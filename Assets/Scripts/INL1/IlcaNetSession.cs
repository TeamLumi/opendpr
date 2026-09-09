using NexPlugin;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

namespace INL1
{
	public class IlcaNetSession : IlcaNetBase
	{
		private static IlcaNetSessionSetting sampleset;
		private static IlcaNetSessionState netSessionState;
		private static GameState netGameState;
		private static GameState netNextGameState;
		private static PiaPlugin.AsyncProcessId netAsyncProcessId;
		private static GameAsync netGameState_Game_AsyncWait;
		private static IlcaNetSessionOpenStatus netSessionOpenCloseStatus;
		private static IlcaNetSessionOpenStatus netSessionOpenCloseStatusTarget;
		private static bool isCompletedSessionOpenCloseStatus;

		public const int maxNetGamer = 16;

		public static IlcaNetStation NetStation;
		public static IlcaNetGamer[] NetGamer;
		public static IlcaNetGamer[] NetGamer2;
		private static byte[] gamerNameConvBuff;
		private static PiaPlugin.Result lastErrorResult;
		private static bool isNetworkFinalRequest;
		private static bool isSessionLeaveRequest;
		private static IlcaNetSessionState sessionLeaveRequestState;
		private static bool isLogoutFinalizeAsyncMoving;
		private static bool isErrorHandleMoving;
		private static bool isCrash;
		private static byte[] gameFront_r_no;
		private static ushort[] gameFront_cnt;
		private static uint localRandomSessionList_counter;
		private static ushort localSessionRandomValue;
		private static bool checkSessionStateNowOnStageInConnected;
		private static ushort autoRetryRandomMatchmakeCounter;
		private static IlcaNetSessionFinalCallback finalRequestCallbackfunc;
		private static bool isSystemCallBackReady;
		private static IlcaNetSessionEventCallback sessionEventCallbackfunc;
		private static bool isSessionEventCallbackFuncReady;
		private static IlcaNetSessionCallbackMode sessionEventCallbackFuncDelayMode;
		private static int sessionEventCallbackQueueCount;

		private const int sessionEventCallbackQueueSize = 128;

		private static PiaPluginSession.SessionEvent[] sessionEventCallbackEventQueue;
		private static PiaPluginSession.JoinSessionSetting sjSsetting;
		private static PiaPluginSession.UpdateSessionSetting suaSetting;
		private static UserSessionOpenCloseAsyncCompleteCallback openCloseCallback;
		private static bool DangerousEmergencyErrorRequest;
		private static PiaPlugin.Result DangerousEmergencyErrorRequestResult;
		private static ulong debugCount;
		private static PiaPlugin.AsyncProcessId updateDispatchWorkerAsyncProcessId;
		private static bool updateDispatchWorkerdispatchResultFlag;
		private static PiaPlugin.Result updateDispatchWorkerdispatchResult;
		private static bool updateDispatchWorkerAsyncResultFlag;
		private static PiaPlugin.Result updateDispatchWorkerAsyncResult;
		private static bool updateDispatchWorkerdispatchSuspendGoing;
		private static bool updateDispatchWorkerdispatchSuspendFinish;
		private static bool updateDispatchWorkerdispatchResultFlagSuspend;
		private static PiaPlugin.Result updateDispatchWorkerdispatchResultSuspend;
		public static List<PiaPluginSession.SessionEvent> sessionEventListSuspendDispatch;
		private static PiaPluginSession.SessionEvent leaveEvent;
		private static PiaPlugin.JoinRandomSessionSetting joinRandomSessionSetting;
		private static PiaPluginSession.CreateSessionSetting createSessionSetting;
		private static PiaPluginSession.CreateSessionSetting.Attribute[] createAttribute;
		private static List<PiaPluginSession.CreateSessionSetting.Attribute> createAttributeList;
		private static PiaPluginSession.SessionSearchCriteria[] sessionSearchCriteriaList;
		private static PiaPluginSession.SessionSearchCriteria.AttributeRange[] searchAttributeRange;
		private static List<PiaPluginSession.SessionSearchCriteria.AttributeRange> searchAttributeRangeList;
		private static List<PiaPluginSession.SessionProperty> getproListAikotoba;
		private static List<getProListMod> getproListIndex;

