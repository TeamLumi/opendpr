using Dpr.Item;
using Dpr.Message;
using Dpr.SubContents;
using Pml.UgFather;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UISellItemUg : UIWindow
	{
		private const string BagPocketMessageFileName = "ss_bag_pocket";

		private static readonly string[] CategoryNameMessageLabels = new string[]
		{
            "SS_bag_pocket_017", "SS_bag_pocket_018", "SS_bag_pocket_024",
            "SS_bag_pocket_019", "SS_bag_pocket_020", "SS_bag_pocket_021",
            "SS_bag_pocket_022", "",                  "SS_bag_pocket_023",
        };

		[SerializeField]
		private UIButtonSelector categorySelector;
		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private UIText descriptionHeaderNameText;
		[SerializeField]
		private UIText descriptionText;
		[SerializeField]
		private UIText categoryNameText;
		[SerializeField]
		private UIText noDataText;
		[SerializeField]
		private Image descriptionItemIconImage;
		[SerializeField]
		private SellUgItemPanel ugItemPanel;
		[SerializeField]
		private UgItemSelectAmount selectAmount;
		[SerializeField]
		private BagIconPanel bagIconPanel;

		private Dictionary<int, UgFatherDataManager.SellItemData> sellItemDataTable = new Dictionary<int, UgFatherDataManager.SellItemData>();
		private Dictionary<int, int> convertItemIdTable = new Dictionary<int, int>();
		private List<ItemInfo> itemInfoList = new List<ItemInfo>();
		private UgFatherDataManager dataManagerPtr;
		private Coroutine removeNewIconCoroutine;
		private KeyGuideCreater keyguide = new KeyGuideCreater();
		private ShowMessageWindow msgWindow = new ShowMessageWindow();
		private MessageMsgFile shopMsgFile;
		private BagCategoryButton currentCategoryButton;
		private BagItemButton currentSelectItem;
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
		private void SetupCategoryData() { }
		
		// TODO
		private void SetupItemData() { }
		
		// TODO
		private bool IsContainsCategory(int id, ref ItemInfo.CategoryType[] categoryArray) { return default; }
		
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
		
		private void OnFinishSellProcess()
		{
			this.state = (MenuState)1;
		}
		
		// TODO
		private bool CheckIsEmptySelectItem() { return default; }
		
		private bool CheckIsEmptySellItemData()
		{
			return this.sellItemData == null;
		}
		
		// TODO
		private void OnSelectCategoryButton(IUIButton button) { }
		
		// TODO
		private void OnUnSelectCategoryButton(IUIButton button) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void SetItemInfo(ItemInfo itemInfo) { }
		
		// TODO
		private void SetCursor(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void ReloadScrollView(int selectIndex = 0, float scrollPos = 0.0f) { }
		
		// TODO
		private void ReloadItemInfoList(ItemInfo.CategoryType categoryType) { }
		
		// TODO
		private void ClearItemInfo() { }
		
		// TODO
		private void StartRemoveNew(BagItemButton itemButton) { }
		
		// TODO
		private void CancelRemoveNew() { }
		
		// TODO
		private bool IsIncludeNewItemInCategory(ItemInfo.CategoryType category) { return default; }
		
		// TODO
		private bool IsIncludeNewItemInCurrentList() { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
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