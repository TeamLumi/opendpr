namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DecrementPP : Section
	{
		public Section_FromEvent_DecrementPP(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;

			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			if (poke.IsDead() && !description.isDeadPokeEnable)
				return;

			result.isSuccessed = decrementPP(poke, description.wazaIdx, description.volume);

			if (result.isSuccessed && description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage);
			}
		}

		private bool decrementPP(BTL_POKEPARAM poke, byte wazaIndex, byte volume)
		{
			ushort pp = poke.WAZA_GetPP(wazaIndex);
			if (pp == 0)
				return false;

			GetServerCommandPutter().DecrementPP(poke, wazaIndex, volume);
			return true;
		}

		private void useItem(BTL_POKEPARAM poke)
		{
			GetServerCommandPutter().UseItemAct(poke);
		}

		public class Description
		{
			public byte pokeID;
			public byte wazaIdx;
			public byte volume;
			public bool isSurfacePP;
			public bool isDeadPokeEnable;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				wazaIdx = 0;
				volume = 0;
				isSurfacePP = false;
				isDeadPokeEnable = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}