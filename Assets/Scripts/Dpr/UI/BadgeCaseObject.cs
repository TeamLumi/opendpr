using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class BadgeCaseObject : MonoBehaviour
	{
		public const string BadgeCaseModelAssetPathFormat = "objects/ob1009_{0}";
		public const string BadgeModelAssetPath = "objects/ob1009_09";
		public const string BadgeAnimeAssetPath = "objects/ob1009_00";
		public const string BadgeCaseModelName = "ob1009_BadgeCase";
		public const string BadgeModelName = "ob1009_Badges";

		[SerializeField]
		private Animator animator;
		[SerializeField]
		private Transform maskTransform;
		[SerializeField]
		private Transform showBadgePositionTransform;
		[Header("ケースの色(ダイアモンド)")]
		[SerializeField]
		private Color diamondCaseColor = Color.white;
		[Header("ケースの文字色(ダイアモンド)")]
		[SerializeField]
		private Color diamondCaseTitleColor = Color.white;
        [Header("各ジムリーダーの枠の色(ダイアモンド)")]
		[SerializeField]
		private Color diamondGymleaderFrameColor = Color.white;
        [Header("ケースのボタン枠の色(ダイアモンド)")]
		[SerializeField]
		private Color diamondCaseButtonFrameColor = Color.white;
        [Header("ケースの色(パール)")]
		[SerializeField]
		private Color pearlCaseColor = Color.white;
        [Header("ケースの文字色(パール)")]
		[SerializeField]
		private Color pearlCaseTitleColor = Color.white;
        [Header("各ジムリーダーの枠の色(パール)")]
		[SerializeField]
		private Color pearlGymleaderFrameColor = Color.white;
        [Header("ケースのボタン枠の色(パール)")]
		[SerializeField]
		private Color pearlCaseButtonFrameColor = Color.white;
		[Header("バッジを磨く判定になる範囲")]
		[SerializeField]
		private float polishedRange = 100.0f;
		[Header("バッジ閲覧：タッチ操作での回転速度")]
		[SerializeField]
		private float badgeTouchRotateSpeed = 1.0f;
		[Header("バッジ閲覧：自動回転の開始時間(秒)")]
		[SerializeField]
		private float badgeAutoRotateStartTime = 10.0f;
		[Header("バッジ閲覧：自動回転の1回転の時間(秒)")]
		[SerializeField]
		private float badgeAutoRotateDuration = 10.0f;
		[SerializeField]
		private CardAnimationController animationController;
		[SerializeField]
		private BadgeCaseAnimationEvent animationEvent;

		private UITouchInputController touchInputController;
		private UIInputController input;
		private Transform badgeCaseTransform;
		private Transform badgeTransform;
		private Transform buttonTransform;
		private BadgeObject[] badgeObjects;
		private BadgeObject selectedBadgeObject;
		private Vector2 tempStartPoint;
		private Vector3 beforeBadgePosition;
		private Quaternion beforeBadgeRotation;
		private float noTouchTime;
		private Camera screenCamera;
		private RaycastHit[] raycastHits;
		internal Animator badgeCaseAnimator;
		internal Animator badgeAnimator;
		private bool isDisposed;
		private bool isShowBadge;
		private bool IsBadgeGet;

		public bool IsReady { get; private set; }
		public bool IsActive { get; private set; }
		public bool IsOpen { get => animationController.IsOpen; }
		public bool IsEnd { get; private set; }
		public bool IsAnimation { get => animationController.IsAnimation; }
		
		// TODO
		public void Initialize(Camera screenCamera, UIInputController input, bool isBadgeGet = false) { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void OpenCover() { }
		
		// TODO
		public void CloseCover() { }
		
		// TODO
		public void Show() { }
		
		// TODO
		public void PlayBadgeConditionEffects() { }
		
		// TODO
		public void StopBadgeConditionEffects() { }
		
		public void PlayAnimationBadgeGet(string animeName)
		{
			this.badgeCaseAnimator.Play(animeName,0);
			0x3f800000.speed = this.badgeCaseAnimator;
			this.badgeAnimator.Play(animeName,0);
			0x3f800000.speed = this.badgeAnimator;
		}
		
		// TODO
		public IEnumerator LoadBadgeGetAnimation() { return default; }
		
		// TODO
		public Transform GetBadgeTransform(int badgeNo) { return default; }
		
		// TODO
		private void SetActive(bool isActive) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private string GetBadgeCaseModelAssetPath() { return default; }
		
		// TODO
		private void LoadModel() { }
		
		// TODO
		private IEnumerator SetupModels() { return default; }
		
		// TODO
		private bool Raycast(Vector3 point, out bool isHitButton, out BadgeObject hitBadgeObject)
		{
			isHitButton = default;
			hitBadgeObject = default;
			return default;
		}
		
		// TODO
		private void SwitchBadgeCaseOpenClose() { }
		
		// TODO
		private void PlayCaseButtonEffect() { }
	}
}