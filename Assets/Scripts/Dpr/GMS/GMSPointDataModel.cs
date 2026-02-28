using UnityEngine;

namespace Dpr.GMS
{
	public class GMSPointDataModel : GMSPointData
	{
		private Vector2 screenPos;
		private Vector3 normal;
		private int dataCount;
		internal int markIndex;
		private bool bIsView;
		internal bool bHasData;
		private bool bHasNewData;
		
		// TODO
		public void CreateData(ushort index, string pointTitle, in Vector3 point) { }
		
		public PointHistoryDataModel[] HistoryDataArray { get => historyDataArray; }
		public bool HasData { get => bHasData; }
		public bool IsMaxData { get => dataCount >= GMSDataConstants.POINT_HISTORY_DATA_NUM; }
		public int DataCount { get => dataCount; }
		public bool HasNewData { get => bHasNewData; }
		public int MarkIndex { get => markIndex; }
		
		public void ResetMarkIndex()
		{
			this.markIndex = 0;
		}
		
		// TODO
		public void ResetAllNewFlag() { }
		
		// TODO
		public PointHistoryDataModel GetHistoryDataByIndex(int index) { return default; }
		
		public PointHistoryDataModel GetMarkHistoryData()
		{
			if (this.markIndex < this.historyDataArray.Length) {
			  return *
			          (this.historyDataArray + (int)this.markIndex * 8 + 0x20);
			}
			return null;
		}
		
		// TODO
		public void SetHistoryData(int index, PointHistoryDataModel newHistoryData) { }
		
		// TODO
		public void AddHistoryData(PointHistoryDataModel newHistoryData) { }
		
		// TODO
		private void CheckHasNewFlagData() { }
		
		// TODO
		public void ChangeMarkHistoryData(int newMarkIndex) { }
		
		// TODO
		public void MoveTopNewHistoryData() { }
		
		// TODO
		public void DeleteHistoryData(int index) { }
		
		// TODO
		private void CheckHasHistoryData() { }
		
		// TODO
		public void SortHistoryData() { }
		
		public Sprite GetPointMarkIconSpr()
		{
			if (this.markIndex < this.historyDataArray.Length) {
			  return *
			          (this.historyDataArray + (int)this.markIndex * 8[0]
			          + 0x18);
			}
			return null;
		}
		
		public Vector3 Normal { get => normal; }
		public bool IsView { get => bIsView; }
		public Vector2 ScreenPos { get => screenPos; }
		
		public void ChangeViewStatus(bool canView)
		{
			if (((!this.bIsView ^ canView) & 1) == 0) {
			  this.bIsView = (canView ? 1 : 0) & 1;
			}
		}
		
		// TODO
		public void SetScreenPosition(Vector2 screenPos) { }
	}
}