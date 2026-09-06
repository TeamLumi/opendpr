using System.Text;

namespace Dpr.NetworkUtils
{
	public class CountDownTimer
	{
		private const string ZERO_MINUT = "00";
		private const int SECOND = 60;

		private StringBuilder timeSb = new StringBuilder();
		private float remaingTime;
		private int remainingCount;
		private bool isCountDown;
		private float realTime;
		
		// TODO
		public void StartCountDown(float startTime) { }
		
		public bool IsCountDown { get => isCountDown; }
		public int RemainingCount { get => remainingCount; }
		
		// TODO
		public bool IsChangeCountDown() { return default; }
		
		public void SetTimeCount(int timeCount) {
		    this.remainingCount = timeCount;
		}
		
		// TODO
		public string GetMinuteStr() { return default; }
		
		// TODO
		public string GetSecondStr() { return default; }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
	}
}