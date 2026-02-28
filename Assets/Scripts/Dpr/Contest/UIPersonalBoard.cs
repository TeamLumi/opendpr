using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class UIPersonalBoard : MonoBehaviour
	{
		private UIText bestCntText;
		private UIText greaCntText;
		private UIText niceCntText;
		private UIText missCntText;
		private Image contestTitleImage;
		private Image rankTitleImage;
		private Image medalImage;
		private Image visualGaugeImage;
		private Image danceGaugeImage;
		private Image wazaGaugeImage;
		
		// TODO
		public void Initialize() { }
		
		private void SetTextComponents()
		{
			var uVar1 = ComponentExtensions.FindDeep(StringLiteral_8986,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.bestCntText = uVar1;
			uVar1 = ComponentExtensions.FindDeep(StringLiteral_8987,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.greaCntText = uVar1;
			uVar1 = ComponentExtensions.FindDeep(StringLiteral_8988,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.niceCntText = uVar1;
			uVar1 = ComponentExtensions.FindDeep(StringLiteral_8989,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.missCntText = uVar1;
		}
		
		// TODO
		private void SetText() { }
		
		// TODO
		private void SetImageComponents() { }
		
		// TODO
		public void SetCountTexts(string bestCntStr, string greatCntStr, string niceCntStr, string missCntStr) { }
		
		// TODO
		public void SetGaugeRatio(float visualRatio, float danceRatio, float wazaRatio) { }
		
		public void SetTitleSpr(Sprite contestTitleSpr, Sprite rankTitleSpr)
		{
			this.contestTitleImage.sprite = contestTitleSpr;
			this.rankTitleImage.sprite = rankTitleSpr;
		}
		
		public void SetMedalSpr(Sprite medalSpr)
		{
			this.medalImage.sprite = medalSpr;
			this.medalImage.enabled = 1;
		}
	}
}