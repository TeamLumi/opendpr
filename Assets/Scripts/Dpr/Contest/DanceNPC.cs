using System;
using System.Collections.Generic;
using XLSXContent;

namespace Dpr.Contest
{
	public class DanceNPC : ADancePlayer
	{
		private const float LAUNCH_SKILL_TIME_OFFSET = 0.1f;

		private DanceTapData tapData = new DanceTapData();
		private NotesDataModel nextNote;
		private ContestMasterDatas.SheetNPCLevelData npcLevelData;
		private double prevElapsedTime;
		private float reserveLaunchSkillTime;
		private float startNoteArriveSec;
		private float limitWaitComboTime;
		private float nextNoteArriveTime;
		private float waitTimer;
		private bool bIsStandbySkill;
		private bool bIsHold;
		private bool bTapActionEnable = true;
		private bool bIsTutorial;
		
		public DanceNPC(ContestPlayerEntity entity, CollectNotesDataModel collectNotesData, List<NotesDataModel> notesDataList, Action<ADancePlayer> onLockSkill) : base(entity.Index, notesDataList, onLockSkill)
		{
			danceData = entity.PlayerData.danceDataModel;
			playerType = PlayerType.NPC;
			npcLevelData = (entity.PlayerData as ContestNPCData).levelData;
			reserveLaunchSkillTime = notesDataList[collectNotesData.FindNotesIndexByDensityOarder(npcLevelData.densityOrder)].arriveSec - LAUNCH_SKILL_TIME_OFFSET;
			bIsActive = false;

			Reset();
		}
		
		protected override void Dispose()
		{
			this.bIsActive = 0;
			this.bTapActionEnable = false;
		}
		
		public DanceTapData TapData { get => tapData; }
		
		public override void Reset()
		{
			ADancePlayer.Reset();
			this.currentActionID = 0;
			this.bIsStandbySkill = false;
			this.bTapActionEnable = false;
		}
		
		public void ChangeTutorialSetting(bool flag)
		{
			this.bIsTutorial = (flag ? 1 : 0) & 1;
		}
		
		// TODO
		public override void Activate() { }
		
		// TODO
		private void SetNextNoteDataPtr() { }
		
		public override void DeActivate()
		{
			this.bIsStandbySkill = false;
			this.bIsActive = 0;
			this.bTapActionEnable = false;
		}
		
		// TODO
		public void SkipCurrentNotesIndexByTime(float elapsedTime) { }
		
		// TODO
		protected override void UpdateAction() { }
		
		// TODO
		protected override void UpdateSkill() { }
		
		// TODO
		private void UpdateNPCAction() { }
		
		// TODO
		private void UpdateNPCTapAction() { }
		
		private void StartHold()
		{
			this.bIsHold = true;
			this.currentActionID = 2;
			this.startNoteArriveSec = this.nextNoteArriveTime + this.tapData.tapTimingOffset;
		}
		
		private void FinishHold()
		{
			if (this.bIsHold) {
			  this.tapData.holdTimeRatio =
			       ((this.nextNoteArriveTime + this.tapData.tapTimingOffset) -
			       this.startNoteArriveSec) / (this.nextNoteArriveTime - this.startNoteArriveSec);
			  this.currentActionID = 3;
			  this.bIsHold = false;
			}
		}
		
		public void FailedTap()
		{
			this.startNoteArriveSec = 0;
			this.bIsHold = false;
		}
		
		// TODO
		private bool CheckUseSkill() { return default; }
		
		private bool CheckLaunchSkill()
		{
			return (double)this.reserveLaunchSkillTime <= this.currentElapsedTime;
		}
		
		// TODO
		public override void NoticeLaunchSkill(ADancePlayer player) { }
		
		private void SetSkillComboTiming()
		{
			var uVar1 = Random.Range(0,0x40bccccd);
			this.limitWaitComboTime = uVar1;
			this.waitTimer = 0;
		}
		
		private bool CheckLaunchSkillToOtherCombo()
		{
			if (this.bIsStandbySkill) {
			  var fVar1 = this.waitTimer +
			          (float)(this.currentElapsedTime - this.prevElapsedTime);
			  this.waitTimer = fVar1;
			  return this.limitWaitComboTime <= fVar1;
			}
			return false;
		}
		
		// TODO
		protected override void OnForceLaunchSkill() { }
		
		public override void LaunchSkill()
		{
			this.bTapActionEnable = false;
			this.danceData.LaunchSkill();
		}
		
		// TODO
		public override void ActivateSkillEffect(double elapsedTime, Action onFinishSkillEffect) { }
		
		// TODO
		private void UpdateSkillEffect() { }
		
		// TODO
		protected override void OnChangeMultiMode(bool isHost) { }
	}
}