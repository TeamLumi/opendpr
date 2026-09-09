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

        public unsafe SEND_DATA_BUFFER* GetBuffer() {
            return m_buffer;
        }

        public void Clear()
        {
            unsafe
            {
                SEND_DATA_BUFFER.Clear(m_buffer);
            }
        }

        // TODO
        public void CopyFrom(in SendData src) { }

        // TODO
        public unsafe void Store(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* data, uint dataSize) { }

        // TODO
        public unsafe void Store(in SEND_DATA_BUFFER* buffer) { }

        // TODO
        public ushort GetSerialNumber() { return 0; }

        // TODO
        public ServerSequence GetServerSequence() { return ServerSequence.BATTLE_START_SETUP; }

        // TODO
        public ServerRequest GetServerRequest() { return ServerRequest.NONE; }

        // TODO
        public unsafe void* GetData() { return null; }

        // TODO
        public uint GetDataSize() { return 0; }

        // TODO
        public uint GetTotalSize() { return 0; }

        // TODO
        public string GetString() { return null; }
    }
}