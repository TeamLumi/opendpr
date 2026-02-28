namespace Dpr.Battle.Logic
{
    public sealed class SideEffectStatus
    {
        private DATA m_data = new DATA();

        public SideEffectStatus(BtlSideEffect sideEffect)
        {
            m_data.sideEffect = sideEffect;
        }

        public void CopyFrom(in SideEffectStatus src)
        {
            m_data.CopyFrom(src.m_data);
        }

        // TODO
        public void SwapFrom(SideEffectStatus target) { }

        // TODO
        public bool AddEffect(in BTL_SICKCONT contParam) { return false; }

        public bool RemoveEffect()
        {
        	if (this.m_data.add_counter != 0) {
        	  this.m_data.add_counter = 0;
        	  this.m_data.turn_counter = 0;
        	  BTL_SICKCONT.set_type(this.m_data + 0x18,0);
        	  return true;
        	}
        	return false;
        }

        public bool IsEffective()
        {
        	return this.m_data.add_counter != 0;
        }

        public uint GetAddCount()
        {
        	return this.m_data.add_counter;
        }

        public uint GetMaxTurnCount()
        {
        	return BTL_SICKCONT.get_turn_count(this.m_data + 0x18);
        }

        public uint GetCurrentTurnCount()
        {
        	return this.m_data.turn_counter;
        }

        public uint GetRemainingTurn()
        {
        	return (BTL_SICKCONT.get_turn_count(this.m_data + 0x18) & 0xff) - this.m_data.turn_counter;
        }

        // TODO
        public uint GetTurnUpCount() { return 0; }

        // TODO
        public byte GetCausePokeID() { return 0; }

        public void IncTurnCount()
        {
        	this.m_data.turn_counter = this.m_data.turn_counter + 1;
        }

        public bool IsTurnPassed()
        {
        	return (uint)BTL_SICKCONT.get_turn_count(this.m_data + 0x18) <= this.m_data.turn_counter;
        }

        public BTL_SICKCONT GetContParam()
        {
            return m_data.contParam;
        }

        private class DATA
        {
            public BtlSideEffect sideEffect;
            public BTL_SICKCONT contParam;
            public uint turn_counter;
            public uint add_counter;

            public void CopyFrom(DATA src)
            {
                sideEffect = src.sideEffect;
                contParam = src.contParam;
                turn_counter = src.turn_counter;
                add_counter = src.add_counter;
            }
        }
    }
}