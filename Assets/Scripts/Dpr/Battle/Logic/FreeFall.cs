using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public static class FreeFall
	{
		public static bool CheckFreeFallUserPoke(BTL_POKEPARAM poke)
		{
			return poke.IsUsingFreeFall();
		}

		public static bool CheckFreeFallPoke(BTL_POKEPARAM poke)
		{
			return poke.CheckSick(WazaSick.WAZASICK_FREEFALL);
		}
	}
}