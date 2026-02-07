using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_Uncategory : Section
	{
		public Section_WazaExec_Category_Uncategory(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			WazaParam wazaParam = description.wazaParam;
			PokeSet targets = description.targets;

			WazaNo waza = wazaParam.wazaID;

			if (waza == WazaNo.SUKIRUSUWAPPU)
			{
				skillSwap(attacker, targets);
			}
			else if (waza == WazaNo.MIGAWARI)
			{
				createMigawari(attacker);
			}
		}

		private void skillSwap(BTL_POKEPARAM attacker, PokeSet targets)
		{
			var desc = new Section_SkillSwap.Description();
			desc.attacker = attacker;
			desc.targets = targets;
			desc.needFailMessageDisplay = true;
			desc.cause = TokuseiChangeCause.TOKUSEI_CHANGE_CAUSE_OTHER;

			var result = new Section_SkillSwap.Result();
			var section = new Section_SkillSwap(GetCommonParam());
			section.Execute(result, in desc);
		}

		private bool createMigawari(BTL_POKEPARAM attacker)
		{
			var desc = new Section_Migawari_Create.Description();
			desc.poke = attacker;

			var result = new Section_Migawari_Create.Result();
			var section = new Section_Migawari_Create(GetCommonParam());
			section.Execute(result, in desc);

			return result.isCreated;
		}

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
