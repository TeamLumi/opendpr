namespace NexPlugin
{
	public class DataStoreRatingLog
	{
		internal NpDateTime lockExpirationTime;
		internal ulong pid;
		internal int ratingValue;
		internal bool isRated;
		
		public DataStoreRatingLog()
		{
			isRated = false;
		}
		
		public bool IsRated() {
		    return isRated;
		}
		
		public ulong GetPrincipalId() {
		    return pid;
		}
		
		public int GetRatingValue() {
		    return ratingValue;
		}
		
		// TODO
		public NpDateTime GetLockExpirationTime() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}