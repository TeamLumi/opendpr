namespace Dpr.Battle.Logic
{
    public sealed class PokeSelResult
    {
        private BTL_CLIENT_ID m_myClientID;
        private BTL_CLIENT_ID[] m_selClientID = new BTL_CLIENT_ID[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte[] m_selIdx = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte[] m_outPokeIdx = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private ushort[] m_useItem = new ushort[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private byte[] m_wazaIdx = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte m_cnt;
        private byte m_max;
        private bool m_fCancel;

        public byte GetSelectMax()
        {
        	return (byte)(this.m_max);
        }

        // TODO
        public void Init(PokeSelParam param) { }

        public void Push(byte outPokeIdx, byte selPokeIdx)
        {
        	if ((uint)this.m_max <= (uint)this.m_cnt) {
        	}
        	if ((uint)this.m_cnt < this.m_selClientID.Length) {
        	  this.m_selClientID + (ulong)this.m_cnt * 4[0] =
        	       this.m_myClientID;
        	  if ((uint)this.m_cnt < this.m_selIdx.Length) {
        	    this.m_selIdx + (ulong)this.m_cnt[0] = selPokeIdx
        	    ;
        	    if ((uint)this.m_cnt < this.m_outPokeIdx.Length) {
        	      this.m_outPokeIdx + (ulong)this.m_cnt[0] =
        	           outPokeIdx;
        	      if ((uint)this.m_cnt < this.m_useItem.Length) {
        	        this.m_useItem + (ulong)this.m_cnt * 2[0] =
        	             0;
        	        if ((uint)this.m_cnt < this.m_wazaIdx.Length) {
        	          this.m_wazaIdx + (ulong)this.m_cnt[0] = 0
        	          ;
        	          this.m_cnt = (byte)(this.m_cnt + '\x01');
        	        }
        	      }
        	    }
        	  }
        	}
        }

        public void Pop()
        {
        	if (this.m_cnt != 0) {
        	  this.m_cnt = (byte)(this.m_cnt + -1);
        	}
        }

        public void SetCancel(bool flg)
        {
        	this.m_fCancel = (flg ? 1 : 0) & 1;
        }

        public bool IsCancel()
        {
        	return this.m_fCancel;
        }

        public bool IsDone()
        {
        	return this.m_cnt == this.m_max;
        }

        public byte GetCount()
        {
        	return (byte)(this.m_cnt);
        }

        public byte GetLast()
        {
        	if ((ulong)this.m_cnt == 0) {
        	  return 6;
        	}
        	if ((uint)(ulong)this.m_cnt - 1 < this.m_selIdx.Length) {
        	  return (byte)(this.m_selIdx + (ulong)this.m_cnt - 1[0]);
        	}
        }

        public byte Get(byte idx)
        {
        	if (this.m_cnt <= idx) {
        	  return 6;
        	}
        	if ((uint)idx < this.m_selIdx.Length) {
        	  return (byte)(this.m_selIdx + (ulong)idx[0]);
        	}
        }

        public void SetItemUse(BTL_CLIENT_ID clientID, byte pokeIdx, ushort itemNo, byte wazaIdx = 0)
        {
        	if ((uint)this.m_max <= (uint)this.m_cnt) {
        	}
        	if ((uint)this.m_cnt < this.m_selClientID.Length) {
        	  this.m_selClientID + (ulong)this.m_cnt * 4[0] = clientID;
        	  if ((uint)this.m_cnt < this.m_selIdx.Length) {
        	    this.m_selIdx + (ulong)this.m_cnt[0] = pokeIdx
        	    ;
        	    if ((uint)this.m_cnt < this.m_outPokeIdx.Length) {
        	      this.m_outPokeIdx + (ulong)this.m_cnt[0] = 0;
        	      if ((uint)this.m_cnt < this.m_useItem.Length) {
        	        this.m_useItem + (ulong)this.m_cnt * 2[0] =
        	             itemNo;
        	        if ((uint)this.m_cnt < this.m_wazaIdx.Length) {
        	          this.m_wazaIdx + (ulong)this.m_cnt[0] =
        	               wazaIdx;
        	          this.m_cnt = (byte)(this.m_cnt + '\x01');
        	        }
        	      }
        	    }
        	  }
        	}
        }

        // TODO
        public bool IsItemUse(out BTL_CLIENT_ID clientID, out byte pokeIdx, out ushort itemNo, out byte wazaIdx)
        {
            clientID = BTL_CLIENT_ID.BTL_CLIENT_PLAYER;
            pokeIdx = 0;
            itemNo = 0;
            wazaIdx = 0;
            return false;
        }
    }
}