namespace Dpr.Battle.Logic
{
	public sealed class Section_Shrink : Section
	{
		public Section_Shrink(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			pResult.isSuccess = GetEventLauncher().Event_CheckShrink(description.target, description.percentage);
			if (pResult.isSuccess)
			{
				description.target.TURNFLAG_Set(BTL_POKEPARAM.TurnFlag.TURNFLG_SHRINK);
			}
		}

		public class Description
		{
			public BTL_POKEPARAM target;
			public uint percentage;
			
			public Description()
			{
				target = null;
				percentage = 0;
			}
		}

		public class Result
		{
			public bool isSuccess;
		}
	}
}