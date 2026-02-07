namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ConsumeItem : Section
	{
		public Section_FromEvent_ConsumeItem(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.userPokeID);
			if (poke.IsDead())
				return;

			ushort itemID = poke.GetItem();
			if (itemID == 0)
				return;

			if (!description.isUseActionDisable)
			{
				GetServerCommandPutter().UseItemAct(poke);
			}

			if (description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage);
			}

			removeItem(poke);

			bool isKinomiCheckEnable = !description.isKinomiCheckDisable;
			afterItemEquip(poke, itemID, isKinomiCheckEnable);
		}

		private void removeItem(BTL_POKEPARAM poke)
		{
			ushort itemID = poke.GetItem();
			GetServerCommandPutter().ConsumeItem(poke, itemID);
		}

		private void afterItemEquip(BTL_POKEPARAM poke, ushort itemID, bool isKinomiCheckEnable)
		{
			GetEventLauncher().Event_AfterItemEquip(poke, itemID, isKinomiCheckEnable);
		}

		public class Description
		{
			public byte userPokeID;
			public bool isUseActionDisable;
			public bool isKinomiCheckDisable;
			public bool isConsumeMessageEnable;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				isUseActionDisable = false;
				isKinomiCheckDisable = false;
				isConsumeMessageEnable = false;
			}
		}

		public class Result { }
	}
}