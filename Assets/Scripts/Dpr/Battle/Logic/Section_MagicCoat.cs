using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_MagicCoat : Section
	{
		public Section_MagicCoat(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void executeMagicCoat(byte robPokeID, byte targetPokeID, BtlPokePos targetPos, WazaNo waza) { }
		
		private void event_WazaReflect(BTL_POKEPARAM robPoke, BTL_POKEPARAM targetPoke, WazaNo waza)
		{
			this.m_pEventLauncher.Event_WazaReflect();
		}
		
		// TODO
		private void getWazaParam(WazaParam wazaParam, BTL_POKEPARAM attacker, WazaNo waza) { }
		
		// TODO
		private void registerTarget(PokeSet pokeSet, BTL_POKEPARAM attacker, WazaParam wazaParam, BtlPokePos targetPos) { }
		
		// TODO
		private void wazaExec(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }

		public class Description
		{
			public WazaNo waza;
			
			public Description()
			{
				waza = WazaNo.NULL;
			}
		}

		public class Result { }
	}
}