		private const int OverPasswordMagicNunberSize = 4;
		private const int OverPasswordIDposition = 4;
		private const int OverPasswordSizePosition = 5;
		private const int OverPasswordDataPosition = 6;
		private const int OverPasswordMinSize = 7;

		private static bool isErrorHandleNexInitialize;
		private static PiaPlugin.State errorHandleNextSessionState;
		
		// TODO: cctor
		
		// TODO
		[Conditional("INL1_DEBUG")]
		private static void DebugDispSet() { }
		
		// TODO
		[Conditional("INL1_DEBUG")]
		private static void DebugDispClear() { }
		
		// TODO
		public static bool Init(MonoBehaviour callobj) { return default; }
		
		// TODO
		public static bool Init(MonoBehaviour callobj, IlcaNetSessionFinalCallback finalCallback) { return default; }
		
		// TODO
		private static void SessionFinalCallbackSet(IlcaNetSessionFinalCallback finalRequestCallback) { }
		
		// TODO
		public static bool SessionEventCallbackFuncSet(IlcaNetSessionEventCallback func) { return default; }
		
		// TODO
		public static bool SessionEventCallbackFuncSet(IlcaNetSessionEventCallback func, IlcaNetSessionCallbackMode callBackMode) { return default; }
		
		// TODO
		public static bool NetworkInitAsync(IlcaNetSessionSetting setting) { return default; }
		
		// TODO
		private static void NetworkInitAsyncNexWait() { }
		
		// TODO
		public static IlcaNetSessionState State() { return default; }
		
		// TODO
		public static IlcaNetSessionState Update() { return default; }
		
		// TODO
		public static void UpdateBottom() { }
		
		// TODO
		public static bool NetworkFinalRequestAsync() { return default; }
		
		// TODO
		private static bool NetworkFinalAsync() { return default; }
		
		// TODO
		public static bool SettingSet(IlcaNetSessionSetting setting) { return default; }
		
		// TODO
		private static void CleanUpCore() { }
		
		// TODO
		private static void NetworkTransportInit() { }
		
		// TODO
		private static void GameFrontRnoInit() { }
		
		// TODO
		private static void StationIndexCasheInit() { }
		
		// TODO
		private static void SystemCallBackInit() { }
		
		// TODO
		private static void SystemCallBackFinal() { }
		
		// TODO
		private static void SessionEventUserCallbackInit() { }
		
		// TODO
		private static void SessionEventUserCallbackInitAll() { }
		
		// TODO
		private static void SessonOpenCloseInit() { }
		
		// TODO
		public static bool IsHost() { return default; }
		
		// TODO
		public static int ThisStationIndex() { return default; }
		
		// TODO
		public static int HostStationIndex() { return default; }
		
		// TODO
		public static int NumStation() { return default; }
		
		// TODO
		public static int NumGamer() { return default; }
		
		// TODO
		public static int PlayerNumMaxCurrentlySetting() { return default; }
		
		// TODO
		public static bool IsSessionOnStageInConnected() { return default; }
		
		// TODO
		private static bool SessionOnStageCheck(ref PiaPluginSession.SessionStatus session) { return default; }
		
