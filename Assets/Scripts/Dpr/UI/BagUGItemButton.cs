using Dpr.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BagUGItemButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private Image newIconImage;
		[SerializeField]
		private UIText stockCountValueText;

		private int index;
		private RectTransform rectTransform;
		private UgItemInfo item;
		
		public bool IsNull { get => item == null; }
		public bool IsNew { get => item.bIsNew; }
		
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
		public void Clear() { }
		
		// TODO
		public void SetInfo(UgItemInfo item) { }
		
		public UgItemInfo GetInfo() {
		    return item;
		}
		
		// TODO
		public void RemoveNew() { }
		
		// TODO
		private void UpdateNew() { }
		
		// TODO
		public void UpdateStockCount() { }
	}
}