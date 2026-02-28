using DG.Tweening;
using Dpr.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIGMSScene : MonoBehaviour
	{
		private readonly int launchAnimHash = Animator.StringToHash("LaunchAnim");
		private readonly int launchAnimInHash = Animator.StringToHash("LaunchAnimIn");
        private readonly int idleAnimHash = Animator.StringToHash("LaunchAnimIdle");

        [SerializeField]
		private SubkeyguideObj subkeyguideObj;
		[SerializeField]
		private PutPointObj putCompAnimObj;
		[SerializeField]
		private PutPointObj putCompObj;
		[SerializeField]
		private RawImage sceneBGRawImage;
		[SerializeField]
		private RawImage rtRawImage;
		[SerializeField]
		private Image titleLogoImage01;
		[SerializeField]
		private Image preTitleLogoImage;
		[SerializeField]
		private Image titleLogoImage02;
		private Canvas launchAnimCanvas;
		private DOTweenAnimation headerFadeTween;
		private CanvasGroup headerCanvasGroup;
		private Animator launchAnimator;
		private AnimState animState;
		private Sprite titleSpr;
		private Sprite preTitleSpr;
		private bool bIsPlayLaunchAnim;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		private void ReleaseSprite() { }
		
		public bool IsPlayLaunchAnim { get => bIsPlayLaunchAnim; }
		
		public void Setup(int maxPutNum)
		{
			this.putCompObj.Setup();
			this.putCompAnimObj.Setup(maxPutNum);
		}
		
		public void SetSceneBGTexture(Texture2D bgTexture)
		{
			this.sceneBGRawImage.texture = bgTexture;
		}
		
		public void SetRenderTexture(RenderTexture rt)
		{
			this.rtRawImage.texture = rt;
		}
		
		// TODO
		public void SetTitleLogoSpr(Sprite titleLogoSpr, Sprite preTitleLogoSpr) { }
		
		// TODO
		public void ShowHeader() { }
		
		// TODO
		public void HideHeader() { }
		
		public void ShowPutNumText(int putNum, bool isComp)
		{
			this.putCompObj.Show(putNum,(isComp ? 1 : 0) & 1);
		}
		
		public void HidePutNumText()
		{
			var uVar1 = this.putCompObj.putPointContent.activeSelf;
			if ((uVar1 & 1) != 0) {
			  this.putCompObj.putPointContent.SetActive(0);
			}
			uVar1 = this.putCompObj.putPointCompContent.activeSelf;
			if ((uVar1 & 1) != 0) {
			  this.putCompObj.putPointCompContent.SetActive(0);
			}
		}
		
		public void SetSubkeyguideActive(bool active)
		{
			if (((this.subkeyguideObj.isShow == 0 ^ active) & 1) != 0) {
			}
			active = (active ? 1 : 0) & 1;
			this.subkeyguideObj.isShow = active;
			this.subkeyguideObj.bgImg.enabled = active;
			this.subkeyguideObj.iconImg.enabled = active;
			this.subkeyguideObj.text.enabled = active;
		}
		
		public void StartSceneAnim(int putNum, bool isComp)
		{
			this.launchAnimCanvas.enabled = 1;
			this.animState = (AnimState)0;
			this.putCompAnimObj.Show(putNum,(isComp ? 1 : 0) & 1);
			this.launchAnimator.enabled = 1;
			this.launchAnimator.Play(this.launchAnimHash);
			this.bIsPlayLaunchAnim = true;
		}
		
		// TODO
		public void StartOnBackTopAnim(int putNum, bool isComp) { }
		
		public void PlayEndAnim()
		{
			this.animState = (AnimState)1;
			this.launchAnimCanvas.enabled = 0;
		}
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void UpdateLaunchAnim() { }
		
		// TODO
		private void UpdateEndAnim() { }
		
		// TODO
		private bool CheckTransitionAnim(int animHash) { return default; }
		
		// TODO
		public void PlayAnimationSE(GMSSoundPlayer.PlaySE_ID seID) { }

		[Serializable]
		private class SubkeyguideObj
		{
			public Image bgImg;
			public Image iconImg;
			public UIText text;
			private bool isShow = true;
			
			public void SetComponentEnabled(bool enabled)
			{
				if (((!this.isShow ^ enabled) & 1) != 0) {
				}
				enabled = (enabled ? 1 : 0) & 1;
				this.isShow = enabled;
				this.bgImg.enabled = enabled;
				this.iconImg.enabled = enabled;
				this.text.enabled = enabled;
			}
		}

		[Serializable]
		public class PutPointObj
		{
			public GameObject putPointContent;
			public UIText putPointNumText;
			public GameObject putPointCompContent;
			public UIText putPointCompNumText;
			private int currentPutPointNum = -1;
			
			public void Setup(int maxPutNum)
			{
				this.putCompObj.Setup();
				this.putCompAnimObj.Setup(maxPutNum);
			}
			
			// TODO
			public void Show(int putNum, bool isComp) { }
			
			public void Hide()
			{
				if ((this.putPointContent.activeSelf & 1) != 0) {
				  this.putPointContent.SetActive(0);
				}
				if ((this.putPointCompContent.activeSelf & 1) != 0) {
				  this.putPointCompContent.SetActive(0);
				}
			}
			
			// TODO
			private void ShowNormalUI(int putNum) { }
			
			// TODO
			private void SetPutPointNumText(int putNum) { }
			
			private void HideNormalUI()
			{
				if ((this.putPointContent.activeSelf & 1) != 0) {
				  this.putPointContent.SetActive(0);
				}
			}
			
			private void SetNormalUIActive(bool active)
			{
				if (((this.putPointContent.activeSelf ^ active) & 1) != 0) {
				  this.putPointContent.SetActive((active ? 1 : 0) & 1);
				}
			}
			
			private void ShowCompleteUI()
			{
				if ((this.putPointCompContent.activeSelf & 1) != 0) {
				}
				this.putPointCompContent.SetActive(1);
			}
			
			private void HideCompleteUI()
			{
				if ((this.putPointCompContent.activeSelf & 1) != 0) {
				  this.putPointCompContent.SetActive(0);
				}
			}
			
			private void SetCompleteUIActive(bool active)
			{
				if (((this.putPointCompContent.activeSelf ^ active) & 1) != 0) {
				  this.putPointCompContent.SetActive((active ? 1 : 0) & 1);
				}
			}
		}

		private enum AnimState : int
		{
			LaunchAnim = 0,
			EndAnim = 1,
		}
	}
}