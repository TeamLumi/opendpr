using DG.Tweening;
using Dpr.MsgWindow;
using Dpr.SubContents;
using UnityEngine;

namespace Dpr.Contest
{
	public class ResultTotalScores : MonoBehaviour
	{
		private readonly int animHash = Animator.StringToHash("ResultMedalRoll");

		[SerializeField]
		private Color toEnvLightColor;
		[SerializeField]
		private ResultScoreGauge[] playerScoreGaugeArray;
		private ResultPlayerDataModel[] playerDataArray;
		private int[] playerScoreArray;
		private EnvControllerAnimation envAnimation;
		private ShowMessageWindow resultMsg = new ShowMessageWindow();
		private WaitTimer waitTimer = new WaitTimer();
		private ResultSettings settingsData;
		private DOTweenAnimation fadeTween;
		private StateID currentState;
		private StateID nextStateID;
		private ResultID resultID;
		private Sprite medalSpr;
		private float waitDuration;
		private float timer;
		private int announcedPlayerIndex;
		private int maxTotalScore;
		private int bestPerformerNum;
		private bool bRunning;
		private bool bStopUpdate;
		private bool bIsUserBestPerformer;
		
		// TODO
		public void Initialize(ResultSettings setting) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void Setup(ResultDataModel resultDataModel) { }
		
		// TODO
		public void StartAnimation() { }
		
		// TODO
		private void ChangeState(StateID nextStateID) { }
		
		// TODO
		private void ChangeStartAnnnounce() { }
		
		// TODO
		private void ChangeGaugeAnim() { }
		
		// TODO
		private void ChangeStateAnnounceWinner() { }
		
		// TODO
		private void ChangeStateLeave() { }
		
		private void ChangeStateEnd()
		{
			this.bRunning = false;
		}
		
		// TODO
		private void TransitionWaitState(StateID nextStateID, float waitDuration) { }
		
		// TODO
		public bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		private void UpdateGaugeAnim(float deltaTime) { }
		
		// TODO
		private void UpdateAnounceWinner(float deltaTime) { }
		
		// TODO
		private void UpdateWait(float deltaTime) { }

		private enum StateID : int
		{
			Admission = 0,
			StartAnnounce = 1,
			GaugeAnim = 2,
			AnnounceWinner = 3,
			Leave = 4,
			Wait = 5,
			End = 6,
		}

		private class EnvControllerAnimation
		{
			private const float LIGHT_TWEEN_DURATION = 0.3f;

			private EnvironmentController envController;
			private Color toColor;
			private Color defaultColor;
			
			public EnvControllerAnimation(EnvironmentController envController, Color toColor)
			{
				this.envController = envController;
				this.toColor = toColor;

				defaultColor = envController.parameters.LightColor;
			}
			
			// TODO
			public void DoForward() { }
			
			// TODO
			public void DoBackward() { }
		}
	}
}