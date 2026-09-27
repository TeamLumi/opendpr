using Pml.PokePara;
using Pml;
using UnityEngine;
using XLSXContent;
using Dpr.Trainer;
using Dpr.Battle.Logic;

namespace Dpr.Field
{
    public class FieldEncount
    {
        public const int GENE_ENC_1 = 0;
        public const int GENE_ENC_2 = 1;
        public const int TIME_ENC_1 = 2;
        public const int TIME_ENC_2 = 3;
        public const int SWAY_ENC_1 = 4;
        public const int SWAY_ENC_2 = 5;
        public const int SP_ENC_1 = 6;
        public const int SP_ENC_2 = 7;
        public const int AGB_ENC_1 = 8;
        public const int AGB_ENC_2 = 9;
        public const int SWAY_ENC_3 = 10;
        public const int SWAY_ENC_4 = 11;
        public const int ENC_MONS_NUM_NORMAL = 12;
        public const int ENC_MONS_NUM_GENERATE = 2;
        public const int ENC_MONS_NUM_NOON = 2;
        public const int ENC_MONS_NUM_NIGHT = 2;
        public const int ENC_MONS_NUM_SWAY_GRASS = 4;
        public const int ENC_FORM_PROB_NUM = 5;
        public const int ENC_MONS_NUM_AGB = 2;
        public const int ENC_MONS_NUM_SEA = 5;
        public const int ENC_MONS_NUM_ROCK = 5;
        public const int ENC_MONS_NUM_FISH = 5;
        public const int GROUND_ENCOUNT = 0;
        public const int WATER_ENCOUNT = 1;
        public const int FISHING_ENCOUNT = 2;
        private const int ENC_MONS_NUM_MAX = 12;
        private const int ROD_TYPE_NONE = 255;
        private const int WEATHER_NONE = 255;
        private const int CALC_SHIFT = 8;
        private const int DEBUG_MONITOR_TIME = 20;

        // TODO
        public static EncountResult FieldEncount_Check(FieldObjectEntity entity, bool inGridmove) { return null; }

        // TODO
        private static void EncountAttributeCheck(int attribute, FieldEncountTable.Sheettable data, out int enc_location, out uint prob)
        {
            enc_location = 0;
            prob = 0;
        }

        private static void GetEncountProbFishing(FishingRod inRodType, FieldEncountTable.Sheettable data, out uint prob)
        {
            prob = 0;

            switch (inRodType)
            {
                case FishingRod.BoroiTurizao:
                    prob = (uint)data.encRate_turi_boro;
                    break;

                case FishingRod.IiTurizao:
                    prob = (uint)data.encRate_turi_ii;
                    break;

                case FishingRod.SugoiTurizao:
                    prob = (uint)data.encRate_sugoi;
                    break;
            }
        }

        // TODO
        public static EncountResult SetFishingEncount(FishingRod inRodType, Vector2Int position) { return null; }

        // TODO
        public static EncountResult SetSweetEncount() { return null; }

        // TODO
        private static void ApplyDayTime(ref MonsLv[] enc_data, FieldEncountTable.Sheettable data) { }

        // TODO
        private static void ApplyAgbSlot(ref MonsLv[] enc_data, FieldEncountTable.Sheettable data) { }

        // TODO
        private static int GetMaxLvMonsTblNo(MonsLv[] inEncCommonData, ENC_FLD_SPA inFldSpa, int inTblNo) { return 0; }

        // TODO
        private static void SetSpaStruct(PokemonParam inPokeParam, FieldEncountTable.Sheettable inData, ref ENC_FLD_SPA outSpa) { }

        // TODO
        private static uint ChangeEncProb(bool inIsFishing, uint inProb, ENC_FLD_SPA inFldSpa, SYS_WEATHER inWeatherCode, PokemonParam inPokeParam) { return 0; }

        // TODO
        private static bool CheckEcntCancelByLv(ENC_FLD_SPA inFldSpa, PokemonParam inMyPokeParam, int inEneLv) { return false; }

