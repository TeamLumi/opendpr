using DG.Tweening;
using Dpr.MsgWindow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Contest
{
	public class DanceSection : MonoBehaviour
	{
		private DanceSettings danceSettingData;
		private UIPlayerStatus uiPlayerStatus;
		private UIContestSkillInfo uiSkillInfo;
		private NotesLane notesLane;
		private ScoreGauge scoreGauge;
		private UIMusicProgressBar uiMusicProgress;
		private ContestMatchingNetwork network;
		private ADancePlayer[] dancePlayerArray;
		private DOTweenAnimation uiDanceFadeTween;
		private WaitForSeconds waitUIFadeTween;
		private WaitForSeconds waitIconJumpTween;
		private WaitForSeconds waitUserWazaAfter;
		private DanceSectionDataModel dataModel = new DanceSectionDataModel();
		private WazaSequencePlayer wazaSeqPlayer = new WazaSequencePlayer();
		private Queue<EmitHeartData> emitHeartDataQueue = new Queue<EmitHeartData>();
		private List<DanceHeartEffect> activeDanceHeartList = new List<DanceHeartEffect>();
		private List<Coroutine> runningCoroutineList = new List<Coroutine>();
		private SceneObjectManager manager;
		private WaitTimer waitEmitHeartTimer = new WaitTimer();
		private float elapsedTime;
		private float deltaTime;
		private float userSkillDuration;
		private bool isTutorial;
		private bool active;
		private bool lockEmitHeartFlag;
		private bool isBlockLockSkill;
		private bool isFinishDance;
		
		public void SetScriptableObject(DanceSettings danceSettingData)
		{
			this.danceSettingData = danceSettingData;
		}
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void ResetParam(DanceSectionData danceSectionData) { }
		
		// TODO
		public void Setup(ContestDataModel contestDataModel, bool isTutorial) { }
		
		// TODO
		private void CreatePlayerData(ContestPlayerEntity[] entities, DanceSectionData danceSectionData) { }
		
		// TODO
		private float CalcSkillAnimDuration(float skillAnimDuration, int restNoteNum) { return default; }
		
		public void SetProgressIconSpr(Sprite iconSpr)
		{
			this.uiMusicProgress.SetIconSpr(iconSpr);
		}
		
		// TODO
		public void SetupNetwork(ContestMatchingNetwork network, float syncScoreSpan) { }
		
		public bool IsReady()
		{
			if (((this.uiPlayerStatus.IsReady() & 1) != 0) &&
			   (this.uiPlayerStatus.IsReady() = NotesLane.IsReady(this.notesLane), (UIPlayerStatus.IsReady(this.uiPlayerStatus) & 1) != 0))
			{
			  return this.uiSkillInfo.IsReady();
			}
			return false;
		}
		
		public bool IsActive { get => active; }
		
		// TODO
		public void StartSection() { }
		
		// TODO
		private IEnumerator IE_StartSection(Action onComplete) { return default; }
		
		// TODO
		public void Stop() { }
		
		// TODO
		public void HideDanceUI() { }
		
		// TODO
		public void FinishSection() { }
		
		// TODO
		private IEnumerator IE_WaitFinish(Action onComplete) { return default; }
		
		// TODO
		public bool UpdateSection(float deltaTime, float elapsedTime) { return default; }
		
		// TODO
		private void CheckCreateNote() { }
		
		// TODO
		private void CreateNotesBg(NotesDataModel noteDataModel) { }
		
		// TODO
		private void OnDeactiveNote(NoteIcon targetIcon) { }
		
		// TODO
		private void OnArrivedNote(NoteTypeID noteType) { }
		
		// TODO
		private void OnThrowLongEndNote() { }
		
		// TODO
		private void UpdatePlayer(float elapsedTime) { }
		
		// TODO
		private void UserAction(DanceUser player) { }
		
		// TODO
		private void NPCAction(DanceNPC npc) { }
		
		// TODO
		private void OtherPlayerAction(DanceOtherUser player) { }
		
		// TODO
		private void UserTap(int userIndex, DanceTapData tapData) { }
		
		// TODO
		private void UserReleaseHold(int userIndex, DanceTapData tapData) { }
		
		// TODO
		private void NPCTap(int playerIndex, DanceTapData tapData) { }
		
		// TODO
		private void NPCReleaseHold(int playerIndex, DanceTapData tapData) { }
		
		// TODO
		private void PlayerTapActionResult(int playerIndex, PlayerType playerType, NoteTapTimingID timingID) { }
		
		private void ShowUITimingGrade(NoteTapTimingID timingID)
		{
			if ((this.wazaSeqPlayer.IsRunning & 1) != 0) {
			}
			this.notesLane.ShowTimingGrade(timingID);
		}
		
		private void UpdateContestWaza()
		{
			this.wazaSeqPlayer.OnUpdate();
		}
		
		// TODO
		public void ForceLaunchContestWazaFromSeq() { }
		
		// TODO
		private void OnLockContestSkill(ADancePlayer player) { }
		
		// TODO
		private void LaunchContestSkill(ADancePlayer player) { }
		
		// TODO
		private void ShowSkillUI(ADancePlayer player, bool isPrevSameWazaType, bool isSameUserWazaType) { }
		
		// TODO
		private IEnumerator IE_DoActivePlayerSkillAnimation(ADancePlayer player, Action onFinishAnim, Action onComplete) { return default; }
		
		// TODO
		private IEnumerator IE_DoNonActivePlayerSkillAnimation(float duration, Action onComplete) { return default; }
		
		// TODO
		private PlayerDanceDataModel CalcScoreAfterContestWaza(ADancePlayer player, float checkElapsedTime) { return default; }
		
		// TODO
		private void CheckSkillComboBonus(int playerIndex) { }
		
		// TODO
		private void UpdateUI() { }
		
		// TODO
		private void UpdateProgressGauge() { }
		
		// TODO
		private void EmitHeart(int playerIndex, PlayerType playerType) { }
		
		// TODO
		private void UpdateEmitHeart(float deltaTime) { }
		
		// TODO
		private void UpdateChainGauge() { }
		
		// TODO
		private void UpdateHeartEffect() { }
		
		public void OnLateUpdate()
		{
			this.wazaSeqPlayer.OnLateUpdate();
		}
		
		// TODO
		private void DoPlayAllTween(bool forward) { }
		
		// TODO
		private void DoPlayUIDanceTween(bool forward) { }
		
		// TODO
		public void OnLeaveOtherPlayer(int index) { }
		
		// TODO
		public void OnChangeHostMine() { }
		
		// TODO
		private void SendScoreData(ADancePlayer player) { }
		
		// TODO
		private void SendLaunchSkillData(ADancePlayer player) { }
		
		// TODO
		private bool CheckCanSendPacket(ADancePlayer player) { return default; }
		
		// TODO
		public void ReceiveScore(ScoreNetData scoreData) { }
		
		// TODO
		public void ReceiveLaunchSkill(LaunchSkillNetData launchSkillData) { }
	}
}