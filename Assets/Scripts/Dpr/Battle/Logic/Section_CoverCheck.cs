namespace Dpr.Battle.Logic
{
	public sealed class Section_CoverCheck : Section
	{
		public Section_CoverCheck(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			requestPokeChangeForServer();
		}

		private void requestPokeChangeForServer()
		{
			PokeChangeRequest pokeChangeRequest = GetPokeChangeRequest();
			pokeChangeRequest.RequestEmptyPos(GetBattleEnv().GetPosPoke());
		}

		public class Description { }

		public class Result { }
	}
}