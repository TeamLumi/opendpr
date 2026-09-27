namespace Dpr.Battle.Logic
{
    public sealed class GRightsManager
    {
        private readonly MainModule m_pMainModule;
        private GRights[] m_gRights = new GRights[(int)BtlSide.BTL_SIDE_NUM];

        public GRightsManager(MainModule pMainModule, BattleEnv pBattleEnv)
        {
            m_pMainModule = pMainModule;

            createGRights(pMainModule, pBattleEnv);
            Initialize();
        }

        private void createGRights(MainModule pMainModule, BattleEnv pBattleEnv)
        {
            m_gRights[(int)BtlSide.BTL_SIDE_1ST] = new GRights(pMainModule, pBattleEnv);
            m_gRights[(int)BtlSide.BTL_SIDE_2ND] = new GRights(pMainModule, pBattleEnv);
        }

        public void Initialize()
        {
            for (int i=0; i<m_gRights.Length; i++)
                m_gRights[i].Initialize();
        }

        public void CopyFrom(in GRightsManager src)
        {
            for (int i=0; i<m_gRights.Length; i++)
                m_gRights[i].CopyFrom(src.GetGRights((BtlSide)i));
        }

        public void AddClient(BTL_CLIENT_ID clientID)
        {
            var side = m_pMainModule.GetClientSide((byte)clientID);
            if (side >= BtlSide.BTL_SIDE_NUM)
                return;

            m_gRights[(int)side].AddClient(clientID);
        }

        public GRights GetGRights(BtlSide side)
        {
            return m_gRights[(int)side];
        }
    }
}