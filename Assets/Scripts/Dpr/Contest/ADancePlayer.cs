using System;
using System.Collections.Generic;

namespace Dpr.Contest
{
	public abstract class ADancePlayer
	{
		protected List<NotesDataModel> notesDataList = new List<NotesDataModel>();
		protected PlayerDanceDataModel danceData;
		protected PlayerType playerType = PlayerType.NPC;
		protected Action<ADancePlayer> onLockSkill;
		protected ActionID currentActionID;
		protected double currentElapsedTime;
		protected double sendScoreDataSpan;
		protected double sendScoreDataTimer;
		protected float skillAnimDuration;
		protected float reservedLaunchElapsedTime;
		protected float lastNoteArriveTime;
		protected int playerIndex;
		protected bool bForceLaunchSkillFlag;
		protected bool bIsMultiMode;
		protected bool bIsActive;
		
		public ADancePlayer(int playerIndex, List<NotesDataModel> notesDataList, Action<ADancePlayer> onLockSkill)
		{
			this.playerIndex = playerIndex;
			this.notesDataList = notesDataList;
			this.onLockSkill = onLockSkill;

			lastNoteArriveTime = notesDataList[notesDataList.Count - 1].arriveSec;
			bIsMultiMode = false;
		}
		
		// TODO
		private float CalcLastNoteArriveTime() { return default; }
		
		public float SkillAnimDuration { get => skillAnimDuration; }
		
		// TODO
		public void SetSkillAnimDuration(float skillAnimDuration) { }
		
		public bool IsActive { get => bIsActive; }
		public int PlayerIndex { get => playerIndex; }
		public ActionID CurrentActionID { get => currentActionID; }
		public PlayerType PlayerType { get => playerType; }
		
		// TODO
		public virtual void Reset() { }

		public abstract void Activate();

		public abstract void DeActivate();
		
		// TODO
		public void OnFinalize() { }

		protected abstract void Dispose();

		public abstract void NoticeLaunchSkill(ADancePlayer player);
		
		public abstract void LaunchSkill();

		public abstract void ActivateSkillEffect(double elapsedTime, Action onFinishSkillEffect);

		protected abstract void OnChangeMultiMode(bool isHost);

		protected abstract void UpdateAction();

		protected abstract void UpdateSkill();

		protected abstract void OnForceLaunchSkill();
		
		// TODO
		public void OnUpdate(double elapsedTime) { }
		
		// TODO
		protected void CheckCanUseSkill() { }
		
		// TODO
		public void ForceLaunchSkill(float reservedLaunchElapsedTime) { }
		
		public bool CheckSendScore()
		{
			if ((this.bIsMultiMode) &&
			   (this.sendScoreDataSpan <= this.sendScoreDataTimer)) {
			  this.sendScoreDataTimer = 0;
			  return true;
			}
			return false;
		}
		
		// TODO
		public void ChangeMultiMode(bool isHost, float syncScoreSpan) { }

		public enum ActionID : int
		{
			None = 0,
			Tap = 1,
			StartHold = 2,
			Release = 3,
			LaunchSkill = 4,
		}
	}
}