using Audio;
using Dpr.Contest;
using Dpr.EvScript;
using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class UIContCapsuleSelect : UIWindow, IContestUIWindow
	{
		[SerializeField]
		private MenuHeader _header;
		[SerializeField]
		private UIScrollView _capsuleScrollView;
		[SerializeField]
		private CapsuleViewController _capsuleViewController;
		[SerializeField]
		private Cursor _cursor;
		[SerializeField]
		private RectTransform bgParent;
		[SerializeField]
		private RectTransform bgRectTransform;

		private CapsuleInfo[] _capsuleInfos;
		private PokemonParam[] _attachPokemonParamArray;
		private int[] _attachTrays;
		private int[] _attachPositions;
		private CapsuleItemButton _selectedCapsuleItemButton;
		private AudioManager audioManagerPtr;
		private KeyGuideCreater _keyGuide = new KeyGuideCreater();
		private EvWork.WORK_INDEX _resultWorkIndex;
		private ContestMenuEventID _resultEventID = ContestMenuEventID.None;
		private float _currentScrollPosition;
		private int _currentSelectIndex;
		private int _startSelectIndex;
		private bool _bIsOpen;
		private bool _bIsOpening;
		private bool _bIsMultiMode;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		private void CreateCapsuleInfos() { }
		
		// TODO
		public void OpenSingleMode(int resultTemp, UIWindowID prevWindowId) { }
		
		// TODO
		public void OpenMultiMode(UIWindowID prevWindowID, string minutStr, string secondStr) { }
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId)
		{
			IEnumerator Init() { return default; }

			return default;
        }
		
		public bool IsOpen { get => _bIsOpen; }
		public ContestMenuEventID ResultEventID { get => _resultEventID; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateInputSelect() { }
		
		// TODO
		private void UpdateInputAction() { }
		
		// TODO
		private void UpdateInputRot() { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnReverseCapsule2D() { }
		
		// TODO
		private void SetupCapsuleView() { }
		
		// TODO
		public void CloseWindow() { }
		
		// TODO
		private IEnumerator OpClose() { return default; }
		
		// TODO
		private void OnClose() { }
		
		public void SetTimeCount(string minutStr, string secondStr)
		{
			this._header.SetTime(minutStr,secondStr);
		}
		
		// TODO
		private void ResetContestParam() { }
	}
}