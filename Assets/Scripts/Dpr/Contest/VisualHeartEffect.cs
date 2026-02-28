using Effect;
using UnityEngine;

namespace Dpr.Contest
{
	public class VisualHeartEffect : MonoBehaviour
	{
		private static readonly Vector3 INIT_POS = new Vector3(0.0f, -1000.0f, 0.0f);

		private EffectManager fxManagerPtr;
		private EffectData heartFxData;
		private EffectInstance fxInst;
		private Transform effectTransform;
		private Transform fxInstTransform;
		private Transform fxManagerTransform;
		private Vector2 moveSpeed;
		private Vector2 addSpeed;
		private float limitPosY;
		private bool active;
		
		public bool IsActive { get => active; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void ResetParam() { }
		
		public void SetNormalHeartFxData(EffectData fxData)
		{
			this.heartFxData = fxData;
			Create();
		}
		
		public void SetLargeHeartFxData(EffectData fxData)
		{
			this.heartFxData = fxData;
			Create();
		}
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void Create() { }
		
		// TODO
		public void PerformVisualHeart(Vector2 emitPos, Vector2 speedXRange, Vector2 speedYRange) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void Stop() { }
		
		// TODO
		private void SetGoActive(bool active) { }
	}
}