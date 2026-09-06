using Dpr.Message;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanLanguageButton : MonoBehaviour, IUIButton
	{
		private const string LanguageSpriteNameFormat = "cmn_ico_txt_lang_{0}_";

		[SerializeField]
		private Image image;

		private int index;
		private RectTransform rectTransform;
		private Sprite selectSprite;
		private Sprite unselectSprite;
		
		// TODO
		public MessageEnumData.MsgLangId LangId { get; private set; }
		
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
		public void SetLanguage(MessageEnumData.MsgLangId langId) { }
	}
}