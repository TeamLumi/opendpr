using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class CapsuleViewController : MonoBehaviour
	{
		[SerializeField]
		private GameObject capsule3DViewPrefab;
		[SerializeField]
		private GameObject capsule2DObject;
		[SerializeField]
		private GameObject capsule3DObject;
		[SerializeField]
		private RawImage capsule3DViewRawImage;
		[SerializeField]
		private RectTransform bgRectTransform;
		[SerializeField]
		private SealSubKeyGuide subKeyGuide;

		private static GameObject capsule3DViewObject;
		private Transform bgParent;
		private bool isBeforeFadeBlurActive;
		private bool isOpenedKeyguide;
		private bool isFading;
		
		public bool IsInitialized { get => View3DController != null && View3DController.IsIntialized; }
		public Capsule2DViewController View2DController { get; private set; }
		public Capsule3DViewController View3DController { get; private set; }
		
		// TODO
		public IEnumerator Initialize() { return default; }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void Setup(CapsuleInfo capsuleInfo, bool isResetView) { }
		
		// TODO
		public void Set3DCapsuleActive(bool isAvtive) { }
		
		public void SetDisablePreviewGuide(bool isEnable)
		{
			this.subKeyGuide.SetDisablePreviewGuide((isEnable ? 1 : 0) & 1);
		}
		
		// TODO
		public IEnumerator ShowPreviewScene(CapsuleInfo capsuleInfo, CapsuleInfo subCapsuleInfo, IEnumerator playFadeWindow, Action onBeforeFadeIn, bool isCallStopScript = true) { return default; }
		
		// TODO
		public IEnumerator HidePreviewScene(IEnumerator playFadeWindow, Action onBeforeFadeIn, bool isCallOnOpenMenu = true) { return default; }
		
		// TODO
		public void UpdatePreviewKeyGuide(Keyguide keyguide) { }
		
		public bool CheckWaitFade()
		{
			var uVar1 = 0.isBusy;
			if ((uVar1 & 1) != 0) {
			  this.isFading = true;
			  return true;
			}
			if (this.isFading) {
			  var fVar2 = (float)0.fadeInProgress;
			  if (fVar2 == 1.0) {
			    this.isFading = false;
			    return false;
			  }
			  return this.isFading;
			}
			return false;
		}
		
		private void SetupRawImage(Transform parent)
		{
			Transform.SetParent(this.capsule3DViewRawImage.transform,parent,1,0);
			Transform.SetAsFirstSibling(this.capsule3DViewRawImage.transform,0);
		}
	}
}