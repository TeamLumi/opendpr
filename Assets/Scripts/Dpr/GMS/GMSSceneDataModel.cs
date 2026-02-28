using DPData;
using Dpr.Demo;
using Dpr.Message;
using Dpr.SubContents;
using Dpr.UI;
using Pml;
using SmartPoint.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.U2D;
using XLSXContent;

namespace Dpr.GMS
{
	public class GMSSceneDataModel
	{
		private const int INIT_VOICE_SB_CAPACITY = 64;

		private readonly Rect VIEWPORT_RECT = new Rect(-0.1f, -0.1f, 1.15f, 1.15f);
		private readonly Vector2 SCREE_SIZE = new Vector2(1280.0f, 720.0f);

		private GMSMasterData gmsMasterData;
		private GMSPointDataContainer dataContainer = new GMSPointDataContainer();
		private GMSResourceContainer resourceContainer = new GMSResourceContainer();
		private UIManager uiManagerPtr;
		private Camera mainCameraPtr;
		private GMSPointDataModel lastUpdatePointData;
		private AchievementInfo achievementInfo = new AchievementInfo();
		private Keyguide keyguide;
		private KeyguidePattern keyguidePattern = KeyguidePattern.None;
		private ArenaInfo.SheetArenaData currentArenaData;
		private MessageManager msgManagerPtr;
		private MessageMsgFile monsNameMsgFile;
		private MessageMsgFile gmsMsgFile;
		private Dictionary<int, string> monsNameTable = new Dictionary<int, string>();
		private Transform keyGuideParent;
		private RenderTexture renderTexture;
		private UnionTradeManager.BoxPokeData evolvedTargetPokeParam;
		internal GMSMode selectGMSMode = GMSMode.Top;
		internal SceneState nowSceneState;
		private Coroutine coroutineCreatePointHistoryData;
		private BoxWindow.SelectedPokemon selectBoxPokemon;
		private StringBuilder voiceEventSb = new StringBuilder(INIT_VOICE_SB_CAPACITY);
		private Color defaultFadeColor;
		private Fader.FadeMode defaultFadeMode;

		private int[] ngPokeNos;
		private float showPointDotValue;
		internal int nowTotalPutPointNum;
		private int maxPointNum;
		private int lastSelectModeIndex;
		private ushort tradeListIndex;
		private ushort browsingListIndex;
		private byte achievementStep;
		private bool lockCheckAchievementFlag;
		internal bool hasAchievementReward;
		private bool bIsReady;

		private SpriteAtlas graphicTextAtlas;
		private Demo_Trade tradeDemoParam;
		private TradeResultData tradeResultData;
		
		// TODO
		public void Initialize(Transform keyGuideParent) { }
		
		// TODO
		private ArenaInfo.SheetArenaData FindGMSArenaInfo() { return default; }
		
		// TODO
		private void CreatePointDatas() { }
		
		// TODO
		private int FirstCalcPutPointNum() { return default; }
		
		// TODO
		private IEnumerator IE_CreatePointHistoryData() { return default; }
		
		// TODO
		public void SetGMSMasterData(GMSMasterData gmsMasterData) { }
		
		public void ResetData()
		{
			this.lockCheckAchievementFlag = false;
			this.keyguidePattern = (KeyguidePattern)7;
			var uVar1 = CalcTotalPutPointNum();
			this.nowTotalPutPointNum = uVar1;
			this.dataContainer.RemapRefDataIndex();
		}
		
		// TODO
		public void ResetPointDataStatus() { }
		
		// TODO
		public void OnFinishTrade() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void UnloadAssetBundle() { }
		
		public bool IsReady { get => bIsReady; }
		public SceneState NowSceneState { get => nowSceneState; }
		public GMSMode SelectGMSMode { get => selectGMSMode; }
		public RenderTexture RenderTexture { get => renderTexture; }
		public GMSPointDataContainer DataContainer { get => dataContainer; }
		public int LastSelectModeIndex { get => lastSelectModeIndex; }
		public int TotalPutPointNum { get => nowTotalPutPointNum; }
		public int MaxPutPointNum { get => maxPointNum; }
		public bool IsPutComp { get => maxPointNum <= nowTotalPutPointNum; }
		
		// TODO
		public void SetSceneState(SceneState newState) { }
		
		// TODO
		public void ChangeGMSMode(GMSMode selectGMSMode) { }
		
		public bool CanSnapPoint()
		{
			if ((int)this.selectGMSMode != 0) {
			  return 0 < this.nowTotalPutPointNum;
			}
			return true;
		}
		
		public bool CanControllCameraOnBrowsingMode { get => selectGMSMode != GMSMode.Browsing || nowTotalPutPointNum > 0; }
		
		// TODO
		public string GetGroundAssetPath() { return default; }
		
		// TODO
		public EnvironmentSettings GetStageRenderSetting() { return default; }
		
		// TODO
		public string GetResourcePath(int dataIndex) { return default; }
		
		// TODO
		public EmitEffectParam[] GetGMSEffects() { return default; }
		
		// TODO
		public string GetSpriteAtlasPath() { return default; }
		
		public void SetSpriteAtlas(SpriteAtlas atlas)
		{
			this.graphicTextAtlas = atlas;
		}
		
		// TODO
		public Sprite GetSpriteByIndex(int index) { return default; }
		
		// TODO
		private string GetSpriteName(int index) { return default; }
		
		// TODO
		public float GetAutoCloseMsgTimeShort() { return default; }
		
		// TODO
		public float GetAutoCloseMsgTimeLong() { return default; }
		
		// TODO
		public float CalcEarthRadius() { return default; }
		
		// TODO
		private float CalcShowPointDotValue() { return default; }
		
