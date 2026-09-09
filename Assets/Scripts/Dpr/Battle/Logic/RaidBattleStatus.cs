namespace Dpr.Battle.Logic
{
    public sealed class RaidBattleStatus
    {
        private byte m_allDeadCount;
        private ushort[] m_turnCountAfterAllDead = new ushort[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private bool m_isPlayBtlEffectKill;

        public RaidBattleStatus()
        {
            Initialize();
        }

        public void Initialize()
        {
            m_allDeadCount = 0;

            for (int i=0; i<m_turnCountAfterAllDead.Length; i++)
                m_turnCountAfterAllDead[i] = 0;

            m_isPlayBtlEffectKill = false;
        }

        public void CopyFrom(in RaidBattleStatus src)
        {
            m_allDeadCount = src.m_allDeadCount;

            for (int i=0; i<m_turnCountAfterAllDead.Length; i++)
                m_turnCountAfterAllDead[i] = src.m_turnCountAfterAllDead[i];

            m_isPlayBtlEffectKill = src.m_isPlayBtlEffectKill;
        }

        public byte GetAllDeadCount()
        {
            return m_allDeadCount;
        }

        // TODO
        public void IncAllDeadCount() { }

        // TODO
        public bool IsAllDeadCountMax() { return false; }

        // TODO
        public ushort GetTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { return 0; }

        // TODO
        public void IncTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

        // TODO
        public void ResetTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

        // TODO
        public void PlayBtlEffectKill() { }

        public bool IsPlayBtlEffectKill() {
            return m_isPlayBtlEffectKill;
        }
    }
}