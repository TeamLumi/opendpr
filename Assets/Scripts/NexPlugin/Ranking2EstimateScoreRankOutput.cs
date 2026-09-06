namespace NexPlugin
{
	public struct Ranking2EstimateScoreRankOutput
	{
		internal uint rank;
		internal uint score;
		internal uint category;
		internal uint season;
		internal uint samplingRate;
		internal uint length;
		
		public uint GetRank() {
		    return rank;
		}
		
		public uint GetScore() {
		    return score;
		}
		
		public uint GetCategory() {
		    return category;
		}
		
		public uint GetSeason() {
		    return season;
		}
		
		public uint GetSamplingRate() {
		    return samplingRate;
		}
		
		public uint GetLength() {
		    return length;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}