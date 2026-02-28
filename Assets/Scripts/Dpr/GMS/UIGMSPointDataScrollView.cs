using Audio;
using Dpr.UI;
using System;
using UnityEngine;

namespace Dpr.GMS
{
	public class UIGMSPointDataScrollView : MonoBehaviour
	{
		private readonly Vector3 HIDE_POS = new Vector3(0.0f, 2000.0f);

		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private UIText listTitle;
		[SerializeField]
		private UIText emptyMessage;
		[SerializeField]
		private UI.Cursor cursorPtr;
		[SerializeField]
		private RectTransform cursorContent;
		[SerializeField]
		private RectTransform cursorRect;
		private AudioManager audioManager;
		private AUIGMSScrollItem lastSelectItem;
		private RectTransform scrollViewRect;
		private Vector2 defaultPosition = Vector2.zero;
		private int maxIndex;
		private int prevSelectIndex;
		private int currentSelectIndex;
		private bool bIsPlayingInput;
		private bool bInputEnabled;
		internal Action<AUIGMSScrollItem> onRequiredItem;
		internal Action<int> onMoveScrollView;
		internal Action onSelect;
		internal Action onCancel;
		internal Action onReleaseInput;
		
		// TODO
		public void Initialize(Action<AUIGMSScrollItem> onRequiredItem, Action<int> onMoveScrollView, Action onSelect, Action onCancel, Action onReleaseInput) { }
		
		// TODO
		public void Setup(int dataNum, int startIndex) { }
		
		public void OnFinalize()
		{
			this.onRequiredItem = null;
			this.onMoveScrollView = null;
			this.onSelect = null;
			this.onCancel = null;
			this.onReleaseInput = null;
		}
		
		public int CurrentSelectIndex { get => currentSelectIndex; }
		public bool IsPlayingInput { get => bIsPlayingInput; }
		public AUIGMSScrollItem LastSelectItem { get => lastSelectItem; }
		
		// TODO
		public AUIGMSScrollItem GetScrollItemByIndex(int index) { return default; }
		
		public void SetInputEnabled(bool enabled)
		{
			this.bInputEnabled = (enabled ? 1 : 0) & 1;
		}
		
		// TODO
		public void Show(string title = "") { }
		
		// TODO
		public void SettingCursor() { }
		
		// TODO
		public void Hide(Vector2 hidePosition) { }
		
		// TODO
		private void SetListTitle(string title) { }
		
		private void SetAnchoredPosition(Vector2 anchoredPosition)
		{
			this.scrollViewRect.set_anchoredPosition();
		}
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void UpdateInput() { }
		
		// TODO
		private void UpdateCursorPos() { }
		
		// TODO
		public void DoMoveScrollView(int moveIndex, bool playMoveSE = true, bool isInput = true) { }
		
		public void ReleaseInput()
		{
			this.bIsPlayingInput = false;
			this.scrollView.ResumeMoveSelect();
			if (this.onReleaseInput != null) {
			  this.onReleaseInput.Invoke();
			}
		}
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
	}
}