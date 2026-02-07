namespace Dpr.Battle.Logic
{
	public sealed class Section_AfterTokuseiChanged_Event : Section
	{
		public Section_AfterTokuseiChanged_Event(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description desc)
        {
            GetEventLauncher().Event_ChangeTokuseiAfter(desc.poke.GetID());
        }

		public class Description
		{
			public BTL_POKEPARAM poke;
		}

		public class Result { }
	}
}