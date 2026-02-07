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

        public void CopyFrom(RaidBossDesc src)
        {
            hpCoef = src.hpCoef;
            gWazaFrequency = src.gWazaFrequency;
            actNum = src.actNum;
            gWallGaugeMax = src.gWallGaugeMax;
            gWallGaugeInit = src.gWallGaugeInit;
            gWallRepairTurn = src.gWallRepairTurn;

            for (int i = 0; i < angryHPThreshold.Length; i++)
                angryHPThreshold[i] = src.angryHPThreshold[i];

            for (int i = 0; i < angryWazaNo.Length; i++)
                angryWazaNo[i] = src.angryWazaNo[i];

            for (int i = 0; i < angryWazaTimming.Length; i++)
                angryWazaTimming[i] = src.angryWazaTimming[i];
        }

        public static void Copy(RaidBossDesc pDesc, in RaidBossDesc src)
        {
            pDesc.CopyFrom(src);
        }

        public static void SetDefault(RaidBossDesc pDesc, MonsNo monsno, ushort formno, byte grade)
        {
            pDesc.hpCoef = 1.0f;
            pDesc.gWazaFrequency = 0;
            pDesc.actNum = 1;
            pDesc.gWallGaugeMax = 0;
            pDesc.gWallGaugeInit = 0;
            pDesc.gWallRepairTurn = 0;

            for (int i = 0; i < pDesc.angryHPThreshold.Length; i++)
                pDesc.angryHPThreshold[i] = 0;

            for (int i = 0; i < pDesc.angryWazaNo.Length; i++)
                pDesc.angryWazaNo[i] = WazaNo.NULL;

            for (int i = 0; i < pDesc.angryWazaTimming.Length; i++)
                pDesc.angryWazaTimming[i] = RaidBossAngryWazaTiming.NONE;
        }
    }
}