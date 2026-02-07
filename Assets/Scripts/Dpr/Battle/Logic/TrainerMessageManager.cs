namespace Dpr.Battle.Logic
{
    public sealed class TrainerMessageManager
    {
        private readonly MainModule m_pMainModule;
        private ClientData[] m_clientData = Arrays.InitializeWithDefaultInstances<ClientData>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);

        public TrainerMessageManager(MainModule pMainModule)
        {
            m_pMainModule = pMainModule;
            ClearClientData();
        }

        private void ClearClientData()
        {
            for (int i = 0; i < m_clientData.Length; i++)
            {
                for (int j = 0; j < m_clientData[i].isDone.Length; j++)
                    m_clientData[i].isDone[j] = false;
            }
        }

        public bool IsMessageExist(byte clientID, TrainerMessageID messageID)
        {
            if (clientID >= m_clientData.Length)
                return false;

            if ((int)messageID >= (int)TrainerMessageID.MESSAGE_NUM)
                return false;

            return !m_clientData[clientID].isDone[(int)messageID];
        }

        public void Done(byte clientID, TrainerMessageID messageID)
        {
            if (clientID < m_clientData.Length && (int)messageID < (int)TrainerMessageID.MESSAGE_NUM)
                m_clientData[clientID].isDone[(int)messageID] = true;
        }

        private sealed class ClientData
        {
            public bool[] isDone = new bool[(int)TrainerMessageID.MESSAGE_NUM];
        }
    }
}