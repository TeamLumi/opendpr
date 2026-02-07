namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FormChange : Section
	{
		public Section_FromEvent_FormChange(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isChanged = false;

			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);

			if (!description.isEnableInCaseOfDead && poke.IsDead())
			{
				return;
			}

			if (poke.GetFormNo() == description.formNo)
			{
				return;
			}

			formChange(description);
			result.isChanged = true;
		}

		private void formChange(in Description description)
		{
			ServerCommandPutter scp = GetServerCommandPutter();

			scp.ChangeForm(description.pokeID, description.formNo, description.isDontResetFormByOut);

			if (description.isDisplayTokuseiWindow)
			{
				scp.TokWin_In(description.pokeID);
			}

			if (description.isDisplayChangeEffect)
			{
				scp.Act_ChangeForm(description.pokeID);
			}

			if (description.successMessage.IsEnable())
			{
				scp.Message(description.successMessage);
			}

			if (description.isDisplayTokuseiWindow)
			{
				scp.TokWin_Out(description.pokeID);
			}
		}

		public class Description
		{
			public byte pokeID;
			public byte formNo;
			public bool isDontResetFormByOut;
			public bool isEnableInCaseOfDead;
			public bool isDisplayTokuseiWindow;
			public bool isDisplayChangeEffect;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				formNo = 0;
				isDontResetFormByOut = false;
				isEnableInCaseOfDead = false;
				isDisplayTokuseiWindow = false;
				isDisplayChangeEffect = true;
			}
		}

		public class Result
		{
			public bool isChanged;
		}
	}
}