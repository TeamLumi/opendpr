namespace Dpr.Battle.Logic
{
	public sealed class Section_TokuseiDisabled : Section
	{
		public Section_TokuseiDisabled(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM target = description.target;

			// Fire the tokusei-disabled event
			GetEventLauncher().Event_TokuseiDisabled(target);

			// Trigger Intimidate-like re-check after ability is disabled
			onKintyoukanMoved(target);
		}

		private void onKintyoukanMoved(BTL_POKEPARAM poke)
		{
			var desc = new Section_KintyoukanMoved.Description();
			desc.movedPoke = poke;
			var sectionResult = new Section_KintyoukanMoved.Result();
			GetSectionContainer().GetSection_KintyoukanMoved().Execute(sectionResult, desc);
		}

		public class Description
		{
			public BTL_POKEPARAM target;
			
			public Description()
			{
				target = null;
			}
		}

		public class Result { }
	}
}