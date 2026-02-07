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
            if (type2 != (byte)PokeType.MAX && type2 != type1)
            {
                TypeAffinity.AffinityID aff2 = TypeAff((PokeType)wazaType, (PokeType)type2);
                aff = TypeAffMul(aff, aff2);
            }
            if (typeEx != (byte)PokeType.MAX && typeEx != type1 && typeEx != type2)
            {
                TypeAffinity.AffinityID affEx = TypeAff((PokeType)wazaType, (PokeType)typeEx);
                aff = TypeAffMul(aff, affEx);
            }
            return aff;
        }

        public static byte GetResistTypes(PokeType type, byte[] dst)
        {
            byte count = 0;
            for (int i = 0; i < (int)PokeType.MAX; i++)
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
            switch (aff)
            {
                case TypeAffinity.AffinityID.TYPEAFF_0:
                    return 0;
                case TypeAffinity.AffinityID.TYPEAFF_1_64:
                    return rawDamage >> 6;
                case TypeAffinity.AffinityID.TYPEAFF_1_32:
                    return rawDamage >> 5;
                case TypeAffinity.AffinityID.TYPEAFF_1_16:
                    return rawDamage >> 4;
                case TypeAffinity.AffinityID.TYPEAFF_1_8:
                    return rawDamage >> 3;
                case TypeAffinity.AffinityID.TYPEAFF_1_4:
                    return rawDamage >> 2;
                case TypeAffinity.AffinityID.TYPEAFF_1_2:
                    return rawDamage >> 1;
                case TypeAffinity.AffinityID.TYPEAFF_2:
                    return rawDamage << 1;
                case TypeAffinity.AffinityID.TYPEAFF_4:
                    return rawDamage << 2;
                case TypeAffinity.AffinityID.TYPEAFF_8:
                    return rawDamage << 3;
                case TypeAffinity.AffinityID.TYPEAFF_16:
                    return rawDamage << 4;
                case TypeAffinity.AffinityID.TYPEAFF_32:
                    return rawDamage << 5;
                case TypeAffinity.AffinityID.TYPEAFF_64:
                    return rawDamage << 6;
                default:
                    return rawDamage;
            }
        }

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

        public static void MakeDefaultWazaSickCont(WazaSick sick, BTL_POKEPARAM attacker, out BTL_SICKCONT cont)
        {
            if ((int)sick < (int)Sick.MAX)
            {
                cont = MakeDefaultPokeSickCont((Sick)sick, attacker.GetID());
            }
            else if (sick == WazaSick.WAZASICK_KONRAN)
            {
                uint turns = RandRange(2, 4);
                cont = SICKCONT.MakeTurn(attacker.GetID(), (byte)turns);
            }
            else if (sick == WazaSick.WAZASICK_MEROMERO)
            {
                cont = SICKCONT.MakePoke(attacker.GetID(), attacker.GetID());
            }
            else
            {
                cont = SICKCONT.MakePermanent(attacker.GetID());
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
            if (sick == Sick.NEMURI)
            {
                cont.type = 2;
                cont.causePokeID = causePokeID;
                uint turns;
                if (isCantUseRand)
                {
                    turns = 3;
                }
                else
                {
                    turns = RandRange(2, 4);
                }
                cont.turn_count = (byte)turns;
                return cont;
            }
            byte sickType;
            if (sick >= Sick.KOORI && sick <= Sick.DOKU)
            {
                sickType = 1;
            }
            else if (sick == Sick.MAHI)
            {
                sickType = 1;
            }
            else
            {
                sickType = 0;
            }
            cont.type = sickType;
            cont.causePokeID = causePokeID;
            return cont;
        }

        public static ushort StatusRank(ushort defaultVal, byte rank)
        {
            return (ushort)(defaultVal * StatusRankTable[rank].num / StatusRankTable[rank].denom);
        }

        public static uint QuotMaxHP_Zero(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false)
        {
            if (denom == 0)
            {
                denom = 1;
            }
            BTL_POKEPARAM.ValueID vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP;
            if (useBeforeGParam)
            {
                if (bpp.IsGMode())
                {
                    vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP_BEFORE_G;
                }
            }
            uint maxHP = (uint)bpp.GetValue(vid);
            if (denom != 0)
            {
                return maxHP / denom;
            }
            return 0;
        }

        public static uint QuotMaxHP(BTL_POKEPARAM bpp, uint denom, bool useBeforeGParam = false)
        {
            if (denom == 0)
            {
                denom = 1;
            }
            BTL_POKEPARAM.ValueID vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP;
            if (useBeforeGParam)
            {
                if (bpp.IsGMode())
                {
                    vid = BTL_POKEPARAM.ValueID.BPP_MAX_HP_BEFORE_G;
                }
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
            return (byte)(defPer * HitPerTable[rank].num / HitPerTable[rank].denom);
        }

        public static bool CheckCritical(byte rank, int ratio)
        {
            if (rank >= CheckCriticalTable.Length)
                return true;
            return GetRand(CheckCriticalTable[rank]) < ratio;
        }

        public static int ITEM_GetParam(ushort item, Pml.Item.ItemData.PrmID paramID)
        {
            return Pml.Item.ItemData.GetParam(item, paramID);
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
            var personalData = PersonalSystem.GetPersonalData((MonsNo)mons_no, (ushort)form_no);
            return personalData.GetParam(paramID);
        }

        public static uint PERSONAL_GetMinExp(int monsno, int formno, byte level)
        {
            PersonalSystem.LoadGrowTable((MonsNo)monsno, (ushort)formno);
            return PersonalSystem.GetMinExp(level);
        }

        public static bool PERSONAL_IsEvoCancelPokemon(int mons_no, ushort formno, byte level)
        {
            PersonalSystem.LoadEvolutionTable((MonsNo)mons_no, formno);
            byte routeNum = PersonalSystem.GetEvolutionRouteNum();
            for (uint i = 0; i < routeNum; i++)
            {
                EvolveCond cond = PersonalSystem.GetEvolutionCondition((byte)i);
                if (cond == EvolveCond.LEVELUP)
                {
                    byte evoLevel = PersonalSystem.GetEvolveEnableLevel((byte)i);
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
            return sickID >= WazaSick.WAZASICK_MAHI && sickID <= WazaSick.WAZASICK_DOKU;
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
                if (bpp.IsMatchType((byte)PokeType.IWA))
                {
                    return 0;
                }
                if (bpp.IsMatchType((byte)PokeType.HAGANE))
                {
                    return 0;
                }
                if (bpp.IsMatchType((byte)PokeType.JIMEN))
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            uint maxHP = (uint)bpp.GetValue(BTL_POKEPARAM.ValueID.BPP_MAX_HP_BEFORE_G);
            ushort damage = (ushort)(maxHP / 16);
            if (damage == 0)
            {
                damage = 1;
            }
            return damage;
        }

        public static int GetWeatherDmgRatio(BtlWeather weather, byte wazaType)
        {
            int ratio = 0x1000;
            switch (weather)
            {
                case BtlWeather.BTL_WEATHER_SHINE:
                case BtlWeather.BTL_WEATHER_DAY:
                {
                    int fireRatio = (wazaType == (byte)PokeType.MIZU) ? 0x800 : 0x1000;
                    int waterRatio = 0x1800;
                    ratio = (wazaType == (byte)PokeType.HONOO) ? waterRatio : fireRatio;
                    break;
                }
                case BtlWeather.BTL_WEATHER_RAIN:
                case BtlWeather.BTL_WEATHER_STORM:
                {
                    int waterRatio = (wazaType == (byte)PokeType.MIZU) ? 0x1800 : 0x1000;
                    int fireRatio = 0x800;
                    ratio = (wazaType == (byte)PokeType.HONOO) ? fireRatio : waterRatio;
                    break;
                }
            }
            return ratio;
        }

        public static bool IsShineWeather(BtlWeather weather)
        {
            return weather == BtlWeather.BTL_WEATHER_SHINE || weather == BtlWeather.BTL_WEATHER_DAY;
        }

        public static bool IsRainWeather(BtlWeather weather)
        {
            return weather == BtlWeather.BTL_WEATHER_RAIN || weather == BtlWeather.BTL_WEATHER_STORM;
        }

        public static void WazaSickContToBppSickCont(SickContParam wazaSickCont, BTL_POKEPARAM attacker, out BTL_SICKCONT sickCont)
        {
            switch (wazaSickCont.type)
            {
                case 1:
                    sickCont = SICKCONT.MakePermanentIncParam(attacker.GetID(), wazaSickCont.turnMax, wazaSickCont.turnMin);
                    break;
                case 2:
                {
                    uint turns = RandRange(wazaSickCont.turnMin, wazaSickCont.turnMax);
                    sickCont = SICKCONT.MakeTurn(attacker.GetID(), (byte)turns);
                    break;
                }
                case 3:
                    sickCont = SICKCONT.MakePoke(attacker.GetID(), attacker.GetID());
                    break;
                case 4:
                {
                    uint turns = RandRange(wazaSickCont.turnMin, wazaSickCont.turnMax);
                    sickCont = SICKCONT.MakePokeTurn(attacker.GetID(), attacker.GetID(), (byte)turns);
                    break;
                }
                default:
                    sickCont = SICKCONT.MakeNull();
                    break;
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
            for (int i = 0; ; i++)
            {
                WazaSick sickID = tables.GetMentalSickID((uint)i);
                if (sickID == WazaSick.WAZASICK_NONE)
                {
                    break;
                }
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

        public static WazaTarget GetWazaTarget(WazaNo waza, BTL_POKEPARAM attacker)
        {
            if (waza == WazaNo.NOROI)
            {
                if (attacker != null)
                {
                    return attacker.IsMatchType((byte)PokeType.GHOST)
                        ? WazaTarget.TARGET_OTHER_SELECT
                        : WazaTarget.TARGET_USER;
                }
            }
            return WazaDataSystem.GetTarget(waza);
        }

        public static WazaTarget GetNoroiTargetType(BTL_POKEPARAM attacker)
        {
            return attacker.IsMatchType((byte)PokeType.GHOST)
                ? WazaTarget.TARGET_OTHER_SELECT
                : WazaTarget.TARGET_USER;
        }

        public static BtlPokePos DecideWazaTargetAuto(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, bool IsClient = false)
        {
            BtlRule rule = mainModule.GetRule();
            byte pokeID = bpp.GetID();
            BtlPokePos myPos = mainModule.PokeIDtoPokePos(pokeCon, pokeID);
            WazaTarget target = WazaDataSystem.GetTarget(waza);

            if (waza == WazaNo.NOROI)
            {
                target = bpp.IsMatchType((byte)PokeType.GHOST)
                    ? WazaTarget.TARGET_OTHER_SELECT
                    : WazaTarget.TARGET_USER;
            }

            if (rule == BtlRule.BTL_RULE_SINGLE)
            {
                switch (target)
                {
                    case WazaTarget.TARGET_OTHER_SELECT:
                    case WazaTarget.TARGET_ENEMY_SELECT:
                    case WazaTarget.TARGET_ENEMY_RANDOM:
                        return mainModule.GetOpponentPokePos(myPos, 0);
                    case WazaTarget.TARGET_FRIEND_USER_SELECT:
                    case WazaTarget.TARGET_USER:
                        return myPos;
                    default:
                        return BtlPokePos.POS_NULL;
                }
            }
            else
            {
                ExPokePos exPos;
                byte[] pokeIDAry = new byte[5];

                switch (target)
                {
                    case WazaTarget.TARGET_OTHER_SELECT:
                    case WazaTarget.TARGET_ENEMY_SELECT:
                    case WazaTarget.TARGET_ENEMY_RANDOM:
                        exPos = new ExPokePos(ExPokePos.ExPosType.AREA_ENEMY, myPos);
                        break;
                    case WazaTarget.TARGET_FRIEND_USER_SELECT:
                        exPos = new ExPokePos(ExPokePos.ExPosType.AREA_MYTEAM, myPos);
                        break;
                    case WazaTarget.TARGET_FRIEND_SELECT:
                        exPos = new ExPokePos(ExPokePos.ExPosType.AREA_FRIENDS, myPos);
                        break;
                    case WazaTarget.TARGET_USER:
                        return myPos;
                    default:
                        return BtlPokePos.POS_NULL;
                }

                BtlMultiMode multiMode = mainModule.GetMultiMode();
                byte count = exPos.ExpandExistPokeID(rule, multiMode, pokeCon, pokeIDAry);
                if (count != 0)
                {
                    uint idx;
                    if (!IsClient)
                    {
                        idx = GetRand(count);
                    }
                    else
                    {
                        idx = GetPublicRand(count);
                    }
                    return mainModule.PokeIDtoPokePos(pokeCon, pokeIDAry[idx]);
                }

                BtlPokePos[] posAry = new BtlPokePos[5];
                byte posCount = exPos.ExpandPos(rule, multiMode, posAry);
                if (posCount != 0)
                {
                    uint idx;
                    if (!IsClient)
                    {
                        idx = GetRand(posCount);
                    }
                    else
                    {
                        idx = GetPublicRand(posCount);
                    }
                    return posAry[idx];
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
                    return true;
            }
            return false;
        }

        public static WazaNo RandWaza(WazaNo[] omitWazaTbl, ushort tblElems)
        {
            ushort count = 0;
            for (ushort wazaID = 1; wazaID < (ushort)WazaNo.MAX; wazaID++)
            {
                if (tblElems != 0)
                {
                    bool found = false;
                    for (ushort j = 0; j < tblElems; j++)
                    {
                        if ((WazaNo)wazaID == omitWazaTbl[j])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        continue;
                    }
                }
                g_WazaStoreWork[count] = (WazaNo)wazaID;
                count++;
            }
            if (count == 0)
            {
                return WazaNo.NULL;
            }
            uint idx = GetRand(count);
            return g_WazaStoreWork[idx];
        }

        public static BtlPokePos DecideWazaTargetAutoForClient(MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM bpp, WazaNo waza, ref ulong pRandContextSaveWork)
        {
            return DecideWazaTargetAuto(mainModule, pokeCon, bpp, waza, true);
        }

        public static bool RULE_IsNeedSelectTarget(BtlRule rule)
        {
            return rule != BtlRule.BTL_RULE_SINGLE;
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
            PokemonParam lastMon = party.GetMemberPointer(party.GetMemberCount() - 1);
            uint gold = trData.GetGoldParam();
            uint level = lastMon.GetLevel();
            return gold * level * 4;
        }

        public static uint CalcWinMoney(BATTLE_SETUP_PARAM sp)
        {
            if (sp.competitor != BtlCompetitor.BTL_COMPETITOR_TRAINER)
            {
                return 0;
            }
            uint total = 0;
            if (sp.tr_data[1] != null && sp.party[1] != null)
            {
                total = calcWinMoney_Sub(sp.tr_data[1], sp.party[1]);
            }
            if (sp.tr_data.Length > 3 && sp.tr_data[3] != null && sp.party[3] != null)
            {
                total += calcWinMoney_Sub(sp.tr_data[3], sp.party[3]);
            }
            return total;
        }

        public static uint CalcLoseMoney(BATTLE_SETUP_PARAM sp, POKECON pokeCon)
        {
            BTL_PARTY party = pokeCon.GetPartyData(0);
            byte count = party.GetMemberCount();
            uint maxLevel = 0;
            for (uint i = 0; i < count; i++)
            {
                BTL_POKEPARAM bpp = party.GetMemberDataConst((byte)i);
                uint level = (uint)bpp.GetValue(BTL_POKEPARAM.ValueID.BPP_LEVEL);
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
                penalty = money;
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
