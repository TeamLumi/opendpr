using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SubContents;
using Dpr.Trainer;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIBattleMatching : UIWindow
	{
		[SerializeField]
		private UIText _textTitle;
		[SerializeField]
		private UIBattleMatchingPlayer _player;
		[SerializeField]
		private UIBattleMatchingPlayer _playerVS;
		[SerializeField]
		private UIBattleMatchingRule _rule;
		[SerializeField]
		private UIBattleMatchingTimer _timer;
		[SerializeField]
		private GameObject _objResult;
		[SerializeField]
		private Image _imageResultA;
		[SerializeField]
		private Image _imageResultB;
		[SerializeField]
		private Image _imageResultDraw;
		[SerializeField]
		private Sprite _spriteResultWin;
		[SerializeField]
		private Sprite _spriteResultLose;
		[SerializeField]
		private GameObject _objLoading;
		[SerializeField]
		private GameObject _objVS;
		[SerializeField]
		private GameObject _objBgVS;
		[SerializeField]
		private MultiModelView _modelView;

		private ShowMessageWindow _msgWindow;
		private MsgWindowManager _msgWindowManager;
		private float _showMsgTime;

		private readonly string[] YESNO_CONTEXTMENU_LABELS = new string[]
		{
            "SS_net_net_btl_036", "SS_net_net_btl_037",
        };
		private readonly Vector2 MSG_WINDOW_ANCHOR_POS = new Vector2(15.0f, 110.0f);
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Setup() { }
		
		// TODO
		public void OpenUnionRoom(UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public void OpenColiseum(UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public void OpenResume(UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close() { }
		
		// TODO
		public IEnumerator OpClose() { return default; }
		
		// TODO
		public void SetKeyGuide(bool decide = true, bool back = true, bool cancel = false, bool complete = false) { }
		
		// TODO
		public void OpenKeyguide(bool decide = true, bool back = true, bool cancel = false) { }
		
		// TODO
		public void CloseKeyGuide() { }
		
		// TODO
		private void SetTitle(BattleModeID type) { }
		
		// TODO
		public void SetPlayer(BattleModeID type) { }
		
		// TODO
		public void SetPlayerVS(BattleModeID type) { }
		
		// TODO
		public void SetPlayerName(int index, string name, uint language) { }
		
		// TODO
		public void SetPlayerNameVS(int index, string name, uint language) { }
		
		// TODO
		public void OpenVSWait() { }
		
		// TODO
		public void CloseVSWait() { }
		
		// TODO
		public void ShowPreparationIconReady(int index) { }
		
		// TODO
		public void ShowPreparationIconWait(int index) { }
		
		// TODO
		public void HidePreparationIcon(int index) { }
		
		// TODO
		public void ResetPreparationIcon() { }
		
		// TODO
		public void OnJoinMine(int playerIndex) { }
		
		// TODO
		public void OnLeavePlayer(int index) { }
		
		// TODO
		public bool IsShowAllPlayerModel() { return default; }
		
		// TODO
		public int GetNowViewModelCount { get; }
		
		// TODO
		public bool HasViewModelByIndex(int index) { return default; }
		
		// TODO
		public void LoadCharacterModel(int index, Action<GameObject> onComplete) { }
		
		// TODO
		public void LoadCharacterModel(int index, TrainerType trainerType, int colorID, string modelPath, Action<GameObject> onComplete) { }
		
		// TODO
		public void DestroyAllCahracterModel() { }
		
		// TODO
		public void DestroyCharacterModel(int index) { }
		
		// TODO
		public void ChangeAllModelMotion(int motionIndex) { }
		
		// TODO
		public void ChangeModelMotion(int index, int motionIndex) { }
		
		// TODO
		public void SetTimerMessage(string label) { }
		
		// TODO
		public void SetTimerMessage(string msbt, string label) { }
		
		// TODO
		public void SetActiveTimer(bool active) { }
		
		// TODO
		public void SetActiveRemainingText(bool active) { }
		
		// TODO
		public void RemainingWarningText(bool warning = true) { }
		
		// TODO
		public void UpdateUITimeText(string minutes, string seconds) { }
		
		// TODO
		public void OpenRuleWindow() { }
		
		// TODO
		public void CloseRuleWindow() { }
		
		// TODO
		public void OpenSelectRuleWindow() { }
		
		// TODO
		public void OnRuleMoveX(bool left) { }
		
		// TODO
		public void OnRuleMoveY(bool up) { }
		
		// TODO
		public bool OnRuleDecide() { return default; }
		
		// TODO
		public void ShowVS(Action onEnd) { }
		
		// TODO
		private IEnumerator WaitVS(Action onEnd) { return default; }
		
		// TODO
		public void OpenResult() { }
		
		// TODO
		public void CloseResult() { }
		
		// TODO
		public bool IsWindowOpen() { return default; }
		
		public void SetShowMsgTime(float time) {
		    this._showMsgTime = time;
		}
		
		// TODO
		public void ShowMessageWindow(string label, [Optional] Action onFinishMessage, bool isShowloadingIcon = false) { }
		
		// TODO
		public void ShowMsgWindowAndContextMenu(string label, string[] contextLabels, [Optional] Action<int> onSelect) { }
		
		// TODO
		public void ShowMsgWindowAndContextMenu_Custom(string label, string[] contextLabels, [Optional] Action<int> onSelect) { }
		
		// TODO
		public void ShowConfirmYesNoMsg(string message, [Optional] Action onSelectYes, [Optional] Action onSelectNo) { }
		
		// TODO
		public void ShowConfirmLeaveSessionMsg([Optional] Action onSelectYes, [Optional] Action onSelectNo) { }
		
		// TODO
		public void ShowAutoCloseMessageWindow(string label, [Optional] Action onClosed) { }
		
		// TODO
		public void ShowInputCloseMessageWindow(string label, [Optional] Action onClosed) { }
		
		// TODO
		public void CloseMessageWindow() { }
		
		// TODO
		public void OpenContextMenu(string[] contextLabels, Action<int> onSelect) { }
		
		// TODO
		public void OpenContextMenu_Custom(string[] contextLabels, Action<int> onSelect) { }
		
		// TODO
		public void CloseContextMenu() { }
	}
}