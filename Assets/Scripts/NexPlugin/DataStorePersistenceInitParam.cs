namespace NexPlugin
{
	public class DataStorePersistenceInitParam
	{
		internal ushort persistenceSlotId;
		internal bool deleteLastObject;
		
		public DataStorePersistenceInitParam(ushort persistenceSlotId = DataStore.INVALID_PERSISTENCE_SLOT_ID, bool deleteLastObject = true)
		{
			this.persistenceSlotId = persistenceSlotId;
			this.deleteLastObject = deleteLastObject;
		}
		
		public void SetPersistenceSlotId(ushort persistenceSlotId_) {
		    this.persistenceSlotId = persistenceSlotId_;
		}
		
		public ushort GetPersistenceSlotId() {
		    return persistenceSlotId;
		}
		
		public void SetDeleteLastObject(bool deleteLastObject_) {
		    this.deleteLastObject = deleteLastObject_;
		}
		
		public bool GetDeleteLastObject() {
		    return deleteLastObject;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}