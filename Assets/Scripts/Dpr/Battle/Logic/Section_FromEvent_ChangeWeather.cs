namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ChangeWeather : Section
	{
		public Section_FromEvent_ChangeWeather(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;

			if (description.byAirLock)
			{
				endWeather_byAirLock(description.userPokeID, description.isDisplayTokuseiWindow, in description.successMessage);
				result.isSuccessed = true;
				return;
			}

			result.isSuccessed = changeWeather(in description);
		}

		private void endWeather_byAirLock(byte userPokeID, bool isTokuseiWindowDisplay, in StrParam successMessage)
		{
			endWeather();

			if (isTokuseiWindowDisplay)
			{
				GetServerCommandPutter().TokWin_In(userPokeID);
			}

			if (successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in successMessage);
			}

			if (isTokuseiWindowDisplay)
			{
				GetServerCommandPutter().TokWin_Out(userPokeID);
			}
		}

		private void endWeather()
		{
			GetServerCommandPutter().EndWeather();
		}

		private void endWeather_After()
		{
			BtlWeather currentWeather = GetBattleEnv().GetFieldStatus().GetWeather();
			var desc = new Section_ChangeWeather_After.Description();
			desc.weather = currentWeather;
			var afterResult = new Section_ChangeWeather_After.Result();
			var afterSection = new Section_ChangeWeather_After(GetCommonParam());
			afterSection.Execute(afterResult, in desc);
		}

		private void startDefaultWeather()
		{
			BtlWeather defaultWeather = GetMainModule().GetDefaultWeather();
			if (defaultWeather != BtlWeather.BTL_WEATHER_NONE)
			{
				changeWeatherCore(defaultWeather, 0, 0, PokeID.INVALID);
			}
		}

		private bool changeWeather(in Description description)
		{
			ChangeWeatherResult checkResult = checkWeatherChangeEnable(description.weather, description.turn);

			switch (checkResult)
			{
				case ChangeWeatherResult.OK:
					changeWeather_Success(description.userPokeID, description.weather, description.turn, description.turnUpCount, in description.successMessage, description.isDisplayTokuseiWindow);
					return true;

				case ChangeWeatherResult.FAIL:
					changeWeather_Fail(description.userPokeID, description.isDisplayTokuseiWindow);
					return false;

				case ChangeWeatherResult.FAIL_CANT_OVERWRITE:
					changeWeather_Fail(description.userPokeID, description.isDisplayTokuseiWindow);
					return false;

				default:
					return false;
			}
		}

		private ChangeWeatherResult checkWeatherChangeEnable(BtlWeather weather, byte turn)
		{
			FieldStatus fieldStatus = GetBattleEnv().GetFieldStatus();
			BtlWeather currentWeather = fieldStatus.GetWeather();

			if (weather == BtlWeather.BTL_WEATHER_NONE)
			{
				return ChangeWeatherResult.OK;
			}

			if (currentWeather == weather)
			{
				return ChangeWeatherResult.FAIL;
			}

			byte refTurn = turn;
			if (!GetEventLauncher().Event_CheckChangeWeather(weather, ref refTurn))
			{
				return ChangeWeatherResult.FAIL_CANT_OVERWRITE;
			}

			return ChangeWeatherResult.OK;
		}

		private void changeWeather_Success(byte userPokeID, BtlWeather weather, byte turn, byte turnUpCount, in StrParam successMessage, bool isDisplayTokuseiWindow)
		{
			BtlWeather prevWeather = GetBattleEnv().GetFieldStatus().GetWeather();

			if (prevWeather != BtlWeather.BTL_WEATHER_NONE)
			{
				endWeather();
				endWeather_After();
			}

			if (weather != BtlWeather.BTL_WEATHER_NONE)
			{
				changeWeatherCore(weather, turn, turnUpCount, userPokeID);
			}
			else
			{
				startDefaultWeather();
			}

			if (isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(userPokeID);
			}

			if (successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in successMessage);
			}

			if (isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_Out(userPokeID);
			}

			endWeather_After();
		}

		private void changeWeatherCore(BtlWeather weather, byte turn, byte turnUpCount, byte causePokeID)
		{
			GetServerCommandPutter().StartWeather(weather, turn, turnUpCount, causePokeID, ChangeWeatherCause.OTHERS);
		}

		private void changeWeather_Fail(byte userPokeID, bool isTokuseiWindowDisplay)
		{
			if (isTokuseiWindowDisplay)
			{
				GetServerCommandPutter().TokWin_In(userPokeID);
				GetServerCommandPutter().TokWin_Out(userPokeID);
			}
		}

		public class Description
		{
			public byte userPokeID;
			public BtlWeather weather;
			public byte turn;
			public byte turnUpCount;
			public bool byAirLock;
			public StrParam successMessage = new StrParam();
			public bool isDisplayTokuseiWindow;

			public Description()
			{
				userPokeID = PokeID.INVALID;
				isDisplayTokuseiWindow = false;
				weather = BtlWeather.BTL_WEATHER_NONE;
				turn = 0;
				turnUpCount = 0;
				byAirLock = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}
