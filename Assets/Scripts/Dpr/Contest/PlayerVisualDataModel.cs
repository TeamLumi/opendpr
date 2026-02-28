namespace Dpr.Contest
{
	public class PlayerVisualDataModel : PlayerVisualData
	{
		public void SetScore(int stickerScore, int itemScore, int conditionScore, int checkLargetHeartCount)
		{
			this.itemScore = itemScore;
			this.conditionScore = conditionScore;
			var iVar2 = (int)((float)(itemScore + stickerScore + conditionScore) / 100.0);
			var iVar1 = 0;
			if (checkLargetHeartCount != 0) {
			  iVar1 = iVar2 / checkLargetHeartCount;
			}
			this.emitNormalHeartNum = iVar2 - iVar1 * checkLargetHeartCount;
			this.stickerScore = stickerScore;
			this.heartNum = iVar2;
			this.emitLargeHeartNum = iVar1;
		}
		
		public bool IsEmitHeart { get => emitNormalHeartNum > 0 || emitLargeHeartNum > 0; }
		public int TotalHeartNum { get => emitLargeHeartNum + emitNormalHeartNum; }
		
		private int CalcHeartNum()
		{
			return (int)((float)(this.itemScore + this.stickerScore +
			                    this.conditionScore) / 100.0);
			return 0;
		}
	}
}