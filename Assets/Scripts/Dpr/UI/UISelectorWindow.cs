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
		
		public void SetWindowActive(bool active) {
		    this.bActive = active;
		}
		
		// TODO
		public void OpenSelectWindow(string[] contestNameArray, string[] rankNameArray, Action<WindowItemID> onEvent) { }
		
		// TODO
		public void ShowCategoryAndRank(string categoryName, string rankName) { }
		
		// TODO
		private void SetCategoryAndRankText(string categoryName, string rankName) { }
		
		// TODO
		private void SetFrameActive(WindowFrameType frameType, bool active) { }
		
		// TODO
		private void SetObjectActive(bool active) { }
		
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
		
		// TODO
		public void OnCompleteRewind() { }
		
		// TODO
		private void CursorUp() { }
		
		// TODO
		private void CursorDown() { }
		
		// TODO
		private void SetCursorIndex(int index) { }
		
		// TODO
		private void UpdateCursor() { }
		
		// TODO
		private void SetCursorView(bool active) { }

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