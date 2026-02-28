using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class CardAnimationController : MonoBehaviour
	{
		private readonly int AnimParamFromCardId = Animator.StringToHash("FromCardId");
		private readonly int AnimParamToCardId = Animator.StringToHash("ToCardId");
        private readonly int AnimParamFromCaseId = Animator.StringToHash("FromCaseId");
        private readonly int AnimParamToCaseId = Animator.StringToHash("ToCaseId");

        private List<Animator> animators;
		private Animator mainAnimator;
		private CardModelViewController cardModelViewController;
		private bool isOpened;
		
		public bool IsShowBadgeCase { get; private set; }
		public bool IsCardFront { get; private set; }
		public bool IsOpen { get; private set; }
		public bool IsAnimation { get => mainAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f; }
		
		// TODO
		public bool IsAnimationAll { get; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void RegisterAnimator(Animator animator, bool isMain) { }
		
		public void RegisterCardModelViewController(CardModelViewController cardModelViewController)
		{
			this.cardModelViewController = cardModelViewController;
		}
		
		// TODO
		public void ShowCard() { }
		
		// TODO
		public void SwitchCardFrontBack() { }
		
		// TODO
		public void ShowBadgeCase() { }
		
		// TODO
		public void OpenCover() { }
		
		// TODO
		public void CloseCover() { }
		
		public void SetEnviromentLight(int isEnable)
		{
			this.cardModelViewController.SetEnviromentLight(isEnable == 1);
		}
		
		public void RebindMain()
		{
			this.mainAnimator.Rebind();
		}
		
		// TODO
		private void SetAnimatorParams(int fromCard, int toCard, int fromCase, int toCase) { }
	}
}