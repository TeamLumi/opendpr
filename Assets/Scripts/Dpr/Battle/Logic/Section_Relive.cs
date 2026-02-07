namespace Dpr.Battle.Logic
{
	public sealed class Section_Relive : Section
	{
		public Section_Relive(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			BTL_CLIENT_ID clientID = PokeID.PokeIdToClientId(description.pokeID);
			BtlPokePos pokePos = GetPokePos(poke);

			// Display the relive message
			if (description.reliveMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.reliveMessage);
			}

			// Recover HP
			GetServerCommandPutter().SimpleHp(poke, (int)description.recoverHP, DamageCause.OTHER, PokeID.INVALID, true);

			// Perform member-in (re-entry to battle)
			byte posIdx = (byte)pokePos;
			byte nextPokeIdx = (byte)GetPokeParty((byte)clientID).FindMember(poke);
			byte inPokeID = memberIn((byte)clientID, posIdx, nextPokeIdx);

			// Run after-member-in logic
			afterMemberIn(inPokeID);
		}

		private byte memberIn(byte clientID, byte posIdx, byte nextPokeIdx)
		{
			var desc = new Section_MemberInCore.Description();
			desc.clientID = clientID;
			desc.posIdx = posIdx;
			desc.nextPokeIdx = nextPokeIdx;

			var result = new Section_MemberInCore.Result();
			var section = new Section_MemberInCore(GetCommonParam());
			section.Execute(result, in desc);

			return result.inPokeID;
		}

		private void afterMemberIn(byte inPokeID)
		{
			// Fire ability-triggered effects after member-in (e.g. Intimidate)
			BTL_POKEPARAM poke = GetPokeParam(inPokeID);

			var desc = new Section_KintyoukanMoved.Description();
			desc.movedPoke = poke;

			var result = new Section_KintyoukanMoved.Result();
			var section = new Section_KintyoukanMoved(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public byte pokeID;
			public ushort recoverHP;
			public StrParam reliveMessage = new StrParam();

			public Description()
			{
				pokeID = PokeID.INVALID;
				recoverHP = 0;
			}
		}

		public class Result { }
	}
}
