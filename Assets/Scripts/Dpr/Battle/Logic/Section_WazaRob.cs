using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaRob : Section
	{
		public Section_WazaRob(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		private void event_WazaRob(BTL_POKEPARAM robPoke, BTL_POKEPARAM originalPoke, WazaNo waza)
		{
			this.m_pEventLauncher.Event_WazaRob();
		}
		
		// TODO
		private void getWazaParam(WazaParam pWazaParam, BTL_POKEPARAM attacker, WazaNo waza) { }
		
		// TODO
		private void registerTarget(PokeSet pPokeSet, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, BtlPokePos targetPos) { }
		
		// TODO
		private bool isFailedByKaihukuHuuji(BTL_POKEPARAM attacker, WazaParam wazaParam) { return default; }
		
		// TODO
		private void putFailedMessageByKaihukuHuuji(BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private bool isFailedByZigokuDuki(BTL_POKEPARAM attacker, WazaParam wazaParam) { return default; }
		
		// TODO
		private void putFailedMessageByZigokuDuki(BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private void wazaExec(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }

		public class Description
		{
			public WazaRobParam robParam;
			public BTL_POKEPARAM attacker;
			public WazaNo actWaza;
		}

		public class Result { }
	}
}