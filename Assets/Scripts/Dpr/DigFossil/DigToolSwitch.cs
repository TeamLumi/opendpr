using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigToolSwitch : MonoBehaviour, IDigToolsSwitch
	{
		[SerializeField]
		private Image hummer;
		[SerializeField]
		private Image pickaxe;
		[SerializeField]
		private List<Sprite> sprites;
		[SerializeField]
		private RectTransform hummerRect;
		[SerializeField]
		private RectTransform pickaxeRect;
		[SerializeField]
		private DigAudioManager audioManager;
		private IDigCursor cursor;
		
		public bool IsPickaxe { get; private set; }
		
		public void Initialize(IDigCursor cursor)
		{
			this.cursor = cursor;
			SetTool(1);
		}
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void SetTool(bool bIsPickaxe) { }
		
		// TODO
		private bool CheckInsideButton(Vector2 touchPos, RectTransform rect) { return default; }

		private enum SpriteIndex : int
		{
			HummerOff = 0,
			HummerOn = 1,
			PickaxeOff = 2,
			PickaxeOn = 3,
		}
	}
}