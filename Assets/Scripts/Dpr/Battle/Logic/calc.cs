using Pml.PokePara;
using Pml.WazaData;
using Pml;
using Pml.Battle;
using Pml.Personal;

namespace Dpr.Battle.Logic
{
    public static class calc
    {
        private static Random g_RandSys;
        private static Random g_PublicRand;
        private static WazaNo[] g_WazaStoreWork;
        private static bool g_SakasaBtlFlag;
        public static PowerID[] PokePowerIDTable = new PowerID[6]
        {
            PowerID.HP, PowerID.ATK, PowerID.DEF, PowerID.SPATK, PowerID.SPDEF, PowerID.AGI
        };
        private static readonly StatusRankTableElem[] StatusRankTable = new StatusRankTableElem[13]
        {
            new StatusRankTableElem(2, 8),   new StatusRankTableElem(2, 7),   new StatusRankTableElem(2, 6),
            new StatusRankTableElem(2, 5),   new StatusRankTableElem(2, 4),   new StatusRankTableElem(2, 3),
            new StatusRankTableElem(2, 2),   new StatusRankTableElem(3, 2),   new StatusRankTableElem(4, 2),
            new StatusRankTableElem(5, 2),   new StatusRankTableElem(6, 2),   new StatusRankTableElem(7, 2),
            new StatusRankTableElem(8, 2),
        };
        private static readonly HitPerTableElem[] HitPerTable = new HitPerTableElem[13]
        {
            new HitPerTableElem(6, 18),   new HitPerTableElem(6, 16),   new HitPerTableElem(6, 14),
            new HitPerTableElem(6, 12),   new HitPerTableElem(6, 10),   new HitPerTableElem(6, 8),
            new HitPerTableElem(6, 6),    new HitPerTableElem(8, 6),    new HitPerTableElem(10, 6),
            new HitPerTableElem(12, 6),   new HitPerTableElem(14, 6),   new HitPerTableElem(16, 6),
            new HitPerTableElem(18, 6),
        };
        private static readonly byte[] CheckCriticalTable = new byte[4] { 1, 2, 8, 16 };
        private static readonly byte[] PENALTY_COEF = new byte[9] { 2, 4, 6, 9, 12, 16, 20, 25, 30 };

        public static void BITFLG_Construction(byte[] flags)
        {
            for (int i = 0; i < flags.Length; i++)
                flags[i] = 0;
        }

        public static void BITFLG_Set(byte[] flags, uint index)
        {
            flags[index / 8] |= (byte)(1 << (int)(index % 8));
        }

        public static bool BITFLG_Check(byte[] flags, uint index)
        {
            return (flags[index / 8] & (1 << (int)(index % 8))) != 0;
        }

        public static void BITFLG_Off(byte[] flags, uint index)
        {
            flags[index / 8] &= (byte)~(1 << (int)(index % 8));
        }

        public static uint ABS(int value)
        {
            return (uint)(value < 0 ? -value : value);
        }

        public static void InitSys(Random randSys, bool bSakasaBtl)
        {
            g_RandSys = randSys;
            g_PublicRand = new Random();
            g_SakasaBtlFlag = bSakasaBtl;
            g_WazaStoreWork = new WazaNo[826];
        }

        public static void ResetSys(ulong randSeed)
        {
            g_RandSys.Initialize(randSeed);
        }

        public static void QuitSys()
        {
            g_RandSys = null;
            g_PublicRand = null;
            g_WazaStoreWork = null;
        }

        public static Random GetRandGenerator()
        {
            return g_RandSys;
        }

        // TODO
        public static TypeAffinity.AffinityID TypeAff(PokeType wazaType, PokeType pokeType) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public static TypeAffinity.AffinityID TypeAffMul(TypeAffinity.AffinityID aff1, TypeAffinity.AffinityID aff2) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public static TypeAffinity.AffinityID TypeAffPair(byte wazaType, PokeTypePair pokeType) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public static byte GetResistTypes(PokeType type, byte[] dst) { return 0; }

        // TODO
        public static uint DamageBase(uint wazaPower, uint atkPower, uint atkLevel, uint defGuard) { return 0; }

        // TODO
        public static uint AffDamage(uint rawDamage, TypeAffinity.AffinityID aff) { return 0; }

        public static uint GetPublicRand(uint range)
        {
            return (uint)Random.GetPublicRand((int)range);
        }

        public static uint GetRand(uint range)
        {
            return (uint)g_RandSys.GetValue(range);
        }

        public static uint RandRange(uint min, uint max)
        {
            return GetRand(max - min) + min;
        }

        public static uint MulRatio(uint value, int ratio)
        {
            return (uint)(value * ratio / 4096);
        }

        public static uint MulRatio_OverZero(uint value, int ratio)
        {
            uint result = MulRatio(value, ratio);
            if (result == 0)
                result = 1;
            return result;
        }

        public static uint MulRatioInt(uint value, uint ratio)
        {
            return value * ratio / 100;
        }

        // TODO
        public static void MakeDefaultWazaSickCont(WazaSick sick, BTL_POKEPARAM attacker, out BTL_SICKCONT cont)
        {
            cont = default(BTL_SICKCONT);
        }

        // TODO
        public static BTL_SICKCONT MakeWazaSickCont_Poke(byte pokeID, byte causePokeID) { return default(BTL_SICKCONT); }

        // TODO
        public static BTL_SICKCONT MakeDefaultPokeSickCont(Sick sick, byte causePokeID, bool isCantUseRand = false) { return default(BTL_SICKCONT); }

        public static ushort StatusRank(ushort defaultVal, byte rank)
        {
            return (ushort)(defaultVal * StatusRankTable[rank].num / StatusRankTable[rank].denom);
        }

        // TODO
        public static uint QuotMaxHP_Zero(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false) { return 0; }

