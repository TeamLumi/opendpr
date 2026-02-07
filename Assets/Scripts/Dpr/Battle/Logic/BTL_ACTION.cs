using Pml;

namespace Dpr.Battle.Logic
{
	public static class BTL_ACTION
	{
		public static void SetFightParam(ref BTL_ACTION_PARAM p, byte pokeID, WazaNo waza, BtlPokePos targetPos, bool forbidGWaza = false, bool forceGWaza = false)
		{
			p.raw = 0;
			p.fight_cmd = (byte)BtlAction.BTL_ACTION_FIGHT;
			p.fight_pokeID = pokeID;
			p.fight_waza = (ushort)waza;
			p.fight_targetPos = (byte)targetPos;
			p.fight_wazaInfoFlag = false;
			p.fight_forbidGWaza = forbidGWaza;
			p.fight_forceGWaza = forceGWaza;
		}

		public static void ChangeFightTargetPos(ref BTL_ACTION_PARAM p, BtlPokePos nextTargetPos)
		{
			p.fight_targetPos = (byte)nextTargetPos;
		}

		public static void FightParamToWazaInfoMode(ref BTL_ACTION_PARAM p)
		{
			p.fight_wazaInfoFlag = true;
		}

		public static bool IsWazaInfoMode(ref BTL_ACTION_PARAM p)
		{
			return p.fight_wazaInfoFlag;
		}

		public static bool IsFight(ref BTL_ACTION_PARAM p)
		{
			return p.gen_cmd == (byte)BtlAction.BTL_ACTION_FIGHT;
		}

		public static bool IsFightWithG(ref BTL_ACTION_PARAM p)
		{
			return p.gen_cmd == (byte)BtlAction.BTL_ACTION_FIGHT && p.fight_gFlag;
		}

		public static bool IsGStart(ref BTL_ACTION_PARAM p)
		{
			return p.gen_cmd == (byte)BtlAction.BTL_ACTION_G_START;
		}

		public static bool IsItem(ref BTL_ACTION_PARAM p)
		{
			return p.gen_cmd == (byte)BtlAction.BTL_ACTION_ITEM;
		}

		public static bool IsCheer(ref BTL_ACTION_PARAM p)
		{
			return p.gen_cmd == (byte)BtlAction.BTL_ACTION_CHEER;
		}

		public static WazaNo GetWazaID(ref BTL_ACTION_PARAM act)
		{
			return (WazaNo)act.fight_waza;
		}

		public static BtlPokePos GetWazaTargetPos(ref BTL_ACTION_PARAM act)
		{
			return (BtlPokePos)act.fight_targetPos;
		}

		public static WazaNo GetOriginalWazaID(ref BTL_ACTION_PARAM act)
		{
			return (WazaNo)act.fight_waza;
		}

		public static void SetItemParam(ref BTL_ACTION_PARAM p, byte pokeID, ushort itemNumber, byte targetID, byte wazaIdx)
		{
			p.raw = 0;
			p.item_cmd = (byte)BtlAction.BTL_ACTION_ITEM;
			p.item_pokeID = pokeID;
			p.item_number = itemNumber;
			p.item_targetID = targetID;
			p.item_param = wazaIdx;
		}

		public static void SetChangeParam(ref BTL_ACTION_PARAM p, byte posIdx, byte memberIdx)
		{
			p.raw = 0;
			p.change_cmd = (byte)BtlAction.BTL_ACTION_CHANGE;
			p.change_posIdx = posIdx;
			p.change_memberIdx = memberIdx;
			p.change_depleteFlag = false;
		}

		public static void SetChangeDepleteParam(ref BTL_ACTION_PARAM p)
		{
			p.raw = 0;
			p.change_cmd = (byte)BtlAction.BTL_ACTION_CHANGE;
			p.change_depleteFlag = true;
		}

		public static bool IsDeplete(in BTL_ACTION_PARAM p)
		{
			return p.gen_cmd == (byte)BtlAction.BTL_ACTION_CHANGE && p.change_depleteFlag;
		}

		public static void SetEscapeParam(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p.raw = 0;
			p.escape_cmd = (byte)BtlAction.BTL_ACTION_ESCAPE;
			p.escape_pokeID = pokeID;
		}

		public static void SetCheer(ref BTL_ACTION_PARAM p)
		{
			p.raw = 0;
			p.cheer_cmd = (byte)BtlAction.BTL_ACTION_CHEER;
		}

		public static void SetSafariBall(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p.raw = 0;
			p.gen_cmd = (byte)BtlAction.BTL_ACTION_SAFARI_BALL;
			p.gen_pokeID = pokeID;
		}

		public static void SetSafariEsa(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p.raw = 0;
			p.gen_cmd = (byte)BtlAction.BTL_ACTION_SAFARI_ESA;
			p.gen_pokeID = pokeID;
		}

		public static void SetSafariDoro(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p.raw = 0;
			p.gen_cmd = (byte)BtlAction.BTL_ACTION_SAFARI_DORO;
			p.gen_pokeID = pokeID;
		}

		public static void SetSafariYousumi(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p.raw = 0;
			p.gen_cmd = (byte)BtlAction.BTL_ACTION_SAFARI_YOUSUMI;
			p.gen_pokeID = pokeID;
		}

		public static void SetNULL(ref BTL_ACTION_PARAM p)
		{
			p.raw = 0;
			p.gen_cmd = (byte)BtlAction.BTL_ACTION_NULL;
		}

		public static void SetSkip(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p.raw = 0;
			p.gen_cmd = (byte)BtlAction.BTL_ACTION_SKIP;
			p.gen_pokeID = pokeID;
		}

		public static BtlAction GetAction(in BTL_ACTION_PARAM p)
		{
			return (BtlAction)p.gen_cmd;
		}

		public static void SetRecPlayOver(ref BTL_ACTION_PARAM act)
		{
			act.raw = 0;
			act.gen_cmd = (byte)BtlAction.BTL_ACTION_RECPLAY_TIMEOVER;
		}

		public static void SetRecPlayError(ref BTL_ACTION_PARAM act)
		{
			act.raw = 0;
			act.gen_cmd = (byte)BtlAction.BTL_ACTION_RECPLAY_ERROR;
		}
	}
}
