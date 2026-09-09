using NexPlugin;
using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStoreBaseParam
	{
		[SerializeField]
		private uint httpThreadPriority;
		[SerializeField]
		private uint httpBufferSize = 0x8000;
		[SerializeField]
		private uint timeoutBytesPerSecond = DataStore.DEFAULT_DATA_TRANSFER_TIMEOUT_BYTES_PER_SECOND;
		[SerializeField]
		[Range(0.0f, 3600000.0f)]
		private int minimumTimeoutMilliSecond = 60000;
		[SerializeField]
		private uint httpSendSocketBufferSize = 0x10000;
		[SerializeField]
		private uint httpRecvSocketBufferSize = 0x10000;

        public uint GetHttpThreadPrioritySetting() {
            return httpThreadPriority;
        }
		
		public uint GetHttpBufferSizeSetting() {
		    return httpBufferSize;
		}
		
		public uint GetTimeoutBytesPerSecondSetting() {
		    return timeoutBytesPerSecond;
		}
		
		public int GetMinimumTimeoutMilliSecondSetting() {
		    return minimumTimeoutMilliSecond;
		}
		
		public uint GetHttpSendSocketBufferSizeSetting() {
		    return httpSendSocketBufferSize;
		}
		
		public uint GetHttpRecvSocketBufferSizeSetting() {
		    return httpRecvSocketBufferSize;
		}
	}
}