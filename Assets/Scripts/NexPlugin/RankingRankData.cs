using System.Collections.Generic;

namespace NexPlugin
{
	public class RankingRankData
	{
		internal ulong principalId;
		internal uint order;
		internal ulong uniqueId;
		internal uint category;
		internal uint score;
		internal ulong param;
		internal NpDateTime updateTime;
		internal List<byte> commonData;
		internal byte group0;
		internal byte group1;
		
		public RankingRankData()
		{
			principalId = 0;
			order = 0;
			param = 0;
			uniqueId = 0;
			category = 0;
			score = 0;
			commonData = new List<byte>();
			updateTime = NpDateTime.Never;
		}
		
		public ulong GetPrincipalId() {
		    return principalId;
		}
		
		public ulong GetUniqueId() {
		    return uniqueId;
		}
		
		public uint GetOrder() {
		    return order;
		}
		
		public uint GetCategory() {
		    return category;
		}
		
		public uint GetScore() {
		    return score;
		}
		
		public byte GetGroup0() {
		    return group0;
		}
		
		public byte GetGroup1() {
		    return group1;
		}
		
		public ulong GetParam() {
		    return param;
		}
		
		public List<byte> GetCommonData() {
		    return commonData;
		}
		
		// TODO
		public NpDateTime GetUpdateTime() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}