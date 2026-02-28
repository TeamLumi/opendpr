using XLSXContent;

namespace Pml.Item
{
    public class ItemManager
    {
        private static ItemManager s_Instance = new ItemManager();
        private ItemTable m_alldata;

        public static ItemManager Instance { get => s_Instance; }

        public void Load(ItemTable data)
        {
            m_alldata = data;
        }

        public int GetParam(ushort itemno, ItemData.PrmID prmID, bool isCheckActive = true)
        {
            for (int i=0; i<m_alldata.Item.Length; i++)
            {
                var item = m_alldata.Item[i];
                if (itemno == item.no)
                {
                    if (item != null && (item.no == 0 || !isCheckActive || item.GetParam(ItemData.PrmID.INACTIVE) == 0))
                        return item.GetParam(prmID);

                    break;
                }
            }

            return m_alldata.Item[0].GetParam(prmID);
        }

        // TODO
        public BallId ItemID2BallID(ushort itemno) { return BallId.NULL; }

        // TODO
        public ushort BallID2ItemID(BallId ballid) { return 0; }

        // TODO
        public WazaNo GetWazaNo(ushort itemno) { return WazaNo.NULL; }

        // TODO
        private byte ItemNoToWazaMachineID(ushort itemno) { return 0; }

        // TODO
        public WazaNo WazaMachineIDToWazaID(byte machine_no) { return WazaNo.NULL; }

        // TODO
        public ItemNo WazaMachineIDToItemNo(byte machine_no) { return ItemNo.DUMMY_DATA; }

        // TODO
        public uint GetWazaMachineItemNum() { return 0; }

        // TODO
        private int GetIconId(ushort itemno) { return 0; }

        // TODO
        public bool IsGroupOf(ushort itemno, byte itemgroup) { return false; }

        // TODO
        public bool GroupIdToItemNo(byte itemgroup, byte groupid, out ushort o_pItemNo)
        {
            o_pItemNo = 0;
            return false;
        }

        // TODO
        public ItemTable.SheetItem Get(ushort itemno, bool isCheckActive = true) { return null; }

        public static bool IsStrangeBall(BallId ballid)
        {
        	return 0x19 < ((int)ballid & 0xff) - 1;
        }
    }
}