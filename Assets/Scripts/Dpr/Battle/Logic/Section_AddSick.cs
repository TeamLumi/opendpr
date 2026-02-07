using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_AddSick : Section
	{
		public Section_AddSick(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;

			BTL_POKEPARAM attacker = GetPokeParam(description.pokeID);
			BTL_POKEPARAM target = GetPokeParam(description.targetPokeID);

			if (!description.isEffectiveToDeadPoke && target.IsDead())
			{
				return;
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(description.pokeID);
			}

			bool isFail = checkFail(attacker, target, description.sickID, description.sickCont,
				description.sickCause, 0, description.overWriteMode, description.isFailResultDisplay);

			if (!isFail)
			{
				addSick(attacker, target, description.sickID, description.sickCont,
					description.isEffectDisplay, !description.isStandardMessageDisable,
					in description.specialMessage, description.isItemReactionDisable);
				result.isSuccessed = true;
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_Out(description.pokeID);
			}
		}

		private bool checkFail(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONT sickCont, SickCause sickCause, uint wazaSerial, SickOverWriteMode overWriteMode, bool isFailResultDisplay)
		{
			var checkFailDesc = new Section_AddSickCheckFail.Description();
			checkFailDesc.attacker = attacker;
			checkFailDesc.target = target;
			checkFailDesc.sick = sick;
			checkFailDesc.sickCont = sickCont;
			checkFailDesc.sickCause = sickCause;
			checkFailDesc.wazaSerial = wazaSerial;
			checkFailDesc.overWriteMode = overWriteMode;
			checkFailDesc.isFailResultDisplay_ByBasicRules = isFailResultDisplay;
			checkFailDesc.isFailResultDisplay_BySpecialFactors = isFailResultDisplay;

			var checkFailResult = new Section_AddSickCheckFail.Result();
			var checkFailSection = new Section_AddSickCheckFail(GetCommonParam());
			checkFailSection.Execute(checkFailResult, in checkFailDesc);

			return checkFailResult.isFail;
		}

		private void addSick(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONT sickCont, bool isEffectDisplay, bool isDefaultMessageDisplay, in StrParam specialMessage, bool isItemReactionDisable)
		{
			var coreDesc = new Section_AddSick_Core.Description();
			coreDesc.attacker = attacker;
			coreDesc.target = target;
			coreDesc.sick = sick;
			coreDesc.sickCont = sickCont;
			coreDesc.isEffectDisplay = isEffectDisplay;
			coreDesc.isDefaultMessageDisplay = isDefaultMessageDisplay;
			coreDesc.specialMessage = specialMessage;
			coreDesc.isItemReactionDisable = isItemReactionDisable;

			var coreResult = new Section_AddSick_Core.Result();
			var coreSection = new Section_AddSick_Core(GetCommonParam());
			coreSection.Execute(coreResult, in coreDesc);
		}

		public class Description
		{
			public byte pokeID;
			public byte targetPokeID;
			public WazaSick sickID;
			public BTL_SICKCONT sickCont;
			public SickCause sickCause;
			public SickOverWriteMode overWriteMode;
			public bool isDisplayTokuseiWindow;
			public bool isFailResultDisplay;
			public bool isEffectDisplay;
			public bool isStandardMessageDisable;
			public bool isItemReactionDisable;
			public bool isEffectiveToDeadPoke;
			public StrParam specialMessage = new StrParam();

			public Description()
			{
				pokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				sickID = WazaSick.WAZASICK_NONE;
				sickCont = default;
				isEffectDisplay = true;
				isStandardMessageDisable = false;
				isItemReactionDisable = false;
				isEffectiveToDeadPoke = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}
