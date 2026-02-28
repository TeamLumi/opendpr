using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_UseItem_Core : Section
	{
		private const int RANGE_FULL = 0;
		private const int RANGE_VIEW = 1;
		private const int RANGE_FRONT = 2;

		private const int AREA_FRONT = 0;
		private const int AREA_BACK = 1;
		private const int AREA_RESERVE = 2;

		private ItemEffectInfo[] s_itemEffectTableInstance;
		
		// TODO
		private ItemEffectInfo[] s_itemEffectTable { get; }
		
		public Section_UseItem_Core(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool canUseEscapeItem() { return default; }
		
		// TODO
		private BTL_POKEPARAM getTaragetInfo(out byte pTargetArea, out BtlPokePos pTargetPos, byte targetPokeID)
		{
			pTargetArea = default;
			pTargetPos = default;
			return default;
		}
		
		// TODO
		private void useBall(BTL_POKEPARAM userPoke, ushort itemID, out bool pIsUsed, out bool pIsCaptured, POKE_CAPTURED_CONTEXT pCaptureContext)
		{
			pIsUsed = default;
			pIsCaptured = default;
		}
		
		// TODO
		private BTL_POKEPARAM decideBallTarget(out BtlPokePos pTargetPos, BTL_POKEPARAM userPoke)
		{
			pTargetPos = default;
			return default;
		}
		
		// TODO
		private int decideCaptureValueCoef(BTL_POKEPARAM pUserPoke, BTL_POKEPARAM pTargetPoke) { return default; }
		
		// TODO
		private void useBallForbidden(ushort itemID, BtlPokePos targetPos, BallThrowForbiddenCause cause) { }
		
		// TODO
		private bool canUseItem(ushort itemID, byte targetArea, BtlPokePos targetPos) { return default; }
		
		private bool ItemEff_SleepRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			uint uVar2;
			var uVar1 = itemID.IsDead();
			if ((!uVar1) &&
			   (uVar1 = itemID.CheckSick(2), uVar1)) {
			  uVar2 = 1;
			  makeCmd_CureSick(bpp,itemID,2,1);
			}
			else {
			  uVar2 = 0;
			}
			return uVar2;
		}
		
		private bool ItemEff_PoisonRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			uint uVar2;
			var uVar1 = itemID.IsDead();
			if ((!uVar1) &&
			   (uVar1 = itemID.CheckSick(5), uVar1)) {
			  uVar2 = 1;
			  makeCmd_CureSick(bpp,itemID,5,1);
			}
			else {
			  uVar2 = 0;
			}
			return uVar2;
		}
		
		private bool ItemEff_YakedoRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			uint uVar2;
			var uVar1 = itemID.IsDead();
			if ((!uVar1) &&
			   (uVar1 = itemID.CheckSick(4), uVar1)) {
			  uVar2 = 1;
			  makeCmd_CureSick(bpp,itemID,4,1);
			}
			else {
			  uVar2 = 0;
			}
			return uVar2;
		}
		
		private bool ItemEff_KooriRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			uint uVar2;
			var uVar1 = itemID.IsDead();
			if ((!uVar1) &&
			   (uVar1 = itemID.CheckSick(3), uVar1)) {
			  uVar2 = 1;
			  makeCmd_CureSick(bpp,itemID,3,1);
			}
			else {
			  uVar2 = 0;
			}
			return uVar2;
		}
		
		private bool ItemEff_MahiRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			uint uVar2;
			var uVar1 = itemID.IsDead();
			if ((!uVar1) &&
			   (uVar1 = itemID.CheckSick(1), uVar1)) {
			  uVar2 = 1;
			  makeCmd_CureSick(bpp,itemID,1,1);
			}
			else {
			  uVar2 = 0;
			}
			return uVar2;
		}
		
		private bool ItemEff_KonranRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			uint uVar2;
			var uVar1 = itemID.IsDead();
			if ((!uVar1) &&
			   (uVar1 = itemID.CheckSick(6), uVar1)) {
			  uVar2 = 1;
			  makeCmd_CureSick(bpp,itemID,6,1);
			}
			else {
			  uVar2 = 0;
			}
			return uVar2;
		}
		
		private bool ItemEff_MeromeroRcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			uint uVar2;
			var uVar1 = itemID.IsDead();
			if ((!uVar1) &&
			   (uVar1 = itemID.CheckSick(7), uVar1)) {
			  uVar2 = 1;
			  makeCmd_CureSick(bpp,itemID,7,1);
			}
			else {
			  uVar2 = 0;
			}
			return uVar2;
		}
		
		// TODO
		private bool ItemEff_Mental_Cure(BTL_POKEPARAM bpp, ushort itemID, int itemParam, WazaSick sickID) { return default; }
		
		// TODO
		private bool ItemEff_Common_Cure(BTL_POKEPARAM bpp, ushort itemID, int itemParam, WazaSick sickID) { return default; }
		
		// TODO
		private void makeCmd_CureSick(BTL_POKEPARAM bpp, WazaSick sickID, bool bStdMsg) { }
		
		// TODO
		private bool ItemEff_EffectGuard(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_Relive(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		private bool ItemEff_AttackRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			ulong uVar3 = default;
			var uVar2 = itemID.GetID();
			var cVar1 = bpp.GetPokePos(uVar2);
			if (((cVar1 == '\x05') ||
			    (uVar3 = itemID.IsDead(), (uVar3 & 1) != 0)) ||
			   (uVar3 = itemID.IsRankEffectValid(1,actParam),
			   (uVar3 & 1) == 0)) {
			  uVar2 = 0;
			}
			else {
			  uVar2 = 1;
			  makeCmd_RankEffect(bpp,itemID,1,actParam);
			}
			return uVar2;
		}
		
		private bool ItemEff_DefenceRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			ulong uVar3 = default;
			var uVar2 = itemID.GetID();
			var cVar1 = bpp.GetPokePos(uVar2);
			if (((cVar1 != '\x05') &&
			    (uVar3 = itemID.IsDead(), (uVar3 & 1) == 0)) &&
			   (uVar3 = itemID.IsRankEffectValid(2,actParam),
			   (uVar3 & 1) != 0)) {
			  makeCmd_RankEffect(bpp,itemID,2,actParam);
			  return true;
			}
			return false;
		}
		
		private bool ItemEff_SPAttackRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			ulong uVar3 = default;
			var uVar2 = itemID.GetID();
			var cVar1 = bpp.GetPokePos(uVar2);
			if (((cVar1 != '\x05') &&
			    (uVar3 = itemID.IsDead(), (uVar3 & 1) == 0)) &&
			   (uVar3 = itemID.IsRankEffectValid(3,actParam),
			   (uVar3 & 1) != 0)) {
			  makeCmd_RankEffect(bpp,itemID,3,actParam);
			  return true;
			}
			return false;
		}
		
		private bool ItemEff_SPDefenceRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			ulong uVar3 = default;
			var uVar2 = itemID.GetID();
			var cVar1 = bpp.GetPokePos(uVar2);
			if (((cVar1 != '\x05') &&
			    (uVar3 = itemID.IsDead(), (uVar3 & 1) == 0)) &&
			   (uVar3 = itemID.IsRankEffectValid(4,actParam),
			   (uVar3 & 1) != 0)) {
			  makeCmd_RankEffect(bpp,itemID,4,actParam);
			  return true;
			}
			return false;
		}
		
		private bool ItemEff_AgilityRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			ulong uVar3 = default;
			var uVar2 = itemID.GetID();
			var cVar1 = bpp.GetPokePos(uVar2);
			if (((cVar1 != '\x05') &&
			    (uVar3 = itemID.IsDead(), (uVar3 & 1) == 0)) &&
			   (uVar3 = itemID.IsRankEffectValid(5,actParam),
			   (uVar3 & 1) != 0)) {
			  makeCmd_RankEffect(bpp,itemID,5,actParam);
			  return true;
			}
			return false;
		}
		
		private bool ItemEff_HitRank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			ulong uVar3 = default;
			var uVar2 = itemID.GetID();
			var cVar1 = bpp.GetPokePos(uVar2);
			if (((cVar1 != '\x05') &&
			    (uVar3 = itemID.IsDead(), (uVar3 & 1) == 0)) &&
			   (uVar3 = itemID.IsRankEffectValid(6,actParam),
			   (uVar3 & 1) != 0)) {
			  makeCmd_RankEffect(bpp,itemID,6,actParam);
			  return true;
			}
			return false;
		}
		
		// TODO
		private bool ItemEff_Common_Rank(BTL_POKEPARAM bpp, ushort itemID, int itemParam, BTL_POKEPARAM.ValueID rankType) { return default; }
		
		// TODO
		private void makeCmd_RankEffect(BTL_POKEPARAM bpp, WazaRankEffect rankType, int volume) { }
		
		private bool ItemEff_CriticalUp(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam)
		{
			var uVar2 = bpp.CONTFLAG_Get(9);
			if (uVar2) {
			  return false;
			}
			this.m_pServerCmdPutter.SetContFlag(bpp,9);
			var uVar1 = bpp.GetID();
			this.m_pServerCmdPutter.Message_Set(0x582,uVar1);
			return true;
		}
		
		// TODO
		private bool ItemEff_PP_Rcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool ItemEff_AllPP_Rcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private bool makeCmd_RecoverAllPP(BTL_POKEPARAM bpp, byte recoverLimit, bool bStdMsg) { return default; }
		
		// TODO
		private bool ItemEff_HP_Rcv(BTL_POKEPARAM bpp, ushort itemID, int itemParam, byte actParam) { return default; }
		
		// TODO
		private void makeCmd_RecoverHP(BTL_POKEPARAM bpp, uint recoverHP, bool bStdMsg) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ushort itemID;
			public byte actParam;
			public byte targetID;
			public POKE_CAPTURED_CONTEXT capContext;
			
			public Description()
			{
				poke = null;
				capContext = null;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				actParam = 0;
				targetID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public TrainerItemResult useResult;
			public bool isConsumed;
			public bool isUsedBall;
		}

		private delegate bool ItemEffectFuncPtr(BTL_POKEPARAM target, ushort itemID, int itemParam, byte actParam);

		private class ItemEffectInfo
		{
			public Pml.Item.ItemData.PrmID effect;
			public byte range;
			public ItemEffectFuncPtr func;
			
			public ItemEffectInfo(Pml.Item.ItemData.PrmID effect, byte range, ItemEffectFuncPtr func)
			{
				this.func = func;
				this.effect = effect;
				this.range = range;
			}
		}
	}
}