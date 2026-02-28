using DG.Tweening;
using Effect;
using System;
using UnityEngine;

namespace Dpr.Contest
{
	public class DanceHeartEffect : MonoBehaviour
	{
		private EffectManager fxManagerPtr;
		private EffectData heartFxData;
		private EffectInstance fxInst;
		private Ease easeTypeID = Ease.InCubic;
		private Transform effectTransform;
		private Transform fxInstTransform;
		private Transform fxManagerTransform;
		private Vector3 startPoint;
		private Vector3 pointA;
		private Vector3 pointB;
		private Vector3 goalPoint;
		private float timer;
		private float duration;
		private Action onComplete;
		private bool active;
		private bool isPlayerHeart;
		
		public bool IsActive { get => active; }
		
		// TODO
		public void Initialize() { }
		
		public void SetNormalHeartFxData(EffectData fxData)
		{
			this.heartFxData = fxData;
		}
		
		public void SetLargeHeartFxData(EffectData fxData)
		{
			this.heartFxData = fxData;
		}
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void Create() { }
		
		// TODO
		private bool CheckHeartFxInst() { return default; }
		
		public void OnUpdate(float deltaTime)
		{
			if (this.isPlayerHeart) {
			  OnPlayerHeartUpdate();
			}
			OnNPCHeartUpdate();
		}
		
		// TODO
		public void PerformEmitPlayerHeart(float duration, Ease easeType, Action onComplete, Vector3[] points) { }
		
		// TODO
		private void OnPlayerHeartUpdate(float deltaTime) { }
		
		// TODO
		private void UpdatePosition() { }
		
		// TODO
		public void PerformEmitNPCHeart(float duration, Ease easeType, Action onComplete, Vector3 from, Vector3 to) { }
		
		// TODO
		private void OnNPCHeartUpdate(float deltaTime) { }
		
		// TODO
		private void FinishFx() { }
		
		// TODO
		public void Stop() { }
		
		// TODO
		private void SetGoActive(bool active) { }
	}
}