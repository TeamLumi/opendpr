using System.Collections.Generic;

namespace NexPlugin
{
	public class Ranking2Info
	{
		internal uint numRankedIn;
		internal uint lowestRank;
		internal int season;
		internal List<Ranking2RankData> rankDataList;
		
		public Ranking2Info()
		{
			rankDataList = new List<Ranking2RankData>();
		}
		
		public List<Ranking2RankData> GetRankDataList() {
		    return rankDataList;
		}
		
		public uint GetLowestRank() {
		    return lowestRank;
		}
		
		public uint GetNumRankedIn() {
		    return numRankedIn;
		}
		
		public int GetSeason() {
		    return season;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}