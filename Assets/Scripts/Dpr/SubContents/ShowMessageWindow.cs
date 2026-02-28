using DPData;
using Dpr.Message;
using Dpr.MsgWindow;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.SubContents
{
	public class ShowMessageWindow
	{
		private MessageMsgFile msgFile;
		private MsgWindowInput input = new MsgWindowInput();
		private MsgWindowParam msgWindowParam = new MsgWindowParam();
		private MsgWindow.MsgWindow msgWindow;
		private Vector2? wndAnchorPos;
		private Action onClosedWindow;
		private ShowMode currentMode;
		private MSGSPEED msgSpeed = MSGSPEED.MSGSPEED_MAX;
		private float showDuration;
		private float timer;
		private bool isNetworkMode;
		
		// TODO
		public void Setup(string msbtName, MSGSPEED msgSpeed, bool isNetwork = false) { }
		
		// TODO
		public void Setup(string msbtName, bool batchDisplayFlag, bool isNetwork = false) { }
		
		// TODO
		private void Initialize(string msbtName) { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool IsOpen { get => msgWindow != null && msgWindow.IsOpen; }
		public MsgWindowParam MsgWindowParam { get => msgWindowParam; }
		public MsgWindowDataModel.MsgWindowState MsgWindowState { get => msgWindow.MsgState; }
		
		// TODO
		public void ChangeMSBTFile(string newMsbtName) { }
		
		// TODO
		public void SetWndAnchorPos(Vector2? anchorPos) { }
		
		// TODO
		public void SetMsgSpeed(MSGSPEED msgSpeed) { }
		
		// TODO
		public void SetBatchDisplayFlag(bool flag) { }
		
		public void SetNetworkMode(bool isNetwork)
		{
			this.isNetworkMode = (isNetwork ? 1 : 0) & 1;
		}
		
		// TODO
		public void HideKeywaitIcon() { }
		
		// TODO
		public void ShowMessage(string labelName, [Optional] Action onFinishMessage, bool isShowloadingIcon = false, bool inputEnabled = false) { }
		
		// TODO
		public void ShowMessage(string labelName, Action onFinishMessage, Action onClosedWindow, bool isShowloadingIcon = false, bool inputEnabled = false) { }
		
		// TODO
		public void ShowAutoCloseMessage(string labelName, float showDuration, [Optional] Action onFinishMessage, [Optional] Action onClosedWindow) { }
		
		// TODO
		public void ShowInputCloseMessage(string labelName, [Optional] Action onFinishMessage, [Optional] Action onClosedWindow) { }
		
		// TODO
		private void OpenMsgWindow(string labelName, bool inputEnabled, Action onFinishMessage, bool isShowloadingIcon = false) { }
		
		// TODO
		public void ShowInputCloseItemPocketMessage(string labelName, int itemNo, [Optional] Action onFinishMessage, [Optional] Action onClosedWindow) { }
		
		private void OnUpdate(float deltaTime)
		{
			if ((int)this.currentMode == 2) {
			  WaitCloseWindow();
			}
			if ((int)this.currentMode != 1) {
			  if ((int)this.currentMode == 0) {
			    UpdateAutoClose();
			  }
			}
			UpdateInputClose();
		}
		
		// TODO
		private void UpdateAutoClose(float deltaTime) { }
		
		// TODO
		private bool CheckTime(float deltaTime) { return default; }
		
		// TODO
		private void UpdateInputClose() { }
		
		// TODO
		private void WaitCloseWindow() { }
		
		public void CloseMsgWindow()
		{
			this.currentMode = (ShowMode)2;
			var uVar1 = 0.IsOpen;
			if ((uVar1 & 1) != 0) {
			  MsgWindowManager.CloseMsg(0);
			}
		}

		private enum ShowMode : int
		{
			AutoClose = 0,
			InputClose = 1,
			WaitClosed = 2,
		}
	}
}