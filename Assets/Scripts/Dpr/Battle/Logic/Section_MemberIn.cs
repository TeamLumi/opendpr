namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberIn : Section
	{
		public Section_MemberIn(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			// Perform the member-in
			pResult.inPokeID = memberIn(description.clientID, description.posIdx, description.nextPokeIdx);
		}

		private byte memberIn(byte clientID, byte posIdx, byte nextPokeIdx)
		{
			// Delegate to the core member-in section
			var desc = new Section_MemberInCore.Description();
			desc.clientID = clientID;
			desc.posIdx = posIdx;
			desc.nextPokeIdx = nextPokeIdx;

			var result = new Section_MemberInCore.Result();
			var section = new Section_MemberInCore(GetCommonParam());
			section.Execute(result, in desc);

			byte inPokeID = result.inPokeID;

			// Check battle talk for the entering pokemon
			checkBattleTalk(inPokeID);

			return inPokeID;
		}

		private void checkBattleTalk(byte pokeID)
		{
			// Trainer battle talk (e.g., "Go! <Pokemon>!") is handled client-side
		}

		public class Description
		{
			public byte clientID;
			public byte posIdx;
			public byte nextPokeIdx;
			public bool isPutMessage;

			public Description()
			{
				clientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
				posIdx = 0;
				nextPokeIdx = 0;
				isPutMessage = false;
			}
		}

		public class Result
		{
			public byte inPokeID;
		}
	}
}
