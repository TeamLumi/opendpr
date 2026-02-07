namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_CalcAgilityOrder : Section
	{
		public Section_FromEvent_CalcAgilityOrder(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			ushort agility = calcAgility(description.target, description.isTrickRoomApply);
			result.order = (byte)(agility >> 8);
		}

		private ushort calcAgility(BTL_POKEPARAM poke, bool isTrickRoomApply)
		{
			return GetEventLauncher().Event_CalcAgility(poke, isTrickRoomApply);
		}

		public class Description
		{
			public BTL_POKEPARAM target;
			public bool isTrickRoomApply;
			
			public Description()
			{
				target = null;
				isTrickRoomApply = false;
			}
		}

		public class Result
		{
			public byte order;
		}
	}
}