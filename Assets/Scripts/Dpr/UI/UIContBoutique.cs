using Dpr.Contest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UIContBoutique : ShopBase, IContestUIWindow
	{
		[SerializeField]
		private MenuHeader _header;
		[SerializeField]
		private CharacterModelView _modelView;
		[SerializeField]
		private float modelOffsetZ = 4.2f;

		private List<ShopBoutiqueItemItem.Param> _itemParams = new List<ShopBoutiqueItemItem.Param>();
		private ShopBoutiqueItemItem _selectShopItem;
		private KeyGuideCreater keyguide = new KeyGuideCreater();
		private Action onFinish;
		private ShopBoutique.BoutiqueType _boutiqueType;
		private ContestMenuEventID _resultEventID = ContestMenuEventID.None;
		private int _selectIndex;
		private bool _bIsSelected;
		private bool _bIsOpen;
		private bool _bIsOpening;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId, Action onFinish) { }
		
		// TODO
		public void OpenMultiMode(UIWindowID prevWindowID, string minutStr, string secondStr) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void InsertSecondContestDress(bool isMale) { }
		
		// TODO
		private int FindStartIndex() { return default; }
		
		public bool IsOpen { get => _bIsOpen; }
		public ContestMenuEventID ResultEventID { get => _resultEventID; }
		
		// TODO
		protected void OnUpdate(float deltaTime) { }
		
		// TODO
		protected bool UpdateSelect(float deltaTime) { return default; }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void SetupModelView() { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnDecidedSelectItem() { }
		
		// TODO
		private void ChangeSelectDressIcon() { }
		
		// TODO
		public void CloseWindow() { }
		
		// TODO
		private IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		public void SetTimeCount(string minutStr, string secondStr)
		{
			this._header.SetTime(minutStr,secondStr);
		}
	}
}