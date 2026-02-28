using Dpr.Contest;
using Dpr.EvScript;
using Dpr.NetworkUtils;
using INL1;
using System;
using System.Collections;
using UnityEngine;
using XLSXContent;

namespace Dpr.UI
{
	public class ContestMatching : UIWindow, IContestUIWindow
	{
		[SerializeField]
		private ContestMatchingUI contestMatchingUI;
		[SerializeField]
		private UISelectorWindow selectorWindow;

		private ContestMatchingNetwork network = new ContestMatchingNetwork();
		private ContestMatchingRecruitmentMember recruitmentMember = new ContestMatchingRecruitmentMember();
		private ContestMatchingCategoryAndRank selectCategoryAndRank = new ContestMatchingCategoryAndRank();
		private ContestMatchingPreparation preparation = new ContestMatchingPreparation();
		private ContestMatchingResume resume = new ContestMatchingResume();
		private ContestMasterDatas contMasterData;
		private ContestConfigDatas contConfigData;
		private MatchingState currentState;
		private EvWork.WORK_INDEX resultWorkIndex;
		private bool bIsSuccess;
		private bool bIsActive;
		private bool bIsLoadAssetBundle;
		
		public ContestMenuEventID ResultEventID { get => ContestMenuEventID.Decide; }
		public bool IsOpen { get => throw new NotImplementedException(); }
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(MatchingParam param, UIWindowID prevWindowId) { }
		
		// TODO
		public void OpenResume(int resultWkIndex, UIWindowID prevWindowId) { }
		
		private void ResetParam()
		{
			this.bIsSuccess = false;
			FlagWork.SetWork(this.resultWorkIndex,2);
		}
		
		// TODO
		private IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void AppendContestMasterData() { }
		
		// TODO
		private void RequestLoadAssetBundle() { }
		
		private void OnUpdate(float deltaTime)
		{
			if (this.bIsActive) {
			  switch(this.currentState) {
			  case 0:
			    if (this.recruitmentMember.bIsActive) {
			      var iVar1 = this.recruitmentMember.currentState;
			      if ((int)iVar1 == 2) {
			        this.recruitmentMember.UpdateWaitSkip();
			      }
			      if ((int)iVar1 == 1) {
			        this.recruitmentMember.UpdateWaitAllReady();
			      }
			      if ((int)iVar1 == 0) {
			        this.recruitmentMember.UpdateWaitJoinMember();
			        this.recruitmentMember.UpdateInput();
			      }
			    }
			    break;
			  case 1:
			    this.selectCategoryAndRank.OnUpdate();
			    break;
			  case 2:
			    if (this.preparation != null) {
			      ContestMatchingPreparation.OnUpdate();
			    }
			    break;
			  case 3:
			    if (this.resume.bIsActive) {
			      if ((int)this.resume.currentState == 3) {
			        ContestMatchingResume.UpdateWait();
			      }
			      if ((int)this.resume.currentState == 2) {
			        ContestMatchingResume.UpdateReady();
			      }
			    }
			    break;
			  case 5:
			    UpdateExit();
			    break;
			  }
			}
		}
		
		// TODO
		private void OnFinishRecruitmentMember() { }
		
		// TODO
		private void OnFinishSelectCategoryAndRank() { }
		
		private void SendNextStepDataToAll()
		{
			if ((this.network.IsHost() & 1) != 0) {
			  this.network.SendNoticeDataToAll(8);
			}
		}
		
		// TODO
		private void OnRecievePacket(byte dataID, PacketReader pr) { }
		
		// TODO
		private void OnReceiveModelData(PacketReader pr) { }
		
		// TODO
		private void OnReceiveCountDownData(PacketReader pr) { }
		
		// TODO
		private void OnReceiveSkillPointData(PacketReader pr) { }
		
		private void OnReceiveChoiceData(PacketReader pr)
		{
			var uVar1 = Dpr_Contest_ContestMatchingNetwork__ReceiveChoiceNetData
			                  (this.network,pr,0);
			if ((int)this.currentState == 1) {
			  this.selectCategoryAndRank.OnReceiveChoice(uVar1);
			}
		}
		
		// TODO
		private void OnReceiveCategoryAndRankData(PacketReader pr) { }
		
		private void OnReceiveEntryNPCData(PacketReader pr)
		{
			var uVar1 = Dpr_Contest_ContestMatchingNetwork__ReceiveEntryNPCData
			                  (this.network,pr,0);
			if ((int)this.currentState == 2) {
			  this.preparation.OnReceiveEntryNPCData(uVar1);
			}
		}
		
		// TODO
		private void OnReceiveEntryPlayerData(PacketReader pr) { }
		
		// TODO
		private void OnReceiveContestInfoData(PacketReader pr) { }
		
		// TODO
		private void OnReceiveReadyData(PacketReader pr) { }
		
		// TODO
		private bool CheckCanReceiveNoticeData(MultiContestStepID stepID) { return default; }
		
		// TODO
		private void OnSessionEvent(SessionEventData result) { }
		
		// TODO
		private void OnJoinMine(int stationIndex) { }
		
		private void OnJoinOtherPlayer(int stationIndex)
		{
			if ((int)this.currentState != 0) {
			}
			this.recruitmentMember.OnJoinOtherPlayer();
		}
		
		// TODO
		private void OnLeaveMine() { }
		
		// TODO
		private void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		private void OnChangeHostMine() { }
		
		// TODO
		private void OnChangeHostOtherPlayer(int stationIndex) { }
		
		// TODO
		private void OnSessionError() { }
		
		// TODO
		private void OnMatchingResult(FinishPattern pattern) { }
		
		// TODO
		private void ResultReuccess() { }
		
		// TODO
		private void ResultCancel() { }
		
		// TODO
		private void ResultDissolution() { }
		
		// TODO
		private void ResultLeaveMember() { }
		
		// TODO
		private bool CanOpenErrorDialog() { return default; }
		
		// TODO
		private void StopMatchingProcess() { }
		
		// TODO
		private void UpdateExit() { }
		
		private void OnFinishSession()
		{
			ContestUtils.EmitLog(StringLiteral_11292,3);
		}
		
		// TODO
		public void CloseWindow() { }
		
		// TODO
		private IEnumerator OpClose() { return default; }
		
		// TODO
		private void UnloadResources() { }
		
		// TODO
		public void ResetContestParam() { }
		
		// TODO
		public void SetTimeCount(string minutStr, string secondStr) { }

		public enum FinishPattern : int
		{
			Success = 0,
			Cancel = 1,
			Dissolution = 2,
			LeavedMember = 3,
			Error = 4,
		}

		private enum MatchingState : int
		{
			RecruitmentMember = 0,
			SelectCategoryAndRank = 1,
			Preparation = 2,
			Resume = 3,
			GoContest = 4,
			Exit = 5,
		}
	}
}