using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_SimpleRecover : Section
	{
		public Section_WazaExec_Category_SimpleRecover(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		private uint calcRecoverVolume(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaNo wazano)
		{
			this.m_pEventLauncher.Event_CalcWazaRecoverHP();
			return 0;
		}
		
		// TODO
		private void getRecoverMessage(StrParam pMessage, BTL_POKEPARAM pAttacker, BTL_POKEPARAM pTarget, WazaNo wazano) { }
		
		// TODO
		private bool recoverHP(BTL_POKEPARAM target, ushort recoverHP, in StrParam recoverMsg) { return default; }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				targets = null;
			}
		}

		public class Result { }
	}
}