        // TODO
        private static bool CheckSpray(int inEneLv, ref ENC_FLD_SPA inSpa) { return false; }

        // TODO
        private static uint ChangeEncProbByEquipItem(PokemonParam inMyPokeParam, uint ioPer) { return 0; }

        // TODO
        private static bool WildEncSingle(PokemonParam poke_param, ref EncountResult param, FieldEncountTable.Sheettable data, MonsLv[] enc_data, ENC_FLD_SPA inFldSpa, SWAY_ENC_INFO inSwayEncInfo)
        {
            if (inSwayEncInfo.Enc)
            {
                if (inSwayEncInfo.Table == 1)
                {
                    enc_data[SWAY_ENC_1] = data.swayGrass[0];
                    enc_data[SWAY_ENC_2] = data.swayGrass[1];
                    enc_data[SWAY_ENC_3] = data.swayGrass[2];
                    enc_data[SWAY_ENC_4] = data.swayGrass[3];
                }

                param.IsRare = SwayGrass.work_data.random_iro == 0;
                param.IsKakure = SwayGrass.work_data.random_kakure == 0;

                if (inSwayEncInfo.Decide)
                {
                    EncountParamSet(SwayGrass.rensa_mons, (int)SwayGrass.rensa_lv, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1, inFldSpa, poke_param, ref param);
                    return true;
                }
                else
                {
                    return SetSwayEncountData(poke_param, inFldSpa, enc_data, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1, ref param, SwayGrass.rensa_mons, SwayGrass.rensa_lv);
                }
            }
            else
            {
                var encounter = SetEncountData(poke_param, FishingRod.None, inFldSpa, enc_data, GROUND_ENCOUNT, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1, ref param);

                if (encounter)
                    SwayGrass.SwayGrass_InitSwayGrass();

                return encounter;
            }
        }

        // TODO
        private static bool WildEncDouble(PokemonParam poke_param, ref EncountResult param, MonsLv[] enc_data, ENC_FLD_SPA inFldSpa) { return false; }

        // TODO
        private static bool WildWaterEncSingle(PokemonParam poke_param, ref EncountResult param, MonsLv[] enc_data, ENC_FLD_SPA inFldSpa) { return false; }

        // TODO
        private static bool FishingEncSingle(PokemonParam poke_param, ref EncountResult battle_param, MonsLv[] inData, ENC_FLD_SPA inFldSpa, FishingRod inRodType) { return false; }

        // TODO
        private static bool MapEncountCheck(uint per, int attr, bool inGridmove) { return false; }

        // TODO
        private static bool EncountWalkCheck(float walkcnt, uint per) { return false; }

        // TODO
        private static bool EncountCheckMain(uint per) { return false; }

        private static int RandomPokeSet()
        {
            var roll = RandomGroupWork.RandomValue(100);

            if (roll < 20)      return 0;
            else if (roll < 40) return 1;
            else if (roll < 50) return 2;
            else if (roll < 60) return 3;
            else if (roll < 70) return 4;
            else if (roll < 80) return 5;
            else if (roll < 85) return 6;
            else if (roll < 90) return 7;
            else if (roll < 94) return 8;
            else if (roll < 98) return 9;
            else if (roll < 99) return 10;
            else                return 11;
        }

        private static int RandomPokeSetNoGround()
        {
            var roll = RandomGroupWork.RandomValue(100);

            if (roll < 60)      return 0;
            else if (roll < 90) return 1;
            else if (roll < 95) return 2;
            else if (roll < 99) return 3;
            else                return 4;
        }

