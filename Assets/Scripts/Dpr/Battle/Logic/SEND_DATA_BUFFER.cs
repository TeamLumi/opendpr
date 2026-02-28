using Unity.Collections.LowLevel.Unsafe;

namespace Dpr.Battle.Logic
{
    public unsafe struct SEND_DATA_BUFFER
    {
        public const int SEND_BUFFER_SIZE = 10004;
        internal const ushort SEND_DATA_SERIAL_NUMBER_NULL = 0;
        internal const ushort SEND_DATA_SERIAL_NUMBER_MIN = 1;
        public Header header;
        public fixed byte data[SEND_BUFFER_SIZE];

        public static void Clear(SEND_DATA_BUFFER* buf)
        {
            buf->header.serverSeq = (ushort)ServerSequence.INVALID;
        }

        public static void Copy(SEND_DATA_BUFFER* dest, in SEND_DATA_BUFFER* src)
        {
            dest->header.serialNumber = src->header.serialNumber;
            dest->header.serverReq = src->header.serverReq;
            dest->header.size = src->header.size;
            dest->header.serverSeq = src->header.serverSeq;

            UnsafeUtility.MemCpy(dest->data, src->data, dest->header.size);
        }

        // TODO
        public static void Store(SEND_DATA_BUFFER* buf, ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* data, uint dataSize) { }

        public static unsafe ushort GetSerialNumber(in SEND_DATA_BUFFER* buf)
        {
        	return (ushort)(*(ushort *)buf);
        }

        // TODO
        public static ServerSequence GetServerSequence(in SEND_DATA_BUFFER* buf) { return ServerSequence.BATTLE_START_SETUP; }

        // TODO
        public static ServerRequest GetServerRequest(in SEND_DATA_BUFFER* buf) { return ServerRequest.NONE; }

        public static void* GetData(SEND_DATA_BUFFER* buf)
        {
        	return buf + 8;
        }

        // TODO
        public static uint GetDataSize(in SEND_DATA_BUFFER* buf) { return 0; }

        // TODO
        public static uint GetTotalSize(in SEND_DATA_BUFFER* buf) { return 0; }

        // TODO
        public static string GetString(in SEND_DATA_BUFFER* buf) { return null; }

        // TODO
        public static string GetString(void* inData, uint size) { return null; }

        public struct Header
        {
            public ushort serialNumber;
            public ushort serverReq;
            public ushort size;
            public ushort serverSeq;
        }
    }
}