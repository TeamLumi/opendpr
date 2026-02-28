using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UINetworkIcon : MonoBehaviour
	{
		private DOTweenAnimation[] matchingIconTweens;
		private DOTweenAnimation[] attentionIconTweens;
		internal GameObject matchingIconObj;
		internal GameObject attentionIconObj;
		private Image matchingIconImage;
		private Image attentionIconImage;
		private RectTransform matchingIconRect;
		private RectTransform attentionIconRect;
		
		// TODO
		public void Initialize() { }
		
		public Vector3 MatchingIconPos { get => matchingIconRect.position; }
		
		// TODO
		public void ShowMatchingIcon() { }
		
		public void HideMatchingIcon()
		{
			this.matchingIconObj.SetActive(0);
		}
		
		// TODO
		public void ShowAttentionIcon() { }
		
		public void HideAttentionIcon()
		{
			this.attentionIconObj.SetActive(0);
		}
	}
}