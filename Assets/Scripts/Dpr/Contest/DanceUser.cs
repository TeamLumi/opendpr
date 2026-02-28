using System;
using System.Collections.Generic;

namespace Dpr.Contest
{
	public class DanceUser : ADancePlayer
	{
		private ContestInput input = new ContestInput();
		private DanceTapData tapData = new DanceTapData();
		private ContestUserData contestUserData;
		private double prevElapsedTime;
		private bool canInput;
		private bool bAutoMode;
		private bool isOn;
		
		public DanceUser(ContestPlayerEntity entity, List<NotesDataModel> notesDataList, Action<ADancePlayer> onLockSkill) : base(entity.Index, notesDataList, onLockSkill)
		{
			contestUserData = entity.PlayerData as ContestUserData;
			danceData = contestUserData.danceDataModel;
			playerType = PlayerType.User;
			bIsActive = false;

			Reset();
		}
		
		public DanceTapData TapData { get => tapData; }
		
		public override void Activate()
		{
			this.bIsActive = 1;
			this.canInput = true;
			this.input.Subscribe();
		}
		
		public override void DeActivate()
		{
			this.bIsActive = 0;
			this.canInput = false;
			this.input.Remove();
		}
		
		protected override void Dispose()
		{
			this.bIsActive = 0;
			this.canInput = false;
			this.input.Remove();
		}
		
		public override void Reset()
		{
			ADancePlayer.Reset();
			this.currentActionID = 0;
			this.canInput = false;
			this.bIsActive = 0;
		}
		
		public void ChangeTutorialSetting(bool flag)
		{
			this.bAutoMode = (flag ? 1 : 0) & 1;
		}
		
		// TODO
		protected override void UpdateAction() { }
		
		// TODO
		protected override void UpdateSkill() { }
		
		// TODO
		private void UserInput() { }
		
		protected override void OnForceLaunchSkill()
		{
			this.bForceLaunchSkillFlag = 1;
		}
		
		// TODO
		public override void NoticeLaunchSkill(ADancePlayer player) { }
		
		public override void LaunchSkill()
		{
			this.canInput = false;
			if (this.bIsActive != 0) {
			  this.danceData.LaunchSkill();
			}
		}
		
		// TODO
		private void AutoSuccessMode() { }
		
		// TODO
		private void UpdateSkillEffect() { }
		
		public override void ActivateSkillEffect(double elapsedTime, Action onFinishSkillEffect)
		{
			this.canInput = true;
			this.danceData.ActivateSkillEffect(elapsedTime);
		}
		
		// TODO
		protected override void OnChangeMultiMode(bool isHost) { }
	}
}