using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreMetaInfo
	{
		internal ulong dataId;
		internal ulong ownerId;
		internal uint size;
		internal string name;
		internal ushort dataType;
		internal ushort period;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal NpDateTime createdTime;
		internal NpDateTime updatedTime;
		internal DataStore.DataStatus status;
		internal uint referDataId;
		internal DataStore.DataFlag flag;
		internal NpDateTime expireTime;
		internal List<string> tags;
		internal List<DataStoreRatingInfo> ratingInfo;
		internal List<byte> metaBinary;
		
		public DataStoreMetaInfo()
		{
			dataId = 0;
			accessPermission = new DataStorePermission();
			updatePermission = new DataStorePermission();
			tags = new List<string>();
			ratingInfo = new List<DataStoreRatingInfo>();
			metaBinary = new List<byte>();
		}
		
		public ulong GetDataId() {
		    return dataId;
		}
		
		public ulong GetOwnerId() {
		    return ownerId;
		}
		
		public uint GetSize() {
		    return size;
		}
		
		public string GetName() {
		    return name;
		}
		
		public ushort GetDataType() {
		    return dataType;
		}
		
		public DataStorePermission GetAccessPermission() {
		    return accessPermission;
		}
		
		public DataStorePermission GetUpdatePermission() {
		    return updatePermission;
		}
		
		// TODO
		public NpDateTime GetCreatedTime() { return default; }
		
		// TODO
		public NpDateTime GetUpdatedTime() { return default; }
		
		public ushort GetPeriod() {
		    return period;
		}
		
		public DataStore.DataStatus GetDataStatus() {
		    return status;
		}
		
		public uint GetReferDataId() {
		    return referDataId;
		}
		
		public DataStore.DataFlag GetDataFlag() {
		    return flag;
		}
		
		// TODO
		public NpDateTime GetExpireTime() { return default; }
		
		public List<string> GetTags() {
		    return tags;
		}
		
		public List<DataStoreRatingInfo> GetRating() {
		    return ratingInfo;
		}
		
		public List<byte> GetMetaBinary() {
		    return metaBinary;
		}
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}