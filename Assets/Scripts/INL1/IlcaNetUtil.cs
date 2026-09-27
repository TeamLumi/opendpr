using NexPlugin;
using nn.account;
using System;
using System.Collections;
using UnityEngine;

namespace INL1
{
	public class IlcaNetUtil : IlcaNetServer
	{
		private static volatile bool next;
		private static volatile bool abort;
		private static IlcaNetUtilInternetBackCallBack s_backCallback;
		
		// TODO
		public static bool InternetGo(MonoBehaviour callobj, UserHandle uh, ulong nexUniqueId, ulong nexUniqueIdPassword, bool ngsLogin, IlcaNetUtilInternetGoCallBack userCallback, bool freePass = false) { return default; }
		
		// TODO
		private static IEnumerator InternetGoCore(MonoBehaviour callobj, UserHandle uh, ulong nexUniqueId, ulong nexUniqueIdPassword, bool ngsLogin, IlcaNetUtilInternetGoCallBack userCallback, bool freePass = false) { return default; }
		
		// TODO
		private static void InternetGoCallbackNEXUID(bool isSuccess, ulong nexUniqueId, ulong nexUniqueIdPassword) { }
		
		// TODO
		private static void InternetGoCallbackNSAIDT(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult result, long responseCode, string responseStr) { }
		
		// TODO
		private static void InternetGoNexFinalizeCallback() { }
		
		// TODO
		private static void InternetGoNexInitializeCallback(AsyncResult asyncResult) { }
		
		// TODO
		private static void InternetGoCallbackNGSlogin(AsyncResult asyncResult, ulong principalId, IntPtr pNgsFacade) { }
		
		// TODO
		private static void NextAbort(bool isSuccess) { }
		
		// TODO
		private static void FocusHandleNotify() { }
		
		// TODO
		public static IlcaNetUtilConnectStatusEnum InternetConnectStatus() { return default; }
		
		// TODO
		public static bool InternetBack(MonoBehaviour callobj, IlcaNetUtilInternetBackCallBack userCallback) { return default; }
		
		// TODO
		private static void InternetBackCallback() { }

		public delegate void IlcaNetUtilInternetGoCallBack(bool isSuccess, IlcaNetUtilInternetGoResult res, ulong nexUniqueId, ulong nexUniqueIdPassword);

		public enum IlcaNetUtilConnectStatusEnum : int
		{
			None = 0,
			Initialized = 1,
			LoggedIn = 2,
		}

		public delegate void IlcaNetUtilInternetBackCallBack(bool isSuccess);
	}
}