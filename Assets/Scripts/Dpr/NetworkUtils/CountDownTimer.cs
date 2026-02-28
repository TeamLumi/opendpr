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
		
		public void SetTimeCount(int timeCount)
		{
			this.remainingCount = timeCount;
		}
		
		// TODO
		public string GetMinuteStr() { return default; }
		
		// TODO
		public string GetSecondStr() { return default; }
		
		public void OnUpdate(float deltaTime)
		{
			float fVar2 = default;
			if (this.isCountDown) {
			  var fVar1 = (float)0.realtimeSinceStartup;
			  this.realTime = fVar1;
			  this.remaingTime = this.remaingTime - (fVar1 - fVar2);
			  if (this.remaingTime - (fVar1 - fVar2) + 1.0 <= 0.0) {
			    this.remaingTime = 0;
			    this.isCountDown = false;
			  }
			}
		}
	}
}