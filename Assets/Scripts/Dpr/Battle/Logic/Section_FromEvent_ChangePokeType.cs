namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ChangePokeType : Section
	{
		public Section_FromEvent_ChangePokeType(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			PokeTypePair currentType = poke.GetPokeType();

			if (currentType.value == description.nextType.value)
			{
				if (description.isFailMessageEnable)
				{
					GetServerCommandPutter().Message(description.changedMessage);
				}
				result.isSuccessed = false;
				return;
			}

			result.isSuccessed = GetServerCommandPutter().ChangePokeType(description.pokeID, description.nextType, description.exTypeCause);
			if (result.isSuccessed)
			{
				if (!description.isStandardMessageDisable)
				{
					GetServerCommandPutter().Message(description.changedMessage);
				}
			}
		}

		public class Description
		{
			public byte pokeID;
			public PokeTypePair nextType;
			public BTL_POKEPARAM.ExTypeCause exTypeCause;
			public bool isStandardMessageDisable;
			public bool isFailMessageEnable;
			public bool isDisplayTokuseiWindow;
			public StrParam changedMessage = new StrParam();

            public Description()
			{
				pokeID = PokeID.INVALID;
				nextType = (PokeTypePair)0;
				exTypeCause = BTL_POKEPARAM.ExTypeCause.EXTYPE_CAUSE_NONE;
				isStandardMessageDisable = false;
				isFailMessageEnable = false;
				isDisplayTokuseiWindow = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}