using Dpr.Message;
using Dpr.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class StatuePlacementFilterWindow : MonoBehaviour
	{
		[SerializeField]
		private GameObject topItemPrefab;
		[SerializeField]
		private GameObject detailItemPrefab;
		[SerializeField]
		private RectTransform topContentsRoot;
		[SerializeField]
		private RectTransform detailContentsRoot;
		[SerializeField]
		private GameObject topWindow;
		[SerializeField]
		private GameObject detailWindow;
		[SerializeField]
		private RectTransform detailWindowRect;
		[SerializeField]
		private VerticalLayoutGroup detailLayoutGroup;
		[SerializeField]
		private GameObject window;
		[SerializeField]
		private StatuePlacementFilterInfo filterInfo;
		[SerializeField]
		private SecretBaseAudioManager audioManager;
		[SerializeField]
		private IndexSelector topItemSelector;
		[SerializeField]
		private IndexSelector detailItemSelector;

		private List<FillterTopItem> topItems = new List<FillterTopItem>();
		private Dictionary<int, List<FilterDetailItem>> detailItems = new Dictionary<int, List<FilterDetailItem>>();
		private int[] detailItemIndices = new int[(int)TopItemType.Max];
		private State currentState;
		private bool isReset;
		private bool isDisplay;
		private float dest;
		private float detailContentHeight;
		private float viewport;

		private readonly float scrollSpeed = 0.5f;
		private readonly float itemSize = 56.0f;

		private Action<FilterResult> OnApplied;
		private Action<bool> OnCancel;
		
		// TODO
		public void Initialize(Action<FilterResult> OnApplied, Action<bool> OnCancel) { }
		
		public void Show()
		{
			this.currentState = (State)0;
			this.isReset = 0x100;
			ShowTopItemList();
			this.window.SetActive(1);
			this.filterInfo.Apply(0xffffffff);
		}
		
		public void Close()
		{
			this.isDisplay = false;
			this.currentState = (State)0;
			this.window.SetActive(0);
		}
		
		// TODO
		private void InitializeDetail_Top(MessageMsgFile msgFile) { }
		
		// TODO
		private void InitializeDetail_Type(MessageMsgFile msgFile) { }
		
		// TODO
		private void InitializeDetail_Size(MessageMsgFile msgFile) { }
		
		// TODO
		private void InitializeDetail_Category(MessageMsgFile msgFile) { }
		
		// TODO
		private void AddDetail(TopItemType type, string[] subjects) { }
		
		public void OnUpdate()
		{
			if (this.isDisplay) {
			  if ((int)this.currentState == 1) {
			    OnUpdate_DetailSelect();
			  }
			  if ((int)this.currentState == 0) {
			    OnUpdate_TopSelect();
			  }
			}
		}
		
		// TODO
		private void OnUpdate_TopSelect() { }
		
		// TODO
		private void ResetFillter() { }
		
		// TODO
		private void ApplyFilter() { }
		
		// TODO
		private void OnUpdate_DetailSelect() { }
		
		private void CalcScroll()
		{
			float fVar6 = default;
			int iVar10 = default;
			int iVar4 = default;
			var fVar8 = this.detailContentHeight;
			if (this.itemSize + fVar6 <= this.detailContentHeight) {
			  fVar8 = this.itemSize + fVar6;
			}
			if (this.dest <= this.itemSize * (float)iVar10 + (float)iVar4) {
			  var bVar1 = false;
			  var bVar2 = true;
			  var bVar3 = false;
			  if (fVar8 <= this.detailContentHeight) {
			    bVar1 = false;
			    bVar2 = false;
			    bVar3 = true;
			    if (!NAN(fVar8) && !NAN(this.dest + this.viewport)) {
			      bVar1 = fVar8 < this.dest + this.viewport;
			      bVar2 = fVar8 == this.dest + this.viewport;
			      bVar3 = false;
			    }
			  }
			  if (bVar2 || bVar1 != bVar3) {
			  }
			  this.dest + this.viewport = this.dest + (fVar8 - this.dest + this.viewport);
			}
			else if (this.dest + this.viewport < 0.0) {
			}
			this.dest = this.dest + this.viewport;
		}
		
		// TODO
		private void CalcScrollImmediate() { }
		
		// TODO
		private void ShowDetailItemList() { }
		
		// TODO
		private void ShowTopItemList() { }
		
		// TODO
		private void ApplyTopItemText() { }
		
		// TODO
		private void UpdateTopIndex(int move) { }
		
		// TODO
		private void UpdateDetailIndex(int topItemIndex, int move) { }

		private enum TopItemType : int
		{
			Type1 = 0,
			Type2 = 1,
			Size = 2,
			Category = 3,
			Max = 4,
		}

		private enum State : int
		{
			TopSelect = 0,
			DetailSelect = 1,
		}

		public class FilterResult
		{
			public int type1;
			public int type2;
			public int size;
			public int category;
			public int legend;
			
			public FilterResult()
			{
				// Empty, declared explicitly
			}
			
			public FilterResult(int type1, int type2, int size, int category, int legend)
			{
				this.type1 = type1;
				this.type2 = type2;
				this.size = size;
				this.category = category;
				this.legend = legend;
			}
		}
	}
}