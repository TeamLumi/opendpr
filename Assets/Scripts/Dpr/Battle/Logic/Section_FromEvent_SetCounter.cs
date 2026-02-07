namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetCounter : Section
	{
		public Section_FromEvent_SetCounter(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			GetServerCommandPutter().SetBppCounter(poke, (BTL_POKEPARAM.Counter)description.counterID, description.value);
		}

		public class Description
		{
			public byte pokeID;
			public byte counterID;
			public byte value;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				counterID = 0;
				value = 0;
			}
		}

		public class Result { }
	}
}