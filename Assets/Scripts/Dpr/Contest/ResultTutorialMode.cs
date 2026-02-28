using Dpr.SubContents;

namespace Dpr.Contest
{
	public class ResultTutorialMode
	{
		private ShowMessageWindow resultMsg = new ShowMessageWindow();
		private State currentState;
		private float waitMsgDuration;
		private float timer;
		private int playCount;
		private bool bRestart;
		private bool bRunning;
		
		public void OnFinalize()
		{
			this.resultMsg.OnFinalize();
		}
		
		public bool IsSelectRestart { get => bRestart; }
		
		// TODO
		public void Setup(ResultSettings setting) { }
		
		// TODO
		public void StartAnimation() { }
		
		// TODO
		private void FirstPlayAnimation() { }
		
		// TODO
		private void PlayAnimation() { }
		
		// TODO
		public bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		private void UpdateWaitMsg(float deltaTime) { }
		
		// TODO
		private void ChangeState(State nextState) { }

		private enum State : int
		{
			None = 0,
			WaitMsg = 1,
			WaitContextMenu = 2,
		}
	}
}