using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNoEffect_SimpleSick : Section
    {
		public Section_CheckNoEffect_SimpleSick(in CommonParam commonParam): base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			checkNoEffect(description.wazaParam, description.attacker, description.targets);
		}

		private bool checkNoEffect(WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets)
		{
			WazaNo waza = wazaParam.wazaID;
			uint count = targets.GetCount();

			for (uint i = 0; i < count; i++)
			{
				BTL_POKEPARAM target = targets.Get(i);
				if (isNoEffect(attacker, target, waza))
				{
					targets.Remove(target);
					i--;
					count--;
				}
			}

			return count == 0;
		}

		private bool isNoEffect(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaNo waza)
		{
			WazaSick sick = WAZADATA.GetSick(waza);
			if (sick == WazaSick.WAZASICK_NONE)
			{
				return false;
			}

			BTL_SICKCONT sickCont;
			calc.MakeDefaultWazaSickCont(sick, attacker, out sickCont);

			return addSickCheckFail(target, attacker, sick, in sickCont);
		}

		private bool addSickCheckFail(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaSick sick, in BTL_SICKCONT sickCont)
		{
			var desc = new Section_AddSickCheckFail.Description();
			desc.attacker = attacker;
			desc.target = target;
			desc.sick = sick;
			desc.sickCont = sickCont;
			desc.sickCause = SickCause.WAZA_EFFECT_SICK;
			desc.overWriteMode = SickOverWriteMode.CANT;
			desc.isFailResultDisplay_ByBasicRules = false;
			desc.isFailResultDisplay_BySpecialFactors = false;
			desc.isOtherEffectDisplayed = false;
			var result = new Section_AddSickCheckFail.Result();
			new Section_AddSickCheckFail(GetCommonParam()).Execute(result, desc);

			return result.isFail;
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