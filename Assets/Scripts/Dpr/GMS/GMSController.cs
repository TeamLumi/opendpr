using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SubContents;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.GMS
{
	public class GMSController : MonoBehaviour
	{
		private TradeState currentTradeState;
		private AfterErrorDialogActID afterErrorDialogActID;
		private GMSTradeResult gmsTradeResult;
		private PointDataStatus pointDataStatus = PointDataStatus.None;
		private WaitTimer randomWaitTimer = new WaitTimer();
		private bool isMovedCamera;
		private bool isCalledSave;
		private bool canUseGMSNetwork;

		[SerializeField]
		private GMSCamera gmsCamera;
		private UIGMSScene sceneUI;
		private UIPointMarkManager uiGMSMark;
		private UIPointListManager uiPointDataList;
		private UIAchievementAnim uiAchievementAnim;
		private GMSSceneDataModel dataModel = new GMSSceneDataModel();
		private GMSMessageWindow msgWindow = new GMSMessageWindow();
		private GMSResourceLoader resourceLoader = new GMSResourceLoader();
		private GMSResourceLoader asyncResourceLoader = new GMSResourceLoader();
		private UIManager uiManagerPtr;
		private GameObject earthObj;
		private Texture2D bgTexture;
		private EffectEmitter effectEmitter = new EffectEmitter();
		
		// TODO
		private void StartTradeFlow() { }
		
		// TODO
		private void ChangeStateNetworkTrade() { }
		
		private void ResetTradeParam()
		{
			this.gmsTradeResult = null;
			this.isMovedCamera = false;
			this.pointDataStatus = (PointDataStatus)3;
			this.afterErrorDialogActID = (AfterErrorDialogActID)0;
			if (0xe < (int)this.currentTradeState ||
			    (1 << (int)((int)this.currentTradeState & 0x1f) & 0x4009U) == 0) {
			  GMSWork.EmitLog(_StringLiteral_9409,0);
			}
			this.currentTradeState = (TradeState)0;
			this.uiGMSMark.HideAttentionIcon();
			this.uiGMSMark.HideMatchingIcon();
			0.StopFx(this.effectEmitter,0x27);
		}
		
		// TODO
		private void UpdateNetworkTrade(float deltaTime) { }
		
		// TODO
		private void UpdateStartPreSave() { }
		
		// TODO
		private void UpdateStartConnect() { }
		
		// TODO
		private bool CheckConnectInternet() { return default; }
		
		// TODO
		private void OnConnectSuccess() { }
		
		// TODO
		private void StartValidateCheck() { }
		
		// TODO
		private void OnFailedValidate(ValidateResultID resultID) { }
		
		// TODO
		private void OnConnectFalied() { }
		
		// TODO
		private void UpdatePreTradeSave() { }
		
		// TODO
		private void UpdateStartConnectGMSServer(float deltaTime) { }
		
		// TODO
		private bool CheckFatalError() { return default; }
		
		// TODO
		private void UpdateTrading() { }
		
		// TODO
		private void ReceiveTradeData(int pointIndex, byte[] coreData) { }
		
		// TODO
		private void UpdateFinishTrade() { }
		
		// TODO
		private void UpdateFinishTradeDemo() { }
		
		// TODO
		private void OnFinishedTradeDemo(int pointIndex) { }
		
		// TODO
		private void UpdateShowApplicationError() { }
		
		// TODO
		private void ChangeTradeState(TradeState nextState) { }
		
		// TODO
		private void SetAfterErrorDialogAct(AfterErrorDialogActID actID) { }
		
		// TODO
		private void FinishTrade(TradeResult result) { }
		
		// TODO
		private void OnTradeSuccess() { }
		
		// TODO
		private void PlayTradeDemo([Optional] Action onEndDemo) { }
		
		// TODO
		private void OnTradeServerError() { }
		
		private void OnTradeFailed()
		{
			this.canUseGMSNetwork = false;
			this.dataModel.ClearTradeDemoParam();
			this.dataModel.ClearTradeResultData();
			ChangeTradeState(0xe);
			var uVar1 = new Action(this);
			this.msgWindow.ShowMessage(0xb,1,0,uVar1);
		}
		
		// TODO
		private bool IsPerformedTrade() { return default; }
		
		private void HideMatchingIcon()
		{
			this.uiGMSMark.HideMatchingIcon();
			0.StopFx(this.effectEmitter,0x27);
		}
		
		private void HideAttentionIcon()
		{
			this.uiGMSMark.HideAttentionIcon();
		}
		
		// TODO
		private bool WaitSave() { return default; }
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		public IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private IEnumerator IE_WaitManagerInitialize() { return default; }
		
		// TODO
		private IEnumerator IE_LoadMasterDatas() { return default; }
		
		// TODO
		private void LoadResourcesBackGround() { }
		
		// TODO
		private void SetAllObjectLayer(GameObject target, int layer) { }
		
		// TODO
		private void AppendLoadResource() { }
		
		// TODO
		private void SceneInitialize() { }
		
		private void LoadEffect()
		{
			var uVar1 = ComponentExtensions.FindDeep(_StringLiteral_9435,1);
			uVar1 = uVar1.transform;
			this.effectEmitter.Initialize(uVar1,GMSSceneDataModel.GetGMSEffects(this.dataModel),0);
		}
		
		// TODO
		private void Start() { }
		
		// TODO
		private void Setup() { }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void ChangeSceneState(SceneState nextState) { }
		
		private void ChangeSceneStateLaunchAnim()
		{
			this.sceneUI.StartSceneAnim(this.dataModel.nowTotalPutPointNum,GMSSceneDataModel.get_IsPutComp(this.dataModel) & 1,0);
		}
		
		// TODO
		private void ChangeSceneStateModeSelect() { }
		
		private void OnClosedModeSelectMenu()
		{
			if (this.dataModel.selectGMSMode == 2) {
			  ConfirmExitGMSScene();
			}
			if (this.dataModel.selectGMSMode != 1) {
			  if (this.dataModel.selectGMSMode == 0) {
			    OpenSelectTradeMonsBox();
			  }
			}
			StartBrowsingMode();
		}
		
		// TODO
		private void OpenSelectTradeMonsBox() { }
		
		private bool CheckHasUnionPenalty()
		{
			if ((this.dataModel.HasUnionPenalty() & 1) != 0) {
			  this.msgWindow.ShowMessage(0x20,1,0,0,1);
			  if (this.dataModel.nowSceneState == 0x10) {
			    GMSWork.EmitLog(_StringLiteral_9436,2);
			  }
			  else {
			    this.dataModel.SetSceneState(0x10);
			  }
			  return true;
			}
			return false;
		}
		
		// TODO
		private void StartBrowsingMode() { }
		
		private void ChangeSceneStateBackTitle()
		{
			this.sceneUI.StartOnBackTopAnim(this.dataModel.nowTotalPutPointNum,GMSSceneDataModel.get_IsPutComp(this.dataModel) & 1,0);
			if (this.dataModel.nowSceneState == 2) {
			  GMSWork.EmitLog(_StringLiteral_9436,2);
			}
			this.dataModel.SetSceneState(2);
			ChangeSceneStateModeSelect();
		}
		
		// TODO
		private void ChangeSceneStateStartGMSModeAnim() { }
		
		// TODO
		private void ChangeSceneStateEndGMSModeAnim() { }
		
		private void ChangeSceneStateSaveTradeResult()
		{
			this.dataModel.SetGMSPlayerData();
		}
		
		// TODO
		private void ChangeSceneStateMain() { }
		
		// TODO
		private void ChangeSceneStateAchievement() { }
		
		private void ChangeSceneStateReward()
		{
			if (this.dataModel.hasAchievementReward != 0) {
			  this.dataModel.GetAutoCloseMsgTimeShort();
			  this.msgWindow.ShowAutoCloseMessage(0x1a,0,1);
			}
		}
		
		// TODO
		private void ChangeSceneStateConfirmContinue() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateStateLaunchAnim() { }
		
		// TODO
		private void UpdateStateStartGMSModeAnim(float deltaTime) { }
		
		// TODO
		private void UpdateStateMain(float deltaTime) { }
		
		// TODO
		private void UpdateInput(float deltaTime) { }
		
		private bool CanExitScene()
		{
			return this.uiPointDataList.bIsShowPointHistoryView == 0;
		}
		
		private void BackBoxMenu()
		{
			OpenSelectTradeMonsBox();
			if (this.dataModel.nowSceneState == 8) {
			  GMSWork.EmitLog(_StringLiteral_9436,2);
			}
			this.dataModel.SetSceneState(8);
		}
		
		// TODO
		private void UpdateStateBackBox() { }
		
		// TODO
		private void UpdateSelectReplaceData() { }
		
		// TODO
		private void UpdateStateEndGMSModeAnim() { }
		
		private void UpdateAchievementAnim()
		{
			if (this.uiAchievementAnim.bIsActive != 0) {
			  this.uiAchievementAnim.OnUpdate();
			}
			ChangeSceneState(0xc);
		}
		
		// TODO
		private void UpdateReward() { }
		
		private void UpdateSaveTradeResult()
		{
			var uVar1 = WaitSave();
			if (uVar1) {
			}
			if (this.dataModel.nowSceneState == 0xe) {
			  GMSWork.EmitLog(_StringLiteral_9436,2);
			}
			this.dataModel.SetSceneState(0xe);
			ChangeSceneStateConfirmContinue();
		}
		
		// TODO
		private void UpdatePenalty() { }
		
		// TODO
		private void UpdateCamera(float deltaTime) { }
		
		// TODO
		private void InputCamera() { }
		
		// TODO
		private void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void UpdatePointMark() { }
		
		// TODO
		private void OnSelectListData(PointHistoryDataModel selectData) { }
		
		// TODO
		private void OpenConfirmReplaceDataMsg() { }
		
		// TODO
		private void JumpPoint(int pointIndex, Action onMoveEnd) { }
		
		// TODO
		private void OpenChoicePointOperationMenu(bool isSelectMarkItem, bool isSelectTop) { }
		
		// TODO
		private void ChoiceMark() { }
		
		// TODO
		private void ChoiceDeleteMark(bool isSelectTop) { }
		
		// TODO
		private void OnChoiceDelete(bool isSelectTop) { }
		
		// TODO
		private void OnChoiceReplaceData() { }
		
		// TODO
		private void JumpNearPoint() { }
		
		// TODO
		private void OnStopCameraMove() { }
		
		private void OnReleaseListInput()
		{
			if ((this.dataModel.selectGMSMode == 1) &&
			   (this.dataModel.nowTotalPutPointNum < 2)) {
			}
			DecideSelectPoint();
		}
		
		// TODO
		private void OnCancelList() { }
		
		// TODO
		private void OpenConfirmStayMessage() { }
		
		// TODO
		private void OnSelectStayData() { }
		
		// TODO
		private void DecideSelectPoint() { }
		
		// TODO
		private void ConfirmExitGMSScene() { }
	}
}