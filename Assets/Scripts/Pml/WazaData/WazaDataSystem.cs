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

        // TODO
        public static WazaWeather GetWeather(WazaNo wazano) { return default; }

        // TODO
        public static WazaSick GetSick(WazaNo id) { return WazaSick.WAZASICK_NONE; }

        // TODO
        public static int GetSickPer(WazaNo id) { return 0; }

        // TODO
        public static SickContParam GetSickCont(WazaNo id) { return default; }

        // TODO
        public static byte GetRankEffectCount(WazaNo id) { return 0; }

        public static WazaRankEffect GetRankEffect(WazaNo id, uint idx, out int volume)
        {
            if (idx >= 3)
            {
                GFL.ASSERT(false);
                volume = 0;
                return WazaRankEffect.NONE;
            }

            var waza = s_wazaTable.Waza[(int)id];

            WazaRankEffect type;
            switch (idx)
            {
                case 0: type = (WazaRankEffect)waza.rankEffType1; break;
                case 1: type = (WazaRankEffect)waza.rankEffType2; break;
                case 2: type = (WazaRankEffect)waza.rankEffType3; break;
                default: type = WazaRankEffect.NONE; break;
            }

            volume = 0;
            if (type == WazaRankEffect.NONE)
                return WazaRankEffect.NONE;

            switch (idx)
            {
                case 0: volume = waza.rankEffValue1; break;
                case 1: volume = waza.rankEffValue2; break;
                case 2: volume = waza.rankEffValue3; break;
            }

            return type;
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

        public static byte GetGPower(WazaNo id) {
            return 0;
        }

        // TODO
        public static ushort[] GetYubiWoHuruPermitWazaTable() { return null; }

        // TODO
        public static uint GetContestWazaNo(WazaNo id) { return 0; }
    }
}