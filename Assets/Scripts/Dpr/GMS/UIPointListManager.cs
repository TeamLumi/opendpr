using Audio;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIPointListManager : MonoBehaviour
	{
		private readonly Vector2 HIDE_SCROLL_VIEW_POSITION = new Vector2(1000.0f, -10.0f);

		private UIGMSPointDataScrollView tradePointScrollView;
		private UIGMSPointDataScrollView browsingPointScrollView;
		private UIGMSPointDataScrollView browsingPointHistoryScrollView;
		private GMSPointDataContainer dataContainerPtr;
		private ViewState viewState = ViewState.BrowsingPointView;
		private AudioManager audioManager;
		private Image listMaskImage;
		private StringBuilder markDataTitleSb = new StringBuilder();
		private StringBuilder emptyDataTitleSb = new StringBuilder();
        private StringBuilder emptyDataNameSb = new StringBuilder();
        private Action<PointHistoryDataModel> onSelectPointData;
		private Action onReleaseInput;
		private Action onCancelList;
		private GMSMode gmsMode = GMSMode.Top;
		private int currentBrowsingPointDataIndex;
		internal bool bIsShowPointHistoryView = true;
		
		// TODO
		public void Initialize(Action<PointHistoryDataModel> onSelectPointData, Action onReleaseInput, Action onCancelSelect) { }
		
		// TODO
		private void InitializeScrollView() { }
		
		// TODO
		public void Setup(GMSPointDataContainer dataContainer, int startTradeListIndex, int startBrowsingListIndex) { }
		
		public void OnFinalize()
		{
			this.browsingPointScrollView.onRequiredItem = 0;
			this.browsingPointScrollView.onMoveScrollView = 0;
			this.browsingPointScrollView.onSelect = 0;
			this.browsingPointScrollView.onCancel = 0;
			this.browsingPointScrollView.onReleaseInput = null;
			this.browsingPointHistoryScrollView.onRequiredItem = 0;
			this.browsingPointHistoryScrollView.onMoveScrollView = 0;
			this.browsingPointHistoryScrollView.onSelect = 0;
			this.browsingPointHistoryScrollView.onCancel = 0;
			this.browsingPointHistoryScrollView.onReleaseInput = null;
			this.tradePointScrollView.onRequiredItem = 0;
			this.tradePointScrollView.onMoveScrollView = 0;
			this.tradePointScrollView.onSelect = 0;
			this.tradePointScrollView.onCancel = 0;
			this.tradePointScrollView.onReleaseInput = null;
			this.onSelectPointData = null;
			this.onReleaseInput = null;
			this.onCancelList = null;
		}
		
		// TODO
		public void SetInputEnabled(bool enabled) { }
		
		// TODO
		public void SetInputEnabled(bool tradePointEnabled, bool browsingPointEnabled, bool browsingPointHistoryEnabled) { }
		
		// TODO
		public void OnChangeStateMain(GMSMode gmsMode, int index, bool canControllList) { }
		
		public bool IsShowPointHistoryView { get => bIsShowPointHistoryView; }
		public bool PlayingPointDataList { get => tradePointScrollView.IsPlayingInput || browsingPointScrollView.IsPlayingInput; }
		public int TradePointListIndex { get => tradePointScrollView.CurrentSelectIndex; }
		public int BrowsingPointListIndex { get => browsingPointScrollView.CurrentSelectIndex; }
		public int SelectPointDataIndex { get => currentBrowsingPointDataIndex; }
		public int CurrentSelectPointHistoryIndex { get => browsingPointHistoryScrollView.CurrentSelectIndex; }
		
		// TODO
		public void HideAllUI() { }
		
		// TODO
		public void ShowTradePointList(int index) { }
		
		// TODO
		private void HideTradePointList() { }
		
		// TODO
		private void ShowBrowsingPointList(int index) { }
		
		// TODO
		private void HideBrowsingPointList() { }
		
		// TODO
		public void ShowPointHistoryInTrade(int pointIndex) { }
		
		// TODO
		private void ShowHistoryList() { }
		
		// TODO
		public void HideBrowsingHistoryList() { }
		
		private void SetShowHistoryFlag(bool flag)
		{
			this.bIsShowPointHistoryView = (flag ? 1 : 0) & 1;
			this.listMaskImage.enabled = (flag ? 1 : 0) & 1;
		}
		
		// TODO
		public void OnDeleteAllHistoryData(bool hasPutPoint) { }
		
		// TODO
		private GMSPointDataModel GetPointDataModelByIndex(int index) { return default; }
		
		// TODO
		public void MoveTradePointListIndex(int index) { }
		
		// TODO
		public void MoveBrowsingPointListIndex(int index) { }
		
		// TODO
		private void ReloadBrowsingPointList(int startIndex) { }
		
		// TODO
		public void ResetDataListItemView() { }
		
		// TODO
		private void ReloadHistoryViewData() { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void OnRequiredTradePointItem(AUIGMSScrollItem item) { }
		
		// TODO
		private void OnMoveTradePointView(int index) { }
		
		// TODO
		private void OnSelectTradePointItem() { }
		
		// TODO
		private void OnRequiredBrowsingPointItem(AUIGMSScrollItem item) { }
		
		// TODO
		private void UpdatePointDataIconView(GMSPointDataModel newData, UIBrowsingPointDataItem targetItem) { }
		
		// TODO
		private void OnMoveBrowsingPointView(int index) { }
		
		// TODO
		private void OnSelectBrowsingPointItem() { }
		
		// TODO
		private void OnRequiredHistoryDataItem(AUIGMSScrollItem item) { }
		
		// TODO
		private void OnSelectHistoryItem() { }
		
		// TODO
		private PointHistoryDataModel GetMonsData() { return default; }
		
		// TODO
		private void OnCancelHistory() { }
		
		// TODO
		private void ResetPointNewFlag(int pointIndex) { }
		
		private void OnReleaseListInput()
		{
			if ((!this.bIsShowPointHistoryView) && (this.onReleaseInput != null)) {
			  this.onReleaseInput.Invoke();
			}
		}

		public enum ViewState : int
		{
			TradePointView = 0,
			BrowsingPointView = 1,
			BrowsingHistoryView = 2,
			SelectHistoryDataView = 3,
			None = 4,
		}
	}
}