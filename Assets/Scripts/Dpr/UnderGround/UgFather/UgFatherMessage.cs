using Dpr.MsgWindow;
using System;

namespace Dpr.UnderGround.UgFather
{
	public static class UgFatherMessage
	{
		// TODO
		public static void ShowHealingChoices(Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public static void ShowHealingBegin(Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		// TODO
		public static void ShowHealingEnd(Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { }
		
		public static void Close()
		{
			MsgWindowManager.CloseMsg(0);
		}
		
		// TODO
		private static MsgWindowParam CreateParam(string labelName, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { return default; }
	}
}