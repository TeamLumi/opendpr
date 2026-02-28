using Dpr.Message;
using System;
using System.Collections.Generic;

namespace Dpr.UI
{
	public class BattleMatchingSelectTeamMember
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private Action _onFinishState;
		private Action<int, int> _onSelect;
		private Action _onDecide;
		private List<int> _orderPlayers;
		private MessageMsgFile _msgFile;
		private UIInputController _inputController = new UIInputController();
		private bool _closed;
		
		// TODO
		public void Initialize(Action onFinishState, Action<int, int> onSelect, Action onDecide) { }
		
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
		public void DecideTeam() { }
		
		// TODO
		private void ShowSelectMessage() { }
		
		// TODO
		private void OnSelectMessage(int index) { }
		
		// TODO
		private void DecidePlayer(int index, int stationIndex) { }
		
		// TODO
		public void LoadModel(int index, int stationIndex) { }
		
		// TODO
		public void UnloadModel(int index) { }
		
		private void SetKeyGuide(bool complete = false)
		{
			this._battleMatchingUIPtr.SetKeyGuide(1,1,0,(complete ? 1 : 0) & 1);
		}
	}
}