namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Shrink : Section
	{
		public Section_FromEvent_Shrink(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSucceeded = shrink(description.pokeID, description.percentage);
		}

		private bool shrink(byte pokeID, byte percentage)
		{
			BTL_POKEPARAM poke = GetPokeParam(pokeID);
			if (poke.IsDead())
				return false;

			bool isShrink = GetEventLauncher().Event_CheckShrink(poke, percentage);
			if (isShrink)
			{
				poke.TURNFLAG_Set(BTL_POKEPARAM.TurnFlag.TURNFLG_SHRINK);
			}
			else
			{
				GetEventLauncher().Event_FailShrink(poke);
			}
			return isShrink;
		}

		public class Description
		{
			public byte pokeID;
			public byte percentage;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				percentage = 0;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}