namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SwapPoke : Section
	{
		public Section_FromEvent_SwapPoke(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSwapped = false;

			BTL_POKEPARAM poke1 = GetPokeParam(description.pokeID1);
			BTL_POKEPARAM poke2 = GetPokeParam(description.pokeID2);

			if (poke1.IsDead() || poke2.IsDead())
				return;

			BtlPokePos pos1 = GetPokePos(poke1);
			BtlPokePos pos2 = GetPokePos(poke2);

			if (pos1 == BtlPokePos.POS_NULL || pos2 == BtlPokePos.POS_NULL)
				return;

			byte clientID = (byte)PokeID.PokeIdToClientId(description.pokeID1);

			GetServerCommandPutter().SwapPokePos(clientID, pos1, pos2);
			GetServerCommandPutter().Act_SwapPokePos(clientID, pos1, pos2);

			if (description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage);
			}

			afterMoveEvent(poke1);
			afterMoveEvent(poke2);

			result.isSwapped = true;
		}

		private void afterMoveEvent(BTL_POKEPARAM poke)
		{
			GetEventLauncher().Event_AfterMove(poke);
		}

		public class Description
		{
			public byte pokeID1;
			public byte pokeID2;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID1 = PokeID.INVALID;
				pokeID2 = PokeID.INVALID;
			}
		}

		public class Result
		{
			public bool isSwapped;
		}
	}
}