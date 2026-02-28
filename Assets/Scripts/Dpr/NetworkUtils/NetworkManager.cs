using Dpr.Message;
using Dpr.SubContents;
using INL1;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using XLSXContent;

namespace Dpr.NetworkUtils
{
    [RequireComponent(typeof(IlcaNetComponent))]
    public class NetworkManager : SingletonMonoBehaviour<NetworkManager>
    {
        public static ReceivePacketCallback onReceivePacket;
        public static ReceivePacketExCallback onReceivePacketEx;
        public static SessionEventCallback onSessionEvent;
        public static FinishSessionCallback onFinishedSession;
        private Dictionary<int, string> sessionErrorLogTable = new Dictionary<int, string>();
        private Dictionary<int, NetworkData.SheetErrorDialogInfo> networkErrorDialogTable = new Dictionary<int, NetworkData.SheetErrorDialogInfo>();
        private bool processingInternetGo;
        private SessionConnector sessionConnector = new SessionConnector();
        private NetworkParam networkParam = new NetworkParam();
        private PacketReader packetReader = new PacketReader();
        private PacketWriter packetWriter = new PacketWriter();
        private PacketWriterRe packetWriterRe = new PacketWriterRe();
        private IlcaNetServerValidate.CheckRequest checkRequest = new IlcaNetServerValidate.CheckRequest();
        private IlcaNetServerValidate.CheckResponse checkResponse = new IlcaNetServerValidate.CheckResponse();
        private RequestValidateResult validateResult;
        private ValidateCheckResult singleValidateCheckResult;
        private ValidateCheckPluralResult pluralValidateCheckResult;
        private GMSTradeResult gmsTradeResult = new GMSTradeResult();
        private ErrorAppletResult appletResult = new ErrorAppletResult();
        private ShowMessageWindow showMsgWindow = new ShowMessageWindow();
        private int systemErrorDialogOpenCount;
        private ErrorCodeID systemErrorDialogCode = ErrorCodeID.NUM;

        // TODO
        public static void Reset() { }

        // TODO
        private void Start() { }

        // TODO
        private IEnumerator IE_Start() { return null; }

        // TODO
        private void InitCallbackParam() { }

        // TODO
        private void InitNotification() { }

        // TODO
        private void InitData() { }

        // TODO
        private void OnDestroy() { }

        // TODO
        public static void StartSessionRandomJoin(IlcaNetSessionNetworkType networkType, IlcaNetSessionGamingStartMode gamingStartMode, ushort gameMode, ushort playerNumMax, [Optional] Action<StartSessionResult> onCompleteStartSession) { }

        // TODO
        public static void StartSessionRandomJoin(IlcaNetSessionNetworkType networkType, IlcaNetSessionGamingStartMode gamingStartMode, ushort gameMode, ushort playerNumMax, bool bAutoSessionOpen, bool bAutoSessionClose, [Optional] Action<StartSessionResult> onCompleteStartSession) { }

        // TODO
        public static void StartSessionRandomJoin(IlcaNetSessionNetworkType networkType, IlcaNetSessionGamingStartMode gamingStartMode, ushort gameMode, ushort playerNumMax, string password, [Optional] Action<StartSessionResult> onCompleteStartSession, IlcaNetSessionCallbackLastEventLeave sessionCallbackLastEventLeave = 0) { }

        // TODO
        public static void StartSessionRandomJoin(IlcaNetSessionNetworkType networkType, IlcaNetSessionGamingStartMode gamingStartMode, ushort gameMode, ushort playerNumMax, string password, bool bAutoSessionOpen, bool bAutoSessionClose, [Optional] Action<StartSessionResult> onCompleteStartSession) { }

        // TODO
        public static void StartSessionRandomJoin(IlcaNetSessionNetworkType networkType, IlcaNetSessionGamingStartMode gamingStartMode, ushort gameMode, ushort playerNumMax, string password, bool bAutoSessionOpen, bool bAutoSessionClose, [Optional] uint[] attributeValueArray, [Optional] uint[] attributeMinValueArray, [Optional] uint[] attributeMaxValueArray, [Optional] Action<StartSessionResult> onCompleteStartSession) { }

        // TODO
        public static void StartGMSTrade([Optional] Action<bool> onCompleteInternetGo) { }

        // TODO
        private void DoStartSession([Optional] Action<StartSessionResult> onCompleteStartSession) { }

        // TODO
        public static void JoinSessionRandom([Optional] Action<StartSessionResult> onSessionEventCallback) { }

        // TODO
        private static bool IsAlreadyConnectInternet() { return false; }

        // TODO
        public static bool IsNetworkAvailable { get; }
        public static NetworkParam NetworkParam { get; }
        public static bool IsInternetMode { get; }

        public bool ProcessingInternetGo()
        {
        	if ((this.networkParam != null) && (this.networkParam.networkType == 1)) {
        	  return this.processingInternetGo;
        	}
        	return false;
        }

        // TODO
        public static void CallInternetGo(bool ngsLogin, bool isShowMessage, Action<bool, SessionErrorType> onFinishedInternetGo, bool freePass = false, bool isNetworkMode = false) { }

        // TODO
        private void OpenConfirmConnectMsg(Action onSelectYes, Action onSelectNo) { }

        // TODO
        private void DoInternetGo(bool ngsLogin, bool bIsSaveOnSuccess, bool isAlreadyConnect, bool isShowMessage, Action<bool, SessionErrorType> onFinishedInternetGo, bool freePass = false) { }

        // TODO
        private IEnumerator IE_SaveFirstConnect(Action onComplete) { return null; }

        // TODO
        public static void RestartRequestAsync([Optional] uint[] attributeValueArray, [Optional] uint[] attributeMinValueArray, [Optional] uint[] attributeMaxValueArray) { }

