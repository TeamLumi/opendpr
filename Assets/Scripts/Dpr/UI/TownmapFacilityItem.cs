using UnityEngine;

namespace Dpr.UI
{
	public class TownmapFacilityItem : MonoBehaviour
	{
		[SerializeField]
		private UIText _text;
		
		public void Setup(string messageLabel)
		{
			this._text.SetupMessage(0,messageLabel);
		}
	}
}