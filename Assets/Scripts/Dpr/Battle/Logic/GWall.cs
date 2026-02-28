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

        public void Setup(byte gaugeMax, byte gaugeInit, byte repairTurn)
        {
        	var bVar1 = gaugeMax;
        	if (gaugeInit <= gaugeMax) {
        	  bVar1 = (byte)(gaugeInit);
        	}
        	this.m_gaugeMax = (byte)(gaugeMax);
        	this.m_gaugeInit = (byte)(gaugeInit);
        	this.m_repairTurnMax = (byte)(repairTurn);
        	this.m_repairTurnCount = (byte)(repairTurn);
        	this.m_gaugeNow = (byte)(bVar1);
        }

        public void SetAppear()
        {
        	this.m_isAppeared = true;
        }

        public bool IsAppeared()
        {
        	return this.m_isAppeared;
        }

        public bool IsActive()
        {
        	if (this.m_isAppeared) {
        	  return this.m_gaugeNow != 0;
        	}
        	return false;
        }

        public bool IsBroken()
        {
        	if (this.m_isAppeared) {
        	  return this.m_gaugeNow == 0;
        	}
        	return false;
        }

        public byte GetGauseMax()
        {
        	return (byte)(this.m_gaugeMax);
        }

        public byte GetGaugeNow()
        {
        	return (byte)(this.m_gaugeNow);
        }

        public byte GetGauseInit()
        {
        	return (byte)(this.m_gaugeInit);
        }

        public void InitGauge()
        {
        	if (this.m_gaugeInit <= this.m_gaugeMax) {
        	}
        	this.m_gaugeNow = (byte)(this.m_gaugeInit);
        }

        public void SetGauge(byte value)
        {
        	if (value <= this.m_gaugeMax) {
        	  this.m_gaugeMax = (byte)(value);
        	}
        	this.m_gaugeNow = (byte)(this.m_gaugeMax);
        }

        public void AddGauge(byte value)
        {
        	if (this.m_gaugeNow + value <= this.m_gaugeMax) {
        	  this.m_gaugeMax = (byte)(this.m_gaugeNow + value);
        	}
        	this.m_gaugeNow = (byte)(this.m_gaugeMax);
        }

        public void SubGauge(byte value)
        {
        	var uVar1 = 0;
        	if ((uint)(value * 0x1000000) <= (uint)this.m_gaugeNow * 0x1000000) {
        	  uVar1 = (char)((uint)this.m_gaugeNow * 0x1000000 + value * -0x1000000 >> 0x18);
        	}
        	this.m_gaugeNow = (byte)(uVar1);
        }

        public bool IsGaugeZero()
        {
        	return this.m_gaugeNow == 0;
        }

        public bool IsGaugeFull()
        {
        	return this.m_gaugeMax <= this.m_gaugeNow;
        }

        public byte GetRepairTurnCount()
        {
        	return (byte)(this.m_repairTurnCount);
        }

        public void DecrementRepairTurnCount()
        {
        	if (this.m_repairTurnCount != 0) {
        	  this.m_repairTurnCount = (byte)(this.m_repairTurnCount + -1);
        	}
        }

        public void SetRepairTurnCountMax()
        {
        	this.m_repairTurnCount = (byte)(this.m_repairTurnMax);
        }

        public void DecrementRepairTurnCountMax()
        {
        	if (this.m_repairTurnMax != 0) {
        	  this.m_repairTurnMax = (byte)(this.m_repairTurnMax + -1);
        	}
        }
    }
}