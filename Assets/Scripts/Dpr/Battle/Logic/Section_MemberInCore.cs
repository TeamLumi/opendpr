namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberInCore : Section
	{
		public Section_MemberInCore(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			byte clientID = description.clientID;
			byte posIdx = description.posIdx;
			byte nextPokeIdx = description.nextPokeIdx;

			// Get the party member about to enter
			BTL_PARTY party = GetPokeParty(clientID);
			BTL_POKEPARAM poke = party.GetMemberDataConst(nextPokeIdx);
			byte pokeID = poke.GetID();

			// Register the member-in via server command (clears data, sets position)
			GetServerCommandPutter().MemberIn(clientID, posIdx, nextPokeIdx, 0);

			// Play the member-in visual
			GetServerCommandPutter().Act_MemberIn(clientID, posIdx, nextPokeIdx, true);

			// Clear the pokemon's data for entering battle
			poke.Clear_ForIn();

			// Check trainer battle talk for last-poke-in message
			checkBattleTalk(pokeID);

			pResult.inPokeID = pokeID;
		}

		private void checkBattleTalk(byte pokeID)
		{
			// Trainer "last pokemon" message is handled by the client-side TrainerMessageManager
			// This is triggered when the trainer's last pokemon enters battle
		}

		public class Description
		{
			public byte clientID;
			public byte posIdx;
			public byte nextPokeIdx;

			public Description()
			{
				clientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
				posIdx = 0;
				nextPokeIdx = 0;
			}
		}

		public class Result
		{
			public byte inPokeID;
		}
	}
}
