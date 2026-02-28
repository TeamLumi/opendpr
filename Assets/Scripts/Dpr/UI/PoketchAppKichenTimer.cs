using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppKichenTimer : PoketchAppBase
	{
		[SerializeField]
		[Tooltip("背景アニメーションの切り替え間隔")]
		private float _bgAniamationTime = 0.3f;
		[SerializeField]
		[Tooltip("ボタン明滅の切り替え間隔")]
		private float _buttonBlinkTime = 0.5f;
		[SerializeField]
		private Image _secondsImage01;
		[SerializeField]
		private Image _secondsImage10;
		[SerializeField]
		private Image _minutesImage01;
		[SerializeField]
		private Image _minutesImage10;
		[SerializeField]
		private Sprite[] _numberSprites;
		[SerializeField]
		private Image _bgImage01;
		[SerializeField]
		private Image _bgImage02;
		[SerializeField]
		private Image _bgImage03;
		[SerializeField]
		private Sprite[] _bgSprites01;
		[SerializeField]
		private Sprite[] _bgSprites02;
		[SerializeField]
		private Sprite[] _bgSprites03;

		private TimerState _state;
		private float _timer;
		private int _displayMinutes;
		private int _displaySeconds;
		private TimerBgState _bgState;
		private float _bgAnimationTimeCount;
		private bool _isButtonVisible = true;

		private const float PRESSED_OFFSET_Y = -10.0f;

		private float _buttonBlinkTimeCount;
		private Vector3 _defaultStartButtonPosition;
		private Vector3 _defaultStopButtonPosition;
		private Vector3 _pressedStartButtonPosition;
		private Vector3 _pressedStopButtonPosition;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		public override void OnSizeChanged(bool isLarge) { }
		
		// TODO
		public override void OnAppChanged() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void StartTimer() { }
		
		// TODO
		private void StopTimer() { }
		
		// TODO
		private void ResetTimer(bool isPlaySE = true) { }
		
		private void OnCountFinished()
		{
			this._state = (TimerState)3;
			SetBgSprites();
			this._bgAnimationTimeCount = 0;
		}
		
		private void SetTimer(int minutes, int seconds)
		{
			if ((int)this._state != 0) {
			}
			if (0x3a < (int)seconds) {
			  seconds = 0x3b;
			}
			seconds = seconds & ((int)seconds >> 0x1f ^ 0xffffffffU);
			if (0x62 < (int)minutes) {
			  minutes = 99;
			}
			minutes = minutes & ((int)minutes >> 0x1f ^ 0xffffffffU);
			SetTimerDisplay(minutes,seconds);
			this._timer = (float)(int)(seconds + minutes * 0x3c);
		}
		
		private void AddTimerSeconds01(int addSeconds01)
		{
			addSeconds01 = this._displaySeconds % 10 + addSeconds01;
			var iVar2 = addSeconds01;
			if (addSeconds01 < 0) {
			  iVar2 = 9;
			}
			if (9 < addSeconds01) {
			  iVar2 = 0;
			}
			if ((int)this._state != 0) {
			}
			if (0x3a < (int)iVar2 + (this._displaySeconds / 10) * 10) {
			  iVar2 + (this._displaySeconds / 10) * 10 = 0x3b;
			}
			iVar2 + (this._displaySeconds / 10) * 10 = iVar2 + (this._displaySeconds / 10) * 10 & ((int)iVar2 + (this._displaySeconds / 10) * 10 >> 0x1f ^ 0xffffffffU);
			if (0x62 < (int)this._displayMinutes) {
			  this._displayMinutes = 99;
			}
			this._displayMinutes = this._displayMinutes & ((int)this._displayMinutes >> 0x1f ^ 0xffffffffU);
			SetTimerDisplay(this._displayMinutes,iVar2 + (this._displaySeconds / 10) * 10);
			this._timer = (float)(int)(iVar2 + (this._displaySeconds / 10) * 10 + this._displayMinutes * 0x3c);
		}
		
		private void AddTimerSeconds10(int addSeconds10)
		{
			addSeconds10 = (this._displaySeconds / 10) % 10 + addSeconds10;
			var iVar3 = addSeconds10 * 10;
			if (addSeconds10 < 0) {
			  iVar3 = 0x32;
			}
			if (5 < addSeconds10) {
			  iVar3 = 0;
			}
			if ((int)this._state != 0) {
			}
			if (0x3a < (int)iVar3 + this._displaySeconds % 10) {
			  iVar3 + this._displaySeconds % 10 = 0x3b;
			}
			iVar3 + this._displaySeconds % 10 = iVar3 + this._displaySeconds % 10 & ((int)iVar3 + this._displaySeconds % 10 >> 0x1f ^ 0xffffffffU);
			if (0x62 < (int)this._displayMinutes) {
			  this._displayMinutes = 99;
			}
			this._displayMinutes = this._displayMinutes & ((int)this._displayMinutes >> 0x1f ^ 0xffffffffU);
			SetTimerDisplay(this._displayMinutes,iVar3 + this._displaySeconds % 10);
			this._timer = (float)(int)(iVar3 + this._displaySeconds % 10 + this._displayMinutes * 0x3c);
		}
		
		private void AddTimerMinutes01(int addMinutes01)
		{
			addMinutes01 = this._displayMinutes % 10 + addMinutes01;
			var iVar2 = addMinutes01;
			if (addMinutes01 < 0) {
			  iVar2 = 9;
			}
			if (9 < addMinutes01) {
			  iVar2 = 0;
			}
			if ((int)this._state != 0) {
			}
			if (0x3a < (int)this._displaySeconds) {
			  this._displaySeconds = 0x3b;
			}
			this._displaySeconds = this._displaySeconds & ((int)this._displaySeconds >> 0x1f ^ 0xffffffffU);
			if (0x62 < (int)iVar2 + (this._displayMinutes / 10) * 10) {
			  iVar2 + (this._displayMinutes / 10) * 10 = 99;
			}
			iVar2 + (this._displayMinutes / 10) * 10 = iVar2 + (this._displayMinutes / 10) * 10 & ((int)iVar2 + (this._displayMinutes / 10) * 10 >> 0x1f ^ 0xffffffffU);
			SetTimerDisplay(iVar2 + (this._displayMinutes / 10) * 10,this._displaySeconds);
			this._timer = (float)(int)(this._displaySeconds + iVar2 + (this._displayMinutes / 10) * 10 * 0x3c);
		}
		
		private void AddTimerMinutes10(int addMinutes10)
		{
			addMinutes10 = (this._displayMinutes / 10) % 10 + addMinutes10;
			var iVar3 = addMinutes10 * 10;
			if (addMinutes10 < 0) {
			  iVar3 = 0x5a;
			}
			if (9 < addMinutes10) {
			  iVar3 = 0;
			}
			if ((int)this._state != 0) {
			}
			if (0x3a < (int)this._displaySeconds) {
			  this._displaySeconds = 0x3b;
			}
			this._displaySeconds = this._displaySeconds & ((int)this._displaySeconds >> 0x1f ^ 0xffffffffU);
			if (0x62 < (int)iVar3 + this._displayMinutes % 10) {
			  iVar3 + this._displayMinutes % 10 = 99;
			}
			iVar3 + this._displayMinutes % 10 = iVar3 + this._displayMinutes % 10 & ((int)iVar3 + this._displayMinutes % 10 >> 0x1f ^ 0xffffffffU);
			SetTimerDisplay(iVar3 + this._displayMinutes % 10,this._displaySeconds);
			this._timer = (float)(int)(this._displaySeconds + iVar3 + this._displayMinutes % 10 * 0x3c);
		}
		
		// TODO
		private void SetTimerDisplay(float seconds) { }
		
		// TODO
		private void SetTimerDisplay(int minutes, int seconds) { }
		
		// TODO
		private void SetBgSprites(TimerBgState state) { }
		
		// TODO
		private void SetButtonsVisible(bool visible) { }

		private enum TimerState : int
		{
			Idle = 0,
			Stop = 1,
			CountDown = 2,
			Finished = 3,
			End = 4,
		}

		private enum TimerButtonType : int
		{
			Start = 0,
			Stop = 1,
			Reset = 2,
			Seconds01_Up = 3,
			Seconds01_Down = 4,
			Seconds10_Up = 5,
			Seconds10_Down = 6,
			Minutes01_Up = 7,
			Minutes01_Down = 8,
			Minutes10_Up = 9,
			Minutes10_Down = 10,
			End = 11,
		}

		private enum TimerBgState : int
		{
			Idle = 0,
			Finished01 = 1,
			Finished02 = 2,
			CountDown = 3,
		}
	}
}