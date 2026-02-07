using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AppearFreeFallTarget : Section
	{
		public Section_AppearFreeFallTarget(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID);
            GetServerCommandPutter().CureSick(targetPoke, WazaSick.WAZASICK_FREEFALL, out _);
        }

		public class Description
		{
			public byte targetPokeID;
			
			public Description()
			{
				targetPokeID = PokeID.INVALID;
			}
		}

		public class Result { }
	}
}