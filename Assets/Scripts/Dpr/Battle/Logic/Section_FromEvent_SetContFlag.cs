namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetContFlag : Section
	{
		public Section_FromEvent_SetContFlag(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			GetServerCommandPutter().SetContFlag(poke, description.flag);
			result.isSuccessed = true;
		}

		public class Description
		{
			public byte pokeID;
			public ContFlag flag;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				flag = ContFlag.CONTFLG_NULL;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}