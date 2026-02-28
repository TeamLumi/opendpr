using AK;
using DPData;
using Dpr.Message;
using Dpr.MsgWindow;
using Dpr.SubContents;
using Dpr.UI;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.GMS
{
	public class GMSMessageWindow
	{
		private readonly Vector2 CENTER_WINDOW_POS = new Vector2(0.0f, 105.0f);
		private readonly Vector2 MSG_WINDOW_POS = new Vector2(-195.0f, 105.0f);

        private string[] choiceYesNoTexts;
		private string[] choiceGMSModeTexts;
		private string[] choiceTradeTexts;
		private string[] choiceMarkedMonsDataTexts;
		private string[] choiceMonsDataTexts;
		private GMSMasterData.SheetWindowMessage[] windowMsgDatas;
		private ShowMessageWindow msgWindow = new ShowMessageWindow();
		private ContextMenuWindow.Param contextParam = new ContextMenuWindow.Param();
		private int prevUseMsgFileNameHash;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void SetMessageDatas(GMSMasterData.SheetWindowMessage[] windowMessage) { }
		
		// TODO
		private void SetChoiceYesNoTexts(MessageMsgFile useMsgFile) { }
		
		// TODO
		private void SetChoiceGMSModeTexts(MessageMsgFile useMsgFile) { }
		
		// TODO
		private void SetChoiceTradeTexts(MessageMsgFile useMsgFile) { }
		
		// TODO
		private void SetChoiceMarkedMonsDataTexts(MessageMsgFile useMsgFile) { }
		
		// TODO
		private void SetChoiceMonsDataTexts(MessageMsgFile useMsgFile) { }
		
		// TODO
		public bool IsOpen { get; }
		
		public MsgWindowDataModel.MsgWindowState MsgWindowState { get => msgWindow.MsgWindowState; }
		
		public void SetMsgSpeed(MSGSPEED msgSpeed)
		{
			this.msgWindow.SetMsgSpeed(msgSpeed);
		}
		
		// TODO
		public void ShowMessage(MessageID messageID, [Optional] [DefaultParameterValue(false)] bool canInputClose, [Optional] Action onFinishedMessage, [Optional] Action onClosedWindow, bool defaultPos = false) { }
		
		// TODO
		public void ShowAutoCloseMessage(MessageID messageID, float showMsgTime, Action onClosedWindow, bool defaultPos = false) { }
		
		// TODO
		private void SettingWindowPos(bool defaultPos) { }
		
		// TODO
		private string SettingMsbtData(MessageID messageID) { return default; }
		
		public void CloseMsgWindow()
		{
			this.msgWindow.CloseMsgWindow();
		}
		
		// TODO
		public void OpenYesNoMenu(Action<int> onChoiced, [Optional] Action onClosed) { }
		
		// TODO
		public void OpenChoiceModeSelectMenu(int initSelectIndex, Action<int> onChoiced, [Optional] Action onClosed) { }
		
		// TODO
		public void OpenChoiceTradeMenu(Action<int> onChoiced, [Optional] Action onClosed) { }
		
		// TODO
		public void OpenChoiceMonsDataMenu(Action<int> onChoiced, [Optional] Action onClosed) { }
		
		// TODO
		public void OpenChoiceMarkedMonsDataMenu(Action<int> onChoiced, [Optional] Action onClosed) { }
		
		// TODO
		public void OpenChoiceConfirmDeleteMenu(Action<int> onChoiced, [Optional] Action onClosed) { }
		
		// TODO
		private void OpenContextMenu(string[] menuLabels, int initSelectIndex, Action<int> onChoiced, Action onClosed, uint seDecide = EVENTS.UI_COMMON_DECIDE) { }
		
		// TODO
		private void OpenContextMenuFromMsgWindowManager(string[] textArray, int initSelectIndex, Action<int> onChoiced, Action onClosed) { }
		
		// TODO
		private void OpenContextMenuFromUIManager(Vector3 windowPos, string[] textArray, int initSelectIndex, Action<int> onChoiced, Action onClosed, uint seDecide = EVENTS.UI_COMMON_DECIDE) { }
	}
}