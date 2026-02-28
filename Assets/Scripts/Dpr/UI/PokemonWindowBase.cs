using Dpr.MsgWindow;
using UnityEngine;

namespace Dpr.UI
{
	public class PokemonWindowBase : UIWindow
	{
		[SerializeField]
		protected PokemonParty _party;
		[SerializeField]
		protected RectTransform _messageWindowRoot;
		
		public override void OnCreate()
		{
			UIWindow.OnCreate();
			var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
			                  (this,1);
			this._animator = uVar1;
		}
		
		// TODO
		public void SetContextMenuPositionParams(ContextMenuWindow.Param param, RectTransform transPartyItem, int selectIndex, float posZ) { }
		
		// TODO
		protected override void OpenMessageWindow(MsgWindowParam messageParam) { }

		public class BaseParam
		{
			public int selectIndex = -1;
		}
	}
}