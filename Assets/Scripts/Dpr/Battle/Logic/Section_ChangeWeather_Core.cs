namespace Dpr.Battle.Logic
{
	public sealed class Section_ChangeWeather_Core : Section
	{
		public Section_ChangeWeather_Core(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			GetServerCommandPutter().StartWeather(description.weather, description.turn,
				description.turnUpCount, description.causePokeID, description.cause);

			afterChangeWeather(description.weather);
		}

		private void afterChangeWeather(BtlWeather weather)
		{
			var afterDesc = new Section_ChangeWeather_After.Description();
			afterDesc.weather = weather;
			var afterResult = new Section_ChangeWeather_After.Result();
			var afterSection = new Section_ChangeWeather_After(GetCommonParam());
			afterSection.Execute(afterResult, in afterDesc);
		}

		private void checkBattleTalk(byte pokeID, BtlWeather weather)
		{
			// Battle talk is handled client-side by TrainerMessageManager
		}

		public class Description
		{
			public BtlWeather weather;
			public byte turn;
			public byte turnUpCount;
			public byte causePokeID;
			public ChangeWeatherCause cause;

			public Description()
			{
				weather = BtlWeather.BTL_WEATHER_NONE;
				turn = 0;
				turnUpCount = 0;
				causePokeID = PokeID.INVALID;
				cause = ChangeWeatherCause.OTHERS;
			}
		}

		public class Result { }
	}
}