        private static int RandomPokeSetFishing(FishingRod inFishingRod)
        {
            var roll = RandomGroupWork.RandomValue(100);

            switch (inFishingRod)
            {
                case FishingRod.BoroiTurizao:
                    if (roll < 60)      return 0;
                    else if (roll < 90) return 1;
                    else if (roll < 95) return 2;
                    else if (roll < 99) return 3;
                    else                return 4;

                case FishingRod.IiTurizao:
                    if (roll < 40)      return 0;
                    else if (roll < 80) return 1;
                    else if (roll < 95) return 2;
                    else if (roll < 99) return 3;
                    else                return 4;

                case FishingRod.SugoiTurizao:
                    if (roll < 40)      return 0;
                    else if (roll < 80) return 1;
                    else if (roll < 95) return 2;
                    else if (roll < 99) return 3;
                    else                return 4;

                default:
                    return 0;
            }
        }

        private static bool SetEncountData(PokemonParam param, FishingRod inRodType, ENC_FLD_SPA inFldSpa, MonsLv[] inData, int location, BTL_CLIENT_ID inTarget, ref EncountResult outBattleParam)
        {
            int outNo = 0;

            bool fixedType = false;
            fixedType |= CheckFixTypeEcnt(inFldSpa, inData, inData.Length, PokeType.HAGANE, TokuseiNo.ZIRYOKU,  ref outNo); // Magnet Pull,   50%, Steel
            fixedType |= CheckFixTypeEcnt(inFldSpa, inData, inData.Length, PokeType.DENKI,  TokuseiNo.SEIDENKI, ref outNo); // Static,        50%, Electric
            fixedType |= CheckFixTypeEcnt(inFldSpa, inData, inData.Length, PokeType.KUSA,   TokuseiNo.SYUUKAKU, ref outNo); // Harvest,       50%, Grass
            fixedType |= CheckFixTypeEcnt(inFldSpa, inData, inData.Length, PokeType.HONOO,  TokuseiNo.MORAIBI,  ref outNo); // Flash Fire,    50%, Fire
            fixedType |= CheckFixTypeEcnt(inFldSpa, inData, inData.Length, PokeType.MIZU,   TokuseiNo.YOBIMIZU, ref outNo); // Storm Drain,   50%, Water
            fixedType |= CheckFixTypeEcnt(inFldSpa, inData, inData.Length, PokeType.DENKI,  TokuseiNo.HIRAISIN, ref outNo); // Lightning Rod, 50%, Electric

            int lvl = 0;
            int slot = 0;
            switch (location)
            {
                case FISHING_ENCOUNT:
                    if (fixedType)
                        slot = 0;
                    else
                        slot = RandomPokeSetFishing(inRodType);

                    lvl = SetEncountPokeLv(inData[slot], inFldSpa);
                    break;

                case WATER_ENCOUNT:
                    if (fixedType)
                        slot = 0;
                    else
                        slot = RandomPokeSetNoGround();

                    lvl = SetEncountPokeLv(inData[slot], inFldSpa);
                    break;

                case GROUND_ENCOUNT:
                    if (fixedType)
                        slot = 0;
                    else
                        slot = RandomPokeSet();

                    slot = GetMaxLvMonsTblNo(inData, inFldSpa, slot);
                    lvl = inData[slot].maxlv;
                    break;
            }

            if (!inFldSpa.Egg && !inFldSpa.EncCancelSpInvalid)
            {
                // Keen Eye, Intimidate
                if (inFldSpa.Spa == TokuseiNo.SURUDOIME || inFldSpa.Spa == TokuseiNo.IKAKU)
                {
                    var paramLvl = param.GetLevel();
                    if (paramLvl > 5 && lvl <= (paramLvl - 5) && RandomGroupWork.RandomValue(2) == 0)
                        return false;
                }
            }

            if (inFldSpa.SprayCheck && inFldSpa.SpMyLv > lvl)
                return false;

            SetEncountDataDecideMons(inData[slot].monsNo, (uint)lvl, inTarget, false, inFldSpa, param, ref outBattleParam);

            return true;
        }

