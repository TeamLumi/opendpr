using DPData;
using Effect;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class BadgeObject
	{
		private int id;
		private GameObject gameObject;
		private Transform nodeTransform;
		private BadgeCondition currentBadgeCondition;
		private EffectInstance conditionEffect;
		private int polishedCount;
		private int needCleanupCount;
		private byte cleanupValue;
		
		public bool IsVisible { get; private set; }
		public bool IsAutoRotate { get; private set; }
		
		public BadgeObject(int id, GameObject gameObject, Transform transform)
		{
			this.id = id;
			this.gameObject = gameObject;
			this.nodeTransform = transform;

			IsVisible = BadgeWork.IsGet(id);
			if (IsVisible)
				UpdateCondition(true);

			gameObject.SetActive(IsVisible);
		}
		
		// TODO
		public void Dispose() { }
		
		public Transform GetTransform()
		{
			return this.nodeTransform;
		}
		
		public void SetActive(bool isActive)
		{
			this.gameObject.SetActive((isActive ? 1 : 0) & 1);
		}
		
		// TODO
		public void Polish() { }
		
		// TODO
		public void Hit() { }
		
		public Vector3 GetPosition()
		{
			this.nodeTransform.position;
			return null;
		}
		
		public void SetPosition(Vector3 pos)
		{
			this.nodeTransform.set_position();
		}
		
		public Quaternion GetRotation()
		{
			this.nodeTransform.rotation;
			return null;
		}
		
		public void SetRotation(Quaternion quaternion)
		{
			this.nodeTransform.set_rotation();
		}
		
		// TODO
		public void RotateY(float value) { }
		
		// TODO
		public void StartAutoRotate(float duration) { }
		
		// TODO
		public void StopAutoRotate() { }
		
		public void PlayConditionEffect()
		{
			if (this.conditionEffect != null) {
			}
			UpdateCondition(1);
		}
		
		// TODO
		public void StopConditionEffect() { }
		
		// TODO
		private void UpdateCondition(bool isForce = false)
		{
			// TODO
			void Loaded(EffectInstance effectInstance) { }
        }
		
		// TODO
		private void PlayEffect(int effectID, Transform parent, [Optional] Action<EffectInstance> onLoaded) { }
	}
}