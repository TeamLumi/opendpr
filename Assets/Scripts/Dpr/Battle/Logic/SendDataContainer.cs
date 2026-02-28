using System.Collections.Generic;

namespace Dpr.Battle.Logic
{
    public sealed class SendDataContainer
    {
        private List<SendData> m_buffer = new List<SendData>();
        private uint m_bufferNum;
        private uint m_addIndex;

        public SendDataContainer(uint bufferNum)
        {
            m_bufferNum = bufferNum;
            m_addIndex = 0;

            for (; bufferNum != 0; bufferNum--)
                m_buffer.Add(new SendData());

            ClearBuffer();
        }

        private void ClearBuffer()
        {
            m_addIndex = 0;
            for (int i=0; i<m_bufferNum; i++)
                m_buffer­[i].Clear();
        }

        // TODO
        public void Dispose() { }

        // TODO
        public void CopyFrom(in SendDataContainer srcContainer) { }

        // TODO
        public void AddData(in SendData dataBuffer) { }

        private void IncAddIndex()
        {
        	var uVar3 = 0;
        	if (this.m_bufferNum != 0) {
        	  uVar3 = this.m_addIndex + 1 / this.m_bufferNum;
        	}
        	this.m_addIndex = this.m_addIndex + 1 - uVar3 * this.m_bufferNum;
        }

        public bool IsDataExist(uint dataSerialNumber)
        {
        	var lVar1 = GetData();
        	return lVar1 != 0;
        }

        // TODO
        public SendData GetData(uint dataSerialNumber) { return null; }

        // TODO
        public SendData GetLatestData() { return null; }
    }
}