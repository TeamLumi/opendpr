namespace Dpr.Battle.Logic
{
	public sealed class Section_KintyoukanMoved : Section
	{
		public Section_KintyoukanMoved(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM movedPoke = description.movedPoke;

			// Fire the member-in completion event for the moved pokemon
			GetEventLauncher().Event_AfterMemberIn(movedPoke, EventID.MEMBER_IN_COMP);

			// Check item reaction for the moved pokemon
			checkItemReaction(movedPoke);
		}

		private void checkItemReaction(BTL_POKEPARAM poke)
		{
			if (poke.IsFightEnable())
			{
				GetEventLauncher().Event_CheckItemReaction(poke, 0);
			}
		}

		public class Description
		{
			public BTL_POKEPARAM movedPoke;

			public Description()
			{
				movedPoke = null;
			}
		}

		public class Result { }
	}
}
