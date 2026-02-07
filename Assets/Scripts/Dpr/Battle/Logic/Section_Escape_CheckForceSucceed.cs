namespace Dpr.Battle.Logic
{
	public sealed class Section_Escape_CheckForceSucceed : Section
	{
		public Section_Escape_CheckForceSucceed(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            pResult.canEscape = GetEventLauncher().Event_SkipNigeruCalc(description.poke);
        }

		public class Description
		{
			public BTL_POKEPARAM poke;
			
			public Description()
			{
				poke = null;
			}
		}

		public class Result
		{
			public bool canEscape;
		}
	}
}