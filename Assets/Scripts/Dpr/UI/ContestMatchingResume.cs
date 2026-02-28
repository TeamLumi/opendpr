using Dpr.Contest;
using Dpr.MsgWindow;
using System;
using XLSXContent;

namespace Dpr.UI
{
	public class ContestMatchingResume
	{
		private const float WAIT_TIME = 2.0f;

		private ContestMatchingUI contestMatchingUIPtr;
		private ContestMatchingNetwork networkPtr;
		private ContestMasterDatas contMasterDataPtr;
		private UIInputController inputController = new UIInputController();
		private UISelectorWindow selectorWindowPtr;
		private WaitTimer waitTimer;
		private Action<ContestMatching.FinishPattern> onFinish;
		internal ResumeState currentState;
		private int loadCount;
		internal bool bIsActive;
		
		public void Initialize(ContestMatchingUI contestMatchingUI, ContestMatchingNetwork network, Action<ContestMatching.FinishPattern> onFinish)
		{
			this.contestMatchingUIPtr = contestMatchingUI;
			this.networkPtr = network;
			this.onFinish = onFinish;
			this.currentState = (ResumeState)0;
		}
		
		public void OnFinalize()
		{
			this.onFinish = null;
		}
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void StartProcess(int stationIndex, UISelectorWindow selectorWindow, ContestMasterDatas contestMasterDatas) { }
		
		// TODO
		private void OnFinishMessage() { }
		
		// TODO
		private bool CheckSameMember() { return default; }
		
		// TODO
		private void LoadCharacterModel(int stationIndex, Action onComplete) { }
		
		public void OnUpdate(float deltaTime)
		{
			if (this.bIsActive) {
			  if ((int)this.currentState == 3) {
			    UpdateWait();
			  }
			  if ((int)this.currentState == 2) {
			    UpdateReady();
			  }
			}
		}
		
		// TODO
		private void UpdateCheckEntry() { }
		
		// TODO
		private void UpdateReady(float deltaTime) { }
		
		// TODO
		private void UpdateWait(float deltaTime) { }
		
		// TODO
		private void ChangeState(ResumeState newState) { }
		
		// TODO
		private void OnChangeState_CheckEntry() { }
		
		// TODO
		private void OnChangeState_Ready() { }
		
		private void OnChangeState_Wait()
		{
			if (this.waitTimer != null) {
			  this.waitTimer.ResetTimer();
			}
		}
		
		// TODO
		private void OnChangeState_Finish() { }
		
		// TODO
		private void SetReadyFlag(int stationIndex, bool flag) { }
		
		// TODO
		public void OnLeaveOtherPlayer(int stationIndex) { }
		
		// TODO
		public void Deactivate() { }
		
		public bool IsFinishPreparation()
		{
			return (int)this.currentState == 4;
		}
		
		// TODO
		public void OnReceiveReadyData(int stationIndex, NoticeID noticeID) { }

		internal enum ResumeState : int
		{
			LoadModel = 0,
			CheckEntry = 1,
			Ready = 2,
			Wait = 3,
			Finish = 4,
		}
	}
}