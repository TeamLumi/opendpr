using DPData;
using Dpr.Demo;
using Dpr.Message;
using Pml.PokePara;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;

namespace Dpr.UI
{
	public class UIPofinCase : UIWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private UIPofinCase_CategorySelector categorySelector;
		[SerializeField]
		private UIPofinCase_TasteLump tasteLump;
		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private UIText subText;
		[SerializeField]
		private GameObject noDataTextObject;
		[SerializeField]
		private GameObject[] noDataDisableObjects;

		private PokemonParam selectedPokemonParam;
		private Action<ConditionParam> onResultCallback;
		private PoffinResult.SheetSheet1[] poffinResultDatas;
		private PoffinData[] poffinDatas;
		private int selectedIndex;
		public int selectPartyIndex = -1;
		private float scrollPos;
		private UIPofinCase_ItemButton currentItemButton;
		private MessageMsgFile poffinMainMsgFile;
		private Coroutine removeNewIconCoroutine;
		private Demo_ModelViewer poffin3DModel;
		public ConditionParam conditionParam;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		public void Open(PokemonParam pokemonParam, Action<ConditionParam> onResult, UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		public void InputUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void ReloadScrollView(int selectIndex = 0, float scrollPos = 0.0f) { }
		
		// TODO
		private void SetNoDataDisableObject(bool isActive) { }
		
		// TODO
		private void SetTaste(PoffinData poffinData) { }
		
		// TODO
		private void ShowItemContextMenu() { }
		
		// TODO
		private void DropPoffin(PoffinData poffinData) { }
		
		// TODO
		private IEnumerator LoadMD([Optional] Action onLoaded) { return default; }
		
		// TODO
		private string GetPoffinNameLabel(int mstId) { return default; }
		
		// TODO
		private string GetPoffinNameStr(int mstId) { return default; }
		
		// TODO
		private void SetupSubText(UIPofinCase_CategorySelector.Category category) { }
		
		// TODO
		private void PlayEatPoffinDemo(PokemonParam pokemonParam, PoffinData poffinData, [Optional] Action<ConditionParam> onComplete)
		{
			// TODO
			IEnumerator OnPreEnd() { return default; }
        }
		
		// TODO
		private void OpenPokemonStatusWindow(PokemonParam pokemonParam, ConditionParam conditionParam, [Optional] Action onComplete) { }
		
		// TODO
		private IEnumerator SetupPoffin3D([Optional] Action onComplete) { return default; }
		
		// TODO
		private void LoadPoffin3DModel(PoffinData data) { }
		
		private void HidePoffin3DModel()
		{
			this.poffin3DModel.ChangeModel(StringLiteral_398,1);
		}
	}
}