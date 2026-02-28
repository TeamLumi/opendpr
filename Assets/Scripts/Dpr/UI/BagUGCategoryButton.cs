using Dpr.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BagUGCategoryButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private Image newIconImage;
		[SerializeField]
		private GameObject unselectObject;
		[SerializeField]
		private GameObject selectObject;
		[SerializeField]
		private UgItemInfo.CategoryType categoryType;

		private int index;
		private RectTransform rectTransform;
		
		public UgItemInfo.CategoryType CategoryType { get => categoryType; }
		
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
			this.unselectObject.SetActive(0);
			this.selectObject.SetActive(1);
		}
		
		public void UnSelect()
		{
			this.unselectObject.SetActive(1);
			this.selectObject.SetActive(0);
		}
		
		public void SetNewIconEnable(bool isEnable)
		{
			this.newIconImage.enabled = (isEnable ? 1 : 0) & 1;
		}
	}
}