namespace Dpr.Battle.Logic
{
    public sealed class ServerCommandQueue
    {
        public const int MSGARG_MAX_NUM = 9;
        public const ushort INVALID_PTR_VALUE = 65535;
        public const uint QUE_READING_STATE_NULL = 4294967295;

        private uint m_writePtr;
        private uint m_readPtr;
        private unsafe byte* m_buffer;

        internal const byte RESERVE_INFO_SIZE = 3;

        private static readonly ServerCommandArgsFormat[] ServerCmdToFmtTbl = new ServerCommandArgsFormat[(int)ServerCommand.NUM]
        {
            ServerCommandArgsFormat.FMT_NULL,
            ServerCommandArgsFormat.FMT_1122byte,
            ServerCommandArgsFormat.FMT_1122byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_53bit_1byte,
            ServerCommandArgsFormat.FMT_53bit_1byte,
            ServerCommandArgsFormat.FMT_53bit,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_53bit_1byte,
            ServerCommandArgsFormat.FMT_53bit_1byte,
            ServerCommandArgsFormat.FMT_53bit_1byte,
            ServerCommandArgsFormat.FMT_53bit_1byte,
            ServerCommandArgsFormat.FMT_1x9byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_14byte,
            ServerCommandArgsFormat.FMT_1144byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_53bit_12byte,
            ServerCommandArgsFormat.FMT_5_5_14bit,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_111byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_55511bit_22byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_5_3_7_1bit_2byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_2byte,
            ServerCommandArgsFormat.FMT_2byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_144byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_144byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_5_5_14bit,
            ServerCommandArgsFormat.FMT_114byte,
            ServerCommandArgsFormat.FMT_114byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_55555bit_22byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1x7byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_114byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_114byte,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_1144byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_111byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_NULL,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_NULL,
            ServerCommandArgsFormat.FMT_555bit,
            ServerCommandArgsFormat.FMT_14byte,
            ServerCommandArgsFormat.FMT_111byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_144byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_4x8byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1144byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_22222byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_1122byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_2x8byte,
            ServerCommandArgsFormat.FMT_53bit,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1111byte,
            ServerCommandArgsFormat.FMT_1111byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_5353bit,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_53bit,
            ServerCommandArgsFormat.FMT_555555bit,
            ServerCommandArgsFormat.FMT_53bit,
            ServerCommandArgsFormat.FMT_555bit,
            ServerCommandArgsFormat.FMT_NULL,
            ServerCommandArgsFormat.FMT_4x8byte,
            ServerCommandArgsFormat.FMT_NULL,
            ServerCommandArgsFormat.FMT_2x7byte,
            ServerCommandArgsFormat.FMT_53bit,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_2byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_2byte,
            ServerCommandArgsFormat.FMT_12byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_112byte,
            ServerCommandArgsFormat.FMT_4byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_53bit,
            ServerCommandArgsFormat.FMT_556bit_222byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_11byte,
            ServerCommandArgsFormat.FMT_NULL,
            ServerCommandArgsFormat.FMT_2x7byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_22222byte,
            ServerCommandArgsFormat.FMT_MSG,
            ServerCommandArgsFormat.FMT_MSG,
            ServerCommandArgsFormat.FMT_MSG_SE,
            ServerCommandArgsFormat.FMT_MSG_SE,
            ServerCommandArgsFormat.FMT_1byte,
            ServerCommandArgsFormat.FMT_111byte,
        };

        private static byte SC_ARGFMT_GetArgCount(ServerCommandArgsFormat format)
        {
        	if ((int)format == 0x10) {
        	  return 9;
        	}
        	var bVar1 = (byte)9;
        	if ((int)format != 0x20) {
        	  bVar1 = (byte)((int)format & 0xf);
        	}
        	return (byte)(bVar1);
        }

        public ServerCommandQueue()
        {
            Initialize();

            unsafe
            {
                m_buffer = (byte*)BattleUnmanagedMem.Malloc(BattleServerConst.BTL_SERVERCMD_QUE_SIZE);
            }
        }

        public void Initialize()
        {
            m_writePtr = 0;
            m_readPtr = 0;
        }

        // TODO
        public unsafe void Copy(void* data, ushort dataLength) { }

