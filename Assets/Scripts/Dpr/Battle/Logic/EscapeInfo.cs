namespace Dpr.Battle.Logic
{
    public sealed class EscapeInfo
    {
        private PARAM m_param = new PARAM();

        public uint GetCount()
        {
            return m_param.count;
        }

        private void clear()
        {
            m_param.count = 0;

            for (int i=0; i<m_param.clientID.Length; i++)
                m_param.clientID[i] = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
        }

        public EscapeInfo()
        {
            Clear();
        }

        public void Clear()
        {
            clear();
        }

        public void Add(byte clientID)
        {
            if (m_param.count < m_param.clientID.Length)
            {
                m_param.clientID[m_param.count] = clientID;
                m_param.count++;
            }
        }

        public BtlResult CheckWinner(in MainModule mainModule, byte myClientID, BtlCompetitor competitorType)
        {
            for (uint i = 0; i < m_param.count; i++)
            {
                byte escapedClientID = m_param.clientID[i];
                if (escapedClientID == myClientID)
                    return BtlResult.BTL_RESULT_RUN;

                if (mainModule.IsOpponentClientID(myClientID, escapedClientID))
                    return BtlResult.BTL_RESULT_RUN_ENEMY;
            }

            return BtlResult.BTL_RESULT_LOSE;
        }

        public void Copy(EscapeInfo dst)
        {
            dst.m_param.count = m_param.count;
            for (int i = 0; i < m_param.clientID.Length; i++)
                dst.m_param.clientID[i] = m_param.clientID[i];
        }

        private class PARAM
        {
            public uint count;
            public byte[] clientID = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        }
    }
}