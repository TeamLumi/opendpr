namespace Dpr.Battle.Logic
{
	public sealed class Section_RecoverHP_CheckFailBase : Section
	{
		public Section_RecoverHP_CheckFailBase(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            pResult.isFailed = description.poke.IsHPFull();
        }

		public class Description
		{
			public BTL_POKEPARAM poke;
			
			public Description()
			{
				poke = null;
			}
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}