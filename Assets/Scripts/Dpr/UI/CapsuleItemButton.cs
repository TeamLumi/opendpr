using UnityEngine;

namespace Dpr.UI
{
	public class CapsuleItemButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private PokemonIcon pokemonIcon;
		[SerializeField]
		private GameObject swapSelectedObject;
		[SerializeField]
		private GameObject contextOpenObject;
		[SerializeField]
		private GameObject onSealObject;
		[SerializeField]
		private GameObject onNotSelectableObject;

		private int index;
		private RectTransform rectTransform;
		private CapsuleInfo info;
		
		public int GetIndex() {
		    return index;
		}
		
		public void SetIndex(int index) {
		    this.index = index;
		}
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Select() { }
		
		// TODO
		public void UnSelect() { }
		
		// TODO
		public void SetInfo(CapsuleInfo info) { }
		
		public CapsuleInfo GetInfo() {
		    return info;
		}
		
		// TODO
		public void OnSwapStart() { }
		
		// TODO
		public void OnSwapEnd() { }
		
		// TODO
		public void OnNotSelectable() { }
		
		// TODO
		public void OnContextMenuOpen() { }
		
		// TODO
		public void OnContextMenuClose() { }
	}
}