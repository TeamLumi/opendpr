using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FreeFallStart : Section
	{
		public Section_FromEvent_FreeFallStart(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSucceeded = false;
			result.isFailMessageDisplayed = false;

			BTL_POKEPARAM attacker = GetPokeParam(description.attackerID);
			BTL_POKEPARAM target = GetPokeParam(description.targetID);

			if (target.IsDead())
			{
				return;
			}

			if (checkGuard(attacker, target, description.wazaParam))
			{
				result.isFailMessageDisplayed = true;
				return;
			}

			setFreeFallSick(attacker, target);
			result.isSucceeded = true;
		}

		private uint getWeight(BTL_POKEPARAM poke)
		{
			var weightDesc = new Section_FromEvent_GetWeight.Description();
			weightDesc.pokeID = poke.GetID();
			var weightResult = new Section_FromEvent_GetWeight.Result();
			var weightSection = new Section_FromEvent_GetWeight(GetCommonParam());
			weightSection.Execute(weightResult, in weightDesc);
			return weightResult.weight;
		}

		private void onMamoruSuccess(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam)
		{
			var desc = new Section_MamoruSuccess.Description();
			desc.attacker = attacker;
			desc.target = target;
			desc.wazaParam = wazaParam;
			var mamoruResult = new Section_MamoruSuccess.Result();
			var mamoruSection = new Section_MamoruSuccess(GetCommonParam());
			mamoruSection.Execute(mamoruResult, in desc);
		}

		private bool checkGuard(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam)
		{
			if (target.TURNFLAG_Get(BTL_POKEPARAM.TurnFlag.TURNFLG_MAMORU))
			{
				onMamoruSuccess(attacker, target, wazaParam);
				return true;
			}
			return false;
		}

		private void setFreeFallSick(BTL_POKEPARAM attacker, BTL_POKEPARAM target)
		{
			BTL_SICKCONT cont = new BTL_SICKCONT();
			GetServerCommandPutter().AddSick(target, WazaSick.WAZASICK_FREEFALL, in cont);
		}

		public class Description
		{
			public byte attackerID;
			public byte targetID;
			public WazaParam wazaParam;

			public Description()
			{
				wazaParam = null;
				attackerID = PokeID.INVALID;
				targetID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isSucceeded;
			public bool isFailMessageDisplayed;
		}
	}
}
