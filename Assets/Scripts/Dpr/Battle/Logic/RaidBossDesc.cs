using Pml;
using Pml.Personal;

namespace Dpr.Battle.Logic
{
    public class RaidBossDesc
    {
        public float hpCoef;
        public byte gWazaFrequency;
        public byte actNum;
        public byte gWallGaugeMax;
        public byte gWallGaugeInit;
        public byte gWallRepairTurn;
        public byte[] angryHPThreshold = new byte[2];
        public WazaNo[] angryWazaNo = Arrays.InitializeWithDefaultInstances<WazaNo>(2);
        public RaidBossAngryWazaTiming[] angryWazaTimming = Arrays.InitializeWithDefaultInstances<RaidBossAngryWazaTiming>(2);

        // TODO
        public void CopyFrom(RaidBossDesc src) { }

        public static void Copy(RaidBossDesc pDesc, in RaidBossDesc src)
        {
        	CopyFrom(pDesc,src);
        }

        // TODO
        public static void SetDefault(RaidBossDesc pDesc, MonsNo monsno, ushort formno, byte grade) { }
    }
}