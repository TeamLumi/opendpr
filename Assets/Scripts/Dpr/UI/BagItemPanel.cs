using Dpr.Item;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class BagItemPanel : MonoBehaviour
	{
		public static int SwitchItemDescriptionWazaPanelButton = UIManager.ButtonPlusMinus;
		private const string BagPocketMessageFileName = "ss_bag_pocket";
		private static readonly string[] CategoryNameMessageLabels = new string[]
		{
            "SS_bag_pocket_017", "SS_bag_pocket_018", "SS_bag_pocket_024", "SS_bag_pocket_019",
            "SS_bag_pocket_020", "SS_bag_pocket_021", "SS_bag_pocket_022", "",
            "SS_bag_pocket_023",
        };
		private const int ChangeAmountValue = 1;
		private const int ChangeLotAmountValue = 10;

		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private BagIconPanel bagIconPanel;
		[SerializeField]
		private UIText moneyValueText;
		[SerializeField]
		private UIButtonSelector categoryButtonSelector;
		[SerializeField]
		private UIText categoryNameText;
		[SerializeField]
		private RectTransform categoryLeftArrowRectTransform;
		[SerializeField]
		private RectTransform categoryRightArrowRectTransform;
		[SerializeField]
		private UIScrollView itemListScrollView;
		[SerializeField]
		private UIText noDataText;
		[SerializeField]
		private BagItemDescriptionPanel bagItemDescriptionPanel;
		[SerializeField]
		private BagItemSelectAmount selectAmount;

		private bool isRemoveNewEnable;
		private bool isBattle;
		private ItemListMemory itemListMemory;
		private List<ItemInfo> items;
		private BagCategoryButton currentCategoryButton;
		private Coroutine removeNewIconCoroutine;
		private Action<int> onDecideSelectAmountCallback;
		private Action onCancelSelectAmountCallback;
		private Action<int> onSelectAmountValueChangedCallback;
		
		public int CurrentCategoryId { get; private set; }
		public bool IsNoItem { get => items == null || items.Count == 0; }
		public BagItemButton SelectedItemButton { get; private set; }
		public bool IsShowSelectAmount { get => selectAmount.IsShow; }
		public bool CanSwitchDescriptionWazaPanel { get => SelectedItemButton != null && (ItemInfo.CategoryType)CurrentCategoryId == ItemInfo.CategoryType.WazaMachine; }
		public UIButtonSelector CategorySelector { get => categoryButtonSelector; }

        public event Action<BagItemButton> OnChangeSelectItem;

        // TODO
        public void Initialize(ItemListMemory itemListMemory, [Optional] [DefaultParameterValue(false)] bool isBattle, [Optional] ItemInfo.CategoryType[] categoryTypes) { }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void SetRemoveNewEnable(bool isEnable) { }
		
		public void SetShowDescriptionContestWaza(bool isShowWazaContest)
		{
			this.bagItemDescriptionPanel.isShowWazaContest = (isShowWazaContest ? 1 : 0) & 1;
		}
		
		// TODO
		public void MoveCategorySelect(int value) { }
		
		public void ResumeCategoryMoveSelect()
		{
			this.categoryButtonSelector.ResumeMoveSelect();
		}
		
		// TODO
		public void MoveItemListSelect(int value) { }
		
		// TODO
		public void MoveItemListPage(bool isNext) { }
		
		public void ResumeItemListMoveSelect()
		{
			this.itemListScrollView.ResumeMoveSelect();
		}
		
		// TODO
		public void ChangeSelectAmount(bool isAdd, bool isLot) { }
		
		public void ResumeSelectAmountChange()
		{
			this.selectAmount.ResumeChangeAmount();
		}
		
		// TODO
		public void DecideSelectAmount() { }
		
		// TODO
		public void CancelSelectAmount() { }
		
		// TODO
		public void ReloadItemList(bool isFocusSelectedItem = false, int selectedItemId = 0) { }
		
		// TODO
		public void SetMoneyText(int money) { }
		
		public void ShowSelectAmount(int min, int max, Action<int> onDecide, Action onCancel, [Optional] Action<int> onAmountValueChanged)
		{
			this.onDecideSelectAmountCallback = onDecide;
			this.onCancelSelectAmountCallback = onCancel;
			this.onSelectAmountValueChangedCallback = onAmountValueChanged;
			this.selectAmount.Set(min,max);
			this.selectAmount.Show();
		}
		
		public void SetSelectAmountDescriptionText(string text)
		{
			this.selectAmount.SetDescriptionText(text);
		}
		
		public void SwitchItemDescriptionWazaPanel()
		{
			this.bagItemDescriptionPanel.SwitchWazaDescrption();
		}
		
		// TODO
		public void PlayCursorDecideAnimation() { }
		
		// TODO
		private void SetupCategoryButtons(int selectIndex, [Optional] ItemInfo.CategoryType[] activeCategoryTypes) { }
		
		// TODO
		private void OnSelectCategoryButton(IUIButton button) { }
		
		// TODO
		private void OnUnSelectCategoryButton(IUIButton button) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void StartRemoveNew(BagItemButton bagItemButton) { }
		
		// TODO
		private void CancelRemoveNew() { }
	}
}