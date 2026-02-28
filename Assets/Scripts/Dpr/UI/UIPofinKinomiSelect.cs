using DG.Tweening;
using Dpr.Item;
using Dpr.SubContents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIPofinKinomiSelect : UIWindow
	{
		public static bool isPofinPlaying;
		public static bool isPofinEnd;

		[SerializeField]
		private BagItemPanel bagItemPanel;
		[SerializeField]
		private RectTransform startButton;

		private ItemListMemory itemListMemory;
		private ItemInfo.CategoryType[] categoryTypes = new ItemInfo.CategoryType[] { ItemInfo.CategoryType.Nuts };
		private UIMsgWindowController msgWindowController;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private List<BagItemButton> GrayButtons = new List<BagItemButton>();
		private bool isEnd;
		private bool isSortSelect;

		[SerializeField]
		private Image[] berryImages;

		private List<ItemInfo> itemList = new List<ItemInfo>();
		private MsgWindow.MsgWindow msgWindow;
		private HorizontalLayoutGroup horizontalLayout;

		[SerializeField]
		private int posy = -68;

		private List<Tweener> Tws = new List<Tweener>();
		private Keyguide.Param keyguideParam;

		private const string QuestionSortMessageLabel = "SS_bag_083";
		private const string NewSortMessageLabel = "SS_bag_079";
		private const string CancelSortMessageLabel = "SS_bag_082";
		private const string FavoriteSortMessageLabel = "SS_bag_081";
		private const string TypeSortMessageLabel = "SS_bag_077";
		private const string NameSortMessageLabel = "SS_bag_078";
		private const string NumberSortMessageLabel = "SS_bag_080";
		private const string TypeSortResultMessageLabel = "SS_bag_084";
		private const string NameSortResultMessageLabel = "SS_bag_085";
		private const string NewSortResultMessageLabel = "SS_bag_088";
		private const string FavoriteSortResultMessageLabel = "SS_bag_087";
		private const string NumberSortResultMessageLabel = "SS_bag_086";
		
		private bool isPushB { get => Utils.PushB; }
		private bool isPushA { get => Utils.PushA; }
		private bool isPushX { get => Utils.PushX; }
		private bool isPushY { get => Utils.PushY; }
		private bool isPushPlus { get => (GameController.ButtonMask.Plus & GameController.push) != 0; }
		
		// TODO
		public override void OnCreate() { }
		
		private void OnUpdate(float deltaTime)
		{
			if ((!this.isEnd) && (!this.isSortSelect)) {
			  OnUpdateDefault();
			  this.msgWindowController.OnUpdate();
			}
		}
		
		// TODO
		private void OnUpdateDefault() { }
		
		// TODO
		private void KinomiUndo() { }
		
		// TODO
		private void KinomiRedo() { }
		
		// TODO
		private Image GetEmptyImage() { return default; }
		
		// TODO
		private void SetSprite(Image image, ItemInfo item) { }
		
		// TODO
		public static Sprite GetKinomiImage(int kinomiID) { return default; }
		
		// TODO
		protected override void OnDestroy() { }
		
		// TODO
		private bool RemoveLastItem() { return default; }
		
		// TODO
		private void ShowConfirmMessage([Optional] Action OnCancel) { }
		
		// TODO
		private void GotoCooking() { }
		
		// TODO
		public void Open(bool isResult = false) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		public IEnumerator OpOpen(bool isResult) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		// TODO
		public void EnterStartButton() { }
		
		// TODO
		public void ExitStartButton() { }
		
		private void StartSortItems()
		{
			this.isSortSelect = true;
			this.bagItemPanel.SetRemoveNewEnable(0);
			var uVar2 = new Action(this);
			var uVar1 = _StringLiteral_11687;
			this.msgWindowController.OpenMsgWindow(StringLiteral_9892,uVar1,1,0,uVar2);
		}
		
		// TODO
		private void SortItems(ItemInfo.SortType sortType) { }
		
		// TODO
		private void ShowSortResultMessage(ItemInfo.SortType sortType) { }
	}
}