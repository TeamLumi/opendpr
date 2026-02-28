using Audio;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class ZukanMovingEffecter : MonoBehaviour
	{
		[SerializeField]
		protected SensorParam _sensorParam;

		protected float _maxLength;
		protected Animator _animator;

		protected const int _maxLevel = 5;

		protected static readonly int animParamStateId = Animator.StringToHash("stateId");

		protected float[] _values = new float[2]; // TODO: Find a constant for this?
		
		public void Awake()
		{
			var uVar1 = UnityEngine_Component__GetComponent<object>
			                  (this);
			this._animator = uVar1;
		}
		
		// TODO
		public void Setup() { }
		
		// TODO
		protected void UpdateEffecter(uint gameParamId, float accelValue, [Optional] [DefaultParameterValue(false)] bool isInstance, [Optional] AudioInstance voiceInstance) { }

		[Serializable]
		protected class SensorParam
		{
			public float max = 3.0f;
			public float min;
		}
	}
}