using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AfterTokuseiChanged_Item : Section
	{
		public Section_AfterTokuseiChanged_Item(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description desc)
		{
			BTL_POKEPARAM poke = desc.poke;

			if (poke.IsDead())
			{
				return;
			}

			checkItemReaction(poke);
			onKintyoukanMoved(poke);
		}

		private void checkItemReaction(BTL_POKEPARAM poke)
		{
			if (poke.IsFightEnable())
			{
				GetEventLauncher().Event_CheckItemReaction(poke, 0);
			}
		}

		private void onKintyoukanMoved(BTL_POKEPARAM poke)
		{
			var desc = new Section_KintyoukanMoved.Description();
			desc.movedPoke = poke;
			var result = new Section_KintyoukanMoved.Result();
			var section = new Section_KintyoukanMoved(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public TokuseiNo prevTokusei;
			public TokuseiNo nextTokusei;
		}

		public class Result { }
	}
}
