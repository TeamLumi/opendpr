using Dpr.NetworkUtils;
using System;

namespace Dpr.UI
{
	public class BattleMatchingSelectPokemon
	{
		private UIBattleMatching _battleMatchingUIPtr;
		private UIBattleMatchingPokemonSelect _pokemonSelectUIPtr;
		private Action _onFinishState;
		private Action _onSelect;
		private Action<ushort> _onCountDown;
		private bool _ready;
		private bool _stopped;
		private float _readyWaitTime = 3.0f;
		private float _readyProgressTime;
		private bool _isHost;
		private bool _isCountDown;
		private const int START_UI_COUNTDOWN_COUNT = 10;
		private CountDownTimer _countTimer = new CountDownTimer();
		private State _currentState;
		
		public void Initialize(Action onFinishState, Action onSelect, Action<ushort> onCountDown)
		{
			this._onFinishState = onFinishState;
			this._onSelect = onSelect;
			this._onCountDown = onCountDown;
		}
		
		// TODO
		public void Setup(UIBattleMatching battleMatchingUI) { }
		
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
		private void SetPreparationIconWait() { }
		
		// TODO
		public void SetPreparationIconReady(int stationIndex) { }
		
		// TODO
		public void SetPreparationIconWait(int stationIndex) { }
		
		public void StartCountDown(float startTime)
		{
			this._isCountDown = true;
			this._countTimer.StartCountDown();
			UpdateUITimeText();
		}
		
		// TODO
		private void UpdateCountDown(float deltaTime) { }
		
		private void Timeup()
		{
			if ((int)this._currentState == 1) {
			  this._pokemonSelectUIPtr.TimeUp();
			}
		}
		
		private bool UpdateCountDownFlow(float deltaTime)
		{
			this._countTimer.OnUpdate();
			if ((this._countTimer.IsChangeCountDown() & 1) != 0) {
			  UpdateUITimeText();
			  CheckShowUICountDown();
			  return true;
			}
			return false;
		}
		
		// TODO
		private void SetCountDownTime() { }
		
		// TODO
		public void SetCountDownTime(int timeCount) { }
		
		// TODO
		private void CheckShowUICountDown() { }
		
		// TODO
		private void UpdateUITimeText() { }

		private enum State : int
		{
			None = 0,
			Select = 1,
			Wait = 2,
		}
	}
}