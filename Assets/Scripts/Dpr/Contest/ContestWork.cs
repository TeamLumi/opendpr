using DPData;
using Dpr.BallDeco;
using Dpr.EvScript;
using Pml.PokePara;

namespace Dpr.Contest
{
    public static class ContestWork
    {
        public static EntryPlayerData[] entryPlayerDatas = null;
        public static CategoryID categoryID = CategoryID.NULL;
        public static int cassetVersion = 0;
        public static RankID rankID = RankID.NULL;
        public static ContestMode playMode = ContestMode.NULL;
        public static uint selectPartyIndex = 0;
        public static byte selectWazaIndex = 0;
        public static int selectCapsuleNumber = 0;
        public static int contestStageRank = 0;
        public static ushort playerFashion = 0;
        public static MSGSPEED sceneMsgSpeed = MSGSPEED.MSGSPEED_MAX;

        // TODO
        public static void SetResultData(ContestRewardDataModel resultDataModel) { }

        // TODO
        private static void SetSingleModeResultData(ContestRewardDataModel resultDataModel) { }

        // TODO
        private static void SetMultiModeResultData(ContestRewardDataModel resultDataModel) { }

        // TODO
        public static bool IsCassetVersionDprB() { return false; }

        // TODO
        public static int GetUserContestPoint() { return 0; }

        // TODO
        public static void SetUserContestPoint(uint newPoint) { }

        // TODO
        public static CapsuleData GetSelectCapsuleData() { return default; }

        // TODO
        public static void ApplyUserDataToEntryPlayerData(int userEntryNumber) { }

        // TODO
        public static PokemonParam GetEntryMemberPokemon(uint memberIndex) { return null; }

        private static PokemonParam CreateDummyMonster()
        {
        	var uVar1 = new PokemonParam(0x183,1,0);
        	return uVar1;
        }

        public static bool IsMultiMode { get => playMode == ContestMode.Local || playMode == ContestMode.Internet; }

        // TODO
        public static void AddRewardItem(SealID sealNo, int itemCount) { }

        // TODO
        public static int CheckContestEntry(CategoryID categoryID, RankID rankID) { return 0; }

        // TODO
        public static bool CanEntryContest(PokemonParam pokeParam, CategoryID categoryID) { return false; }

        public static bool CheckPokeStatus(PokemonParam pokeParam)
        {
        	var uVar2 = pokeParam.IsEgg(2);
        	if (uVar2) {
        	  return false;
        	}
        	var uVar1 = pokeParam.IsHpZero();
        	return ~(uVar1 ? 1 : 0) & 1;
        }

        private static bool CheckEntryFurContest(PokemonParam pokeParam)
        {
        	pokeParam.HaveRibbon(0x28);
        	return false;
        }

        // TODO
        public static bool HasValidContestWaza(PokemonParam pokeParam) { return false; }

        // TODO
        public static int FindValidWazaIndex(PokemonParam pokeParam) { return 0; }

        // TODO
        private static bool CheckRankClearFlag(CategoryID categoryID, RankID rankID) { return false; }

        // TODO
        private static bool IsClearPrevRank(CategoryID categoryID, RankID rankID) { return false; }

        // TODO
        public static void ApplyContestRecord(ContestRewardDataModel resultDataModel) { }

        // TODO
        private static void UpdateContestEntryCnt() { }

        // TODO
        private static void UpdateBestPerformerCnt() { }

        // TODO
        private static void UpdateContestClearRank() { }

        // TODO
        private static void UpdateWinRate() { }

        // TODO
        private static void UpdateGetRibbonCnt(bool hasCategoryRibbon, bool hasContestStarRibbon, bool hasTwinkleStarRibbon) { }

        // TODO
        public static void ApplyContestTVData() { }

        // TODO
        public static void ApplyReportData_MultiMode(ResultDataModel resultDataModel) { }

        public static EvWork.SYSFLAG_INDEX FindStandardContestClearFlagIndex(CategoryID categoryID, RankID rankID)
        {
        	var iVar1 = categoryID * 3 + rankID + 0x2f2;
        	if ((int)rankID == 4) {
        	  iVar1 = categoryID + 8;
        	}
        	return iVar1;
        }

        public static EvWork.SYSFLAG_INDEX FindSercretContestClearFlagIndex(RankID rankID)
        {
        	return rankID + 0x317;
        }

        // TODO
        public static void ResetContestData() { }

        // TODO
        public static void SaveContestPhotoData(CategoryID categoryID, RankID rankID, CaptureData captureData) { }

        private static void ResetPhotoFxData(ref CON_PHOTO_FX_DATA targetData)
        {
        	targetData = 0xffffffff;
        	*(targetData + 1) = 0;
        	*(targetData + 3) = 0;
        	*(targetData + 5) = 0;
        	*(targetData + 7) = 0;
        	*(targetData + 9) = 0;
        }

        // TODO
        private static void SetMonsLanguageID(CategoryID categoryID, byte langID) { }

        // TODO
        private static void SetPhotoMonsName(CategoryID categoryID, string nickname) { }
    }
}