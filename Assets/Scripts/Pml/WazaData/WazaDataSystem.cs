using XLSXContent;

namespace Pml.WazaData
{
    public static class WazaDataSystem
    {
        public const int RANK_STORE_MAX = 3;
        public const int HITRATIO_MUST = 101;
        public const int CRITICAL_MUST = 6;
        public static WazaTable s_wazaTable;

        public static void Initialize(WazaTable wazaTable)
        {
            s_wazaTable = wazaTable;
        }

        public static void Finalize_()
        {
            s_wazaTable = null;
        }

        public static WazaTable.SheetWaza Get(WazaNo id)
        {
            return s_wazaTable.Waza[(int)id];
        }

        // TODO
        public static bool IsValid(WazaNo id) { return false; }

        // TODO
        public static bool GetFlag(WazaNo id, WazaFlag flag) { return false; }

        public static uint GetMaxPP(WazaNo id, uint maxupcnt)
        {
            maxupcnt = maxupcnt >= 3 ? 3 : maxupcnt;

            var basePP = Get(id).basePP;
            return (maxupcnt * basePP * 20 / 100 + basePP) & 0xFF;
        }

        // TODO
        public static uint GetPower(WazaNo id) { return 0; }

        // TODO
        public static byte GetType(WazaNo id) { return 0; }

        // TODO
        public static WazaDamageType GetDamageType(WazaNo id) { return 0; }

        // TODO
        public static WazaCategory GetCategory(WazaNo id) { return WazaCategory.SIMPLE_DAMAGE; }

        // TODO
        public static int GetPriority(WazaNo id) { return 0; }

        // TODO
        public static ushort GetHitPer(WazaNo id) { return 0; }

        // TODO
        public static bool IsAlwaysHit(WazaNo id) { return false; }

        public static uint GetHitCountMax(WazaNo id)
        {
            return Get(id).hitCountMax;
        }

        public static uint GetHitCountMin(WazaNo id)
        {
            return Get(id).hitCountMin;
        }

        // TODO
        public static bool IsMustCritical(WazaNo id) { return false; }

        // TODO
        public static uint GetShrinkPer(WazaNo id) { return 0; }

        // TODO
        public static bool IsDamage(WazaNo id) { return false; }

        // TODO
        public static byte GetCriticalRank(WazaNo id) { return 0; }

        public static WazaWeather GetWeather(WazaNo wazano)
        {
        	var iVar1 = 0xf0;
        	if (0xf0 < (int)wazano) {
        	  iVar1 = 0x102;
        	}
        	var iVar3 = 0xc9;
        	if (0xf0 < (int)wazano) {
        	  iVar3 = 0xf1;
        	}
        	var uVar2 = 2;
        	if (0xf0 < (int)wazano) {
        	  uVar2 = 3;
        	}
        	var uVar4 = 4;
        	if (0xf0 < (int)wazano) {
        	  uVar4 = 1;
        	}
        	if (iVar1 != wazano) {
        	  uVar2 = 0;
        	}
        	if (iVar3 != wazano) {
        	  uVar4 = uVar2;
        	}
        	return uVar4;
        }

        // TODO
        public static WazaSick GetSick(WazaNo id) { return WazaSick.WAZASICK_NONE; }

        // TODO
        public static int GetSickPer(WazaNo id) { return 0; }

        // TODO
        public static SickContParam GetSickCont(WazaNo id) { return default; }

        // TODO
        public static byte GetRankEffectCount(WazaNo id) { return 0; }

        // TODO
        public static WazaRankEffect GetRankEffect(WazaNo id, uint idx, out int volume)
        {
            volume = 0;
            return WazaRankEffect.NONE;
        }

        // TODO
        public static int GetRankEffectPer(WazaNo id, uint idx) { return 0; }

        // TODO
        public static uint GetDamageRecoverRatio(WazaNo id) { return 0; }

        // TODO
        public static uint GetHPRecoverRatio(WazaNo id) { return 0; }

        // TODO
        public static WazaTarget GetTarget(WazaNo id) { return WazaTarget.TARGET_OTHER_SELECT; }

        // TODO
        public static int GetAISeqNo(WazaNo id) { return 0; }

        // TODO
        public static byte GetDamageReactionRatio(WazaNo id) { return 0; }

        // TODO
        public static byte GetHPReactionRatio(WazaNo id) { return 0; }

        public static byte GetGPower(WazaNo id)
        {
        	return 0;
        }

        // TODO
        public static ushort[] GetYubiWoHuruPermitWazaTable() { return null; }

        // TODO
        public static uint GetContestWazaNo(WazaNo id) { return 0; }
    }
}