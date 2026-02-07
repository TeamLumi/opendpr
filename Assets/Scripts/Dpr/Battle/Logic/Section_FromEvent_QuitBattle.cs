namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_QuitBattle : Section
	{
		public Section_FromEvent_QuitBattle(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.userPokeID);
			result.isSucceeded = escape(poke, description.isForceSuccess);
		}

		private bool escape(BTL_POKEPARAM poke, bool isForceSuccess)
		{
			if (poke.IsDead())
				return false;

			BTL_CLIENT_ID clientID = PokeID.PokeIdToClientId(poke.GetID());
			GetServerCommandPutter().AddEscapeInfo(clientID);
			return true;
		}

		public class Description
		{
			public byte userPokeID;
			public bool isForceSuccess;
			public bool isDisplayTokuseiWindow;
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				isForceSuccess = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}