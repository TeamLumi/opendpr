using Dpr.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BagItemButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private Image iconImage;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private Image newIconImage;
		[SerializeField]
		private Image favoriteIconImage;
		[SerializeField]
		private UIText stockCountLabelText;
		[SerializeField]
		private UIText stockCountValueText;
		[SerializeField]
		private Image registerButtonImage;
		[SerializeField]
		private Sprite[] shortcutButonSprites;

		private int index;
		private RectTransform rectTransform;
		private ItemInfo item;
		
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
		public void SetInfo(ItemInfo item) { }
		
		public ItemInfo GetInfo() {
		    return item;
		}
		
		// TODO
		public void SwitchFavorite() { }
		
		// TODO
		public void RemoveNew() { }
		
		// TODO
		private void UpdateNew() { }
		
		// TODO
		private void UpdateFavorite() { }
		
		// TODO
		private void UpdateRegisterButton() { }
		
		// TODO
		public void UpdateStockCount() { }
		
		// TODO
		public void SetTextColor(Color color) { }
		
		// TODO
		public void SetIconColor(Color color) { }
	}
}