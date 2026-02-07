namespace Dpr.Battle.Logic
{
	public sealed class Section_ChangeWeather_After : Section
	{
		public Section_ChangeWeather_After(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            GetEventLauncher().Event_AfterChangeWeather(description.weather);
        }

		public class Description
		{
			public BtlWeather weather;
			
			public Description()
			{
				weather = BtlWeather.BTL_WEATHER_NONE;
			}
		}

		public class Result { }
	}
}