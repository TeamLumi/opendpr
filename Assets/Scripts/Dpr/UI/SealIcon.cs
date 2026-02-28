using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SealIcon : MonoBehaviour
	{
		[SerializeField]
		protected Image iconImage;
		[SerializeField]
		private Image typeIconImage;
		
		// TODO
		public void Set(SealInfo sealInfo) { }
		
		// TODO
		public void Set(int sealId) { }
		
		public void Clear()
		{
			this.iconImage.sprite = 0;
		}
		
		public void SetEnable(bool isEnable)
		{
			this.iconImage.enabled = (isEnable ? 1 : 0) & 1;
			this.typeIconImage.enabled = (isEnable ? 1 : 0) & 1;
		}
	}
}