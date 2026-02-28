using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class WAZADATA
    {
        public static WazaTarget GetWazaTarget(WazaNo id)
        {
            return WazaDataSystem.GetTarget(id);
        }

        public static uint GetHPRecoverRatio(WazaNo id)
        {
            return WazaDataSystem.GetHPRecoverRatio(id);
        }

        public static uint GetHPReactionRatio(WazaNo id)
        {
            return WazaDataSystem.GetHPReactionRatio(id);
        }

        public static uint GetDamageReactionRatio(WazaNo id)
        {
            return WazaDataSystem.GetDamageReactionRatio(id);
        }

        public static uint GetDamageRecoverRatio(WazaNo id)
        {
            return WazaDataSystem.GetDamageRecoverRatio(id);
        }

        public static uint GetShrinkPer(WazaNo id)
        {
            return WazaDataSystem.GetShrinkPer(id);
        }

        public static WazaSick GetSick(WazaNo id)
        {
            return WazaDataSystem.GetSick(id);
        }

        public static int GetSickPer(WazaNo id)
        {
            return WazaDataSystem.GetSickPer(id);
        }

        public static byte GetType(WazaNo id)
        {
            return WazaDataSystem.GetType(id);
        }

        public static WazaCategory GetCategory(WazaNo id)
        {
            return WazaDataSystem.GetCategory(id);
        }

        public static WazaDamageType GetDamageType(WazaNo id)
        {
            return WazaDataSystem.GetDamageType(id);
        }

        public static SickContParam GetSickCont(WazaNo id)
        {
            return WazaDataSystem.GetSickCont(id);
        }

        public static WazaRankEffect GetRankEffect(WazaNo id, uint idx, out int volume)
        {
            return WazaDataSystem.GetRankEffect(id, idx, out volume);
        }

        public static byte GetRankEffectCount(WazaNo id)
        {
            return WazaDataSystem.GetRankEffectCount(id);
        }

        public static int GetRankEffectPer(WazaNo id, uint idx)
        {
            return WazaDataSystem.GetRankEffectPer(id, idx);
        }

        public static uint GetPower(WazaNo id)
        {
            return WazaDataSystem.GetPower(id);
        }

        public static ushort GetHitPer(WazaNo id)
        {
            return WazaDataSystem.GetHitPer(id);
        }

        public static uint GetHitCountMax(WazaNo id)
        {
            return WazaDataSystem.GetHitCountMax(id);
        }

        public static uint GetHitCountMin(WazaNo id)
        {
            return WazaDataSystem.GetHitCountMin(id);
        }

        public static int GetAISeqNo(WazaNo id)
        {
            return WazaDataSystem.GetAISeqNo(id);
        }

        public static bool GetFlag(WazaNo id, WazaFlag flag)
        {
            return WazaDataSystem.GetFlag(id, flag);
        }

        public static bool IsValid(WazaNo id)
        {
            return WazaDataSystem.IsValid(id);
        }

        public static bool IsAlwaysHit(WazaNo id)
        {
            return WazaDataSystem.IsAlwaysHit(id);
        }

        public static bool IsMustCritical(WazaNo id)
        {
            return WazaDataSystem.IsMustCritical(id);
        }

        public static byte GetCriticalRank(WazaNo id)
        {
            return WazaDataSystem.GetCriticalRank(id);
        }

        public static uint GetMaxPP(WazaNo id, uint ppup_cnt)
        {
            return WazaDataSystem.GetMaxPP(id, ppup_cnt);
        }

        public static BtlWeather GetWeather(WazaNo id)
        {
            return (BtlWeather)WazaDataSystem.GetWeather(id);
        }

        public static int GetPriority(WazaNo id)
        {
            return WazaDataSystem.GetPriority(id);
        }

        public static bool IsDamage(WazaNo id)
        {
            return WazaDataSystem.IsDamage(id);
        }

        public static byte GetGPower(WazaNo wazano)
        {
            return WazaDataSystem.GetGPower(wazano);
        }
    }
}