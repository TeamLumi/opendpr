using Dpr.Battle.Logic.Net;

namespace Dpr.Battle.Logic
{
    public sealed class Adapter
    {
        private Client m_iPtrNetClient;
        private SendData m_sendData = new SendData();
        private SendData m_returnData = new SendData();
        private ServerRequest m_processingRequest;
        private byte m_myClientId;
        private State m_state;
        private bool m_isRetDataPrepared;
        private bool m_isCommMode;
        private RaidActionIconID m_raidActionIcon;

        public Adapter(byte clientID, bool isCommMode, Client iPtrNetClient)
        {
            m_iPtrNetClient = iPtrNetClient;
            m_processingRequest = ServerRequest.NONE;
            m_myClientId = clientID;
            m_state = State.kFree;
            m_isRetDataPrepared = false;
            m_isCommMode = isCommMode;
            m_raidActionIcon = RaidActionIconID.NONE;
        }

        public void Init()
        {
            m_state = State.kFree;
            m_processingRequest = ServerRequest.NONE;
            m_isRetDataPrepared = false;
        }

        public void ChangeToNonCommMode()
        {
        	this.m_isCommMode = false;
        }

        public bool IsWaitingClientReply()
        {
        	return (int)this.m_state == 3;
        }

        public unsafe void SetCmd(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* sendData, uint sendDataSize)
        {
        	if ((int)this.m_state != 0) {
        	}
        	this.m_processingRequest = (ServerRequest)(serverReq);
        	this.m_state = (State)1;
        	this.m_sendData.Store();
        	this.m_returnData.Clear();
        	this.m_isRetDataPrepared = false;
        }

        // TODO
        public bool WaitCmd() { return false; }

        public SendData GetReturnData()
        {
        	return this.m_returnData;
        }

        public void ResetCmd()
        {
        	this.m_state = (State)0;
        	if (this.m_isCommMode) {
        	  this.m_iPtrNetClient.ClearBattleCommandRecvData();
        	}
        }

        public void ClearRecvData()
        {
        	if (this.m_isCommMode) {
        	  this.m_iPtrNetClient.ClearBattleCommandRecvData();
        	}
        }

        // TODO
        private bool startToReception() { return false; }

        // TODO
        private bool receptionClient() { return false; }

        public void ResetRecvBuffer()
        {
        	this.m_sendData.Clear();
        }

        // TODO
        public void RecvCmd(ref ServerRequest serverReq, ref ushort commandSerialNumber, ref ServerSequence serverSeq) { }

        // TODO
        public unsafe uint GetRecvData(void** ppRecv) { return 0; }

        // TODO
        public bool ReturnCmd(in SendData returnData) { return false; }

        public RaidActionIconID GetRaidAction(BTL_CLIENT_ID clientID)
        {
        	if (this.m_iPtrNetClient != null) {
        	  return this.m_iPtrNetClient.GetRaidAction(clientID);
        	}
        	return (ulong)this.m_raidActionIcon;
        }

        // TODO
        public void SetRaidAction(RaidActionIconID action) { }

        public void ClearRaidAction()
        {
        	if (this.m_iPtrNetClient != null) {
        	  this.m_iPtrNetClient.ClearRaidAction();
        	}
        	this.m_raidActionIcon = (RaidActionIconID)0;
        }

        public bool CheckTrainerActionRequest(BTL_CLIENT_ID clientID)
        {
        	if (this.m_iPtrNetClient != null) {
        	  this.m_iPtrNetClient.CheckTrainerAction(clientID);
        	}
        	return false;
        }

        // TODO
        public void SetTrainerActionRequest() { }

        public void ClearTrainerActionRequest()
        {
        	if (this.m_iPtrNetClient != null) {
        	  this.m_iPtrNetClient.ClearTrainerAction();
        	}
        }

        private enum State : int
        {
            kFree = 0,
            kCmdRecieved = 1,
            kWaitSendToClient = 2,
            kWaitRecvFromClient = 3,
            kDone = 4,
        }
    }
}