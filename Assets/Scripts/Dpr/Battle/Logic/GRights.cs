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

            Initialize();
        }

        public void Initialize()
        {
            for (int i=0; i<m_clientInfo.Length; i++)
            {
                m_clientInfo[i].clientID = BTL_CLIENT_ID.BTL_CLIENT_NULL;
                m_clientInfo[i].isInvalid = false;
            }

            m_clientNum = 0;
            m_assignedClientIdx = 0;
            m_passedTurnCount = 0;
        }

        public void CopyFrom(in GRights src)
        {
            for (int i=0; i<m_clientInfo.Length; i++)
            {
                m_clientInfo[i].clientID = src.m_clientInfo[i].clientID;
                m_clientInfo[i].isInvalid = src.m_clientInfo[i].isInvalid;
            }

            m_clientNum = src.m_clientNum;
            m_assignedClientIdx = src.m_assignedClientIdx;
        }

        public bool IsGRightsRegulationExist()
        {
            return m_clientNum > 1;
        }

        public void AddClient(BTL_CLIENT_ID clientID)
        {
            if (m_clientNum < m_clientInfo.Length)
            {
                m_clientInfo[m_clientNum].clientID = clientID;
                m_clientInfo[m_clientNum].isInvalid = false;
                m_clientNum++;
            }
        }

        public void InvalidateClient(BTL_CLIENT_ID clientID)
        {
            for (int i=0; i!=m_clientInfo.Length; i++)
            {
                if (m_clientInfo[i].clientID == clientID)
                {
                    m_clientInfo[i].isInvalid = true;
                    break;
                }
            }
        }

        public byte GetClientNum()
        {
            return m_clientNum;
        }

        public int GetClientOrder(BTL_CLIENT_ID clientID)
        {
            if (m_clientNum == 0)
                return -1;

            for (int i=0; i<m_clientInfo.Length; i++)
            {
                if (m_clientInfo[i].clientID == clientID)
                    return i;
            }

            return -1;
        }

        public BTL_CLIENT_ID GetClientByOrder(byte order)
        {
            if (order >= m_clientNum)
                return BTL_CLIENT_ID.BTL_CLIENT_NULL;

            return m_clientInfo[order].clientID;
        }

        public BTL_CLIENT_ID GetAssignedClient()
        {
            if (m_clientNum == 0)
                return BTL_CLIENT_ID.BTL_CLIENT_NULL;

            return m_clientInfo[m_assignedClientIdx].clientID;
        }

        public bool TransferRights()
        {
            if (!IsGRightsRegulationExist())
                return false;

            m_assignedClientIdx = getNextAssignTarget(m_assignedClientIdx);
            m_passedTurnCount = 0;
            return true;
        }

        private byte getNextAssignTarget(byte currentIdx)
        {
            if (m_clientNum == 0)
                return currentIdx;

            var newIdx = (byte)((currentIdx + 1) % m_clientNum);

            // Result ignored
            _ = isAssignEnable(m_clientInfo[newIdx]);

            return newIdx;
        }

        private bool isAssignEnable(in ClientInfo clientInfo)
        {
            return true;
        }

        public uint GetPassedTurnCount()
        {
            return m_passedTurnCount;
        }

        public void IncPassedTurnCount()
        {
            if (m_passedTurnCount < DefineConstants.BTL_TURNCOUNT_MAX)
                m_passedTurnCount++;
        }

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