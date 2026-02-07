namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetTurnFlag : Section
	{
		public Section_FromEvent_SetTurnFlag(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
            GetServerCommandPutter().SetTurnFlag(poke, description.flag);
            result.isSuccessed = true;
        }

		public class Description
		{
			public byte pokeID;
			public BTL_POKEPARAM.TurnFlag flag;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				flag = BTL_POKEPARAM.TurnFlag.TURNFLG_MAX;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}