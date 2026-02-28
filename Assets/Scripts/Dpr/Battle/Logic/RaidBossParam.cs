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

        public float GetHPCoef()
        {
        	return this.m_desc.hpCoef;
        }

        public GWall GetGWallConst()
        {
        	return this.m_gWall;
        }

        public GWall GetGWall()
        {
        	return this.m_gWall;
        }

        public byte GetGrade()
        {
        	return (byte)(this.m_grade);
        }

        public byte GetReinforceTurn()
        {
        	return (byte)(this.m_reinforceTurn);
        }

        public void SetReinforceTurn(byte turn)
        {
        	this.m_reinforceTurn = (byte)(turn);
        }

        public void DecReinforceTurn()
        {
        	if (this.m_reinforceTurn != 0) {
        	  this.m_reinforceTurn = (byte)(this.m_reinforceTurn + -1);
        	}
        }

        public byte GetActionNum()
        {
        	return (byte)(this.m_desc.actNum);
        }

        public byte GetGWazaUseFrequency()
        {
        	return (byte)(this.m_desc.gWazaFrequency);
        }

        public bool IsOnGWazaUseTurn()
        {
        	if ((this.m_desc.gWazaFrequency != 0) && (this.m_gWazaUseTurn == 0))
        	{
        	  return !this.m_gWazaUsed;
        	}
        	return false;
        }

        public void DecGWazaUseTurn()
        {
        	if (this.m_gWazaUseTurn != 0) {
        	  this.m_gWazaUseTurn = (byte)(this.m_gWazaUseTurn + -1);
        	}
        }

        public void SetGWazaUsed()
        {
        	this.m_gWazaUsed = true;
        }

        public void ResetGWazaUseSchedule(byte reUseTurn)
        {
        	this.m_gWazaUsed = false;
        	this.m_gWazaUseTurn = (byte)(reUseTurn);
        }

        public byte GetAngryHPThreshold()
        {
        	if ((uint)this.m_angryLevel < this.m_desc.angryHPThreshold.Length) {
        	  return (byte)(this.m_desc.angryHPThreshold + (ulong)this.m_angryLevel[0]);
        	}
        }

        public void IncAngryLevel()
        {
        	if (this.m_angryLevel < 2) {
        	  if (this.m_desc.angryHPThreshold.Length <= (uint)this.m_angryLevel) {
        	  }
        	  if (this.m_desc.angryHPThreshold + (ulong)this.m_angryLevel[0] != 0) {
        	    this.m_angryLevel = (byte)(this.m_angryLevel + 1);
        	    this.m_gWall.DecrementRepairTurnCountMax();
        	  }
        	}
        }

        public bool IsAngryLevelMax()
        {
        	if (1 < this.m_angryLevel) {
        	  return true;
        	}
        	if ((uint)this.m_angryLevel < this.m_desc.angryHPThreshold.Length) {
        	  return this.m_desc.angryHPThreshold + (ulong)this.m_angryLevel[0] == 0;
        	}
        }

        public bool IsAngry()
        {
        	return this.m_angryLevel != 0;
        }

        public WazaNo GetAngryWaza()
        {
        	if (this.m_angryLevel == 0) {
        	  return (WazaNo)0;
        	}
        	if (this.m_angryLevel - 1 < this.m_desc.angryWazaNo.Length) {
        	  return this.m_desc.angryWazaNo + (int)this.m_angryLevel - 1 * 4[0];
        	}
        }

        public RaidBossAngryWazaTiming GetAngryWazaTiming()
        {
        	if (this.m_angryLevel == 0) {
        	  return (RaidBossAngryWazaTiming)0;
        	}
        	if (this.m_angryLevel - 1 < this.m_desc.angryWazaTimming.Length) {
        	  return this.m_desc.angryWazaTimming + (int)this.m_angryLevel - 1 * 4[0];
        	}
        }

        public class SetupParam
        {
            public byte grade;
            public RaidBossDesc pDesc;
        }
    }
}