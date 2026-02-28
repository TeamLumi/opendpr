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

        public BallId ItemID2BallID(ushort itemno)
        {
            var item = Get(itemno);
            return item.GetBallID();
        }

        public ushort BallID2ItemID(BallId ballid)
        {
            if (ballid == BallId.NULL)
                return (ushort)ItemNo.DUMMY_DATA;

            for (int i = 0; i < m_alldata.Item.Length; i++)
            {
                var item = m_alldata.Item[i];
                if (item.GetBallID() == ballid)
                    return (ushort)i;
            }

            GFL.ASSERT(false, "Failed to BallID2ItemID()");
            return (ushort)ItemNo.DUMMY_DATA;
        }

        public WazaNo GetWazaNo(ushort itemno)
        {
            var item = Get(itemno);
            if (!item.IsWazaMachine())
                return WazaNo.NULL;

            for (int i = 0; i < m_alldata.WazaMachine.Length; i++)
            {
                if (m_alldata.WazaMachine[i].itemNo == itemno)
                    return (WazaNo)m_alldata.WazaMachine[i].wazaNo;
            }

            return WazaNo.NULL;
        }

        private byte ItemNoToWazaMachineID(ushort itemno)
        {
            return (byte)Get(itemno).GetWazaMashineNo();
        }

        public WazaNo WazaMachineIDToWazaID(byte machine_no)
        {
            for (int i = 0; i < m_alldata.WazaMachine.Length; i++)
            {
                if (m_alldata.WazaMachine[i].machineNo == machine_no)
                    return (WazaNo)m_alldata.WazaMachine[i].wazaNo;
            }

            return WazaNo.NULL;
        }

        public ItemNo WazaMachineIDToItemNo(byte machine_no)
        {
            for (int i = 0; i < m_alldata.WazaMachine.Length; i++)
            {
                if (m_alldata.WazaMachine[i].machineNo == machine_no)
                    return (ItemNo)m_alldata.WazaMachine[i].itemNo;
            }

            return ItemNo.DUMMY_DATA;
        }

        public uint GetWazaMachineItemNum()
        {
            return (uint)m_alldata.WazaMachine.Length;
        }

        private int GetIconId(ushort itemno)
        {
            return GetParam(itemno, ItemData.PrmID.ICONID);
        }

        public bool IsGroupOf(ushort itemno, byte itemgroup)
        {
            var item = Get(itemno);
            return item.IsGroupOf(itemgroup);
        }

        public bool GroupIdToItemNo(byte itemgroup, byte groupid, out ushort o_pItemNo)
        {
            for (int i = 0; i < m_alldata.Item.Length; i++)
            {
                var item = m_alldata.Item[i];
                if (item.group == itemgroup && item.group_id == groupid)
                {
                    o_pItemNo = (ushort)i;
                    return true;
                }
            }

            o_pItemNo = 0;
            return false;
        }

        public ItemTable.SheetItem Get(ushort itemno, bool isCheckActive = true)
        {
            for (int i = 0; i < m_alldata.Item.Length; i++)
            {
                var item = m_alldata.Item[i];
                if (itemno == item.no)
                {
                    if (item.no == 0 || !isCheckActive || item.GetParam(ItemData.PrmID.INACTIVE) == 0)
                        return item;
                    break;
                }
            }

            return m_alldata.Item[0];
        }

        public static bool IsStrangeBall(BallId ballid)
        {
            return ballid >= BallId.PAAKUBOORU;
        }
    }
}
