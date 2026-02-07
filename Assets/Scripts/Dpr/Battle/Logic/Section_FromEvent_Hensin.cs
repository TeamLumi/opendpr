using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Hensin : Section
	{
		public Section_FromEvent_Hensin(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSucceeded = false;

			BTL_POKEPARAM userPoke = GetPokeParam(description.userPokeID);
			BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID);

			if (userPoke.IsDead() || targetPoke.IsDead())
				return;

			if (!userPoke.HENSIN_CheckEnable(targetPoke))
				return;

			TokuseiNo prevTokusei = (TokuseiNo)userPoke.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI);

			GetServerCommandPutter().Op_Hensin(description.userPokeID, description.targetPokeID);
			GetServerCommandPutter().Act_Hensin(description.userPokeID, description.targetPokeID);

			if (description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage);
			}

			TokuseiNo nextTokusei = (TokuseiNo)userPoke.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI);

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(description.userPokeID);
				GetServerCommandPutter().TokWin_Out(description.userPokeID);
			}

			afterTokuseiChanged_Event(userPoke);
			afterTokuseiChanged_Item(userPoke, prevTokusei, nextTokusei);

			result.isSucceeded = true;
		}

		private void afterTokuseiChanged_Event(BTL_POKEPARAM poke)
		{
			Section_AfterTokuseiChanged_Event section = new Section_AfterTokuseiChanged_Event(GetCommonParam());
			Section_AfterTokuseiChanged_Event.Description desc = new Section_AfterTokuseiChanged_Event.Description();
			Section_AfterTokuseiChanged_Event.Result res = new Section_AfterTokuseiChanged_Event.Result();

			desc.poke = poke;
			section.Execute(res, desc);
		}

		private void afterTokuseiChanged_Item(BTL_POKEPARAM poke, TokuseiNo prevTokusei, TokuseiNo nextTokusei)
		{
			Section_AfterTokuseiChanged_Item section = new Section_AfterTokuseiChanged_Item(GetCommonParam());
			Section_AfterTokuseiChanged_Item.Description desc = new Section_AfterTokuseiChanged_Item.Description();
			Section_AfterTokuseiChanged_Item.Result res = new Section_AfterTokuseiChanged_Item.Result();

			desc.poke = poke;
			desc.prevTokusei = prevTokusei;
			desc.nextTokusei = nextTokusei;

			section.Execute(res, desc);
		}

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public bool isDisplayTokuseiWindow;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}