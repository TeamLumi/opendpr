using Audio;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class UISelectorWindow : MonoBehaviour
	{
		[SerializeField]
		private List<AWindowItem> windowItemList;
		[SerializeField]
		private GameObject[] frameObjArray;
		[SerializeField]
		private DOTweenAnimation scaleTween;

		private UIInputController inputController = new UIInputController();
		private AudioManager audioManager;
		private WindowState windowState;
		private float timer;
		private float waitTime;
		private bool bActive;
		private Action onClosed;
		private Action<WindowItemID> onItemEvent;
		private RectTransform cursorRect;
		private GameObject arrowParent;
		private Cursor cursorFrame;
		private AWindowItem currentSelectItem;
		private int cursorIndex;
		private bool bIsOpen;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		private void SetupCursor() { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool IsOpen { get => bIsOpen; }
		
		// TODO
		public T GetItem<T>(int index) { return default; }
		
		// TODO
		private void Clear() { }
		
		// TODO
		private void ResetIndex() { }
		
		public void SetWindowActive(bool active)
		{
			this.bActive = (active ? 1 : 0) & 1;
		}
		
		// TODO
		public void OpenSelectWindow(string[] contestNameArray, string[] rankNameArray, Action<WindowItemID> onEvent) { }
		
		// TODO
		public void ShowCategoryAndRank(string categoryName, string rankName) { }
		
		// TODO
		private void SetCategoryAndRankText(string categoryName, string rankName) { }
		
		// TODO
		private void SetFrameActive(WindowFrameType frameType, bool active) { }
		
		private void SetObjectActive(bool active)
		{
			var uVar2 = this.gameObject;
			var uVar1 = uVar2.activeSelf;
			if (((uVar1 ^ active) & 1) != 0) {
			  this.bIsOpen = true;
			  uVar2 = this.gameObject;
			  uVar2.SetActive(this.bIsOpen);
			}
		}
		
		// TODO
		public void Close([Optional] Action onClosed) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateWindowActive(float deltaTime) { }
		
		// TODO
		private void UpdateWaitStartDecideAnim() { }
		
		// TODO
		private void UpdateWaitCursorAnim(float deltaTime) { }
		
		// TODO
		private bool CheckCursorAnimState(int state) { return default; }
		
		// TODO
		private void OnItemEvent(AWindowItem item) { }
		
		public void OnCompleteRewind()
		{
			this.windowState = (WindowState)0;
			this.bIsOpen = false;
			var uVar1 = this.gameObject;
			uVar1.SetActive(0);
			if (this.onClosed != null) {
			  this.onClosed.Invoke();
			}
		}
		
		// TODO
		private void CursorUp() { }
		
		// TODO
		private void CursorDown() { }
		
		// TODO
		private void SetCursorIndex(int index) { }
		
		// TODO
		private void UpdateCursor() { }
		
		private void SetCursorView(bool active)
		{
			if (((this.arrowParent.activeSelf ^ active) & 1) != 0) {
			  this.arrowParent.SetActive((active ? 1 : 0) & 1);
			}
		}

		public enum WindowItemID : int
		{
			CategorySelector = 0,
			RankSelector = 1,
			DecideButton = 2,
			Num = 3,
		}

		private enum WindowFrameType : int
		{
			Selector = 0,
			View = 1,
		}

		private enum WindowState : int
		{
			Deactive = 0,
			Active = 1,
			WaitStartDecideAnim = 2,
			WaitCursorAnim = 3,
			Closing = 4,
		}
	}
}