using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PokeActionParam_Item
    {
        public byte targetID;
        public ItemNo number;
        public byte param;

        // TODO
        public void CopyFrom(PokeActionParam_Item src) { }

        public void Clear()
        {
        	this.targetID = (byte)0;
        	this.number = (ItemNo)0;
        	this.param = (byte)0;
        }
    }
}