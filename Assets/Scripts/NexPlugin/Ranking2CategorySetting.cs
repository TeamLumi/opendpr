namespace NexPlugin
{
	public class Ranking2CategorySetting
	{
		internal uint minScore;
		internal uint maxScore;
		internal ushort lowestRank;
		internal byte maxSeasonsToGoBack;
		internal byte resetMode;
		internal byte resetHour;
		internal byte resetDay;
		internal ushort resetMonth;
		internal bool scoreOrder;
		
		public Ranking2CategorySetting()
		{
			// Empty, declared explicitly
		}
		
		public uint GetMinScore() {
		    return minScore;
		}
		
		public uint GetMaxScore() {
		    return maxScore;
		}
		
		public bool GetScoreOrder() {
		    return scoreOrder;
		}
		
		public uint GetLowestRank() {
		    return lowestRank;
		}
		
		public byte GetMaxSeasonsToGoBack() {
		    return maxSeasonsToGoBack;
		}
		
		public byte GetResetMode() {
		    return resetMode;
		}
		
		public byte GetResetHour() {
		    return resetHour;
		}
		
		public byte GetResetDay() {
		    return resetDay;
		}
		
		public ushort GetResetMonth() {
		    return resetMonth;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}