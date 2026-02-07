using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetItem : Section
	{
		public Section_FromEvent_SetItem(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSucceeded = false;

			BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID);

			if (description.isClearConsume)
			{
				GetServerCommandPutter().ClearConsumedItem(description.targetPokeID);
			}
			if (description.isClearConsumeOtherPoke)
			{
				GetServerCommandPutter().ClearConsumedItem(description.clearConsumePokeID);
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(description.userPokeID);
			}

			changeItem(targetPoke, description.itemID, description.isConsumeItem);

			if (description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage);
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_Out(description.userPokeID);
			}

			if (description.isCallConsumedEvent)
			{
				GetEventLauncher().Event_AfterItemEquip(targetPoke, description.itemID, true);
			}

			checkItemReaction(targetPoke);

			result.isSucceeded = true;
		}

		private void changeItem(BTL_POKEPARAM poke, ushort nextItemID, bool isConsume)
		{
			ushort prevItemID = poke.GetItem();
			if (prevItemID != (ushort)ItemNo.DUMMY_DATA && isConsume)
			{
				GetServerCommandPutter().ConsumeItem(poke, prevItemID);
			}
			GetServerCommandPutter().SetItem(poke, nextItemID);
		}

		private void checkItemReaction(BTL_POKEPARAM poke)
		{
			GetEventLauncher().Event_CheckItemReaction(poke, 0);
		}

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public ushort itemID;
			public bool isClearConsume;
			public bool isClearConsumeOtherPoke;
			public byte clearConsumePokeID;
			public bool isCallConsumedEvent;
			public bool isDisplayTokuseiWindow;
			public bool isConsumeItem;
			public StrParam successMessage = new StrParam();

			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isClearConsume = false;
				isClearConsumeOtherPoke = false;
				clearConsumePokeID = PokeID.INVALID;
				isCallConsumedEvent = false;
				isDisplayTokuseiWindow = false;
				isConsumeItem = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}
