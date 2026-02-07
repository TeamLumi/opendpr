using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AfterItemEquip : Section
	{
		public Section_AfterItemEquip(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			GetEventLauncher().Event_AfterItemEquip(description.poke, description.itemID, description.isKinomiCheckEnable);
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ushort itemID;
			public bool isKinomiCheckEnable;
			
			public Description()
			{
				poke = null;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isKinomiCheckEnable = false;
			}
		}

		public class Result { }
	}
}