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
		
		// TODO
		public override void Activate() { }
		
		// TODO
		public override void DeActivate() { }
		
		// TODO
		protected override void Dispose() { }
		
		// TODO
		public override void Reset() { }
		
		public void ChangeTutorialSetting(bool flag) {
		    this.bAutoMode = flag;
		}
		
		// TODO
		protected override void UpdateAction() { }
		
		// TODO
		protected override void UpdateSkill() { }
		
		// TODO
		private void UserInput() { }
		
		// TODO
		protected override void OnForceLaunchSkill() { }
		
		// TODO
		public override void NoticeLaunchSkill(ADancePlayer player) { }
		
		// TODO
		public override void LaunchSkill() { }
		
		// TODO
		private void AutoSuccessMode() { }
		
		// TODO
		private void UpdateSkillEffect() { }
		
		// TODO
		public override void ActivateSkillEffect(double elapsedTime, Action onFinishSkillEffect) { }
		
		// TODO
		protected override void OnChangeMultiMode(bool isHost) { }
	}
}