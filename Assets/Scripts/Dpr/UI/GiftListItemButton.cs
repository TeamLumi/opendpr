using DPData.MysteryGift;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftListItemButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private UIText activeNameText;
		[SerializeField]
		private UIText disableNameText;
		[SerializeField]
		private GameObject activeObject;
		[SerializeField]
		private GameObject disableObject;

		private int index;
		private RectTransform rectTransform;
		
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
		public void Set(RecvData data) { }
	}
}