namespace Dpr.Battle.Logic
{
	public sealed class Section_CantAction : Section
	{
		public Section_CantAction(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            GetServerCommandPutter().CantAction(description.poke);
        }

		public class Description
		{
			public BTL_POKEPARAM poke;
			
			public Description()
			{
				poke = null;
			}
		}

		public class Result { }
	}
}