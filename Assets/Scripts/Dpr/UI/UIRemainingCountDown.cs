using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIRemainingCountDown : MonoBehaviour
	{
		[SerializeField]
		private Image countImage;
		[SerializeField]
		private int startCount = 10;

		private DOTweenAnimation[] tweenArray;
		private Sprite[] countSprArray;
		private RectTransform imageRect;
		private Vector3 initScale = Vector3.zero;
		private float initAlpha;
		private bool bIsActive;
		
		// TODO
		private void Start() { }
		
		// TODO
		private void SetupCountSpr() { }
		
		// TODO
		public void DOCountDown(int count) { }
		
		public void Deactivate()
		{
			if (this.bIsActive) {
			  this.bIsActive = false;
			  ExtensionMethods.SetActive(0);
			}
		}
		
		private void OnDestroy()
		{
			this.countSprArray = null;
		}
	}
}