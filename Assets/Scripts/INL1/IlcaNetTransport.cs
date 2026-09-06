using System.ComponentModel;
using System.Diagnostics;

namespace INL1
{
	public class IlcaNetTransport : IlcaNetBase
	{
		private ushort myPort;
		protected int stationIndex = -1;
		protected ulong constantId;
		private static PiaPlugin.Result result;

		private static ulong[] ValidityConstantID = new ulong[17];

		private static int hostStationIndex = -1;
		private static int thisStationIndex = -1;

		private static ulong hostStationConstantID = 0;
		private static ulong thisStationConstantID = 0;

		public static ulong debug_SendPeakCount;
		public static ulong debug_RecvPeakCount;
		public static ulong debug_SendPeakByte;
		public static ulong debug_RecvPeakByte;
		public static ulong debug_SendSecCount;
		public static ulong debug_RecvSecCount;
		public static ulong debug_SendSecByte;
		public static ulong debug_RecvSecByte;
		private static ulong debug_SendCount;
		private static ulong debug_SendCountRe;
		private static ulong debug_SendByte;
		private static ulong debug_SendByteRe;
		private static ulong debug_SendCountPort;
		private static ulong debug_SendBytePort;
		private static ulong debug_SendToCount;
		private static ulong debug_SendToCountRe;
		private static ulong debug_SendToByte;
		private static ulong debug_SendToByteRe;
		private static ulong debug_RecvCount;
		private static ulong debug_RecvCountRe;
		private static ulong debug_RecvByte;
		private static ulong debug_RecvByteRe;
		private static ulong debug_SendOldCount;
		private static ulong debug_RecvOldCount;
		private static ulong debug_SendOldByte;
		private static ulong debug_RecvOldByte;

		private static int debugAnalysisIntervalCount = 0;

		private const int debugAnalysisInterval = 30;
		
		public IlcaNetTransport()
		{
			// Empty, declared explicitly
		}
		
		~IlcaNetTransport()
		{
			// Empty
		}
		
		// TODO
		[Conditional("INL1_DEBUG")]
		public static void DebugCountReset() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void DebugCountPrinf() { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void AnalysisInterval() { }
		
		// TODO
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StationAndConstantIdClear() { }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StationIndexSet(int host) {
            this.stationIndex = host;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ConstantIdSet(ulong cid) {
            this.constantId = cid;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StationIndexGet(int host) {
            return stationIndex;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ulong ConstantIdGet(ulong cid) {
            return constantId;
        }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void HostStationSet(int index, ulong constantID) { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ulong HostStationConstantIDGet() { return default; }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int HostStationIndexGet() { return default; }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ThisStationSet(int index, ulong constantID) { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ulong ThisStationConstantIDGet() { return default; }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int ThisStationIndexGet() { return default; }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ValidityConstantIDSet(int index, ulong constantId) { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ulong ValidityConstantIDGet(int index) { return default; }
		
		protected void MyPortSet(ushort port) {
		    this.myPort = port;
		}
		
		// TODO
		public virtual int Send(PacketWriter pw, IlcaNetPacketType type) { return default; }
		
		// TODO
		public virtual int SendPeriodic(PacketWriter pw) { return default; }
		
		// TODO
		protected virtual int SendCore(PacketWriter pw, IlcaNetPacketType type, bool notStrict = false) { return default; }
		
		// TODO
		public virtual int SendTo(PacketWriter pw, IlcaNetPacketType type, int sendStationIndex) { return default; }
		
		// TODO
		public virtual int Recv(ref PacketReader pr) { return default; }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void NetworkBadEmulationSetting(int level) { }

        // TODO
        [Conditional("INL1_DEBUG")]
        public static void InternetNatTraversalBadEmulationSetting(int percent) { }
	}
}