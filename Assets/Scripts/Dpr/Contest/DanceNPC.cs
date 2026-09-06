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
		
		// TODO
		protected override void Dispose() { }
		
		public DanceTapData TapData { get => tapData; }
		
		// TODO
		public override void Reset() { }
		
		public void ChangeTutorialSetting(bool flag) {
		    this.bIsTutorial = flag;
		}
		
		// TODO
		public override void Activate() { }
		
		// TODO
		private void SetNextNoteDataPtr() { }
		
		// TODO
		public override void DeActivate() { }
		
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
		
		// TODO
		private void StartHold() { }
		
		// TODO
		private void FinishHold() { }
		
		// TODO
		public void FailedTap() { }
		
		// TODO
		private bool CheckUseSkill() { return default; }
		
		// TODO
		private bool CheckLaunchSkill() { return default; }
		
		// TODO
		public override void NoticeLaunchSkill(ADancePlayer player) { }
		
		// TODO
		private void SetSkillComboTiming() { }
		
		// TODO
		private bool CheckLaunchSkillToOtherCombo() { return default; }
		
		// TODO
		protected override void OnForceLaunchSkill() { }
		
		// TODO
		public override void LaunchSkill() { }
		
		// TODO
		public override void ActivateSkillEffect(double elapsedTime, Action onFinishSkillEffect) { }
		
		// TODO
		private void UpdateSkillEffect() { }
		
		// TODO
		protected override void OnChangeMultiMode(bool isHost) { }
	}
}