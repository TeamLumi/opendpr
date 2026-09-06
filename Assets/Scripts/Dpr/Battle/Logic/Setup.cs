using Dpr.Trainer;
using Pml;

namespace Dpr.Battle.Logic
{
	public static class Setup
	{
		private static readonly byte[] maxFollowPokeLevelTbl = new byte[]
		{
            10, 10, 30, 30, 50, 50, 70, 70, 100,
        };
		
		// TODO
		public static void BATTLE_SETUP_FIELD_SITUATION_Init(BTL_FIELD_SITUATION sit) { }
		
		// TODO
		public static void BATTLE_PARAM_SetBtlStatusFlag(BATTLE_SETUP_PARAM bp, BTL_STATUS_FLAG status_f) { }
		
		// TODO
		public static void BATTLE_PARAM_ResetBtlStatusFlag(BATTLE_SETUP_PARAM bp, BTL_STATUS_FLAG status_f) { }
		
		// TODO
		public static bool BATTLE_PARAM_CheckBtlStatusFlag(BATTLE_SETUP_PARAM bp, BTL_STATUS_FLAG status_f) { return default; }
		
		// TODO
		private static void BATTLE_SETUP_Init(BATTLE_SETUP_PARAM bp) { }
		
		// TODO
		public static void BATTLE_SETUP_Clear(BATTLE_SETUP_PARAM bp) { }
		
		// TODO
		public static void BATTLE_SETUP_Wild(BATTLE_SETUP_PARAM bp, PokeParty playerParty, PokeParty partyEnemy, TrainerID partnerTrainerID, BTL_FIELD_SITUATION sit, BtlRule rule) { }
		
		// TODO
		public static void BATTLE_SETUP_Wild(BATTLE_SETUP_PARAM bp, PokeParty playerParty, PokeParty partyEnemy, BTL_FIELD_SITUATION sit, BtlRule rule) { }
		
		// TODO
		public static void BATTLE_SETUP_DemoCapture(BATTLE_SETUP_PARAM bp, PokeParty playerParty, PokeParty partyEnemy, TrainerID trainerID, BTL_FIELD_SITUATION sit) { }
		
		// TODO
		private static void setBoxFull(BATTLE_SETUP_PARAM pSetupParam) { }
		
		// TODO
		private static bool checkBoxFull() { return default; }
		
		// TODO
		public static void BTL_SETUP_Trainer(BATTLE_SETUP_PARAM bp, PokeParty playerParty, TrainerID trID, BTL_FIELD_SITUATION sit, BtlRule rule) { }
		
		// TODO
		public static void BTL_SETUP_Trainer_Tag(BATTLE_SETUP_PARAM bp, in PokeParty playerParty, TrainerID trID_1, TrainerID trID_2, BTL_FIELD_SITUATION sit, BtlRule rule) { }
		
		// TODO
		public static void BTL_SETUP_Trainer_Multi(BATTLE_SETUP_PARAM bp, in PokeParty playerParty, TrainerID trID_friend, TrainerID trID_1, TrainerID trID_2, BTL_FIELD_SITUATION sit, BtlRule rule) { }
		
		// TODO
		public static void BATTLE_SETUP_Comm(BATTLE_SETUP_PARAM bp, in PokeParty playerParty, BTL_FIELD_SITUATION sit, BtlCommMode commMode, byte commPos) { }
		
		// TODO
		public static void BATTLE_SETUP_ToMultiMode(BATTLE_SETUP_PARAM bp) { }
		
		// TODO
		public static void BATTLE_SETUP_ToAIMultiMode(BATTLE_SETUP_PARAM bp, TrainerID trid_enemy1, TrainerID trid_enemy2, BtlCompetitor competitor) { }
		
		// TODO
		private static void setupParty(BATTLE_SETUP_PARAM pSetupParam, BTL_CLIENT_ID clientID, PokeParty pParty) { }
		
