using Dpr.Battle.Logic.Net.Data;
using Dpr.NetworkUtils;
using INL1;
using System.Collections;

namespace Dpr.Battle.Logic.Net
{
    public class Client
    {
        // TODO: cctor

        private const int WORK_MAX = 4;
        private static uint s_battleCmdSeqNo;
        private static int[] s_setupStationIndices = new int[WORK_MAX] { -1, -1, -1, -1 };
        private BATTLE_SETUP_PARAM m_pSetupParam;
        private ServerVersions m_serverVesions;
        private byte m_myClientID;
        private int m_myStationIndex;
        private ServerParam m_serverParam;
        private int m_serverParamSignal;
        private SendToClientReq[] sendToClientReq;
        private BattleCommandWork m_uPtrServerCommand;
        private BattleCommandWork[] m_uPtrClientCommand;
        private int m_ErrorKindBit;
        private SignalNetData netData_Signal;
        private ServerVersionNetData netData_ServerVersion;
        private ServerParamNetData netData_ServerParam;
        private BattleCommandSCNetData netData_BattleCommandSC;
        private BattleCommandCSNetData netData_BattleCommandCS;
        private bool isStartDetermineServer;
        private float determineServerTimeout;
        private SendSeverVersionReq[] sendServerVersionReq;
        private bool isTerminated;
        private bool isFinishedSession;
        private const int SEND_SERVER_VERSION_INTERVAL = 15;
        private const TransportType UseTransportType = TransportType.Gamer2;

        private static Client Instance { get => BattleProc.isInstantiated ? BattleProc.Instance.MainModule?.m_iPtrNetClient : null; }
        public int ErrorKindBits { get => m_ErrorKindBit; }

        // TODO
        public Client(BATTLE_SETUP_PARAM bsp) { }

        // TODO
        public void Initialize() { }

        // TODO
        public void Terminate() { }

        public bool IsTerminated() {
            return isTerminated;
        }

        // TODO
        public bool HasErrorOccured(ErrorKind kind = ErrorKind.Invalid) { return false; }

        public bool IsReady() {
            return true;
        }

        // TODO
        public bool StartDetermineServer() { return false; }

        // TODO
        public bool IsDeterminedServer() { return false; }

        // TODO
        public byte GetServerVersion() { return 0; }

        // TODO
        public bool CheckImServer() { return false; }

        // TODO
        public void Update() { }

        public bool ToBeReconnectableMode() {
            return false;
        }

        // TODO
        public void TurnToRaidAIEnableMode() { }

        // TODO
        public void TurnToRaidOnlyMeMode() { }

        public static bool IsShouldDissconetError(int errorKindBits) {
            return false;
        }

        // TODO
        public static ErrorCodeID GetErrorDialogCode(int errorKindBits) { return ErrorCodeID.ErrorNSATokenAuth; }

        // TODO
        private static bool IsErrorKindBit(int errorKindBits, ErrorKind kind) { return false; }

        // TODO
        public void NotifyNetworkError(ErrorKind kind, int arg = 0) { }

        public bool IsClientCommunicationExist(BTL_CLIENT_ID clientId) {
            return true;
        }

        // TODO
        public bool StartNotifyServerParam(in ServerParam serverParam) { return false; }

        // TODO
        public bool StartWaitForNotifyServerParam() { return false; }

        // TODO
        public bool IsNotifiedServerParam() { return false; }

        // TODO
        public ServerParam GetServerParam() { return default; }

        // TODO
        public IEnumerator StartLeaveOnError() { return null; }

        // TODO
        public static void RegisterSetupStationIndices(int index0 = -1, int index1 = -1, int index2 = -1, int index3 = -1) { }

        // TODO
        private static void RemoveSetupStationIndex(int index) { }

        // TODO
        private static bool ExistSetupStationIndex(int index) { return false; }

        // TODO
        public static void SetupNetworkCb() { }

        // TODO
        public static void ReleaseNetworkCb() { }

        // TODO
        private void OnReceivePacketEx(PacketReader pr, TransportType transportType, int receiveStationIndex) { }

        // TODO
        private void OnReceivePacket_Signal(in Signal data, int stationIndex) { }

        // TODO
        private void OnReceivePacket_ServerVersion(in ServerVersion data, int stationIndex) { }

        // TODO
        private void OnReceivePacket_ServerParam(in ServerParam data, int stationIndex) { }

        // TODO
        private void OnReceivePacket_BattleCommandSC(PacketReader pr) { }

        // TODO
        private void OnReceivePacket_BattleCommandCS(PacketReader pr) { }

        // TODO
        private void OnSessionEvent(SessionEventData result) { }

