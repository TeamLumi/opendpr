using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaSick : Section
	{
		public Section_WazaSick(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isSuccess = false;

			BTL_POKEPARAM attacker = description.attacker;
			BTL_POKEPARAM target = description.target;
			WazaSick sickID = description.sick;
			SickCause cause = description.cause;
			uint actionSerialNo = description.actionSerialNo;

			if (sickID == WazaSick.WAZASICK_NONE)
			{
				return;
			}

			BTL_SICKCONTOBJ sickCont = new BTL_SICKCONTOBJ(description.sickCont);

			bool isFailed = addSickCheckFail(attacker, target, sickID, sickCont, cause, actionSerialNo,
				description.isFailResultDisplay_ByBasicRules,
				description.isFailResultDisplay_BySpecialFactors,
				description.isOtherEffectDisplayed);

			if (!isFailed)
			{
				StrParam specialMessage = new StrParam();
				addSick(attacker, target, sickID, sickCont, specialMessage);
				pResult.isSuccess = true;
			}
		}

		private bool addSickCheckFail(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONTOBJ sickCont, SickCause cause, uint actionSerialNo, bool isFailResultDisplay_ByBasicRules, bool isFailResultDisplay_BySpecialFactors, bool isOtherEffectDisplayed)
		{
			var desc = new Section_AddSickCheckFail.Description();
			desc.attacker = attacker;
			desc.target = target;
			desc.sick = sick;
			desc.sickCont = sickCont.value;
			desc.sickCause = cause;
			desc.wazaSerial = actionSerialNo;
			desc.isFailResultDisplay_ByBasicRules = isFailResultDisplay_ByBasicRules;
			desc.isFailResultDisplay_BySpecialFactors = isFailResultDisplay_BySpecialFactors;
			desc.isOtherEffectDisplayed = isOtherEffectDisplayed;

			var result = new Section_AddSickCheckFail.Result();
			var section = new Section_AddSickCheckFail(GetCommonParam());
			section.Execute(result, in desc);

			return result.isFail;
		}

		private void addSick(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONTOBJ sickCont, StrParam specialMessage)
		{
			var desc = new Section_AddSick_Core.Description();
			desc.attacker = attacker;
			desc.target = target;
			desc.sick = sick;
			desc.sickCont = sickCont.value;
			desc.isEffectDisplay = true;
			desc.isDefaultMessageDisplay = true;
			desc.specialMessage = specialMessage;

			var result = new Section_AddSick_Core.Result();
			var section = new Section_AddSick_Core(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public WazaSick sick;
			public BTL_SICKCONT sickCont;
			public SickCause cause;
			public uint actionSerialNo;
			public bool isFailResultDisplay_ByBasicRules;
			public bool isFailResultDisplay_BySpecialFactors;
			public bool isOtherEffectDisplayed;

			public Description()
			{
				attacker = null;
				target = null;
				sick = WazaSick.WAZASICK_NONE;
				sickCont = default;
				cause = SickCause.OTHER;
				actionSerialNo = 0;
				isFailResultDisplay_ByBasicRules = false;
				isFailResultDisplay_BySpecialFactors = false;
				isOtherEffectDisplayed = false;
			}
		}

		public class Result
		{
			public bool isSuccess;
		}
	}
}
