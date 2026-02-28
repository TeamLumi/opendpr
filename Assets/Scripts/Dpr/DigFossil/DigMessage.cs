using Dpr.MsgWindow;
using System;

namespace Dpr.DigFossil
{
	public class DigMessage : IDigMessage
	{
		// TODO
		public void ShowStartMessage(int depositNum, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public void ShowResultMessage(bool bIsDigOutAllItems, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public void ShowResultCommonItemMessage(int labelId, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public void ShowResultStoneBoxMessage(short boxId, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public void ShowStoneBoxOpenMessage(Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public void ShowStatueGetMessage(int labelId, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public void ShowItemMaxMessage(Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public void ShowUgItemMaxMessage(Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		public void Close()
		{
			MsgWindowManager.CloseMsg(0);
		}
		
		// TODO
		private MsgWindowParam CreateParam(string labelName, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { return default; }
	}
}