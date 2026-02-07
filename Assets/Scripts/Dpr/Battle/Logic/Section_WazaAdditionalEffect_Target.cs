using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaAdditionalEffect_Target : Section
	{
		public Section_WazaAdditionalEffect_Target(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			BTL_POKEPARAM defender = description.defender;
			WazaParam wazaParam = description.wazaParam;

			if (defender.IsDead())
			{
				return;
			}

			// Skip additional effects on substitute hits
			if (description.fMigawriHit)
			{
				return;
			}

			// Apply rank effect on target
			addRankEffect(description.actionDesc, wazaParam, attacker, defender);

			// Apply status condition on target
			addSick(wazaParam, attacker, defender);
		}

		private void addRankEffect(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target)
		{
			var desc = new Section_WazaAdditionalEffect_RankEffect.Description();
			desc.actionDesc = actionDesc;
			desc.wazaParam = wazaParam;
			desc.attacker = attacker;
			desc.target = target;

			var result = new Section_WazaAdditionalEffect_RankEffect.Result();
			var section = new Section_WazaAdditionalEffect_RankEffect(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void addSick(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target)
		{
			WazaNo waza = wazaParam.wazaID;

			// Get the status condition this move inflicts
			WazaSick sickID = WAZADATA.GetSick(waza);
			if (sickID == WazaSick.WAZASICK_NONE)
			{
				return;
			}

			// Check probability
			int sickPer = WAZADATA.GetSickPer(waza);
			if (sickPer <= 0)
			{
				return;
			}

			// Check special occurrence rate via event system
			uint finalPer = GetEventLauncher().Event_CheckSpecialWazaAdditionalPer(
				attacker.GetID(), target.GetID(), (uint)sickPer);
			if (!calc.IsOccurPer(finalPer))
			{
				return;
			}

			// Apply the status condition
			BTL_SICKCONT sickCont;
			calc.MakeDefaultWazaSickCont(sickID, attacker, out sickCont);

			var desc = new Section_AddSick.Description();
			desc.pokeID = attacker.GetID();
			desc.targetPokeID = target.GetID();
			desc.sickID = sickID;
			desc.sickCont = sickCont;
			desc.sickCause = SickCause.WAZA_EFFECT_SICK;
			desc.isFailResultDisplay = false;

			var result = new Section_AddSick.Result();
			var section = new Section_AddSick(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM defender;
			public uint damage;
			public bool fMigawriHit;
		}

		public class Result { }
	}
}
