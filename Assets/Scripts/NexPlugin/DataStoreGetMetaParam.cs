namespace NexPlugin
{
	public class DataStoreGetMetaParam
	{
		internal ulong dataId;
		internal DataStorePersistenceTarget persistenceTarget;
		internal DataStore.ResultFlag resultOption;
		internal ulong accessPassword;
		
		public DataStoreGetMetaParam()
		{
			dataId = 0;
			persistenceTarget = new DataStorePersistenceTarget();
			resultOption = 0;
			accessPassword = 0;
		}
		
		// TODO
		public void SetDataId(ulong dataId_) { }
		
		public ulong GetDataId() {
		    return dataId;
		}
		
		// TODO
		public void SetPersistenceTarget(DataStorePersistenceTarget persistenceTarget_) { }
		
		public DataStorePersistenceTarget GetPersistenceTarget() {
		    return persistenceTarget;
		}
		
		public void SetResultOption(DataStore.ResultFlag resultOption_) {
		    this.resultOption = resultOption_;
		}
		
		public DataStore.ResultFlag GetResultOption() {
		    return resultOption;
		}
		
		public void SetAccessPassword(ulong accessPassword_) {
		    this.accessPassword = accessPassword_;
		}
		
		public ulong GetAccessPassword() {
		    return accessPassword;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}