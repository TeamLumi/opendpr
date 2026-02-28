namespace Dpr.Battle.Logic
{
	public static class FreeFall
	{
		public static bool CheckFreeFallUserPoke(BTL_POKEPARAM poke)
		{
			poke.IsUsingFreeFall();
			return false;
		}
		
		public static bool CheckFreeFallPoke(BTL_POKEPARAM poke)
		{
			var uVar1 = poke.IsUsingFreeFall();
			if (uVar1) {
			  return true;
			}
			var uVar2 = poke.CheckSick(0x22);
			return uVar2;
		}
	}
}