		// TODO
		public float CalcSpeedUpCoefficient() { return default; }
		
		// TODO
		private int GetDataValue(int dataIndex) { return default; }
		
		// TODO
		public int GetPointIndexByListIndex(int listIndex) { return default; }
		
		// TODO
		public int FindBrowsingIndexByTradeIndex(int tradeIndex) { return default; }
		
		// TODO
		public PointDataStatus CheckPointDataStatus(int pointIndex) { return default; }
		
		// TODO
		public GMSPointDataModel GetPointDataModelByIndex(int index) { return default; }
		
		// TODO
		private int CalcTotalPutPointNum() { return default; }
		
		// TODO
		public string CreatePointMonsVoiceEvent(int pointIndex) { return default; }
		
		// TODO
		private PointHistoryDataModel CreatePointHistoryDataModelByHistoryData(GMS_POINT_HISTORY_DATA hitsoryData, GMS_POINT_HISTORY_EXT_DATA extData) { return default; }
		
		// TODO
		private PointHistoryDataModel CreateHistoryDataModel(IntermediatePointData data) { return default; }
		
		// TODO
		private string CreateMonsNameStr(MonsNo monsNo) { return default; }
		
		// TODO
		private void LoadMonsIconSpr(MonsNo monsNo, ushort formNo, Sex sex, Action<Sprite> onLoadComplete) { }
		
		// TODO
		public GMSPointDataModel FindNearPointDataFromCamera(ref Vector3 cameraNormal) { return default; }
		
		// TODO
		public void MarkHistoryData(int pointIndex, int dataIndex, bool isSave) { }
		
		// TODO
		public void AddHistoryData(int pointIndex, IntermediatePointData newData, bool isNew, bool isSave) { }
		
		// TODO
		public void InsertHistoryData(int pointIndex, IntermediatePointData newData, bool isMark, bool isNew, bool isSave) { }
		
		// TODO
		public void DeleteHistoryData(int pointIndex, int dataIndex, bool isSave) { }
		
		// TODO
		public void SortNewHistoryData(int pointIndex) { }
		
		// TODO
		public void ResetPointMarkIndex(int pointIndex) { }
		
		// TODO
		public void UpdatePointPosition(GMSPointDataModel target, in Vector3 cameraNormal, bool isMaxZoom) { }
		
		// TODO
		private bool IsViewCamera(GMSPointDataModel target, in Vector3 cameraNormal, bool isMaxZoom) { return default; }
		
		// TODO
		public int GetStartListIndex(GMSMode gmsMode) { return default; }
		
		public int GetNowSelectModeListIndex()
		{
			GetStartListIndex(this.selectGMSMode);
			return 0;
		}
		
		public void SetTradeListIndex(int index)
		{
			this.tradeListIndex = (ushort)(index);
		}
		
		public void SetBrowsingListIndex(int index)
		{
			this.browsingListIndex = (ushort)(index);
		}
		
		public Demo_Trade TradeDemoParam { get => tradeDemoParam; }
		
		// TODO
		public void ClearTradeDemoParam() { }
		
		// TODO
		public void OnExitScene() { }
		
		// TODO
		public void OpenBoxWindow(Action onSelectMons, Action onCancel) { }
		
		// TODO
		private BoxWindow.OpenParam CreateBoxWindowParam() { return default; }
		
		// TODO
		private void ResetFaderParam() { }
		
		public TradeResultData TradeData { get => tradeResultData; }
		public int ReceivePointIndex { get => tradeResultData.receiveData?.pointIndex ?? 0; }
		
		// TODO
		public int ClampPointIndex(int pointIndex) { return default; }
		
		// TODO
		public void PerformCheckDprIllegalFlag() { }
		
		// TODO
		public void SettingSendDataModel(int selectPointIndex) { }
		
		// TODO
		public void OnReceivePokeData(int pointNo, byte[] coreData) { }
		
		// TODO
		public void ApplyDemoParam() { }
		
		// TODO
		public void DeleteSendPokeData() { }
		
		public void ClearTradeResultData()
		{
			this.tradeResultData.Clear();
		}
		
		private bool IsRankMax { get => achievementStep >= gmsMasterData.PutRank.Length - 1; }
		
		// TODO
		public bool CheckPutRankup() { return default; }
		
		public bool HasAchievementReward { get => hasAchievementReward; }
		
		// TODO
		public AchievementInfo AchievementStepUp() { return default; }
		
		// TODO
		public GMSMasterData.SheetWindowMessage[] GetWindowMessageMD() { return default; }
		
		// TODO
		public string GetMessageLabelByID(MessageID messageID) { return default; }
		
		// TODO
		public void OpenKeyguide(KeyguidePattern pattern) { }
		
		// TODO
		private Keyguide.Param CreateKeyguidePatternTop() { return default; }
		
		// TODO
		private Keyguide.Param CreateKeyguidePatternTrade() { return default; }
		
		// TODO
		private Keyguide.Param CreateKeyguidePatternTradeHistory() { return default; }
		
		// TODO
		private Keyguide.Param CreateKeyguidePatternBrowsing() { return default; }
		
		// TODO
		private Keyguide.Param CreateKeyguidePatternBrowsingHistory() { return default; }
		
		// TODO
		private Keyguide.Param CreateKeyguidePatternDecide() { return default; }
		
		private Keyguide.Param CreateKeyguidePatternEmpty()
		{
			var uVar1 = new Keyguide_Param();
			return uVar1;
		}
		
		// TODO
		public void CloseKeyguide() { }
		
		// TODO
		public float CalcRandomWaitTime() { return default; }
		
		// TODO
		public bool HasUnionPenalty() { return default; }
		
		// TODO
		public void SetGMSPlayerData() { }
	}
}