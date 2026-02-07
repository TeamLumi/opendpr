namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SwapItem : Section
	{
		public Section_FromEvent_SwapItem(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSucceeded = false;

			BTL_POKEPARAM userPoke = GetPokeParam(description.userPokeID);
			BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID);

			ushort userItem = userPoke.GetItem();
			ushort targetItem = targetPoke.GetItem();

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(description.userPokeID);
			}

			changeItem(userPoke, targetItem);
			changeItem(targetPoke, userItem);

			if (description.successMessage1.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage1);
			}
			if (description.successMessage2.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage2);
			}
			if (description.successMessage3.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage3);
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_Out(description.userPokeID);
			}

			if (description.isIncRecordCount_StealItemFromWildPoke)
			{
				incRecord_StealItemFromWildPoke(description.targetPokeID, targetItem);
			}

			checkItemReaction(userPoke);
			checkItemReaction(targetPoke);

			result.isSucceeded = true;
		}

		private void changeItem(BTL_POKEPARAM poke, ushort nextItemID)
		{
			GetServerCommandPutter().SetItem(poke, nextItemID);
		}

		private void checkItemReaction(BTL_POKEPARAM poke)
		{
			GetEventLauncher().Event_CheckItemReaction(poke, 0);
		}

		private void incRecord_StealItemFromWildPoke(byte targetPokeID, ushort targetItem)
		{
			// Record keeping for stealing items from wild pokemon (PGL record counter)
		}

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public bool isIncRecordCount_StealItemFromWildPoke;
			public bool isDisplayTokuseiWindow;
			public StrParam successMessage1 = new StrParam();
			public StrParam successMessage2 = new StrParam();
			public StrParam successMessage3 = new StrParam();

			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				isIncRecordCount_StealItemFromWildPoke = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}
