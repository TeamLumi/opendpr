namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnCheck_Event : Section
	{
		public Section_TurnCheck_Event(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isExpGet = false;

			PokeSet pokeSet = new PokeSet();
			storeFrontPokeByAgilityOrder(pokeSet);

			uint count = pokeSet.GetCount();
			for (int i = 0; i < (int)count; i++)
			{
				BTL_POKEPARAM poke = pokeSet.Get((uint)i);

				if (poke.IsDead())
					continue;

				GetEventLauncher().Event_TurnCheck(poke.GetID(), description.eventID);

				checkPokeDead(poke);
			}

			pResult.isExpGet = checkExpGet();
		}

		private void storeFrontPokeByAgilityOrder(PokeSet pokeSet)
		{
			var desc = new Section_GetFrontPokeSetByAgilityOrder.Description();
			desc.pPokeSet = pokeSet;

			var result = new Section_GetFrontPokeSetByAgilityOrder.Result();
			var section = new Section_GetFrontPokeSetByAgilityOrder(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void checkPokeDead(BTL_POKEPARAM poke)
		{
			if (!poke.IsDead())
				return;

			var desc = new Section_CheckPokeDead.Description();
			desc.poke = poke;
			desc.isDeadMessageDisplay = true;

			var result = new Section_CheckPokeDead.Result();
			var section = new Section_CheckPokeDead(GetCommonParam());
			section.Execute(result, in desc);
		}

		private bool checkExpGet()
		{
			var desc = new Section_CheckExpGet.Description();
			var result = new Section_CheckExpGet.Result();
			var section = new Section_CheckExpGet(GetCommonParam());
			section.Execute(result, in desc);
			return result.isExpGet;
		}

		public class Description
		{
			public EventID eventID;

			public Description()
			{
				eventID = EventID.INVALID;
			}
		}

		public class Result
		{
			public bool isExpGet;
		}
	}
}
