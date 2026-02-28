using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class RegisterItemButton : MonoBehaviour
	{
		[SerializeField]
		private Image baseImage;
		[SerializeField]
		private Image itemIconImage;
		
		public ushort ItemNo { get; private set; }
		public bool IsSet { get; private set; }
		
		// TODO
		public void Setup(ushort itemNo) { }
		
		public void SetBaseSprite(Sprite sprite)
		{
			this.baseImage.sprite = sprite;
		}
	}
}