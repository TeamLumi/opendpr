namespace Dpr.Battle.Logic
{
	public sealed class Section_DecrementPP : Section
	{
		public Section_DecrementPP(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            BTL_POKEPARAM poke = description.poke;
            byte wazaIdx = description.wazaIndex;
            byte volume = description.volume;

            if (poke.WAZA_GetPP(wazaIdx) > 0)
            {
                GetServerCommandPutter().DecrementPP(poke, wazaIdx, volume);
                pResult.isDecrement = true;
            }
        }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public byte wazaIndex;
			public byte volume;
			
			public Description()
			{
				poke = null;
				wazaIndex = 0;
				volume = 0;
			}
		}

		public class Result
		{
			public bool isDecrement;
			
			public Result()
			{
				isDecrement = false;
			}
		}
	}
}