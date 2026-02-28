namespace Dpr.Battle.Logic
{
    public sealed class PosEffectStatus
    {
        private Data m_data = new Data();

        public PosEffectStatus(BtlPokePos pos, BtlPosEffect posEffect)
        {
            m_data.pos = pos;
            m_data.posEffect = posEffect;
            m_data­.isEffective = false;
        }

        public void CopyFrom(in PosEffectStatus src)
        {
            m_data.CopyFrom(src.m_data);
        }

        public bool SetEffect(in PosEffect.EffectParam effectParam)
        {
        	if (this.m_data.isEffective != 0) {
        	  return false;
        	}
        	this.m_data.effectParam = effectParam;
        	this.m_data.isEffective = 1;
        	return true;
        }

        public void RemoveEffect()
        {
        	this.m_data.isEffective = 0;
        }

        public bool IsEffective()
        {
        	return this.m_data.isEffective;
        }

        public PosEffect.EffectParam GetEffectParam()
        {
        	return this.m_data.effectParam;
        }

        public void SetEffectParam(in PosEffect.EffectParam effectParam)
        {
        	this.m_data.effectParam = effectParam;
        }

        public BtlPokePos GetPokePos()
        {
        	return this.m_data.pos;
        }

        public BtlPosEffect GetPosEffect()
        {
        	return this.m_data.posEffect;
        }

        private class Data
        {
            public BtlPokePos pos;
            public BtlPosEffect posEffect;
            public bool isEffective;
            public PosEffect.EffectParam effectParam;

            public void CopyFrom(Data src)
            {
                pos = src.pos;
                posEffect = src.posEffect;
                isEffective = src.isEffective;
                effectParam = src.effectParam;
            }
        }
    }
}