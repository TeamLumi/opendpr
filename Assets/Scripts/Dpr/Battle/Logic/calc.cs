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
            {
                flags[i] = 0;
            }
        }

        public static void BITFLG_Set(byte[] flags, uint index)
        {
            byte byteIdx = (byte)(index >> 3);
            if (byteIdx < flags.Length)
            {
                flags[byteIdx] |= (byte)(1 << (int)(index & 7));
            }
        }

        public static bool BITFLG_Check(byte[] flags, uint index)
        {
            byte byteIdx = (byte)(index >> 3);
            if (byteIdx >= flags.Length)
            {
                return false;
            }
            return (flags[byteIdx] & (1 << (int)(index & 7))) != 0;
        }

        public static void BITFLG_Off(byte[] flags, uint index)
        {
            byte byteIdx = (byte)(index >> 3);
            if (byteIdx < flags.Length)
            {
                flags[byteIdx] &= (byte)~(1 << (int)(index & 7));
            }
        }

        public static uint ABS(int value)
        {
            if (value < 0)
                return (uint)(-value);
            return (uint)value;
        }

        public static void InitSys(Random randSys, bool bSakasaBtl)
        {
            g_RandSys = randSys;
            g_PublicRand = new Random();
            g_PublicRand.Initialize();
            g_WazaStoreWork = new WazaNo[827];
            g_SakasaBtlFlag = bSakasaBtl;
        }

        public static void ResetSys(ulong randSeed)
        {
            g_RandSys.Initialize(randSeed);
        }

        public static void QuitSys()
        {
            g_WazaStoreWork = null;
            g_RandSys = null;
            g_PublicRand = null;
        }

        public static Random GetRandGenerator()
        {
            return g_RandSys;
        }

        public static TypeAffinity.AffinityID TypeAff(PokeType wazaType, PokeType pokeType)
        {
            return TypeAffinity.CalcAffinity(wazaType, pokeType, g_SakasaBtlFlag);
        }

        public static TypeAffinity.AffinityID TypeAffMul(TypeAffinity.AffinityID aff1, TypeAffinity.AffinityID aff2)
        {
            return TypeAffinity.MulAffinity(aff1, aff2);
        }

        public static TypeAffinity.AffinityID TypeAffPair(byte wazaType, PokeTypePair pokeType)
        {
            PokeTypePair.Split(pokeType, out byte type1, out byte type2, out byte typeEx);
            TypeAffinity.AffinityID aff = TypeAff((PokeType)wazaType, (PokeType)type1);
            if (type2 != (byte)PokeType.NULL && type2 != type1)
            {
                TypeAffinity.AffinityID aff2 = TypeAff((PokeType)wazaType, (PokeType)type2);
                aff = TypeAffMul(aff, aff2);
            }
            if (typeEx != (byte)PokeType.NULL && typeEx != type1 && typeEx != type2)
            {
                TypeAffinity.AffinityID aff3 = TypeAff((PokeType)wazaType, (PokeType)typeEx);
                aff = TypeAffMul(aff, aff3);
            }
            return aff;
        }

        public static byte GetResistTypes(PokeType type, byte[] dst)
        {
            byte count = 0;
            for (int i = 0; i < 0x12; i++)
            {
                TypeAffinity.AffinityID aff = TypeAff(type, (PokeType)i);
                if (aff == TypeAffinity.AffinityID.TYPEAFF_1_2 || aff == TypeAffinity.AffinityID.TYPEAFF_0)
                {
                    dst[count] = (byte)i;
                    count++;
                }
            }
            return count;
        }

        public static uint DamageBase(uint wazaPower, uint atkPower, uint atkLevel, uint defGuard)
        {
            uint result = 0;
            if (defGuard != 0)
            {
                result = (atkPower * wazaPower * (atkLevel * 2 / 5 + 2)) / defGuard;
            }
            return result / 50 + 2;
        }

        public static uint AffDamage(uint rawDamage, TypeAffinity.AffinityID aff)
        {
            int val = (int)rawDamage;
            switch (aff)
            {
                case TypeAffinity.AffinityID.TYPEAFF_0: return 0;
                case TypeAffinity.AffinityID.TYPEAFF_1_64: return rawDamage >> 6;
                case TypeAffinity.AffinityID.TYPEAFF_1_32: return rawDamage >> 5;
                case TypeAffinity.AffinityID.TYPEAFF_1_16: return rawDamage >> 4;
                case TypeAffinity.AffinityID.TYPEAFF_1_8: return rawDamage >> 3;
                case TypeAffinity.AffinityID.TYPEAFF_1_4: return rawDamage >> 2;
                case TypeAffinity.AffinityID.TYPEAFF_1_2: return rawDamage >> 1;
                case TypeAffinity.AffinityID.TYPEAFF_2: return (uint)(val << 1);
                case TypeAffinity.AffinityID.TYPEAFF_4: return (uint)(val << 2);
                case TypeAffinity.AffinityID.TYPEAFF_8: return (uint)(val << 3);
                case TypeAffinity.AffinityID.TYPEAFF_16: return (uint)(val << 4);
                case TypeAffinity.AffinityID.TYPEAFF_32: return (uint)(val << 5);
                case TypeAffinity.AffinityID.TYPEAFF_64: return (uint)(val << 6);
                default: return rawDamage;
            }
        }

        public static uint GetPublicRand(uint range)
        {
            if (g_PublicRand != null)
            {
                return (uint)g_PublicRand.GetValue(range);
            }
            return (uint)UnityEngine.Random.Range(0, (float)range);
        }

        public static uint GetRand(uint range)
        {
            return (uint)g_RandSys.GetValue(range);
        }

        public static uint RandRange(uint min, uint max)
        {
            uint lo = min;
            uint hi = max;
            if (min > max)
            {
                lo = max;
                hi = min;
            }
            return lo + GetRand(hi - lo + 1);
        }

        public static uint MulRatio(uint value, int ratio)
        {
            int product = ratio * (int)value;
            uint result = (uint)product >> 12;
            if ((uint)(product & 0xfff) > 0x800)
            {
                result++;
            }
            return result;
        }

        public static uint MulRatio_OverZero(uint value, int ratio)
        {
            uint result = MulRatio(value, ratio);
            if (result == 0)
            {
                result = 1;
            }
            return result;
        }

        public static uint MulRatioInt(uint value, uint ratio)
        {
            uint product = value * ratio;
            uint result = product / 100;
            if (product % 100 > 49)
            {
                result = product / 100 + 1;
            }
            return result;
        }

        public static void MakeDefaultWazaSickCont(WazaSick sick, BTL_POKEPARAM attacker, out BTL_SICKCONT cont)
        {
            int sickID = (int)sick;
            if (sickID < 6)
            {
                byte pokeID = attacker.GetID();
                cont = MakeDefaultPokeSickCont((Sick)sickID, pokeID);
            }
            else if (sickID == 6)
            {
                uint turns = RandRange(2, 4);
                byte pokeID = attacker.GetID();
                cont = SICKCONT.MakeTurn(pokeID, (byte)turns);
            }
            else if (sickID == 7)
            {
                byte pokeID = attacker.GetID();
                byte pokeID2 = attacker.GetID();
                cont = SICKCONT.MakePoke(pokeID, pokeID2);
            }
            else
            {
                byte pokeID = attacker.GetID();
                cont = SICKCONT.MakePermanent(pokeID);
            }
        }

        public static BTL_SICKCONT MakeWazaSickCont_Poke(byte pokeID, byte causePokeID)
        {
            BTL_SICKCONT cont = default;
            cont.type = 3;
            cont.causePokeID = causePokeID;
            cont.poke_ID = pokeID;
            return cont;
        }

        public static BTL_SICKCONT MakeDefaultPokeSickCont(Sick sick, byte causePokeID, bool isCantUseRand = false)
        {
            BTL_SICKCONT cont = default;
            int sickID = (int)sick;
            if (sickID == 2)
            {
                cont.type = 2;
                cont.causePokeID = causePokeID;
                byte turns;
                if (isCantUseRand)
                {
                    turns = 3;
                }
                else
                {
                    turns = (byte)RandRange(2, 4);
                }
                cont.turn_count = turns;
                return cont;
            }
            else if (sickID >= 3 && sickID <= 5)
            {
                cont.type = 1;
                cont.causePokeID = causePokeID;
                return cont;
            }
            else if (sickID == 1)
            {
                cont.type = 1;
                cont.causePokeID = causePokeID;
                return cont;
            }
            else
            {
                cont.type = 0;
                cont.causePokeID = causePokeID;
                return cont;
            }
        }

        public static ushort StatusRank(ushort defaultVal, byte rank)
        {
            if (rank < StatusRankTable.Length)
            {
                uint num = StatusRankTable[rank].num;
                uint denom = StatusRankTable[rank].denom;
                if (denom != 0)
                {
                    return (ushort)((uint)(defaultVal * num) / denom);
                }
            }
            return defaultVal;
        }

        public static uint QuotMaxHP_Zero(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false)
        {
            if (denom == 0) denom = 1;
            BTL_POKEPARAM.ValueID vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP;
            if (useBeforeGParam && bpp.IsGMode())
            {
                vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP_BEFORE_G;
            }
            uint maxHP = (uint)bpp.GetValue(vid);
            uint result = 0;
            if (denom != 0)
            {
                result = maxHP / denom;
            }
            return result;
        }

        public static uint QuotMaxHP(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false)
        {
            if (denom == 0) denom = 1;
            BTL_POKEPARAM.ValueID vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP;
            if (useBeforeGParam && bpp.IsGMode())
            {
                vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP_BEFORE_G;
            }
            uint maxHP = (uint)bpp.GetValue(vid);
            uint result = 0;
            if (denom != 0)
            {
                result = maxHP / denom;
            }
            if (maxHP < denom)
            {
                result = 1;
            }
            return result;
        }

        public static byte HitPer(byte defPer, byte rank)
        {
            if (rank < HitPerTable.Length)
            {
                uint num = HitPerTable[rank].num;
                uint denom = HitPerTable[rank].denom;
                uint result = 0;
                if (denom != 0)
                {
                    result = (num * (uint)(defPer & 0xff)) / denom;
                }
                if (result > 99)
                {
                    result = 100;
                }
                return (byte)result;
            }
            return defPer;
        }

        public static bool CheckCritical(byte rank, int ratio)
        {
            if (rank < CheckCriticalTable.Length)
            {
                uint critVal = 0;
                if (ratio != 0)
                {
                    critVal = (uint)CheckCriticalTable[rank] / (uint)ratio;
                }
                uint critByte = critVal & 0xff;
                if (critByte == 0)
                {
                    critByte = 1;
                }
                return GetRand(critByte) == 0;
            }
            return false;
        }

        public static int ITEM_GetParam(ushort item, Pml.Item.ItemData.PrmID paramID)
        {
            return Pml.Item.ItemManager.Instance.GetParam(item, paramID);
        }

        public static bool ITEM_IsBall(ushort itemID)
        {
            return ITEM_GetParam(itemID, Pml.Item.ItemData.PrmID.ITEM_TYPE) == 5;
        }

        public static bool ITEM_IsReriveItem(ushort itemID)
        {
            return ITEM_GetParam(itemID, Pml.Item.ItemData.PrmID.DEATH_RCV) != 0;
        }

        public static bool ITEM_IsMail(ushort item)
        {
            return ITEM_GetParam(item, Pml.Item.ItemData.PrmID.ITEM_TYPE) == 6;
        }

        public static uint PERSONAL_GetParam(int mons_no, int form_no, ParamID paramID)
        {
            var data = Pml.Personal.PersonalSystem.GetPersonalData((Pml.MonsNo)mons_no, (ushort)form_no);
            return Pml.Personal.PersonalTableExtensions.GetParam(data, paramID);
        }

        public static uint PERSONAL_GetMinExp(int monsno, int formno, byte level)
        {
            Pml.Personal.PersonalSystem.LoadGrowTable((Pml.MonsNo)monsno, (ushort)formno);
            return Pml.Personal.PersonalSystem.GetMinExp(level);
        }

        public static bool PERSONAL_IsEvoCancelPokemon(int mons_no, ushort formno, byte level)
        {
            Pml.Personal.PersonalSystem.LoadEvolutionTable((Pml.MonsNo)mons_no, formno);
            byte routeNum = Pml.Personal.PersonalSystem.GetEvolutionRouteNum();
            for (uint i = 0; i < routeNum; i++)
            {
                var cond = Pml.Personal.PersonalSystem.GetEvolutionCondition((byte)i);
                if ((int)cond == 4)
                {
                    byte evoLevel = Pml.Personal.PersonalSystem.GetEvolveEnableLevel((byte)i);
                    if (evoLevel <= level)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsBasicSickID(WazaSick sickID)
        {
            return (int)sickID < 6;
        }

        public static ushort RecvWeatherDamage(BTL_POKEPARAM bpp, BtlWeather weather)
        {
            if (weather == BtlWeather.BTL_WEATHER_SNOW)
            {
                if (bpp.IsMatchType((byte)PokeType.KOORI))
                {
                    return 0;
                }
            }
            else if (weather == BtlWeather.BTL_WEATHER_SAND)
            {
                if (bpp.IsMatchType((byte)PokeType.JIMEN))
                {
                    return 0;
                }
                if (bpp.IsMatchType((byte)PokeType.HAGANE))
                {
                    return 0;
                }
                if (bpp.IsMatchType((byte)PokeType.IWA))
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            uint maxHP = (uint)bpp.GetValue(BTL_POKEPARAM.ValueID.BPP_MAX_HP_BEFORE_G);
            uint result = maxHP;
            if ((int)maxHP >= 0)
            {
                result = maxHP;
            }
            else
            {
                result = maxHP + 15;
            }
            result = result >> 4;
            if ((result & 0xffff) == 0)
            {
                result = 1;
            }
            return (ushort)result;
        }

        public static int GetWeatherDmgRatio(BtlWeather weather, byte wazaType)
        {
            int result = 0x1000;
            switch (weather)
            {
                case BtlWeather.BTL_WEATHER_SHINE:
                case BtlWeather.BTL_WEATHER_DAY:
                {
                    int valB = (wazaType == 10) ? 0x800 : 0x1000;
                    result = 0x1800;
                    if (wazaType != 9)
                    {
                        result = valB;
                    }
                    break;
                }
                case BtlWeather.BTL_WEATHER_RAIN:
                case BtlWeather.BTL_WEATHER_STORM:
                {
                    int valB = (wazaType == 10) ? 0x1800 : 0x1000;
                    result = 0x800;
                    if (wazaType != 9)
                    {
                        result = valB;
                    }
                    break;
                }
            }
            return result;
        }

        public static bool IsShineWeather(BtlWeather weather)
        {
            if (weather == BtlWeather.BTL_WEATHER_SHINE)
                return true;
            return weather == BtlWeather.BTL_WEATHER_DAY;
        }

        public static bool IsRainWeather(BtlWeather weather)
        {
            if (weather == BtlWeather.BTL_WEATHER_RAIN)
                return true;
            return weather == BtlWeather.BTL_WEATHER_STORM;
        }

        public static void WazaSickContToBppSickCont(SickContParam wazaSickCont, BTL_POKEPARAM attacker, out BTL_SICKCONT sickCont)
        {
            switch (wazaSickCont.type)
            {
                case 1:
                {
                    byte pokeID = attacker.GetID();
                    sickCont = SICKCONT.MakePermanentIncParam(pokeID, (byte)wazaSickCont.turnMax, wazaSickCont.turnMin);
                    return;
                }
                case 2:
                {
                    uint turns = RandRange(wazaSickCont.turnMin, wazaSickCont.turnMax);
                    byte pokeID = attacker.GetID();
                    sickCont = SICKCONT.MakeTurn(pokeID, (byte)turns);
                    return;
                }
                case 3:
                {
                    byte pokeID = attacker.GetID();
                    byte pokeID2 = attacker.GetID();
                    sickCont = SICKCONT.MakePoke(pokeID, pokeID2);
                    return;
                }
                case 4:
                {
                    byte pokeID = attacker.GetID();
                    byte pokeID2 = attacker.GetID();
                    uint turns = RandRange(wazaSickCont.turnMin, wazaSickCont.turnMax);
                    sickCont = SICKCONT.MakePokeTurn(pokeID, pokeID2, (byte)turns);
                    return;
                }
                default:
                    sickCont = SICKCONT.MakeNull();
                    return;
            }
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

        public static WazaSick CheckMentalSick(BTL_POKEPARAM bpp)
        {
            int i = 0;
            while (true)
            {
                WazaSick sickID = tables.GetMentalSickID((uint)i);
                if (sickID == WazaSick.WAZASICK_NONE)
                    break;
                i++;
                if (bpp.CheckSick(sickID))
                {
                    return sickID;
                }
            }
            return WazaSick.WAZASICK_NONE;
        }

        public static TypeAffinity.AboutAffinityID TypeAffAbout(TypeAffinity.AffinityID aff)
        {
            return TypeAffinity.ConvAboutAffinity(aff);
        }

        public static bool IsOccurPer(uint per)
        {
            uint rand = GetRand(100);
            return rand < per;
        }

        public static int Roundup(int value, int min)
        {
            if (value < min)
                return min;
            return value;
        }

        public static int Rounddown(int val, int max)
        {
            if (val > max)
                return max;
            return val;
        }

        public static int RoundValue(int val, int min, int max)
        {
            int result = Roundup(val, min);
            result = Rounddown(result, max);
            return result;
        }

        public static WazaTarget GetWazaTarget(WazaNo waza, BTL_POKEPARAM attacker)
        {
            if (waza == (WazaNo)0xae) // Noroi (Curse)
            {
                if (attacker != null)
                {
                    return attacker.IsMatchType((byte)PokeType.GHOST) ? (WazaTarget)0 : (WazaTarget)7;
                }
            }
            return (WazaTarget)WazaDataSystem.GetTarget(waza);
        }

        public static WazaTarget GetNoroiTargetType(BTL_POKEPARAM attacker)
        {
            return attacker.IsMatchType((byte)PokeType.GHOST) ? (WazaTarget)0 : (WazaTarget)7;
        }

        public static BtlPokePos DecideWazaTargetAuto(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, bool IsClient = false)
        {
            BtlRule rule = mainModule.GetRule();
            byte pokeID = bpp.GetID();
            BtlPokePos basePos = mainModule.PokeIDtoPokePos(pokeCon, pokeID);
            uint wazaTarget = (uint)WazaDataSystem.GetTarget(waza);

            if (waza == (WazaNo)0xae) // Noroi (Curse)
            {
                wazaTarget = (uint)(bpp.IsMatchType((byte)PokeType.GHOST) ? 0 : 7);
            }

            if (rule == BtlRule.BTL_RULE_SINGLE)
            {
                if (wazaTarget > 9)
                {
                    return BtlPokePos.POS_NULL;
                }
                uint mask = (uint)(1 << (int)(wazaTarget & 0x1f));
                if ((mask & 0x239) != 0)
                {
                    return mainModule.GetOpponentPokePos(basePos, 0);
                }
                if ((mask & 0x82) != 0)
                {
                    return basePos;
                }
                return BtlPokePos.POS_NULL;
            }
            else
            {
                ExPokePos exPos = new ExPokePos();
                byte[] pokeIDAry = new byte[5];

                ExPokePos.ExPosType exPosType;
                switch (wazaTarget)
                {
                    case 0: // TARGET_OTHER_SELECT
                    case 3: // TARGET_ENEMY_SELECT
                    case 9: // TARGET_ENEMY_RANDOM
                        exPosType = ExPokePos.ExPosType.AREA_ENEMY;
                        break;
                    case 1: // TARGET_FRIEND_USER_SELECT
                        exPosType = ExPokePos.ExPosType.AREA_MYTEAM;
                        break;
                    case 2: // TARGET_FRIEND_SELECT
                        exPosType = ExPokePos.ExPosType.AREA_FRIENDS;
                        break;
                    case 7: // TARGET_USER
                        return basePos;
                    default:
                        return BtlPokePos.POS_NULL;
                }

                ExPokePos targetExPos = new ExPokePos(exPosType, basePos);
                BtlMultiMode multiMode = mainModule.GetMultiMode();
                byte count = targetExPos.ExpandExistPokeID(rule, multiMode, pokeCon, pokeIDAry);

                if (count != 0)
                {
                    byte randIdx;
                    if (!IsClient)
                    {
                        randIdx = (byte)(GetRand(count) & 0xff);
                    }
                    else
                    {
                        randIdx = (byte)(GetPublicRand(count) & 0xff);
                    }
                    if (randIdx < pokeIDAry.Length)
                    {
                        return mainModule.PokeIDtoPokePos(pokeCon, pokeIDAry[randIdx]);
                    }
                }

                // Fallback: try expanding by pos
                BtlPokePos[] posAry = new BtlPokePos[5];
                byte posCount = targetExPos.ExpandPos(rule, multiMode, posAry);

                if (posCount != 0)
                {
                    byte randIdx;
                    if (!IsClient)
                    {
                        randIdx = (byte)(GetRand(posCount) & 0xff);
                    }
                    else
                    {
                        randIdx = (byte)(GetPublicRand(posCount) & 0xff);
                    }
                    if (randIdx < posAry.Length)
                    {
                        return posAry[randIdx];
                    }
                }

                return BtlPokePos.POS_NULL;
            }
        }

        public static uint PokeIDx6_Pack32bit(byte[] pokeIDList)
        {
            return (uint)(
                (pokeIDList[0] & 0x1f) |
                ((pokeIDList[1] & 0x1f) << 5) |
                ((pokeIDList[2] & 0x1f) << 10) |
                ((pokeIDList[3] & 0x1f) << 15) |
                ((pokeIDList[4] & 0x1f) << 20) |
                ((pokeIDList[5] & 0x1f) << 25)
            );
        }

        public static void PokeIDx6_Unpack32bit(uint pack, byte[] pokeIDList)
        {
            pokeIDList[0] = (byte)(pack & 0x1f);
            pokeIDList[1] = (byte)((pack >> 5) & 0x1f);
            pokeIDList[2] = (byte)((pack >> 10) & 0x1f);
            pokeIDList[3] = (byte)((pack >> 15) & 0x1f);
            pokeIDList[4] = (byte)((pack >> 20) & 0x1f);
            pokeIDList[5] = (byte)((pack >> 25) & 0x1f);
        }

        public static bool is_include(WazaNo[] tbl, uint tblElems, WazaNo wazaID)
        {
            for (uint i = 0; i < tblElems; i++)
            {
                if (tbl[i] == wazaID)
                {
                    return true;
                }
            }
            return false;
        }

        public static WazaNo RandWaza(WazaNo[] omitWazaTbl, ushort tblElems)
        {
            ushort storeCount = 0;

            if (tblElems != 0)
            {
                for (ushort wazaNo = 1; wazaNo <= (ushort)WazaNo.MAX - 1; wazaNo++)
                {
                    bool found = false;
                    for (ushort j = 0; j < tblElems; j++)
                    {
                        if ((uint)omitWazaTbl[j] == wazaNo)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        g_WazaStoreWork[storeCount] = (WazaNo)wazaNo;
                        storeCount++;
                    }
                }
            }
            else
            {
                for (ushort wazaNo = 1; wazaNo <= (ushort)WazaNo.MAX - 1; wazaNo++)
                {
                    g_WazaStoreWork[storeCount] = (WazaNo)wazaNo;
                    storeCount++;
                }
            }

            if (storeCount == 0)
            {
                return WazaNo.NULL;
            }

            ushort randIdx = (ushort)(GetRand(storeCount) & 0xffff);
            return g_WazaStoreWork[randIdx];
        }

        public static BtlPokePos DecideWazaTargetAutoForClient(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, ref ulong pRandContextSaveWork)
        {
            return DecideWazaTargetAuto(mainModule, pokeCon, bpp, waza, true);
        }

        public static bool RULE_IsNeedSelectTarget(BtlRule rule)
        {
            return rule != 0;
        }

        public static byte RULE_HandPokeIndex(BtlRule rule, byte numCoverPos)
        {
            return numCoverPos;
        }

        public static uint calcWinMoney_Sub(in BSP_TRAINER_DATA trData, in PokeParty party)
        {
            if (party == null)
            {
                return 0;
            }
            if (trData == null || party.GetMemberCount() == 0)
            {
                return 0;
            }
            Pml.PokePara.PokemonParam lastMember = party.GetMemberPointerConst(party.GetMemberCount() - 1);
            byte gold = trData.GetGoldParam();
            uint level = lastMember.GetLevel();
            return (uint)(gold * level * 4);
        }

        public static uint CalcWinMoney(BATTLE_SETUP_PARAM sp)
        {
            if (sp.competitor != BtlCompetitor.BTL_COMPETITOR_TRAINER)
            {
                return 0;
            }

            uint money1 = 0;
            if (sp.tr_data[1] != null && sp.party[1] != null && sp.party[1].GetMemberCount() != 0)
            {
                Pml.PokePara.PokemonParam lastMember = sp.party[1].GetMemberPointerConst(sp.party[1].GetMemberCount() - 1);
                byte gold = sp.tr_data[1].GetGoldParam();
                uint level = lastMember.GetLevel();
                money1 = (uint)(gold * level * 4);
            }

            uint money2 = 0;
            if (sp.tr_data.Length > 3 && sp.tr_data[3] != null && sp.party.Length > 3 && sp.party[3] != null)
            {
                if (sp.party[3].GetMemberCount() != 0 && sp.tr_data[3] != null)
                {
                    Pml.PokePara.PokemonParam lastMember = sp.party[3].GetMemberPointerConst(sp.party[3].GetMemberCount() - 1);
                    byte gold = sp.tr_data[3].GetGoldParam();
                    uint level = lastMember.GetLevel();
                    money2 = (uint)(gold * level * 4);
                }
            }

            return money1 + money2;
        }

        public static uint CalcLoseMoney(BATTLE_SETUP_PARAM sp, POKECON pokeCon)
        {
            BTL_PARTY btlParty = pokeCon.GetPartyDataConst(0);
            byte memberCount = (byte)btlParty.GetMemberCount();

            uint maxLevel = 0;
            for (uint i = 0; i < memberCount; i++)
            {
                BTL_POKEPARAM member = btlParty.GetMemberDataConst((byte)i);
                uint level = (uint)member.GetValue(BTL_POKEPARAM.ValueID.BPP_LEVEL);
                if (level > maxLevel)
                {
                    maxLevel = level;
                }
            }

            return CalcPenaltyMoney(maxLevel);
        }

        private static uint CalcPenaltyMoney(uint level_max)
        {
            byte badge = PlayerWork.badge;
            uint penalty = level_max * PENALTY_COEF[badge] * 4;
            uint money = (uint)PlayerWork.GetMoney();
            if (money <= penalty)
            {
                return money;
            }
            return penalty;
        }

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