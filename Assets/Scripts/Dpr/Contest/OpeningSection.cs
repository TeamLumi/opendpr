using Effect;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class OpeningSection : MonoBehaviour
	{
		private readonly int startAnimHash = Animator.StringToHash("Opening");
		private readonly int endAnimHash = Animator.StringToHash("End");

        private EffectInstance titleLogoFx;
		private EffectData titleLogoFxData;
		private Animator openingAnimator;
		private Transform cameraContent;
		private Transform canvasTransform;
		private Image contestTitleImage;
		private Image medalImage;
		private Image categoryTitleImage;
		private Image rankImage;
		private Vector3 logoFxPos;
		private AnimState animState;
		private bool bRunning;
		private bool bReady;
		
		public bool IsReady { get => bReady; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		private void SetImageComponents()
		{
			var uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8904,0);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.contestTitleImage = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8905,0);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.medalImage = uVar1;
			uVar1 = ComponentExtensions.FindDeep(StringLiteral_8906,0);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.categoryTitleImage = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8907,0);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.rankImage = uVar1;
		}
		
		// TODO
		private void LoadFx() { }
		
		public void ResetParam()
		{
			var uVar1 = this.gameObject;
			uVar1.SetActive(1);
			this.animState = (AnimState)0;
		}
		
		// TODO
		public void Stop() { }
		
		public void SetMedalSpr(Sprite spr)
		{
			this.medalImage.sprite = spr;
			this.medalImage.enabled = 1;
		}
		
		public void SetContestTitleSpr(Sprite spr)
		{
			this.contestTitleImage.sprite = spr;
			this.contestTitleImage.enabled = 1;
		}
		
		public void SetCategorySpr(Sprite spr)
		{
			this.categoryTitleImage.sprite = spr;
			this.categoryTitleImage.enabled = 1;
		}
		
		public void SetRankSpr(Sprite spr)
		{
			this.rankImage.sprite = spr;
			this.rankImage.enabled = 1;
		}
		
		public void SetMedalActive(bool active)
		{
			ExtensionMethods.SetActive(this.medalImage,(active ? 1 : 0) & 1);
		}
		
		public void SetRankActive(bool active)
		{
			ExtensionMethods.SetActive(this.rankImage,(active ? 1 : 0) & 1);
		}
		
		// TODO
		public void Setup() { }
		
		// TODO
		public void StartSection() { }
		
		// TODO
		public bool UpdateSection() { return default; }
		
		// TODO
		private void CheckStratAnimation() { }
		
		// TODO
		private void CheckFinishAnimation() { }
		
		// TODO
		private void OnFinishSection() { }
		
		// TODO
		public void PlayAllPlayerAnimation(int animationIndex) { }
		
		// TODO
		public void PlayLeftMostTrainerAnim(int animationIndex) { }
		
		// TODO
		public void PlayLeftTrainerAnim(int animationIndex) { }
		
		// TODO
		public void PlayRightTrainerAnim(int animationIndex) { }
		
		// TODO
		public void PlayRightMostTrainerAnim(int animationIndex) { }
		
		// TODO
		private void PlayTrainerMotion(int playerIndex, int animationIndex) { }
		
		// TODO
		public void PlayTitleFx() { }
		
		public void StopTitleFx()
		{
			if (this.titleLogoFx != null) {
			  0.Stop(this.titleLogoFx,0);
			}
		}

		private enum AnimState : int
		{
			WaitStartPlayAnim = 0,
			PlayingAnim = 1,
			End = 2,
		}
	}
}