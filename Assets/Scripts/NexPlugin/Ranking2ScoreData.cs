namespace NexPlugin
{
	public class Ranking2ScoreData
	{
		internal uint category;
		internal uint score;
		internal ulong misc;
		
		public Ranking2ScoreData()
		{
			category = 0;
			score = 0;
			misc = 0;
		}
		
		public uint GetCategory() {
		    return category;
		}
		
		public void SetCategory(uint category_) {
		    this.category = category_;
		}
		
		public uint GetScore() {
		    return score;
		}
		
		public void SetScore(uint score_) {
		    this.score = score_;
		}
		
		public ulong GetMisc() {
		    return misc;
		}
		
		public void SetMisc(ulong misc_) {
		    this.misc = misc_;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}