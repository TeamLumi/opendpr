using Dpr.SubContents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class UIBattleMatchingPokemonSelect : UIWindow
	{
		[SerializeField]
		private UIBattleMatchingTimer _timer;
		[SerializeField]
		private UIBattleMatchingTeamPlate _teamPlate;
		[SerializeField]
		private PokemonParty _pokemonParty;
		[SerializeField]
		private UIBattleMatchingPokemonItem[] _pokemonItems;
		[SerializeField]
		private RectTransform _decide;
		[SerializeField]
		private Cursor _cursor;

		private PokemonStatusWindow _pokemonStatusUI;
		private UIBattleMatchingTeamSelect _teamSelectUI;
		private ContextMenuWindow _contextMenu;
		private Action _onDecide;
		private Action _onCancel;
		private Action _onUpdateTimer;
		private bool _isBattleTower;
		private bool _decideFade = true;
		private bool _isOpeningStatus;
		private bool _isOpeningTeam;
		private int _currentIndex;
		private int _maxIndex;
		private int _requiredNumMin;
		private int _requiredNumMax;
		private List<int> _joinIndexList = new List<int>();
		private bool _isOpeningMessage;
		private ShowMessageWindow _msgWindow = new ShowMessageWindow();

		private readonly Vector2 MSG_WINDOW_ANCHOR_POS = new Vector2(15.0f, 110.0f);
		
		public Action onUpdateTimer { set => _onUpdateTimer = value; }
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Action onDecide, [Optional] Action onCancel, bool battleTower = false, bool decideFade = false, UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void PreClose() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public IEnumerator OpClose() { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		public void RemainingWarningText(bool warning = true) { }
		
		// TODO
		public void UpdateUITimeText(string minutes, string seconds) { }
		
		// TODO
		public void TimeUp() { }
		
		// TODO
		private bool UpdateSelect(float deltaTime) { return default; }
		
		// TODO
		private bool SetSelectIndex(int selectIndex) { return default; }
		
		// TODO
		private void SelectComplete(bool complete) { }
		
		private void SetCursorDecide(bool decide)
		{
			if (decide) {
			  this._cursor.SetActive(1);
			}
			GameObject.SetActive(this._cursor.gameObject,0,0);
		}
		
		// TODO
		private void OpenContextMenu() { }
		
		// TODO
		private void SetContextMenuPositionParams(ContextMenuWindow.Param param, RectTransform transPartyItem, int selectIndex, float posZ) { }
		
		// TODO
		private void SetNumber() { }
		
		// TODO
		private void OpenKeyguide() { }
		
		// TODO
		public void CloseKeyGuide() { }
	}
}