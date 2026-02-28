using Pml;

namespace Dpr.GMS
{
	public class PointHistoryDataModel : PointHistoryData
	{
		private bool bIsNew;
		
		public int DataIndex { get => dataIndex; }
		
		public void SetDataIndex(int dataIndex)
		{
			this.dataIndex = dataIndex;
		}
		
		// TODO
		public string GetMonsNickname() { return default; }
		
		public void SetMonsNickname(string nickName)
		{
			this.receiveMonsNicknameSb.Clear();
			this.receiveMonsNicknameSb.Append(nickName);
		}
		
		// TODO
		public string GetMonsName() { return default; }
		
		public void SetMonsName(string monsName)
		{
			this.receiveMonsNameSb.Clear();
			this.receiveMonsNameSb.Append(monsName);
		}
		
		// TODO
		public string GetParentName() { return default; }
		
		public void SetParentName(string parentName)
		{
			this.receiveMonsParentNameSb.Clear();
			this.receiveMonsParentNameSb.Append(parentName);
		}
		
		// TODO
		public string GetDateTimeStr() { return default; }
		
		public void SetDateTimeStr(string dateTimeStr)
		{
			this.dateTimeSb.Clear();
			this.dateTimeSb.Append(dateTimeStr);
		}
		
		public bool IsNew { get => bIsNew; }
		
		// TODO
		public void SetNewFlag(bool flag) { }
		
		public IntermediatePointData GetPointData { get => currentPointData; }
		public MonsNo ReceiveMonsNo { get => currentPointData?.receiveMonsNo ?? MonsNo.NULL; }
		public uint ReceiveFormNo { get => currentPointData?.receiveMonsFormNo ?? 0; }
		
		public void SetPointData(IntermediatePointData pointData)
		{
			this.currentPointData = pointData;
		}
		
		public void ClearData()
		{
			this.dataIndex = 0xffffffff;
			this.currentPointData = 0;
			this.sendMonsIconSpr = 0;
			this.receiveMonsIconSpr = 0;
			this.receiveMonsSexIconSpr = 0;
			this.receiveMonsLangIconSpr = 0;
			this.receiveMonsParentLangIconSpr = 0;
			if (this.receiveMonsNameSb != 0) {
			  this.receiveMonsNameSb.Clear();
			}
			if (this.receiveMonsNicknameSb != 0) {
			  this.receiveMonsNicknameSb.Clear();
			}
			if (this.receiveMonsParentNameSb != 0) {
			  this.receiveMonsParentNameSb.Clear();
			}
			if (this.dateTimeSb != 0) {
			  this.dateTimeSb.Clear();
			}
		}
	}
}