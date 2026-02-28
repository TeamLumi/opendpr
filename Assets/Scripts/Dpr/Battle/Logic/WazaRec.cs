using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class WazaRec
    {
        public const int TURN_MAX = 20;
        public const int RECORD_MAX = 400;
        private uint m_ptr;
        private RECORD[] m_record;

        // TODO
        public WazaRec() { }

        // TODO
        public void CopyFrom(in WazaRec src) { }

        // TODO
        public void Init() { }

        public unsafe void Add(WazaNo waza, uint turn, byte pokeID)
        {
        	if (this.m_ptr < this.m_record.Length) {
        	  *(uint *)
        	   (this.m_record + (ulong)this.m_ptr * 8[0] + 0x14) =
        	       waza;
        	  if (this.m_ptr < this.m_record.Length) {
        	    *(uint *)
        	     (this.m_record + (ulong)this.m_ptr * 8[0] + 0x10) =
        	         turn;
        	    if (this.m_ptr < this.m_record.Length) {
        	      *(byte *)
        	       (this.m_record + (ulong)this.m_ptr * 8[0] + 0x18)
        	           = pokeID;
        	      if (this.m_ptr < this.m_record.Length) {
        	        *(byte *)
        	         (this.m_record + (ulong)this.m_ptr * 8[0] +
        	         0x19) = 0;
        	        var uVar1 = this.m_ptr + 1;
        	        this.m_ptr = uVar1;
        	        var iVar2 = 0;
        	        if ((long)(ulong)uVar1 < (long)this.m_record.Length) {
        	          iVar2 = this.m_ptr + 1;
        	        }
        	        this.m_ptr = iVar2;
        	      }
        	    }
        	  }
        	}
        }

        // TODO
        public void SetEffectiveLast() { }

        // TODO
        public bool IsUsedWaza(WazaNo waza, uint turn) { return false; }

        // TODO
        public uint GetUsedWazaCount(WazaNo waza, uint turn) { return 0; }

        // TODO
        public WazaNo GetPrevEffectiveWaza(uint turn) { return WazaNo.NULL; }

        private class RECORD
        {
            public uint turn;
            public WazaNo wazaID;
            public byte pokeID;
            public bool fEffective;

            // TODO
            public void CopyFrom(RECORD src) { }

            // TODO
            public RECORD() { }
        }
    }
}