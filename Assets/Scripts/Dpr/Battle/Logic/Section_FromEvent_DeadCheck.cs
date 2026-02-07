namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DeadCheck : Section
	{
		public Section_FromEvent_DeadCheck(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			result.isChecked = false;

			if (poke.IsDead())
			{
				return;
			}

			checkPokeDead(poke);
			result.isChecked = true;
		}

		private void checkPokeDead(BTL_POKEPARAM poke)
		{
			if (poke.GetValue(BTL_POKEPARAM.ValueID.BPP_HP) == 0)
			{
				GetEventLauncher().Event_BeforeDead(poke);
				GetServerCommandPutter().KillPokemon(poke, PokeID.INVALID, DamageCause.OTHER, 0);
				GetServerCommandPutter().Act_Dead(poke.GetID(), false);
				poke.Clear_ForDead();
			}
		}

		public class Description
		{
			public byte pokeID;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isChecked;
		}
	}
}