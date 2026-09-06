using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public class RankingCachedResult : RankingResult
	{
		internal uint maxLength;
		internal NpDateTime createdTime;
		internal NpDateTime expiredTime;
		
		public RankingCachedResult()
		{
			maxLength = 0;
			createdTime = NpDateTime.INVALID_DATE_TIME;
			expiredTime = NpDateTime.INVALID_DATE_TIME;
		}
		
		public uint GetMaxLength() {
		    return maxLength;
		}
		
		// TODO
		public NpDateTime GetCreatedTime() { return default; }
		
		// TODO
		public NpDateTime GetExpiredTime() { return default; }
		
		// TODO
		public LocalUpdateState LocalUpdate(RankingOrderParam orderParam, RankingScoreData scoreData, ulong pid, [Optional] [DefaultParameterValue(0ul)] ulong nexUniqueId, [Optional] NpDateTime utcCurrentTime, [Optional] List<byte> pCommonData) { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }

		public enum LocalUpdateState : int
		{
			UPDATE_SUCCESS = 0,
			UPDATE_FAILED = 1,
			UPDATE_ERROR = 2,
		}
	}
}