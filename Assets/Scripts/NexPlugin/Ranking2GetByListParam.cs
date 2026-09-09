namespace NexPlugin
{
	public class Ranking2GetByListParam
	{
		internal uint category;
		internal uint offset;
		internal uint length;
		internal Ranking2.Ranking2GetOptionFlags optionFlags;
		internal Ranking2.Ranking2SortFlags sortFlags;
		internal byte numSeasonsToGoBack;
		
		public Ranking2GetByListParam()
		{
			numSeasonsToGoBack = 0;
			sortFlags = Ranking2.Ranking2SortFlags.NOTHING;
			category = 0;
			offset = 0;
			length = 10;
			optionFlags = Ranking2.Ranking2GetOptionFlags.NOTHING;
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