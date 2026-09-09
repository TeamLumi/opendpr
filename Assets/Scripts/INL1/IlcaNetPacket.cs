using System.ComponentModel;

namespace INL1
{
	public class IlcaNetPacket
	{
		public const uint SystemHeaderMax = 0;
		public const uint PayloadMax = 1024;
		public const uint PayloadMaxUn = 340;
		public const uint UserDataMax = 1024;
		public const uint UserDataMaxUn = 340;

		private uint counte;
		protected uint MyUserDataMax = UserDataMax;
		private byte[] systemHeader;
		private byte[] userData;
		private byte[] payload;
		private IlcaNetPacketType packetType;
		
		public IlcaNetPacket()
		{
			userData = new byte[UserDataMax];
			Reset();
		}
		
		~IlcaNetPacket()
		{
			// Empty
		}
		
		// TODO
		protected virtual void WriteBufferFast(byte a) { }
		
		// TODO
		protected virtual int WriteRemaining() { return default; }
		
		// TODO
		protected virtual void ReadBufferFast(ref byte a) { }
		
		// TODO
		protected virtual int ReadRemaining(ulong recvSize) { return default; }
		
		// TODO
		public virtual void Reset() { }
		
		public virtual uint UserDataSizeNow() {
		    return counte;
		}
		
		public virtual uint UserDataSizeMax() {
		    return MyUserDataMax;
		}
		
		// TODO
		protected virtual void PayloadSerialize() { }
		
		// TODO
		protected virtual void PayloadDeSerialize(ulong recvByte) { }
		
		// TODO
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ref byte[] UserDataBuffRef() { return ref userData; }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ref byte[] PayloadBuffRef() { return ref userData; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual uint PayloadBuffSizeNow() {
            return counte;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void PacketTypeSet(IlcaNetPacketType type) {
            packetType = type;
        }
		
		public virtual IlcaNetPacketType PacketTypeGet() {
		    return packetType;
		}
	}
}