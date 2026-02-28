using Dpr.Contest;
using Dpr.EvScript;
using Dpr.MsgWindow;
using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class UIContPokeSelect : UIWindow, IContestUIWindow
	{
		[SerializeField]
		private MenuHeader _header;
		[SerializeField]
		private PokemonModelView _modelView;
		[SerializeField]
		private PokemonParty _uiPokeParty;
		[SerializeField]
		private ConditionRaderChart _rader;
		[SerializeField]
		private ConditionFur _uiConditionFur;

		private KeyGuideCreater _keyGuide = new KeyGuideCreater();
		private EvWork.WORK_INDEX _resultWorkIndex;
		private ContestMenuEventID _resultEventID = ContestMenuEventID.None;
		private MsgWindowParam msgWindowParam = new MsgWindowParam();
		private MsgWindow.MsgWindow msgWindowPtr;
		private uint startSelectIndex;
		private bool _bInputed;
		private bool _bIsOpen;
		private bool _bIsOpening;
		private bool _bIsMulti;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		private void SetErrorMsgParam() { }
		
		public bool IsOpen { get => _bIsOpen; }
		public ContestMenuEventID ResultEventID { get => _resultEventID; }
		
		// TODO
		public void OpenSingleMode(int resultWorkIndex, UIWindowID prevWindowId) { }
		
		// TODO
		public void OpenMultiMode(UIWindowID prevWindowId, string minutStr, string secondStr) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
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
		
		// TODO
		private void UpdateInpuInOpenWindow() { }
		
		// TODO
		public void CloseWindow() { }
		
		// TODO
		private void CloseSingleMode() { }
		
		// TODO
		private IEnumerator TransitionSelectContestWazaMenu() { return default; }
		
		// TODO
		private void CloseMultiMode() { }
		
		// TODO
		private IEnumerator OpClose() { return default; }
		
		// TODO
		private void ClosedMenu() { }
		
		public void SetTimeCount(string minutStr, string secondStr)
		{
			this._header.SetTime(minutStr,secondStr);
		}
		
		// TODO
		private void ResetContestParam() { }
	}
}