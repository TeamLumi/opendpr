using Dpr.MsgWindow;
using System;

namespace Dpr.SecretBase
{
	public static class SecretBaseMessage
	{
		public static void ShowDontHaveStatue(Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
		{
			var uVar1 = CreateParam(_StringLiteral_10116,onFinishedShowAllMessage,onFinishedCloseWindow);
			MsgWindowManager.OpenMsg(uVar1);
		}
		
		public static void ShowNothingStatueEffect(Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
		{
			var uVar1 = CreateParam(_StringLiteral_10117,onFinishedShowAllMessage,onFinishedCloseWindow);
			MsgWindowManager.OpenMsg(uVar1);
		}
		
		public static void ShowSetThisSecretBase(Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
		{
			var uVar1 = CreateParam(_StringLiteral_10118,onFinishedShowAllMessage,onFinishedCloseWindow);
			MsgWindowManager.OpenMsg(uVar1);
		}
		
		public static void ShowUnsetThisSecretBase(Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
		{
			var uVar1 = CreateParam(_StringLiteral_10119,onFinishedShowAllMessage,onFinishedCloseWindow);
			MsgWindowManager.OpenMsg(uVar1);
		}
		
		public static void Close()
		{
			MsgWindowManager.CloseMsg(0);
		}
		
		// TODO
		private static MsgWindowParam CreateParam(string labelName, Action onFinishedShowAllMessage, Action onFinishedCloseWindow) { return default; }
	}
}