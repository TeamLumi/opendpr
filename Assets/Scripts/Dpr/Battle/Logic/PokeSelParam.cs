namespace Dpr.Battle.Logic
{
    public sealed class PokeSelParam
    {
        private BTL_CLIENT_ID m_clientID;
        private BTL_PARTY m_party;
        private byte m_numSelect;
        private bool m_bDisabledPutPosSequence;
        private byte[] m_prohibit = new byte[DefineConstants.BTL_PARTY_MEMBER_MAX];

        public BTL_PARTY GetParty()
        {
        	return this.m_party;
        }

        // TODO
        public void Init(BTL_CLIENT_ID clientID, BTL_PARTY party, byte numSelect) { }

        public void SetProhibitFighting(byte numCover)
        {
        	if (numCover != 0) {
        	  var lVar3 = 0;
        	  do {
        	    if (this.m_prohibit.Length <= (uint)lVar3) {
        	    }
        	    lVar3 = lVar3 + 1;
        	    this.m_prohibit + lVar3[0] = 2;
        	  } while ((uint)numCover != (uint)lVar3);
        	}
        }

        public void SetProhibit(PokeselReason reason, byte idx)
        {
        	if ((uint)idx < this.m_prohibit.Length) {
        	  this.m_prohibit + (ulong)idx[0] = reason;
        	}
        }

        public BTL_CLIENT_ID GetClientID()
        {
        	return this.m_clientID;
        }

        public byte GetNumSelect()
        {
        	return (byte)(this.m_numSelect);
        }

        public void DisablePutPosSequence()
        {
        	this.m_bDisabledPutPosSequence = true;
        }

        public bool IsDisabledPutPosSequence()
        {
        	return this.m_bDisabledPutPosSequence;
        }
    }
}