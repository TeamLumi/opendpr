using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIBrowsingPointHistoryDataItem : AUIGMSScrollItem
	{
		[SerializeField]
		private Image selectBGImage;
		[SerializeField]
		private Image sendMonsIconImage;
		[SerializeField]
		private Image receiveMonsIconImage;
		[SerializeField]
		private Image receiveSexIconImage;
		[SerializeField]
		private Image receiveMonsLanguageImage;
		[SerializeField]
		private Image receiveMonsParentLanguageImage;
		[SerializeField]
		private Image newIconImage;
		[SerializeField]
		private UIText historyTitleText;
		[SerializeField]
		private UIText receiveMonsNicknameText;
		[SerializeField]
		private UIText receiveMonsParentNameText;
		
		// TODO
		public void ShowHistoryDataItem(string title, string monsNickname, string parentName, Sprite sendMonsIconSpr, Sprite receiveMonsIconSpr, Sprite receiveSexIconSpr, Sprite receiveMonsLanguageSpr, Sprite receiveParentLanguageSpr, bool isNew) { }
		
		// TODO
		public void ShowEmptyDataItem(string emptyStr) { }
		
		private void SetNewImageEnabled(bool enabled)
		{
			if (((this.newIconImage.enabled ^ enabled) & 1) != 0) {
			  this.newIconImage.enabled = (enabled ? 1 : 0) & 1;
			}
		}
		
		// TODO
		private void SetSprite(Image target, Sprite spr) { }
		
		// TODO
		protected override void OnSelect() { }
		
		// TODO
		protected override void OnUnSelect() { }
		
		// TODO
		private void SetTextColor(Color color) { }
	}
}