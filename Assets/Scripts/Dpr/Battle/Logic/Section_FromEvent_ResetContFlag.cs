namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ResetContFlag : Section
	{
		public Section_FromEvent_ResetContFlag(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			GetServerCommandPutter().ResetContFlag(poke, description.flag);
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