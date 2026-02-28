namespace Dpr.Battle.Logic
{
    public sealed class WazaRobParam
    {
        public byte robberCount;
        public byte[] robberPokeID = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public BtlPokePos[] targetPos = new BtlPokePos[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public byte[] targetPokeID = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];

        public void Add(byte robberPokeID, byte targetPokeID, BtlPokePos targetPos)
        {
        	if ((int)this.robberPokeID.Length <= (int)(uint)this.robberCount) {
        	}
        	if (this.robberCount < this.robberPokeID.Length) {
        	  this.robberPokeID + (ulong)this.robberCount[0] = robberPokeID;
        	  if ((uint)this.robberCount < this.targetPokeID.Length) {
        	    this.targetPokeID + (ulong)this.robberCount[0] = targetPokeID
        	    ;
        	    if ((uint)this.robberCount < this.targetPos.Length) {
        	      this.targetPos + (ulong)this.robberCount[0] =
        	           targetPos;
        	      this.robberCount = (byte)(this.robberCount + '\x01');
        	    }
        	  }
        	}
        }

        // TODO
        public void CopyFrom(in WazaRobParam src) { }

        // TODO
        public void Clear() { }
    }
}