namespace Dpr.Battle.Logic
{
    public sealed class GRights
    {
        private readonly MainModule m_pMainModule;
        private readonly BattleEnv m_pBattleEnv;
        private ClientInfo[] m_clientInfo = Arrays.InitializeWithDefaultInstances<ClientInfo>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        private byte m_clientNum;
        private byte m_assignedClientIdx;
        private uint m_passedTurnCount;

        public GRights(MainModule pMainModule, BattleEnv pBattleEnv)
        {
            m_pMainModule = pMainModule;
            m_pBattleEnv = pBattleEnv;

            for (int i=0; i<m_clientInfo.Length; i++)
            {
                m_clientInfo[i].clientID = BTL_CLIENT_ID.BTL_CLIENT_NULL;
                m_clientInfo[i].isInvalid = false;
            }

            m_clientNum = 0;
            m_assignedClientIdx = 0;
            m_passedTurnCount = 0;
        }

        // TODO
        public void Initialize() { }

        // TODO
        public void CopyFrom(in GRights src) { }

        // TODO
        public bool IsGRightsRegulationExist() { return false; }

        // TODO
        public void AddClient(BTL_CLIENT_ID clientID) { }

        // TODO
        public void InvalidateClient(BTL_CLIENT_ID clientID) { }

        public byte GetClientNum() {
            return m_clientNum;
        }

        // TODO
        public int GetClientOrder(BTL_CLIENT_ID clientID) { return 0; }

        // TODO
        public BTL_CLIENT_ID GetClientByOrder(byte order) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        public BTL_CLIENT_ID GetAssignedClient() { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        public bool TransferRights() { return false; }

        // TODO
        private byte getNextAssignTarget(byte currentIdx) { return 0; }

        private bool isAssignEnable(in ClientInfo clientInfo) {
            return true;
        }

        public uint GetPassedTurnCount() {
            return m_passedTurnCount;
        }

        // TODO
        public void IncPassedTurnCount() { }

        private class ClientInfo
        {
            public BTL_CLIENT_ID clientID;
            public bool isInvalid;

            public void CopyFrom(ClientInfo src)
            {
                clientID = src.clientID;
                isInvalid = src.isInvalid;
            }
        }
    }
}