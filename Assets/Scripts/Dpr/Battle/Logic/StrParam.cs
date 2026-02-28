namespace Dpr.Battle.Logic
{
    public sealed class StrParam
    {
        private Param m_param;

        // TODO
        public StrParam() { }

        // TODO
        public StrParam(in StrParam src) { }

        // TODO
        public void CopyFrom(in StrParam src) { }

        public void Clear()
        {
        	this.m_param.ID = 0;
        	var lVar4 = this.m_param.args;
        	if (0 < (int)lVar4.Length) {
        	  var uVar5 = 0;
        	  var uVar6 = lVar4.Length & 0xffffffff;
        	  do {
        	    if (uVar6 <= uVar5) {
        	    }
        	    var lVar1 = uVar5 * 4;
        	    uVar5 = uVar5 + 1;
        	    lVar4 + lVar1[0] = 0;
        	    lVar4 = this.m_param.args;
        	    uVar6 = (ulong)lVar4.Length;
        	  } while ((long)uVar5 < (int)lVar4.Length);
        	}
        	this.m_param.type = 0;
        }

        public bool IsEnable()
        {
        	return this.m_param.type != 0;
        }

        public void Setup(BtlStrType type, ushort strID)
        {
        	this.m_param.type = type;
        	this.m_param.ID = strID;
        	this.m_param.argCnt = 0;
        }

        public ushort GetStrID()
        {
        	return (ushort)(this.m_param.ID);
        }

        public BtlStrType GetStrType()
        {
        	return this.m_param.type;
        }

        // TODO
        public void AddArg(int arg) { }

        public void ChangeArg(byte index, int value)
        {
        	var uVar1 = (uint)index & 0xff;
        	if (uVar1 < this.m_param.argCnt) {
        	  if (this.m_param.args.Length <= uVar1) {
        	  }
        	  this.m_param.args + (index & 0xff) * 4[0] = value;
        	}
        }

        public ushort GetArgsCount()
        {
        	return (ushort)(this.m_param.argCnt);
        }

        public int[] GetArgs()
        {
        	return this.m_param.args;
        }

        // TODO
        public void AddSE(uint SENo) { }

        public bool IsSEAdded()
        {
        	return this.m_param.fSEAdd;
        }

        // TODO
        public int GetSE() { return 0; }

        public void SetFailMsgFlag()
        {
        	this.m_param.fFailMsg = 1;
        }

        public bool IsFailMsg()
        {
        	return this.m_param.fFailMsg;
        }

        private class Param
        {
            public ushort ID;
            public ushort type;
            public ushort argCnt;
            public bool fSEAdd;
            public bool fFailMsg;
            public int[] args;

            // TODO
            public void CopyFrom(Param src) { }

            public void Clear()
            {
            	this.m_param.ID = 0;
            	var lVar4 = this.m_param.args;
            	if (0 < (int)lVar4.Length) {
            	  var uVar5 = 0;
            	  var uVar6 = lVar4.Length & 0xffffffff;
            	  do {
            	    if (uVar6 <= uVar5) {
            	    }
            	    var lVar1 = uVar5 * 4;
            	    uVar5 = uVar5 + 1;
            	    lVar4 + lVar1[0] = 0;
            	    lVar4 = this.m_param.args;
            	    uVar6 = (ulong)lVar4.Length;
            	  } while ((long)uVar5 < (int)lVar4.Length);
            	}
            	this.m_param.type = 0;
            }

            // TODO
            public Param() { }
        }
    }
}