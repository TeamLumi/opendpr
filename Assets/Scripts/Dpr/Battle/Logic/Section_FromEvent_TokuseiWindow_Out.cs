namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_TokuseiWindow_Out : Section
	{
		public Section_FromEvent_TokuseiWindow_Out(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			GetServerCommandPutter().TokWin_Out(description.pokeID);
			result.isVanished = true;
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
			public bool isVanished;
		}
	}
}