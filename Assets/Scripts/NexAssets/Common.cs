using NexPlugin;
using nn;
using nn.account;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NexAssets
{
    public class Common : MonoBehaviour
    {
        // TODO: Finish cctor

        public const int NC_VERSION = 500;

        protected static string s_OperationPlatform;
        private static bool s_NexUpdateF;
        public static NEX_INIT_PARAM s_NexInitParam;
        protected static NexInitializer s_NexInitializer;
        protected static AsyncResult s_AutoLoginResult;
        protected static ASYNCSTATE s_AutoLoginState;
        protected static bool s_AutoLogout;
        protected static int s_AutoLogoutCount;
        protected static List<CORE_ARG> s_CoreArgList;
        private static LostConnectCallback m_LostConnectCB;
        private static NGSDisconnectCallback m_NGSDisconnectCB;
        protected static List<NgsFacadeInfo> s_NgsFacadeInfoList;
        protected static NgsFacadeInfo s_LastLoginNgsFacadeInfo;
        protected static IntPtr s_DefaultUser;
        private static UserHandle s_AutoLoginUser;
        public static bool s_updateAlive;
        public static string s_operatingSystem;
        private static Dictionary<int, FunctionInfo> FunctionInfos;
        private static List<ApiCallsFrequency> s_ApiCallsFrequencyList;

        // TODO
        private NEX_INIT_PARAM GetNexInitParam() { return default; }

        // TODO
        public static NP_NGSINFO GetNgsInfo() { return default; }

        // TODO
        public static NgsFacadeInfo GetLastLoginNgsFacadeInfo() { return default; }

        // TODO
        public static void SetDefaultUser(IntPtr pNgsFacade) { }

        // TODO
        public static IntPtr GetDefaultUser() { return IntPtr.Zero; }

        // TODO
        public static void SetAutoLoginUserHandle(UserHandle userHandle) { }

        // TODO
        public static UserHandle GetAutoLoginUserHandle() { return default; }

        // TODO
        public static bool GetAutoLoginResult(out ASYNCSTATE state, out AsyncResult result)
        {
            state = default;
            result = default;
            return default;
        }

        // TODO
        public bool IsAsyncStateError(ASYNCSTATE state) { return false; }

        // TODO
        protected void Awake() { }

        // TODO
        protected void Update() { }

        // TODO
        protected void LateUpdate() { }

        // TODO
        public static bool InitializeNex() { return false; }

        // TODO
        public static bool InitializeNex(uint pluginMemSize, NexPlugin.Common.ThreadMode threadMode, int coreNo = 1) { return false; }

        // TODO
        public static bool InitializeNexAsync([Optional] AsyncResultCB callback) { return false; }

        // TODO
        public static bool InitializeNexAsync(uint pluginMemSize, NexPlugin.Common.ThreadMode threadMode, [Optional, DefaultParameterValue(1)] int coreNo, [Optional] AsyncResultCB callback) { return false; }

        // TODO
        private static bool InitializeNexAsync(uint pluginMemSize, NexPlugin.Common.ThreadMode threadMode, int coreNo, NEX_INIT_ARG arg) { return false; }

        // TODO
        public static bool FinalizeNexAsync([Optional] AsyncResultCB callback) { return false; }

        // TODO
        public static bool FinalizeNex() { return false; }

        // TODO
        public ASYNCSTATE LoginAsync([Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE LoginAsync(NP_NGSINFO ngsInfo, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE LoginAsync(UserHandle userHandle, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE LoginAsync(UserHandle userHandle, NP_NGSINFO ngsInfo, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE LoginAsync(NetworkServiceAccountId nsaId, byte[] nsaIdToken, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE LoginAsync(NP_NGSINFO ngsInfo, NetworkServiceAccountId nsaId, byte[] nsaIdToken, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE LoginAsync(ref uint asyncId, NP_NGSINFO ngsInfo, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE LoginAsync(ref uint asyncId, UserHandle userHandle, NP_NGSINFO ngsInfo, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE LoginAsync(ref uint asyncId, NP_NGSINFO ngsInfo, NetworkServiceAccountId nsaId, byte[] nsaIdToken, [Optional] NexPlugin.NgsFacade.LoginCB callback) { return ASYNCSTATE.NONE; }

        // TODO
        public static ASYNCSTATE LogoutAsync([Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade) { return ASYNCSTATE.NONE; }

        // TODO
        public static void Wait() { }

        // TODO
        public ASYNCSTATE AcquireNexUniqueIdAsync([Optional] NexPlugin.Utility.AcquireNexUniqueIdCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE AcquireNexUniqueIdAsync_(AsyncResult asyncResult, CORE_ARG param) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE AcquireNexUniqueIdWithPasswordAsync([Optional] NexPlugin.Utility.AcquireNexUniqueIdWithPasswordCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE AcquireNexUniqueIdWithPasswordAsync_(AsyncResult asyncResult, CORE_ARG param) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE AssociateNexUniqueIdWithMyPrincipalIdAsync(UniqueIdInfo info, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE AssociateNexUniqueIdWithMyPrincipalIdAsync_(AsyncResult asyncResult, CORE_ARG param) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE AssociateNexUniqueIdsWithMyPrincipalIdAsync(List<UniqueIdInfo> info, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE AssociateNexUniqueIdsWithMyPrincipalIdAsync_(AsyncResult asyncResult, CORE_ARG param) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE GetAssociatedNexUniqueIdWithMyPrincipalIdAsync([Optional] NexPlugin.Utility.GetAssociatedNexUniqueIdWithMyPrincipalIdCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE GetAssociatedNexUniqueIdWithMyPrincipalIdAsync_(AsyncResult asyncResult, CORE_ARG param) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE GetAssociatedNexUniqueIdsWithMyPrincipalIdAsync([Optional] NexPlugin.Utility.GetAssociatedNexUniqueIdWithMyPrincipalIdListCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE GetAssociatedNexUniqueIdsWithMyPrincipalIdAsync_(AsyncResult asyncResult, CORE_ARG param) { return ASYNCSTATE.NONE; }

        // TODO
        public ASYNCSTATE GetIntegerSettingsAsync(uint index, [Optional] NexPlugin.Utility.GetIntegerSettingsCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE GetIntegerSettingsAsync_(AsyncResult asyncResult, CORE_ARG param) { return ASYNCSTATE.NONE; }

        // TODO
        public static bool IsValidNexUniqueId(ulong nexUniqueId) { return false; }

        // TODO
        public ASYNCSTATE TestConnectivityAsync([Optional] NexPlugin.NgsFacade.TestConnectivityCB callback, [Optional] IntPtr pNgsFacade) { return ASYNCSTATE.NONE; }

        // TODO
        public static ulong GetPrincipalId([Optional] IntPtr pNgsFacade) { return 0; }

        // TODO
        public static void SetConnectionLostCallback(LostConnectCallback callback) { }

        // TODO
        public static void SetNGSDisconnectCallback(NGSDisconnectCallback callback) { }

        // TODO
        protected ASYNCSTATE ExecAfterLogin(CORE_ARG coreArg) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE InitializeNexsInf(ref uint async_id) { return ASYNCSTATE.NONE; }

        // TODO
        private ASYNCSTATE GetLoginUserParam(UserHandle userHandle, out NetworkServiceAccountId nsaId, out byte[] tokenCache, bool autoLogin = false)
        {
            nsaId = default;
            tokenCache = default;
            return ASYNCSTATE.NONE;
        }

        // TODO
        private ASYNCSTATE NGSLoginInf(ref uint async_id) { return ASYNCSTATE.NONE; }

        // TODO
        private void SetAutoLoginResultError(Result res) { }

        // TODO
        protected static ASYNCSTATE GetAsyncState(bool ret) { return ASYNCSTATE.NONE; }

        // TODO
        private void CoreInitCB(AsyncResult asyncResult) { }

        // TODO
        private void CoreLoginCB(AsyncResult asyncResult, ulong pid, IntPtr pNgsFacade) { }

        // TODO
        private void CoreLostConnectCB(AsyncResult asyncResult) { }

        // TODO
        private void CoreLogoutCB(AsyncResult asyncResult) { }

        // TODO
        protected static int GetCallCount(FunctionInfo info, List<ApiCallsFrequency> list) { return 0; }

        protected bool ApiCallsFrequencyCheck(FunctionInfo api, List<ApiCallsFrequency> list) {
            return false;
        }

        private bool ApiCallsFrequencyCheck(int type) {
            return false;
        }

        // TODO
        protected static void NC_LOG(string str) { }

        // TODO
        protected static void NC_LOG(string format, object[] arg) { }

        public enum CALL_DISPATCH : int
        {
            UPDATE = 1,
            LATEUPDATE = 2,
        }

        public struct NEX_INIT_PARAM
        {
            public NP_NGSINFO ngsInfo;
            public uint pluginMemSize;
            public NexPlugin.Common.ThreadMode threadMode;
            public CALL_DISPATCH callDispatch;
            public uint dispatchTimeOut;
            public NexPlugin.Common.DispachFlag dispatchFlag;
            public bool autoLogin;
            public bool autoLogout;
            public int coreNo;
        }

        protected delegate ASYNCSTATE ExecAsyncFunc(AsyncResult asyncResult, CORE_ARG arg);
        public delegate void LostConnectCallback();
        public delegate void NGSDisconnectCallback(ulong principalId);

        public struct NgsFacadeInfo
        {
            public ulong principalId;
            public IntPtr pNgsFacade;
            public bool isLogin;
        }

        public struct NP_NGSINFO
        {
            public uint gameServerId;
            public string accessKey;
            public int timeOut;
        }

        public enum ASYNCSTATE : int
        {
            NONE = -1,
            INVALID = 0,
            INVALID_ARGUMENT = 1,
            PLUGINCALL_SUCCESS = 2,
            PLUGINCALL_ERROR = 3,
            NOT_NEXINIT = 4,
            NOT_LOGIN = 5,
            INIT_NEX_START = 6,
            INIT_NEX_ERROR = 7,
            NGS_USER_CANCEL = 8,
            NGS_USERHANDLE_ERROR = 9,
            NGS_ENSUREAVAILABLE_ERROR = 10,
            NGS_GETID_ERROR = 11,
            NGS_ENSURIDTOKENCACHE_ERROR = 12,
            NGS_LOADIDTOKENCACHE_ERROR = 13,
            NGS_LOGIN_START = 14,
            NGS_LOGIN_ERROR = 15,
        }

        protected class CORE_ARG
        {
            public AsyncResultNum asyncNum;
            public uint asyncId;
            public IntPtr pNgsFacade;
            public ExecAsyncFunc func;

            // TODO
            public T Clone<T>() { return default; }
        }

        private class NEX_INIT_ARG : CORE_ARG
        {
            public AsyncResultCB callback;
        }

        private class GETUID_ARG : CORE_ARG
        {
            public int timeOut;
            public NexPlugin.Utility.AcquireNexUniqueIdCB callback;
        }

        private class GETUIDWITHPASSWD_ARG : CORE_ARG
        {
            public int timeOut;
            public NexPlugin.Utility.AcquireNexUniqueIdWithPasswordCB callback;
        }

        private class ASCUIDWITHPID_ARG : CORE_ARG
        {
            public UniqueIdInfo info;
            public int timeOut;
            public AsyncResultCB callback;
        }

        private class ASCUIDWITHPIDLIST_ARG : CORE_ARG
        {
            public List<UniqueIdInfo> info;
            public int timeOut;
            public AsyncResultCB callback;
        }

        private class GETASCUIDWITHPID_ARG : CORE_ARG
        {
            public int timeOut;
            public NexPlugin.Utility.GetAssociatedNexUniqueIdWithMyPrincipalIdCB callback;
        }

        private class GETASCUIDWITHPIDLIST_ARG : CORE_ARG
        {
            public int timeOut;
            public NexPlugin.Utility.GetAssociatedNexUniqueIdWithMyPrincipalIdListCB callback;
        }

        private class GETINTEGERSETTINGS_ARG : CORE_ARG
        {
            public uint index;
            public int timeOut;
            public NexPlugin.Utility.GetIntegerSettingsCB callback;
        }

        protected struct ApiCallsFrequency
        {
            public int type;
            public float time;
        }

        protected struct FunctionInfo
        {
            public int type;
            public int limit;
            public int time;
            public string name;
        }

        private enum Functions : int
        {
            TestConnectivity = 0,
            AcquireNexUniqueId = 1,
            AcquireNexUniqueIdWithPassword = 2,
            AssociateNexUniqueIdWithMyPrincipalId = 3,
            AssociateNexUniqueIdWithMyPrincipalId2 = 4,
            GetAssociatedNexUniqueIdWithMyPrincipalId = 5,
            GetAssociatedNexUniqueIdWithMyPrincipalId2 = 6,
            GetIntegerSettings = 7,
        }
    }
}