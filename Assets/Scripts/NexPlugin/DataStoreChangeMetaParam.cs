using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreChangeMetaParam
	{
		internal ulong dataId;
		internal DataStore.ModificationFlag modifiesFlag;
		internal string name;
		internal DataStorePermission accessPermission;
		internal DataStorePermission updatePermission;
		internal ushort period;
		internal ushort dataType;
		internal List<string> tags;
		internal List<byte> metaBinary;
		internal DataStorePersistenceTarget persistenceTarget;
		internal DataStore.DataStatus status;
		internal ulong updatePassword;
		internal DataStoreChangeMetaCompareParam compareParam;
		
		public DataStoreChangeMetaParam()
		{
			Reset();
		}
		
		// TODO
		public void SetDataId(ulong dataId_) { }
		
		public ulong GetDataId() {
		    return dataId;
		}
		
		public void SetModificationFlag(DataStore.ModificationFlag modificationFlag) {
		    this.modifiesFlag = modificationFlag;
		}
		
		public DataStore.ModificationFlag GetModificationFlag() {
		    return modifiesFlag;
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
		
		public void SetUpdatePassword(ulong updatePassword_) {
		    this.updatePassword = updatePassword_;
		}
		
		public ulong GetUpdatePassword() {
		    return updatePassword;
		}
		
		public void SetDataType(ushort dataType_) {
		    this.dataType = dataType_;
		}
		
		private ushort GetDataType() {
		    return dataType;
		}
		
		public void SetDataStatus(DataStore.DataStatus status_) {
		    this.status = status_;
		}
		
		public DataStore.DataStatus GetDataStatus() {
		    return status;
		}
		
		// TODO
		public void SetChangeMetaCompareParam(DataStoreChangeMetaCompareParam compareParam_) { }
		
		public DataStoreChangeMetaCompareParam GetChangeMetaCompareParam() {
		    return compareParam;
		}
		
		// TODO
		public void SetPersistenceTarget(DataStorePersistenceTarget persistenceTarget_) { }
		
		public DataStorePersistenceTarget GetPersistenceTarget() {
		    return persistenceTarget;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}