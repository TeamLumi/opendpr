namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_MemberChange : Section
	{
		public Section_FromEvent_MemberChange(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSucceeded = false;

			if (!canMemberChange(description.outPokeID))
				return;

			BTL_POKEPARAM outPoke = GetPokeParam(description.outPokeID);

			if (description.startMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.startMessage);
			}

			if (!memberOut(outPoke, description.isInterruptDisable))
				return;

			if (description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage);
			}

			result.isSucceeded = true;
		}

		private bool canMemberChange(byte pokeID)
		{
			BTL_POKEPARAM poke = GetPokeParam(pokeID);
			if (poke.IsDead())
				return false;

			BTL_CLIENT_ID clientID = PokeID.PokeIdToClientId(pokeID);
			byte posIdx = PokeID.PokeIdToStartMemberIndex(pokeID);
			BTL_PARTY party = GetPokeParty((byte)clientID);

			if (party.GetAliveMemberCountRear((byte)(posIdx + 1)) == 0)
				return false;

			return true;
		}

		private bool memberOut(BTL_POKEPARAM outPoke, bool isInterruptDisable)
		{
			Section_MemberOut section = new Section_MemberOut(GetCommonParam());
			Section_MemberOut.Description desc = new Section_MemberOut.Description();
			Section_MemberOut.Result res = new Section_MemberOut.Result();

			desc.outPoke = outPoke;
			desc.isInterruptDisable = isInterruptDisable;

			section.Execute(res, desc);
			return res.isOutSuccessed;
		}

		public class Description
		{
			public byte outPokeID;
			public bool isInterruptDisable;
			public bool isDisplayTokuseiWindow;
			public StrParam startMessage = new StrParam();
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				outPokeID = PokeID.INVALID;
				isInterruptDisable = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}