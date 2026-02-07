using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExecEnd : Section
	{
		public Section_WazaExecEnd(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			WazaParam wazaParam = description.wazaParam;

			if (!description.isWazaLocked && !description.isWazaHide)
			{
				tameLockClear(attacker);
			}

			if (attacker.IsUsingFreeFall())
			{
				freefallRelease(attacker);
			}

			GetServerCommandPutter().UpdateWazaProcResult(
				attacker.GetID(),
				description.actTargetPos,
				(byte)WAZADATA.GetDamageType(wazaParam.wazaID),
				description.isWazaEffective,
				wazaParam.wazaID,
				description.orgWaza);

			event_EndWazaSeq(description.actionDesc, attacker, wazaParam.wazaID, description.isWazaEffective);
		}

		private void tameLockClear(BTL_POKEPARAM poke)
		{
			var desc = new Section_TameLockClear.Description();
			desc.poke = poke;

			var result = new Section_TameLockClear.Result();
			var section = new Section_TameLockClear(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void freefallRelease(BTL_POKEPARAM poke)
		{
			var desc = new Section_FreeFall_Release.Description();
			desc.attacker = poke;
			desc.canAppearSelf = true;
			desc.canAppearTarget = true;

			var result = new Section_FreeFall_Release.Result();
			var section = new Section_FreeFall_Release(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void event_EndWazaSeq(ActionDesc actionDesc, BTL_POKEPARAM attacker, WazaNo waza, bool isWazaEffective)
		{
			GetEventLauncher().Event_EndWazaSeq(attacker, waza, isWazaEffective, actionDesc);
		}

		public class Description
		{
			public ActionDesc actionDesc;
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public bool isPPUsed;
			public bool isWazaEffective;
			public bool isWazaLocked;
			public bool isWazaHide;
			public WazaNo orgWaza;
			public BtlPokePos actTargetPos;
		}

		public class Result { }
	}
}
