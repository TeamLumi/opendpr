namespace NexPlugin
{
	public class DataStorePersistenceInfo
	{
		internal ulong dataId;
		internal ulong principalId;
		internal ushort persistenceSlotId;
		
		public DataStorePersistenceInfo()
		{
			dataId = 0;
		}
		
		public ulong GetPrincipalId() {
		    return principalId;
		}
		
		public ushort GetPersistenceSlotId() {
		    return persistenceSlotId;
		}
		
		public ulong GetDataId() {
		    return dataId;
		}
		
		// TODO
		public bool IsValid() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}