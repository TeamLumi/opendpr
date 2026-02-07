using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_UseItemEquip : Section
	{
		public Section_UseItemEquip(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isUsed = false;

			BTL_POKEPARAM pPoke = GetPokeParam(description.userPokeID);
			if (pPoke == null)
			{
				return;
			}

			if (!description.isUseDead && pPoke.IsDead())
			{
				return;
			}

			if (!pPoke.IsFightEnable() && !description.isUseDead)
			{
				return;
			}

			FieldStatus fieldStatus = GetBattleEnv().GetFieldStatus();
			ushort itemID = pPoke.GetItemEffective(in fieldStatus);
			if (itemID == (ushort)ItemNo.DUMMY_DATA)
			{
				return;
			}

			if (description.isSkipHPFull && pPoke.IsHPFull())
			{
				return;
			}

			var useItemDesc = new Section_UseItem_Core.Description();
			useItemDesc.poke = pPoke;
			useItemDesc.itemID = itemID;
			useItemDesc.actParam = 0;
			useItemDesc.targetID = description.userPokeID;

			var useItemResult = new Section_UseItem_Core.Result();
			var useItemSection = new Section_UseItem_Core(GetCommonParam());
			useItemSection.Execute(useItemResult, in useItemDesc);

			if (useItemResult.isConsumed)
			{
				section_ChangeItem(pPoke);
				section_AfterItemEquip(pPoke, itemID);
				pResult.isUsed = true;
			}
		}

		private void section_ChangeItem(BTL_POKEPARAM pPoke)
		{
			var desc = new Section_ChangeItem.Description();
			desc.poke = pPoke;
			desc.nextItemID = (ushort)ItemNo.DUMMY_DATA;
			desc.isPrevItemConsumed = true;

			var result = new Section_ChangeItem.Result();
			var section = new Section_ChangeItem(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void section_AfterItemEquip(BTL_POKEPARAM pPoke, ushort itemID)
		{
			var desc = new Section_AfterItemEquip.Description();
			desc.poke = pPoke;
			desc.itemID = itemID;
			desc.isKinomiCheckEnable = true;

			var result = new Section_AfterItemEquip.Result();
			var section = new Section_AfterItemEquip(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public byte userPokeID = PokeID.INVALID;
			public bool isSkipHPFull;
			public bool isUseDead;
		}

		public class Result
		{
			public bool isUsed;
		}
	}
}
