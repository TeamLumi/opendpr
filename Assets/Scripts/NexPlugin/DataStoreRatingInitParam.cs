namespace NexPlugin
{
	public class DataStoreRatingInitParam
	{
		internal long initialValue;
		internal int rangeMin;
		internal int rangeMax;
		internal DataStore.RatingFlag flag;
		internal DataStore.RatingInternalFlag internalFlag;
		internal DataStore.RatingLockType lockType;
		internal short periodDuration;
		internal sbyte periodHour;
		internal sbyte slot;
		
		public DataStoreRatingInitParam()
		{
			flag = 0;
			internalFlag = 0;
			lockType = DataStore.RatingLockType.RATING_LOCK_NONE;
			periodDuration = 0;
			periodHour = 0;
			slot = 0;
			initialValue = 0;
			rangeMin = 0;
			rangeMax = 0;
		}
		
		public void SetInitialValue(long initialValue_) {
		    this.initialValue = initialValue_;
		}
		
		// TODO
		public void SetRangeMin(int min_) { }
		
		// TODO
		public void SetRangeMax(int max) { }
		
		// TODO
		public void SetLock(DataStoreRatingLockInitParam ratingLockInitParam) { }
		
		public void SetFlag(DataStore.RatingFlag flag_) {
		    this.flag = flag_;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}