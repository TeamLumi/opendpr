namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaAdditionalEffect_RankEffect : Section
	{
		public Section_WazaAdditionalEffect_RankEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		private bool isRankEffectOccur(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target)
		{
			this.m_pEventLauncher.Event_CheckAddRankEffectOccur();
			return false;
		}
		
		// TODO
		private void addRankEffect(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target) { }

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			
			public Description()
			{
				actionDesc = null;
				wazaParam = null;
				attacker = null;
				target = null;
			}
		}

		public class Result { }
	}
}