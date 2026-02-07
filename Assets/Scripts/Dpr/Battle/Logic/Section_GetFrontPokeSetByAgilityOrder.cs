namespace Dpr.Battle.Logic
{
	public sealed class Section_GetFrontPokeSetByAgilityOrder : Section
	{
		public Section_GetFrontPokeSetByAgilityOrder(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			PokeSet pPokeSet = description.pPokeSet;

			// Store all front pokemon into the set
			storeFrontPoke(pPokeSet);

			// Sort by agility (highest speed first)
			sortByAgility(pPokeSet);
		}

		private void storeFrontPoke(PokeSet pPokeSet)
		{
			for (byte pos = 0; pos < (byte)PokemonPosition.BTL_POS_NUM; pos++)
			{
				byte pokeID = GetBattleEnv().GetPokeCon().GetFrontPokeID((BtlPokePos)pos);
				if (pokeID == PokeID.INVALID)
				{
					continue;
				}
				BTL_POKEPARAM poke = GetPokeParam(pokeID);
				if (!poke.IsFightEnable())
				{
					continue;
				}
				pPokeSet.Add(poke);
			}
		}

		private void sortByAgility(PokeSet pPokeSet)
		{
			var desc = new Section_SortByAgility.Description();
			desc.targets = pPokeSet;
			var result = new Section_SortByAgility.Result();
			var section = new Section_SortByAgility(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public PokeSet pPokeSet;
		}

		public class Result { }
	}
}
