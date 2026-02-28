using DPData;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIPofinCase_ItemButton : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private UIText levelText;
		[SerializeField]
		private Image newImage;

		private int index;
		
		public PoffinData Data { get; private set; }
		
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
		
		// TODO
		public void Select() { }
		
		// TODO
		public void UnSelect() { }
		
		// TODO
		public void Setup(PoffinData data, string poffinName) { }
		
		public void SetNewIconEnable(bool isEnable)
		{
			this.newImage.enabled = (isEnable ? 1 : 0) & 1;
		}
	}
}