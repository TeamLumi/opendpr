using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class MoneyWindow : UIWindow
	{
		[SerializeField]
		private UIText _money;
		private int _prevMoney = -1;
		
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
		private void SetupMoney(bool isInitialized = false) { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
	}
}