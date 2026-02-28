namespace Pml.Item
{
    public class ItemData
    {
        public const uint ITEM_WAZAMACHINE_ERROR = 4294967295;
        public const byte NUTS_ID_ERROR = 255;
        public const int FLAG0_MASK_NAGE_EFF = 1;
        public const int FLAG0_MASK_IMP = 2;
        public const int FLAG0_MASK_CNV_BTN = 4;
        public const int FLAG0_MASK_SPEND = 8;
        public const int FLAG0_MASK_BATTLE_SELECTABLE = 16;
        public const int FLAG0_MASK_USE_NO_SPEND = 32;
        public const int FLAG0_MASK_SET_TO_POKE = 64;
        public const int FLAG0_MASK_WORK_TYPE = 128;
        public const int FLAG0_MASK_ABILITY_GUARD = 256;
        public const int FLAG0_MASK_LV_UP = 512;
        public const int FLAG0_MASK_PP_RCV = 1024;
        public const int FLAG0_MASK_ALLPP_RCV = 2048;
        public const int FLAG0_MASK_PP_UP = 4096;
        public const int FLAG0_MASK_PP_3UP = 8192;
        public const int FLAG0_MASK_EXP_LIMIT = 16384;
        public const int FLAG0_MASK_SLEEP_RCV = 32768;
        public const int FLAG0_MASK_POISON_RCV = 65536;
        public const int FLAG0_MASK_BURN_RCV = 131072;
        public const int FLAG0_MASK_ICE_RCV = 262144;
        public const int FLAG0_MASK_PARALAYZE_RCV = 524288;
        public const int FLAG0_MASK_PANIC_RCV = 1048576;
        public const int FLAG0_MASK_MEROMERO_RCV = 2097152;
        public const int FLAG0_MASK_DEATH_RCV = 4194304;
        public const int FLAG0_MASK_ALLDEATH_RCV = 8388608;
        public const int FLAG0_MASK_EVOLUTION = 16777216;
        public const int FLAG0_MASK_INACTIVE = -2147483648;
        public const int PP_UP_WAZAMAX_MIN = 5;

        public static int GetParam(ushort itemno, PrmID prmID)
        {
            return ItemManager.Instance.GetParam(itemno, prmID, true);
        }

        public static uint GetHealingItemType(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.GetHealingItemType();
        }

        public static bool IsNeedSelectSkill(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsNeedSelectSkill();
        }

        public static bool IsDeathRecoverAllItem(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsDeathRecoverAllItem();
        }

        public static bool IsSale(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsSale();
        }

        public static bool IsEventItem(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsEventItem();
        }

        public static int GetGroupId(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.GetGroupId();
        }

        public static BallId GetBallID(ushort itemno)
        {
            return ItemManager.Instance.ItemID2BallID(itemno);
        }

        public static ushort BallId2ItemId(BallId ballId)
        {
            return ItemManager.Instance.BallID2ItemID(ballId);
        }

        public static bool IsWazaMachine(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsWazaMachine();
        }

        public static WazaNo GetWazaNo(ushort itemno)
        {
            return ItemManager.Instance.GetWazaNo(itemno);
        }

        public static uint GetWazaMashineNo(ushort item)
        {
            var sheetItem = ItemManager.Instance.Get(item);
            return sheetItem.GetWazaMashineNo();
        }

        public static uint GetWazaMashineMax()
        {
            return ItemManager.Instance.GetWazaMachineItemNum();
        }

        public static WazaNo GetWazaMashineWaza(byte machine_no)
        {
            return ItemManager.Instance.WazaMachineIDToWazaID(machine_no);
        }

        public static ItemNo GetWazaMashineItemNo(byte machine_no)
        {
            return ItemManager.Instance.WazaMachineIDToItemNo(machine_no);
        }

        public static bool IsWazaRecord(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsWazaRecord();
        }

        public static bool IsNuts(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsNuts();
        }

        public static byte GetNutsNo(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.GetNutsNo();
        }

        public static ushort NutsIDToItemNo(byte nutsid)
        {
            ushort itemNo;
            if (ItemManager.Instance.GroupIdToItemNo((byte)ItemGroup.NUTS, nutsid, out itemNo))
                return itemNo;
            return 0;
        }

        public static bool IsGroupOf(ushort itemno, byte itemgroup)
        {
            return ItemManager.Instance.IsGroupOf(itemno, itemgroup);
        }

        public static bool IsMegaStone(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsMegaStone();
        }

        public static bool IsJewel(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsJewel();
        }

        public static bool IsPiece(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsPiece();
        }

        public static bool IsBeads(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsBeads();
        }

        public static bool IsHeart(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.IsHeart();
        }

        public static bool CanPokeHave(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.CanPokeHave();
        }

        public static bool IsValid(ushort item)
        {
            return ItemManager.Instance.GetParam(item, PrmID.INACTIVE, false) == 0;
        }

        public static uint GetTypeSortNumber(ushort itemno)
        {
            var item = ItemManager.Instance.Get(itemno);
            return item.GetTypeSortNumber();
        }

        public enum PrmID : int
        {
            ITEMNUMBER = 0,
            PRICE = 1,
            WAT_PRICE = 2,
            BP_PRICE = 3,
            ICONID = 4,
            EQUIP = 5,
            ATTACK = 6,
            TUIBAMU_EFF = 7,
            NAGE_EFF = 8,
            NAGE_ATC = 9,
            SIZEN_ATC = 10,
            SIZEN_TYPE = 11,
            IMP = 12,
            CNV = 13,
            F_POCKET = 14,
            F_FUNC = 15,
            B_FUNC = 16,
            WORK_TYPE = 17,
            ITEM_TYPE = 18,
            SPEND = 19,
            USE_SPEND = 20,
            SORT = 21,
            GROUP = 22,
            GROUPID = 23,
            SET_TO_POKE = 24,
            B_SELECTABLE = 25,
            INACTIVE = 26,
            WORK = 27,
            SLEEP_RCV = 27,
            POISON_RCV = 28,
            BURN_RCV = 29,
            ICE_RCV = 30,
            PARALYZE_RCV = 31,
            PANIC_RCV = 32,
            MEROMERO_RCV = 33,
            ABILITY_GUARD = 34,
            DEATH_RCV = 35,
            ALL_DEATH_RCV = 36,
            LV_UP = 37,
            EVOLUTION = 38,
            ATTACK_UP = 39,
            DEFENCE_UP = 40,
            SP_ATTACK_UP = 41,
            SP_DEFENCE_UP = 42,
            AGILITY_UP = 43,
            HIT_UP = 44,
            CRITICAL_UP = 45,
            PP_UP = 46,
            PP_3UP = 47,
            PP_RCV = 48,
            ALL_PP_RCV = 49,
            HP_RCV = 50,
            HP_EXP = 51,
            POWER_EXP = 52,
            DEFENCE_EXP = 53,
            AGILITY_EXP = 54,
            SP_ATTACK_EXP = 55,
            SP_DEFENCE_EXP = 56,
            EXP_LIMIT_FLAG = 57,
            FRIEND1 = 58,
            FRIEND2 = 59,
            FRIEND3 = 60,
            HP_EXP_POINT = 61,
            POWER_EXP_POINT = 62,
            DEFENCE_EXP_POINT = 63,
            AGILITY_EXP_POINT = 64,
            SP_ATTACK_EXP_POINT = 65,
            SP_DEFENCE_EXP_POINT = 66,
            HP_RCV_POINT = 67,
            PP_RCV_POINT = 68,
            FRIEND1_POINT = 69,
            FRIEND2_POINT = 70,
            FRIEND3_POINT = 71,
        }

        public enum WorkType : int
        {
            NORMAL = 0,
            POKEUSE = 1,
            BALL = 2,
        }

        public enum HpRecoverType : int
        {
            FULL = 255,
            HALF = 254,
            QUOT = 253,
        }

        public enum PpRecoverType : int
        {
            FULL = 127,
        }

        public enum ItemType : int
        {
            ALLDETH_RCV = 0,
            LV_UP = 1,
            NEMURI_RCV = 2,
            DOKU_RCV = 3,
            YAKEDO_RCV = 4,
            KOORI_RCV = 5,
            MAHI_RCV = 6,
            KONRAN_RCV = 7,
            ALL_ST_RCV = 8,
            MEROMERO_RCV = 9,
            HP_RCV = 10,
            DEATH_RCV = 11,
            HP_UP = 12,
            ATC_UP = 13,
            DEF_UP = 14,
            SPA_UP = 15,
            SPD_UP = 16,
            AGI_UP = 17,
            HP_DOWN = 18,
            ATC_DOWN = 19,
            DEF_DOWN = 20,
            SPA_DOWN = 21,
            SPD_DOWN = 22,
            AGI_DOWN = 23,
            EVO = 24,
            PP_UP = 25,
            PP_3UP = 26,
            PP_RCV = 27,
            ETC = 28,
        }

        public enum FieldFunctionType : int
        {
            NONE = 0,
            ITEMUSE_FLD_RECOVER = 1,
            ITEMUSE_FLD_WAZA = 2,
            ITEMUSE_FLD_CYCLE = 3,
            ITEMUSE_FLD_MITSU = 4,
            ITEMUSE_FLD_BAG_MSG = 5,
            ITEMUSE_FLD_EVOLUTION = 6,
            ITEMUSE_FLD_ANANUKE = 7,
            ITEMUSE_FLD_APPLICATION = 8,
            ITEMUSE_FLD_FLY = 9,
            ITEMUSE_FLD_VIDRO = 10,
            ITEMUSE_FLD_MAIL = 11,
            ITEMUSE_FLD_KINOMI = 12,
            ITEMUSE_FLD_FISHING_ROD_GREAT = 13,
            ITEMUSE_FLD_BATTLE_REC = 14,
            ITEMUSE_FLD_FORM_CHANGE = 15,
            ITEMUSE_FLD_DOWSING_MACHINE = 16,
            ITEMUSE_FLD_UNION = 17,
            ITEMUSE_FLD_ROTOPON = 18,
            ITEMUSE_FLD_TANKENSETTO = 19,
            ITEMUSE_FLD_BOUKENNOOTO = 20,
            ITEMUSE_FLD_POFINKEESU = 21,
            ITEMUSE_FLD_POKETORE = 22,
            ITEMUSE_FLD_KODAKKUZYOURO = 23,
            ITEMUSE_FLD_BATORUSAATYAA = 24,
            ITEMUSE_FLD_FISHING_ROD_BORO = 25,
            ITEMUSE_FLD_FISHING_ROD_II = 26,
            ITEMUSE_FLD_TENKAINOHUE = 27,
            ITEMUSE_FLD_POINTOKAADO = 28,
            ITEMUSE_FLD_DS_PLAYER = 29,
        }
    }
}
