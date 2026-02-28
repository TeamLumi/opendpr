namespace Dpr.Battle.Logic
{
    public static class rec
    {
        private const int FALSE = 0;
        private const int TRUE = 1;

        public static byte MakeRecFieldTag(RecFieldType type, byte numClient, bool fChapter)
        {
        	var uVar1 = 0x80;
        	if (!fChapter) {
        	  uVar1 = 0;
        	}
        	return (byte)(uVar1 | ((int)type & 7) << 4 | numClient & 0xf);
        }

        public static void ReadRecFieldTag(byte tagCode, out FieldType type, out byte numClient, out bool fChapter)
        {
        	numClient = (byte)tagCode & 0xf;
        	type = (FieldType)((tagCode & 0xff) >> 4 & 7);
        	fChapter = (byte)(tagCode >> 7) & 1;
        }

        public static byte MakeClientActionTag(byte clientID, byte numAction)
        {
        	return (byte)(numAction | clientID << 5);
        }

        public static void ReadClientActionTag(byte tagCode, out byte clientID, out byte numAction)
        {
        	clientID = (byte)(tagCode >> 5) & 7;
        	numAction = (byte)tagCode & 0x1f;
        }

        public static byte MakeRecTimingCode(Timing timing, bool isRecordTargetData)
        {
        	var uVar1 = 0x80;
        	if (!isRecordTargetData) {
        	  uVar1 = 0;
        	}
        	return (byte)(uVar1 | (int)timing & 0x7f);
        }

        public static void ReadRecTimingCode(byte timingCode, ref Timing timing, ref bool isRecordTargetData)
        {
        	isRecordTargetData = (byte)(timingCode >> 7) & 1;
        	timing = (Timing)(timingCode & 0x7f);
        }

        public enum FieldType : int
        {
            BTL_RECFIELD_NULL = 0,
            BTL_RECFIELD_ACTION = 1,
            BTL_RECFIELD_BTLSTART = 2,
            BTL_RECFIELD_TIMEOVER = 3,
            BTL_RECFIELD_SIZEOVER = 4,
        }

        public enum Timing : int
        {
            RECTIMING_None = 0,
            RECTIMING_StartTurn = 1,
            RECTIMING_PokeInCover = 2,
            RECTIMING_PokeInChange = 3,
            RECTIMING_BtlIn = 4,
            RECTIMING_PokeChangeAfterFirstPokeIn = 5,
        }

        public enum HeaderIndex : int
        {
            HEADER_TIMING_CODE = 0,
            HEADER_FIELD_TAG = 1,
            HEADER_SIZE = 2,
        }

        public enum RecFieldType : int
        {
            RECFIELD_NULL = 0,
            RECFIELD_ACTION = 1,
            RECFIELD_BTLSTART = 2,
            RECFIELD_TIMEOVER = 3,
            RECFIELD_SIZEOVER = 4,
            RECFIELD_MAX = 5,
        }

        public sealed unsafe class Data
        {
            private ushort m_writePtr;
            private bool m_fSizeOver;
            private byte dmy;
            private byte* m_buf;

            public Data()
            {
                m_writePtr = 0;
                m_fSizeOver = false;
                dmy = 0;
                m_buf = (byte*)BattleUnmanagedMem.Malloc(BattleDefConst.BTLREC_OPERATION_BUFFER_SIZE);
            }

            // TODO
            public void Write(void* data, uint size) { }

            // TODO
            public Timing GetTimingCode(void* data) { return Timing.RECTIMING_None; }

            public bool IsCorrect()
            {
            	return !this.m_fSizeOver;
            }

            public void* GetDataPtr(ref uint size)
            {
            	size = (uint)this.m_writePtr;
            	return this.m_buf;
            }
        }

        public sealed unsafe class Reader
        {
            private byte* m_recordData;
            private uint m_dataSize;
            private bool m_fReadOver;
            private uint[] m_readPtr = new uint[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
            private byte*[] m_readBuf = new byte*[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];

            public void ResetError()
            {
                m_fReadOver = false;
            }

            public void SetDataSize(uint size)
            {
                m_dataSize = size;
            }

            public Reader()
            {
                var ptr = (byte*)BattleUnmanagedMem.Malloc(m_readBuf.Length * 64);
                for (int i=0; i<m_readBuf.Length; i++)
                    m_readBuf[i] = ptr + (i * 64);
            }

            // TODO
            public void Init(void* recordData, uint dataSize) { }

            public void Reset()
            {
            	if (0 < (int)this.m_readPtr.Length) {
            	  var uVar4 = 0;
            	  var uVar5 = this.m_readPtr.Length & 0xffffffff;
            	  do {
            	    if (uVar5 <= uVar4) {
            	    }
            	    var lVar1 = uVar4 * 4;
            	    uVar4 = uVar4 + 1;
            	    this.m_readPtr + lVar1[0] = 0;
            	    uVar5 = (ulong)this.m_readPtr.Length;
            	  } while ((long)uVar4 < (int)this.m_readPtr.Length);
            	}
            }

            // TODO
            public bool CheckBtlInCmd(byte clientID) { return false; }

            // TODO
            public BTL_ACTION_PARAM* ReadAction(byte clientID, out byte numAction, out bool fChapter, out bool isBtlInCmd)
            {
                numAction = 0;
                fChapter = false;
                isBtlInCmd = false;
                return null;
            }

            // TODO
            public uint GetTurnCount() { return 0; }

            // TODO
            public bool IsReadComplete(byte clientID) { return false; }
        }

        public sealed unsafe class SendTool
        {
            private static readonly int BUFSIZE = 1000;

            private byte m_writePtr;
            private byte m_clientBit;
            private byte m_numClients;
            private byte m_type;
            private bool m_fChapter;
            private bool m_fError;
            private byte* m_buffer;

            public SendTool()
            {
                m_buffer = (byte*)BattleUnmanagedMem.Malloc(BUFSIZE);
            }

            // TODO
            public void Init(bool fChapter) { }

            // TODO
            public byte* PutBtlInTiming(ref uint dataSize) { return null; }

            // TODO
            public byte* PutBtlInChapter(ref uint dataSize, bool fChapter) { return null; }

            // TODO
            public void PutSelActionData(byte clientID, BTL_ACTION_PARAM* action, byte numAction) { }

            // TODO
            public byte* FixSelActionData(Timing timingCode, ref uint dataSize) { return null; }

            // TODO
            public byte* PutTimeOverData(ref uint dataSize) { return null; }

            // TODO
            public void RestoreStart(void* data, uint dataSize) { }

            // TODO
            public bool RestoreFwd(ref uint rp, out byte clientID, out byte numAction, BTL_ACTION_PARAM* action)
            {
                clientID = 0;
                numAction = 0;
                action = null;
                return false;
            }
        }
    }
}