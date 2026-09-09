namespace NexPlugin
{
	public class RankingScoreData
	{
		internal ulong param;
		internal uint category;
		internal uint score;
		internal Ranking.OrderBy orderBy;
		internal Ranking.UpdateMode updateMode;
		internal byte group0;
		internal byte group1;
		
		public RankingScoreData()
		{
			param = 0;
			category = 0;
			score = 0;
			orderBy = Ranking.OrderBy.ORDER_BY_DESC;
			updateMode = Ranking.UpdateMode.UPDATE_MODE_NORMAL;
			group0 = 0;
			group1 = 0;
		}
		
		public uint GetCategory() {
		    return category;
		}
		
		public void SetCategory(uint category_) {
		    this.category = category_;
		}
		
		public void SetScore(uint score_) {
		    this.score = score_;
		}
		
		public uint GetScore() {
		    return score;
		}
		
		public void SetOrderBy(Ranking.OrderBy orderBy_) {
		    this.orderBy = orderBy_;
		}
		
		public Ranking.OrderBy GetOrderBy() {
		    return orderBy;
		}
		
		public void SetUpdateMode(Ranking.UpdateMode updateMode_) {
		    this.updateMode = updateMode_;
		}
		
		public Ranking.UpdateMode GetUpdateMode() {
		    return updateMode;
		}
		
		public void SetGroup0(byte group0_) {
		    this.group0 = group0_;
		}
		
		public byte GetGroup0() {
		    return group0;
		}
		
		public void SetGroup1(byte group1_) {
		    this.group1 = group1_;
		}
		
		public byte GetGroup1() {
		    return group1;
		}
		
		public void SetParam(ulong param_) {
		    this.param = param_;
		}
		
		public ulong GetParam() {
		    return param;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}