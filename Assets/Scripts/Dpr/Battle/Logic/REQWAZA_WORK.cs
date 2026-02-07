using Pml;

namespace Dpr.Battle.Logic
{
    public class REQWAZA_WORK
    {
        public WazaNo wazaID;
        public BtlPokePos targetPos;

        public REQWAZA_WORK()
        {
            wazaID = WazaNo.NULL;
            targetPos = BtlPokePos.POS_NULL;
        }
    }
}