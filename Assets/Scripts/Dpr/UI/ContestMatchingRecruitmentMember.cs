using Dpr.Contest;
using Dpr.NetworkUtils;
using System;

namespace Dpr.UI
{
	public class ContestMatchingRecruitmentMember
	{
		private JoinPlayerData[] joinPlayerDataArray;
		private ContestMatchingUI contestMatchingUIPtr;
		private ContestMatchingNetwork networkPtr;
		private UIInputController inputController = new UIInputController();
		private NetworkManager networkManager;
		private Action onFinishState;
		private Action<ContestMatching.FinishPattern> onFinish;
		internal RecruitmentState currentState;
		private int loadCount;
		private bool bLockPlayerAction;
		private bool bIsOpenConfirmMsg;
		internal bool bIsActive;
		
		// TODO
		public void Initialize(ContestMatchingUI contestMatchingUI, ContestMatchingNetwork network, Action onFinishState, Action<ContestMatching.FinishPattern> onFinishMatching) { }
		
		public void OnFinalize()
		{
			this.onFinishState = null;
			this.onFinish = null;
		}
		
		private void Reset()
		{
			this.bLockPlayerAction = false;
			this.bIsActive = false;
			this.currentState = (RecruitmentState)0;
		}
		
		// TODO
		public void StartProcess(int stationIndex, float startCountDown) { }
		
		// TODO
		private void CheckModelLoadCompleted() { }
		
		public void OnUpdate(float deltaTime)
		{
			if (this.bIsActive) {
			  if ((int)this.currentState == 2) {
			    UpdateWaitSkip();
			  }
			  if ((int)this.currentState == 1) {
			    UpdateWaitAllReady();
			  }
			  if ((int)this.currentState == 0) {
			    UpdateWaitJoinMember();
			    UpdateInput();
			  }
			}
		}
		
		// TODO
		private void UpdateWaitJoinMember(float deltaTime) { }
		
		// TODO
		private void CheckMatchingRecruitmentMemberInit(float deltaTime) { }
		
		// TODO
		private void UpdateWaitSkip(float deltaTime) { }
		
		// TODO
		private void UpdateWaitAllReady(float deltaTime) { }
		
		// TODO
		private void FixSessionPlayerUIInfo() { }
		
		// TODO
		private bool CheckMemberReady(float deltaTime) { return default; }
		
		// TODO
		private void FinishRecruitmentMember() { }
		
		private void CheckMemberActive()
		{
			if (((this.networkPtr.IsGamerActive(0) & 1) == 0) &&
			   (this.networkPtr.IsGamerActive(0) = Dpr_UI_MultiModelView__HasViewModelByIndex
			                      (this.contestMatchingUIPtr.modelView,0,0), (this.networkPtr.IsGamerActive(0) & 1) != 0))
			{
			  this.contestMatchingUIPtr.OnExitPlayer();
			}
			if (((this.networkPtr.IsGamerActive(1) & 1) == 0) &&
			   (this.networkPtr.IsGamerActive(1) = Dpr_UI_MultiModelView__HasViewModelByIndex
			                      (this.contestMatchingUIPtr.modelView,1,0), (this.networkPtr.IsGamerActive(1) & 1) != 0))
			{
			  this.contestMatchingUIPtr.OnExitPlayer(1);
			}
			if (((this.networkPtr.IsGamerActive(2) & 1) == 0) &&
			   (this.networkPtr.IsGamerActive(2) = Dpr_UI_MultiModelView__HasViewModelByIndex
			                      (this.contestMatchingUIPtr.modelView,2,0), (this.networkPtr.IsGamerActive(2) & 1) != 0))
			{
			  this.contestMatchingUIPtr.OnExitPlayer(2);
			}
			if (((this.networkPtr.IsGamerActive(3) & 1) == 0) &&
			   (this.networkPtr.IsGamerActive(3) = Dpr_UI_MultiModelView__HasViewModelByIndex
			                      (this.contestMatchingUIPtr.modelView,3,0), (this.networkPtr.IsGamerActive(3) & 1) != 0))
			{
			  this.contestMatchingUIPtr.OnExitPlayer(3);
			}
		}
		
		// TODO
		private void UpdateInput() { }
		
		// TODO
		private void OnSelectLeaveYes() { }
		
		// TODO
		private void OnSelectLeaveNo() { }
		
		// TODO
		private void HideMatchingUI() { }
		
		// TODO
		private void SetSkipFlag(int stationIndex, bool flag) { }
		
		private void ChangeState_WaitAllReady()
		{
			ContestUtils.EmitLog(StringLiteral_11358,3);
			this.currentState = (RecruitmentState)1;
		}
		
		// TODO
		public void OnJoinOtherPlayer(int stationIndex) { }
		
		// TODO
		public void OnLeaveMine() { }
		
		// TODO
		public void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		public void OnChangeHostMine() { }
		
		// TODO
		public void OnChangeHostOtherPlayer() { }
		
		public void Deactivate()
		{
			this.bIsActive = false;
		}
		
		// TODO
		public void OnReceiveCountDownData(CountDownNetData timeData) { }
		
		// TODO
		public void OnReceivePlayerData(NetPlayerInfo playerInfo) { }
		
		// TODO
		public void OnReceiveReadyData(int stationIndex, NoticeID noticeID) { }

		internal enum RecruitmentState : int
		{
			WaitJoinMember = 0,
			WaitAllReady = 1,
			WaitSkip = 2,
			Retry = 3,
			Finish = 4,
		}

		private class JoinPlayerData
		{
			public string playerName;
			public int cassetVersion;
			public ushort fashion;
			public bool isDpClear;
			
			public void Clear()
			{
				playerName = string.Empty;
				cassetVersion = 0;
				fashion = 0;
				isDpClear = false;
			}
		}
	}
}