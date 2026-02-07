namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_GetWeather : Section
	{
		public Section_FromEvent_GetWeather(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BtlWeather weather = GetEventLauncher().Event_GetWeather();
			result.weather = GetEventLauncher().Event_CheckLocalWeather(description.pokeID, weather);
		}

		public class Description
		{
			public byte pokeID;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public BtlWeather weather;
		}
	}
}