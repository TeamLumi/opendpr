using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public static class BTL_SICK
	{
		public static bool MakeDefaultCureMsg(WazaSick sickID, in BTL_SICKCONT oldCont, BTL_POKEPARAM bpp, ushort itemID, StrParam str)
		{
			bool fUseItem = (itemID != (ushort)Pml.ItemNo.DUMMY_DATA);
			int strID = sick.getCureStrID(sickID, fUseItem);

			if (strID < 0)
				return false;

			str.Setup(BtlStrType.BTL_STRTYPE_SET, (ushort)strID);
			str.AddArg(bpp.GetID());
			return true;
		}

		public static void MakeDefaultMsg(WazaSick sickID, in BTL_SICKCONT cont, BTL_POKEPARAM bpp, StrParam str)
		{
			int strID = sick.getDefaultSickStrID(sickID, in cont);

			if (strID < 0)
				return;

			str.Setup(BtlStrType.BTL_STRTYPE_SET, (ushort)strID);
			str.AddArg(bpp.GetID());
		}

		public static bool CheckBatonTouchInherit(WazaSick sick, BTL_POKEPARAM bpp)
		{
			switch (sick)
			{
				case WazaSick.WAZASICK_KONRAN:
				case WazaSick.WAZASICK_MEROMERO:
				case WazaSick.WAZASICK_BIND:
				case WazaSick.WAZASICK_NOROI:
				case WazaSick.WAZASICK_YADORIGI:
				case WazaSick.WAZASICK_SASIOSAE:
				case WazaSick.WAZASICK_AQUARING:
				case WazaSick.WAZASICK_KAIHUKUHUUJI:
				case WazaSick.WAZASICK_HOROBINOUTA:
				case WazaSick.WAZASICK_NEWOHARU:
				case WazaSick.WAZASICK_TOOSENBOU:
				case WazaSick.WAZASICK_ENCORE:
				case WazaSick.WAZASICK_TELEKINESIS:
				case WazaSick.WAZASICK_MUSTHIT:
				case WazaSick.WAZASICK_MUSTHIT_TARGET:
				case WazaSick.WAZASICK_TOGISUMASU:
					return true;
				default:
					return false;
			}
		}

		public static bool MakeSickDamageMsg(StrParam strParam, BTL_POKEPARAM bpp, WazaSick sickID)
		{
			int strID = sick.getWazaSickDamageStrID(sickID);

			if (strID < 0)
				return false;

			strParam.Setup(BtlStrType.BTL_STRTYPE_SET, (ushort)strID);
			strParam.AddArg(bpp.GetID());
			return true;
		}

		public static short GetSpecificSickFailStrID(WazaSick sickID)
		{
			switch (sickID)
			{
				case WazaSick.WAZASICK_DOKU:    return (short)BTL_STRID_SET.DokuAlready;
				case WazaSick.WAZASICK_YAKEDO:  return (short)BTL_STRID_SET.YakedoAlready;
				case WazaSick.WAZASICK_NEMURI:  return (short)BTL_STRID_SET.NemuriAlready;
				case WazaSick.WAZASICK_KOORI:   return (short)BTL_STRID_SET.KoriAlready;
				case WazaSick.WAZASICK_MAHI:    return (short)BTL_STRID_SET.MahiAlready;
				default:                        return -1;
			}
		}
	}
}
