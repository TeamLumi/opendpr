using Dpr.Contest;
using Dpr.MsgWindow;
using Pml.PokePara;
using System;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class UIFureaiPokeSelect : UIWindow
	{
		[SerializeField]
		private MenuHeader _header;
		[SerializeField]
		private PokemonModelView _modelView;
		[SerializeField]
		private PokemonParty _uiPokeParty;

		private KeyGuideCreater _keyGuide = new KeyGuideCreater();
		private ContestMenuEventID _resultEventID = ContestMenuEventID.None;
		private MsgWindowParam msgWindowParam = new MsgWindowParam();
		private MsgWindow.MsgWindow msgWindowPtr;
		private bool _bInputed;
		private bool _showModel;
		public Action<int> GetTemotiNo;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		private void SetErrorMsgParam(bool isEgg) { }
		
		// TODO
		public void Open(int resultWorkIndex) { }
		
		// TODO
		private IEnumerator OpOpen() { return default; }
		
		// TODO
		private void ResetContestParam() { }
		
		// TODO
		private PokemonParty.Param CreatePokemonPartyParam() { return default; }
		
		// TODO
		private void OnClickPartyItem(PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void OnChangedPartyItem(PokemonPartyItem partyItem, int selectIndex) { }
		
		// TODO
		private void UpdatePokemonStatus(PokemonParam selectPokemonParam) { }
		
		// TODO
		private void SetupModelView(PokemonParam pokemonParam) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateInput() { }
		
		private void OpenMsgWindow()
		{
			this.msgWindowPtr = MsgWindowManager.OpenMsg(this.msgWindowParam);
		}
		
		// TODO
		private void UpdateInpuInOpenWindow() { }
		
		// TODO
		private void CloseWindow(int selectIndex) { }
		
		// TODO
		private IEnumerator OpClose() { return default; }
		
		// TODO
		private void ClosedMenu() { }
	}
}