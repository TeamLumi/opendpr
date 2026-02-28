using System;

namespace Dpr.UI
{
	public class BattleMatchingSelectRule
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private UIInputController _inputController = new UIInputController();
		private Action _onSelectMember;
		private Action _onDecideMember;
		private Action _onLeave;
		private Action _onRule;
		private Action _onFinishState;
		private SelectRuleState currentState;
		private bool _closed;
		private bool _opendLeaveMsg;
		private bool _isWaitDecideRule;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private int nowSelectPlayerIndex;
		
		public void Initialize(Action onFinishState, Action onSelectMember, Action onDecideMember, Action onRule, Action onLeave)
		{
			this._onFinishState = onFinishState;
			this._onSelectMember = onSelectMember;
			this._onDecideMember = onDecideMember;
			this._onRule = onRule;
			this._onLeave = onLeave;
			this._opendLeaveMsg = false;
			this.currentState = (SelectRuleState)0;
		}
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
		public void PreClose()
		{
			this._closed = true;
			this._battleMatchingUIPtr.CloseMessageWindow();
			this._battleMatchingUIPtr.CloseContextMenu();
		}
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateSelectMine() { }
		
		// TODO
		public void SelectMember() { }
		
		// TODO
		private void UpdateWaitOtherDecide() { }
		
		// TODO
		private void OnSelectMember(int index) { }
		
		// TODO
		private void WaitSelectMember() { }
		
		private void SelectRule()
		{
			this._battleMatchingUIPtr.CloseMessageWindow();
			this._battleMatchingUIPtr.CloseContextMenu();
			this._battleMatchingUIPtr.OpenSelectRuleWindow();
			this.currentState = (SelectRuleState)1;
			this._opendLeaveMsg = 0x100;
		}
		
		// TODO
		public void WaitSelectRule(int stationIndex) { }
		
		// TODO
		public void SetReady() { }
		
		// TODO
		private void UpdateReady(float deltaTime) { }
		
		private void CloseAllMsg()
		{
			this._battleMatchingUIPtr.CloseMessageWindow();
			this._battleMatchingUIPtr.CloseContextMenu();
		}

		private enum SelectRuleState : int
		{
			None = 0,
			SelectMine = 1,
			SelectOther = 2,
			Ready = 3,
			Finish = 4,
		}
	}
}