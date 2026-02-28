using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class WAZADATA
    {
        public static WazaTarget GetWazaTarget(WazaNo id)
        {
        	WazaDataSystem.GetTarget(id);
        	return (WazaTarget)0;
        }

        public static uint GetHPRecoverRatio(WazaNo id)
        {
        	WazaDataSystem.GetHPRecoverRatio(id);
        	return 0;
        }

        public static byte GetHPReactionRatio(WazaNo id)
        {
        	WazaDataSystem.GetHPReactionRatio(id);
        	return 0;
        }

        public static byte GetDamageReactionRatio(WazaNo id)
        {
        	WazaDataSystem.GetDamageReactionRatio(id);
        	return 0;
        }

        public static uint GetDamageRecoverRatio(WazaNo id)
        {
        	WazaDataSystem.GetDamageRecoverRatio(id);
        	return 0;
        }

        public static uint GetShrinkPer(WazaNo id)
        {
        	WazaDataSystem.GetShrinkPer(id);
        	return 0;
        }

        public static WazaSick GetSick(WazaNo id)
        {
        	WazaDataSystem.GetSick(id);
        	return (WazaSick)0;
        }

        public static int GetSickPer(WazaNo id)
        {
        	WazaDataSystem.GetSickPer(id);
        	return 0;
        }

        public static byte GetType(WazaNo id)
        {
        	WazaDataSystem.GetType(id);
        	return 0;
        }

        public static WazaCategory GetCategory(WazaNo id)
        {
        	WazaDataSystem.GetCategory(id);
        	return (WazaCategory)0;
        }

        public static WazaDamageType GetDamageType(WazaNo id)
        {
        	WazaDataSystem.GetDamageType(id);
        	return (WazaDamageType)0;
        }

        public static SickContParam GetSickCont(WazaNo id)
        {
        	var uVar1 = WazaDataSystem.GetSickCont(id);
        	return uVar1;
        }

        public static WazaRankEffect GetRankEffect(WazaNo id, uint idx, out int volume)
        {
        	WazaDataSystem.GetRankEffect();
        	return (WazaRankEffect)0;
        }

        public static byte GetRankEffectCount(WazaNo id)
        {
        	WazaDataSystem.GetRankEffectCount(id);
        	return 0;
        }

        public static int GetRankEffectPer(WazaNo id, uint idx)
        {
        	WazaDataSystem.GetRankEffectPer(id,idx);
        	return 0;
        }

        public static uint GetPower(WazaNo id)
        {
        	WazaDataSystem.GetPower(id);
        	return 0;
        }

        public static ushort GetHitPer(WazaNo id)
        {
        	WazaDataSystem.GetHitPer(id);
        	return 0;
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
        	WazaDataSystem.GetAISeqNo(id);
        	return 0;
        }

        public static bool GetFlag(WazaNo id, WazaFlag flag)
        {
        	WazaDataSystem.GetFlag(id,flag);
        	return false;
        }

        public static bool IsValid(WazaNo id)
        {
        	WazaDataSystem.IsValid(id);
        	return false;
        }

        public static bool IsAlwaysHit(WazaNo id)
        {
        	WazaDataSystem.IsAlwaysHit(id);
        	return false;
        }

        public static bool IsMustCritical(WazaNo id)
        {
        	WazaDataSystem.IsMustCritical(id);
        	return false;
        }

        public static byte GetCriticalRank(WazaNo id)
        {
        	WazaDataSystem.GetCriticalRank(id);
        	return 0;
        }

        public static uint GetMaxPP(WazaNo id, uint ppup_cnt)
        {
        	WazaDataSystem.GetMaxPP(id,ppup_cnt);
        	return 0;
        }

        public static BtlWeather GetWeather(WazaNo id)
        {
        	WazaDataSystem.GetWeather(id);
        	return (BtlWeather)0;
        }

        public static int GetPriority(WazaNo id)
        {
        	WazaDataSystem.GetPriority(id);
        	return 0;
        }

        public static bool IsDamage(WazaNo id)
        {
        	WazaDataSystem.IsDamage(id);
        	return false;
        }

        public static byte GetGPower(WazaNo wazano)
        {
        	WazaDataSystem.GetGPower(wazano);
        	return 0;
        }
    }
}