using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_InsertWazaAction : Section
	{
		public Section_FromEvent_InsertWazaAction(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isAdded = false;

			BTL_POKEPARAM poke = GetPokeParam(description.actPokeID);

			if (poke.IsDead())
			{
				return;
			}

			PokeAction action = new PokeAction();
			action.bpp = poke;
			action.actionCategory = PokeActionCategory.Fight;
			action.actionParam_Fight.waza = description.actWazaNo;
			action.actionParam_Fight.targetPos = description.targetPos;
			action.actionDesc.CopyFrom(description.actionDesc);
			action.fDone = false;

			action.priority = calcActionPriority(action);

			GetPokemonActionContainer().InsertAction(action);
			result.isAdded = true;
		}

		private uint calcActionPriority(PokeAction pokeAction)
		{
			Section_CalcActionPriority section = new Section_CalcActionPriority(GetCommonParam());
			Section_CalcActionPriority.Description desc = new Section_CalcActionPriority.Description();
			Section_CalcActionPriority.Result res = new Section_CalcActionPriority.Result();

			desc.pokeAction = pokeAction;

			section.Execute(res, desc);

			return res.priority;
		}

		public class Description
		{
			public ActionDesc actionDesc = new ActionDesc();
			public byte actPokeID;
			public WazaNo actWazaNo;
			public BtlPokePos targetPos;
			
			public Description()
			{
				actPokeID = PokeID.INVALID;
				actWazaNo = WazaNo.NULL;
				targetPos = BtlPokePos.POS_NULL;
			}
		}

		public class Result
		{
			public bool isAdded;
		}
	}
}