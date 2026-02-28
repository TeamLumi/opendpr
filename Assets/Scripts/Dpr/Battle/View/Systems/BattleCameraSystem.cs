using Audio;
using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using SmartPoint.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.Battle.View.Systems
{
	public sealed class BattleCameraSystem : SequenceCameraSystem
	{
        public WaitCameraStateType WaitCameraState { get; private set; }

        private const int LOTTERY_MAX = 10;
		private const int PLAY_WAIT_CAMERA_DELAY_FRAME = 30;

		private int _lotteryCnt;
		private Coroutine _waitCameraLoadCoroutine;
		private bool _isSplitScreen;
		private bool _isSplitScreenDelResource;
		private bool _isEnableWaitamera;
		private bool _isFirstWaitCamera;
		private bool _isStatedWaitCamera;
		private int _waitCameraCnt;
		private int _playWaitCameraIndex = -1;
		private BattleWaitCameraData.SheetWaitCameraData[] _useWaitCameraDatas;
		private HashSet<BattleWaitCameraData.SheetWaitCameraData> _lotteryPlayWaitCameraDatas;
		private Vector3 _position;
		private Vector3 _target;
		private Vector3 _animPosition;
		private Vector3 _animTarget;
		private float _animNear;
		private float _animFar;
		private float _animFov;
		private float _animTwist;
		private BtlvPos _waitCameraTargetPoke = BtlvPos.BTL_VPOS_ERROR;
		private BtlvPos _waitCameraTargetTrainer = BtlvPos.BTL_VPOS_ERROR;
        private Coroutine _waitCameraDispose;
		
		public bool IsPlayWaitCamera { get => WaitCameraState != WaitCameraStateType.None; }
		public bool IsPlayedWaitCameraOnce { get => !_isFirstWaitCamera; }
		
		public BattleCameraSystem(BattleViewSystem pViewSystem, Camera camera) : base(pViewSystem)
		{
			var cameraPlacementData = BattleDataTableManager.Instance.BattleDefaultPlacementData.GetDefaultCameraPlacementData(BtlRule.BTL_RULE_SINGLE, Pml.PokePara.Size.S, Pml.PokePara.Size.S);
			var cluster = BattleProc.Instance.Cluster;

			var camStateTypes = Enum.GetValues(typeof(CameraStateType));
            Cameras = new BOCamera[camStateTypes.Length];

			foreach (CameraStateType camStateType in camStateTypes)
			{
				if (camStateType != CameraStateType.Sub)
				{
					var boCam = camera.AddComponentIfNecessary<BOCamera>();
                    boCam.Initialize(camStateType);
                    boCam.IsAudioListener = true;
					DepthOfField.instance.target = boCam.GetTargetTransform();
					DepthOfField.instance.sensorScale = pViewSystem.GetTimeZoneSensorScale();
					boCam.transform.parent = cluster;

					if (cameraPlacementData == null)
					{
						boCam.transform.SetOrigin(null);
						boCam.Camera.nearClipPlane = DEFAULT_NEAR;
						boCam.Camera.farClipPlane = DEFAULT_FAR;
						boCam.Camera.fieldOfView = DEFAULT_FOV;
					}
					else
					{
						boCam.transform.position = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamPos : cameraPlacementData.SubCamPos;
						boCam.transform.rotation = Quaternion.Euler(camStateType == CameraStateType.Main ? cameraPlacementData.MainCamRot : cameraPlacementData.SubCamRot);
						var cam = boCam.Camera;
						cam.nearClipPlane = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamNear : cameraPlacementData.SubCamNear;
						cam.farClipPlane = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamFar : cameraPlacementData.SubCamFar;
						cam.fieldOfView = camStateType == CameraStateType.Main ? cameraPlacementData.MainCamFov : cameraPlacementData.SubCamFov;
                    }

					AudioManager.Instance.SetListenerPosition(boCam.transform.position);
					AudioManager.Instance.SetListenerRotation(boCam.transform.rotation);
					Cameras[(int)camStateType] = boCam;
                }
			}

			InitializeWaitCamera();
			CameraState = CameraStateType.Main;
			WaitCameraState = WaitCameraStateType.None;
		}
		
		public override void OnLateUpdate(float deltaTime)
		{
			if (this.Cameras != 0) {
			  SequenceCameraSystem.OnLateUpdate();
			}
		}
		
		// TODO
		private void InitializeWaitCamera() { }
		
		// TODO
		private void ClearWaitCameraWork() { }
		
		// TODO
		private void LateUpdateWaitCamera() { }
		
		// TODO
		public void StartWaitCamera() { }
		
		// TODO
		private void StartLoopWaitCamera() { }
		
		// TODO
		private IEnumerator RunWaitCameraForSequence(bool isLoop) { return default; }
		
		// TODO
		private BattleWaitCameraData.SheetWaitCameraData LotteryWaitCamera() { return default; }
		
		// TODO
		private bool CanPlayWaitCameraData(BattleWaitCameraData.SheetWaitCameraData data) { return default; }
		
		private void StopCamera()
		{
			this._lotteryCnt = 0;
		}
		
		// TODO
		public void EndWaitCamera() { }
		
		// TODO
		public void StopWaitCameraCoroutine() { }
		
		// TODO
		private void ResetWaitCameraParam() { }
	}
}