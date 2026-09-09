namespace NexPlugin
{
	public class DataStoreRatingTarget
	{
		internal ulong dataId;
		internal sbyte slot;
		
		public DataStoreRatingTarget()
		{
			dataId = 0;
			slot = 0;
		}
		
		public void SetDataId(ulong dataId_) {
		    this.dataId = dataId_;
		}
		
		public ulong GetDataId() {
		    return dataId;
		}
		
		public void SetSlot(sbyte slot_) {
		    this.slot = slot_;
		}
		
		public sbyte GetSlot() {
		    return slot;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}