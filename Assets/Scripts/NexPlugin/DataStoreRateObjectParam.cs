namespace NexPlugin
{
	public class DataStoreRateObjectParam
	{
		internal ulong accessPassword;
		internal int ratingValue;
		
		public DataStoreRateObjectParam()
		{
			ratingValue = 1;
			accessPassword = 0;
		}
		
		public void SetRatingValue(int ratingValue_) {
		    this.ratingValue = ratingValue_;
		}
		
		public int GetRatingValue() {
		    return ratingValue;
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