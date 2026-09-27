using NexPlugin;
using nn;
using nn.account;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

namespace INL1
{
	public class IlcaNetBase
	{
		protected static MonoBehaviour inl_callobj = null;
		protected static bool isPlatformLibraryInitialized = false;
		protected static bool isPlatformLibraryFullInitialized = false;
		protected static bool isNetSessionInitialized = false;
		protected static bool isNetStationInitialized = false;
		protected static bool isEmergencyFinalizeRequest = false;
		protected static PiaPlugin.Result lastEmergencyResult = default;
		protected static IlcaNetSessionSetting netSetting = new IlcaNetSessionSetting();
		protected static IlcaNetSessionSetting netSettingBackup = new IlcaNetSessionSetting();
		protected static uint nowStationNumber = 0;
		protected static UserHandle netUserHandle;
		protected static int LocalCommunicationVersionNumber = 0;
		protected static bool isErrorViewerAsync = true;

		protected static volatile bool isErrorViewerDispNow = false;

		protected static bool isErrorViewerDispCancel = false;
		protected static bool isNamerakaMode = true;

		public const int MaxGamers = 16;
		protected const int WorkerThreadSleepTime = 16;

        protected static volatile bool isMainThreadDispatchActive = true;

		private static bool lastErrorViewerApplet = false;
		protected static int debugNetworkBadEmulationLevel = 0;
		protected static byte debugNatTraversalFailureRatioForHost = 0;
		protected static byte debugNatTraversalFailureRatioForClient = 0;
		protected static bool debugIsNatTypeCheckFailure = false;
		protected static bool debugIsDnsResolutionFailure = false;
		protected static IlcaNetUserRandomNumFunc userRandomNumLocalFunc = null;

		private const byte NexVersionMajor = 4;
		private const byte NexVersionMinor = 6;
		private const byte NexVersionMicro = 5;

		private static volatile ErrorMode modeErrorViewerWorker;
		private static PiaPlugin.Result resErrorViewerWorker;
		private static Result nnResultErrorViewerWorker;
		private static volatile uint svcode;
		private static volatile string svdialog;
		private static volatile string svscreen;
		private static volatile string svlang;
		protected static UniqueIdInfo netNexUIdInfo = new UniqueIdInfo();
		protected static ulong netNexUniqueId = 0;
		protected static ulong netNexUniqueIdPassword = 0;
		protected static string netNsaIDtoken = null;
		protected static UserHandle netNsaIDtokenUserHandle;
		private static AsyncResultCB GeneralNexInitialize2Func;
		
		// TODO
		public static void Init(int version) { }
		
		// TODO
		protected static void CallObjSet(MonoBehaviour callobj) { }
		
		// TODO
		protected static void EmergencyCall(PiaPlugin.Result result) { }
		
		// TODO
		protected static void EmergencyInit() { }
		
		// TODO
		protected static bool EmergencyCheck() { return default; }
		
		// TODO
		protected static void EmergencyFinal() { }
		
		// TODO
		protected static bool IsPlatformLibraryInitialized() { return default; }
		
		// TODO
		protected static bool IsNetSessionInitialized() { return default; }
		
		// TODO
		protected static bool IsNetStationInitialized() { return default; }
		
		// TODO
		public static void OnDestroy() { }
		
		// TODO
		public static uint MemoryUsage() { return default; }
		
		// TODO
		public static void NonBlockWorkerThreadUse(bool flag) { }
		
		// TODO
		public static void RandomNumLocalFuncSet([Optional] IlcaNetUserRandomNumFunc func) { }
		
		// TODO
		private static ushort RandomNumLocal() { return default; }
		
		// TODO
		public static void ErrorViewerAsycnSet(bool flag) { }
		
		// TODO
		public static void ErrorViewerDispCancel(bool flag) { }
		
		// TODO
		protected static PiaPlugin.Result PlatformInitialize() { return default; }
		
		// TODO
		protected static PiaPlugin.Result PlatformInitialize2() { return default; }
		
		// TODO
		protected static void ErrorViewer(PiaPlugin.Result result) { }
		
		// TODO
		protected static void ErrorViewer(Result nnRes) { }
		
		// TODO
		private static void ErrorViewerWorker() { }
		
		// TODO
		public static bool LastErrorViewerAppletGet() { return default; }
		
		// TODO
		public static void LastErrorViewerAppletSet(bool flag) { }
		
		// TODO
		public static bool ErrorViewerOriginal(uint code, string dialog, string screen, string lang) { return default; }
		
		// TODO
		private static void DisplayErrorAppletWorkerThread() { }
		
		// TODO
		protected static GeneraNexInitializeResult GeneralNexInitialize(AsyncResultCB func) { return default; }
		
		// TODO
		protected static GeneraNexInitializeResult GeneralNexInitialize2(AsyncResultCB func) { return default; }
		
		// TODO
		private static void GeneralNexInitialize2Callback(AsyncResult rsul) { }
		
		// TODO
		protected static bool IsNexServerConnected() { return default; }
		
		// TODO
		protected static void GeneraNexTerminateImmediatelySet() { }
		
		// TODO
		[Conditional("INL1_DEBUG")]
		public static void DebugLog(string msg) { }

		public delegate ushort IlcaNetUserRandomNumFunc();

		public class PinnedKey
		{
			private GCHandle m_Handle;
			private uint m_KeyDataSize;
			private byte[] m_KeyData;
			
			public PinnedKey(byte[] keyData)
			{
				m_KeyData = (byte[])keyData.Clone();
				m_Handle = GCHandle.Alloc(m_KeyData, GCHandleType.Pinned);
				m_KeyDataSize = (uint)keyData.Length;
			}
			
			~PinnedKey()
			{
				m_Handle.Free();
			}
			
			public IntPtr GetKeyDataPtr()
			{
				return m_Handle.AddrOfPinnedObject();
			}
			
			public uint GetKeyDataSize()
			{
				return m_KeyDataSize;
			}
		}

		private enum ErrorMode : int
		{
			PiaPluginResult = 0,
			nnResult = 1,
		}

		protected enum GeneraNexInitializeResult : int
		{
			AsyncStart = 0,
			AlreadyInit = 1,
			Error = 10,
			ErrorInit = 10,
			ErrorAsync = 11,
		}
	}
}