using AK;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchButton : MonoBehaviour
	{
		[SerializeField]
		private Image _image;
		[SerializeField]
		private Sprite _pressedSprite;
		[SerializeField]
		private Vector2 _pressedOffset = Vector2.zero;
		[SerializeField]
		private Vector2 _pressedTransform = Vector2.zero;
		[SerializeField]
		private float _pressedScale = 1.0f;
		[SerializeField]
		private bool _canDrag;
		[SerializeField]
		private bool _disablePressedOffset;
		[SerializeField]
		private bool _enableRepeat;
		[SerializeField]
		private float _firstRepeatTime = 0.5f;
		[SerializeField]
		private float _repeatTime = 0.2f;

		private Vector3 _basePosition;
		private Vector3 _pressedPosition;
		private Vector2 _baseDeltaSize;
		private Vector2 _pressedDeltaSize;
		private Vector2 _baseScaleVector;
		private Vector2 _pressedScaleVector;
		private bool _onRepeat;
		private float _repeatTimeCount;
		private int _repeatCount;
		private uint _seEventId;

        public bool IsInitialized { get; private set; }

        private UnityAction _onButtonAction;

        public bool CanDrag { get => _canDrag; }
        public UnityAction OnTouchAction { private get; set; }
        public UnityAction OnReleaseAction { private get; set; }

        // TODO
        public void Initialize([Optional] UnityAction callback, uint seEventId = EVENTS.S_FI304) { }
		
		// TODO
		public void Uninitialize() { }
		
		// TODO
		private void OnUpdateRepeat(float deltaTime) { }
		
		public void SetSeEventId(uint seEventId = uint.MaxValue)
		{
			this._seEventId = seEventId;
		}
		
		// TODO
		public void OnPush() { }
		
		// TODO
		public void SetTouch() { }
		
		// TODO
		public void SetRelease() { }
		
		// TODO
		public void SetImage(bool isTouch = false) { }
	}
}