using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class RankingGetRankingParam
	{
		[SerializeField]
		private uint category;
		[SerializeField]
		private NexPlugin.Ranking.RankingMode mode;
		[SerializeField]
		private NexPlugin.Ranking.StatsFlag statsflag = NexPlugin.Ranking.StatsFlag.STATS_FLAG_TOTAL;
		[SerializeField]
		private RankingOrderParam rankingOrderParam = new RankingOrderParam();
		
		public uint GetCategory() {
		    return category;
		}
		
		public NexPlugin.Ranking.RankingMode GetRankingMode() {
		    return mode;
		}
		
		// TODO
		public NexPlugin.Ranking.StatsFlag GetStatsFlag() { return default; }
		
		// TODO
		public NexPlugin.RankingOrderParam GetRankingOrderParam() { return default; }
	}
}