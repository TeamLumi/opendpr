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
		private Action<AUIGMSScrollItem> onRequiredItem;
		private Action<int> onMoveScrollView;
		private Action onSelect;
		private Action onCancel;
		private Action onReleaseInput;
		
		// TODO
		public void Initialize(Action<AUIGMSScrollItem> onRequiredItem, Action<int> onMoveScrollView, Action onSelect, Action onCancel, Action onReleaseInput) { }
		
		// TODO
		public void Setup(int dataNum, int startIndex) { }
		
		// TODO
		public void OnFinalize() { }
		
		public int CurrentSelectIndex { get => currentSelectIndex; }
		public bool IsPlayingInput { get => bIsPlayingInput; }
		public AUIGMSScrollItem LastSelectItem { get => lastSelectItem; }
		
		// TODO
		public AUIGMSScrollItem GetScrollItemByIndex(int index) { return default; }
		
		public void SetInputEnabled(bool enabled) {
		    this.bInputEnabled = enabled;
		}
		
		// TODO
		public void Show(string title = "") { }
		
		// TODO
		public void SettingCursor() { }
		
		// TODO
		public void Hide(Vector2 hidePosition) { }
		
		// TODO
		private void SetListTitle(string title) { }
		
		// TODO
		private void SetAnchoredPosition(Vector2 anchoredPosition) { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void UpdateInput() { }
		
		// TODO
		private void UpdateCursorPos() { }
		
		// TODO
		public void DoMoveScrollView(int moveIndex, bool playMoveSE = true, bool isInput = true) { }
		
		// TODO
		public void ReleaseInput() { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
	}
}