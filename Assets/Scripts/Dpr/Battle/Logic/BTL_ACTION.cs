using Pml;

namespace Dpr.Battle.Logic
{
	public static class BTL_ACTION
	{
		public static void SetFightParam(ref BTL_ACTION_PARAM p, byte pokeID, WazaNo waza, BtlPokePos targetPos, bool forbidGWaza = false, bool forceGWaza = false)
		{
			var uVar1 = 0x100000000;
			if (!forbidGWaza) {
			  uVar1 = 0;
			}
			var uVar2 = 0x200000000;
			if (!forceGWaza) {
			  uVar2 = 0;
			}
			p = (ulong)(uint)(pokeID << 4) & 0x1f0 | (ulong)(((int)waza & 0xffff) << 0xd) | uVar1 |
			           (ulong)(uint)((int)targetPos << 9) & 0x1e00 | uVar2 | 1;
		}
		
		public static void ChangeFightTargetPos(ref BTL_ACTION_PARAM p, BtlPokePos nextTargetPos)
		{
			ulong uVar1 = default;
			if ((((int)nextTargetPos & 0xff) != 5) && (uVar1 = p, (uVar1 & 0xf) == 1)) {
			  p = uVar1 & 0xffffffffffffe000 | uVar1 & 0x1ff | ((ulong)((int)nextTargetPos & 0x7fffff) & 0xf) << 9
			  ;
			}
		}
		
		public static void FightParamToWazaInfoMode(ref BTL_ACTION_PARAM p)
		{
			if ((p & 0xf) == 1) {
			  p = p | 0x20000000;
			}
		}
		
		public static bool IsWazaInfoMode(ref BTL_ACTION_PARAM p)
		{
			return (p & 0x2000000f) == 0x20000001;
		}
		
		public static bool IsFight(ref BTL_ACTION_PARAM p)
		{
			return (p & 0xf) == 1;
		}
		
		public static bool IsFightWithG(ref BTL_ACTION_PARAM p)
		{
			return (p & 0x8000000f) == 0x80000001;
		}
		
		public static bool IsGStart(ref BTL_ACTION_PARAM p)
		{
			return (p & 0xf) == 6;
		}
		
		public static bool IsItem(ref BTL_ACTION_PARAM p)
		{
			return (p & 0xf) == 2;
		}
		
		public static bool IsCheer(ref BTL_ACTION_PARAM p)
		{
			return (p & 0xf) == 7;
		}
		
		public static WazaNo GetWazaID(ref BTL_ACTION_PARAM act)
		{
			var uVar1 = (uint)act >> 0xd & 0xffff;
			if ((act & 0xf) != 1) {
			  uVar1 = 0;
			}
			return uVar1;
		}
		
		public static BtlPokePos GetWazaTargetPos(ref BTL_ACTION_PARAM act)
		{
			var uVar1 = (uint)act >> 9 & 0xf;
			if ((act & 0xf) != 1) {
			  uVar1 = 5;
			}
			return uVar1;
		}
		
		public static WazaNo GetOriginalWazaID(ref BTL_ACTION_PARAM act)
		{
			var uVar1 = (uint)act >> 0xd & 0xffff;
			if ((act & 0xf) != 1) {
			  uVar1 = 0;
			}
			return uVar1;
		}
		
		public static void SetItemParam(ref BTL_ACTION_PARAM p, byte pokeID, ushort itemNumber, byte targetID, byte wazaIdx)
		{
			p = (itemNumber & 0xffff) << 0x11 |
			           (ulong)(uint)(pokeID << 4) & 0x1f0 | (targetID & 0xff) << 9 |
			           (ulong)(wazaIdx & 0xff) << 0x21 | 2;
		}
		
		public static void SetChangeParam(ref BTL_ACTION_PARAM p, byte posIdx, byte memberIdx)
		{
			p = (ulong)(uint)(posIdx << 9) & 0xe00 | (ulong)(uint)(memberIdx << 0xc) & 0x7000 | 3;
		}
		
		public static void SetChangeDepleteParam(ref BTL_ACTION_PARAM p)
		{
			p = 0x81f3;
		}
		
		public static bool IsDeplete(in BTL_ACTION_PARAM p)
		{
			return (p & 0x800f) == 0x8003;
		}
		
		public static void SetEscapeParam(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p = (ulong)(uint)(pokeID << 4) & 0x1f0 | p & 0xfffffffffffffe00 | 4;
		}
		
		public static void SetCheer(ref BTL_ACTION_PARAM p)
		{
			p = p & 0xfffffffffffffe00 | 0x1f7;
		}
		
		public static void SetSafariBall(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p = (ulong)(uint)(pokeID << 4) & 0x1f0 | p & 0xfffffffffffffe00 | 10;
		}
		
		public static void SetSafariEsa(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p = (ulong)(uint)(pokeID << 4) & 0x1f0 | p & 0xfffffffffffffe00 | 0xb;
		}
		
		public static void SetSafariDoro(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p = (ulong)(uint)(pokeID << 4) & 0x1f0 | p & 0xfffffffffffffe00 | 0xc;
		}
		
		public static void SetSafariYousumi(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p = (ulong)(uint)(pokeID << 4) & 0x1f0 | p & 0xfffffffffffffe00 | 0xd;
		}
		
		public static void SetNULL(ref BTL_ACTION_PARAM p)
		{
			p = null;
		}
		
		public static void SetSkip(ref BTL_ACTION_PARAM p, byte pokeID)
		{
			p = (ulong)(uint)(pokeID << 4) & 0x1f0 | p & 0xfffffffffffffe00 | 5;
		}
		
		public static BtlAction GetAction(in BTL_ACTION_PARAM p)
		{
			return p & 0xf;
		}
		
		public static void SetRecPlayOver(ref BTL_ACTION_PARAM act)
		{
			act = act & 0x1f0 | 8;
		}
		
		public static void SetRecPlayError(ref BTL_ACTION_PARAM act)
		{
			act = act & 0x1f0 | 9;
		}
	}
}