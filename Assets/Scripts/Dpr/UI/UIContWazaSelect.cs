using Dpr.Contest;
using Dpr.EvScript;
using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class UIContWazaSelect : UIWindow, IContestUIWindow
	{
		[SerializeField]
		private MenuHeader _header;
		[SerializeField]
		private PokemonModelView _modelView;
		[SerializeField]
		private WazaManageWazaStatusPanel _wazaPanel;
		[SerializeField]
		private UIPokeStatusSelectPanel _uiPokeStatus;

		private KeyGuideCreater _keyGuide = new KeyGuideCreater();
		private EvWork.WORK_INDEX _resultWorkIndex;
		private ContestMenuEventID _resultEventID = ContestMenuEventID.None;
		private PokemonParam selectPokeParam;
		private byte _startSelectIndex;
		private bool _bInputed;
		private bool _bIsOpen;
		private bool _bIsOpening;
		private bool _bIsMultiMode;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(EvWork.WORK_INDEX resultWorkIndex, UIWindowID prevWindowID) { }
		
		// TODO
		public void OpenMultiMode(UIWindowID prevWindowID, string minutStr, string secondStr) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowID) { return default; }
		
		public bool IsOpen { get => _bIsOpen; }
		public ContestMenuEventID ResultEventID { get => _resultEventID; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateInput() { }
		
		private bool CheckValidContestWaza()
		{
			if (this.selectPokeParam != null) {
			  var uVar1 = Pml_PokePara_CoreParam__GetWazaNo
			                    (this.selectPokeParam,this._wazaPanel.selectIndex,0
			                    );
			  uVar1 = WazaDataSystem.IsValid(uVar1);
			  return uVar1;
			}
			ContestUtils.EmitLog(StringLiteral_11793,3);
			return false;
		}
		
		// TODO
		public void CloseWindow() { }
		
		// TODO
		private IEnumerator OpClose() { return default; }
		
		public void SetTimeCount(string minutStr, string secondStr)
		{
			this._header.SetTime(minutStr,secondStr);
		}
		
		// TODO
		private void ResetContestParam() { }
	}
}