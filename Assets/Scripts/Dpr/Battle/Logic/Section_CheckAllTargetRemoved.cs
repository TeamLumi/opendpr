namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckAllTargetRemoved : Section
	{
		public Section_CheckAllTargetRemoved(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            pResult.isFailed = (description.targets.GetAliveCount() == 0);
        }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targets;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				targets = null;
			}
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}