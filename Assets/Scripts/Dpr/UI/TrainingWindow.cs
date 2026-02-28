using Pml;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class TrainingWindow : UIWindow
	{
		[SerializeField]
		private UIText _itemName;
		[SerializeField]
		private UIText _itemRemainNum;
		[SerializeField]
		private UIText _itemNum;
		[SerializeField]
		private RectTransform _contentRoot;

		private List<TrainingItemBase> _items = new List<TrainingItemBase>();
		private int _itemCount;
		private int _itemRemainCount;
		private int _selectIndex;
		private bool _isDoneTraining;
		private Param _param;
		
		public bool isDoneTraining { get => _isDoneTraining; }
		
		public override void OnCreate()
		{
			UIWindow.OnCreate();
			var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
			                  (this,1);
			this._animator = uVar1;
		}
		
		// TODO
		public void Open(Param param, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void SetRemainItemNum(int remainCount) { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void CheckItem(TrainingItemBase itemBase) { }
		
		// TODO
		private void EnableStart(bool enabled) { }
		
		// TODO
		private void StartTraining() { }
		
		// TODO
		private bool UpdateSelect(float deltaTime) { return default; }
		
		// TODO
		private bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return default; }

		private enum ItemType : int
		{
			HP = 0,
			ATK = 1,
			DEF = 2,
			SPATK = 3,
			SPDEF = 4,
			AGI = 5,
			START = 6,
		}

		public class Param
		{
			public PokemonParam pokemonParam;
			public ItemNo itemNo = ItemNo.GINNOOUKAN;
		}
	}
}