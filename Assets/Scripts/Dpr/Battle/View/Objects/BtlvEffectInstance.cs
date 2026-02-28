using Dpr.BallDeco;
using Dpr.SequenceEditor;
using Effect;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public sealed class BtlvEffectInstance : BtlvPureObject
	{
		private Vector3 _beforeTranslation;
		private EffectInstance _effect;
		private SEQ_DEF_EFF_DRAWTYPE _drawType;
		private bool _autoRotate;
		private BattleScreenObject _screenObject;

		public EffectInstance Effect { get => _effect; private set => _effect = value; }
		public bool IsStop { get; private set; }
		public bool IsScreenEffect
		{
			get
			{
				return _drawType == SEQ_DEF_EFF_DRAWTYPE.SEQ_DEF_EFF_DRAWTYPE_SCREEN ||
					   _drawType == SEQ_DEF_EFF_DRAWTYPE.SEQ_DEF_EFF_DRAWTYPE_BEFORE;
			}
		}
		public bool AutoRotate { set => _autoRotate = value; }
		public AffixSealData SealData { get; private set; }
		
		public BtlvEffectInstance(EffectData effectData, SEQ_DEF_EFF_DRAWTYPE drawType = SEQ_DEF_EFF_DRAWTYPE.SEQ_DEF_EFF_DRAWTYPE_NORAML)
		{
			_effect = EffectManager.Instance.Create(effectData, Vector3.zero, Quaternion.identity, null);
			_name = _effect.particleSystem.name;
			_drawType = drawType;
			_isSuspendUpdate = false;
			IsStop = false;
		}
		
		public BtlvEffectInstance(EffectData effectData, AffixSealData sealData)
		{
            _effect = EffectManager.Instance.Create(effectData, Vector3.zero, Quaternion.identity, null);
            _name = _effect.particleSystem.name;
            _drawType = SEQ_DEF_EFF_DRAWTYPE.SEQ_DEF_EFF_DRAWTYPE_NORAML;
            _isSuspendUpdate = false;
            IsStop = false;
			SealData = sealData;
        }
		
		// TODO
		public override void Dispose() { }
		
		// TODO
		public void Play([Optional] Action<EffectInstance> onComplete) { }
		
		// TODO
		public void Fade() { }
		
		// TODO
		public void Kill(bool immediate = true) { }
		
		// TODO
		public override bool IsActive() { return default; }
		
		// TODO
		public override void OnUpdatePreJob(float deltaTime) { }
		
		// TODO
		public override void OnUpdatePostJob(float deltaTime) { }
		
		// TODO
		public void SetRenderCamera(BattleScreenObject screenObject) { }
		
		// TODO
		protected override void UpdateSRT() { }
		
		public void SetMultiplyColor(Vector4 color)
		{
			if (this._effect != null) {
			  Color.op_Implicit(0);
			  this._effect.SetMultiplyColor();
			}
		}
	}
}