        // TODO
        public static bool IsConnect { get; }
        public static bool IsDisconnected { get; }
        public static IlcaNetSessionState SessionState { get; }
        public static bool IsCrash { get; }
        public static bool IsHost { get; }
        public int MyStationIndex { get; }
        public static PacketWriter PacketWriter { get; }
        public static PacketWriterRe PacketWriterRe { get; }

        // TODO
        public uint GetSessionNum() { return 0; }

        // TODO
        public IlcaNetSessionProperty GetSessionProperty(uint index) { return default; }

        // TODO
        public IlcaNetSessionProperty[] GetAllSessionProperties() { return default; }

        // TODO
        public void RefreshSessionList(Action<bool> onCompleteSearch) { }

        // TODO
        public static int NowGamerNum { get; }

        // TODO
        public bool IsJoinOtherPlayer() { return false; }

        // TODO
        public static bool IsMaxJoinPlayer { get; }
        public static int GetMaxStation { get; }

        // TODO
        public int GetHostStationIndex() { return 0; }

        // TODO
        public bool IsGamerActive(int stationIndex) { return false; }

        // TODO
        public static IlcaNetGamer GetGamerData(int stationIndex) { return default; }

        // TODO
        public string GetGamerName(int stationIndex, bool surroundFontTag = true) { return ""; }

        // TODO
        public string GetGamerName(int stationIndex, int cassetVersion, bool surroundFontTag = true) { return ""; }

        // TODO
        public MessageEnumData.MsgLangId GetGamerLangID(int stationIndex) { return MessageEnumData.MsgLangId.JPN; }

        // TODO
        public static int SendReliablePacket(PacketWriterRe packetWriterRe, int sendStationIndex, TransportType transportType = TransportType.Station) { return default; }

        // TODO
        public static int SendUnReliablePacket(PacketWriter packetWriter, int sendStationIndex, TransportType transportType = TransportType.Station) { return default; }

        // TODO
        public static int SendReliablePacketToAll(PacketWriterRe packetWriterRe, TransportType transportType = TransportType.Station) { return default; }

        // TODO
        public static int SendUnReliablePacketToAll(PacketWriter packetWriter, TransportType transportType = TransportType.Station) { return default; }

        // TODO
        public bool CloseSession() { return false; }

        // TODO
        public bool OpenSession() { return false; }

        // TODO
        public static bool LeaveSession() { return false; }

        // TODO
        public static bool FinishSession() { return false; }

        // TODO
        public void RequestValidateTrade(CoreParam coreParam, Action<ValidateCheckResult> onFinished) { }

        // TODO
        public void RequestValidateBattle(CoreParam[] coreParamArray, Action<ValidateCheckPluralResult> onFinished) { }

        // TODO
        public void RequestValidateGMS(CoreParam coreParam, Action<ValidateCheckResult> onFinished) { }

        // TODO
        private bool CheckValidateTargetData(CoreParam[] coreParamArray) { return false; }

        // TODO
        private void SettingCheckRequestData(CoreParam[] coreParamArray) { }

        // TODO
        private void RequestValidateCheck(IlcaNetServerValidate.CheckRequest cReq, Action<RequestValidateResult> onCompleteCheck) { }

        // TODO
        private void CheckUpdateValidatePublicKey() { }

        // TODO
        private ValidateResultID CheckIllegalResultData() { return default; }

        // TODO
        private bool HasCheckResponse() { return false; }

        // TODO
        public void DoGMSTrade(int dataPointNo, Action<GMSTradeResult> onComplete) { }

        // TODO
        public static bool SuspendOn() { return false; }

        // TODO
        public static bool SuspendOff() { return false; }

        // TODO
        public static void SetAutoLogoutControl(bool on) { }

        public void OnUpdate(float deltaTime)
        {
        	if (this.sessionConnector.bRunningSession != 0) {
        	  this.sessionConnector.OnUpdate();
        	  CheckReceivePacket();
        	}
        }

        // TODO
        public void CheckReceivePacket() { }

        // TODO
        private void CheckReceivePacketImpl(TransportType transportType, int receiveStationIndex, ReceivePacketCallback _onReceivePacket, ReceivePacketExCallback _onReceivePacketEx) { }

        private void OnLateUpdate(float deltaTime)
        {
        	if (this.sessionConnector.bRunningSession != 0) {
        	  this.sessionConnector.OnLateUpdate();
        	}
        }

        // TODO
        private void OnSessionEvent(SessionEventData sessionEvent) { }

        // TODO
        private void OnFinishedSession() { }

        // TODO
        private void OnSessionError(SessionErrorType errorType) { }

        // TODO
        public void SetupMasterData(NetworkData networkData) { }

        // TODO
        public static void ShowApplicationErrorDialog(ErrorCodeID errorCodeId, [Optional] Action<ErrorAppletResult> onCloseWindow) { }

        // TODO
        public static bool IsShowApplicationErrorDialog() { return false; }

        // TODO
        public static ErrorCodeID GetShowApplicationErrorCodeID() { return default; }

        // TODO
        private void OpenErrorDialog(uint errorCode, Action<ErrorAppletResult> onCloseWindow) { }

        // TODO
        private string GetErrorMessage(string msbtName, string labelName) { return ""; }

        // TODO
        private void EmitSessionErrorLog(SessionErrorType errorType) { }

        // TODO
        private void OnResume(int value) { }

        public delegate void ReceivePacketCallback(PacketReader pr);
        public delegate void ReceivePacketExCallback(PacketReader pr, TransportType transportType, int receiveStationIndex);
        public delegate void SessionEventCallback(SessionEventData result);
        public delegate void FinishSessionCallback();
    }
}