        // TODO
        public static uint QuotMaxHP(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false) { return 0; }

        public static byte HitPer(byte defPer, byte rank)
        {
            return (byte)(defPer * HitPerTable[rank].num / HitPerTable[rank].denom);
        }

        public static bool CheckCritical(byte rank, int ratio)
        {
            if (rank >= CheckCriticalTable.Length)
                return true;
            return GetRand(CheckCriticalTable[rank]) < ratio;
        }

        // TODO
        public static int ITEM_GetParam(ushort item, Pml.Item.ItemData.PrmID paramID) { return 0; }

        // TODO
        public static bool ITEM_IsBall(ushort itemID) { return false; }

        // TODO
        public static bool ITEM_IsReriveItem(ushort itemID) { return false; }

        // TODO
        public static bool ITEM_IsMail(ushort item) { return false; }

        // TODO
        public static uint PERSONAL_GetParam(int mons_no, int form_no, ParamID paramID) { return 0; }

        // TODO
        public static uint PERSONAL_GetMinExp(int monsno, int formno, byte level) { return 0; }

        // TODO
        public static bool PERSONAL_IsEvoCancelPokemon(int mons_no, ushort formno, byte level) { return false; }

        public static bool IsBasicSickID(WazaSick sickID)
        {
            return sickID >= WazaSick.WAZASICK_MAHI && sickID <= WazaSick.WAZASICK_DOKU;
        }

        // TODO
        public static ushort RecvWeatherDamage(BTL_POKEPARAM bpp, BtlWeather weather) { return 0; }

        // TODO
        public static int GetWeatherDmgRatio(BtlWeather weather, byte wazaType) { return 0; }

        public static bool IsShineWeather(BtlWeather weather)
        {
            return weather == BtlWeather.BTL_WEATHER_SHINE || weather == BtlWeather.BTL_WEATHER_DAY;
        }

        public static bool IsRainWeather(BtlWeather weather)
        {
            return weather == BtlWeather.BTL_WEATHER_RAIN || weather == BtlWeather.BTL_WEATHER_STORM;
        }

        // TODO
        public static void WazaSickContToBppSickCont(SickContParam wazaSickCont, BTL_POKEPARAM attacker, out BTL_SICKCONT sickCont)
        {
            sickCont = default(BTL_SICKCONT);
        }

        public static byte HitCountStd(byte numHitMax)
        {
            if (numHitMax == 5)
            {
                var percents = new byte[6] { 0, 0, 35, 70, 85, 100 };
                var roll = g_RandSys.GetValue(100);

                for (byte i=0; i<percents.Length; i++)
                {
                    if (roll % 256 < percents[i])
                        return i;
                }

                numHitMax = 5;
            }

            return numHitMax;
        }

        // TODO
        public static WazaSick CheckMentalSick(BTL_POKEPARAM bpp) { return WazaSick.WAZASICK_NONE; }

        // TODO
        public static TypeAffinity.AboutAffinityID TypeAffAbout(TypeAffinity.AffinityID aff) { return TypeAffinity.AboutAffinityID.NONE; }

        public static bool IsOccurPer(uint per)
        {
            return GetRand(100) < per;
        }

        public static int Roundup(int value, int min)
        {
            return value < min ? min : value;
        }

        public static int Rounddown(int val, int max)
        {
            return val > max ? max : val;
        }

        public static int RoundValue(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        // TODO
        public static WazaTarget GetWazaTarget(WazaNo waza, BTL_POKEPARAM attacker) { return WazaTarget.TARGET_OTHER_SELECT; }

        // TODO
        public static WazaTarget GetNoroiTargetType(BTL_POKEPARAM attacker) { return WazaTarget.TARGET_OTHER_SELECT; }

        // TODO
        public static BtlPokePos DecideWazaTargetAuto(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, bool IsClient = false) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static uint PokeIDx6_Pack32bit(byte[] pokeIDList) { return 0; }

        // TODO
        public static void PokeIDx6_Unpack32bit(uint pack, byte[] pokeIDList) { }

        public static bool is_include(WazaNo[] tbl, uint tblElems, WazaNo wazaID)
        {
            for (uint i = 0; i < tblElems; i++)
            {
                if (tbl[i] == wazaID)
                    return true;
            }
            return false;
        }

        // TODO
        public static WazaNo RandWaza(WazaNo[] omitWazaTbl, ushort tblElems) { return WazaNo.NULL; }

        // TODO
        public static BtlPokePos DecideWazaTargetAutoForClient(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, ref ulong pRandContextSaveWork) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static bool RULE_IsNeedSelectTarget(BtlRule rule) { return false; }

        // TODO
        public static byte RULE_HandPokeIndex(BtlRule rule, byte numCoverPos) { return 0; }

        // TODO
        public static uint calcWinMoney_Sub(in BSP_TRAINER_DATA trData, in PokeParty party) { return 0; }

        // TODO
        public static uint CalcWinMoney(BATTLE_SETUP_PARAM sp) { return 0; }

        // TODO
        public static uint CalcLoseMoney(BATTLE_SETUP_PARAM sp, POKECON pokeCon) { return 0; }

        // TODO
        private static uint CalcPenaltyMoney(uint level_max) { return 0; }

        public class ESCAPEINFO
        {
	        public uint count;
            public byte[] clientID = new byte[5];
        }

        private struct StatusRankTableElem
        {
	        public byte num;
            public byte denom;

            public StatusRankTableElem(byte num, byte denom)
            {
                this.num = num;
                this.denom = denom;
            }
        }

        private struct HitPerTableElem
        {
            public byte num;
            public byte denom;

            public HitPerTableElem(byte num, byte denom)
            {
                this.num = num;
                this.denom = denom;
            }
        }
    }
}