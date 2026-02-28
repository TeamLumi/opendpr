using XLSXContent;

namespace Pml.Item
{
    public static class ItemTableExtensions
    {
        public static int GetParam(this ItemTable.SheetItem prm, ItemData.PrmID prmID)
        {
            switch (prmID)
            {
                case ItemData.PrmID.ITEMNUMBER:
                    return prm.no;

                case ItemData.PrmID.PRICE:
                    return prm.price;

                case ItemData.PrmID.WAT_PRICE:
                    return 0;

                case ItemData.PrmID.BP_PRICE:
                    return prm.bp_price;

                case ItemData.PrmID.ICONID:
                    return prm.iconid;

                case ItemData.PrmID.EQUIP:
                    return prm.eqp;

                case ItemData.PrmID.ATTACK:
                    return prm.atc;

                case ItemData.PrmID.TUIBAMU_EFF:
                    return prm.tuibamu_eff;

                case ItemData.PrmID.NAGE_EFF:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_NAGE_EFF) != 0 ? 1 : 0;

                case ItemData.PrmID.NAGE_ATC:
                    return prm.nage_atc;

                case ItemData.PrmID.SIZEN_ATC:
                    return prm.sizen_atc;

                case ItemData.PrmID.SIZEN_TYPE:
                    return prm.sizen_type;

                case ItemData.PrmID.IMP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_IMP) != 0 ? 1 : 0;

                case ItemData.PrmID.CNV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_CNV_BTN) != 0 ? 1 : 0;

                case ItemData.PrmID.F_POCKET:
                    return prm.fld_pocket;

                case ItemData.PrmID.F_FUNC:
                    return prm.field_func;

                case ItemData.PrmID.B_FUNC:
                    return prm.battle_func;

