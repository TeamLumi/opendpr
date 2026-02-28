using System;
using UnityEngine;

namespace Dpr.UI
{
	public abstract class AWindowItem : MonoBehaviour
	{
		[SerializeField]
		private RectTransform cursorContent;
		[HideInInspector]
		public int index;
		[HideInInspector]
		public int selectIndex;
		[HideInInspector]
		public bool isShow = true;

		protected Action<AWindowItem> onItemEvent;
		
		public RectTransform CursorContent { get => cursorContent; }
		
		public abstract ItemType ItemType { get; }
		public abstract bool IsShowArrowIcon { get; }

		public abstract bool OnUpdate(float deltaTime);
		
		// TODO
		public void Initialize(Action<AWindowItem> onItemEvent) { }
		
		// TODO
		protected virtual void OnInitialize() { }
		
		public void OnFinalize()
		{
			this.onItemEvent = null;
		}
		
		public void Show()
		{
			if (this.isShow) {
			}
			this.isShow = true;
			ExtensionMethods.SetActive(1);
		}
		
		public void Hide()
		{
			if (this.isShow) {
			  this.isShow = false;
			  ExtensionMethods.SetActive(0);
			}
		}
	}
}