using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStorePreparePostParam
	{
		internal uint size;
		internal string name;
		internal ushort dataType;
		internal ushort period;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal DataStore.DataFlag flag;
		internal List<string> tags;
		internal Dictionary<sbyte, DataStoreRatingInitParam> ratingInitParams;
		internal List<byte> meta;
		internal DataStorePersistenceInitParam persistenceInitParam;
		
		public DataStorePreparePostParam()
		{
			Reset();
		}
		
		public void SetSize(uint size_) {
		    this.size = size_;
		}
		
		public uint GetSize() {
		    return size;
		}
		
		// TODO
		public void SetName(string name_) { }
		
		public string GetName() {
		    return name;
		}
		
		public void SetDataType(ushort dataType_) {
		    this.dataType = dataType_;
		}
		
		public ushort GetDataType() {
		    return dataType;
		}
		
		// TODO
		public void SetAccessPermission(DataStorePermission permission_) { }
		
		public DataStorePermission GetAccessPermission() {
		    return accessPermission;
		}
		
		// TODO
		public void SetUpdatePermission(DataStorePermission updatePermission_) { }
		
		public DataStorePermission GetUpdatePermission() {
		    return updatePermission;
		}
		
		public void SetDataFlag(DataStore.DataFlag flag_) {
		    this.flag = flag_;
		}
		
		public DataStore.DataFlag GetDataFlag() {
		    return flag;
		}
		
		public void SetPeriod(ushort period_) {
		    this.period = period_;
		}
		
		public ushort GetPeriod() {
		    return period;
		}
		
		// TODO
		public void SetTags(List<string> tags_) { }
		
		public List<string> GetTags() {
		    return tags;
		}
		
		// TODO
		public void SetRatingSetting(Dictionary<sbyte, DataStoreRatingInitParam> ratingInitParam) { }
		
		// TODO
		public void ClearRatingSetting() { }
		
		// TODO
		public bool AddRatingSetting(sbyte slot, DataStoreRatingInitParam ratingInitParam) { return default; }
		
		public Dictionary<sbyte, DataStoreRatingInitParam> GetRatingSetting() {
		    return ratingInitParams;
		}
		
		// TODO
		public void SetMetaBinary(List<byte> meta_) { }
		
		public List<byte> GetMetaBinary() {
		    return meta;
		}
		
		// TODO
		public void SetPersistenceInitParam(DataStorePersistenceInitParam persistenceInitParam_) { }
		
		public DataStorePersistenceInitParam GetPersistenceInitParam() {
		    return persistenceInitParam;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}