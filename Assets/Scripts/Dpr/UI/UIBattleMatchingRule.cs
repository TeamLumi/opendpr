using Dpr.BattleMatching;
using Dpr.Message;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class UIBattleMatchingRule : MonoBehaviour
	{
		[SerializeField]
		private UIText _textTitle;
		[SerializeField]
		private WindowItemSelector[] _categories;
		[SerializeField]
		private WindowItemButton _decide;
		[SerializeField]
		private RectTransform _cursor;
		[SerializeField]
		private Cursor _cursorFrame;
		[SerializeField]
		private GameObject _cursorArrows;

		private MessageMsgFile _msgFile;
		private int _currentIndex;
		private List<int> _currentIndexList;
		private Dictionary<PokemonNum, string> _pokemonNumList;
		private Dictionary<Regulation.LevelRangeType, string> _pokemonLevelList;
		private List<string> _legendPokemonList;
		private List<string> _samePokemonList;
		private List<string> _sameItemList;
		
		// TODO
		public void OpenRuleWindow() { }
		
		// TODO
		public void CloseRuleWindow() { }
		
		// TODO
		public void OpenSelectRuleWindow() { }
		
		// TODO
		public void OnMoveX(bool left) { }
		
		// TODO
		public void OnMoveY(bool up) { }
		
		// TODO
		public bool OnDecide() { return default; }
		
		// TODO
		private void SetTitle(bool select = false) { }
		
		// TODO
		private void SetDecide(bool select = false) { }
		
		// TODO
		private string GetNameStr(int no) { return default; }
		
		// TODO
		private string GetFormattedStr(int no) { return default; }
		
		// TODO
		private string GetNumStr(PokemonNum num) { return default; }
		
		private void SetCursorAnchor(RectTransform rectTr)
		{
			ExtensionMethods.SetActive(this._cursor,1);
			rectTr.anchorMin;
			this._cursor.set_anchorMin();
			rectTr.anchorMax;
			this._cursor.set_anchorMax();
			rectTr.pivot;
			this._cursor.set_pivot();
			rectTr.position;
			this._cursor.set_position();
			rectTr.sizeDelta;
			this._cursor.set_sizeDelta();
		}
	}
}