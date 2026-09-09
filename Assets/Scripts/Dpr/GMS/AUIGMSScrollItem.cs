using Dpr.UI;
using UnityEngine;

namespace Dpr.GMS
{
	public abstract class AUIGMSScrollItem : MonoBehaviour, IUIButton
	{
		protected RectTransform rectTransform;
		protected int currentIndex;
		
		// TODO
		public bool GetActive() { return default; }
		
		public int GetIndex() {
		    return currentIndex;
		}
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		public void SetIndex(int index) {
		    this.currentIndex = index;
		}
		
		// TODO
		public void Select() { }

		// TODO
		protected abstract void OnSelect();
		
		// TODO
		public void UnSelect() { }

		// TODO
		protected abstract void OnUnSelect();
	}
}