                case ItemData.PrmID.WORK_TYPE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_WORK_TYPE) != 0 ? 1 : 0;

                case ItemData.PrmID.ITEM_TYPE:
                    return prm.type;

                case ItemData.PrmID.SPEND:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_SPEND) != 0 ? 1 : 0;

                case ItemData.PrmID.USE_SPEND:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_USE_NO_SPEND) != 0 ? 1 : 0;

                case ItemData.PrmID.SORT:
                    return prm.sort;

                case ItemData.PrmID.GROUP:
                    return prm.group;

                case ItemData.PrmID.GROUPID:
                    return prm.group_id;

                case ItemData.PrmID.SET_TO_POKE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_SET_TO_POKE) != 0 ? 1 : 0;

                case ItemData.PrmID.B_SELECTABLE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_BATTLE_SELECTABLE) != 0 ? 1 : 0;

                case ItemData.PrmID.INACTIVE:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_INACTIVE) != 0 ? 1 : 0;

                default:
                    if (prm.GetParam(ItemData.PrmID.WORK_TYPE) == 0)
                        return prm.wk_cmn;
                    else
                        return prm.GetWorkRecoverItem(prmID);
            }
        }

        public static int GetWorkRecoverItem(this ItemTable.SheetItem prm, ItemData.PrmID prmID)
        {
            switch (prmID)
            {
                case ItemData.PrmID.SLEEP_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_SLEEP_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.POISON_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_POISON_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.BURN_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_BURN_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ICE_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ICE_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.PARALYZE_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PARALAYZE_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.PANIC_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PANIC_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.MEROMERO_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_MEROMERO_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ABILITY_GUARD:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ABILITY_GUARD) != 0 ? 1 : 0;

                case ItemData.PrmID.DEATH_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_DEATH_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ALL_DEATH_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ALLDEATH_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.LV_UP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_LV_UP) != 0 ? 1 : 0;

                case ItemData.PrmID.EVOLUTION:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_EVOLUTION) != 0 ? 1 : 0;

                case ItemData.PrmID.ATTACK_UP:
                    return prm.wk_atc_up;

                case ItemData.PrmID.DEFENCE_UP:
                    return prm.wk_def_up;

                case ItemData.PrmID.SP_ATTACK_UP:
                    return prm.wk_spa_up;

                case ItemData.PrmID.SP_DEFENCE_UP:
                    return prm.wk_spd_up;

                case ItemData.PrmID.AGILITY_UP:
                    return prm.wk_agi_up;

                case ItemData.PrmID.HIT_UP:
                    return prm.wk_hit_up;

                case ItemData.PrmID.CRITICAL_UP:
                    return prm.wk_critical_up;

                case ItemData.PrmID.PP_UP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PP_UP) != 0 ? 1 : 0;

                case ItemData.PrmID.PP_3UP:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PP_3UP) != 0 ? 1 : 0;

                case ItemData.PrmID.PP_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_PP_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.ALL_PP_RCV:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_ALLPP_RCV) != 0 ? 1 : 0;

                case ItemData.PrmID.HP_RCV:
                    if (((int)prm.flags0 & (ItemData.FLAG0_MASK_DEATH_RCV | ItemData.FLAG0_MASK_ALLDEATH_RCV)) != 0)
                        return 0;
                    return prm.wk_prm_hp_rcv != 0 ? 1 : 0;

                case ItemData.PrmID.HP_EXP:
                    return prm.wk_prm_hp_exp != 0 ? 1 : 0;

                case ItemData.PrmID.POWER_EXP:
                    return prm.wk_prm_pow_exp != 0 ? 1 : 0;

                case ItemData.PrmID.DEFENCE_EXP:
                    return prm.wk_prm_def_exp != 0 ? 1 : 0;

                case ItemData.PrmID.AGILITY_EXP:
                    return prm.wk_prm_agi_exp != 0 ? 1 : 0;

                case ItemData.PrmID.SP_ATTACK_EXP:
                    return prm.wk_prm_spa_exp != 0 ? 1 : 0;

                case ItemData.PrmID.SP_DEFENCE_EXP:
                    return prm.wk_prm_spd_exp != 0 ? 1 : 0;

                case ItemData.PrmID.EXP_LIMIT_FLAG:
                    return ((int)prm.flags0 & ItemData.FLAG0_MASK_EXP_LIMIT) != 0 ? 1 : 0;

                case ItemData.PrmID.FRIEND1:
                    return prm.wk_friend1 != 0 ? 1 : 0;

                case ItemData.PrmID.FRIEND2:
                    return prm.wk_friend2 != 0 ? 1 : 0;

                case ItemData.PrmID.FRIEND3:
                    return prm.wk_friend3 != 0 ? 1 : 0;

                case ItemData.PrmID.HP_EXP_POINT:
                    return prm.wk_prm_hp_exp;

                case ItemData.PrmID.POWER_EXP_POINT:
                    return prm.wk_prm_pow_exp;

                case ItemData.PrmID.DEFENCE_EXP_POINT:
                    return prm.wk_prm_def_exp;

                case ItemData.PrmID.AGILITY_EXP_POINT:
                    return prm.wk_prm_agi_exp;

                case ItemData.PrmID.SP_ATTACK_EXP_POINT:
                    return prm.wk_prm_spa_exp;

                case ItemData.PrmID.SP_DEFENCE_EXP_POINT:
                    return prm.wk_prm_spd_exp;

                case ItemData.PrmID.HP_RCV_POINT:
                    return prm.wk_prm_hp_rcv;

                case ItemData.PrmID.PP_RCV_POINT:
                    return prm.wk_prm_pp_rcv;

                case ItemData.PrmID.FRIEND1_POINT:
                    return prm.wk_friend1;

                case ItemData.PrmID.FRIEND2_POINT:
                    return prm.wk_friend2;

                case ItemData.PrmID.FRIEND3_POINT:
                    return prm.wk_friend3;

                default:
                    GFL.ASSERT(false, "Invalid ItemData::PrmID");
                    return 0;
            }
        }

        public static uint GetHealingItemType(this ItemTable.SheetItem item)
        {
            int flags0 = (int)item.flags0;

            // Not WORK_TYPE → ETC
            if ((flags0 & ItemData.FLAG0_MASK_WORK_TYPE) == 0)
                return (uint)ItemData.ItemType.ETC;

            // ALLDEATH_RCV
            if ((flags0 & ItemData.FLAG0_MASK_ALLDEATH_RCV) != 0)
                return (uint)ItemData.ItemType.ALLDETH_RCV;

            // LV_UP
            if ((flags0 & ItemData.FLAG0_MASK_LV_UP) != 0)
                return (uint)ItemData.ItemType.LV_UP;

            // Build composite from 6 status cure flags
            int statusCure = 0;
            if ((flags0 & ItemData.FLAG0_MASK_SLEEP_RCV) != 0) statusCure |= 1;
            if ((flags0 & ItemData.FLAG0_MASK_POISON_RCV) != 0) statusCure |= 2;
            if ((flags0 & ItemData.FLAG0_MASK_BURN_RCV) != 0) statusCure |= 4;
            if ((flags0 & ItemData.FLAG0_MASK_ICE_RCV) != 0) statusCure |= 8;
            if ((flags0 & ItemData.FLAG0_MASK_PARALAYZE_RCV) != 0) statusCure |= 16;
            if ((flags0 & ItemData.FLAG0_MASK_PANIC_RCV) != 0) statusCure |= 32;

            if (statusCure <= 8)
            {
                switch (statusCure)
                {
                    case 1: return (uint)ItemData.ItemType.NEMURI_RCV;
                    case 2: return (uint)ItemData.ItemType.DOKU_RCV;
                    case 4: return (uint)ItemData.ItemType.YAKEDO_RCV;
                    case 8: return (uint)ItemData.ItemType.KOORI_RCV;
                }
            }
            else
            {
                if (statusCure == 16)
                    return (uint)ItemData.ItemType.MAHI_RCV;
                if (statusCure == 32)
                    return (uint)ItemData.ItemType.KONRAN_RCV;
                if (statusCure == 0x3f)
                {
                    if ((flags0 & (ItemData.FLAG0_MASK_DEATH_RCV | ItemData.FLAG0_MASK_ALLDEATH_RCV)) != 0)
                        return (uint)ItemData.ItemType.ALL_ST_RCV;
                    if (item.wk_prm_hp_rcv != 0)
                        return (uint)ItemData.ItemType.HP_RCV;
                    return (uint)ItemData.ItemType.ALL_ST_RCV;
                }
            }

            // MEROMERO_RCV
            if ((flags0 & ItemData.FLAG0_MASK_MEROMERO_RCV) != 0)
                return (uint)ItemData.ItemType.MEROMERO_RCV;

            // HP_RCV (only if no death recovery)
            if ((flags0 & (ItemData.FLAG0_MASK_DEATH_RCV | ItemData.FLAG0_MASK_ALLDEATH_RCV)) == 0
                && item.wk_prm_hp_rcv != 0)
                return (uint)ItemData.ItemType.HP_RCV;

            // DEATH_RCV
            if ((flags0 & ItemData.FLAG0_MASK_DEATH_RCV) != 0)
                return (uint)ItemData.ItemType.DEATH_RCV;

            // Stat increases/decreases (signed exp values)
            if (item.wk_prm_hp_exp > 0) return (uint)ItemData.ItemType.HP_UP;
            if (item.wk_prm_hp_exp < 0) return (uint)ItemData.ItemType.HP_DOWN;

            if (item.wk_prm_pow_exp > 0) return (uint)ItemData.ItemType.ATC_UP;
            if (item.wk_prm_pow_exp < 0) return (uint)ItemData.ItemType.ATC_DOWN;

            if (item.wk_prm_def_exp > 0) return (uint)ItemData.ItemType.DEF_UP;
            if (item.wk_prm_def_exp < 0) return (uint)ItemData.ItemType.DEF_DOWN;

            if (item.wk_prm_spa_exp > 0) return (uint)ItemData.ItemType.SPA_UP;
            if (item.wk_prm_spa_exp < 0) return (uint)ItemData.ItemType.SPA_DOWN;

            if (item.wk_prm_agi_exp > 0) return (uint)ItemData.ItemType.AGI_UP;
            if (item.wk_prm_agi_exp < 0) return (uint)ItemData.ItemType.AGI_DOWN;

            if (item.wk_prm_spd_exp > 0) return (uint)ItemData.ItemType.SPD_UP;
            if (item.wk_prm_spd_exp < 0) return (uint)ItemData.ItemType.SPD_DOWN;

            // EVOLUTION
            if ((flags0 & ItemData.FLAG0_MASK_EVOLUTION) != 0)
                return (uint)ItemData.ItemType.EVO;

            // PP_UP
            if ((flags0 & ItemData.FLAG0_MASK_PP_UP) != 0)
                return (uint)ItemData.ItemType.PP_UP;

            // PP_3UP
            if ((flags0 & ItemData.FLAG0_MASK_PP_3UP) != 0)
                return (uint)ItemData.ItemType.PP_3UP;

            // PP_RCV
            if ((flags0 & ItemData.FLAG0_MASK_PP_RCV) != 0)
                return (uint)ItemData.ItemType.PP_RCV;

            // ALLPP_RCV → PP_RCV type
            if ((flags0 & ItemData.FLAG0_MASK_ALLPP_RCV) != 0)
                return (uint)ItemData.ItemType.PP_RCV;

            return (uint)ItemData.ItemType.ETC;
        }

        public static bool IsNeedSelectSkill(this ItemTable.SheetItem item)
        {
            uint healType = item.GetHealingItemType();
            if (healType == (uint)ItemData.ItemType.PP_UP || healType == (uint)ItemData.ItemType.PP_3UP)
                return true;
            if (healType != (uint)ItemData.ItemType.PP_RCV)
                return false;
            return item.GetParam(ItemData.PrmID.PP_RCV) != 0;
        }

        public static bool IsDeathRecoverAllItem(this ItemTable.SheetItem item)
        {
            return ((int)item.flags0 & ItemData.FLAG0_MASK_WORK_TYPE) != 0
                && ((int)item.flags0 & ItemData.FLAG0_MASK_ALLDEATH_RCV) != 0;
        }

        public static bool IsSale(this ItemTable.SheetItem item)
        {
            return ((int)item.flags0 & ItemData.FLAG0_MASK_IMP) == 0 && item.price != 0;
        }

        public static bool IsEventItem(this ItemTable.SheetItem item)
        {
            return item.type == Pml.ItemType.EVENT;
        }

        public static int GetGroupId(this ItemTable.SheetItem item)
        {
            return item.group_id;
        }

        public static BallId GetBallID(this ItemTable.SheetItem item)
        {
            if (item.group != ItemGroup.BALL)
                return BallId.NULL;
            return (BallId)(item.group_id + 1);
        }

        public static bool IsWazaMachine(this ItemTable.SheetItem item)
        {
            return item.group == ItemGroup.WAZA_MACHINE;
        }

        public static uint GetWazaMashineNo(this ItemTable.SheetItem item)
        {
            if (!item.IsWazaMachine())
                return ItemData.ITEM_WAZAMACHINE_ERROR;
            return (uint)item.group_id;
        }

        public static bool IsWazaRecord(this ItemTable.SheetItem item)
        {
            return item.IsWazaMachine() && ((int)item.flags0 & ItemData.FLAG0_MASK_IMP) == 0;
        }

        public static bool IsNuts(this ItemTable.SheetItem item)
        {
            return item.group == ItemGroup.NUTS;
        }

        public static byte GetNutsNo(this ItemTable.SheetItem item)
        {
            if (!item.IsNuts())
                return ItemData.NUTS_ID_ERROR;
            return item.group_id;
        }

        public static bool IsGroupOf(this ItemTable.SheetItem item, byte itemgroup)
        {
            return item.group == itemgroup;
        }

        public static bool IsMegaStone(this ItemTable.SheetItem item)
        {
            return item.group == ItemGroup.MEGA_STONE;
        }

        public static bool IsJewel(this ItemTable.SheetItem item)
        {
            return item.group == ItemGroup.JEWEL;
        }

        public static bool IsPiece(this ItemTable.SheetItem item)
        {
            return item.group == ItemGroup.PIECE;
        }

        public static bool IsBeads(this ItemTable.SheetItem item)
        {
            return item.group == ItemGroup.BEADS;
        }

        public static bool IsHeart(this ItemTable.SheetItem item)
        {
            return item.group == ItemGroup.HEART;
        }

        public static bool CanPokeHave(this ItemTable.SheetItem item)
        {
            return ((int)item.flags0 & ItemData.FLAG0_MASK_SET_TO_POKE) != 0;
        }

        public static uint GetTypeSortNumber(this ItemTable.SheetItem item)
        {
            return (uint)(((uint)item.type << 28) | ((uint)item.sort << 16)) + (uint)(short)item.no;
        }
    }
}
