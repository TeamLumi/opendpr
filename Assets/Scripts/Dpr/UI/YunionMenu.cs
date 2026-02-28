using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class YunionMenu : UIWindow
	{
		[SerializeField]
		private UIText _textTitle;
		[SerializeField]
		private GameObject _objNetMode;
		[SerializeField]
		private Cursor _cursorNetMode;
		[SerializeField]
		private GameObject _objEnterMode;
		[SerializeField]
		private MultiModelView _modelView;

		private OpenMenuType _currentMenu;
		private OpenMenuType _currentSelect;
		private bool _loadingModel;

		private const int CURSOR_POS = 295;
		private const string MODEL_PATH = "persons/field/fc2012_00";
		private const string MSG_FILE = "dlp_net_union_room";
		private const string MSG_LABEL_UNION = "DLP_net_union_room_111";
		private const string MSG_LABEL_COMMUNITY = "DLP_net_union_room_106";
		private const string MSG_LABEL_GLOBAL = "DLP_net_union_room_107";
		private const string SCRIPT_COMMUNITY = "ev_connect_union_ymenu";
		private const string SCRIPT_GLOBAL = "ev_connect_global_ymenu";
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(bool cancel) { }
		
		// TODO
		public IEnumerator OpCloseCancel() { return default; }
		
		// TODO
		public IEnumerator OpClose() { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void ChangeMenu(OpenMenuType type) { }
		
		// TODO
		private void SelectMenu() { }
		
		// TODO
		public void OpenKeyguide() { }
		
		// TODO
		public void CloseKeyGuide([Optional] Action onComplete) { }
		
		// TODO
		private void SetTitle() { }
		
		// TODO
		private void SetSelect(OpenMenuType type) { }
		
		private void SetCursor()
		{
			var uVar1 = 0xc3938000;
			if ((int)this._currentSelect != 1) {
			  uVar1 = 0x43938000;
			}
			this._cursorNetMode.transform = Transform.get_parent(Component.get_transform(this._cursorNetMode),0);
			this._cursorNetMode.transform = UnityEngine_Component__GetComponent<object>
			                  (this._cursorNetMode.transform);
			ExtensionMethods.SetLocalPositionX(uVar1,this._cursorNetMode.transform,0);
		}
		
		// TODO
		private void LoadModel() { }
		
		private void UnloadModel()
		{
			this._modelView.DestroyModel(0);
		}

		private enum OpenMenuType : int
		{
			SelectRoom = 0,
			CommunityRoom = 1,
			GlobalRoom = 2,
		}
	}
}