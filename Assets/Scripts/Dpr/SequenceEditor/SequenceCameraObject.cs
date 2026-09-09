using Dpr.Battle.View;
using Dpr.Battle.View.Playables;
using Dpr.Rendering;
using SmartPoint.Rendering;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.SequenceEditor
{
	[RequireComponent(typeof(Camera))]
	public class SequenceCameraObject : MonoBehaviour
	{
		protected Transform _cachedTransform;

		public const float DEFAULT_FREEZE_CAMERA_HEIGHT = -9999.0f;

		protected Camera _camera;
		[Header("[Cameras]")]
		[SerializeField]
		protected Camera _charaEffectCamera;
		[SerializeField]
		protected Camera _depthCamera;
		[SerializeField]
		protected Camera _compositor;
		[Header("[Post Effects]")]
		[SerializeField]
		protected BattlePostProcessFilter _battlePostProcess;
		[SerializeField]
		protected BattleMultipleCameraCompositor _battleMultipleCameraCompositor;
		[SerializeField]
		protected ColorFilter _colorFilter;
		protected PostEffects _postEffects;
		protected Vector3 m_position;
		protected Vector3 m_positionOffset;
		protected Vector3 m_target;
		protected Vector3 m_targetOffset;
		protected Vector3 m_rotation;
		protected float m_near;
		protected float m_far;
		protected float m_fov;
		protected float _twist;
		protected float m_PseudoTargetDistance = 10.0f;
		protected bool m_isCheckGround;
		protected bool m_isCheckFreezeOnGround;
		protected bool m_isFreezeRotation;
		protected bool m_isForceUpdateRotation;
		protected bool m_isTransformFreeze;
		protected float m_freezeHeight = DEFAULT_FREEZE_CAMERA_HEIGHT;
		protected bool m_isUpdateParam;
		protected bool m_isCalcTarget;
		protected Transform m_targetTransform;

        public Transform transform { get => this.GetComponentThis(ref _cachedTransform); }
        protected float targetDistance { get => Vector3.Distance(m_position, m_target); }
        public Camera Camera { get => this.GetComponentThis(ref _camera); }
        public Vector3 RawPosition { get => transform.position; }
        public Vector3 RawRotation { get => transform.rotation.eulerAngles; }
        public float Near
		{
			get => Camera.nearClipPlane;
			set
			{
				m_near = value;
				m_isUpdateParam = true;
			}
		}
        public float Far
		{
			get => Camera.farClipPlane;
			set
			{
				m_far = value;
				m_isUpdateParam = true;
			}
		}
        public float Fov
		{
			get => Camera.fieldOfView;
			set
			{
				m_fov = value;
				m_isUpdateParam = true;
			}
		}
        public float Twist
		{
			get => _twist;
			set
			{
				_twist = value;
				m_rotation.z = value;
				m_isUpdateParam = true;
			}
		}
        public bool IsEnabled
		{
			get => Camera.enabled;
			set
			{
				_compositor.enabled = value;
				_depthCamera.enabled = value;
				_charaEffectCamera.enabled = value;
				Camera.enabled = value;
			}
		}
        public BattlePostProcessFilter PostProcess
		{
			get
			{
				if (_battlePostProcess == null)
					_battlePostProcess = GetComponentInChildren<BattlePostProcessFilter>();

				return _battlePostProcess;
			}
		}
        public Camera Compositor { get => _compositor; }
        public SequenceCameraSystem.CameraStateType CameraState { get; protected set; }
        public CameraMode CurrentCameraMode { get; protected set; }
        public bool IsAudioListener { get; set; }

        // TODO
        public void Initialize(SequenceCameraSystem.CameraStateType type) { }
		
		// TODO
		public void UnInitialize() { }
		
		// TODO
		public void OnLateUpdate(float deltaTime) { }
		
		// TODO
		public void SetPosition(Vector3 pos) { }
		
		// TODO
		public void SetPosition(Vector3 pos, Vector3 target) { }
		
		// TODO
		public void SetPosition(Vector3 pos, Quaternion target) { }
		
		// TODO
		public Vector3 GetPosition() { return default; }
		
		// TODO
		public void SetPositionOffset(Vector3 pos) { }
		
		// TODO
		public Vector3 GetPositionOffset() { return default; }
		
		// TODO
		public void SetRotation(Vector3 rotation) { }
		
		// TODO
		public Vector3 GetRotation() { return default; }
		
		// TODO
		public void SetTarget(Vector3 value) { }
		
		// TODO
		public void SetTarget(float dist) { }
		
		// TODO
		public Vector3 GetTarget() { return default; }
		
		// TODO
		public Transform GetTargetTransform() { return default; }
		
		// TODO
		public void SetTargetOffset(Vector3 value) { }
		
		// TODO
		public Vector3 GetTargetOffset() { return default; }
		
		// TODO
		protected Vector3 CalcTarget() { return default; }
		
		// TODO
		protected Vector3 CalcTarget(float dist) { return default; }
		
		// TODO
		public void SetRotationFreeze(bool isFreeze, [Optional] Vector3? rot) { }
		
		// TODO
		public Vector3 CalcPseudoTarget(in Vector3 pos, in Vector3 rot) { return default; }
		
		public PostEffects GetPostEffects() {
		    return _postEffects;
		}
		
		public void SetCameraAnimationCheckGround(bool value) {
		    this.m_isCheckGround = value;
		}
		
		public bool GetCameraAnimationCheckGround() {
		    return m_isCheckGround;
		}
		
		// TODO
		public void SetCameraAnimationmFreezeOnGround(bool value) { }
		
		public bool GetCameraAnimationmFreezeOnGround() {
		    return m_isCheckFreezeOnGround;
		}
		
		public void SetFreezeHeight(float height = DEFAULT_FREEZE_CAMERA_HEIGHT) {
		    this.m_freezeHeight = height;
		}
		
		public float GetFreezeHeight() {
		    return m_freezeHeight;
		}
		
		// TODO
		public void SyncOtherCamera(CameraCommander commander, bool isForceUpdate = false) { }
		
		// TODO
		public void GetFollowCameraPos(float camLen, ref Vector3 ret) { }
		
		// TODO
		public void GetFollowCameraRot(ref Vector3 ret) { }
		
		// TODO
		protected void GetCheckGroundCameraPosTrg(in float height, ref Vector3 retPos, ref Vector3 retTrg) { }

		public enum CameraMode : int
		{
			Default = 0,
			Role = 1,
		}

		public enum CameraType : byte
		{
			Main = 0,
			FieldOnlyCamera = 1,
			EffectOnlyCamera = 2,
		}

		public sealed class PostEffect<TImageEffectObject> where TImageEffectObject : ImageEffectObject
		{
			private TImageEffectObject _effectObject;
			private bool _isEnable;
			
			public TImageEffectObject EffectObject { get => _effectObject; }
			public bool IsEnable
			{
				get => _isEnable;
				set
				{
					_isEnable = value;
					SetEnable(value);
				}
			}
			
			public PostEffect(BattlePostProcessFilter filter)
			{
				_effectObject = filter.GetEffect<TImageEffectObject>();
			}
			
			public PostEffect(TImageEffectObject effectObject)
			{
				_effectObject = effectObject;
			}
			
			private void SetEnable(bool isEnabled)
			{
				if (_effectObject != null)
					_effectObject.enabled = isEnabled;
			}
		}

		public sealed class PostEffects
		{
			private PfxParam _pfxParam;
			private SequenceCameraObject _sequenceCameraObject;
			private CommandBuffer _colorFilterBuffer;

			public BattlePostProcessFilter PostProcessFilter { get; private set; }
			public PostEffect<Bloom> Bloom { get; private set; }
			public PostEffect<DepthOfField> DepthOfField { get; private set; }
			public PostEffect<Fxaa> Fxaa { get; private set; }
			public PostEffect<RadialBlur> RadialBlur { get; private set; }
			public PostEffect<ColorFilter> ColorFilter { get; private set; }
			public PostEffect<ChromaticAberration> ChromaticAberration { get; private set; }
			public PostEffect<FeedbackBlur> FeedBackBlur { get; private set; }
			public PostEffect<BtlvPfx> BtlvPfx { get; private set; }
			
			public PostEffects(BattlePostProcessFilter filter, [Optional] PfxParam? initialParam)
			{
				if (initialParam.HasValue)
					_pfxParam = initialParam.Value;
				else
					_pfxParam = PfxParam.Factory();

				PostProcessFilter = filter;
				PostProcessFilter.Reset();

				Bloom = new PostEffect<Bloom>(filter);
				DepthOfField = new PostEffect<DepthOfField>(filter);
				Fxaa = new PostEffect<Fxaa>(filter);
				RadialBlur = new PostEffect<RadialBlur>(filter);
				ChromaticAberration = new PostEffect<ChromaticAberration>(filter);
				FeedBackBlur = new PostEffect<FeedbackBlur>(filter);
				BtlvPfx = new PostEffect<BtlvPfx>(filter);
			}
			
			// TODO
			public void InitializeExternalEffects(SequenceCameraObject bufferCamera, ColorFilter colorFilter) { }
			
			public PfxParam GetPfxParam()
			{
				return _pfxParam;
			}
			
			public void SetPfxParam(PfxParam param, bool isUpdatePfx = true)
			{
				_pfxParam = param;

				if (isUpdatePfx)
				{
                    PostProcessFilter.UpdatePfxParam(param);
                    UpdateBtlvPfx();
                }
			}
			
			// TODO
			public void UpdatePfx() { }
			
			// TODO
			public void UpdateDof() { }
			
			// TODO
			public void UpdateBtlvPfx() { }
			
			// TODO
			public void OnRenderImage(RenderTexture src, RenderTexture dest) { }
			
			// TODO
			public void Dispose() { }
		}
	}
}