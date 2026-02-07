using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CheckFail_2nd : Section
	{
		public Section_WazaExec_CheckFail_2nd(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isFailed = false;

			BTL_POKEPARAM attacker = description.attacker;
			WazaParam wazaParam = description.wazaParam;
			PokeSet targets = description.targets;

			WazaFailCause failCause = checkWazaFail(attacker, wazaParam, targets);
			if (failCause != WazaFailCause.NONE)
			{
				wazaExecFailed(attacker, wazaParam, failCause);
				pResult.isFailed = true;
			}
		}

		private WazaFailCause checkWazaFail(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets)
		{
			WazaFailCause cause = GetEventLauncher().Event_CheckWazaExecute(
				attacker, wazaParam.wazaID, EventID.WAZA_EXECUTE_CHECK_2ND, wazaParam, targets);
			return cause;
		}

		private void wazaExecFailed(BTL_POKEPARAM attacker, WazaParam wazaParam, WazaFailCause failCause)
		{
			var desc = new Section_WazaExec_Failed.Description();
			desc.pAttacker = attacker;
			desc.waza = wazaParam.wazaID;
			desc.failCause = failCause;

			var result = new Section_WazaExec_Failed.Result();
			var section = new Section_WazaExec_Failed(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targets;
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}
