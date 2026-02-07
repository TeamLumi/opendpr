namespace Dpr.Battle.Logic
{
	public class RaidBattleParam
	{
		public byte bossGrade;
		public bool isBossRare;
		public RaidRewardItemData[] rewards = Arrays.InitializeWithDefaultInstances<RaidRewardItemData>(BattleDefConst.RAID_REWARD_ITEM_MAX);
		public RaidBossDesc bossDesc = new RaidBossDesc();
		public RaidBossCaptureDifficulty bossCaptureDifficulty;
		public bool needApplyCaptureCoefForSpGDuplication;
		
		public void CopyFrom(RaidBattleParam src)
		{
			bossGrade = src.bossGrade;
			isBossRare = src.isBossRare;
			for (int i = 0; i < rewards.Length; i++)
			{
				rewards[i].CopyFrom(src.rewards[i]);
			}
			bossDesc.CopyFrom(src.bossDesc);
			bossCaptureDifficulty = src.bossCaptureDifficulty;
			needApplyCaptureCoefForSpGDuplication = src.needApplyCaptureCoefForSpGDuplication;
		}
	}
}