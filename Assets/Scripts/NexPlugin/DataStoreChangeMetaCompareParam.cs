using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreChangeMetaCompareParam
	{
		internal DataStore.ComparisonFlag comparisonFlag;
		internal string name;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal ushort dataType;
		internal ushort period;
		internal List<string> tags;
		internal List<byte> metaBinary;
		internal DataStore.DataStatus status;
		
		public DataStoreChangeMetaCompareParam()
		{
			Reset();
		}
		
		public DataStoreChangeMetaCompareParam(DataStore.ComparisonFlag comparisonFlag, DataStoreMetaInfo metaInfo)
		{
			Set(comparisonFlag, metaInfo);
		}
		
		// TODO
		public void Set(DataStore.ComparisonFlag comparisonFlag_, DataStoreMetaInfo metaInfo_) { }
		
		public void SetComparisonFlag(DataStore.ComparisonFlag comparisonFlag_) {
		    this.comparisonFlag = comparisonFlag_;
		}
		
		public DataStore.ComparisonFlag GetComparisonFlag() {
		    return comparisonFlag;
		}
		
		// TODO
		public void SetName(string name_) { }
		
		public string GetName() {
		    return name;
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
		public void SetMetaBinary(List<byte> meta) { }
		
		public List<byte> GetMetaBinary() {
		    return metaBinary;
		}
		
		public void SetDataType(ushort dataType_) {
		    this.dataType = dataType_;
		}
		
		public ushort GetDataType() {
		    return dataType;
		}
		
		public void SetDataStatus(DataStore.DataStatus status_) {
		    this.status = status_;
		}
		
		public DataStore.DataStatus GetDataStatus() {
		    return status;
		}
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}