using System;

namespace Dpr.UI
{
	public class BattleMatchingResult
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private Action _onFinishState;
		private bool _ready;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private bool _closed;
		
		public void Initialize(Action onFinishState)
		{
			this._onFinishState = onFinishState;
		}
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		public void PreClose()
		{
			this._closed = true;
		}
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void LoadModel() { }
	}
}