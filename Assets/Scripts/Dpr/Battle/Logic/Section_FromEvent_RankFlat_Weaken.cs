namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RankFlat_Weaken : Section
	{
		public Section_FromEvent_RankFlat_Weaken(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			result.isSuccessed = poke.RankUpReset();
			if (result.isSuccessed)
			{
				GetServerCommandPutter().RankUpReset(description.pokeID);
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
			public bool isSuccessed;
		}
	}
}