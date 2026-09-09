using Pml;
using Pml.Personal;

namespace Dpr.Battle.Logic
{
    public class RaidBossParam
    {
        private GWall m_gWall;
        private RaidBossDesc m_desc = new RaidBossDesc();
        private byte m_grade;
        private byte m_reinforceTurn;
        private byte m_angryLevel;
        private byte m_gWazaUseTurn;
        private bool m_gWazaUsed;

        public RaidBossParam()
        {
            m_gWall = null;

            m_gWazaUsed = false;
            m_grade = 0;
            m_reinforceTurn = 0;
            m_angryLevel = 0;
            m_gWazaUseTurn = 0;

            m_gWall = new GWall();
        }

        // TODO
        public void CopyFrom(in RaidBossParam src) { }

        // TODO
        public void Setup(in SetupParam param) { }

        // TODO
        public float GetHPCoef() { return 0f; }

        public GWall GetGWallConst() {
            return m_gWall;
        }

        public GWall GetGWall() {
            return m_gWall;
        }

        public byte GetGrade() {
            return m_grade;
        }

        public byte GetReinforceTurn() {
            return m_reinforceTurn;
        }

        public void SetReinforceTurn(byte turn) {
            this.m_reinforceTurn = turn;
        }

        // TODO
        public void DecReinforceTurn() { }

        // TODO
        public byte GetActionNum() { return 0; }

        // TODO
        public byte GetGWazaUseFrequency() { return 0; }

        // TODO
        public bool IsOnGWazaUseTurn() { return false; }

        // TODO
        public void DecGWazaUseTurn() { }

        // TODO
        public void SetGWazaUsed() { }

        // TODO
        public void ResetGWazaUseSchedule(byte reUseTurn) { }

        // TODO
        public byte GetAngryHPThreshold() { return 0; }

        // TODO
        public void IncAngryLevel() { }

        // TODO
        public bool IsAngryLevelMax() { return false; }

        // TODO
        public bool IsAngry() { return false; }

        // TODO
        public WazaNo GetAngryWaza() { return WazaNo.NULL; }

        // TODO
        public RaidBossAngryWazaTiming GetAngryWazaTiming() { return RaidBossAngryWazaTiming.NONE; }

        public class SetupParam
        {
            public byte grade;
            public RaidBossDesc pDesc;
        }
    }
}