namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ChangeWeather : Section
	{
		public Section_FromEvent_ChangeWeather(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		private void endWeather_byAirLock(byte userPokeID, bool isTokuseiWindowDisplay, in StrParam successMessage)
		{
			var uVar1 = userPokeID.GetPokeParam();
			if (isTokuseiWindowDisplay) {
			  this.m_pServerCmdPutter.TokWin_In(uVar1);
			}
			this.m_pServerCmdPutter.Message(successMessage);
			this.m_pEventLauncher.Event_NotifyAirLock();
			if (isTokuseiWindowDisplay) {
			  this.m_pServerCmdPutter.TokWin_Out(uVar1);
			}
		}
		
		// TODO
		private void endWeather() { }
		
		// TODO
		private void endWeather_After() { }
		
		// TODO
		private void startDefaultWeather() { }
		
		// TODO
		private bool changeWeather(in Description description) { return default; }
		
		// TODO
		private ChangeWeatherResult checkWeatherChangeEnable(BtlWeather weather, byte turn) { return default; }
		
		// TODO
		private void changeWeather_Success(byte userPokeID, BtlWeather weather, byte turn, byte turnUpCount, in StrParam successMessage, bool isDisplayTokuseiWindow) { }
		
		// TODO
		private void changeWeatherCore(BtlWeather weather, byte turn, byte turnUpCount, byte causePokeID) { }
		
		// TODO
		private void changeWeather_Fail(byte userPokeID, bool isTokuseiWindowDisplay) { }

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