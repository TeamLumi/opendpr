using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PokeActionParam_Fight
    {
        public BtlPokePos targetPos;
        public byte aimTargetID;
        public WazaNo waza;
        public bool gFlag;
        public bool forbidGWaza;
        public bool forceGWaza;

        public void CopyFrom(PokeActionParam_Fight src)
        {
            targetPos = src.targetPos;
            aimTargetID = src.aimTargetID;
            waza = src.waza;
            gFlag = src.gFlag;
            forbidGWaza = src.forbidGWaza;
            forceGWaza = src.forceGWaza;
        }

        public void Clear()
        {
            targetPos = BtlPokePos.POS_NULL;
            aimTargetID = 0;
            waza = WazaNo.NULL;
            gFlag = false;
            forbidGWaza = false;
            forceGWaza = false;
        }
    }
}