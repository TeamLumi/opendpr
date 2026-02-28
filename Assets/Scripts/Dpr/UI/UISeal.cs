using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UISeal : UIWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		public const string QuestionCapsuleActionMessageLabel = "DLP_stickers_003";
		public const string CantAffixSealMoreMessageLabel = "DLP_stickers_005";
		public const string QuestionRemoveAllAffixSealsMessageLabel = "DLP_stickers_007";
		public const string QuestionSwitchModeMessageLabel1 = "DLP_stickers_035";
		public const string QuestionSwitchModeMessageLabel2 = "DLP_stickers_036";
		public const string QuestionCopySealMessageLabel = "DLP_stickers_028";
		public const string DontCopyExistAffixSealMessageLabel = "DLP_stickers_029";
		public const string DontCopySameCapsuleMessageLabel = "DLP_stickers_030";
		public const string QuestionCopyPartSeal1MessageLabel = "DLP_stickers_031";
		public const string QuestionCopyPartSeal2MessageLabel = "DLP_stickers_032";
		public const string ResultCopySealMessageLabel = "DLP_stickers_033";
		public const string DontCopyNotEnoughSealMessageLabel = "DLP_stickers_034";
		public const string RemoveAllAffixSealResultMessageLabel = "DLP_stickers_022";
		public const string CantAffixSealMessageLabel = "DLP_stickers_025";

		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private GameObject headerObject;
		[SerializeField]
		private RectTransform capsuleBaseRectTransform;
		[SerializeField]
		private UIScrollView capsuleScrollView;
		[SerializeField]
		private CapsuleViewController capsuleViewController;
		[SerializeField]
		private GameObject listSceneObject;
		[SerializeField]
		private SealEditSceneController sealEditSceneController;
		[SerializeField]
		private RectTransform contextMenuPosition;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private UIMsgWindowController msgWindowController;
		private Keyguide keyguide;
		private CapsuleInfo[] capsuleInfos;
		private CapsuleItemButton selectedCapsuleItemButton;
		private CapsuleInfo actionSelectedCapsuleInfo;
		private Vector3 initialCapsuleBaseAnchorPosition;
		private int currentSelectIndex;
		private float currentScrollPosition;
		private bool isCopyOnly;
		private bool isUnionRoomView;
		private bool isCallFromEvent;
		private bool isEditMode;
		private ActionType actionType;
		private Action<bool> onCopyOnlyEndCallback;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(bool isCallFromEvent = false, UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public void OpenCopyOnly(CapsuleInfo capsuleInfo, [Optional] [DefaultParameterValue(false)] bool isCallFromEvent, [Optional] Action<bool> onEndCallback, UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public void OpenUnionRoomView(CapsuleInfo[] capsuleInfos, UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId)
		{
			// TODO
			IEnumerator Init() { return default; }

            return default;
		}
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateSelect(float deltaTime) { }
		
		// TODO
		private void OnUpdateDefault(float deltaTime) { }
		
		// TODO
		private void OnUpdateCopyOnly(float deltaTime) { }
		
		// TODO
		private void OnUpdatePreview(float deltaTime) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void ReloadScrollView() { }
		
		// TODO
		private void SetupCapsuleView() { }
		
		// TODO
		private void ShowEditMode(CapsuleInfo capsuleInfo) { }
		
		// TODO
		private void HideEditMode() { }
		
		// TODO
		private IEnumerator ShowPreview() { return default; }
		
		// TODO
		private IEnumerator HidePreview()
		{
			// TODO
            void OnBeforeFadeIn() { }

            return default;
		}
		
		// TODO
		private void StartRemoveAllAffixSeals(CapsuleItemButton capsuleItemButton) { }
		
		// TODO
		private void StartCapsuleAction(ActionType actionType, CapsuleItemButton capsuleItemButton) { }
		
		// TODO
		private void EndCapsuleAction(CapsuleItemButton capsuleItemButton)
		{
			// TODO
			void End() { }
        }
		
		// TODO
		private void SwitchMode() { }
		
		// TODO
		private void OnReverseCapsule2D() { }
		
		private void CopyOnlyDecide()
		{
			var uVar1 = new Action(this);
			this.msgWindowController.OpenMsgWindow(2,_StringLiteral_11890,1,0,uVar1,0);
		}
		
		// TODO
		private void CopyCapsule(CapsuleInfo sourceCapsule, CapsuleInfo destCapsule, bool isQuestionBeforeCopy, Action onCancel, Action onEnd) { }
		
		// TODO
		private void OpenCapsuleContextMenu(CapsuleItemButton capsuleItemButton)
		{
			// TODO
            void OnSelected(ContextMenuID menuID) { }
        }
		
		// TODO
		private void OpenContextMenu(ContextMenuID[] contextMenuIDs, Action<ContextMenuID> onSelected, Vector2 pivot, Vector3 pos, [Optional] Action onClosed) { }

		private enum ActionType : int
		{
			None = 0,
			Copy = 1,
			Swap = 2,
			CopyOnly = 3,
		}
	}
}