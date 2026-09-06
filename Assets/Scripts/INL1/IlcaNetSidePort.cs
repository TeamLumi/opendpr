using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace INL1
{
	public class IlcaNetSidePort
	{
		public const uint DEFAULT_MAGICNUMBER = 572662306;
		public const int DEFAULT_MYPORT = 7099;
		public const int DEFAULT_SERVERPORT = 7100;

		private static Socket ssoc = null;
		private static IPEndPoint thisIP;
		private static int myport = DEFAULT_MYPORT;
		private static int serverPort = DEFAULT_SERVERPORT;
		private static Stopwatch sp = new Stopwatch();
		private static Stopwatch sp2 = new Stopwatch();
        private static Stopwatch sp3 = new Stopwatch();

        // TODO: There seems to be something weird here using DataMemoryBarriers in ARM64 which affects this one
        private static bool InitializeNow;

		private static uint magicNunber = 0x22222222;
		private static string Server = null;
		private static bool Enable = false;
		private static bool Suspend = false;
		private static byte[] sendbuff = new byte[0x800];
		private static byte[] recvbuff = new byte[0x800];
        private static EndPoint from = new IPEndPoint(IPAddress.Any, 0);
		private static EndPoint serverIP = null;
		private static int cnt0 = 0;

		private const int retryFrameCounter = 600;
		private const int MAX_CALLBACK_NUM = 255;

		private static IlcaNetSidePortServiceCallback[] inspsc = new IlcaNetSidePortServiceCallback[0x100];
		
		// TODO
		[Conditional("INL1_DEBUG")]
		public static void Start() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void Start(uint magic) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void Start(uint magic, int my_port) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void Start(uint magic, int my_port, string servern, int serverp) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void MagicNumberSetAndRestart(uint magic) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void Stop() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void SuspendON() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void SuspendOFF() { }
		
		public static bool IsGo() {
		    return false;
		}

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void Init() { }
		
		// TODO
		private static void SocketInitWorkerTh() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void InitRe() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void Exit() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void Final() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void MagicNumberRefGet(ref uint magic) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void SocketInit() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void LocalIPAndServerAddresGet() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void LocalIPAddresGet() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void BindIP(ref IPEndPoint thisIP) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void SendString(string msg, bool Broadcast = false) { }
		
		// TODO
		private static void SendServerIPRequest() { }
		
		// TODO
		private static IPEndPoint BroadcastAddressGet() { return default; }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void SendServer(byte id1, byte id2, byte[] stream, [Optional] IPEndPoint target) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        private static void SocketClose() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void Update() { }
		
		// TODO
		public static CallbackFuncSetEnum CallbackFuncSet(int id, IlcaNetSidePortServiceCallback callback) { return default; }
		
		// TODO
		private static bool CallbackFuncCall(byte id, byte[] stream) { return default; }

		public delegate void IlcaNetSidePortServiceCallback(byte[] bin);

		public enum CallbackFuncSetEnum : int
		{
			Success = 0,
            ArgumentError = -1,
            AlreadySetError = -2,
        }
	}
}