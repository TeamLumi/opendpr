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

        public void IncAllDeadCount()
        {
        	if (this.m_allDeadCount < 4) {
        	  this.m_allDeadCount = (byte)(this.m_allDeadCount + 1);
        	}
        }

        public bool IsAllDeadCountMax()
        {
        	return 3 < this.m_allDeadCount;
        }

        // TODO
        public ushort GetTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { return 0; }

        // TODO
        public void IncTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

        // TODO
        public void ResetTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

        public void PlayBtlEffectKill()
        {
        	this.m_isPlayBtlEffectKill = true;
        }

        public bool IsPlayBtlEffectKill()
        {
        	return this.m_isPlayBtlEffectKill;
        }
    }
}