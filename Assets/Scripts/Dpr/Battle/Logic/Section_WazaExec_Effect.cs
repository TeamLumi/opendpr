namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Effect : Section
	{
		public Section_WazaExec_Effect(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.pAttacker;
			WazaParam wazaParam = description.pWazaParam;
			ActionDesc actionDesc = description.pActionDesc;

			if (description.isWazaValid)
			{
				WazaEffectParams wazaEffect = GetActionSharedData().wazaEffectParams;
				putWazaEffectCommand(wazaEffect, wazaParam, description.pQueReservePos);
				eventOnWazaEffective(attacker, wazaParam, actionDesc);
			}
			else
			{
				onNotEffective(attacker, wazaParam, actionDesc);
			}
		}

		private void putWazaEffectCommand(WazaEffectParams pWazaEffect, WazaParam wazaParam, WazaEffectReservedPos pQueReservePos)
		{
			if (pWazaEffect.IsEnable())
			{
				GetServerCommandPutter().WazaEffect(in wazaParam, pWazaEffect, in pQueReservePos);
			}
		}

		private void eventOnWazaEffective(BTL_POKEPARAM poke, WazaParam wazaParam, ActionDesc actionDesc)
		{
			GetEventLauncher().Event_WazaExeEnd_Common(poke.GetID(), wazaParam.wazaID, in actionDesc, EventID.WAZA_EXECUTE_EFFECTIVE);
		}

		private void onNotEffective(BTL_POKEPARAM poke, WazaParam wazaParam, ActionDesc actionDesc)
		{
			GetEventLauncher().Event_WazaExeEnd_Common(poke.GetID(), wazaParam.wazaID, in actionDesc, EventID.WAZA_EXECUTE_NO_EFFECT);
		}

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public ActionDesc pActionDesc;
			public WazaParam pWazaParam;
			public WazaEffectReservedPos pQueReservePos;
			public bool isWazaValid;

			public Description()
			{
				pAttacker = null;
				pActionDesc = null;
				pWazaParam = null;
				pQueReservePos = null;
				isWazaValid = false;
			}
		}

		public class Result { }
	}
}
