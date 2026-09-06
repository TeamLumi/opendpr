namespace NexPlugin
{
	public class RankingChangeAttributesParam
	{
		internal ulong param;
		internal Ranking.ModificationFlag modificationFlag;
		internal byte group0;
		internal byte group1;
		
		public RankingChangeAttributesParam()
		{
			param = 0;
			modificationFlag = Ranking.ModificationFlag.MODIFICATION_FLAG_NONE;
			group0 = 0;
			group1 = 0;
		}
		
		public void SetModificationFlag(Ranking.ModificationFlag flag) {
		    this.modificationFlag = flag;
		}
		
		public Ranking.ModificationFlag GetModificationFlag() {
		    return modificationFlag;
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