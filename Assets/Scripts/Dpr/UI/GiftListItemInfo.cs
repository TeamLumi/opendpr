using DPData;
using DPData.MysteryGift;
using System;

namespace Dpr.UI
{
	public class GiftListItemInfo
	{
		private MysteryGiftData giftData;
		
		public MysteryGiftData GiftData { get => giftData; }
		public RecvData RecvData { get; private set; }
		public ConvertResult ConvertResult { get; private set; }
		
		public GiftListItemInfo(byte[] data)
		{
			Create(data);
		}
		
		public CanReceiveResult CanReceive()
		{
			return MysteryGiftWork.CanReceive(giftData.commonData);
		}
		
		private void Create(byte[] data)
		{
			var newData = new byte[MysteryGiftData.DataSize];
			Array.Copy(data, 0, newData, 0, newData.Length);

			ConvertResult = MysteryGiftWork.ConvertMysteryGiftData(newData, out giftData);

			if (ConvertResult == ConvertResult.SUCCESS)
				RecvData = MysteryGiftWork.CreateRecvData(giftData);
		}
	}
}