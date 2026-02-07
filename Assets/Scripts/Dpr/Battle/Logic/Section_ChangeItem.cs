using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_ChangeItem : Section
	{
		public Section_ChangeItem(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            ushort prevItemID = description.poke.GetItem();

            if (description.isPrevItemConsumed)
            {
                GetServerCommandPutter().ConsumeItem(description.poke, prevItemID);
            }

            GetServerCommandPutter().SetItem(description.poke, description.nextItemID);
        }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ushort nextItemID;
			public bool isPrevItemConsumed;
			
			public Description()
			{
				poke = null;
				nextItemID = (ushort)ItemNo.DUMMY_DATA;
				isPrevItemConsumed = false;
			}
		}

		public class Result { }
	}
}