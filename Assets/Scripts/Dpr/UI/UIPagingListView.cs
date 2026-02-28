using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class UIPagingListView : MonoBehaviour
	{
		[SerializeField]
		private RectTransform contents;
		[SerializeField]
		private GameObject itemPrefab;
		[SerializeField]
		private IndexSelector itemIndexSelector;
		[SerializeField]
		private IndexSelector pagingIndexSelector;

		private int viewItemMaxCount;
		private int contentsItemCount;
		private List<IUIButton> itemButtonList;

		public event Action<IUIButton> OnRequiredItemData;
		
		public int PageIndex { get => pagingIndexSelector.CurrentIndex; }
		public int PageCount { get; private set; }
		public IUIButton SelectedItem { get; private set; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Setup(int count, int showPageIndex = 0, int selectIndex = 0) { }
		
		// TODO
		private void SetupContents() { }
		
		// TODO
		private void UpdatePageContents() { }
		
		// TODO
		private void UpdateSelectItem() { }
		
		public bool MoveSelect(int value)
		{
			if ((this.itemIndexSelector.Move(value) & 1) != 0) {
			  UpdateSelectItem();
			  return true;
			}
			return false;
		}
		
		public void ResumeSelectMove()
		{
			this.itemIndexSelector.ResumeMoveState();
		}
		
		public bool MovePage(int value)
		{
			if ((this.pagingIndexSelector.Move(value) & 1) != 0) {
			  UpdatePageContents();
			  return true;
			}
			return false;
		}
		
		public void ResumePageMove()
		{
			this.pagingIndexSelector.ResumeMoveState();
		}
	}
}