using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIPofinCase_CategoryButton : MonoBehaviour
	{
		public UIPofinCase_CategorySelector.Category category;
		public Action OnEnableCallback;
		private Image image;
		private UIText text;

		private static readonly Color OffColor = new Color32(200, 200, 200, 255);

		public Sprite SelectedImage;
		public Sprite UnselectedImage;
		
		private void Awake()
		{
			var uVar1 = this.transform;
			uVar1 = uVar1.Find(StringLiteral_3765);
			uVar1 = UnityEngine_Component__GetComponent<object>
			                  (uVar1);
			this.image = uVar1;
			uVar1 = this.transform;
			uVar1 = uVar1.Find(_StringLiteral_11863);
			uVar1 = UnityEngine_Component__GetComponent<object>
			                  (uVar1);
			this.text = uVar1;
		}
		
		public bool isOn { get; private set; }
		
		// TODO
		public void SetOn() { }
		
		// TODO
		public void SetOff() { }
	}
}