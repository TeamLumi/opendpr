using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PokeActionParam_Item
    {
        public byte targetID;
        public ItemNo number;
        public byte param;

        public void CopyFrom(PokeActionParam_Item src)
        {
            targetID = src.targetID;
            number = src.number;
            param = src.param;
        }

        public void Clear()
        {
            targetID = 0;
            number = ItemNo.DUMMY_DATA;
            param = 0;
        }
    }
}