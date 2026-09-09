using NexPlugin;
using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStoreRatingInitParam
	{
		[SerializeField]
		[Range(0.0f, DataStore.NUM_RATING_SLOT - 1.0f)]
		private sbyte slot;
		[SerializeField]
		private long initialValue;
		[SerializeField]
		private int rangeMin;
		[SerializeField]
		private int rangeMax;
		[SerializeField]
		private DataStore.RatingFlag flag;
		[SerializeField]
		private bool isUseMin;
		[SerializeField]
		private bool isUseMax;
		[SerializeField]
		private DataStoreRatingLockInitParam dataStoreRatingLockInitParam = new DataStoreRatingLockInitParam();
		
		public sbyte GetSlot() {
		    return slot;
		}
		
		// TODO
		public DataStoreRatingInitParam GetDataStoreRatingInitParam() { return default; }
	}
}