using INL1;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.NetworkUtils
{
    public class SessionConnector
    {
        private readonly uint[] DEFAULT_ATTRIBUTE_VALUE = new uint[IlcaNetSessionSetting.attributeMax];

        private Action<StartSessionResult> onCompleteStartSession;
        private Action<SessionEventData> onSessionEvent;
        private Action<SessionErrorType> onSessionError;
        private Action onFinishSession;
        private StartSessionResult sessionResult;
        private SessionEventData sessionEventData;
        private IlcaNetSessionSetting sessionSetting = new IlcaNetSessionSetting();
        private IlcaNetSessionState nowSessionState;
        private MonoBehaviour callObjPtr;
        private bool bRunningSession;
        private bool canCallOnFinishedSession = true;
        
        // TODO
        public void Initialize(MonoBehaviour callObj, Action<SessionEventData> onSessionEvent, Action<SessionErrorType> onSessionError, Action onFinishedSession) { }
        
        // TODO
        public void OnDestroy() { }
        
        // TODO
        public void ClearNetSetting() { }
        
        public bool IsConnect
        {
            get
            {
                switch (nowSessionState)
                {
                    case IlcaNetSessionState.SS_NoInit:
                    case IlcaNetSessionState.SS_Final:
                    case IlcaNetSessionState.SS_Crash:
                        return false;

                    default:
                        return true;
                }
            }
        }
        public bool IsDisconnect
        {
            get
            {
                switch (nowSessionState)
                {
                    case IlcaNetSessionState.SS_NoInit:
                    case IlcaNetSessionState.SS_GamingError:
                    case IlcaNetSessionState.SS_Final:
                    case IlcaNetSessionState.SS_Crash:
                        return true;

                    default:
                        return false;
                }
            }
        }
        public bool IsRunning { get => bRunningSession; }
        public IlcaNetSessionState SessionState { get => nowSessionState; }
        public bool IsSessionWait { get => nowSessionState == IlcaNetSessionState.SS_MatchingWait; }
        public IlcaNetSessionNetworkType NetworkType { get => sessionSetting.networkType; }
        
        // TODO
        private void ResetParam() { }
        
        public void SetCallOnFinishedSessionFlag(bool flag) {
            this.canCallOnFinishedSession = flag;
        }

        // TODO
        public void StartSession(NetworkParam networkParam, [Optional] Action<StartSessionResult> onCompleteStartSession) { }
        
        // TODO
        private bool CanPerformStartSession() { return default; }
        
        // TODO
        public void JoinRandomSession([Optional] Action<StartSessionResult> onSessionEventCallback) { }
        
        // TODO
        private bool CheckJoinSession() { return default; }
        
        // TODO
        public void SessionRestartRequestAsync([Optional] uint[] attributeValueArray, [Optional] uint[] attributeMinValueArray, [Optional] uint[] attributeMaxValueArray) { }
        
        // TODO
        private void SetSessionAttribute(uint[] attributeValueArray, uint[] attributeMinValueArray, uint[] attributeMaxValueArray) { }
        
        // TODO
        private bool CheckValidAttributeArray(uint[] value) { return default; }
        
        // TODO
        public bool LeaveSession() { return default; }
        
        // TODO
        public bool FinishSession() { return default; }
        
        // TODO
        public uint GetSessionListSize() { return default; }
        
        // TODO
        public void RefreshSessionList(Action<bool> onCompleteSearch) { }
        
        // TODO
        private IEnumerator IE_SearchSessionList(Action<bool> onCompleteSearch) { return default; }
        
        // TODO
        public IlcaNetSessionProperty GetSessionProperty(uint index) { return default; }
        
        // TODO
        public IlcaNetSessionProperty[] GetAllSessionProperty() { return default; }
        
        // TODO
        private bool CheckSessionStateWait() { return default; }
        
        // TODO
        private bool CheckProcessing() { return default; }
        
        // TODO
        public int SendTo(PacketWriter pw, IlcaNetPacketType sendType, int sendStationIndex, TransportType transportType = TransportType.Station) { return default; }
        
        // TODO
        public int SendAll(PacketWriter pw, IlcaNetPacketType sendType, TransportType transportType = TransportType.Station) { return default; }
        
        // TODO
        public void OnUpdate() { }
        
        // TODO
        private void OnChangeSessionState() { }
        
        // TODO
        private void OnChangeState_SS_MatchingWait() { }
        
        // TODO
        private void OnChangeState_SS_GamingFront() { }
        
        // TODO
        private void OnChangeState_SS_Gaming() { }
        
        // TODO
        private void OnChangeState_SS_GamingLeave() { }
        
        // TODO
        private void OnChangeState_SS_GamingError() { }
        
        // TODO
        private void OnChangeState_SS_Crash() { }
        
        // TODO
        private void OnChangeState_SS_Final() { }
        
        // TODO
        public void OnLateUpdate() { }
        
        // TODO
        private void CallCompleteStartSession(bool isSuccess, SessionErrorType errorType) { }
        
        // TODO
        private void OnSessionEventCallback(IlcaNetSessionEventCallbackType callbackType, int stationIndex) { }
        
        // TODO
        private bool CheckMySessionEvent(int statinIndex) { return default; }
        
        // TODO
        protected virtual void OnSessionFinalCallback() { }
        
        // TODO
        public IlcaNetTransport GetTransport(TransportType transportType, int _stationIndex = -1) { return default; }
    }
}