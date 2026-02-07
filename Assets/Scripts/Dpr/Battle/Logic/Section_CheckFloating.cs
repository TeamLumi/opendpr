namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckFloating : Section
	{
		public Section_CheckFloating(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            pResult.isFloating = GetEventLauncher().Event_CheckFloating(description.target, description.isIncludeHikouType);
        }

		public class Description
		{
			public BTL_POKEPARAM target;
			public bool isIncludeHikouType;
			
			public Description()
			{
				target = null;
				isIncludeHikouType = false;
			}
		}

		public class Result
		{
			public bool isFloating;
		}
	}
}