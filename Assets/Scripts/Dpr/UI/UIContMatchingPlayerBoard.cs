using Dpr.Message;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIContMatchingPlayerBoard : MonoBehaviour
	{
		[SerializeField]
		private UIText _playerName;
		private GameObject loadingMonboObj;
		private Image preparationIconImage;
		private Sprite waitIconSpr;
		private Sprite readyIconSpr;
		
		// TODO
		public void Initialize(string initPlayerNameText, Sprite waitIconSpr, Sprite readyIconSpr) { }
		
		// TODO
		public void SetPlayerName(string playerNameSrt) { }
		
		// TODO
		public void SetPlayerName(string playerNameSrt, MessageEnumData.MsgLangId langId) { }
		
		// TODO
		public void ShowPreparatioIcon(bool isReady) { }
		
		public void HidePreparatioIcon()
		{
			var uVar2 = GameObject.get_activeSelf(this.preparationIconImage.gameObject,0);
			if (uVar2) {
			  GameObject.SetActive(this.preparationIconImage.gameObject,0,0);
			}
		}
		
		private void SetPreparatioIconActive(bool active)
		{
			var uVar1 = GameObject.get_activeSelf(this.preparationIconImage.gameObject,0);
			if (((uVar1 ^ active) & 1) != 0) {
			  GameObject.SetActive(this.preparationIconImage.gameObject,(active ? 1 : 0) & 1,0);
			}
		}
		
		public void SetLoadingMonboObjActive(bool active)
		{
			if (((this.loadingMonboObj.activeSelf ^ active) & 1) != 0) {
			  this.loadingMonboObj.SetActive((active ? 1 : 0) & 1);
			}
		}
	}
}