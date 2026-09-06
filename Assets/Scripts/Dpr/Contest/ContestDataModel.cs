using Dpr.BallDeco;
using Dpr.Battle.View;
using Dpr.Message;
using Dpr.SequenceEditor;
using Pml;
using Pml.PokePara;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XLSXContent;

namespace Dpr.Contest
{
	public class ContestDataModel
	{
		private ContestRewardDataModel contestResultDataModel = new ContestRewardDataModel();
		private ResultDataModel resultData = new ResultDataModel();
		private MessageMsgFile wazaNameMsgFile;
		private MessageMsgFile nameMsgFile;
		private ArenaInfo.SheetArenaData currentArenaData;
		private CaptureData mainCaptureData = new CaptureData();
		private CaptureData wazaCaptureData = new CaptureData();
		private ShadowResolution backupShadowResolution;
		private Sprite contestTitleSpr;
		private Sprite contestCategorySpr;
		private Sprite contestRankSpr;
		private int captureCommandNum;
		private int maxCaptureCommandNum;
		private int userContestPoint;
		private int userIndex;

		private const int INIT_CAPACITY = 32;

		private Dictionary<int, ContestMasterDatas.SheetNPCCapsuleData> npcCapsuleTable = new Dictionary<int, ContestMasterDatas.SheetNPCCapsuleData>();
		private Dictionary<int, ContestMasterDatas.SheetSealData> sealDataTable = new Dictionary<int, ContestMasterDatas.SheetSealData>();
		private Dictionary<int, ContestMasterDatas.SheetItemData> itemDataTable = new Dictionary<int, ContestMasterDatas.SheetItemData>();
		private ContestMasterDatas contestMasterDatas;
		private ContestConfigDatas contestConfigDatas;
		private ContestMasterDatas.SheetContestData useContestData;
		private ContestMasterDatas.SheetBgmData useBgmData;
		private ContestMasterDatas.SheetRewardData useRewardData;
		private DanceSectionData danceSectionData;
		private StringBuilder categoryTexNameSb = new StringBuilder(INIT_CAPACITY);
		private StringBuilder useNotesDataFilePathSb = new StringBuilder(INIT_CAPACITY);
        private StringBuilder useSequenceFilePathSb = new StringBuilder(INIT_CAPACITY);
        private uint mainBgmEventID;
		private uint userContestRank;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void UnloadResource() { }
		
		// TODO
		public void UnloadAssetBundle() { }
		
		public CategoryID ContestCategoryID { get => IsTutorial ? CategoryID.Style : (CategoryID)useContestData.category; }
		public bool IsTutorial { get => (CategoryID)useContestData.category == CategoryID.Tutorial; }
		
		// TODO
		public void SetContestMasterData(Object asset) { }
		
		// TODO
		public void FormatMasterData() { }
		
		// TODO
		private void SettingContestMDRef() { }
		
		// TODO
		private string GetTutorialSeName(bool isDprB) { return default; }
		
		// TODO
		public string GetStringData(int dataID) { return default; }
		
		// TODO
		public int GetValueData(int dataID) { return default; }
		
		public ContestConfigDatas GetConfigData() {
		    return contestConfigDatas;
		}
		
		// TODO
		public Vector3 CreateInitMainCameraDofTargetPos() { return default; }
		
		// TODO
		public Vector3 CreateInitWazaCameraDofTargetPos() { return default; }
		
		// TODO
		public string GetMusicFilePath() { return default; }
		
		// TODO
		public string GetSequenceFilePath() { return default; }
		
		public DanceSectionData GetDanceSectionData() {
		    return danceSectionData;
		}
		
		public uint GetMainBgmEventID() {
		    return mainBgmEventID;
		}
		
		// TODO
		public string GetStagePath() { return default; }
		
		// TODO
		public EnvironmentSettings GetStageRenderSetting() { return default; }
		
		// TODO
		public Sprite GetContestTitleSpr() { return default; }
		
		// TODO
		public Sprite GetCategorySpr() { return default; }
		
		// TODO
		public string GetMedalTexturePath() { return default; }
		
		// TODO
		public Sprite GetRankSpr() { return default; }
		
		// TODO
		public Sprite GetProgressIconSpr() { return default; }
		
		// TODO
		public string CreateUIPlayerNumFileName(int number) { return default; }
		
		// TODO
		public string CreateUIPlayerPlateFileName(int number) { return default; }
		
		// TODO
		public void SetQuaritySettings() { }
		
		// TODO
		public void ResetQuaritySettings() { }
		
		// TODO
		public MonsNo GetPlayerMonsNo() { return default; }
		
		// TODO
		public WazaNo GetPlayerWazaNo() { return default; }
		
		// TODO
		public int GetPlayerFormNo() { return default; }
		
		// TODO
		public PokeType GetPlayerPokeType1() { return default; }
		
		// TODO
		public PokeType GetPlayerPokeType2() { return default; }
		
		public uint GetUserRank() {
		    return userContestRank;
		}
		
		// TODO
		public AContestPlayerData[] CreateContestEntryPlayerDataArray() { return default; }
		
		// TODO
		private void CreateSingleModeNPCDatas() { }
		
