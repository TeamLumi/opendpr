using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	[Serializable]
	public class UIButtonSelector
	{
		[SerializeField]
		private Transform buttonsParentTransform;
		[SerializeField]
		private IndexSelector indexSelector;

		private List<IUIButton> buttons;
		private Action<IUIButton> onSelectButton;
		private Action<IUIButton> onUnSelectButton;
		private List<IUIButton> activeButtons;
		
		// TODO
		public void Initialize(Action<IUIButton> onSelectButton, Action<IUIButton> onUnSelectButton) { }
		
		public void SetActive(bool isActive)
		{
			GameObject.SetActive(this.buttonsParentTransform.gameObject,(isActive ? 1 : 0) & 1,0);
		}
		
		// TODO
		public int GetActiveButtonIndex(int index) { return default; }
		
		// TODO
		public void Setup(int selectIndex = -1) { }
		
		// TODO
		public IUIButton GetButton(int index) { return default; }
		
		// TODO
		public int GetButtonCount() { return default; }
		
		// TODO
		public int GetActiveButtonCount() { return default; }
		
		// TODO
		public bool MoveSelect(int value) { return default; }
		
		public void ResumeMoveSelect()
		{
			this.indexSelector.ResumeMoveState();
		}
		
		// TODO
		private void SetSelectIndex(int index) { }
	}
}