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
		
		public int GetIndex()
		{
			return this.index;
		}
		
		public void SetIndex(int index)
		{
			this.index = index;
		}
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		public void Select()
		{
			this.activeObject.SetActive(1);
			this.disableObject.SetActive(0);
		}
		
		public void UnSelect()
		{
			this.activeObject.SetActive(0);
			this.disableObject.SetActive(1);
		}
		
		// TODO
		public void Set(RecvData data) { }
	}
}