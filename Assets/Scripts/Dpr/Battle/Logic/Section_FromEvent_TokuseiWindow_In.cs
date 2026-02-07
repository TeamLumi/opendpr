namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_TokuseiWindow_In : Section
	{
		public Section_FromEvent_TokuseiWindow_In(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			GetServerCommandPutter().TokWin_In(description.pokeID);
			result.isDisplayed = true;
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
			public bool isDisplayed;
		}
	}
}