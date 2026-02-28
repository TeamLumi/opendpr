namespace Dpr.Battle.Logic
{
    public sealed class PosPoke
    {
        private State[] m_state;
        private BtlPokePos[] m_lastPosInst;
        private BtlPokePos m_lastPosDmy;

        private void setLastPos(int i, BtlPokePos pos)
        {
        	if (-1 < (int)i) {
        	  if ((int)i < (int)this.m_lastPosInst.Length) {
        	    if (i < this.m_lastPosInst.Length) {
        	      this.m_lastPosInst + (int)i[0] = pos;
        	    }
        	  }
        	}
        	this.m_lastPosDmy = (BtlPokePos)(pos);
        }

        private BtlPokePos getLastPos(int i)
        {
        	if (-1 < (int)i) {
        	  if ((int)i < (int)this.m_lastPosInst.Length) {
        	    if (i < this.m_lastPosInst.Length) {
        	      return this.m_lastPosInst + (int)i[0];
        	    }
        	  }
        	}
        	return this.m_lastPosDmy;
        }

        // TODO
        public PosPoke() { }

        // TODO
        public void CopyFrom(in PosPoke src) { }

        // TODO
        public void Init(MainModule mainModule, POKECON pokeCon) { }

        // TODO
        private void setInitialFrontPokemon(MainModule mainModule, POKECON pokeCon, BtlPokePos pos) { }

        // TODO
        public void ExtendPos(in MainModule mainModule, BtlPokePos pos) { }

        // TODO
        public void PokeOut(byte pokeID) { }

        // TODO
        public void PokeIn(MainModule mainModule, BtlPokePos pos, byte pokeID, POKECON pokeCon) { }

        // TODO
        private void checkConfrontRec(MainModule mainModule, BtlPokePos pos, POKECON pokeCon) { }

        // TODO
        public void Swap(BtlPokePos pos1, BtlPokePos pos2) { }

        // TODO
        private void updateLastPos(BtlPokePos pos) { }

        // TODO
        public byte GetClientEmptyPos(byte clientID, BtlPokePos[] pos) { return 0; }

        // TODO
        public byte GetClientEmptyPosCount(byte clientID) { return 0; }

        // TODO
        public bool IsExist(byte pokeID) { return false; }

        // TODO
        public bool IsExistFrontPos(MainModule mainModule, byte pokeID) { return false; }

        // TODO
        public BtlPokePos GetPokeExistPos(byte pokeID) { return BtlPokePos.POS_1ST_0; }

        public BtlPokePos GetPokeLastPos(byte pokeID)
        {
        	var uVar1 = (uint)pokeID & 0xff;
        	if ((int)this.m_lastPosInst.Length <= (int)uVar1) {
        	  return this.m_lastPosDmy;
        	}
        	if (uVar1 < this.m_lastPosInst.Length) {
        	  return this.m_lastPosInst + (pokeID & 0xff)[0];
        	}
        }

        // TODO
        public byte GetExistPokeID(BtlPokePos pos) { return 0; }

        private sealed class State
        {
            public bool fEnable;
            public byte clientID;
            public byte existPokeID;

            // TODO
            public void CopyFrom(State src) { }

            // TODO
            public State() { }
        }
    }
}