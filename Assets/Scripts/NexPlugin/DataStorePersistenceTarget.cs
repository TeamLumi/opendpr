namespace NexPlugin
{
	public class DataStorePersistenceTarget
	{
		internal ulong ownerId;
		internal ushort persistenceSlotId;
		
		public DataStorePersistenceTarget(ulong ownerId = 0, ushort persistenceSlotId = DataStore.INVALID_PERSISTENCE_SLOT_ID)
		{
			this.ownerId = ownerId;
			this.persistenceSlotId = persistenceSlotId;
		}
		
		public void SetOwnerId(ulong ownerId_) {
		    this.ownerId = ownerId_;
		}
		
		public ulong GetOwnerId() {
		    return ownerId;
		}
		
		public void SetPersistenceSlotId(ushort persistenceSlotId_) {
		    this.persistenceSlotId = persistenceSlotId_;
		}
		
		public ushort GetPersistenceSlotId() {
		    return persistenceSlotId;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public override bool Equals(object obj) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}