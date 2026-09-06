namespace NexPlugin
{
	public class DataStoreTouchObjectParam
	{
		internal ulong dataId;
		internal ulong accessPassword;
		
		public DataStoreTouchObjectParam()
		{
			dataId = 0;
			accessPassword = 0;
		}
		
		public void SetDataId(ulong dataId_) {
		    this.dataId = dataId_;
		}
		
		public ulong GetDataId() {
		    return dataId;
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