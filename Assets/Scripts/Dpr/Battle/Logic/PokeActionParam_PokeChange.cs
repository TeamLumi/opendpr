namespace Dpr.Battle.Logic
{
    public sealed class PokeActionParam_PokeChange
    {
        public byte posIdx;
        public byte memberIdx;
        public bool depleteFlag;

        public void CopyFrom(PokeActionParam_PokeChange src)
        {
            posIdx = src.posIdx;
            memberIdx = src.memberIdx;
            depleteFlag = src.depleteFlag;
        }

        public void Clear()
        {
            posIdx = 0;
            memberIdx = 0;
            depleteFlag = false;
        }
    }
}