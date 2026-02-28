using System;

namespace Dpr.UI
{
	public class BattleMatchingSelectBattleTeam
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private UIBattleMatchingTeamSelect _teamSelect;
		private UIInputController _inputController = new UIInputController();
		private Action _onFinishState;
		private Action _onLeave;
		private Action _onSelect;
		private Action _onCancel;
		private bool _ready;
		private bool _closed;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private bool _openingWindow;
		private bool _openedTeamSelect;
		private State _currentState;
		
		public void Initialize(Action onFinishState, Action onLeave, Action onSelect, Action onCancel)
		{
			this._onFinishState = onFinishState;
			this._onLeave = onLeave;
			this._onSelect = onSelect;
			this._onCancel = onCancel;
		}
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		// TODO
		public bool CanClose() { return default; }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void ChangeState(State state) { }
		
		// TODO
		private void SetPreparationIconReady() { }
		
		// TODO
		public void SetPreparationIconReady(int stationIndex) { }
		
		// TODO
		public void SetPreparationIconWait(int stationIndex) { }
		
		// TODO
		private void ShowSelectLeave() { }
		
		// TODO
		private void OnSelectLeave(int index) { }

		private enum State : int
		{
			None = 0,
			Rule = 1,
			Select = 2,
			Wait = 3,
		}
	}
}