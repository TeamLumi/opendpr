namespace NexPlugin
{
	public class DataStorePasswordInfo
	{
		internal ulong dataId;
		internal ulong accessPassword;
		internal ulong updatePassword;
		
		public DataStorePasswordInfo()
		{
			accessPassword = 0;
			updatePassword = 0;
			dataId = 0;
		}
		
		public ulong GetDataId() {
		    return dataId;
		}
		
		public ulong GetAccessPassword() {
		    return accessPassword;
		}
		
		public ulong GetUpdatePassword() {
		    return updatePassword;
		}
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}