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

        public static bool IsValid(WazaNo id)
        {
            if (id <= WazaNo.NULL || (int)id >= s_wazaTable.Waza.Length)
                return false;
            return Get(id).isValid;
        }

        public static bool GetFlag(WazaNo id, WazaFlag flag)
        {
            return (Get(id).flags & (1u << (int)flag)) != 0;
        }

        public static uint GetMaxPP(WazaNo id, uint maxupcnt)
        {
            maxupcnt = maxupcnt >= 3 ? 3 : maxupcnt;

            var basePP = Get(id).basePP;
            return (maxupcnt * basePP * 20 / 100 + basePP) & 0xFF;
        }

        public static uint GetPower(WazaNo id)
        {
            return Get(id).power;
        }

        public static byte GetType(WazaNo id)
        {
            return Get(id).type;
        }

        public static WazaDamageType GetDamageType(WazaNo id)
        {
            return (WazaDamageType)Get(id).damageType;
        }

        public static WazaCategory GetCategory(WazaNo id)
        {
            return (WazaCategory)Get(id).category;
        }

        public static int GetPriority(WazaNo id)
        {
            return Get(id).priority;
        }

        public static ushort GetHitPer(WazaNo id)
        {
            var hitPer = Get(id).hitPer;
            if (hitPer == HITRATIO_MUST)
                return 100;
            return hitPer;
        }

        public static bool IsAlwaysHit(WazaNo id)
        {
            return Get(id).hitPer == HITRATIO_MUST;
        }

        public static uint GetHitCountMax(WazaNo id)
        {
            return Get(id).hitCountMax;
        }

        public static uint GetHitCountMin(WazaNo id)
        {
            return Get(id).hitCountMin;
        }

        public static bool IsMustCritical(WazaNo id)
        {
            return Get(id).criticalRank == CRITICAL_MUST;
        }

        public static uint GetShrinkPer(WazaNo id)
        {
            return Get(id).shrinkPer;
        }

        public static bool IsDamage(WazaNo id)
        {
            return GetPower(id) != 0;
        }

        public static byte GetCriticalRank(WazaNo id)
        {
            return Get(id).criticalRank;
        }

        public static WazaWeather GetWeather(WazaNo wazano)
        {
            switch (wazano)
            {
                case WazaNo.NIHONBARE: return WazaWeather.SHINE;
                case WazaNo.AMAGOI:    return WazaWeather.RAIN;
                case WazaNo.ARARE:     return WazaWeather.SNOW;
                case WazaNo.SUNAARASI: return WazaWeather.SAND;
                default:               return WazaWeather.NONE;
            }
        }

        public static WazaSick GetSick(WazaNo id)
        {
            return (WazaSick)Get(id).sickID;
        }

        public static int GetSickPer(WazaNo id)
        {
            return Get(id).sickPer;
        }

        public static SickContParam GetSickCont(WazaNo id)
        {
            var waza = Get(id);
            var param = new SickContParam();
            param.type = waza.sickCont;
            param.turnMin = waza.sickTurnMin;
            param.turnMax = waza.sickTurnMax;
            return param;
        }

        public static byte GetRankEffectCount(WazaNo id)
        {
            var waza = Get(id);
            byte count = 0;
            if (waza.rankEffType1 != (byte)WazaRankEffect.NONE) count++;
            if (waza.rankEffType2 != (byte)WazaRankEffect.NONE) count++;
            if (waza.rankEffType3 != (byte)WazaRankEffect.NONE) count++;
            return count;
        }

        public static WazaRankEffect GetRankEffect(WazaNo id, uint idx, out int volume)
        {
            volume = 0;
            if (idx >= RANK_STORE_MAX)
            {
                GFL.ASSERT(false);
                return WazaRankEffect.NONE;
            }

            var waza = Get(id);
            byte type;
            switch (idx)
            {
                case 0: type = waza.rankEffType1; break;
                case 1: type = waza.rankEffType2; break;
                case 2: type = waza.rankEffType3; break;
                default: return WazaRankEffect.NONE;
            }

            if (type == (byte)WazaRankEffect.NONE)
                return WazaRankEffect.NONE;

            switch (idx)
            {
                case 0: volume = waza.rankEffValue1; break;
                case 1: volume = waza.rankEffValue2; break;
                case 2: volume = waza.rankEffValue3; break;
            }
            return (WazaRankEffect)type;
        }

        public static int GetRankEffectPer(WazaNo id, uint idx)
        {
            var waza = Get(id);
            switch (idx)
            {
                case 0: return waza.rankEffPer1;
                case 1: return waza.rankEffPer2;
                case 2: return waza.rankEffPer3;
                default: return 0;
            }
        }

        public static uint GetDamageRecoverRatio(WazaNo id)
        {
            uint val = (uint)Get(id).damageRecoverRatio;
            return val & (uint)((int)val >> 31 ^ ~0);
        }

        public static uint GetHPRecoverRatio(WazaNo id)
        {
            uint val = (uint)Get(id).hpRecoverRatio;
            return val & (uint)((int)val >> 31 ^ ~0);
        }

        public static WazaTarget GetTarget(WazaNo id)
        {
            return (WazaTarget)Get(id).target;
        }

        public static int GetAISeqNo(WazaNo id)
        {
            return Get(id).aiSeqNo;
        }

        public static uint GetDamageReactionRatio(WazaNo id)
        {
            int val = (int)Get(id).damageRecoverRatio;
            return (uint)(-val & (val >> 7));
        }

        public static uint GetHPReactionRatio(WazaNo id)
        {
            int val = (int)Get(id).hpRecoverRatio;
            return (uint)(-val & (val >> 7));
        }

        public static byte GetGPower(WazaNo id)
        {
            return 0;
        }

        public static ushort[] GetYubiWoHuruPermitWazaTable()
        {
            if (s_wazaTable.Yubiwohuru != null && s_wazaTable.Yubiwohuru.Length > 0)
                return s_wazaTable.Yubiwohuru[0].wazaNos;
            return null;
        }

        public static uint GetContestWazaNo(WazaNo id)
        {
            return Get(id).contestWazaNo;
        }
    }
}
