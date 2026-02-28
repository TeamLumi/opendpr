using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIBrowsingPointDataItem : AUIGMSScrollItem
	{
		[SerializeField]
		private Image monsIconImage;
		[SerializeField]
		private Image selectBGImage;
		[SerializeField]
		private Image newIconImage;
		[SerializeField]
		private UIText iconTitleText;
		[SerializeField]
		private UIText monsNameText;
		
		// TODO
		public void ShowPointDataItem(string pointTitle, string monsName, Sprite monsIconSpr, bool isNew) { }
		
		// TODO
		public void ShowEmptyPointDataItem(string pointTitle, string nameText) { }
		
		// TODO
		private void SetPointTitleStr(string title) { }
		
		// TODO
		private void SetNameText(string name) { }
		
		// TODO
		private void SetMonsIconSpr(Sprite monsIconSpr) { }
		
		// TODO
		private void SetTextColor(Color color) { }
		
		public void SetNewImageEnabled(bool enabled)
		{
			if (((this.newIconImage.enabled ^ enabled) & 1) != 0) {
			  this.newIconImage.enabled = (enabled ? 1 : 0) & 1;
			}
		}
		
		// TODO
		protected override void OnSelect() { }
		
		// TODO
		protected override void OnUnSelect() { }
	}
}