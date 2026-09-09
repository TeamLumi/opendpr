using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public class BUICommTime : BattleViewUICanvasBase
	{
		private const string GameLabelSpriteName = "btl_txt_endtime_01";
		private const string GameFixSpriteName = "btl_txt_3min_01";
		private const string GameNumberSpriteName = "btl_txt_num_01_{0}";
		private const string GameSecondSpriteName = "btl_txt_second_01";
		private const string Command60SpriteName = "btl_txt_60sec_01";
		private const string Command30SpriteName = "btl_txt_30sec_01";
		private const string CommandNumberSpriteName = "cmn_net_no_time_01_{0}";

		[SerializeField]
		private GameObject _gameTime;
		[SerializeField]
		private Image _gameTimeLabel;
		[SerializeField]
		private Image _gameFixTime;
		[SerializeField]
		private Image _gameSecondText;
		[SerializeField]
		private Image[] _gameSeconds;
		[SerializeField]
		private GameObject _commandTime;
		[SerializeField]
		private Image _commandFixTime;
		[SerializeField]
		private Image _commandVariableTime;
		[SerializeField]
		private Sprite[] _commandTimeSprite;
		[SerializeField]
		private float _showSeconds = 3.0f;
		[SerializeField]
		private uint _gameTimeSeccond;
		[SerializeField]
		private uint _commandTimeSeccond;
		private Sprite[] _gameSecondsSprite;
		private CanvasGroup _gameCanvasGroup;
		private Sprite[] _commandSecondsSprite;
		private CanvasGroup _commandCanvasGroup;
		private float _gameTimeShowWait;
		private bool _isGameTimeEnable;
		private float _commandTimeShowWait;
		private bool _isCommandTimeEnable;
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		public override void Startup() { }
		
		// TODO
		protected override void OnHide() { }
		
		public void SetGameTime(bool isEnable) {
		    this._isGameTimeEnable = isEnable;
		}
		
		// TODO
		public void ApplyGameTime(bool isEnable) { }
		
		public void SetCommandTime(bool isEnable) {
		    this._isCommandTimeEnable = isEnable;
		}
		
		// TODO
		public void ApplyCommandTime(bool isEnable) { }

		private enum SpriteKind : int
		{
			Rest60 = 0,
			Rest30 = 1,
		}
	}
}