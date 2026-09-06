using System.ComponentModel;

namespace INL1
{
	public class PacketReader : IlcaNetPacket
	{
		protected ulong recvByte;
		protected int fromStationIndex;
		
		public PacketReader()
		{
			MyUserDataMax = 0x400;
			Reset();
		}
		
		~PacketReader()
		{
			// Empty
		}
		
		public virtual ulong RecvTotalBytes() {
		    return recvByte;
		}
		
		public virtual int FromStationIndex() {
		    return fromStationIndex;
		}
		
		// TODO
		public virtual int RemainBytes() { return default; }
		
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void RecvTotalBytesSet(uint num) {
		    recvByte = num;
		}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void FromStationIndexSet(int stationIndex) {
            this.fromStationIndex = stationIndex;
        }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void RecvDataMake(uint num) { }
		
		// TODO
		public virtual int ReadByteOut(out byte a)
		{
			a = default;
			return default;
		}
		
		// TODO
		public virtual int ReadByte(ref byte a) { return default; }
		
		// TODO
		public virtual int ReadU16Out(out ushort a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadU16(ref ushort a) { return default; }
		
		// TODO
		public virtual int ReadS16Out(out short a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadS16(ref short a) { return default; }
		
		// TODO
		public virtual int ReadU24Out(out uint a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadU24(ref uint a) { return default; }
		
		// TODO
		public virtual int ReadS24Out(out int a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadS24(ref int a) { return default; }
		
		// TODO
		public virtual int ReadU32Out(out uint a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadU32(ref uint a) { return default; }
		
		// TODO
		public virtual int ReadS32Out(out int a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadS32(ref int a) { return default; }
		
		// TODO
		public virtual int ReadU64Out(out ulong a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadU64(ref ulong a) { return default; }
		
		// TODO
		public virtual int ReadS64Out(out long a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadS64(ref long a) { return default; }
		
		// TODO
		public virtual int ReadFP16Out(out float a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadFP16(ref float a) { return default; }
		
		// TODO
		public virtual int ReadFP24Out(out float a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadFP24(ref float a) { return default; }
		
		// TODO
		public virtual int ReadFP32Out(out float a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadFP32(ref float a) { return default; }
		
		// TODO
		public virtual int ReadFP64Out(out double a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadFP64(ref double a) { return default; }
		
		// TODO
		public virtual int ReadObjectOut(out object a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadBytesOut(out byte[] a)
        {
            a = default;
            return default;
        }

        // TODO
        public virtual int ReadBytes(ref byte[] a) { return default; }
		
		// TODO
		public virtual int ReadBytes(ref byte[] a, uint index) { return default; }
		
		// TODO
		public unsafe virtual int ReadBytes(byte* a, int a_len, uint index) { return default; }
	}
}