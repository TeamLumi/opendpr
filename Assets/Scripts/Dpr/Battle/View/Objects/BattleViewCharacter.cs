using Dpr.Battle.Logic;
using System;
using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public class BattleViewCharacter : BattleObject
	{
		protected const float DEFAULT_ADJUST_HEIGHT = 1.0f;

		protected BtlvPos m_vPos = BtlvPos.BTL_VPOS_ERROR;
		protected ModelType m_type;
		protected bool _isSickSpeedSuspend;
		protected float m_adjustHeight;
		protected float m_cameraAdjustHeight;
		protected bool m_disableSleepEye;
		protected bool _isEnableWaitB;
		protected int _waitBCheckCnt;
		
		public bool IsGJoker { get => false; }
		public bool IsVisible { get => gameObject.activeSelf; set => gameObject.SetActive(value); }
		
		// TODO
		public virtual void Initialize(BtlvPos vPos) { }
		
		protected override void InitializeMember()
		{
			this.m_adjustHeight = 0x3f8000003f800000;
		}
		
		// TODO
		public virtual void SetRenderActive(bool isActive) { }
		
		// TODO
		public void SetVisible(bool value) { }
		
		// TODO
		protected virtual void UpdateVisible() { }
		
		// TODO
		public virtual void SetVisibleShadow(bool value) { }
		
		// TODO
		public void ResetAnimState() { }
		
		// TODO
		public void SetEnableWaitB(bool value) { }
		
		// TODO
		private void UpdateWaitB() { }
		
		[Obsolete]
		public virtual void ChangeAnimState(string parameterName, bool isReset = false) { }
		
		// TODO
		public void ChangeAnimStateBool(string parameterName, bool value) { }
		
		// TODO
		public void ChangeAnimStateInt(string parameterName, int vlaue) { }
		
		// TODO
		public void SetAnimSpeed(float speed) { }
		
		public float GetAnimSpeed()
		{
			return this._animSpeed;
		}
		
		// TODO
		protected virtual void UpdateAnimSpeed() { }
		
		// TODO
		public void StartLookAt(Vector3 pos) { }
		
		// TODO
		public void EndLookAt() { }
		
		// TODO
		public virtual void StartDelete() { }
		
		public bool IsFinishDelete { get => gameObject == null; }
		
		// TODO
		public virtual void AttachObject(GameObject obj, string nodeName, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool isFollowAnimScl, bool isFollowLocalScl) { }
		
		// TODO
		public void DetachObject(GameObject obj) { }
		
		public override void OnUpdatePreJob(float deltaTime)
		{
			UpdateWaitB();
			deltaTime.UpdateSTR();
		}

		public enum HappyType : int
		{
			NONE = 0,
			TYPE_A = 1,
			TYPE_B = 2,
		}

		public enum ShaderType : int
		{
			Normal = 0,
			GShader = 1,
			Count = 2,
		}

		public enum FixParamType : int
		{
			TYPE_VECTOR = 0,
			TYPE_FLOAT = 1,
			TYPE_BOOL = 2,
		}
	}
}