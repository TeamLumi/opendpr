namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaAdditionalEffect_User : Section
	{
		public Section_WazaAdditionalEffect_User(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			WazaParam wazaParam = description.wazaParam;

			if (attacker.IsDead())
			{
				return;
			}

			addRankEffect(attacker, wazaParam, description.actionDesc);
		}

		private void addRankEffect(BTL_POKEPARAM attacker, WazaParam wazaParam, ActionDesc actionDesc)
		{
			var desc = new Section_WazaAdditionalEffect_RankEffect.Description();
			desc.actionDesc = actionDesc;
			desc.wazaParam = wazaParam;
			desc.attacker = attacker;
			desc.target = attacker;

			var result = new Section_WazaAdditionalEffect_RankEffect.Result();
			var section = new Section_WazaAdditionalEffect_RankEffect(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
		}

		public class Result { }
	}
}
