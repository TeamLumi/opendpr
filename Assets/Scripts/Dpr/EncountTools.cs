using Pml.PokePara;
using Pml;
using AttributeData;
using DPData;
using Dpr.Battle.Logic;
using Dpr.Trainer;
using System.Collections;
using System.Runtime.InteropServices;
using Dpr.BallDeco;
using INL1;

namespace Dpr
{
    public static class EncountTools
    {
        private static bool m_isIgnorePokeReflectAfterBattle;

        // TODO
        public static PokeParty CreateSimpleParty(MonsNo monsNo0, int level0, [Optional, DefaultParameterValue(MonsNo.NULL)] MonsNo monsNo1, [Optional, DefaultParameterValue(1)] int level1, [Optional] PokeParty party, ushort sex = 255, ushort seikaku = 65535, ushort sex1 = 255, ushort seikaku1 = 65535, ushort form0 = 0, ushort form1 = 0, byte talentVNum = 0) { return null; }

        //TODO
        public static ItemNo SetWildPokemonItem(PokemonParam pp, int itemRnd, int rnd1 = 50, int rnd2 = 5) { return ItemNo.DUMMY_DATA; }

        // TODO
        public static void SetupBattleWild(BATTLE_SETUP_PARAM battleSetupParam, PokeParty iPtrEnemyParty, ArenaID arenaID, MapAttributeEx mapAttrib, SYS_WEATHER weatherType, [Optional, DefaultParameterValue(false)] bool isSwim, [Optional, DefaultParameterValue(false)] bool isFishing, [Optional, DefaultParameterValue(TrainerID.NONE)] TrainerID partnerID, [Optional, DefaultParameterValue(false)] bool isCaptureDemo, [Optional, DefaultParameterValue(-1)] int safariBallNum, [Optional, DefaultParameterValue(false)] bool isSymbol, [Optional, DefaultParameterValue(false)] bool isMitu, [Optional] string overlapBgm, BattleSetupEffectId overlapSetupEffectId = BattleSetupEffectId.DEFAULT, bool isCantUseBall = false) { }

        // TODO
        private static bool IsUseSetupEffectVariation(PokeParty party) { return false; }

        // TODO
        public static void SetupBattleTrainer(BATTLE_SETUP_PARAM battleSetupParam, ArenaID arenaID, MapAttributeEx mapAttrib, SYS_WEATHER weatherType, BtlRule rule, TrainerID enemyID0, TrainerID enemyID1 = TrainerID.NONE, TrainerID partnerID = TrainerID.NONE) { }

        // TODO
        public static void SetupBattleTowerTrainer(BATTLE_SETUP_PARAM battleSetupParam, PokeParty playerParty, BtlRule rule, ArenaID arenaID, SYS_WEATHER weatherType, TowerTrID enemy1, PokeParty enemy1Party, SealTemplateID[] enemy1SealTIDs, [Optional, DefaultParameterValue(TowerTrID.NONE)] TowerTrID enemy2, [Optional] PokeParty enemy2Party, [Optional] SealTemplateID[] enemy2SealTIDs, [Optional] TowerLotResult lotResult) { }

        // TODO
        public static void SetupBattleTowerTrainer(BATTLE_SETUP_PARAM battleSetupParam, PokeParty playerParty, TowerLotResult lot, ArenaID arenaID, SYS_WEATHER weatherType, [Optional] TowerLotResult lotResult) { }

        // TODO
        public static void GetTrainerExParams(TrainerID enemyID0, TrainerID enemyID1, TrainerID partnerId, BtlRule rule, out ArenaID trainerArenaID, out BattleSetupEffectId trainerSetupEffectId, out EffectBattleID trainerEffectBattleId)
        {
            trainerArenaID = ArenaID.UNKNOWN;
            trainerSetupEffectId = BattleSetupEffectId.NONE;
            trainerEffectBattleId = EffectBattleID.NONE;
        }

        // TODO
        public static void SetWeather(BTL_FIELD_SITUATION situation, SYS_WEATHER weatherType) { }

        // TODO
        public static void OnPostBattle(BATTLE_SETUP_PARAM bsp, PokeParty iPtrPlayerParty, out int outEvolveCheckTargetIndices, out IEnumerator outDispError)
        {
            outEvolveCheckTargetIndices = 0;
            outDispError = null;
        }

        // TODO
        public static void OnPostRegisterZukan(PokemonParam capturePokemonParam, int throwBallCount) { }