		// TODO
		private void SetPlayerCommonParam(AContestPlayerData playerData, EntryPlayerData entryPlayerData) { }
		
		// TODO
		private ContestUserData CreateUserPlayerData(int entryNumber, EntryPlayerData entryPlayerData) { return default; }
		
		// TODO
		private ContestNPCData CreateNPCPlayerData(int entryNumber, EntryPlayerData entryPlayerData) { return default; }
		
		// TODO
		private int GetNPCVisualScore(ContestMasterDatas.SheetNPCData data) { return default; }
		
		// TODO
		private BtlvBallInfo CreateNPCBallInfo(ContestMasterDatas.SheetNPCCapsuleData npcCapsuleData) { return default; }
		
		// TODO
		public ContestOtherUserData CreateOtherPlayerData(int entryNumber, EntryPlayerData entryPlayerData) { return default; }
		
		// TODO
		private PokemonInfo CreatePokemonInfo(EntryPlayerData entryPlayerData) { return default; }
		
		// TODO
		private string CreatePokeModelPath(string pokeAssetBundleName) { return default; }
		
		// TODO
		private int CalcVisualScore(CoreParam pokeParam, bool isPlayer) { return default; }
		
		// TODO
		private float CalcConditionScore(byte conditionValue, int compatibility) { return default; }
		
		// TODO
		private ContestMasterDatas.SheetConditionScoreData FindConditionDataByParameter(int parameter) { return default; }
		
		// TODO
		private int CalcVisualScoreByCapsuleData(AffixSealData[] affixSealData) { return default; }
		
		// TODO
		private int CalcItemScore(int itemNo) { return default; }
		
		// TODO
		public void SetSkillAnimDuration(float seqMaxTime) { }
		
		// TODO
		private AContestSkillBase CreateContestSkill(uint contestSkillID, PokeType wazaType, AContestPlayerData playerData) { return default; }
		
		// TODO
		public EffectContestID[] CreateMonitorIDs() { return default; }
		
		// TODO
		public void OnFindCaptureCommand(ContestViewSystem targetViewSystem) { }
		
		// TODO
		public void OnPerformCaptureCommand(ContestViewSystem targetViewSystem, Macro macro) { }
		
		// TODO
		private void SetWazaEffectData(CaptureData targetData) { }
		
		// TODO
		private void SetCaptureData(CaptureData target) { }
		
		// TODO
		private int GetCaptureCommandFrame(CaptureData target) { return default; }
		
		// TODO
		private bool CheckCaptureProbability(int persent) { return default; }
		
		// TODO
		public ContestConfigDatas.SheetTapScoreData[] GetScoreDataArray() { return default; }
		
		// TODO
		public ContestConfigDatas.SheetTapTimingData[] GetTapTimingDataArray() { return default; }
		
		// TODO
		public float GetValidTapTimeRange() { return default; }
		
		// TODO
		public ContestConfigDatas.SheetComboBonusData[] GetComboBonusDataArray() { return default; }
		
		// TODO
		public void SetNotesData(NotesInfo notesData) { }
		
		// TODO
		private bool IsCaptureContest() { return default; }
		
		// TODO
		public ResultID CalcContestResult() { return default; }
		
		// TODO
		public ResultDataModel CreateModeResultData(ResultID resultID) { return default; }
		
		// TODO
		private ContestConfigDatas.SheetResultCameraTween GetResultCameraParam() { return default; }
		
		// TODO
		private ContestConfigDatas.SheetResultMotion GetResultMotionData() { return default; }
		
		// TODO
		private ResultPlayerDataModel[] CreateResultPlayerData() { return default; }
		
		// TODO
		private int FindTopScore(ContestPlayerEntity[] entities) { return default; }
		
		// TODO
		private void SetResultVoiceData(bool isUserWin) { }
		
		// TODO
		public void CreateMultiModeResultData(int result) { }
		
		// TODO
		public void OnFinishedContest() { }
		
		// TODO
		private void ApplyResultDataIntoPlayerWork() { }
		
		// TODO
		private void ApplyContestRewardData() { }
		
		// TODO
		private void CheckClearContestFlag() { }
		
		// TODO
		private void CheckContestReward(PokemonParam targetPokeParam) { }
		
		// TODO
		private void CheckRewardItem() { }
		
		// TODO
		private ContestMasterDatas.SheetRewardItemData FindRewardItemData() { return default; }
		
		// TODO
		private void CheckRewardCategoryRibbon(PokemonParam targetPokeParam) { }
		
		// TODO
		private void CheckRewardClearAllMasterRank(PokemonParam targetPokeParam) { }
		
		// TODO
		private bool IsAllMasterRankClear(PokemonParam targetPokeParam) { return default; }
		
		// TODO
		private void CheckMasterContestReward(PokemonParam targetPokeParam) { }
		
		// TODO
		private void CheckCaptureData() { }
		
		// TODO
		private void PerformSaveCaptureData(CaptureData targetData) { }
		
		// TODO
		public void ChangeTutorialSecondPlayData() { }
		
		// TODO
		public float GetSyncScoreSpan() { return default; }
	}
}