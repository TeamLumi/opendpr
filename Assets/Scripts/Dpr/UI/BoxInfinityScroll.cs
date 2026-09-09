using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	[RequireComponent(typeof(ScrollRect))]
	public class BoxInfinityScroll : MonoBehaviour
	{
		[SerializeField]
		private BoxInfinityScrollItem _prefab;
		private int _showItemNum = 1;
		private int _outsideItemNum = 1;
		private ScrollRect _scrollRect;
		private HorizontalOrVerticalLayoutGroup _layoutGroup;
		private List<BoxInfinityScrollItem.BaseParam> _params;
		private int _itemNum;
		private int _paramIndex;
		private bool _isMoving;
		private bool _isTeam;
		public UnityAction<BoxInfinityScrollItem> onSelectChanged;
		
		public List<BoxInfinityScrollItem.BaseParam> baseParams { get => _params; }
		public bool IsMoving { get => _isMoving; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public IEnumerator OpSetup(List<BoxInfinityScrollItem.BaseParam> baseParams) { return default; }
		
		// TODO
		private void SetParamIndex(int index) { }
		
		public int GetParamIndex() {
		    return _paramIndex;
		}
		
		// TODO
		private BoxInfinityScrollItem.BaseParam GetParam(int index) { return default; }
		
		// TODO
		private void SetupItem(int itemIndex, BoxInfinityScrollItem.BaseParam param) { }
		
		// TODO
		public void Apply(int index, List<int> hideIndexes, BoxWindow.OpenParam openParam, [Optional] BoxWindow.SEARCH_DATA searchData, [Optional] List<BoxWindow.SelectedPokemon> selected) { }
		
		// TODO
		public void SetSelect(int index, List<int> selectIndexes) { }
		
		// TODO
		public void Move(int offset, [Optional] UnityAction callback) { }
		
		// TODO
		public void Jump(int paramIndex) { }
		
		// TODO
		public void SetDisplayMode(BoxWindow.DisplayMode mode) { }
		
		// TODO
		private float GetScrollPosition() { return default; }
		
		// TODO
		private void SetScrollPosition(float spos) { }
	}
}