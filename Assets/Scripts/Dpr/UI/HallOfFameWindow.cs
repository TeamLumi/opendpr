using Audio;
using DPData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
	public class HallOfFameWindow : UIWindow
	{
		[SerializeField]
		private Image[] _arrows;
		[SerializeField]
		private UIText _number;
		[SerializeField]
		private UIText _date;
		[SerializeField]
		private RectTransform contentRoot;
		[SerializeField]
		private Image _cursor;

		private List<HallOfFameParam> _params = new List<HallOfFameParam>();
		private int _paramIndex;
		private int _selectIndex;

		private const int _delayFrameNum = 4;

		private int _delayFrameCount = -1;

		private const int _columnMax = 3;

		private int _infoType;
		private AudioInstance _voiceInstance;
		
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
		private void SetupKeyguide() { }
		
		private void UpdateItems()
		{
			if ((-1 < this._delayFrameCount) && (this._delayFrameCount = this._delayFrameCount + -1, this._delayFrameCount == 0)) {
			  SetupItems();
			}
		}
		
		// TODO
		private void SetupItems() { }
		
		// TODO
		private void SetItemInfos(int infoType) { }
		
		// TODO
		private void SetupTitle() { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private bool UpdateSelectParam() { return default; }
		
		private bool SetParamIndex(int selectIndex, int move, bool isInitialize = false)
		{
			if ((!isInitialize) && (this._paramIndex == selectIndex)) {
			  return false;
			}
			this._paramIndex = selectIndex;
			this._delayFrameCount = 4;
			PlayAnimArrow(move);
			SetupTitle();
			return true;
		}
		
		// TODO
		private void PlayAnimArrow(int move) { }
		
		// TODO
		private bool UpdateSelect() { return default; }
		
		// TODO
		private bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return default; }
		
		// TODO
		private void PlayVoice(UIDatabase.SheetPokemonVoice voiceData) { }
		
		// TODO
		private HallOfFameItem GetItem(int selectIndex) { return default; }

		private class HallOfFameParam
		{
			public int number = -1;
			public DENDOU_RECORD record;
			public RE_DENDOU_RECORD rename_record;
			public DENDOU_SAVE_ADD_POKE_MEMBER add_record;
			public List<HallOfFameItem> items = new List<HallOfFameItem>();
		}

		public class Param
		{
			public int dummy;
		}
	}
}