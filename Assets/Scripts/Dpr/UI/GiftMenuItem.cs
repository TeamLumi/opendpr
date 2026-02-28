using UnityEngine;

namespace Dpr.UI
{
	public class GiftMenuItem : MonoBehaviour
	{
		[SerializeField]
		public GiftMainMenuWindow.MenuType ItemMenuType = GiftMainMenuWindow.MenuType.None;
        [SerializeField]
		public GameObject buttonEffectObject;
		
		public void Select()
		{
			this.buttonEffectObject.SetActive(1);
		}
		
		public void Unselect()
		{
			this.buttonEffectObject.SetActive(0);
		}
	}
}