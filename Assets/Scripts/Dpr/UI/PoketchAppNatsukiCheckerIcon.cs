using Pml;
using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppNatsukiCheckerIcon : MonoBehaviour
	{
		[SerializeField]
		private PokemonIcon _pokemonIcon;
		[SerializeField]
		private RectTransform _iconTransform;
		[SerializeField]
		private Image _shadowImage;
		[SerializeField]
		private Image[] _heartImages;
		[SerializeField]
		[Tooltip("当たり判定サイズ")]
		private Vector2 _colisionSize;
		[SerializeField]
		[Tooltip("なついている判定のランク")]
		private int _likeFriendShipRank = 3;
		[SerializeField]
		[Tooltip("なつき度毎の近づく/逃げる速度(1s)")]
		private float[] _touchMoveSpeed;
		[SerializeField]
		[Tooltip("最小移動速度(1s)")]
		private float _minMoveSpeed;
		[SerializeField]
		[Tooltip("最大移動速度(1s)")]
		private float _maxMoveSpeed;
		[SerializeField]
		[Tooltip("最小移動距離")]
		private float _minMoveDistance;
		[SerializeField]
		[Tooltip("最大移動距離")]
		private float _maxMoveDistance;
		[SerializeField]
		[Tooltip("移動後の最小待機時間")]
		private float _minIdleTime;
		[SerializeField]
		[Tooltip("移動後の最大待機時間")]
		private float _maxIdleTime;
		[SerializeField]
		[Tooltip("Approach/Escape になるタッチ座標距離")]
		private float _friendShipDistance;
		[SerializeField]
		[Tooltip("Jump の高さ")]
		private float _jumpHeight;
		[SerializeField]
		[Tooltip("Jump の滞空時間")]
		private float _jumpAirTime;
		[SerializeField]
		[Tooltip("Jump の着地後のインターバル")]
		private float _jumpIntervalTime;
		[SerializeField]
		[Tooltip("Heart のなつき度毎の出現個数(2個まで)")]
		private int[] _heartDisplayNum;
		[SerializeField]
		[Tooltip("Heart のなつき度毎の表示時間")]
		private float[] _heartDisplayTime;
		[SerializeField]
		[Tooltip("Heart のなつき度毎の大きさ(Scale)")]
		private float[] _heartScale;

		private Animator _heartAnimator;
		private NatsukiCheckerIconState _state;
		private MonsNo _monsNo;
		private ushort _formNo;
		private bool _bIsSetGetDefaultPosition;
		private Vector2 _minDisplayMargin;
		private Vector2 _maxDisplayMargin;
		private Vector2 _defaultPosition;
		private Vector2 _position;
		private bool _isFriendShip;
		private int _friendShipRank;
		private float _timeCounter;
		private Vector2 _touchPos;
		private bool _isTouch;
		private bool _isTouchOld;
		private float _idleTime;
		private float _moveSpeed;
		private float _moveDistance;
		private Vector2 _moveVec;
		private Vector2 _beforePostion;
		private bool _isDisableReverce;
		private Vector2 _defaultIconPosition;

		private const string animationStateNameHeartMove = "Poketch_NatsukiChecker_Heart01";
		private const string animationStateNameHeartNone = "Poketch_NatsukiChecker_Heart02";
		
		// TODO
		public void Initialize(Material mat, Vector2 windowSize, float windowMargin) { }
		
		// TODO
		public void SetData(PokemonParam pp, bool isDisableReverce) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateIdleState(float deltaTime) { }
		
		// TODO
		private void UpdateMoveState(float deltaTime) { }
		
		// TODO
		private void UpdateApproachState(float deltaTime) { }
		
		// TODO
		private void UpdateEscapeState(float deltaTime) { }
		
		// TODO
		private void UpdateJumpState(float deltaTime) { }
		
		// TODO
		private void UpdateHeartState(float deltaTime) { }
		
		// TODO
		private void SetState(NatsukiCheckerIconState state) { }
		
		// TODO
		private void SetImageDirection(bool left) { }
		
		// TODO
		private void UpdateMove(Vector2 moveVec) { }
		
		// TODO
		private void UpdateMoveInterp(float deltaTime) { }
		
		// TODO
		private bool IsInFriendShipDistance() { return default; }
		
		// TODO
		public void OnTouchDispaly(Vector2 touchPos) { }
		
		public void OnReleaseDispaly()
		{
			this._isTouch = false;
		}
		
		public void OnDoubleTap()
		{
			if ((int)this._state != 4) {
			  ExtensionMethods.SetActive(this._shadowImage,1);
			  this._timeCounter = 0;
			  this._state = (NatsukiCheckerIconState)4;
			}
		}
		
		// TODO
		public bool IsColision(Vector2 pos) { return default; }
		
		// TODO
		public Vector2 ColisionPosMin(bool enableScale) { return default; }
		
		// TODO
		public Vector2 ColisionPosMax(bool enableScale) { return default; }

		private enum NatsukiCheckerIconState : int
		{
			Idle = 0,
			Move = 1,
			Approach = 2,
			Escape = 3,
			Jump = 4,
			Heart = 5,
			End = 6,
		}
	}
}