using System;
using Unity.Collections;

namespace Dpr.Battle.Logic
{
    public sealed class SendData : IDisposable
    {
        private unsafe SEND_DATA_BUFFER* m_buffer;

        public SendData(Allocator allocator = Allocator.Persistent)
        {
            unsafe
            {
                // TODO: Somehow figure out how to use Client.BattleCommandWork.BUFFER_SIZE?
                m_buffer = (SEND_DATA_BUFFER*)BattleUnmanagedMem.Malloc(10012, allocator);
                SEND_DATA_BUFFER.Clear(m_buffer);
            }
        }

        // TODO
        public void Dispose() { }

        public unsafe SEND_DATA_BUFFER* GetBuffer()
        {
        	return this.m_buffer;
        }

        public void Clear()
        {
            unsafe
            {
                SEND_DATA_BUFFER.Clear(m_buffer);
            }
        }

        public void CopyFrom(in SendData src)
        {
        	SEND_DATA_BUFFER.Copy(this.m_buffer,src + 0x10);
        }

        // TODO
        public unsafe void Store(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* data, uint dataSize) { }

        // TODO
        public unsafe void Store(in SEND_DATA_BUFFER* buffer) { }

        public ushort GetSerialNumber()
        {
        	SEND_DATA_BUFFER.GetSerialNumber(ref this.m_buffer);
        	return 0;
        }

        public ServerSequence GetServerSequence()
        {
        	SEND_DATA_BUFFER.GetServerSequence(ref this.m_buffer);
        	return (ServerSequence)0;
        }

        public ServerRequest GetServerRequest()
        {
        	SEND_DATA_BUFFER.GetServerRequest(ref this.m_buffer);
        	return (ServerRequest)0;
        }

        public unsafe void* GetData()
        {
        	SEND_DATA_BUFFER.GetData(this.m_buffer);
        	return default;
        }

        public uint GetDataSize()
        {
        	SEND_DATA_BUFFER.GetDataSize(ref this.m_buffer);
        	return 0;
        }

        public uint GetTotalSize()
        {
        	SEND_DATA_BUFFER.GetTotalSize(ref this.m_buffer);
        	return 0;
        }

        public string GetString()
        {
        	SEND_DATA_BUFFER.GetString(ref this.m_buffer);
        	return default;
        }
    }
}