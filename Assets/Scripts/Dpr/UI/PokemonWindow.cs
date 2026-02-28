using Pml;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class PokemonWindow : PokemonWindowBase
	{
		[SerializeField]
		private PokemonModelView _modelView;
		[SerializeField]
		private RectTransform _gotoBox;

		private WazaNo _fieldWazaNo;
		private PokemonPartyItem _fieldWazaPartyItem;
		private bool _isFieldWazaExecuting;
		private bool _itemSwapSelect;
		private int _checkFormChangeCount;
		private Coroutine _coroutineFormChangeLoadModel;
		private Param _param;
		
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
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		private bool IsFieldWazaSelectMode()
		{
			return (int)this._fieldWazaNo != 0;
		}
		
		private bool IsSwapMode()
		{
			if (((this._party.IsSwapMode() & 1) == 0) && (!this._itemSwapSelect)) {
			  return false;
			}
			return true;
		}
		
		// TODO
		private bool IsEnableBox() { return default; }
		
		// TODO
		private void OnSelectChangedPartyItem(PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void SetupKeyguide() { }
		
		// TODO
		private bool HasItemByParty() { return default; }
		
		// TODO
		private void SetupModelView(PokemonParam pokemonParam) { }
		
		// TODO
		private void OnClickPartyItem(PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void ShowPartyItemName(bool enabled) { }
		
		// TODO
		private void OpenContextMenu(PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void FieldWaza(WazaNo fieldWazaNo, PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void OpenBagWindow(UIBag.ModeType modeType, PokemonParam selectPokemonParam) { }
		
		// TODO
		private void GiveItem(bool isChain)
		{
			// TODO
			void NextChainItemSwap() { }
        }
		
		// TODO
		private void PokemonSwap() { }
		
		// TODO
		private void SelectPokemonByFieldWaza(WazaNo wazaNo, PokemonPartyItem partyItem) { }
		
		// TODO
		private void UseFieldWaza(PokemonPartyItem partyItem)
		{
			// TODO
			void OnCompleteUpdateHp() { }
        }
		
		// TODO
		private void CheckFormChange(PokemonPartyItem pokemonPartyItem, [Optional] UnityAction onComplete)
		{
			// TODO
            IEnumerator LoadModel() { return default; }
        }
		
		// TODO
		private void SetInputEnable(bool enable) { }
		
		// TODO
		public PokemonWindow() { }

		public class Param : BaseParam
		{
			// TODO
			public Param() { }
		}
	}
}