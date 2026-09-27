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
			buttonEffectObject.SetActive(true);
		}
		
		public void Unselect()
		{
            buttonEffectObject.SetActive(false);
        }
	}
}