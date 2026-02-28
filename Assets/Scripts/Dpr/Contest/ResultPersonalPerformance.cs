using DG.Tweening;
using Dpr.Battle.View.Objects;
using Dpr.Message;
using Dpr.UI;
using System.Collections;
using UnityEngine;
using XLSXContent;

namespace Dpr.Contest
{
	public class ResultPersonalPerformance : MonoBehaviour
	{
		private const float WAIT_DURATION = 1.0f;

		private SceneObjectManager objManagerPtr;
		private UIPersonalBoard uiBoard;
		private MessageMsgFile uiMsgFile;
		private CameraAnimation cameraAnim;
		private DOTweenAnimation moveFrameTween;
		private Keyguide keyguide;
		private ContestInput input = new ContestInput();
		private ContestConfigDatas.SheetResultMotion motionData;
		private BOPokemon userPokemon;
		private WaitForSeconds waitDelayMoveFrame;
		private WaitForSeconds waitCameraAnim;
		internal State currentState;
		private string playVoiceEventName;
		private bool isPlayVoice;
		private bool bIsUserWin;
		internal bool bRunning;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void ResetParam() { }
		
		public void OnFinalize()
		{
			CloseKeyguid();
			this.input.Remove();
			this.objManagerPtr = null;
			this.waitCameraAnim = null;
			this.waitDelayMoveFrame = null;
		}
		
		// TODO
		public void Setup(ResultDataModel resultDataModel) { }
		
		// TODO
		private void SettingCameraTweenParam(ContestConfigDatas.SheetResultCameraTween cameraParam) { }
		
		// TODO
		private string GetBestTimingCntStr(int count) { return default; }
		
		// TODO
		private string GetGreatTimingCntStr(int count) { return default; }
		
		// TODO
		private string GetNiceTimingCntStr(int count) { return default; }
		
		// TODO
		private string GetMissTimingCntStr(int count) { return default; }
		
		// TODO
		private string PerseCntText(int count, string labelName) { return default; }
		
		// TODO
		public void StartAnimation() { }
		
		// TODO
		private IEnumerator IE_StartAnimation() { return default; }
		
		// TODO
		private void PlayVoice() { }
		
		// TODO
		private void ChangeUserPokeAnimation(BattlePokemonEntity.AnimationState motionState) { }
		
		// TODO
		private BattlePokemonEntity.AnimationState GetMotionStateByScoreRanking() { return default; }
		
		// TODO
		private void OpenKeyguid() { }
		
		// TODO
		private void CloseKeyguid() { }
		
		// TODO
		private void ChangeState(State nextState) { }
		
		public bool OnUpdate()
		{
			UpdatePokeMotion();
			if ((int)this.currentState == 1) {
			  UpdateKeywait();
			}
			return this.bRunning;
		}
		
		// TODO
		private void UpdateKeywait() { }
		
		// TODO
		private void UpdatePokeMotion() { }

		internal enum State : int
		{
			WaitStart = 0,
			Keywait = 1,
			Finish = 2,
		}

		private class CameraAnimation
		{
			private Camera mainCamera;
			private Transform cameraTransform;
			private Vector3 endPosValue;
			private Vector3 endAngleValue;
			private float duration;
			
			public CameraAnimation(Camera targetCamera, float duration, Vector3 endPosValue, Vector3 endAngleValue)
			{
				mainCamera = targetCamera;
				cameraTransform = mainCamera.transform;

				this.duration = duration;
				this.endPosValue = endPosValue;
				this.endAngleValue = endAngleValue;
			}
			
			// TODO
			public void DOPlayForward() { }
		}
	}
}