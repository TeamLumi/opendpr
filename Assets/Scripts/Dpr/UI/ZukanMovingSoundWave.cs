using Audio;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	[RequireComponent(typeof(CanvasRenderer))]
	public class ZukanMovingSoundWave : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 5.0f;
		[SerializeField]
		private float _lineWidth = 2.0f;
		[SerializeField]
		private Material _material;
		[SerializeField]
		private Color _color = Color.white;

		private Mesh _mesh;

		private const float _minDecibel = -48.0f;
		private const float _maxDecibel = 0.0f;

		private Queue<Point> _pointQueue = new Queue<Point>();

		private const float _maxHeight = 100.0f;

		private List<Vector2> _points = new List<Vector2>();
		private VoiceRTPC.VoiceRTPCDataList _voiceRtpcData;
		private CanvasRenderer _canvasRenderer;
		
		private void Awake()
		{
			var uVar1 = UnityEngine_Component__GetComponent<object>
			                  (this);
			this._canvasRenderer = uVar1;
		}
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public void Setup(VoiceRTPC.VoiceRTPCDataList voiceRtpcData) { }
		
		private void CreateMesh()
		{
			var uVar1 = new Mesh();
			uVar1.MarkDynamic();
			this._mesh = uVar1;
		}
		
		// TODO
		private float GetRTPCValue(AudioInstance audioInstance, uint paramId) { return default; }
		
		// TODO
		public void OnUpdate(float deltaTime, AudioInstance audioInstance) { }
		
		// TODO
		private void UpdateMesh() { }
		
		private float ToLevelValue(float value, float min = _minDecibel, float max = _maxDecibel)
		{
			return (value - min) / (max - min);
		}
		
		// TODO
		private void OnWillRenderCanvases() { }

		private class Point
		{
			public Vector2 pos;
		}
	}
}