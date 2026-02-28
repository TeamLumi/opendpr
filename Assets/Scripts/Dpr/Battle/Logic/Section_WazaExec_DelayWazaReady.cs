namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_DelayWazaReady : Section
	{
		public Section_WazaExec_DelayWazaReady(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putWazaEffect(BtlPokePos attackerPos, BtlPokePos targetPos, in WazaParam pWazaParam) { }
		
		private void event_DecideDelayWaza(in BTL_POKEPARAM pAttacker)
		{
			this.m_pEventLauncher.Event_DecideDelayWaza(pAttacker);
		}

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public WazaParam pWazaParam;
			public BtlPokePos targetPos;
		}

		public class Result
		{
			public bool isReadyProcessed;
			public bool isWazaEnable;
			
			public Result()
			{
				isReadyProcessed = false;
				isWazaEnable = false;
			}
		}
	}
}