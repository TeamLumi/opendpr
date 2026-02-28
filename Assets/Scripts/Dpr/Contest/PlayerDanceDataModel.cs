using System;

namespace Dpr.Contest
{
	public class PlayerDanceDataModel : PlayerDanceData
	{
		public PlayerDanceDataModel()
		{
			tapTimingCountArray = new int[(int)NoteTapTimingID.Num];
		}
		
		// TODO
		public void SetPlayerData(PlayerDanceData data) { }
		
		// TODO
		public void ResetParam() { }
		
		public int StackLiveScore { get => stackLiveScore; }
		
		public void AddLiveScore(int addScore)
		{
			this.danceScore = this.danceScore + addScore;
			this.stackLiveScore = this.stackLiveScore + addScore;
		}
		
		// TODO
		public void DecLiveScore(int decScore) { }
		
		// TODO
		public void AddTapTimingCount(NoteTapTimingID timingID) { }
		
		// TODO
		public int GetTapTimingCount(NoteTapTimingID timingID) { return default; }
		
		public void ForceSetTension(int tension)
		{
			this.successCount = 0;
			this.tension = tension;
		}
		
		// TODO
		public void SetUpdownCount(TensionData tensionData) { }
		
		public bool AddSuccessCount()
		{
			int iVar1 = default;
			if (((this.tension != 0) && (-1 < this.nextTensionUpCount)) &&
			   (iVar1 = this.successCount + 1, this.successCount = iVar1,
			   this.nextTensionUpCount <= iVar1)) {
			  this.tension = this.tension + -1;
			  this.successCount = 0;
			  return true;
			}
			return false;
		}
		
		private void UpTension()
		{
			this.tension = this.tension + -1;
		}
		
		// TODO
		public bool AddFailedCount() { return default; }
		
		private void DownTension()
		{
			this.tension = this.tension + 1;
		}
		
		private void ResetTensionCount()
		{
			this.successCount = 0;
		}
		
		// TODO
		public bool AddHeartGauge(int addValue) { return default; }
		
		public bool IsAlreadyUseSkill { get => usedSkill; }
		public bool IsActiveSkill { get => contestSkill.IsActive; }
		public bool IsForceSuccess { get => bonusParam.forceSuccess; }
		public bool CanEmitHeart { get => canEmitHeart; }
		
		public void UseSkill()
		{
			this.usedSkill = 1;
		}
		
		public void LockSkill()
		{
			this.usedSkill = 1;
		}
		
		// TODO
		public void LaunchSkill() { }
		
		public void FinishedSkillAnim()
		{
			this.canEmitHeart = 1;
		}
		
		// TODO
		public void ActivateSkillEffect(double elapsedTime, Action onFinishSkillEffect) { }
		
		public void UpdateSkillEffect(double elapsedTime)
		{
			this.contestSkill.UpdateSkill();
		}
		
		public void AddWazaScore(int score)
		{
			this.stackLiveScore = this.stackLiveScore + score;
			this.skillScore = this.skillScore + score;
		}
	}
}