        // TODO
        private void OnFinishedSession() { }

        // TODO
        private static void OnReceivePacketExStatic(PacketReader pr, TransportType transportType, int receiveStationIndex) { }

        // TODO
        private static void OnSessionEventStatic(SessionEventData result) { }

        // TODO
        private static void OnFinishedSessionStatic() { }

        // TODO
        public unsafe bool SendToClient(byte clientId, SEND_DATA_BUFFER* sendBuf, ulong sendSize) { return false; }

        // TODO
        public bool CheckReturnFromClient() { return false; }

        // TODO
        public unsafe bool GetRecvClientData(byte clientId, void** pptr) { return false; }

        // TODO
        private int GetCurrentExistingClientNum() { return 0; }

        // TODO
        public static void IncrementSeq() { }

        // TODO
        private void sendToServerVersionCoreAll() { }

        // TODO
        private bool sendServerVersion(int clientID) { return false; }

        // TODO
        private bool isServerVersionReady() { return false; }

        // TODO
        private int sendToClientCoreAll() { return 0; }

        // TODO
        private int sendToClientCore(byte clientId) { return 0; }

        // TODO
        public bool IsServerCmdReceived() { return false; }

        // TODO
        public unsafe void GetReceivedCmdData(void** ppDest) { }

        // TODO
        public unsafe bool ReturnToServer(void* data, uint size) { return false; }

        // TODO
        public void ClearBattleCommandRecvData() { }

        public bool BroadcastRaidAction(RaidActionIconID actionIconId, BTL_CLIENT_ID clientId) {
            return false;
        }

        // TODO
        public RaidActionIconID GetRaidAction(BTL_CLIENT_ID cliendId) { return default; }

        // TODO
        public void ClearRaidAction() { }

        public bool BroadcastTrainerAction(BTL_CLIENT_ID clientId) {
            return false;
        }

        public bool CheckTrainerAction(BTL_CLIENT_ID cliendId) {
            return false;
        }

        // TODO
        public void ClearTrainerAction() { }

        // TODO
        private int GetStationNumFromBSP() { return 0; }

        // TODO
        private bool IsExistStationIndexOnBSP(int stationIndex) { return false; }

        // TODO
        private int countBits(byte bits) { return 0; }

        // TODO
        private int SendReliablePacket(PacketWriterRe pwRe, int stationIndex) { return 0; }

        // TODO
        private int SendReliableData<T>(ANetData<T> data, int stationIndex) { return 0; }

        private struct SendToClientReq
        {
            public const int HEADER_SIZE = 17;
            public const int WRITABLE_SIZE = 1007;
            public ulong sendBuf;
            public int sendSize;
            public int donenum;

            // TODO
            public int GetDivNum() { return 0; }

            // TODO
            public bool GetOfs(out int outOfs, out int outBytes, int index)
            {
                outOfs = 0;
                outBytes = 0;
                return false;
            }

            // TODO
            public static int GetDivNum(int size) { return 0; }

            // TODO
            public static bool GetOfs(out int outOfs, out int outBytes, int size, int index)
            {
                outOfs = 0;
                outBytes = 0;
                return false;
            }

            // TODO
            public void Set(ulong pSendBuf, int sendSize) { }

            // TODO
            public void Clear() { }
        }

        private class BattleCommandWork
        {
            public const int BUFFER_SIZE = 10012;
            public byte clientId;
            public ulong cmdSeqNo;
            public bool isChecked;
            public unsafe byte* body;

            public BattleCommandWork()
            {
                unsafe
                {
                    body = (byte*)BattleUnmanagedMem.Malloc(BUFFER_SIZE);
                }
            }

            public void Set(byte clientId, ulong cmdSeqNo)
            {
                this.clientId = clientId;
                this.cmdSeqNo = cmdSeqNo;
            }

            public void Initialize()
            {
                clientId = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
                cmdSeqNo = 0;
                isChecked = false;
            }

            public bool IsValid()
            {
                return clientId != (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
            }
        }

        private struct SendSeverVersionReq
        {
            public ushort receivedFlag;
            public byte interval;

            // TODO
            public void SetReceivedFlag(ushort flag) { }

            // TODO
            public bool SetReceivedFlagRange(byte src, byte flag) { return false; }

            // TODO
            public int countNum(int src) { return 0; }
        }

        public enum ErrorKind : int
        {
            Invalid = 0,
            Leave_Mine = 1,
            Leave_Other = 2,
            GamingError = 3,
            Crash = 4,
            ResumeGame = 5,
            Timeout = 6,
            CmdIllegal = 7,
            Inconsistent = 8,
            SendError = 9,
            LeaveBattle = 10,
        }
    }
}