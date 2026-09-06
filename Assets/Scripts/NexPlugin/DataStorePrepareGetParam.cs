namespace NexPlugin
{
	public class DataStorePrepareGetParam
	{
		internal ulong dataId;
		internal ulong accessPassword;
		internal DataStorePersistenceTarget persistenceTarget;
		
		public DataStorePrepareGetParam()
		{
			dataId = 0;
			persistenceTarget = new DataStorePersistenceTarget();
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