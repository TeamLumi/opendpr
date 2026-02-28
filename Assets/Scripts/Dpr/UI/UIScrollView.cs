using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class UIScrollView : MonoBehaviour
    {
        [SerializeField]
        private ScrollRect scrollRect;
        [SerializeField]
        private GameObject itemPrefab;
        [SerializeField]
        private DirectionType direction;
        [SerializeField]
        private int duplicateItemCount = 2;
        [SerializeField]
        private int beginScrollCount = 1;
        [SerializeField]
        private IndexSelector indexSelector;
        private Action<IUIButton> onRequiedItemData;
        private Action<IUIButton> onSelectItem;
        private Action<IUIButton> onUnSelectItem;
        private LayoutGroup layoutGroup;
        private bool isHorizontal;
        private bool isActive;
        private LinkedList<IUIButton> scrollRectItems;
        private float viewportSize;
        private int itemSize;
        private int itemSizeWithSpacing;
        private int viewItemCount;
        private int itemCount;
        private int topPadding;
        private int bottomPadding;
        private int spacing;
        private float contentSize;
        private int viewMaxIndex;
        private int renderedStartIndex;
        private int topPaddingItemCount;
        private int paddingItemCount;
        private int gridItemCount;
        private float maxScrollValue;
        private IUIButton selectedItemNode;

        private float ContentAnchorPos { get => isHorizontal ? scrollRect.content.anchoredPosition.x : scrollRect.content.anchoredPosition.y; }
        public int GridItemCount { get => gridItemCount; }
        public LinkedList<IUIButton> ScrollItems { get => scrollRectItems; }

        // TODO
        private void Awake() { }

        public void Initialize(Action<IUIButton> onRequiedItemData, Action<IUIButton> onSelectItem, Action<IUIButton> onUnSelectItem)
        {
        	this.onRequiedItemData = onRequiedItemData;
        	this.onSelectItem = onSelectItem;
        	this.onUnSelectItem = onUnSelectItem;
        	this.selectedItemNode = null;
        	this.isActive = true;
        }

        // TODO
        public void Setup(int itemCount, int selectIndex = 0, float scrollPos = 0.0f, bool isForceScroll = false) { }

        public void SetActive(bool isActive)
        {
        	this.isActive = (isActive ? 1 : 0) & 1;
        }

        // TODO
        public float GetScrollPosition() { return 0.0f; }

        // TODO
        public bool MoveSelect(int value) { return false; }

        // TODO
        public bool Scroll(float value) { return false; }

        // TODO
        public bool MovePage(bool isNext) { return false; }

        public void ResumeMoveSelect()
        {
        	this.indexSelector.ResumeMoveState();
        }

        // TODO
        private void SetSelectIndex(int index) { }

        // TODO
        private void SelectItemNode(int index) { }

        // TODO
        private void OnValueChanged(Vector2 normalizedPosition) { }

        // TODO
        private void UpdateRendererItems(int viewTopPos) { }

        // TODO
        private void ForceUpdateItems(int startIndex) { }

        // TODO
        private void RefreshScrollContentAnchorPosition() { }

        // TODO
        private void SetLayoutGroupPadding(int value) { }

        // TODO
        private void SetScrollRectAnchorPosition(float value) { }

        public enum DirectionType : int
        {
            Vertical = 0,
            Horizontal = 1,
        }
    }
}