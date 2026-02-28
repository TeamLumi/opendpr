using Dpr.Playables;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class CardModelViewController : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
	{
		[SerializeField]
		private Camera bgCamera;
		[SerializeField]
		private Transform modelCameraRoot;
		[SerializeField]
		private Camera modelCamera;
		[SerializeField]
		private Transform modelRoot;
		[SerializeField]
		private RectTransform bgRoot;
		[SerializeField]
		private EnvironmentController environmentController;
		[SerializeField]
		private EnvironmentSettings playerModelEnvironmentSettings;
		[SerializeField]
		private EnvironmentSettings badgeCaseEnvironmentSettings;
		[SerializeField]
		private BadgeCaseObject badgeCaseObject;
		[SerializeField]
		private CardAnimationController animationController;
		[SerializeField]
		private Transform characterRoot;
		[SerializeField]
		private string playerModelObjectName = "PlayerModel";

		private Transform currentBgParentTransform;
		private Transform currentBgTransform;
		private int currentBgSiblingIndex;
		private GameObject playerModelObject;
		private Transform playerModelTransform;
		private AnimationLayer playerModelAnimationLayer;
		private int playerModelWaitAnimationIndex = -1;
		private string loadedAssetBundlePath;
		
		public bool IsReady { get => badgeCaseObject.IsReady; }
		public bool IsShowBadgeCase { get => animationController.IsShowBadgeCase; }
		public bool IsEndBadgeCase { get => badgeCaseObject.IsEnd; }
		public bool IsCardFront { get => animationController.IsCardFront; }
		public bool IsAnimation { get => animationController.IsAnimation; }
		public bool IsAnimationAll { get => animationController.IsAnimationAll; }
		
		// TODO
		public void OnViewportChange(int screenWidth, int screenHeight) { }
		
		// TODO
		public void Initialize(UIInputController input, Animator cardAnimator) { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void SetEnviromentLight(bool isActive) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public IEnumerator Redraw() { return default; }
		
		// TODO
		public void CreateRenderTexture(RawImage rawImage) { }
		
		// TODO
		public void Setup(RenderTexture renderTexture, Transform bgTransform) { }
		
		// TODO
		public void RotatePlayerModel(float value) { }
		
		// TODO
		public void ResetRotatePlayerModel() { }
		
		// TODO
		public void ShowCard() { }
		
		// TODO
		public void SwitchCardFrontBack() { }
		
		// TODO
		public void ShowBadgeCase() { }
		
		public void OpenBadgeCase()
		{
			if ((this.badgeCaseObject.IsOpen & 1) != 0) {
			}
			this.badgeCaseObject.OpenCover();
		}
		
		public void CloseBadgeCase()
		{
			if ((this.badgeCaseObject.IsOpen & 1) != 0) {
			  this.badgeCaseObject.CloseCover();
			}
		}
		
		// TODO
		public void LoadModels(byte fashion, byte bodyType, bool sex) { }
		
		// TODO
		private int GetPlayerWaitAnimationIndex(AnimationLayer animationLayer) { return default; }
		
		private void PlayPlayerModelWaitMotion()
		{
			if ((this.playerModelAnimationLayer != null) && (this.playerModelWaitAnimationIndex != -1)) {
			  0.Play(0,this.playerModelAnimationLayer,this.playerModelWaitAnimationIndex);
			}
		}
	}
}