        // TODO
        private static int GetPokemonParamIndex(PokeParty party, PokemonParam org) { return 0; }

        // TODO
        private static void SetTrainerWinFlag(BATTLE_SETUP_PARAM bsp) { }

        // TODO
        private static void ReflectTokuseiMonohiroiMitsuatsume(PokeParty pMyParty) { }

        private static bool isEvolveCheckTarget(PokeParty playerParty, byte memberIdx, BtlResult result, bool isLevelUp)
        {
        	var uVar1 = playerParty.GetMemberPointerConst(memberIdx);
        	uVar1.GetMonsNo();
        	uVar1.GetFormNo();
        	return (isLevelUp ? 1 : 0) & 1;
        }

        // TODO
        public static void GetAttEff(MapAttributeEx mapAttributeEx, ArenaID arenaID, BattleSetupEffectLot lot, out BattleSetupEffectId setupEffectId, out EffectBattleID effectBattleID, out string soundEventNama)
        {
            setupEffectId = BattleSetupEffectId.NONE;
            effectBattleID = EffectBattleID.NONE;
            soundEventNama = null;
        }

        // TODO
        public static BattleSetupEffectLot GetBattleSetupEffectLot(BtlRule rule, BtlCompetitor competitor = 0, BtlMultiMode multiMode = 0, TrainerID trainerID0 = TrainerID.MAX, TrainerID trainerID1 = TrainerID.MAX) { return BattleSetupEffectLot.WILD_SINGLE; }

        public static TrainerID GetDemoCaptureTrainer(bool isPlayerMale, DefaultPokeType defaultPokeType)
        {
        	uint uVar1;
        	if ((int)defaultPokeType == 10) {
        	  uVar1 = 0x1eb;
        	  if (!isPlayerMale) {
        	    uVar1 = 0x1e8;
        	  }
        	  return uVar1;
        	}
        	if ((int)defaultPokeType == 0xb) {
        	  uVar1 = 0x1ec;
        	  if (!isPlayerMale) {
        	    uVar1 = 0x1e9;
        	  }
        	  return uVar1;
        	}
        	uVar1 = 0x1ea;
        	if (!isPlayerMale) {
        	  uVar1 = 0x1e7;
        	}
        	return uVar1;
        }

        // TODO
        public static PokeParty CreateDemoCapturePokeParty(TrainerID trainerID) { return null; }

        // TODO
        private static ItemNo GetMonohiroiItem(uint level) { return ItemNo.DUMMY_DATA; }

        // TODO
        public static PokemonParam CreateFixPokeParam(MonsNo monsNo, ushort level, uint hp, ushort sex, ushort seikaku, Sick sick, ulong random, byte talentVNum) { return null; }

        // TODO
        private static bool IsLegendPoke(MonsNo monsNo) { return false; }

        // TODO
        private static bool IsRecoverFromPartner(BATTLE_SETUP_PARAM bsp) { return false; }

        // TODO
        public static void SetupBattleComm(BATTLE_SETUP_PARAM bsp, IlcaNetSessionNetworkType networkType, CommRule commRule, byte commPos, in Regulation.Data regulation, int stationIndex0, PokeParty party0, in MYSTATUS_COMM mystatus0, CapsuleData[] capsuleDatas0, int stationIndex1, PokeParty party1, in MYSTATUS_COMM mystatus1, CapsuleData[] capsuleDatas1, [Optional, DefaultParameterValue(-1)] int stationIndex2, [Optional] PokeParty party2, [Optional] in MYSTATUS_COMM mystatus2, [Optional] CapsuleData[] capsuleDatas2, [Optional, DefaultParameterValue(-1)] int stationIndex3, [Optional] PokeParty party3, [Optional] in MYSTATUS_COMM mystatus3, [Optional] CapsuleData[] capsuleDatas3, [Optional] string bgm, [Optional] string winBgm, uint GameLimitSec = 1200, uint CommandLimitSec = 60) { }

        // TODO
        private static void setupPlayerInfo(BATTLE_SETUP_PARAM bsp, int index, int stationIndex, PokeParty party, in MYSTATUS_COMM mystatus, CapsuleData[] capsuledata) { }

        // TODO
        public static IEnumerator DispErrorCoroutine(int commError, bool isDisplayedError) { return null; }

        public enum CommRule : int
        {
            Single = 0,
            Double = 1,
            Multi = 2,
            Mix = 3,
        }
    }
}