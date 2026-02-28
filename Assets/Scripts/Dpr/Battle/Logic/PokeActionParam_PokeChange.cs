namespace Dpr.Battle.Logic
{
    public sealed class PokeActionParam_PokeChange
    {
        public byte posIdx;
        public byte memberIdx;
        public bool depleteFlag;

        // TODO
        public void CopyFrom(PokeActionParam_PokeChange src) { }

        public void Clear()
        {
        	this.posIdx = (byte)0;
        	this.depleteFlag = false;
        }
    }
}