namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RankReset : Section
	{
		public Section_FromEvent_RankReset(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            result.isSuccessed = false;
            for (byte i = 0; i < description.pokeCount; i++)
            {
                BTL_POKEPARAM poke = GetPokeParam(description.pokeID[i]);
                poke.RankReset();
                GetServerCommandPutter().RankReset(description.pokeID[i]);
                result.isSuccessed = true;
            }
        }

		public class Description
		{
			public byte pokeCount;
			public byte[] pokeID = new byte[DefineConstants.BTL_POSIDX_MAX];
			
			public Description()
			{
				pokeCount = 0;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}