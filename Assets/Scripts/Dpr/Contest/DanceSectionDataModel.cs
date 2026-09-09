using System;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.Contest
{
	public class DanceSectionDataModel
	{
		private const float ONE_MINUTE = 60.0f;

		private SceneObjectManager objManager;
		private PlayerDanceDataModel[] playerDataArray;
		private PlayerDanceDataModel userDataModel;
		private Dictionary<int, TensionData> tensionTable = new Dictionary<int, TensionData>();
		private List<NotesDataModel> currentNoteDataList = new List<NotesDataModel>();
		private CollectNotesDataModel collectNotesDataModel = new CollectNotesDataModel();
		private Vector2 notesSpan = Vector2.zero;
		private int currentDataIndex;
		private int musicBpm;
		private Dictionary<int, float> tapTimingTable = new Dictionary<int, float>();
		private Dictionary<int, float> longTapTimeSpanTable = new Dictionary<int, float>();
		private TapResultData tapResultData = new TapResultData();
		private NoteIcon longStartNote;
		private float totalSec;
		private float startElapsedTime;
		private float endTapSec;
		private Dictionary<int, int[]> scoreTable = new Dictionary<int, int[]>();
		private SkillComboData[] comboBonusDataArray;
		private ApplyScoreResult applyScoreResult = new ApplyScoreResult();
		private int maxScore;
		private int totalVisualScore;
		private int totalScore;
		private int checkStackHeartNum;
		private float successScoreRatio;
		private ComboBonusDataModel comboBonus;
		private double launchSkillElapsedTime;
		private float skillChainDuration;
		private float downVolumePersent;
		private int chainCount;
		private int lastUsePlayerIndex = -1;
		private bool canUpdateChain;
		private NotesDataModel lastNoteData;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void SetDanceSectionData(DanceSectionData danceSectionData) { }
		
		// TODO
		private void CreateNoteDataList(DanceSectionData danceSectionData) { }
		
		// TODO
		private void SetNotesSpan() { }
		
		// TODO
		public void ResetParam(DanceSectionData danceSectionData) { }
		
		// TODO
		public void CreateGameParameterFromContestDataModel(ContestDataModel contestDataModel) { }
		
		// TODO
		private void CreateTapScoreTable(ContestConfigDatas.SheetTapScoreData[] scoreDataArray) { }
		
		// TODO
		private void CreateTapTimingData(ContestConfigDatas.SheetTapTimingData[] taimingDataArray) { }
		
		// TODO
		private void CreateChangeTensionDataTable(ContestConfigDatas.SheetTapScoreData[] scoreDataArray) { }
		
		// TODO
		private void CreateComboBonusData(ContestConfigDatas.SheetComboBonusData[] bonusDataArray) { }
		
		public PlayerDanceDataModel GetUserDanceData() {
		    return userDataModel;
		}
		
		// TODO
		public PlayerDanceDataModel GetPlayerDanceDataByIndex(int index) { return default; }
		
		// TODO
		public bool CanEmitHeartByPlayerIndex(int playerIndex) { return default; }
		
		// TODO
		public DanceUser CreatePlayer(int index, ContestPlayerEntity entity, Action<ADancePlayer> onLockSkill) { return default; }
		
		// TODO
		public DanceNPC CreateNPC(int index, ContestPlayerEntity entity, Action<ADancePlayer> onLockSkill) { return default; }
		
		// TODO
		public DanceOtherUser CreateOtherUser(int index, ContestPlayerEntity entity, Action<ADancePlayer> onLockSkill) { return default; }
		
		// TODO
		private void SetPlayerData(int index, PlayerDanceDataModel playerData) { }
		
		// TODO
		private TensionData GetTensionDataByID(TensionID tensionID) { return default; }
		
		// TODO
		public TapResultData UpdatePlayerDataByTimingID(NoteTapTimingID timingId) { return default; }
		
		// TODO
		public TapResultData UpdatePlayerDataByTimingID(int playerIndex, NoteTapTimingID timingId) { return default; }
		
		// TODO
		public TapResultData UpdatePlayerDataByTimingID(PlayerDanceDataModel danceDataModel, NoteTapTimingID timingId) { return default; }
		
		// TODO
		private void UpdatePlayerTensionByTimingID(PlayerDanceDataModel playerData, NoteTapTimingID timingId) { }
		
		// TODO
		private void UpdateHeartGauge(PlayerDanceDataModel playerData, NoteTapTimingID timingId) { }
		
		// TODO
		private int GetHeartGaugeScore(TensionID tensionID, NoteTapTimingID timingID) { return default; }
		
		// TODO
		public float GetHeartGaugeRatio() { return default; }
		
		public float BeatSec { get => ONE_MINUTE / musicBpm; }
		public bool IsFinishCreate { get => currentNoteDataList.Count <= currentDataIndex; }
		
		// TODO
		public NotesDataModel FindNextTargetTypeNoteData(int startIndex, NoteTypeID targetType) { return default; }
		
		// TODO
		public bool CheckCreateNextNote(double checkTime, out NotesDataModel nextNoteData)
		{
			nextNoteData = default;
			return default;
		}
		
		// TODO
		public NotesDataModel GetNextNoteData() { return default; }
		
		public bool IsLongTap { get => longStartNote != null; }
		
		// TODO
		public NoteTapTimingID CheckTapTiming(float noteLifeTime) { return default; }
		
		// TODO
		public void StartLongTap(NoteIcon startNote, float startElapsedTime) { }
		
		// TODO
		public NoteTapTimingID CheckLongHoldSpanTimingID(float elapsedTime) { return default; }
		
		// TODO
		public NoteTapTimingID CheckHoldTimeByTimeRatio(float holdTimeRatio) { return default; }
		
		// TODO
		public TapResultData OnReleaseHold(int playerIndex, NoteTapTimingID holdTimingID) { return default; }
		
		// TODO
		public void FinishLongTap() { }
		
		// TODO
		public TapResultData OnNPCReleaseHold(int playerIndex, NoteTapTimingID holdTimingID) { return default; }
		
		// TODO
		public bool CanUpdateProgressGauge(double elapsedTime, out float gaugeRatio)
		{
			gaugeRatio = default;
			return default;
		}
		
		public float SuccessScoreRatio { get => successScoreRatio; }
		
		// TODO
		public ResultID CheckScoreSuccess() { return default; }
		
		// TODO
		public bool ApplyTotalScoreFromPlayer(int playerIndex, out ApplyScoreResult result)
		{
			result = default;
			return default;
		}
		
		// TODO
		public float CalcTotalRatio() { return default; }
		
		public bool CanUpdateAcceptChain { get => canUpdateChain; }
		public int ChainCount { get => chainCount; }
		public int LastUsePlayerIndex { get => lastUsePlayerIndex; }
		public float DownVolumePersent { get => downVolumePersent; }
		
		// TODO
		public bool IsShowChainCount() { return default; }
		
		// TODO
		public void LaunchSkill(double elapsedTime, int playerIndex, bool isPrevSameWazaType) { }
		
		// TODO
		private void CheckUntilUseSkillPlayer() { }
		
		// TODO
		public void OnLockPlayerContestSkill() { }
		
		// TODO
		private void PlayLaunchWazaSE(int playerIndex, bool isPrevSameWazaType) { }
		
		// TODO
		public float CalcChaniGaugeRatio(double elapsedTime) { return default; }
		
		public NotesDataModel LastNoteData { get => lastNoteData; }
		
		// TODO
		public PlayerDanceDataModel CalcPlayerScoreAfterContestWaza(PlayerDanceDataModel danceDataModel, double startElapsedTime, double endElapsedTime, bool isUser) { return default; }
		
		// TODO
		public void ApplyScoreBonus() { }
		
		public bool IsAlreadyUseUserSkill { get => userDataModel.IsAlreadyUseSkill; }
		
		// TODO
		public bool CheckSamePrevWazaType() { return default; }
		
		// TODO
		public bool CheckSameUserWazaType(int palyerIndex) { return default; }

		private class SkillComboData
		{
			public bool IsContain;
			public int score;
			
			public SkillComboData()
			{
				Reset();
			}
			
			public void Reset()
			{
				IsContain = false;
				score = 0;
			}
		}
	}
}