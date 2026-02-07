using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_UseItem_Force : Section
	{
		public Section_FromEvent_UseItem_Force(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isUsed = false;

			BTL_POKEPARAM userPoke = GetPokeParam(description.userPokeID);
			BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID);

			var useItemDesc = new Section_UseItem_Core.Description();
			useItemDesc.poke = userPoke;
			useItemDesc.itemID = description.itemID;
			useItemDesc.actParam = 0;
			useItemDesc.targetID = description.targetPokeID;

			var useItemResult = new Section_UseItem_Core.Result();
			var useItemSection = new Section_UseItem_Core(GetCommonParam());
			useItemSection.Execute(useItemResult, in useItemDesc);

			bool isUsed = useItemResult.isConsumed;
			result.isUsed = isUsed;

			var cmdParam = new ServerCommandPutter.UseItemCommandParam();
			cmdParam.pokeID = description.targetPokeID;
			cmdParam.itemno = description.itemID;

			displayItemEffect(in cmdParam, description.useEffectType, isUsed);

			if (isUsed)
			{
				if (description.isAteKinomi)
				{
					GetServerCommandPutter().ConsumeItem(targetPoke, description.itemID);
				}

				afterItemEquip(targetPoke, description.itemID);
			}
		}

		private void displayItemEffect(in ServerCommandPutter.UseItemCommandParam param, UseEffectType effectType, bool isUsed)
		{
			if (effectType == UseEffectType.Disable)
			{
				return;
			}

			if (effectType == UseEffectType.Force || isUsed)
			{
				GetServerCommandPutter().PutUseItemCommands(in param);
			}
		}

		private void afterItemEquip(BTL_POKEPARAM poke, ushort itemID)
		{
			GetEventLauncher().Event_AfterItemEquip(poke, itemID, true);
		}

		public enum UseEffectType : int
		{
			Normal = 0,
			Force = 1,
			Disable = 2,
		}

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public ushort itemID;
			public bool isAteKinomi;
			public UseEffectType useEffectType;

			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isAteKinomi = false;
				useEffectType = UseEffectType.Normal;
			}
		}

		public class Result
		{
			public bool isUsed;
		}
	}
}
