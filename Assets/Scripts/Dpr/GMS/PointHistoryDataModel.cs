using Pml;

namespace Dpr.GMS
{
	public class PointHistoryDataModel : PointHistoryData
	{
		private bool bIsNew;
		
		public int DataIndex { get => dataIndex; }
		
		public void SetDataIndex(int dataIndex) {
		    this.dataIndex = dataIndex;
		}
		
		// TODO
		public string GetMonsNickname() { return default; }
		
		// TODO
		public void SetMonsNickname(string nickName) { }
		
		// TODO
		public string GetMonsName() { return default; }
		
		// TODO
		public void SetMonsName(string monsName) { }
		
		// TODO
		public string GetParentName() { return default; }
		
		// TODO
		public void SetParentName(string parentName) { }
		
		// TODO
		public string GetDateTimeStr() { return default; }
		
		// TODO
		public void SetDateTimeStr(string dateTimeStr) { }
		
		public bool IsNew { get => bIsNew; }
		
		// TODO
		public void SetNewFlag(bool flag) { }
		
		public IntermediatePointData GetPointData { get => currentPointData; }
		public MonsNo ReceiveMonsNo { get => currentPointData?.receiveMonsNo ?? MonsNo.NULL; }
		public uint ReceiveFormNo { get => currentPointData?.receiveMonsFormNo ?? 0; }
		
		// TODO
		public void SetPointData(IntermediatePointData pointData) { }
		
		// TODO
		public void ClearData() { }
	}
}