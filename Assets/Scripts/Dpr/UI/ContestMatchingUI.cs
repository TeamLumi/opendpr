using Dpr.Message;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SubContents;
using Dpr.Trainer;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class ContestMatchingUI : MonoBehaviour
	{
		private const string WAIT_ICON_TEX_NAME = "cmn_net_pl_wait_02";
		private const string READY_ICON_TEX_NAME = "cmn_net_pl_wait_01";
		private const string SEARCH_PLAYER_LABEL = "DP_contest_602";
		private const string EMPTY_PLAYER_LABEL = "DP_contest_666";

		private const float SHOW_MSG_TIME = 2.0f;
		private const int START_UI_COUNTDOWN_COUNT = 10;

		private readonly string[] YESNO_CONTEXTMENU_LABELS = new string[]
		{
            "DP_contest_292", "DP_contest_293",
        };
		private readonly Vector2 MSG_WINDOW_ANCHOR_POS = new Vector2(15.0f, 110.0f);

		[SerializeField]
		private UIContMatchingPlayerBoard[] _playerBoardArray;
		[SerializeField]
		internal MultiModelView modelView;
		[SerializeField]
		private UIRemainingCountDown remainigCountDown;
		[SerializeField]
		private UIText countTimeText;
		[SerializeField]
		private GameObject timerObj;

		private CountDownTimer countTimer = new CountDownTimer();
		internal ShowMessageWindow msgWindow = new ShowMessageWindow();
		private KeyGuideCreater _keyGuideCreator = new KeyGuideCreater();
		private MessageMsgFile msgFile;
		private MsgWindowManager msgWindowManager;
		private Transform keyguideParent;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		private Sprite GetSprite(string texName) { return default; }
		
		public void OnFinalize()
		{
			this._keyGuideCreator.Release();
		}
		
		public int GetNowViewModelCount { get => modelView.ModelViewCount; }
		
		public bool HasViewModelByIndex(int index)
		{
			this.modelView.HasViewModelByIndex(index);
			return false;
		}
		
		// TODO
		public void ShowKeyGuide(SubContentsPatternID patternID) { }
		
		public void CloseKeyGuide(Action onClosed)
		{
			this._keyGuideCreator.Close(onClosed);
		}
		
		// TODO
		public void OnJoinMine(int playerIndex) { }
		
		// TODO
		public void OnLeavePlayer(int index) { }
		
		// TODO
		public void OnExitPlayer(int index) { }
		
		// TODO
		public void LoadCharacterModel(int index, TrainerType trainerType, int colorID, string modelPath, Action<GameObject> onComplete) { }
		
		public void DestroyAllCahracterModel()
		{
			if (0 < this.modelView.TotalModelViewCount) {
			  this.modelView.TotalModelViewCount = 0;
			  do {
			    DestroyCharacterModel(this.modelView.TotalModelViewCount);
			    this.modelView.TotalModelViewCount = MultiModelView.get_TotalModelViewCount(this.modelView) + 1;
			  } while (this.modelView.TotalModelViewCount < MultiModelView.get_TotalModelViewCount(this.modelView));
			}
		}
		
		// TODO
		public void DestroyCharacterModel(int index) { }
		
		public void ChangeAllModelMotion(int motionIndex)
		{
			if (0 < this.modelView.TotalModelViewCount) {
			  this.modelView.TotalModelViewCount = 0;
			  do {
			    this.modelView.ChangeModelMotion(MultiModelView.get_TotalModelViewCount(this.modelView),motionIndex,0);
			    this.modelView.TotalModelViewCount = MultiModelView.get_TotalModelViewCount(this.modelView) + 1;
			  } while (this.modelView.TotalModelViewCount < MultiModelView.get_TotalModelViewCount(this.modelView));
			}
		}
		
		public void ChangeModelMotion(int index, int motionIndex)
		{
			this.modelView.ChangeModelMotion(index,motionIndex);
		}
		
		public void ResetAllPlayerName()
		{
			var uVar1 = Dpr_Message_MessageMsgFile__GetNameStr
			                  (this.msgFile,StringLiteral_11370,0);
			if (0 < this._playerBoardArray.Length) {
			  var iVar2 = 0;
			  do {
			    SetPlayerName(iVar2,uVar1);
			    iVar2 = iVar2 + 1;
			  } while (iVar2 < this._playerBoardArray.Length);
			}
		}
		
		// TODO
		public void SetPlayerName(int index, string name) { }
		
		// TODO
		public void SetPlayerName(int index, string name, MessageEnumData.MsgLangId langId) { }
		
		public void SetEmptyPlayerName(int index)
		{
			var uVar1 = Dpr_Message_MessageMsgFile__GetNameStr
			                  (this.msgFile,StringLiteral_11375,0);
			SetPlayerName(index,uVar1);
		}
		
		// TODO
		public void ShowPreparatioIconReady(int index) { }
		
		// TODO
		public void ShowPreparatioIconWait(int index) { }
		
		// TODO
		public void HidePreparatioIcon(int index) { }
		
		// TODO
		public void ResetPreparatioIcon() { }
		
		public int CountTime { get => countTimer.RemainingCount; }
		public bool IsFinishCountDown { get => !countTimer.IsCountDown; }
		
		public string GetCountDownMinutStr()
		{
			this.countTimer.GetMinuteStr();
			return default;
		}
		
		public string GetCountDownSecondStr()
		{
			this.countTimer.GetSecondStr();
			return default;
		}
		
		// TODO
		public void StartCountDown(float startTime) { }
		
		// TODO
		public bool UpdateCountDown(float startTime) { return default; }
		
		// TODO
		public void SetCountDownTime(int timeCount) { }
		
		// TODO
		private void CheckShowUICountDown() { }
		
		// TODO
		private void UpdateUITimeText() { }
		
		// TODO
		public void ShowCountDownTimer() { }
		
		// TODO
		public void HideCountDownTimer() { }
		
		// TODO
		private void SetTimerActive(bool active) { }
		
		public void SetTimerObjActive(bool active)
		{
			if (((this.timerObj.activeSelf ^ active) & 1) != 0) {
			  this.timerObj.SetActive((active ? 1 : 0) & 1);
			}
		}
		
		public bool IsWindowOpen()
		{
			this.msgWindow.IsOpen;
			return false;
		}
		
		public MsgWindowDataModel.MsgWindowState GetMsgState()
		{
			this.msgWindow.MsgWindowState;
			return (MsgWindowState)0;
		}
		
		// TODO
		public void ShowMessageWindow(string label, [Optional] Action onFinishMessage, bool isShowloadingIcon = false) { }
		
		// TODO
		public void ShowMsgWindowAndContextMenu(string label, string[] contextLabels, [Optional] Action<int> onSelect) { }
		
		// TODO
		public void ShowConfirmYesNoMsg(string message, [Optional] Action onSelectYes, [Optional] Action onSelectNo) { }
		
		// TODO
		public void ShowConfirmLeaveSessionMsg([Optional] Action onSelectYes, [Optional] Action onSelectNo) { }
		
		// TODO
		public void ShowAutoCloseMessageWindow(string label, [Optional] Action onClosed) { }
		
		// TODO
		public void ShowInputCloseMessageWindow(string label, [Optional] Action onCloseed) { }
		
		public void CloseMessageWindow()
		{
			if ((this.msgWindow.IsOpen & 1) != 0) {
			  ContestUtils.EmitLog(StringLiteral_11384,3);
			  this.msgWindow.CloseMsgWindow();
			}
		}
		
		// TODO
		public void OpenContextMenu(string[] contextLabels, Action<int> onSelect) { }
		
		public void CloseContextMenu()
		{
			ContestUtils.EmitLog(StringLiteral_11386,3);
			this.msgWindowManager.CloseContextMenu();
		}
	}
}