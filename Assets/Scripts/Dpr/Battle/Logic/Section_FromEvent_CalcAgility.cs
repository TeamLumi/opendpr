namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_CalcAgility : Section
	{
		public Section_FromEvent_CalcAgility(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.agility = GetEventLauncher().Event_CalcAgility(description.poke, description.isTrickRoomApply);
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public bool isTrickRoomApply;
			
			public Description()
			{
				poke = null;
				isTrickRoomApply = false;
			}
		}

		public class Result
		{
			public ushort agility;
		}
	}
}