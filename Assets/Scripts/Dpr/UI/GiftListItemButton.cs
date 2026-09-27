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
			return index;
		}
		
		public void SetIndex(int index)
		{
			this.index = index;
		}
		
		public RectTransform GetRectTransform()
		{
			if (rectTransform == null)
				rectTransform = transform as RectTransform;

			return rectTransform;
		}
		
		public bool GetActive()
		{
			return gameObject.activeSelf;
		}
		
		public void SetActive(bool isActive)
		{
			gameObject.SetActive(isActive);
		}
		
		public void Select()
		{
			activeObject.SetActive(true);
			disableObject.SetActive(false);
		}
		
		public void UnSelect()
		{
			activeObject.SetActive(false);
			disableObject.SetActive(true);
		}
		
		public void Set(RecvData data)
		{
			GiftMessageUtility.SetTitleText(data, new UIText[] { activeNameText, disableNameText });
		}
	}
}