		// TODO
		public static void BATTLE_PARAM_SetTimeLimit(BATTLE_SETUP_PARAM bsp, uint GameLimitSec, uint ClientLimitSec, uint CommandLimitSec) { }
		
		// TODO
		public static void BATTLE_PARAM_SetSkyBattle(BATTLE_SETUP_PARAM bsp) { }
		
		// TODO
		public static void BATTLE_PARAM_SetSakasaBattle(BATTLE_SETUP_PARAM bsp) { }
		
		// TODO
		public static void BATTLE_PARAM_SetMustCaptureMode(BATTLE_SETUP_PARAM bsp) { }
		
		// TODO
		private static void BATTLE_PARAM_SetNoGainMode(BATTLE_SETUP_PARAM bsp) { }
		
		// TODO
		private static void BATTLE_PARAM_SetMoneyRate(BATTLE_SETUP_PARAM bsp, float rate) { }
		
		// TODO
		private static void BATTLE_PARAM_SetPokeParty(BATTLE_SETUP_PARAM bsp, PokeParty party, BTL_CLIENT_ID id) { }
		
		// TODO
		public static void BATTLE_PARAM_SetRegulation(BATTLE_SETUP_PARAM bsp, in Regulation.Data regulation) { }
		
		// TODO
		private static void BATTLE_PARAM_SetRatingValue(BATTLE_SETUP_PARAM bsp, ushort rate1, ushort rate2) { }
		
		// TODO
		public static void BATTLE_PARAM_AllocRecBuffer(BATTLE_SETUP_PARAM bsp) { }
		
		// TODO
		private static uint getBattleInstTrainerAIBit(BtlRule rule) { return default; }
		
		// TODO
		public static void BTL_SETUP_BattleInst(BATTLE_SETUP_PARAM pSetupParam, PokeParty pPlayerParty, TowerTrID instTrainerEnemy1, PokeParty instEnemy1Party, SealTemplateID[] instEnemy1SealTIDs, TowerTrID instTrainerEnemy2, PokeParty instEnemy2Party, SealTemplateID[] instEnemy2SealTIDs, BTL_FIELD_SITUATION pFieldSituation, BtlRule rule) { }
		
		// TODO
		private static void BTL_SETUP_VoiceChatOn(BATTLE_SETUP_PARAM bp) { }
		
		// TODO
		private static void BATTLE_PARAM_AddWildPokemonAi(BATTLE_SETUP_PARAM pSetupParam, BtlAiScriptNo scriptNo) { }
		
		// TODO
		private static void common_base(BATTLE_SETUP_PARAM dst, BTL_FIELD_SITUATION sit) { }
		
		// TODO
		private static byte GetMaxFollowPokeLevel() { return default; }
		
		private static byte GetCaptureLevelCap() {
		    return 0x64;
		}
		
		// TODO
		private static byte GetExpLevelCap() { return default; }
		
		// TODO
		private static void BATTLE_SETUP_PARAM_InitPartyParam(BATTLE_SETUP_PARAM setupParam) { }
		
		// TODO
		private static void player_param(BATTLE_SETUP_PARAM dst, PokeParty party) { }
		
		// TODO
		private static void clearEgg(PokeParty party) { }
		
		// TODO
		private static void player_balldeco(BATTLE_SETUP_PARAM dst, PokeParty party) { }
		
		// TODO
		public static void normalTrainer(BATTLE_SETUP_PARAM dst, BTL_CLIENT_ID clientID, TrainerID tr_id) { }
		
		// TODO
		public static void instTrainer(BATTLE_SETUP_PARAM dst, BTL_CLIENT_ID clientID, TowerTrID trainerID, PokeParty trainerParty, SealTemplateID[] sealTIDs, BtlRule rule) { }
		
		// TODO
		public static void settingByTrainerData(BATTLE_SETUP_PARAM bp, in BSP_TRAINER_DATA trData) { }
	}
}