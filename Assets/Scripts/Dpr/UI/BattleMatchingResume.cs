using System;

namespace Dpr.UI
{
	public class BattleMatchingResume
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private Action _onFinishState;
		private Action<bool> _onSelect;
		private Action _onLeve;
		private bool _resume;
		private bool _ready;
		private bool _closed;
		private bool _finished;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private UIInputController _inputController = new UIInputController();
		
		public void Initialize(Action onFinishState, Action<bool> onSelect, Action onLeve)
		{
			this._onFinishState = onFinishState;
			this._onSelect = onSelect;
			this._onLeve = onLeve;
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
		private void ShowSelectResume() { }
		
		private void OnSelectResume(int index)
		{
			if ((!this._closed) && (!this._ready)) {
			  this._battleMatchingUIPtr.CloseMessageWindow();
			  if (index != 0) {
			    ShowSelectLeave();
			  }
			  OnSelect(1);
			}
		}
		
		// TODO
		private void ShowSelectLeave() { }
		
		private void OnSelectLeave(int index)
		{
			if ((!this._closed) && (!this._ready)) {
			  this._battleMatchingUIPtr.CloseMessageWindow();
			  if (index != 0) {
			    ShowSelectResume();
			  }
			  OnSelect();
			}
		}
		
		// TODO
		private void OnSelect(bool resume) { }
		
		// TODO
		public void Resume() { }
	}
}