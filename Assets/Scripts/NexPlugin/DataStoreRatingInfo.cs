namespace NexPlugin
{
	public struct DataStoreRatingInfo
	{
		private long totalValue;
		private long initialValue;
		private uint count;
		private sbyte slot;
		
		public sbyte GetSlot() {
		    return slot;
		}
		
		public long GetTotalValue() {
		    return totalValue;
		}
		
		public uint GetCount() {
		    return count;
		}
		
		public long GetInitialValue() {
		    return initialValue;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}