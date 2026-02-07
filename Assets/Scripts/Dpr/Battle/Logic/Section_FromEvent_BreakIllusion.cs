namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_BreakIllusion : Section
	{
		public Section_FromEvent_BreakIllusion(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			GetServerCommandPutter().UpdateIllusion();
			GetServerCommandPutter().Message(description.successMessage);
			result.isSucceeded = true;
		}

		public class Description
		{
			public byte targetPokeID;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				targetPokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}