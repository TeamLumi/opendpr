using System.Collections;
using UnityEngine;

namespace Dpr.Contest
{
	public class ResultSection : MonoBehaviour
	{
		private ResultSettings resultSettings;
		private ResultAnnouncement resultAnnounce;
		private ResultTotalScores totalScores;
		private ResultPersonalPerformance personalPerformance;
		private ResultTutorialMode tutorialMode;
		private ResultDataModel resultDataModel;
		private ResultState currentState;
		private bool bRunning;
		internal bool restartContest;
		private bool isTutorial;
		private WaitForSeconds waitStartResult;
		
		public void SetScriptableObject(ResultSettings resultSettings)
		{
			this.resultSettings = resultSettings;
		}
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void ResetParam() { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool IsRestart { get => restartContest; }
		public bool IsReady { get => resultAnnounce.IsReady; }
		
		// TODO
		public void Setup(bool isTutorial) { }
		
		public void LoadResource(ResultID resultID)
		{
			this.resultAnnounce.LoadResultFx();
		}
		
		// TODO
		public void StartSection(ResultDataModel resultDataModel) { }
		
		// TODO
		private IEnumerator IE_StartSection(ResultState firstState) { return default; }
		
		public bool UpdateSection(float deltaTime)
		{
			switch(this.currentState) {
			case 1:
			  var iVar1 = this.resultAnnounce.currentState;
			  if ((int)iVar1 == 3) {
			    this.resultAnnounce.UpdateWait();
			    var cVar2 = this.resultAnnounce.bRunning;
			  }
			  else if ((int)iVar1 == 2) {
			    this.resultAnnounce.UpdateRankupAnim();
			    cVar2 = this.resultAnnounce.bRunning;
			  }
			  else {
			    if ((int)iVar1 == 1) {
			      this.resultAnnounce.UpdateGauge();
			    }
			    cVar2 = this.resultAnnounce.bRunning;
			  }
			  if (!cVar2) {
			    this.currentState = (ResultState)2;
			    this.totalScores.StartAnimation();
			  }
			  break;
			case 2:
			  UpdateTotalScores();
			  return this.bRunning;
			case 3:
			  this.personalPerformance.UpdatePokeMotion();
			  if ((int)this.personalPerformance.currentState == 1) {
			    this.personalPerformance.UpdateKeywait();
			  }
			  if (!this.personalPerformance.bRunning) {
			    this.currentState = (ResultState)5;
			    this.bRunning = false;
			    return false;
			  }
			  break;
			case 4:
			  UpdateTutorialMode();
			  return this.bRunning;
			}
			return this.bRunning;
		}
		
		private void UpdateAnnouncement(float deltaTime)
		{
			var iVar1 = this.resultAnnounce.currentState;
			if ((int)iVar1 == 3) {
			  this.resultAnnounce.UpdateWait();
			  var cVar2 = this.resultAnnounce.bRunning;
			}
			else if ((int)iVar1 == 2) {
			  this.resultAnnounce.UpdateRankupAnim();
			  cVar2 = this.resultAnnounce.bRunning;
			}
			else {
			  if ((int)iVar1 == 1) {
			    this.resultAnnounce.UpdateGauge();
			  }
			  cVar2 = this.resultAnnounce.bRunning;
			}
			if (!cVar2) {
			  this.currentState = (ResultState)2;
			  this.totalScores.StartAnimation();
			}
		}
		
		// TODO
		private void UpdateTotalScores(float deltaTime) { }
		
		private void UpdatePersonalPerformance()
		{
			this.personalPerformance.UpdatePokeMotion();
			if ((int)this.personalPerformance.currentState == 1) {
			  this.personalPerformance.UpdateKeywait();
			  var cVar1 = this.personalPerformance.bRunning;
			}
			else {
			  cVar1 = this.personalPerformance.bRunning;
			}
			if (cVar1) {
			}
			this.currentState = (ResultState)5;
			this.bRunning = false;
		}
		
		// TODO
		private void UpdateTutorialMode(float deltaTime) { }
		
		private void ChangeState(ResultState stateID)
		{
			this.currentState = (ResultState)(stateID);
			switch(stateID) {
			case 1:
			  this.resultAnnounce.StartAnimation();
			  break;
			case 2:
			  this.totalScores.StartAnimation();
			  break;
			case 3:
			  this.personalPerformance.StartAnimation();
			  break;
			case 4:
			  this.tutorialMode.StartAnimation();
			  break;
			case 5:
			  this.bRunning = false;
			  break;
			}
		}
		
		// TODO
		private RankGaugeData CreateRankGaugeData() { return default; }

		private enum ResultState : int
		{
			WaitStart = 0,
			Announcement = 1,
			TotalScores = 2,
			PersonalPerformance = 3,
			Tutorial = 4,
			Finish = 5,
		}
	}
}