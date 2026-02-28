using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BadgeGetViewController : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
	{
		[SerializeField]
		private Transform modelCameraRoot;
		[SerializeField]
		private Camera modelCamera;
		[SerializeField]
		private EnvironmentController environmentController;
		[SerializeField]
		private EnvironmentSettings badgeCaseEnvironmentSettings;
		[SerializeField]
		private BadgeCaseObject badgeCaseObject;
		private bool isPlayingZoom;
		private float zoomTime;
		private float zoomProgressTime;
		private Vector3 defaultPosition;
		private Vector3 zoomPrevPosition;
		private Vector3 zoomNextPosition;
		private float defaultFOV;
		private float zoomPrevFOV;
		private float zoomNextFOV;
		
		// TODO
		public bool IsReady { get; }
		
		// TODO
		public void OnViewportChange(int screenWidth, int screenHeight) { }
		
		// TODO
		public void Initialize(UIInputController input) { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public IEnumerator Redraw() { return default; }
		
		// TODO
		public void CreateRenderTexture(RawImage rawImage) { }
		
		// TODO
		public void Setup(RenderTexture renderTexture) { }
		
		// TODO
		public IEnumerator LoadBadgeGetAnimation() { return default; }
		
		public void PlayAnimationBadgeGet(string animeName)
		{
			this.badgeCaseObject.badgeCaseAnimator.Play(animeName,0);
			0x3f800000.speed = this.badgeCaseObject.badgeCaseAnimator;
			this.badgeCaseObject.badgeAnimator.Play(animeName,0);
			0x3f800000.speed = this.badgeCaseObject.badgeAnimator;
		}
		
		// TODO
		public void PlayEffectBadgeGet(int badgeNo) { }
		
		// TODO
		public void ZoomIn(float time, int badgeNo) { }
		
		// TODO
		public void ZoomOut(float time, int badgeNo) { }
	}
}