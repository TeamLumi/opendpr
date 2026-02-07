using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_CheckJuryoku : Section
	{
		public Section_FromEvent_CheckJuryoku(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			byte[] pokeIDArray = new byte[PokemonPosition.BTL_POS_NUM];
			getAllFrontPokeID(pokeIDArray, out uint pokeCount, description.userPokeID);

			for (uint i = 0; i < pokeCount; i++)
			{
				BTL_POKEPARAM poke = GetPokeParam(pokeIDArray[i]);
				if (poke.IsDead())
				{
					continue;
				}

				cancelSoraWoTobu(poke);
				freefallRelease(poke);
			}
		}

		private void getAllFrontPokeID(byte[] pokeIDArray, out uint pokeCount, byte basePokeID)
		{
			pokeCount = 0;
			POKECON pokeCon = GetBattleEnv().GetPokeCon();

			for (int i = 0; i < PokemonPosition.BTL_POS_NUM; i++)
			{
				byte pokeID = pokeCon.GetFrontPokeID((BtlPokePos)i);
				if (pokeID != PokeID.INVALID)
				{
					pokeIDArray[pokeCount] = pokeID;
					pokeCount++;
				}
			}
		}

		private void cancelSoraWoTobu(BTL_POKEPARAM poke)
		{
			if (poke.CONTFLAG_Get(ContFlag.CONTFLG_SORAWOTOBU))
			{
				GetServerCommandPutter().ResetContFlag(poke, ContFlag.CONTFLG_SORAWOTOBU);
				cureSick(poke, WazaSick.WAZASICK_FLYING);
			}
		}

		private void freefallRelease(BTL_POKEPARAM poke)
		{
			if (poke.CheckSick(WazaSick.WAZASICK_FREEFALL))
			{
				cureSick(poke, WazaSick.WAZASICK_FREEFALL);
			}
		}

		private void cureSick(BTL_POKEPARAM poke, WazaSick sick)
		{
			GetServerCommandPutter().CureSick(poke, sick, out _);
		}

		public class Description
		{
			public byte userPokeID;

			public Description()
			{
				userPokeID = PokeID.INVALID;
			}
		}

		public class Result { }
	}
}
