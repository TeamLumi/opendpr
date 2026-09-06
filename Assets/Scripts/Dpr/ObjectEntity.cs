using Dpr.BallDeco;
using Dpr.Battle.View;
using Dpr.Battle.View.Objects;
using Effect;
using Pml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Playables;

namespace Dpr
{
	[RequireComponent(typeof(Animator))]
	public class ObjectEntity : BaseEntity, ITranslationObject
	{
		public const int BALL_LIGHT_EFFECT_INDEX = -1;

        // TODO
        public override string entityType { get; }

        private static Dictionary<string, EffectData> _sealEffectDataDic = new Dictionary<string, EffectData>();

		[SerializeField]
		private AnimationPlayer _animationPlayer = new AnimationPlayer();
		[SerializeField]
		private Transform[] _locators;
		[SerializeField]
		private BattleModelParticleEntity[] _modelParticleEntities;
		[SerializeField]
		private DirectorUpdateMode _updateMode = DirectorUpdateMode.GameTime;
		private Vector3 _translation = Vector3.zero;
		private Vector3 _translationOffset = Vector3.zero;
        private Vector3 _scale = Vector3.one;
        private Vector3 _scaleOffset = Vector3.one;
        private Vector3 _rotVec = Vector3.zero;
        private Vector3 _rotVecOffset = Vector3.zero;

        public bool IsSuspendUpdate { get; set; }

        private BtlvObjectFollowInfo _objectFollowInfo;
		private List<BtlvEffectInstance> _sealEffectInstances = new List<BtlvEffectInstance>();		
		
		// TODO
		public bool IsEffectLoaded { get; }
		
		// TODO
		protected override void Awake() { }
		
		// TODO
		protected override void OnDestroy() { }
		
		// TODO
		protected override void OnEnable() { }
		
		// TODO
		protected override void OnDisable() { }
		
		// TODO
		public virtual void Initialize() { }
		
		// TODO
		public void SetVisible(bool value) { }
		
		// TODO
		public void OnUpdatePreJob(float deltaTime) { }
		
		// TODO
		public void OnUpdatePostJob(float deltaTime) { }
		
		// TODO
		public void Play(int index, float duration = 0.0f, float startTime = 0.0f, bool isLoop = false) { }
		
		// TODO
		public void Stop() { }
		
		public override AnimationPlayer GetAnimationPlayer() {
		    return _animationPlayer;
		}
		
		// TODO
		public void SetAnimSpeed(float speed) { }
		
		// TODO
		public Transform GetLocator(int index) { return default; }
		
		// TODO
		public Transform GetLocatorByName(string name) { return default; }
		
		// TODO
		public void SetTranslationVec(Vector3 translation) { }
		
		// TODO
		public Vector3 GetTranslationVec() { return default; }
		
		// TODO
		public void SetTranslationOffset(Vector3 translation) { }
		
		// TODO
		public Vector3 GetTranslationOffset() { return default; }
		
		// TODO
		public void SetScaleVec(Vector3 scale) { }
		
		// TODO
		public Vector3 GetScaleVec() { return default; }
		
		// TODO
		public void SetScaleOffset(Vector3 scale) { }
		
		// TODO
		public Vector3 GetScaleOffset() { return default; }
		
		// TODO
		public void SetRotationVec(Vector3 rot) { }
		
		// TODO
		public Vector3 GetRotationVec() { return default; }
		
		// TODO
		public void SetRotationVecOffset(Vector3 rot) { }
		
		// TODO
		public Vector3 GetRotationVecOffset() { return default; }
		
		// TODO
		public bool IsActive() { return default; }

		// TODO
		public void PlayModelParticle(int index, [Optional] Action onComplete) { }
		
		// TODO
		public void StopModelParticle(int index, float fadeTime = 0.0f) { }
		
		// TODO
		public static void ReleaseSealEffectData() { }
		
		// TODO
		public static IEnumerator PreLoadSealEffects(BallId ballId, AffixSealData[] sealDatas) { return default; }
		
		// TODO
		public void PlaySealEffect(BallId ballId, AffixSealData[] affixSealDatas, byte sealCnt, float adjustHeight = 1.0f) { }
		
		// TODO
		public void GetPlaySealEffect(BallId ballId, in AffixSealData[] affixSealDatas, ref List<BtlvEffectInstance> sealEffects, ref BtlvEffectInstance lightEffect) { }
		
		public List<BtlvEffectInstance> GetSealEffectInstances() {
		    return _sealEffectInstances;
		}
		
		// TODO
		private void UpdateSRT() { }
		
		// TODO
		public Vector3 GetCalcTranslation() { return default; }
		
		// TODO
		public Vector3 GetCalcScale() { return default; }
		
		// TODO
		public Vector3 GetCalcRot() { return default; }
		
		// TODO
		public void AttachModel(ITranslationObject iPtrObject, Transform joint, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool followAnimScl, bool followLocalScl) { }
		
		// TODO
		public void DetachModel() { }
	}
}