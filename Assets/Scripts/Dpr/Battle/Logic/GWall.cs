namespace Dpr.Battle.Logic
{
    public sealed class GWall
    {
        private bool m_isAppeared;
        private byte m_gaugeMax;
        private byte m_gaugeNow;
        private byte m_gaugeInit;
        private byte m_repairTurnCount;
        private byte m_repairTurnMax;

        public GWall()
        {
            m_repairTurnCount = 0;
            m_repairTurnMax = 0;
            m_isAppeared = false;
            m_gaugeMax = 0;
            m_gaugeNow = 0;
            m_gaugeInit = 0;
        }

        // TODO
        public void CopyFrom(in GWall src) { }

        // TODO
        public void Setup(byte gaugeMax, byte gaugeInit, byte repairTurn) { }

        // TODO
        public void SetAppear() { }

        public bool IsAppeared() {
            return m_isAppeared;
        }

        // TODO
        public bool IsActive() { return false; }

        // TODO
        public bool IsBroken() { return false; }

        public byte GetGauseMax() {
            return m_gaugeMax;
        }

        public byte GetGaugeNow() {
            return m_gaugeNow;
        }

        public byte GetGauseInit() {
            return m_gaugeInit;
        }

        // TODO
        public void InitGauge() { }

        // TODO
        public void SetGauge(byte value) { }

        // TODO
        public void AddGauge(byte value) { }

        // TODO
        public void SubGauge(byte value) { }

        // TODO
        public bool IsGaugeZero() { return false; }

        // TODO
        public bool IsGaugeFull() { return false; }

        public byte GetRepairTurnCount() {
            return m_repairTurnCount;
        }

        // TODO
        public void DecrementRepairTurnCount() { }

        // TODO
        public void SetRepairTurnCountMax() { }

        // TODO
        public void DecrementRepairTurnCountMax() { }
    }
}