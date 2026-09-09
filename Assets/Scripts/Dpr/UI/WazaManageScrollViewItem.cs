using Pml;
using Pml.PokePara;
using UnityEngine;

namespace Dpr.UI
{
	public class WazaManageScrollViewItem : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private PokemonStatusWazaItem pokemonStatusWazaItem;
		[SerializeField]
		private RectTransform cursorRectTransform;

		private int index;
		private RectTransform rectTransform;
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		public int GetIndex() {
		    return index;
		}
		
		public void SetIndex(int index) {
		    this.index = index;
		}
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public void Select() { }
		
		// TODO
		public void UnSelect() { }
		
		// TODO
		public void Setup(PokemonParam pokemonParam, int wazaIndex, bool isContest = false) { }
		
		// TODO
		public void Setup(WazaNo wazaNo, bool isNew, bool isContest = false) { }
		
		// TODO
		public RectTransform GetCursorTransform() { return default; }
	}
}