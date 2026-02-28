using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public static class GWaza
	{
		// TODO
		public static bool IsGWaza(WazaNo wazano) { return default; }
		
		// TODO
		public static WazaNo GetGWaza(WazaNo srcWaza) { return default; }
		
		// TODO
		public static WazaNo GetGWaza(PokeType wazaType) { return default; }
		
		public static WazaDamageType GetDamageType(WazaNo srcWaza)
		{
			WAZADATA.GetDamageType(srcWaza);
			return (WazaDamageType)0;
		}
		
		public static byte GetPower(WazaNo srcWaza)
		{
			WAZADATA.GetGPower(srcWaza);
			return 0;
		}
	}
}