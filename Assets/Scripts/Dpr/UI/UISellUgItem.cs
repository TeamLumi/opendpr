using Dpr.Item;
using Dpr.Message;
using Dpr.SubContents;
using Pml.UgFather;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UISellUgItem : UIWindow
	{
		[SerializeField]
		private BagUGCategoryButton currentCategoryButton;
		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private UIText descriptionHeaderNameText;
		[SerializeField]
		private UIText descriptionText;
		[SerializeField]
		private SellUgItemPanel ugItemPanel;
		[SerializeField]
		private UgItemSelectAmount selectAmount;
		[SerializeField]
		private GameObject noDataMessageObj;

		private Dictionary<int, UgFatherDataManager.SellItemData> sellItemDataTable;
		private List<UgItemInfo> itemInfoList;
		private UgFatherDataManager dataManagerPtr;
		private Coroutine removeNewIconCoroutine;
		private KeyGuideCreater keyguide;
		private ShowMessageWindow msgWindow;
		private MessageMsgFile shopMsgFile;
		private BagUGItemButton currentSelectItem;
		private UgFatherDataManager.SellItemData sellItemData;
		private MenuState state;
		private int nowAmount;
		private int getUgItemCount;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateStateSelectItem() { }
		
		// TODO
		private void OnUpdateSelect() { }
		
		// TODO
		private void SelectItem() { }
		
		// TODO
		private void OnDecideAmount(int amount) { }
		
		// TODO
		private void OnUpdateStateSelectAmount() { }
		
		// TODO
		private void OnUpdateStateConfirm() { }
		
		// TODO
		private void OnSelectYes() { }
		
		// TODO
		private void OnFinishSellProcess() { }
		
		// TODO
		private bool IsItemEmpty() { return default; }
		
		// TODO
		private bool CheckIsEmptySelectItem() { return default; }
		
		private bool CheckIsEmptySellItemData()
		{
			return this.sellItemData == null;
		}
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void SetItemInfo(UgItemInfo itemInfo) { }
		
		// TODO
		private void SetCursor(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void ReloadScrollView(int selectIndex = 0, float scrollPos = 0.0f) { }
		
		// TODO
		private void ClearItemInfo() { }
		
		// TODO
		private void StartRemoveNew(BagUGItemButton itemButton) { }
		
		// TODO
		private void CancelRemoveNew() { }
		
		// TODO
		private bool IsIncludeNewItemInCurrentList() { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		private IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }

		private enum MenuState : int
		{
			Wait = 0,
			SelectItem = 1,
			SelectAmount = 2,
			OpenConfirm = 3,
			WaitSell = 4,
		}
	}
}