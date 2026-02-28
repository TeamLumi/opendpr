using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIAchievementAnim : MonoBehaviour
	{
		[SerializeField]
		private Image achieveMessageImage;

		private readonly int startAnimHash = Animator.StringToHash("ShowMessage");
		private readonly int endAnimHash = Animator.StringToHash("Wait");

        private RectTransform content;
		private Animator animator;
		private AnimState currentAnimState;
		private Sprite achieveTitleSpr;
		internal bool bIsActive;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void ReleaseSprite() { }
		
		public bool IsActive { get => bIsActive; }
		
		// TODO
		public void ShowMessage(Sprite titleSpr) { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void UpdateWaitStartPlayAnim() { }
		
		// TODO
		private void UpdatePlayingAnim() { }
		
		// TODO
		public void PlayAnimationSE(GMSSoundPlayer.PlaySE_ID seID) { }

		private enum AnimState : int
		{
			WaitStartPlayAnim = 0,
			PlayingAnim = 1,
			End = 2,
		}
	}
}