using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public static class sick
	{
		private static readonly getCureStrIDTable_t[] getCureStrIDTable = new getCureStrIDTable_t[]
		{
			new getCureStrIDTable_t(WazaSick.WAZASICK_DOKU,         BTL_STRID_SET.DokuCure,        BTL_STRID_SET.UseItem_CureDoku),
			new getCureStrIDTable_t(WazaSick.WAZASICK_YAKEDO,       BTL_STRID_SET.YakedoCure,      BTL_STRID_SET.UseItem_CureYakedo),
			new getCureStrIDTable_t(WazaSick.WAZASICK_NEMURI,       BTL_STRID_SET.NemuriWake,      BTL_STRID_SET.UseItem_CureNemuri),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KOORI,        BTL_STRID_SET.KoriMelt,        BTL_STRID_SET.UseItem_CureKoori),
			new getCureStrIDTable_t(WazaSick.WAZASICK_MAHI,         BTL_STRID_SET.MahiCure,        BTL_STRID_SET.UseItem_CureMahi),
			new getCureStrIDTable_t(WazaSick.WAZASICK_ENCORE,       BTL_STRID_SET.EncoreCure,      -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KANASIBARI,   BTL_STRID_SET.KanasibariCure,  -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_SASIOSAE,     BTL_STRID_SET.SasiosaeCure,    -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_BIND,         BTL_STRID_SET.BindCure,        BTL_STRID_SET.BindCure),
			new getCureStrIDTable_t(WazaSick.WAZASICK_YADORIGI,     BTL_STRID_SET.BindCure,        BTL_STRID_SET.BindCure),
			new getCureStrIDTable_t(WazaSick.WAZASICK_TELEKINESIS,  BTL_STRID_SET.Telekinesis_End, -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_TYOUHATSU,    BTL_STRID_SET.ChouhatuCure,    -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_FLYING,       BTL_STRID_SET.DenjiFuyuCure,   -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KAIHUKUHUUJI, BTL_STRID_SET.KaifukuFujiCure, -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_ICHAMON,      BTL_STRID_SET.IchamonCure,     -1),
			new getCureStrIDTable_t(WazaSick.WAZASICK_KONRAN,       BTL_STRID_SET.KonranCure,      BTL_STRID_SET.UseItem_CureKonran),
			new getCureStrIDTable_t(WazaSick.WAZASICK_MEROMERO,     BTL_STRID_SET.MeromeroCure,    BTL_STRID_SET.UseItem_CureMero),
		};

		public static int getCureStrID(WazaSick sick, bool fUseItem)
		{
			for (int i = 0; i < getCureStrIDTable.Length; i++)
			{
				if (getCureStrIDTable[i].sick == sick)
				{
					if (fUseItem)
					{
						return getCureStrIDTable[i].strID_useItem;
					}
					else
					{
						return getCureStrIDTable[i].strID_notItem;
					}
				}
			}

			return -1;
		}

		public static int getDefaultSickStrID(WazaSick sickID, in BTL_SICKCONT cont)
		{
			switch (sickID)
			{
				case WazaSick.WAZASICK_DOKU:
					if (cont.turn_flag)
					{
						return BTL_STRID_SET.MoudokuGet;
					}
					return BTL_STRID_SET.DokuGet;
				case WazaSick.WAZASICK_YAKEDO:       return BTL_STRID_SET.YakedoGet;
				case WazaSick.WAZASICK_NEMURI:       return BTL_STRID_SET.NemuriGet;
				case WazaSick.WAZASICK_KOORI:        return BTL_STRID_SET.KoriGet;
				case WazaSick.WAZASICK_MAHI:         return BTL_STRID_SET.MahiGet;
				case WazaSick.WAZASICK_KONRAN:       return BTL_STRID_SET.KonranGet;
				case WazaSick.WAZASICK_MEROMERO:     return BTL_STRID_SET.MeromeroGet;
				case WazaSick.WAZASICK_BIND:         return BTL_STRID_SET.Bind;
				case WazaSick.WAZASICK_YADORIGI:     return BTL_STRID_SET.Yadorigi;
				case WazaSick.WAZASICK_ENCORE:       return BTL_STRID_SET.Encore;
				case WazaSick.WAZASICK_TYOUHATSU:    return BTL_STRID_SET.Chouhatu;
				case WazaSick.WAZASICK_ICHAMON:      return BTL_STRID_SET.Ichamon;
				case WazaSick.WAZASICK_KANASIBARI:   return BTL_STRID_SET.Kanasibari;
				case WazaSick.WAZASICK_SASIOSAE:     return BTL_STRID_SET.Sasiosae;
				case WazaSick.WAZASICK_FLYING:       return BTL_STRID_SET.DenjiFuyu;
				case WazaSick.WAZASICK_TELEKINESIS:  return BTL_STRID_SET.Telekinesis;
				case WazaSick.WAZASICK_KAIHUKUHUUJI: return BTL_STRID_SET.KaifukuFuji;
				default:                             return -1;
			}
		}

		public static int getWazaSickDamageStrID(WazaSick sick)
		{
			switch (sick)
			{
				case WazaSick.WAZASICK_DOKU:    return BTL_STRID_SET.DokuDamage;
				case WazaSick.WAZASICK_YAKEDO:  return BTL_STRID_SET.YakedoDamage;
				case WazaSick.WAZASICK_AKUMU:   return BTL_STRID_SET.AkumuDamage;
				default:                        return -1;
			}
		}

		private class getCureStrIDTable_t
		{
			public WazaSick sick;
			public short strID_notItem;
			public short strID_useItem;

			public getCureStrIDTable_t(WazaSick sick, short strID_notItem, short strID_useItem)
			{
				this.sick = sick;
				this.strID_notItem = strID_notItem;
				this.strID_useItem = strID_useItem;
			}
		}
	}
}
