using Dpr.BallDeco;
using Dpr.Battle.View;
using Dpr.Trainer;
using Pml;
using UnityEngine;
using XLSXContent;

namespace Dpr.Contest
{
	public static class ContestUtils
	{
		// TODO
		public static string CreateTrainerModelPath(int playerFashion) { return default; }
		
		public static TrainerType CreateTrainerType(bool isOwner, Sex playerSex)
		{
			if (isOwner) {
			  var uVar1 = 100;
			  if ((int)playerSex != 0) {
			    uVar1 = 0x65;
			  }
			  return uVar1;
			}
			return (int)playerSex != 0;
		}
		
		// TODO
		public static TrainerSimpleParam CreateTrainerSimpleParam(TrainerType trainerType, int colorID) { return default; }
		
		// TODO
		public static ContestMasterDatas.SheetRankData FindRankData(int rankPoint, ContestMasterDatas contestMasterDatas) { return default; }
		
		// TODO
		public static CategoryID LotteryCategory(bool isDpClear) { return default; }
		
		// TODO
		public static CategoryID[] GetCanEntryCategory(bool isDpClear) { return default; }
		
		// TODO
		public static RankID LotteryCategory(CategoryID categoryID) { return default; }
		
		// TODO
		public static RankID[] GetRankIDsByCategoryID(CategoryID categoryID) { return default; }
		
		// TODO
		public static string CreateWazaSequencePath(MonsNo monsNo, WazaNo wazaNo, int formNo, PokeType type1, PokeType type2) { return default; }
		
		public static bool CheckUniqueWaza(MonsNo monsNo, WazaNo wazaNo, int formNo, PokeType type1, PokeType type2)
		{
			if ((int)wazaNo < 0xb2) {
			  if ((int)wazaNo == 0xae) {
			    if ((type1 != '\a') && (type2 != '\a')) {
			      return false;
			    }
			    return true;
			  }
			  if ((int)wazaNo != 0xb1) {
			    return false;
			  }
			  if ((int)monsNo != 0xf9) {
			    return false;
			  }
			}
			else if ((int)wazaNo == 0x1cb) {
			  if ((int)monsNo != 0x1e3) {
			    return false;
			  }
			}
			else if ((int)wazaNo == 0x1cc) {
			  if ((int)monsNo != 0x1e4) {
			    return false;
			  }
			}
			else {
			  if ((int)wazaNo != 0x26c) {
			    return false;
			  }
			  if ((int)monsNo != 0x180) {
			    return false;
			  }
			}
			if (formNo != 0) {
			  return false;
			}
			return true;
		}
		
		// TODO
		public static ArenaInfo.SheetArenaData FindArenaDataByID(ArenaID arenaID) { return default; }
		
		// TODO
		public static LotteryNPCData[] CreateLoatteryNPCDataByCategoryAndRank(ContestMasterDatas.SheetNPCData[] NPCData, CategoryID categoryID, RankID rankID, int createNum) { return default; }
		
		// TODO
		private static ContestMasterDatas.SheetNPCData[] ChoiceRandomNPCPlayerData(int choiceNum, ContestMasterDatas.SheetNPCData[] npcDatas) { return default; }
		
		// TODO
		private static int[] CreateShuffledIndexArray(int arrayLength) { return default; }
		
		// TODO
		public static WazaNo LotNPCUseWazaNo(ContestMasterDatas.SheetNPCData npcData) { return default; }
		
		// TODO
		public static BtlvBallInfo CreatePlayerBallInfo(BallId ballId) { return default; }
		
		// TODO
		public static AffixSealData[] CreateNPCAffixSealDataArray(ContestMasterDatas.SheetNPCCapsuleData npcCapsuleData) { return default; }
		
		// TODO
		private static AffixSealData CreateAffixSealData(SealID sealID, Vector3 pos) { return default; }
		
		// TODO
		public static string CreateNumberIconSprName(int number) { return default; }
		
		// TODO
		public static string GetCategoryLabelByID(CategoryID categoryID) { return default; }
		
		// TODO
		public static string GetCategoryLabelByID(CategoryID categoryID, int cassetVersion) { return default; }
		
		// TODO
		public static string GetCategoryLabelByID(int categoryID) { return default; }
		
		// TODO
		public static string GetCategoryLabelByID(int categoryID, int cassetVersion) { return default; }
		
		// TODO
		public static string GetCategoryNameByID(CategoryID categoryID) { return default; }
		
		// TODO
		public static string GetCategoryNameByID(CategoryID categoryID, int cassetVersion) { return default; }
		
		// TODO
		public static string GetCategoryNameByID(int categoryID, int cassetVersion) { return default; }
		
		// TODO
		public static string GetRankLabelByID(RankID rankID) { return default; }
		
		// TODO
		public static string GetRankLabelByID(int rankID) { return default; }
		
		// TODO
		public static string GetRankNameByID(RankID rankID) { return default; }
		
		// TODO
		public static string GetRankNameByID(int rankID) { return default; }
		
		// TODO
		public static void EmitLog(string log, LogType logType = LogType.Log) { }
	}
}