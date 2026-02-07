namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNoEffect_Core : Section
	{
		public Section_CheckNoEffect_Core(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			pResult.isNoEffect = false;
			StrParam customMessage = new StrParam();

			GetEventLauncher().Event_CheckNotEffect(
				description.wazaParam, description.attacker, description.target,
				description.affinityRecorder, description.eventID,
				out bool isNoEffect, out bool isNoReaction, out bool isNoEffectMessageDisplayed,
				out bool isTokuseiWindowDisplay, customMessage);

			if (isNoEffect)
			{
				pResult.isNoEffect = true;
				if (description.fEnableMessage && !isNoEffectMessageDisplayed)
				{
					displayMessage(description.target.GetID(), isTokuseiWindowDisplay, customMessage);
				}
			}
		}

		private void displayMessage(byte pokeID, bool isTokuseiWindowDisplay, in StrParam strParam)
		{
			if (isTokuseiWindowDisplay)
			{
				GetServerCommandPutter().TokWin_In(pokeID);
			}
			GetServerCommandPutter().Message(strParam);
			if (isTokuseiWindowDisplay)
			{
				GetServerCommandPutter().TokWin_Out(pokeID);
			}
		}

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public DmgAffRec affinityRecorder;
			public EventID eventID;
			public bool fEnableMessage;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				target = null;
				affinityRecorder = null;
				eventID = EventID.INVALID;
				fEnableMessage = true;
			}
		}

		public class Result
		{
			public bool isNoEffect;
		}
	}
}