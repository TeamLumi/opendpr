using Pml.PokePara;

namespace Dpr.Demo
{
	public class ConditionParam
	{
		public byte[] PrevCondition = new byte[6]; // TODO: Find a proper constant for these?
		public byte[] NowCondition = new byte[6];
        public byte[] AddCondition = new byte[6];
        public Taste taste;
		public TasteJudge tasteJudge;
		
		public bool IsConditionUp(Condition condition)
		{
			if (condition < this.AddCondition.Length) {
			  return this.AddCondition + (int)condition[0] != 0;
			}
		}
		
		public bool IsConditionMax(Condition condition)
		{
			if (condition < this.PrevCondition.Length) {
			  return this.PrevCondition + (int)condition[0] == -1;
			}
		}
	}
}