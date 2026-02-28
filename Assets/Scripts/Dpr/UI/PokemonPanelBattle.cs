using Dpr.Battle.Logic;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonPanelBattle : MonoBehaviour
	{
		[SerializeField]
		private UIText _state;
		[SerializeField]
		private RectTransform _infoRoot;
		[SerializeField]
		private TypePanel[] _types;
		[SerializeField]
		private RectTransform _contents;
		[SerializeField]
		private PokemonBattleWazaItem _itemPrefab;
		[SerializeField]
		private Cursor _cursor;
		[SerializeField]
		private DetailParam _detail;
		[SerializeField]
		private TokuseiDetailParam _tokuseiDetail;
		[SerializeField]
		private MultiTrainerParam _multiTrainer;

		private List<PokemonBattleWazaItem> _items = new List<PokemonBattleWazaItem>();
		private int _selectIndex;
		private bool _showDetail;
		private VerticalLayoutGroup _verticalLayoutGroup;
		private BTL_POKEPARAM _battlePokemonParam;
		private bool _isActived = true;
		
		public BTL_POKEPARAM CurrentBTLParam { get => _battlePokemonParam; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void Setup(BTL_POKEPARAM battlePokemonParam, bool isWait, bool isMultiPlayer) { }
		
		public void UpdateState(BTL_POKEPARAM bpp, bool isWait)
		{
			var uVar1 = GetSelectStateLabel(bpp,(isWait ? 1 : 0) & 1);
			this._state.SetupMessage(0,uVar1);
		}
		
		// TODO
		private string GetSelectStateLabel(BTL_POKEPARAM bpp, bool isWait) { return default; }
		
		// TODO
		private void SetupItems() { }
		
		// TODO
		private void ShowWazaDetail(bool enabled) { }
		
		// TODO
		private void SetupDetail() { }
		
		public void SetActive(bool enabled)
		{
			enabled = (enabled ? 1 : 0) & 1;
			this._cursor.SetActive(enabled);
			this._isActived = enabled;
			ShowWazaDetail(enabled);
		}
		
		public bool OnUpdate(float deltaTime, UIInputController input)
		{
			var uVar1 = this.gameObject;
			var uVar2 = uVar1.activeSelf;
			if (((uVar2 & 1) != 0) && (this._isActived)) {
			  uVar1 = UpdateSelect(deltaTime);
			  return uVar1;
			}
			return false;
		}
		
		// TODO
		private bool UpdateSelect(float deltaTime, UIInputController input) { return default; }
		
		// TODO
		private bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return default; }

		[Serializable]
		private class DetailParam
		{
			public RectTransform root;
			public Image category;
			public UIText power;
			public UIText hitRate;
			public UIText description;
		}

		[Serializable]
		private class TokuseiDetailParam
		{
			public RectTransform root;
			public UIText tokuseiName;
			public UIText tokuseiDescription;
		}

		[Serializable]
		private class MultiTrainerParam
		{
			public RectTransform root;
			public UIText trainerName;
			public Image bg;
			public Sprite[] sprites;
		}
	}
}