		// TODO
		public static void MatchingBlockRelease() { }
		
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static uint GetSendUnreliableDataSizeMax() {
		    return 0;
		}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static uint SessionID() {
            return 0;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int CallbackQueueNum() {
            return 0;
        }
		
		public static uint ErrorResultGet() {
		    return 0;
		}
		
		// TODO
		public static PiaPlugin.Result ErrorResultGetForFamily() { return default; }
		
		// TODO
		public static uint SessionListSizeGet() { return default; }
		
		// TODO
		public static bool SessionListPropertyGet(uint index, ref IlcaNetSessionProperty pro) { return default; }
		
		// TODO
		public static bool SessionSearchRetryAsync() { return default; }
		
		// TODO
		public static bool SessionJoinAsync(uint index) { return default; }
		
		// TODO
		public static bool SessionJoinAsync(uint index, string password) { return default; }
		
		// TODO
		private static bool SessionJoinAsyncCore(uint index, string password, uint sessionId, GameState nextState) { return default; }
		
		// TODO
		public static bool SessionCreateAsync() { return default; }
		
		// TODO
		public static bool SessionCreateAsync(string password) { return default; }
		
		// TODO
		private static bool SessionCreateAsyncCore(string password, GameState nextState = GameState.GS_JoinProcess) { return default; }
		
		// TODO
		public static bool SessionRandomAsync() { return default; }
		
		// TODO
		public static bool SessionUpdateApplicationDataBufferAsync(byte[] appData, int appDataSize) { return default; }
		
		// TODO
		public static bool SessionCloseHostAsync([Optional] UserSessionOpenCloseAsyncCompleteCallback callback) { return default; }
		
		// TODO
		public static bool SessionOpenHostAsync([Optional] UserSessionOpenCloseAsyncCompleteCallback callback) { return default; }
		
		// TODO
		private static bool SessionOpenCloseHostAsyncCore(IlcaNetSessionOpenStatus nowstate, IlcaNetSessionOpenStatus targetstate) { return default; }
		
		// TODO
		private static bool SessionOpenCloseHostAsyncCompleted() { return default; }
		
		// TODO
		private static bool IsSessionOpenCloseHost(IlcaNetSessionOpenStatus state) { return default; }
		
		// TODO
		private static bool IsSessionToOpenCloseHost(IlcaNetSessionOpenStatus state) { return default; }
		
		// TODO
		private static bool IsSessionClose() { return default; }
		
		// TODO
		private static bool IsSessionOpen() { return default; }
		
		// TODO
		public static bool SessionLeaveRequestAsync() { return default; }
		
		// TODO
		public static bool SessionRestartRequestAsync() { return default; }
		
		// TODO
		private static bool SessionLeaveRequestAsync(IlcaNetSessionState state) { return default; }
		
		// TODO
		private static bool SessionLeaveDefaultCheck(IlcaNetSessionState state) { return default; }
		
		// TODO
		private static bool SessionLeaveAsyncCore(IlcaNetSessionState state) { return default; }
		
		// TODO
		private static bool NetGamerNameGet(PiaPluginSession.SessionEvent ev, ref string gamerName, ref byte nameStringLanguage) { return default; }
		
		// TODO
		private static bool CleanupRecoveryToLoggedIn() { return default; }
		
		// TODO
		private static bool CleanupRecoveryToLoggedIn2phase() { return default; }
		
		// TODO
		private static void DangerousEmergencyCall() { }
		
		// TODO
		[Conditional("INL1_DEBUG")]
		public static void DangerousEmergencyError(int level) { }
		
		// TODO
		private static void DangerousEmergencyErrorCore() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void AnalysisResultPrintCore() { }
		
		// TODO
		private static bool SessionFinalizeProcessMovingCheck() { return default; }
		
		// TODO
		private static bool EmergencyCheckFromFamilyClass() { return default; }
		
		// TODO
		private static bool NetworkFinalRequestCheck() { return default; }
		
		// TODO
		private static bool SessionLeaveRequestCheck() { return default; }
		
		// TODO
		private static void SessionStatusCheckForFamilyClass() { }
		
		// TODO
		private static IlcaNetSessionState UpdateCore() { return default; }
		
		// TODO
		private static void UpdateDispatchWorkerTh() { }
		
		// TODO
		private static bool UpdateDispatchWorkerSet(PiaPlugin.AsyncProcessId apid, bool PriorityMode2 = false) { return default; }
		
		// TODO
		private static void UpdateDispatchWorkerThSuspend() { }
		
		// TODO
		private static bool UpdateDispatchWorkerSetSuspend() { return default; }
		
		// TODO
		public static bool SuspendON() { return default; }
		
		// TODO
		public static bool SuspendOFFRequest() { return default; }
		
		// TODO
		public static bool SuspendOFF() { return default; }
		
		// TODO
		private static bool SuspendFinishCheck(bool first) { return default; }
		
		// TODO
		private static void UpdateDispatchCore(bool first) { }
		
		// TODO
		private static void DispatchAftre(bool first, List<PiaPluginSession.SessionEvent> sessionEventList) { }
		
		// TODO
		private static void SessionToTransportSet(bool first, List<PiaPluginSession.SessionEvent> sessionEventList) { }
		
		// TODO
		private static void NetStationBootCheck() { }
		
		// TODO
		private static void UpdateSwitchCore() { }
		
		// TODO
		private static bool IsAllNetworkAsyncCompleted() { return default; }
		
		// TODO
		private static void SessionStateSet(IlcaNetSessionState sessionEnum) { }
		
		// TODO
		private static IlcaNetSessionState SessionStateNow() { return default; }
		
		// TODO
		private static void GameStateChangeSet(GameState setState) { }
		
		// TODO
		private static void GameStateChangeSet(GameState setState, PiaPlugin.AsyncProcessId waitAsycId, GameState setNextState) { }
		
		// TODO
		private static GameState GameStateNow() { return default; }
		
		// TODO
		private static void CallBackExtension(List<PiaPluginSession.SessionEvent> sessionEventList, bool first) { }
		
		// TODO
		private static bool CallbackEventQueueCheck() { return default; }
		
		// TODO
		private static void CallbackEventQueueCore(in List<PiaPluginSession.SessionEvent> sessionEventList) { }
		
		// TODO
		private static void CallBackExtensionCore(PiaPluginSession.SessionEvent ev, int i, [Optional] string str) { }
		
		// TODO
		private static void CallBackExtensionCoreEventJoin(ref IlcaNetGamer gamer, PiaPluginSession.SessionEvent ev) { }
		
		// TODO
		private static void CallBackNetGamerLastEventLeave() { }
		
		// TODO
		private static void GameState_AsyncWaitCore() { }
		
		// TODO
		private static void GameState_NexPiaInitialize() { }
		
		// TODO
		private static void GameState_NetworkStartedUp() { }
		
		// TODO
		private static void GameState_NetworkStartedUp_NexCallBack(AsyncResult asyncResult) { }
		
		// TODO
		private static void GameState_NetworkStartedUp_after() { }
		
		// TODO
		private static void GameState_LoggedIn() { }
		
		// TODO
		private static void GameState_LoggedInAfter() { }
		
		// TODO
		private static void GameState_WaitWorker(GSWaitWorkerEnum mode) { }
		
		// TODO
		private static void GameState_LoggedInReturnStep() { }
		
		// TODO
		private static void GameState_SessionStartedUp() { }
		
		// TODO
		private static void CreateSessionSet(string password) { }
		
		// TODO
		private static void SearchSessionSet() { }
		
		// TODO
		private static void GameState_BrowseSession() { }
		
		// TODO
		private static void GameState_CreateOrJoinSessionBefore() { }
		
		// TODO
		private static void GameState_BrowseSessionAfter_InternetRandomAikotoba() { }
		
		// TODO
		private static int getproListCompIDIndex(getProListMod a, getProListMod b) { return default; }
		
		// TODO
		private static int getproListCompPlayerNumIndex(getProListMod a, getProListMod b) { return default; }
		
		// TODO
		private static void GameState_BrowseSessionAfter_LocalRandom2() { }
		
		// TODO
		private static bool OverPasswordMagicNumberIDCheck(ref byte[] c, int i) { return default; }
		
		// TODO
		private static uint OverPasswordSizeGet(ref byte[] c, int i) { return default; }
		
		// TODO
		private static bool OverPasswordCompare(ref byte[] c1, int i, ref byte[] c2, int j, uint size) { return default; }
		
		// TODO
		private static void ToGameFrontBeforeLocalRandom() { }
		
		// TODO
		private static void ToGameFront() { }
		
		// TODO
		private static void ToGameInit() { }
		
		// TODO
		private static void autoRetryRandomMatchmakeCounterReset() { }
		
		// TODO
		private static bool AutoRetryCheck(PiaPlugin.Result result) { return default; }
		
		// TODO
		private static void GameState_JoinProcessAll() { }
		
		// TODO
		private static bool InternetRandomMatchCheck() { return default; }
		
		// TODO
		private static bool InternetRandomAikotobaMatchCheck() { return default; }
		
		// TODO
		private static bool LocalRandomMatchCheck() { return default; }
		
		// TODO
		private static bool LanRandomMatchCheck() { return default; }
		
		// TODO
		private static void GameState_GameFrontBefore_LocalRandom() { }
		
		// TODO
		private static void GameState_GameFront() { }
		
		// TODO
		private static void GameState_Game() { }
		
		// TODO
		private static bool CheckSessionOpenCloseStatus() { return default; }
		
		// TODO
		private static void GameState_LogoutCore() { }
		
		// TODO
		private static void GameState_LogoutWaitWorker() { }
		
		// TODO
		private static void GameState_PiaFrameworkFinalize() { }
		
		// TODO
		private static void GameState_PiaFrameworkFinalizeWorkerTh() { }
		
		// TODO
		private static void GameState_PiaFrameworkFinalizeCoreAfter() { }
		
		// TODO
		private static void GameState_ErrorHandling(bool direct = false) { }
		
		// TODO
		private static void GameState_ErrorHandlingCoreToCrash() { }
		
		// TODO
		private static void GameState_ErrorHandlingCoreToError() { }
		
		// TODO
		private static void GameState_ErrorHandlingCoreViewer(PiaPlugin.Result res) { }
		
		// TODO
		private static void HandleError(PiaPlugin.Result errorResult) { }
		
		// TODO
		private static void HandleErrorCore() { }
		
		// TODO
		private static void GameState_HandleErrorWaitWorker() { }
		
		// TODO
		private static void GameState_HandleErrorWait() { }
		
		// TODO
		private static PiaPlugin.State MyConvertHandlingTypeToStat(PiaPlugin.HandlingType handle) { return default; }

		private enum GameState : int
		{
			GS_None = 0,
			GS_AsyncWait = 1,
			GS_NexLogOutWait = 2,
			GS_NexPiaInitialize = 3,
			GS_NetworkStartedUp = 4,
			GS_NetworkStartedUpNEX = 5,
			GS_LoggedIn = 6,
			GS_LoggedInWaitWorker = 7,
			GS_LoggedInReturnStep = 8,
			GS_LoggedInReturnWaitWorker = 9,
			GS_SessionStartedUp = 10,
			GS_BrowseSession = 11,
			GS_BrowseSessionAfter_LocalRandom = 12,
			GS_BrowseSessionAfter_InternetRandomAikotobaBefore = 13,
			GS_BrowseSessionAfter_InternetRandomAikotoba = 14,
			GS_CreateOrJoinSessionBefore = 15,
			GS_CreateOrJoinSession = 16,
			GS_JoinProcess = 17,
			GS_JoinProcessRandom = 18,
			GS_JoinProcess_LocalRandom = 19,
			GS_GameFrontBefore_LocalRandom = 20,
			GS_GameFront = 21,
			GS_Game = 22,
			GS_GameLeave = 23,
			GS_GameError = 24,
			GS_HandleErrorWait = 25,
			GS_HandleErrorWaitWorker = 26,
			GS_ErrorHandling = 27,
			GS_Logout = 28,
			GS_LogoutWaitWorker = 29,
			GS_PiaFrameworkFinalize = 30,
			GS_PiaFrameworkFinalizeAfter = 31,
			GS_Final = 32,
			GS_Crash = 33,
			GS_Max = 34,
		}

		private enum GameAsync : int
		{
			NoWork = 0,
			SessionOpenWait = 1,
			SessionCloseWait = 2,
		}

		public delegate void IlcaNetSessionFinalCallback();
		public delegate void IlcaNetSessionEventCallback(IlcaNetSessionEventCallbackType eve, int stationIndex);
		public delegate void UserSessionOpenCloseAsyncCompleteCallback(IlcaNetSessionOpenStatus nowOpenClose);

		private enum GSWaitWorkerEnum : int
		{
			To_GS_SessionStartedUp = 0,
			To_GS_LoggedIn = 1,
		}

		private class getProListMod
		{
			public uint id;
			public PiaPluginSession.SessionProperty pro;
			
			// TODO
			public getProListMod() { }
		}
	}
}