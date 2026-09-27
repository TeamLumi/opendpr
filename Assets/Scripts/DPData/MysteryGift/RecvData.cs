using System;

namespace DPData.MysteryGift
{
    [Serializable]
    public struct RecvData
    {
        public long timestamp;
        public ushort deliveryId;
        public ushort textId;
        public byte dataType;
        public byte reserved_byte01;
        public short reserved_short01;
        public MonsData monsData;
        public ItemInfo[] itemDatas;
        public uint[] dressIds;
        public uint moneyData;
        public int reserved_int01;
        public int reserved_int02;
        public int reserved_int03;
        public int reserved_int04;

        public void Clear()
        {
            monsData.Clear();
            itemDatas = new ItemInfo[MysteryGiftItemData.InfoSize];
            dressIds = new uint[MysteryGiftDressUpData.InfoSize];
        }
    }
}