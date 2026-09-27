using DPData;
using DPData.MysteryGift;
using Dpr.Battle.Logic;
using INL1;
using Pml.PokePara;
using System;
using System.Runtime.InteropServices;

public static class MysteryGiftWork
{
	public const ushort CheckInternetGiftDataNo = 9999;
	public const long NgCheckSecond = 21600;
	public const byte InputNgCount = 10;
	
	public static MysteryGiftSaveData m_mysteryGiftData
	{
		get => PlayerWork.MysteryGiftData;
		set => PlayerWork.MysteryGiftData = value;
	}
	
	// TODO
	public static void AddRecvData(RecvData recvData) { }
	
	public static bool IsReceived(ushort deliveryId)
	{
		return IlcaNetServerDelivery.OkurimonoIdFlagCheck(deliveryId, PlayerWork.MysteryGiftData.receiveFlag);
	}
	
	// TODO
	public static bool IsExistRecvData() { return default; }
	
	// TODO
	public static void SetReceiveFlag(MysteryGiftData giftData) { }
	
	// TODO
	public static RecvData[] GetRecvDatas() { return default; }
	
	// TODO
	public static void ReceiveItemGift(ushort itemId) { }
	
	// TODO
	public static void ReceiveDressUpItemGift(uint dressId) { }
	
	public static CanReceiveResult CanReceive(MysteryGiftCommonData commonData)
	{
		if (commonData.IsReceiveOnce)
		{
			return IsReceived((ushort)commonData.deliveryID) ? CanReceiveResult.NG : CanReceiveResult.OK;
		}
		else if (commonData.IsReceiveOneDay)
		{
			var playerData = PlayerWork.MysteryGiftData;
			var now = GameManager.nowTime;
			now = new DateTime(now.Year, now.Month, now.Day);

			if (playerData.oneDayDatas.Length <= 0)
				return CanReceiveResult.NG_TodayFull;

			bool freeSpaceAvailable = false;
			for (int i=0; i<playerData.oneDayDatas.Length; i++)
			{
				var oneDayData = playerData.oneDayDatas[i];

                var giftTime = DateTime.FromFileTime(oneDayData.timestamp);
				giftTime = new DateTime(giftTime.Year, giftTime.Month, giftTime.Day);

				if (commonData.deliveryID == oneDayData.deliveryId && (now - giftTime).TotalDays < 1.0)
					return CanReceiveResult.NG_Today;

                freeSpaceAvailable |= (now - giftTime).TotalDays >= 1.0;
            }

			if (freeSpaceAvailable)
                return CanReceiveResult.OK;
			else
                return CanReceiveResult.NG_TodayFull;
        }
		else
		{
			return CanReceiveResult.OK;
        }
	}
	
	// TODO
	public static void ResetNgCount() { }
	
	// TODO
	public static bool IsNgFlagOn() { return default; }
	
	// TODO
	public static bool IncNgCount() { return default; }
	
	// TODO
	public static RecvData CreateRecvData(MysteryGiftData data)
	{
        RecvData recvData = default;
		recvData.Clear();

		// TODO

		return recvData;
	}
	
	public static ConvertResult ConvertMysteryGiftData(byte[] dataBytes, out MysteryGiftData mysteryGiftData)
    {
        mysteryGiftData = default;

        if (dataBytes.Length != MysteryGiftData.DataSize)
            return ConvertResult.INVALID_ARGUMENT;

        mysteryGiftData.commonData = ConvertData<MysteryGiftCommonData>(dataBytes, 0);

        var offset = Marshal.SizeOf<MysteryGiftCommonData>();

        switch ((DataType)mysteryGiftData.commonData.dataType)
        {
            case DataType.Monster:
                mysteryGiftData.pokemonData = ConvertData<MysteryGiftPokemonData>(dataBytes, offset);
                break;

            case DataType.Items:
                mysteryGiftData.itemData = ConvertData<MysteryGiftItemData>(dataBytes, offset);
                break;

            case DataType.DressUp:
                mysteryGiftData.dressUpData = ConvertData<MysteryGiftDressUpData>(dataBytes, offset);
                break;

            case DataType.Money:
                mysteryGiftData.moneyData = ConvertData<uint>(dataBytes, offset);
                break;

            case DataType.UnderGroundItem:
                mysteryGiftData.underGroundItemData = ConvertData<MysteryGiftUnderGroundItemData>(dataBytes, offset);
                break;

            default:
                return ConvertResult.INVALID_ARGUMENT;
        }

        mysteryGiftData.crc = ConvertData<ushort>(dataBytes, MysteryGiftData.CrcIndex);

        if (CheckCrc(dataBytes, mysteryGiftData.crc))
            return ConvertResult.SUCCESS;

        return ConvertResult.CRC_ERROR;
    }

    // TODO
    public static PokemonParam CreatePokemonParam(MysteryGiftPokemonData pokemonData) { return default; }
	
	// TODO
	public static void DebugOneDayHistory(int addDay = 0) { }
	
	// TODO
	public static void ResetReceivedFlag() { }
	
	// TODO
	public static void ResetOneDayReceivedDatas() { }
	
	// TODO
	private static void SetOnceReceiveFlag(ushort deliveryId) { }
	
	// TODO
	private static void SetOneDayReceiveFlag(ushort deliveryId, long timestamp) { }
	
	// TODO
	private static bool IsNgTime(long oldTime, long newTime) { return default; }
	
	// TODO
	public static bool GetGameServerTime(out long timestamp)
	{
		timestamp = default;
		return default;
	}
	
	private static T ConvertData<T>(byte[] dataBytes, int start)
	{
		var size = Marshal.SizeOf<T>();

        var ptr = Marshal.AllocHGlobal(size);

		Marshal.Copy(dataBytes, start, ptr, size);
		var result = Marshal.PtrToStructure<T>(ptr);

        Marshal.FreeHGlobal(ptr);

		return result;
    }
	
	// TODO
	private static void GetPokemonNameAndLanguage(MysteryGiftPokemonData pokemonData, MyStatus myStatus, out string nickName, out string parentName, out byte nickNameLang)
	{
		nickName = default;
		parentName = default;
		nickNameLang = default;
	}
	
	// TODO
	private static void ConvertRecvPokemonData(MysteryGiftPokemonData pokemonData, out MonsData monsData)
	{
		monsData = default;
	}
	
	private static bool CheckCrc(byte[] data, ushort crc)
	{
		if (data.Length > MysteryGiftData.CrcIndex)
			for (int i=MysteryGiftData.CrcIndex; i<data.Length; i++)
                data[i] = 0;

		return CalcCrcValue(data) == crc;
	}
	
	private static int CalcCrcValue(byte[] dataBytes)
	{
		var powers = new int[8];

		for (int i=0; i<powers.Length; i++)
			powers[i] = (int)Math.Pow(2.0d, i);

		if (dataBytes.Length > 0)
		{
			if (powers.Length > 0)
			{
				int crc = ushort.MaxValue;

				for (int i=0; i<dataBytes.Length; i++)
				{
					for (int j=powers.Length-1; j>=0; j--)
					{
						var power = powers[j];

						var bottom15 = (crc & 0x7FFF) << 1;
						var sign = crc >> 0xF;

						crc = bottom15;

						if (((power & (dataBytes[i] ^ 0xFFFFFFFF)) != 0) == (sign != 0))
							crc = bottom15 ^ 0x1021;
					}
				}

				return crc;
			}

			// Ignores result, maybe commented out logs
			for (int i=0; i<dataBytes.Length; i++)
				_ = dataBytes[i];
		}

		return ushort.MaxValue;
	}
}