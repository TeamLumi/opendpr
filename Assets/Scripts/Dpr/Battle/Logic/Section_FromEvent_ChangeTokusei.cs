using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ChangeTokusei : Section
	{
		public Section_FromEvent_ChangeTokusei(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isChanged = false;

			BTL_POKEPARAM target = GetPokeParam(description.targetPokeID);

			TokuseiNo prevTokusei = (TokuseiNo)target.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI);

			if (!description.isEffectiveToSameTokusei && prevTokusei == description.tokuseiID)
			{
				return;
			}

			if (!GetEventLauncher().Event_CheckTokuseiChangeEnable(description.targetPokeID, description.tokuseiID, description.cause))
			{
				GetEventLauncher().Event_TokuseiChangeFailed(description.targetPokeID, description.tokuseiID, description.cause);
				return;
			}

			GetEventLauncher().Event_ChangeTokuseiBefore(description.targetPokeID, prevTokusei, (ushort)description.tokuseiID);

			GetServerCommandPutter().ChangeTokusei(description.targetPokeID, description.tokuseiID);

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(description.targetPokeID);
			}

			if (description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(description.successMessage);
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_Out(description.targetPokeID);
			}

			GetEventLauncher().Event_ChangeTokuseiAfter(description.targetPokeID);

			if (!description.isSkipMemberInEvent)
			{
				afterTokuseiChanged_Item(target, prevTokusei, description.tokuseiID);
			}

			result.isChanged = true;
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
			public TokuseiNo tokuseiID;
			public TokuseiChangeCause cause;
			public bool isEffectiveToSameTokusei;
			public bool isSkipMemberInEvent;
			public bool isDisplayTokuseiWindow;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				tokuseiID = TokuseiNo.NULL;
				cause = TokuseiChangeCause.TOKUSEI_CHANGE_CAUSE_OTHER;
				isEffectiveToSameTokusei = false;
				isSkipMemberInEvent = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isChanged;
		}
	}
}