using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SequenceEditor;
using INL1;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Contest
{
	public class ContestController : MonoBehaviour
	{
		private const float LIMIT_TIMEOUT = 10.0f;

		private ReceivedPlayerResultScore[] receivedScores;
		private ContestMatchingNetwork network = new ContestMatchingNetwork();
		private WaitTimer waitTimer;
		private bool bCanStartContest;
		private bool bIsRecieveWaitTime;
		private bool canSectionUpdate = true;
		private bool bIsStartMultiContest;
		[SerializeField]
		private Camera wazaCamera;
		private SceneObjectManager objectManagerPtr;
		private OpeningSection openingSection;
		private VisualSection visualSection;
		private DanceSection danceSection;
		private ResultSection resultSection;
		private ContestDataModel dataModel = new ContestDataModel();
		private SceneResourceLoader resourceLoader = new SceneResourceLoader();
		private ContestViewSystem contestViewSystem = new ContestViewSystem();
		private ContestViewSystem wazaViewSystem = new ContestViewSystem();
		private SectionID currentSectionID;
		private SectionID nextSectionID;
		private ResultDataModel resultDataModel;
		private bool hasRequestChangeSectionID;
		
		// TODO
		private void InitMultiMode() { }
		
		private void StartNetworkContest()
		{
			this.bIsStartMultiContest = true;
		}
		
		// TODO
		private void SetupNetwork() { }
		
		// TODO
		private IEnumerator IE_ActivateMultiMode() { return default; }
		
		// TODO
		private bool CanStartNetworkContest() { return default; }
		
		private void OnChangeSectionToVisual()
		{
			ContestUtils.EmitLog(StringLiteral_8824,3);
			this.network.repeatSendSpanTimer.ResetTimer();
			this.network.SetAllMainFlag();
			this.network.SetAllSubFlag();
		}
		
		// TODO
		private void UpdateWaitAsync() { }
		
		// TODO
		private void UpdateNetworkError() { }
		
		// TODO
		private void OnChangeSectionWaitAsync() { }
		
		// TODO
		private void ApplyReceivedPlayerResultScore() { }
		
		// TODO
		private void OnRecievePacket(byte dataID, PacketReader pr) { }
		
		// TODO
		private void OnReceiveNotice(NoticeNetData noticeData) { }
		
		private void OnSessionEvent(SessionEventData result)
		{
			switch((int)((ulong)result >> 0x20)) {
			case 3:
			  OnChangeHostMine();
			  break;
			default:
			case 6:
			  OnLeaveOtherPlayer();
			  break;
			case 7:
			case 8:
			  OnSessionError();
			  break;
			case 9:
			  this.network.ReleaseNetworkCallback();
			  OnSessionError();
			  break;
			}
		}
		
		// TODO
		private void OnLeaveOtherPlayer(int stationIndex) { }
		
		private bool IsGaming()
		{
			return (int)this.currentSectionID < 3;
		}
		
		private void ChangeAllOtherPlayerToNPC()
		{
			this.danceSection.OnLeaveOtherPlayer(0);
			this.danceSection.OnLeaveOtherPlayer(1);
			this.danceSection.OnLeaveOtherPlayer(2);
			this.danceSection.OnLeaveOtherPlayer(3);
		}
		
		private void OnChangeHostMine()
		{
			if (this.bIsStartMultiContest) {
			  var uVar1 = Dpr_NetworkUtils_NetworkManager__IsGamerActive
			                    (this.network.networkManager,0,0);
			  if ((uVar1 & 1) == 0) {
			    this.danceSection.OnLeaveOtherPlayer(0);
			  }
			  uVar1 = Dpr_NetworkUtils_NetworkManager__IsGamerActive
			                    (this.network.networkManager,1,0);
			  if ((uVar1 & 1) == 0) {
			    this.danceSection.OnLeaveOtherPlayer(1);
			  }
			  uVar1 = Dpr_NetworkUtils_NetworkManager__IsGamerActive
			                    (this.network.networkManager,2,0);
			  if ((uVar1 & 1) == 0) {
			    this.danceSection.OnLeaveOtherPlayer(2);
			  }
			  uVar1 = Dpr_NetworkUtils_NetworkManager__IsGamerActive
			                    (this.network.networkManager,3,0);
			  if ((uVar1 & 1) == 0) {
			    this.danceSection.OnLeaveOtherPlayer(3);
			  }
			  this.danceSection.OnChangeHostMine();
			}
		}
		
		// TODO
		private void OnChangeHostOtherPlayer() { }
		
		// TODO
		private void OnSessionError() { }
		
		// TODO
		private void OnFinishedSession() { }
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		public IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private void CloseUIWindow() { }
		
		// TODO
		private IEnumerator IE_LoadScenePrefabs(Transform cluster) { return default; }
		
		// TODO
		private void SceneInitialize() { }
		
		// TODO
		private IEnumerator IE_LoadMasterDatas() { return default; }
		
		// TODO
		private void SystemInitialize() { }
		
		// TODO
		private IEnumerator IE_PreLoadResource(Transform cluster) { return default; }
		
		// TODO
		private void AppendLoadNotesData() { }
		
		// TODO
		private void AppendOpeningResource() { }
		
		// TODO
		private void AppendLoadModel(Transform cluster) { }
		
		// TODO
		private void LoadMainSequence() { }
		
		// TODO
		private void LoadWazaSequence() { }
		
		// TODO
		private void SetupUITexture() { }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void PrevSetup() { }
		
		// TODO
		private IEnumerator IE_Start() { return default; }
		
		// TODO
		private void AfterSetup() { }
		
		// TODO
		private void OnDestroy() { }
		
		private void StartContest()
		{
			this.bIsStartMultiContest = true;
			ChangeSectionOpening();
		}
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		private bool IsCompleteSection { get => currentSectionID == SectionID.End; }
		
		// TODO
		private void FinishedContest() { }
		
		private void UpdateSection(float deltaTime, float elapsedTime)
		{
			switch(this.currentSectionID) {
			case 0:
			  if (((((this.openingSection.UpdateSection() & 1) == 0) &&
			       (this.openingSection.UpdateSection() = DanceSection.IsReady(this.danceSection),
			       (this.openingSection.UpdateSection() & 1) != 0)) && (this.wazaViewSystem.ready != 0)) &&
			     ((this.contestViewSystem.ready != 0 &&
			      (this.openingSection.UpdateSection() = SceneObjectManager.get_IsReady(this.objectManagerPtr),
			      (this.openingSection.UpdateSection() & 1) != 0)))) {
			    RequestChangeSectionId(1);
			  }
			  break;
			case 1:
			  if ((this.visualSection.UpdateSection() & 1) == 0) {
			    RequestChangeSectionId(2);
			  }
			  break;
			case 2:
			  UpdateDanceSection();
			  break;
			case 4:
			  UpdateWaitAsync();
			  break;
			case 5:
			  if ((this.resultSection.UpdateSection() & 1) == 0) {
			    if (this.resultSection.restartContest != 0) {
			      RequestChangeSectionId(6);
			    }
			    RequestChangeSectionId(8);
			  }
			  break;
			case 7:
			  UpdateNetworkError();
			  break;
			}
		}
		
		private void UpdateOpeningSection()
		{
			if (((((this.openingSection.UpdateSection() & 1) == 0) &&
			     (this.openingSection.UpdateSection() = DanceSection.IsReady(this.danceSection),
			     (this.openingSection.UpdateSection() & 1) != 0)) && (this.wazaViewSystem.ready != 0)) &&
			   ((this.contestViewSystem.ready != 0 &&
			    (this.openingSection.UpdateSection() = SceneObjectManager.get_IsReady(this.objectManagerPtr),
			    (this.openingSection.UpdateSection() & 1) != 0)))) {
			  RequestChangeSectionId(1);
			}
		}
		
		private void UpdateVisualSection()
		{
			if ((this.visualSection.UpdateSection() & 1) != 0) {
			}
			RequestChangeSectionId(2);
		}
		
		// TODO
		private void UpdateDanceSection(float deltaTime, float elapsedTime) { }
		
		private void UpdateResultSection(float deltaTime)
		{
			if ((this.resultSection.UpdateSection() & 1) != 0) {
			}
			var uVar2 = 8;
			if (this.resultSection.restartContest != 0) {
			  uVar2 = 6;
			}
			RequestChangeSectionId(uVar2);
		}
		
		// TODO
		private IEnumerator IE_LoadResultResource() { return default; }
		
		// TODO
		private void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void DoNextSection() { }
		
		private void LateUpdateSection()
		{
			if ((int)this.currentSectionID == 2) {
			  this.danceSection.OnLateUpdate();
			}
		}
		
		// TODO
		private void ChangeSectionOpening() { }
		
		// TODO
		private void RequestChangeSectionId(SectionID newSectionId) { }
		
		// TODO
		private void OnFindCommand(CommandNo commandNo, ContestViewSystem viewSystem) { }
		
		private void LoadMigawariModel()
		{
			this.resourceLoader.LoadMigawariModel(0);
		}
		
		// TODO
		private void OnPerformedCommand(CommandNo commandNo, ContestViewSystem viewSystem, Macro macro) { }
		
		// TODO
		private void ForceStopContest() { }
		
		// TODO
		private IEnumerator IE_RestartContest() { return default; }
		
		// TODO
		private IEnumerator IE_ReloadTutorialSeq() { return default; }
		
		// TODO
		private IEnumerator IE_LoadTutorialResource() { return default; }
		
		// TODO
		private void ResetParam() { }
	}
}