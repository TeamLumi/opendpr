namespace NexPlugin
{
	public class DataStorePrepareUpdateParam
	{
		internal ulong dataId;
		internal ulong updatePassword;
		internal uint size;
		
		public DataStorePrepareUpdateParam()
		{
			size = 0;
			dataId = 0;
			updatePassword = 0;
		}
		
		public void SetDataId(ulong dataId_) {
		    this.dataId = dataId_;
		}
		
		public ulong GetDataId() {
		    return dataId;
		}
		
		public void SetSize(uint size_) {
		    this.size = size_;
		}
		
		public uint GetSize() {
		    return size;
		}
		
		public void SetUpdatePassword(ulong updatePassword_) {
		    this.updatePassword = updatePassword_;
		}
		
		public ulong GetUpdatePassword() {
		    return updatePassword;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}