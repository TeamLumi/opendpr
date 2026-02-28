using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class PlayerStatusIcon : MonoBehaviour
	{
		private UIText wazaNameText;
		private UIText playerNameText;
		private RectTransform iconContent;
		private RectTransform statusIconRect;
		private RectTransform pmIconRect;
		private Image pmIconImage;
		private Image wazaTypeIconImage;
		private Image wazaMaskObj;
		private Image tensionIconImage;
		private Vector3 startPos = Vector3.zero;
		
		public Transform GetTransform()
		{
			return this.statusIconRect;
		}
		
		public Vector3 GetPmIconPos()
		{
			this.pmIconRect.position;
			return null;
		}
		
		// TODO
		public void Initialize(int index) { }
		
		private void SetComponents()
		{
			var uVar1 = UnityEngine_Component__GetComponent<object>
			                  (this);
			this.statusIconRect = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8913,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.iconContent = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8914,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.wazaTypeIconImage = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8915,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.tensionIconImage = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8916,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.wazaMaskObj = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8917,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.wazaNameText = uVar1;
			uVar1 = ComponentExtensions.FindDeep(StringLiteral_8918,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.playerNameText = uVar1;
			uVar1 = ComponentExtensions.FindDeep(_StringLiteral_8919,1);
			var uVar2 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.pmIconImage = uVar2;
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.pmIconRect = uVar1;
		}
		
		public void ResetIcon()
		{
			var uVar2 = GameObject.get_activeSelf(this.tensionIconImage.gameObject,0);
			if (uVar2) {
			  GameObject.SetActive(this.tensionIconImage.gameObject,0,0);
			}
			ExtensionMethods.SetActive(this.wazaMaskObj,0);
		}
		
		// TODO
		public void SetWazaName(string wazaName, Sprite wazaTypeIconSpr) { }
		
		public void SetMonsterIconSpr(Sprite iconSpr)
		{
			this.pmIconImage.sprite = iconSpr;
		}
		
		// TODO
		public void SetPlayerName(string name) { }
		
		// TODO
		public void ShowTension(Sprite spr) { }
		
		// TODO
		public void ShowTension(Sprite spr, float duration, float jumpPower) { }
		
		public void HideTension()
		{
			var uVar2 = GameObject.get_activeSelf(this.tensionIconImage.gameObject,0);
			if (uVar2) {
			  GameObject.SetActive(this.tensionIconImage.gameObject,0,0);
			}
		}
		
		private void SetTensionImageActive(bool active)
		{
			var uVar1 = GameObject.get_activeSelf(this.tensionIconImage.gameObject,0);
			if (((uVar1 ^ active) & 1) != 0) {
			  GameObject.SetActive(this.tensionIconImage.gameObject,(active ? 1 : 0) & 1,0);
			}
		}
		
		public void ShowWazaMask()
		{
			ExtensionMethods.SetActive(this.wazaMaskObj,1);
		}
		
		public void HideWazaMask()
		{
			ExtensionMethods.SetActive(this.wazaMaskObj,0);
		}
		
		public void StartContestSkill()
		{
			var uVar2 = GameObject.get_activeSelf(this.tensionIconImage.gameObject,0);
			if (uVar2) {
			  GameObject.SetActive(this.tensionIconImage.gameObject,0,0);
			}
			ExtensionMethods.SetActive(this.wazaMaskObj,1);
		}
	}
}