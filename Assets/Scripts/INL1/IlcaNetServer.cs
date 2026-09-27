using NexPlugin;
using nn.account;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace INL1
{
	public class IlcaNetServer : IlcaNetBase
	{
		protected static NexState serverState;

		private static AsyncResult serverAsyncResult;
		private static IlcaNetServerFinalAsyncCallback finalCallback = null;
		private static Thread FinalAsyncCoRoutineCoreUpdateDispatchWTh;

        private static volatile bool isFinalAsyncCoRoutineCoreCallbackCompleted = false;

		private static Thread finalAsyncFWTh;

        private static volatile bool isFinalAsyncFinishWorkerCompleted = false;

		private static UserNexUniqueIdAcquireCallback unuiaCallback = null;
		private static AsyncContext pOutContext = new AsyncContext();
		
		// TODO
		public static bool Init(MonoBehaviour callobj, UserHandle uh, ulong nexUniqueId, ulong nexUniqueIdPassword) { return default; }
		
		// TODO
		protected static bool Init(MonoBehaviour callobj, UserHandle uh, UserNexUniqueIdAcquireCallback func) { return default; }
		
		// TODO
		private static void InitSub(MonoBehaviour callobj, UserHandle uh) { }
		
		// TODO
		protected static void NexAssetsAutoLoginLogoutControl() { }
		
		// TODO
		public static void NexAssetsAutoLoginControl(bool on) { }
		
		// TODO
		public static void NexAssetsAutoLogoutControl(bool on) { }
		
		// TODO
		public static void MainThreadDispatchControl(bool on) { }
		
		// TODO
		public static bool MainThreadDispatchControlState() { return default; }
		
		// TODO
		protected static void StartX() { }
		
		// TODO
		private static void LostCallback() { }
		
		// TODO
		private static void LostCallbackNGS(ulong principalId) { }
		
		// TODO
		public static bool IsRunning() { return default; }
		
		// TODO
		protected static void baseCallback(AsyncResult asyncResult) { }
		
		// TODO
		public static IlcaNetServerFinalAsyncNeedEnum IsFinalAsyncNeed() { return default; }
		
		// TODO
		public static bool FinalAsyncCoRoutine(MonoBehaviour callobj, IlcaNetServerFinalAsyncCallback callback) { return default; }
		
		// TODO
		private static bool FinalAsyncCoRoutineCoreUpdateDispatchWorkerSet() { return default; }
		
		// TODO
		private static void FinalAsyncCoRoutineCoreUpdateDispatchWorkerTh() { }
		
		// TODO
		private static void FinalAsyncCoRoutineCoreCallback(AsyncResult asyncResult) { }
		
		// TODO
		private static bool FinalAsyncFinishWorkerSet() { return default; }
		
		// TODO
		private static void FinalAsyncFinishWorkerTh() { }
		
		// TODO
		private static IEnumerator FinalAsyncCoRoutineCore(IlcaNetServerFinalAsyncCallback callback) { return default; }
		
		// TODO
		public static void Final() { }
		
		// TODO
		public static void NexErrorHandling(AsyncResult asyncResult) { }
		
		// TODO
		private static bool IlcaNetNexUniqueIdAcquireAsync(UserNexUniqueIdAcquireCallback func) { return default; }
		
		// TODO
		private static void IlcaNetNexUniqueIdAcquireAsyncCallback_noPassword(AsyncResult asyncResult, ulong nexUniqueId) { }
		
		// TODO
		private static void IlcaNetNexUniqueIdAcquireAsyncCallback(AsyncResult asyncResult, UniqueIdInfo uniqueIdInfo) { }
		
		// TODO
		private static void IlcaNetNexUniqueIdAcquireAsyncAfterCallback(AsyncResult asyncResult) { }
		
		// TODO
		private static void IlcaNetNexUniqueIdAcquireAsyncAfterAfterSuccessCallback() { }
		
		// TODO
		private static void IlcaNetNexUniqueIdAcquireAsyncAfterAfterFailureCallback() { }
		
		// TODO
		protected static bool NSAIDtokenGetAsync(MonoBehaviour callobj, UserHandle uh, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		public static bool NSAIDtokenGetAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static IEnumerator NSAIDtokenGetAsyncCore(UserHandle uh, IlcaNetServerAsyncCallback callback) { return default; }

		protected enum NexState : int
		{
			Idle = 0,
			StartDeleteData = 1,
			RunningDeleteData = 2,
			EndDeleteData = 3,
			StartDownloadData = 4,
			RunningDownloadData = 5,
			EndDownloadData = 6,
			StartSearchData = 7,
			RunningSearchData = 8,
			EndSearchData = 9,
			StartUploadData = 10,
			RunningUploadData = 11,
			EndUploadData = 12,
			StartUpdateData = 13,
			RunningUpdateData = 14,
			EndUpdateData = 15,
			StartGetMetaData = 16,
			RunningGetMetaData = 17,
			EndGetMetaData = 18,
			StartChangeMetaData = 19,
			RunningChangeMetaData = 20,
			EndChangeMetaData = 21,
			StartGetRatingData = 22,
			RunningGetRatingData = 23,
			EndGetRatingData = 24,
			StartSetRatingData = 25,
			RunningSetRatingData = 26,
			EndSetRatingData = 27,
			StartCrashDataStore = 28,
			RunningCrashDataStore = 29,
			EndCrashDataStore = 30,
			StartRetrieveRank = 31,
			RunningRetrieveRank = 32,
			EndRetrieveRank = 33,
			StartUploadRank = 34,
			RunningUploadRank = 35,
			EndUploadRank = 36,
			StartUploadCommon = 37,
			RunningUploadCommon = 38,
			EndUploadCommon = 39,
			StartRetrieveContent = 40,
			RunningRetrieveContent = 41,
			EndRetrieveContent = 42,
			StartUpload = 43,
			RunningUpload = 44,
			EndUpload = 45,
			StartEstimateRank = 46,
			RunningEstimateRank = 47,
			EndEstimateRank = 48,
			StartCrashRank = 49,
			RunningCrashRank = 50,
			EndCrashRank = 51,
		}

		public enum IlcaNetServerFinalAsyncNeedEnum : int
		{
			None = 0,
			NeedInit = 1,
			NeedLogout = 2,
		}

		public delegate void IlcaNetServerFinalAsyncCallback();
		public delegate void UserNexUniqueIdAcquireCallback(bool isSuccess, ulong nexUniqueId, ulong nexUniqueIdPassword);
		public delegate void IlcaNetServerAsyncCallback(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult result, long responseCode, string responseStr);
	}
}