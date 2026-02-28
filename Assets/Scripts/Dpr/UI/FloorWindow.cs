using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class FloorWindow : UIWindow
	{
		[SerializeField]
		private UIText _number;
		
		public override void OnCreate()
		{
			UIWindow.OnCreate();
			var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
			                  (this,1);
			this._animator = uVar1;
		}
		
		// TODO
		public void Open(FLOOR_DISPLAY floorId, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(FLOOR_DISPLAY floorId, UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
	}
}