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

        // TODO
        public static void BITFLG_Construction(byte[] flags) { }

        // TODO
        public static void BITFLG_Set(byte[] flags, uint index) { }

        // TODO
        public static bool BITFLG_Check(byte[] flags, uint index) { return false; }

        // TODO
        public static void BITFLG_Off(byte[] flags, uint index) { }

        public static uint ABS(int value)
        {
        	var iVar1 = -value;
        	if (-1 < value) {
        	  iVar1 = value;
        	}
        	return iVar1;
        }

        // TODO
        public static void InitSys(Random randSys, bool bSakasaBtl) { }

        // TODO
        public static void ResetSys(ulong randSeed) { }

        // TODO
        public static void QuitSys() { }

        // TODO
        public static Random GetRandGenerator() { return null; }

        // TODO
        public static TypeAffinity.AffinityID TypeAff(PokeType wazaType, PokeType pokeType) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public static TypeAffinity.AffinityID TypeAffMul(TypeAffinity.AffinityID aff1, TypeAffinity.AffinityID aff2) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public static TypeAffinity.AffinityID TypeAffPair(byte wazaType, PokeTypePair pokeType) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public static byte GetResistTypes(PokeType type, byte[] dst) { return 0; }

        public static uint DamageBase(uint wazaPower, uint atkPower, uint atkLevel, uint defGuard)
        {
        	var uVar1 = 0;
        	if (defGuard != 0) {
        	  uVar1 = (atkPower * wazaPower * ((uint)(atkLevel << 1) / 5 + 2)) / defGuard;
        	}
        	return uVar1 / 0x32 + 2;
        }

        public static uint AffDamage(uint rawDamage, TypeAffinity.AffinityID aff)
        {
        	var iVar1 = (int)rawDamage;
        	switch(aff) {
        	case 0:
        	  return 0;
        	case 1:
        	  return rawDamage >> 6 & 0x3ffffff;
        	case 2:
        	  return rawDamage >> 5 & 0x7ffffff;
        	case 3:
        	  return rawDamage >> 4 & 0xfffffff;
        	case 4:
        	  return rawDamage >> 3 & 0x1fffffff;
        	case 5:
        	  return rawDamage >> 2 & 0x3fffffff;
        	case 6:
        	  return rawDamage >> 1 & 0x7fffffff;
        	case 8:
        	  return (ulong)(uint)(iVar1 << 1);
        	case 9:
        	  return (ulong)(uint)(iVar1 << 2);
        	case 10:
        	  return (ulong)(uint)(iVar1 << 3);
        	case 0xb:
        	  return (ulong)(uint)(iVar1 << 4);
        	case 0xc:
        	  return (ulong)(uint)(iVar1 << 5);
        	case 0xd:
        	  rawDamage = (ulong)(uint)(iVar1 << 6);
        	}
        	return rawDamage;
        }

        // TODO
        public static uint GetPublicRand(uint range) { return 0; }

        // TODO
        public static uint GetRand(uint range) { return 0; }

        // TODO
        public static uint RandRange(uint min, uint max) { return 0; }

        public static uint MulRatio(uint value, int ratio)
        {
        	var uVar1 = (uint)(ratio * value) >> 0xc;
        	if (0x800 < (ratio * value & 0xfffU)) {
        	  uVar1 = uVar1 + 1;
        	}
        	return uVar1;
        }

        // TODO
        public static uint MulRatio_OverZero(uint value, int ratio) { return 0; }

        public static uint MulRatioInt(uint value, uint ratio)
        {
        	var uVar1 = ratio * value;
        	var uVar2 = uVar1 / 100;
        	if (0x31 < uVar1 % 100) {
        	  uVar2 = uVar1 / 100 + 1;
        	}
        	return uVar2;
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

        // TODO
        public static ushort StatusRank(ushort defaultVal, byte rank) { return 0; }

        public static uint QuotMaxHP_Zero(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false)
        {
        	var uVar4 = 0xf;
        	if (denom == 0) {
        	  denom = 1;
        	}
        	if (useBeforeGParam) {
        	  var uVar3 = bpp.IsGMode();
        	  uVar4 = 0xf;
        	  if (uVar3) {
        	    uVar4 = 0x10;
        	  }
        	}
        	var uVar2 = bpp.GetValue(uVar4);
        	var uVar1 = 0;
        	if (denom != 0) {
        	  uVar1 = uVar2 / denom;
        	}
        	return uVar1;
        }

        // TODO
        public static uint QuotMaxHP(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false) { return 0; }

        // TODO
        public static byte HitPer(byte defPer, byte rank) { return 0; }

        // TODO
        public static bool CheckCritical(byte rank, int ratio) { return false; }

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
        	return (int)sickID < 6;
        }

        public static ushort RecvWeatherDamage(BTL_POKEPARAM bpp, BtlWeather weather)
        {
        	if (weather == '\x03') {
        	  var uVar3 = bpp.IsMatchType(0xe);
        	}
        	else {
        	  if (weather != '\x04') {
        	    return 0;
        	  }
        	  uVar3 = bpp.IsMatchType(5);
        	  if (uVar3) {
        	    return 0;
        	  }
        	  uVar3 = bpp.IsMatchType(8);
        	  if (uVar3) {
        	    return 0;
        	  }
        	  uVar3 = bpp.IsMatchType(4);
        	}
        	if (uVar3) {
        	  return 0;
        	}
        	var uVar2 = bpp.GetValue(0x10);
        	var uVar1 = uVar2 + 0xf;
        	if (-1 < (int)uVar2) {
        	  uVar1 = uVar2;
        	}
        	uVar1 = uVar1 >> 4;
        	if ((uVar1 & 0xffff) == 0) {
        	  uVar1 = 1;
        	}
        	return (ushort)(uVar1);
        }

        // TODO
        public static int GetWeatherDmgRatio(BtlWeather weather, byte wazaType) { return 0; }

        public static bool IsShineWeather(BtlWeather weather)
        {
        	if (weather == '\x01') {
        	  return true;
        	}
        	return weather == '\x06';
        }

        public static bool IsRainWeather(BtlWeather weather)
        {
        	if (weather == '\x02') {
        	  return true;
        	}
        	return weather == '\x05';
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

        // TODO
        public static bool IsOccurPer(uint per) { return false; }

        public static int Roundup(int value, int min)
        {
        	if (min <= value) {
        	  min = value;
        	}
        	return min;
        }

        public static int Rounddown(int val, int max)
        {
        	if (val <= max) {
        	  max = val;
        	}
        	return max;
        }

        // TODO
        public static int RoundValue(int val, int min, int max) { return 0; }

        // TODO
        public static WazaTarget GetWazaTarget(WazaNo waza, BTL_POKEPARAM attacker) { return WazaTarget.TARGET_OTHER_SELECT; }

        public static WazaTarget GetNoroiTargetType(BTL_POKEPARAM attacker)
        {
        	var uVar1 = attacker.IsMatchType(7);
        	var uVar2 = 0;
        	if (!uVar1) {
        	  uVar2 = 7;
        	}
        	return uVar2;
        }

        // TODO
        public static BtlPokePos DecideWazaTargetAuto(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, bool IsClient = false) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static uint PokeIDx6_Pack32bit(byte[] pokeIDList) { return 0; }

        // TODO
        public static void PokeIDx6_Unpack32bit(uint pack, byte[] pokeIDList) { }

        // TODO
        public static bool is_include(WazaNo[] tbl, uint tblElems, WazaNo wazaID) { return false; }

        // TODO
        public static WazaNo RandWaza(WazaNo[] omitWazaTbl, ushort tblElems) { return WazaNo.NULL; }

        // TODO
        public static BtlPokePos DecideWazaTargetAutoForClient(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, ref ulong pRandContextSaveWork) { return BtlPokePos.POS_1ST_0; }

        public static bool RULE_IsNeedSelectTarget(BtlRule rule)
        {
        	return (int)rule != 0;
        }

        public static byte RULE_HandPokeIndex(BtlRule rule, byte numCoverPos)
        {
        	return (byte)(numCoverPos);
        }

        public static uint calcWinMoney_Sub(in BSP_TRAINER_DATA trData, in PokeParty party)
        {
        	var lVar3 = party;
        	if (lVar3 == 0) {
        	  return 0;
        	}
        	if ((trData != null) && (lVar3.Length != 0)) {
        	  var uVar4 = lVar3.GetMemberPointerConst(lVar3.Length + -1);
        	  var uVar1 = trData.GetGoldParam();
        	  var iVar2 = uVar4.GetLevel();
        	  return (uVar1 & 0xff) * iVar2 * 4;
        	}
        	return 0;
        }

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