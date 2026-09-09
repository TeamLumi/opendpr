namespace NexPlugin
{
	public class Ranking2RankData
	{
		internal ulong misc;
		internal ulong nexUniqueId;
		internal ulong principalId;
		internal uint rank;
		internal uint score;
		internal Ranking2CommonData commonData;
		
		public Ranking2RankData()
		{
			commonData = new Ranking2CommonData();
		}
		
		public uint GetRank() {
		    return rank;
		}
		
		public uint GetScore() {
		    return score;
		}
		
		public ulong GetPrincipalId() {
		    return principalId;
		}
		
		public ulong GetNexUniqueId() {
		    return nexUniqueId;
		}
		
		public Ranking2CommonData GetCommonData() {
		    return commonData;
		}
		
		public ulong GetMisc() {
		    return misc;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}