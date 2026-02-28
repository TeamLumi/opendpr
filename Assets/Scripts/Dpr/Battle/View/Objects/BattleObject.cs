using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public abstract class BattleObject : BtlvBehaviour, ITranslationObject
	{
		protected Vector3 m_translation = Vector3.zero;
		protected Vector3 m_translationOffset = Vector3.zero;
        protected Vector3 m_translationGOffset = Vector3.zero;
        protected Vector3 m_scale = Vector3.one;
        protected Vector3 m_scaleOffset = Vector3.one;
        protected Vector3 m_beforeTranslation = Vector3.zero;
        protected Vector3 m_nodeScaleTranslation = Vector3.zero;
        protected Vector3 m_nodeRotateTranslation = Vector3.zero;
        protected Vector3 m_rotVec = Vector3.zero;
        protected Vector3 m_rotVecOffset = Vector3.zero;
        protected bool m_isVisible;
		protected bool m_isSubVisible;
		protected bool m_suspendUpdate;
		protected bool m_autoRotate;
		protected bool m_isVisibleCameraHit;
		protected bool m_isSubVisibleCameraHit;
		protected float _animSpeed = 1.0f;

		public int Index { get; set; } = -1;
		public bool IsEnable { get; private set; } = true;
		public int Priority { get; private set; }
		public Vector3 NodeScaleTranslation { get; set; }
		public Vector3 NodeRotateTranslation { get; set; }
		
		// TODO
		protected void Awake() { }
		
		// TODO
		protected virtual void OnDestroy() { }
		
		// TODO
		protected void Initialize() { }
		
		// TODO
		protected virtual void InitializeMember() { }
		
		// TODO
		public void SetTranslationVec(Vector3 translation) { }
		
		public Vector3 GetTranslationVec()
		{
			return this.m_translation;
		}
		
		public void SetTranslationOffset(Vector3 translation)
		{
			m_translationOffset = translation;
		}
		
		public Vector3 GetTranslationOffset()
		{
			return this.m_translationOffset;
		}
		
		public void SetScaleVec(Vector3 scale)
		{
			m_scale = scale;
		}
		
		public Vector3 GetScaleVec()
		{
			return this.m_scale;
		}
		
		// TODO
		public void SetScaleOffset(Vector3 scale) { }
		
		public Vector3 GetScaleOffset()
		{
			return m_scaleOffset;
		}
		
		// TODO
		public void SetNodeScaleTranslation(Vector3 translation) { }
		
		public Vector3 GetNodeScaleTranslation()
		{
			return this.m_nodeScaleTranslation;
		}
		
		// TODO
		public void SetNodeRotateTranslation(Vector3 translation) { }
		
		public Vector3 GetNodeRotateTranslation()
		{
			return this.m_nodeRotateTranslation;
		}
		
		// TODO
		public void SetRotationVec(Vector3 rot) { }
		
		public Vector3 GetRotationVec()
		{
			return this.m_rotVec;
		}
		
		// TODO
		public void SetRotationVecOffset(Vector3 rot) { }
		
		public Vector3 GetRotationVecOffset()
		{
			return this.m_rotVecOffset;
		}
		
		// TODO
		public bool IsActive() { return default; }
		
		// TODO
		public virtual void OnUpdatePreJob(float deltaTime) { }
		
		// TODO
		public virtual void OnUpdatePostJob(float deltaTime) { }
		
		// TODO
		protected void UpdateSTR() { }
		
		// TODO
		public Vector3 GetCalcTranslation() { return default; }
		
		// TODO
		public Vector3 GetCalcScale() { return default; }
		
		// TODO
		public Vector3 GetCalcRot() { return default; }

		public enum ModelType : int
		{
			None = 0,
			Trainer = 1,
			Pokemon = 2,
		}
	}
}