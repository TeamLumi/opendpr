namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetPermFlag : Section
	{
		public Section_FromEvent_SetPermFlag(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
            GetServerCommandPutter().SetPermFlag(poke, description.flag);
        }

		public class Description
		{
			public byte pokeID;
			public BTL_POKEPARAM.PermFlag flag;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				flag = BTL_POKEPARAM.PermFlag.PERMFLAG_NULL;
			}
		}

		public class Result { }
	}
}