        private static bool SetEncountDataDecideMons(MonsNo inMonsNo, uint inLv, BTL_CLIENT_ID inTarget, bool inRare, ENC_FLD_SPA inFldSpa, PokemonParam param, ref EncountResult outBattleParam)
        {
            if (inRare)
                EncountParamSetRare(inMonsNo, (int)inLv, inTarget, inFldSpa, param, ref outBattleParam);
            else
                EncountParamSet(inMonsNo, (int)inLv, inTarget, inFldSpa, param, ref outBattleParam);

            return true;
        }

        // TODO
        private static bool SetSwayEncountData(PokemonParam param, ENC_FLD_SPA inFldSpa, MonsLv[] inData, BTL_CLIENT_ID inTarget, ref EncountResult outBattleParam, MonsNo inMonsNo, uint inLv) { return false; }

        private static bool CheckFixTypeEcnt(ENC_FLD_SPA inFldSpa, MonsLv[] inData, int inListNum, PokeType type, TokuseiNo tokusei, ref int outNo)
        {
            if (!inFldSpa.Egg && inFldSpa.Spa == tokusei && RandomGroupWork.RandomValue(2) == 0)
                return FixPokeSet(inData, inListNum, type, ref outNo);

            return false;
        }

        // TODO
        private static bool FixPokeSet(MonsLv[] inData, int inListNum, PokeType type, ref int outNo) { return false; }

        private static int SetEncountPokeLv(MonsLv inData, ENC_FLD_SPA inFldSpa)
        {
            var egg = inFldSpa.Egg;
            var minLv = inData.minlv;
            var maxLv = inData.maxlv;
            var tokusei = inFldSpa.Spa;

            if (minLv > maxLv)
            {
                minLv = maxLv;
                maxLv = minLv;
            }

            var diffLv = maxLv - minLv + 1;

            var roll = RandomGroupWork.RandomValue(10000) % diffLv;

            // Pressure, Hustle, Vital Spirit, 50%
            if (!inFldSpa.Egg &&
                (inFldSpa.Spa == TokuseiNo.PURESSYAA ||
                 inFldSpa.Spa == TokuseiNo.HARIKIRI ||
                 inFldSpa.Spa == TokuseiNo.YARUKI))
            {
                if (RandomGroupWork.RandomValue(2) == 0)
                    return minLv + roll;
                else
                    return maxLv;
            }

            return minLv + roll;
        }

        // TODO
        private static void EncountParamSetRare(MonsNo poke, int lv, BTL_CLIENT_ID inTarget, ENC_FLD_SPA inFldSpa, PokemonParam inPokeParam, ref EncountResult outBattleParam) { }

        // TODO
        private static void EncountParamSet(MonsNo poke, int lv, BTL_CLIENT_ID inTarget, ENC_FLD_SPA inFldSpa, PokemonParam inPokeParam, ref EncountResult outBattleParam) { }

        // TODO
        private static void LastTokuseiCheck(ref EncountResult result, ref ENC_FLD_SPA spa) { }

        // TODO
        private static void LastProc(ref EncountResult result, ref ENC_FLD_SPA spa) { }

        // TODO
        private static void SetSfariMonster(bool inSafariFlg, bool inBookGet, ref MonsLv[] enc_data) { }

        // TODO
        public static MonsNo GetSafariScopeMonster(ZoneID zoneId) { return MonsNo.NULL; }

        // TODO
        private static void SafariEnc_SetSafariEnc(int inRandomSeed, bool inBookGet, ZoneID inZoneID, ref MonsLv[] outenc_data) { }

        // TODO
        private static int CheckMovePokeEnc() { return 0; }

        // TODO
        public static bool IsTairyouHassei() { return false; }

        // TODO
        public static int SafariRandomSeed() { return 0; }

        public struct ENC_FLD_SPA
        {
            public TrainerID TrainerID;
            public bool SprayCheck;
            public bool EncCancelSpInvalid;
            public int SpMyLv;
            public bool Egg;
            public TokuseiNo Spa;
            public int[] FormProb;
            public int AnnoonTblType;
        }

        public struct SWAY_ENC_INFO
        {
            public int Table;
            public bool Decide;
            public bool Enc;
        }
    }
}