namespace Dpr.Battle.Logic
{
	public sealed class Section_DamageDrain_Core : Section
	{
		public Section_DamageDrain_Core(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		private ushort recalcDrainVolume(BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort drainHP)
		{
			this.m_pEventLauncher.Event_RecalcDrainVolume();
			return 0;
		}
		
		// TODO
		private bool recoverHP(BTL_POKEPARAM poke, ushort drainHP, bool skipSpFailCheck) { return default; }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public ushort drainHP;
			public bool skipSpFailCheck;
			
			public Description()
			{
				attacker = null;
				target = null;
				drainHP = 0;
				skipSpFailCheck = false;
			}
		}

		public class Result
		{
			public bool isHpRecovered;
		}
	}
}