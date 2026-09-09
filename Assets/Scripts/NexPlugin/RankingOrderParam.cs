namespace NexPlugin
{
	public class RankingOrderParam
	{
		internal Ranking.OrderCalculation orderCalculation;
		internal Ranking.FilterGroupIndex groupIndex;
		internal byte groupNum;
		internal Ranking.TimeScope timeScope;
		internal uint offset;
		internal byte length;
		
		public RankingOrderParam()
		{
			orderCalculation = Ranking.OrderCalculation.ORDER_CALCULATION_113;
			groupIndex = Ranking.FilterGroupIndex.FILTER_GROUP_INDEX_NONE;
            timeScope = Ranking.TimeScope.TIME_SCOPE_ALL;
            offset = 0;
            groupNum = 0;
			length = 10;
		}
		
		public void SetOrderCalculation(Ranking.OrderCalculation orderCalculation_) {
		    this.orderCalculation = orderCalculation_;
		}
		
		public Ranking.OrderCalculation GetOrderCalculation() {
		    return orderCalculation;
		}
		
		public void SetFilterGroupIndex(Ranking.FilterGroupIndex groupIndex_) {
		    this.groupIndex = groupIndex_;
		}
		
		public Ranking.FilterGroupIndex GetFilterGroupIndex() {
		    return groupIndex;
		}
		
		public void SetFilterGroupNum(byte groupNum_) {
		    this.groupNum = groupNum_;
		}
		
		public byte GetFilterGroupNum() {
		    return groupNum;
		}
		
		public void SetTimeScope(Ranking.TimeScope timeScope_) {
		    this.timeScope = timeScope_;
		}
		
		public Ranking.TimeScope GetTimeScope() {
		    return timeScope;
		}
		
		public void SetOffset(uint offset_) {
		    this.offset = offset_;
		}
		
		public uint GetOffset() {
		    return offset;
		}
		
		public void SetLength(byte length_) {
		    this.length = length_;
		}
		
		public byte GetLength() {
		    return length;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}