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

        // TODO
        public void ChangeToNonCommMode() { }

        // TODO
        public bool IsWaitingClientReply() { return false; }

        // TODO
        public unsafe void SetCmd(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* sendData, uint sendDataSize) { }

        // TODO
        public bool WaitCmd() { return false; }

        public SendData GetReturnData() {
            return m_returnData;
        }

        // TODO
        public void ResetCmd() { }

        // TODO
        public void ClearRecvData() { }

        // TODO
        private bool startToReception() { return false; }

        // TODO
        private bool receptionClient() { return false; }

        // TODO
        public void ResetRecvBuffer() { }

        // TODO
        public void RecvCmd(ref ServerRequest serverReq, ref ushort commandSerialNumber, ref ServerSequence serverSeq) { }

        // TODO
        public unsafe uint GetRecvData(void** ppRecv) { return 0; }

        // TODO
        public bool ReturnCmd(in SendData returnData) { return false; }

        // TODO
        public RaidActionIconID GetRaidAction(BTL_CLIENT_ID clientID) { return RaidActionIconID.NONE; }

        // TODO
        public void SetRaidAction(RaidActionIconID action) { }

        // TODO
        public void ClearRaidAction() { }

        // TODO
        public bool CheckTrainerActionRequest(BTL_CLIENT_ID clientID) { return false; }

        // TODO
        public void SetTrainerActionRequest() { }

        // TODO
        public void ClearTrainerActionRequest() { }

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