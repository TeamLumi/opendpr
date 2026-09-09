using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public class DataStorePermission
	{
		internal DataStore.Permission permission;
		internal List<ulong> recipientIds;
		
		public DataStorePermission()
		{
			Reset();
		}
		
		public DataStorePermission(DataStore.Permission permission, [Optional] List<ulong> recipientIds)
		{
			this.permission = permission;
			this.recipientIds = recipientIds ?? new List<ulong>();
		}
		
		public void SetPermission(DataStore.Permission permission_) {
		    this.permission = permission_;
		}
		
		public DataStore.Permission GetPermission() {
		    return permission;
		}
		
		// TODO
		public void SetRecipientIds(List<ulong> recipientIds_) { }
		
		public List<ulong> GetRecipientIds() {
		    return recipientIds;
		}
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}