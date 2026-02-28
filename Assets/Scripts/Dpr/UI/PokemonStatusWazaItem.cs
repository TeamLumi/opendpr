using Pml;
using Pml.PokePara;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusWazaItem : MonoBehaviour
	{
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText _pp;
		[SerializeField]
		private TypePanel _type;
		[SerializeField]
		private Condition _condition;
		[SerializeField]
		private Image _new;
		[SerializeField]
		private Image _imageBody;
		[SerializeField]
		private BodyParam[] _bodyParams;
		[SerializeField]
		private Color[] _ppColors;
		[SerializeField]
		private Cursor _cursorSwap;

		private int _wazaIndex;
		
		// TODO
		public int wazaIndex { get => _wazaIndex; }
		
		// TODO
		public void Setup(PokemonParam pokemonParam, int wazaIndex, bool isContest = false) { }
		
		// TODO
		private Color GetPpColor(int pp, int ppMax) { return default; }
		
		// TODO
		public void Setup(WazaNo wazaNo, bool isNew, bool isContest = false) { }
		
		// TODO
		public void EnableCondition(bool enabled) { }
		
		// TODO
		public void Select(bool enabled) { }
		
		public void EnableSwapMode(bool enabled)
		{
			GameObject.SetActive(this._cursorSwap.gameObject,(enabled ? 1 : 0) & 1,0);
		}
		
		// TODO
		public void SwapWazaIndex(PokemonParam pokemonParam, PokemonStatusWazaItem fromSwapItem) { }

		[Serializable]
		private class Condition
		{
			public RectTransform root;
			public Image plate;
			public UIText name;
		}

		[Serializable]
		private class BodyParam
		{
			public Sprite sprite;
			public Color nameColor = Color.white;
		}
	}
}