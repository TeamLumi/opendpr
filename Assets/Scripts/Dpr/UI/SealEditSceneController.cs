using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class SealEditSceneController : MonoBehaviour
	{
		private const float CursorMoveValue = 20.0f;

		[SerializeField]
		private SealEditCursor cursor;
		[SerializeField]
		private RectTransform cursorMovableRectTransform;
		[SerializeField]
		private CapsuleViewController capsuleViewController;
		[SerializeField]
		private RectTransform sealPalletRectTransform;
		[SerializeField]
		private RectTransform pullDownRectTransform;
		[SerializeField]
		private GameObject switchPalletIconObject;
		[SerializeField]
		private SealEditSealCountView sealEditSealCountView;

		private UIInputController input;
		private UIMsgWindowController msgWindowController;
		private Keyguide keyguide;
		private CapsuleInfo currentCapsuleInfo;
		private Dictionary<int, SealInfo[]> categoryzedSealInfoDic;
		private SealCategoryButton[] categoryButtons;
		private SealCategoryButton pullDownCategoryButton;
		private SealButton[] pullDownSealButtons;
		private int[] palletCategoryIds;
		private IndexSelector categoryIndexSelector;
		private IndexSelector pullDownIndexSelector;
		private Transform currentHitTransform;
		private Vector3 beforeCursorPosition;
		private bool isShowPullDown;
		private bool isBindCategoryTab;
		private bool canSwitchPallet;
		private bool isAllowSwicthPallet;
		private bool isHoverCategoryTab;
		private bool isHoverSetSealGridCell;
		private bool isAnimation;
		private int selectPalletIndex;
		private int maxPalletIndex;
		private Capsule2DGridCell selectedCapsule2DGridCell;
		private Capsule2DGridCell pickedCapsule2DGridCell;
		private int pickedAffixSealId = -1;
		private int pickedLatestPalletIndex;
		private int pickedLatestCategoryIndex;
		private Seal3DObject selectedSeal3DObject;
		private Seal3DObject pickedSeal3DObject;
		private GameObject dummyPalletObject;
		private Keyguide.Param keyguideParam;
		private List<KeyguideID> keyguideIdList;
		private Vector3[] rectCorners;
		private RaycastHit2D[] raycastHit2Ds;
		private bool isChangeRotate;

		private bool canResetRotate { get => currentCapsuleInfo.Is3DEditMode && isChangeRotate && !isBindCategoryTab && !isShowPullDown; }
		public Capsule2DViewController Capsule2DViewController { get => capsuleViewController.View2DController; }
		public Capsule3DViewController Capsule3DViewController { get => capsuleViewController.View3DController; }
		public bool IsShow { get; private set; }
		public bool IsAllowPreview { get => !isShowPullDown; }
		public Action OnSelectSealWhenAffixSealMaxCount { get; set; }
		
		// TODO
		public IEnumerator Initialize(UIInputController input, UIMsgWindowController msgWindowController) { return default; }
		
		public void SetKeyguid(Keyguide keyguide)
		{
			this.keyguide = keyguide;
		}
		
		// TODO
		public void Show(CapsuleInfo capsuleInfo) { }
		
		// TODO
		public void Hide() { }
		
		// TODO
		public void PlayReportCurrentCapsuleData() { }
		
		public bool OnUpdate(float deltaTime)
		{
			long uVar1;
			if (this.isAnimation) {
			  return false;
			}
			if (this.isBindCategoryTab) {
			  OnUpdateCategoryTab();
			  uVar1 = OnUpdateDefault();
			  return uVar1;
			}
			if (this.isShowPullDown) {
			  OnUpdatePullDown();
			  uVar1 = OnUpdateDefault();
			  return uVar1;
			}
			if ((this.currentCapsuleInfo.Is3DEditMode & 1) != 0) {
			  OnUpdate3DMode();
			  uVar1 = OnUpdateDefault();
			  return uVar1;
			}
			OnUpdate2DMode();
			uVar1 = OnUpdateDefault();
			return uVar1;
		}
		
		// TODO
		private bool OnUpdateDefault(float deltaTime) { return default; }
		
		// TODO
		private void OnUpdateCategoryTab(float deltaTime) { }
		
		// TODO
		private void OnUpdatePullDown(float deltaTime) { }
		
		// TODO
		private void OnUpdate3DMode(float deltaTime) { }
		
		// TODO
		private void OnUpdate2DMode(float deltaTime) { }
		
		// TODO
		private SealCategoryButton GetNearCategoryButton(Vector3 pos) { return default; }
		
		// TODO
		public void UpdateKeyGuide(bool isForce = false) { }
		
		// TODO
		private void MoveCursor(float x, float y) { }
		
		// TODO
		private DecideActionResult Decide() { return default; }
		
		// TODO
		private void SwitchMode() { }
		
		// TODO
		private void ShowPullDown(Vector3 pos) { }
		
		// TODO
		private void HidePullDown() { }
		
		// TODO
		private void UpdatePullDownCursor() { }
		
		// TODO
		private void UpdateCursorPositionToCurrentCategory() { }
		
		// TODO
		private bool MoveCurrentCategoryButtonNearestGrid() { return default; }
		
		// TODO
		private void CheckCursorRaycast(bool isForce = false, bool isCheckMovable = true, bool isSelectSe = true) { }
		
		// TODO
		private IEnumerator DelayCheckCursorRaycast(bool isForce = false, bool isCheckMovable = true, bool isSelectSe = true) { return default; }
		
		// TODO
		private void RefreshShowPullDown(bool isMoveCursorCurrentCategory = true) { }
		
		// TODO
		private void RefreshCapsuleInfo(bool isReset = false) { }
		
		// TODO
		private void UpdatePallet() { }
		
		// TODO
		private void SwitchPallet() { }
		
		// TODO
		private void CheckCategoryButtonEnable(SealCategoryButton button) { }
		
		// TODO
		private void SetupPullDown(SealCategoryButton categoryButton) { }
		
		// TODO
		private void UpdateSealCountView() { }
		
		// TODO
		private void UpdateSwitchPalletIconActive() { }
		
		// TODO
		private void SetPickedSeal(Capsule2DGridCell capsule2DGridCell) { }
		
		// TODO
		private void SetPickedSeal(Seal3DObject seal3DObject) { }
		
		private void ClearPickedSeal()
		{
			this.pickedCapsule2DGridCell = null;
			this.pickedSeal3DObject = null;
			this.pickedAffixSealId = 0xffffffff;
		}
		
		// TODO
		private void OnReverseCapsule2D() { }
		
		// TODO
		private void CheckCursorInMovableRect() { }
		
		// TODO
		private Rect GetRect(RectTransform rectTransform) { return default; }

		private enum DecideActionResult : int
		{
			None = 0,
			Default = 1,
			AffixedSeal = 2,
			PickedSeal = 3,
		}
	}
}