using Dpr.Battle.View.Playables;
using UnityEngine;

namespace Dpr.SequenceEditor
{
	public class SequenceCameraSystem
	{
		protected const float DEFAULT_NEAR = 16.0f;
		protected const float DEFAULT_FAR = 200000.0f;
		protected const float DEFAULT_FOV = 30.0f;

		protected const float DEFAULT_AUDIO_VPF_RANGE_MIN = 20.0f;
		protected const float DEFAULT_AUDIO_VPF_RANGE_MAX = 48.0f;
		protected const float DEFAULT_AUDIO_VPF_VALUE_MIN = 10.0f;
		protected const float DEFAULT_AUDIO_VPF_VALUE_MAX = 1.0f;

		protected const int WAITCAM_TARGET_FIELD = 0;
		protected const int WAITCAM_TARGET_POKE = 1;
		protected const int WAITCAM_TARGET_TRAINER = 2;
		protected const int WAITCAM_TARGET_ENEMY_POKE = 3;
		protected const int WAITCAM_TARGET_ENEMY_TRAINER = 4;
		protected const int WAITCAM_TARGET_ALLY_POKE = 5;
		protected const int WAITCAM_TARGET_ALLY_TRAINER = 6;
		protected const int WAITCAM_TARGET_NONE = 7;
		protected const int WAITCAM_TARGET_G_POKE = 8;
		protected const int WAITCAM_TARGET_ENEMY_G_POKE = 9;
		protected const int WAITCAM_TARGET_ALLY_G_POKE = 10;

		protected const int WAITCAM_NODE_ORIGIN = 0;
		protected const int WAITCAM_NODE_CENTER = 1;
		protected const int WAITCAM_NODE_FACE = 2;
		protected const int WAITCAM_NODE_CHEST = 3;

		protected const int WAITCAM_RUEL_SINGLE = 0;
		protected const int WAITCAM_RUEL_DOUBLE = 1;
		protected const int WAITCAM_RUEL_RAID = 2;
		protected const int WAITCAM_RUEL_S_WILD = 3;
		protected const int WAITCAM_RUEL_D_WILD = 4;
		protected const int WAITCAM_RUEL_G1_ALLY = 5;
		protected const int WAITCAM_RUEL_G1_ENEMY = 6;
		protected const int WAITCAM_RUEL_G2 = 7;
		protected const int WAITCAM_RUEL_JOKER_1 = 8;
		protected const int WAITCAM_RUEL_JOKER_2 = 9;
		protected const int WAITCAM_RUEL_JOKER_3 = 10;

		protected const int WAITCAM_RENDER_VISIBLE_SHADOW = 0;
		protected const int WAITCAM_RENDER_VISIBLE_YEBIS = 1;
		protected const int WAITCAM_RENDER_VISIBLE_ZPREPATH = 2;
		protected const int WAITCAM_RENDER_VISIBLE_BG = 3;
		protected const int WAITCAM_RENDER_VISIBLE_FIELDEFF = 4;
		protected const int WAITCAM_RENDER_VISIBLE_GROUNDEFF = 5;

		protected const int WAITCAM_TARGET_HIDE_NONE = 0;
		protected const int WAITCAM_TARGET_HIDE_ONLY = 1;
		protected const int WAITCAM_TARGET_HIDE_SET = 2;
		protected const int WAITCAM_TARGET_HIDE_SIDE = 3;

		protected ISequenceViewSystem _viewSystem;
		protected CameraFilePlayable m_pCamearaAnimeComponent;
		protected bool _isCheckGround;
		protected bool _isPosOverCheck;
		protected SequenceCameraObject[] Cameras;
		
		protected CameraStateType CameraState { get; set; }

        protected bool IsPlayingCameraAnimation;

        public SequenceCameraSystem(ISequenceViewSystem viewSystem)
		{
			_viewSystem = viewSystem;
		}
		
		// TODO
		public virtual void OnUpdate(float deltaTime) { }
		
		// TODO
		public virtual void OnLateUpdate(float deltaTime) { }
		
		// TODO
		public virtual SequenceCameraObject GetBattleCamera(CameraStateType type) { return default; }
		
		// TODO
		public void PlayCameraAnimation(CameraFilePlayable pAnimFile) { }
		
		// TODO
		public void StopCameraAnimation(CameraStateType state, bool isKeep) { }
		
		// TODO
		public void DestroyCameraAnimation() { }
		
		public void SetCameraAnimationSpeed(float speed)
		{
			if (this.m_pCamearaAnimeComponent != null) {
			  this.m_pCamearaAnimeComponent.SetSpeed();
			}
		}
		
		// TODO
		public void SetCameraAnimationScale(Vector3 scale) { }
		
		// TODO
		public void SetCameraAnimationRotateY_Deg(float rot) { }
		
		public void SetCameraAnimationCheckGround(bool value)
		{
			this._isCheckGround = (value ? 1 : 0) & 1;
		}
		
		public bool GetCameraAnimationCheckGround()
		{
			return this._isCheckGround;
		}
		
		public void SetCameraPosOverCheck(bool value)
		{
			this._isPosOverCheck = (value ? 1 : 0) & 1;
		}
		
		public bool GetCameraPosOverCheck()
		{
			return this._isPosOverCheck;
		}

		public enum CameraStateType : int
		{
			Main = 0,
			Sub = 1,
		}

		public enum WaitCameraStateType : int
		{
			None = 0,
			Wait = 1,
			Load = 2,
			Update = 3,
			Stop = 4,
		}
	}
}