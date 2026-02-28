using Audio;
using DPData;
using Dpr.MsgWindow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SettingWindow : UIWindow
	{
		[SerializeField]
		private Cursor _cursor;
		[SerializeField]
		private ScrollRect _scrollRect;
		[SerializeField]
		private int _viewMenuItemNum = 7;
		[SerializeField]
		private RectTransform _messageWindowRoot;
		private int _selectIndex;
		private List<SettingMenuItem> _activeItems = new List<SettingMenuItem>();
		private int _scrollIndex;
		private CONFIG _tempConfig;
		private AudioInstance _voiceInstance;
		
		public override void OnCreate()
		{
			UIWindow.OnCreate();
			var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
			                  (this,1);
			this._animator = uVar1;
		}
		
		// TODO
		public void Open(UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void OnMenuItemValueChaged(SettingMenuItem menuItem) { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void RevertSettings() { }
		
		// TODO
		private void InitializeSettings() { }
		
		// TODO
		private void AcceptSettings() { }
		
		// TODO
		protected override void OpenMessageWindow(MsgWindowParam messageParam) { }
		
		// TODO
		protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }
		
		// TODO
		private bool UpdateSelect(float deltaTime) { return default; }
		
		// TODO
		private bool UpdateSelectValue(float deltaTime) { return default; }
		
		// TODO
		private bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return default; }
		
		// TODO
		private void SetDucking(ConfigID configId = (ConfigID)(-1)) { }
		
		// TODO
		private bool SetSelectValue(int selectValue) { return default; }
		
		// TODO
		private void OpenDescriptionMessageWindow() { }
		
		// TODO
		private void SetupScrollPosition() { }
	}
}