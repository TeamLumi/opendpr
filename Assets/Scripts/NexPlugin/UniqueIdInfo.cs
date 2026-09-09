namespace NexPlugin
{
	public class UniqueIdInfo
	{
		internal ulong nexUniqueId;
		internal ulong nexUniqueIdPassword;
		
		public UniqueIdInfo()
		{
			nexUniqueId = 0;
		}
		
		public UniqueIdInfo(ulong nexUniqueId_, ulong nexUniqueIdPassword_)
		{
			nexUniqueId = nexUniqueId_;
			nexUniqueIdPassword = nexUniqueIdPassword_;
		}
		
		public void SetUniqueId(ulong nexUniqueId_) {
		    this.nexUniqueId = nexUniqueId_;
		}
		
		public ulong GetUniqueId() {
		    return nexUniqueId;
		}
		
		public void SetPassword(ulong nexUniqueIdPassword_) {
		    this.nexUniqueIdPassword = nexUniqueIdPassword_;
		}
		
		public ulong GetPassword() {
		    return nexUniqueIdPassword;
		}
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}