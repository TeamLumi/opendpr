namespace NexPlugin
{
	public class Ranking2GetParam
	{
		internal ulong nexUniqueId;
		internal uint category;
		internal uint offset;
		internal uint length;
		internal ulong principalId;
		internal Ranking2.Ranking2GetOptionFlags optionFlags;
		internal Ranking2.Ranking2SortFlags sortFlags;
		internal Ranking2.Ranking2Mode mode;
		internal byte numSeasonsToGoBack;
		
		public Ranking2GetParam()
		{
			mode = Ranking2.Ranking2Mode.USER_RANKING;
			numSeasonsToGoBack = 0;
			category = 0;
			offset = 0;
			length = 10;
			nexUniqueId = 0;
			principalId = 0;
			optionFlags = Ranking2.Ranking2GetOptionFlags.NOTHING;
			sortFlags = Ranking2.Ranking2SortFlags.NOTHING;
		}
		
		public Ranking2.Ranking2Mode GetMode() {
		    return mode;
		}
		
		public void SetMode(Ranking2.Ranking2Mode mode_) {
		    this.mode = mode_;
		}
		
		public uint GetCategory() {
		    return category;
		}
		
		public void SetCategory(uint category_) {
		    this.category = category_;
		}
		
		public byte GetNumSeasonsToGoBack() {
		    return numSeasonsToGoBack;
		}
		
		public void SetNumSeasonsToGoBack(byte numSeasonsToGoBack_) {
		    this.numSeasonsToGoBack = numSeasonsToGoBack_;
		}
		
		public uint GetOffset() {
		    return offset;
		}
		
		public void SetOffset(uint offset_) {
		    this.offset = offset_;
		}
		
		public uint GetLength() {
		    return length;
		}
		
		public void SetLength(uint length_) {
		    this.length = length_;
		}
		
		public ulong GetPrincipalId() {
		    return principalId;
		}
		
		public void SetPrincipalId(ulong principalId_) {
		    this.principalId = principalId_;
		}
		
		public ulong GetNexUniqueId() {
		    return nexUniqueId;
		}
		
		public void SetNexUniqueId(ulong nexUniqueId_) {
		    this.nexUniqueId = nexUniqueId_;
		}
		
		public Ranking2.Ranking2SortFlags GetSortFlags() {
		    return sortFlags;
		}
		
		public void SetSortFlags(Ranking2.Ranking2SortFlags sortFlags_) {
		    this.sortFlags = sortFlags_;
		}
		
		public Ranking2.Ranking2GetOptionFlags GetOptionFlags() {
		    return optionFlags;
		}
		
		public void SetOptionFlags(Ranking2.Ranking2GetOptionFlags optionFlags_) {
		    this.optionFlags = optionFlags_;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}