        public unsafe void* GetData()
        {
        	return this.m_buffer;
        }

        public uint GetDataSize()
        {
        	return this.m_writePtr;
        }

        // TODO
        public bool IsContainActCommand(ushort startPos, ushort endPos) { return false; }

        // TODO
        public ServerCommand Read(int[] args, uint argsBufferSize, ref uint cmdReadState) { return ServerCommand.INVALID; }

        // TODO
        public ServerCommand Read(int[] args, uint argsBufferSize) { return ServerCommand.INVALID; }

        public bool IsReadFinished()
        {
        	return this.m_readPtr == this.m_writePtr;
        }

        // TODO
        public void Put_Common(ServerCommand cmd, int[] LegacyParamArray) { }

        // TODO
        public void Put_MsgImpl(ServerCommand cmd, int[] inArgs) { }

        // TODO
        public void Put_WazaSyncChapter() { }

        // TODO
        public ushort ReservePutPos(ServerCommand cmd) { return 0; }

        // TODO
        public void Put_ToReservedPos(ushort pos, ServerCommand cmd, int[] LegacyParamArray) { }

        // TODO
        public void Put_ToReservedPos_Msg(ushort pos, ServerCommand cmd, int[] inArgs) { }

        // TODO
        private void put_reserved_pos_core(ushort pos, ServerCommand cmd, int[] args, uint argsNum) { }

        public uint PushReadState()
        {
        	return this.m_readPtr;
        }

        public void PopReadState(uint state)
        {
        	this.m_readPtr = state;
        }

        // TODO
        public void ReplaceWithSkipCmd(uint pos) { }

        // TODO
        public void Put_ExArgStart(byte argsNum) { }

        // TODO
        public void Put_ExArgOnly(byte arg) { }

        // TODO
        public byte Read_ExArgOnly() { return 0; }

        // TODO
        public void Put_ExAssignClient_Start(BTL_CLIENT_ID clientID) { }

        // TODO
        public void Put_ExAssignClient_End() { }

        // TODO
        private void put_core(ServerCommand cmd, ServerCommandArgsFormat format, int[] args) { }

        // TODO
        private void read_core(ServerCommandArgsFormat format, int[] args) { }

        // TODO
        private void scque_put1byte(byte data) { }

        // TODO
        private void scque_put2byte(ushort data) { }

        // TODO
        private void scque_put3byte(uint data) { }

        // TODO
        private void scque_put4byte(uint data) { }

        // TODO
        private byte scque_read1byte() { return 0; }

        // TODO
        private ushort scque_read2byte() { return 0; }

        // TODO
        private uint scque_read3byte() { return 0; }

        // TODO
        private uint scque_read4byte() { return 0; }

        // TODO
        private byte pack1_2args(int arg1, int arg2, int bits1, int bits2) { return 0; }

        // TODO
        private uint pack_3args(int bytes, int arg1, int arg2, int arg3, int bits1, int bits2, int bits3) { return 0; }

        // TODO
        private uint pack_4args(int bytes, int arg1, int arg2, int arg3, int arg4, int bits1, int bits2, int bits3, int bits4) { return 0; }

        // TODO
        private uint pack_5args(int bytes, int arg1, int arg2, int arg3, int arg4, int arg5, int bits1, int bits2, int bits3, int bits4, int bits5) { return 0; }

        // TODO
        private void unpack1_2args(byte pack, int bits1, int bits2, int[] args, int idx_start) { }

        // TODO
        private void unpack_3args(int bytes, uint pack, int bits1, int bits2, int bits3, int[] args, int idx_start) { }

        // TODO
        private void unpack_4args(int bytes, uint pack, int bits1, int bits2, int bits3, int bits4, int[] args, int idx_start) { }

        // TODO
        private void unpack_5args(int bytes, uint pack, int bits1, int bits2, int bits3, int bits4, int bits5, int[] args, int idx_start) { }

        // TODO
        private ushort _que_replace_ex_cmd(ServerCommand reserveCmd, ServerCommand replaceCmd, byte exVarCount) { return 0; }

        // TODO
        public ServerCommand scque_readcmd_support_skip(ref uint cmdReadState) { return ServerCommand.INVALID; }
    }
}