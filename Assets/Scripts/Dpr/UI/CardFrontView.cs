using Dpr.Message;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class CardFrontView : MonoBehaviour
	{
		[SerializeField]
		private Image cardImage;
		[SerializeField]
		private Image titleImage;
		[SerializeField]
		private UIText numberText;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private UIText moneyText;
		[SerializeField]
		private UIText dexText;
		[SerializeField]
		private UIText playTimeText;
		[SerializeField]
		private UIText startTimeText;
		[SerializeField]
		private UIText clearTimeText;
		[SerializeField]
		private Image cover1Image;
		[SerializeField]
		private Image cover2Image;

		private int currentPlayTimeMinute;
		private bool isUpdatePlayTime;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Initialize(UICard.Param param) { }
		
		public void SetCardImageSprite(Sprite cardSprite, Sprite titleSprite, Sprite cover1Sprite, Sprite cover2Sprite)
		{
			this.cardImage.sprite = cardSprite;
			this.titleImage.sprite = titleSprite;
			this.cover1Image.sprite = cover1Sprite;
			this.cover2Image.sprite = cover2Sprite;
		}
		
		// TODO
		public void Show() { }
		
		// TODO
		public void Hide() { }
		
		public void OnUpdate(float deltaTime)
		{
			if (this.isUpdatePlayTime) {
			  UpdatePlayTimeText();
			}
		}
		
		// TODO
		public void SetText(uint id, PlayerNameData nameData, int money, int zukanCount, ushort playTimeHour, ushort playTimeMinute, long startTime, uint clearTime) { }
		
		// TODO
		private void UpdatePlayTimeText(bool isForce = false) { }
		
		// TODO
		private void SetDateMessageWord(long timeStamp) { }
		
		// TODO
		private void SetDateMessageWord(uint timeStamp) { }
		
		// TODO
		private string GetPlayerIdText(uint id) { return default; }
	}
}