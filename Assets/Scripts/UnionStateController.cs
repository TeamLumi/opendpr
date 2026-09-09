using DPData;
using Dpr.BattleMatching;
using Dpr.NetworkUtils;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnionStateController
{
	private UnionMsgBattleWindow BattleMsgWindow;
	private UnionMsgTradeWindow TradeMsgWindow;
	private UnionMsgRecodeWindow RecodeMsgWindow;
	private UnionMsgGreetingsWindow GreetingsMsgWindow;
	private UnionMsgBallDecoWindow BallDecoMsgWindow;
	private BattleRecruitmentStateModel battleRecruitmentModel;
	private BattleJoinStateModel battleJoinStateModel;
	private TradeRecruitmentStateModel tradeRecruitmentStateModel;
	private TradeJoinStateModel tradeJoinStateModel;
	private RecodeRecruitmentStateModel recodeRecruitmentStateModel;
	private RecodeJoinStateModel recodeJoinStateModel;
	private GreetingsRecruitmentStateModel greetingsRecruitmentStateModel;
	private GreetingsJoinStateModel greetingsJoinStateModel;
	private BallDecoRecruitmentStateModel ballDecoRecruitmentStateModel;
	private BallDecoJoinStateModel ballDecoJoinStateModel;
	private NetStateModel _currentModel;
	public UnionSystemController systemController;
	private UnionContextMenu unionContextMenu;
	private NetDataTalkData talkData;
	public OnlinePlayerCharacter playerCharacter;
	public UnionOpcManager unionOpcManager;
	private Action StartFadeOut;
	public Action transitionFunc;
	private UnionStateTransitionController transitionController;
	public Action leaveUnion;
	public Action<int, byte> requestNetData;
	public Action sendIsTransitionAfter;
	public OpcState.OnlineState opcState;
	public List<UnionMatchWaitData> unionMatchWaitDataList;
	public List<UnionMatchWaitData> unionMatchWaitAllDataList;
	public bool isMultiMatchWait;
	private UnionBattleContextMenu unionBattleContextMenu;

	private const float autoCloseMsgWindowTime = 1.0f;

	private float _autoCloseMsgWindowProgressTime;
	[SerializeField]
	private GameObject _dMenu;
	[SerializeField]
	private CanvasGroup _canvasGroup;
	public UnionBattleRuleWindow unionBattleRuleWindow;
	private int debugTargetStationIndex = -1;
	
	// TODO
	public NetStateModel currentModel { get; set; }
	
	public UnionStateController(OnlinePlayerCharacter onlinePlayer, UnionOpcManager opcManager, ZoneID zoneID, Action leaveUnionRoom, Action<int, byte> request, Action sendTransitionAfterFunc)
	{
		playerCharacter = onlinePlayer;
		unionOpcManager = opcManager;
		requestNetData = request;
		leaveUnion = leaveUnionRoom;
		sendIsTransitionAfter = sendTransitionAfterFunc;

		isMultiMatchWait = false;

		unionMatchWaitDataList = new List<UnionMatchWaitData>();
		unionMatchWaitAllDataList = new List<UnionMatchWaitData>();

		CreateContextMenu(zoneID);
		CreateSystemController();
	}
	
	// TODO
	public void SetCallBack(Action leaveUnionRoom, Action<int, byte> request, Action sendTransitionAfterFunc) { }
	
	// TODO
	private void OnTalkEnd() { }
	
	// TODO
	public void CreateTransitionController() { }
	
	// TODO
	private void OnEndFadeOut() { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void SetIsTransitionAfter(Action<bool> func) { }
	
	public UnionStateTransitionController GetTransitionController() {
	    return transitionController;
	}
	
	// TODO
	public bool IsOpenContextMenu() { return default; }
	
	// TODO
	private void CreateContextMenu(ZoneID zoneID) { }
	
	// TODO
	public void CreateSystemContextMenu() { }
	
	// TODO
	private void CreateSystemController() { }
	
	// TODO
	public void CloseWindow() { }
	
	// TODO
	public void CloseContextWindow() { }
	
	// TODO
	public void InitPlayerState() { }
	
	// TODO
	public void HideBattleStateWindow() { }
	
	// TODO
	private void SendSpokenData(int stationIndex) { }
	
	// TODO
	private void CreateTalkData() { }
	
	// TODO
	private void ChangeTalkData(TalkState talkState, int index) { }
	
	// TODO
	private void MessageEndSpokenData() { }
	
	// TODO
	private void ChangeJoinGreetings(int selectIndex) { }
	
	// TODO
	public void ClearTalkData() { }
	
	// TODO
	public bool IsMsgWindowOpen() { return default; }
	
	// TODO
	public void SetStartFadeOutCallBack(Action fadeFunc) { }
	
	// TODO
	private void CreateSelectStateMsgWindow() { }
	
	public BattleRecruitmentStateModel GetBattleRecruimentModel() {
	    return battleRecruitmentModel;
	}
	
	public BattleJoinStateModel GetBattleJoinModel() {
	    return battleJoinStateModel;
	}
	
	// TODO
	public NetStateModel GetTradeRecruimentModel() { return default; }
	
	// TODO
	public NetStateModel GetTradeJoinModel() { return default; }
	
	// TODO
	public NetStateModel GetRecodeRecruimentModel() { return default; }
	
	// TODO
	public NetStateModel GetRecodeJoinModel() { return default; }
	
	// TODO
	public NetStateModel GetGreetingRecruimentModel() { return default; }
	
	// TODO
	public NetStateModel GetGreetingJoinModel() { return default; }
	
	// TODO
	public NetStateModel GetBallDecoRecruimentModel() { return default; }
	
	// TODO
	public NetStateModel GetBallDecoJoinModel() { return default; }
	
	// TODO
	public void CreateSelectStateModel(OpcState.OnlineState state, NetStateModel.StateModelType stateModelType) { }
	
	// TODO
	public void DefaltTradeCancelModel(int index) { }
	
	// TODO
	public void DefaltBattleCancelModel(int index) { }
	
	// TODO
	public void DefaltRecodeCancelModel(int index) { }
	
	// TODO
	public void DefaltGreetingCancelModel(int index) { }
	
	// TODO
	public void DefaltBallDecoCancelModel(int index) { }
	
	// TODO
	public void CreateRecruitmentBattleCancelModel(int index = -1) { }
	
	// TODO
	private void CreateJoinBattleCancelModel(int index) { }
	
	// TODO
	private void CreateRecruitmentTradeCancelModel(int index) { }
	
	// TODO
	private void CreateJoinTradeCancelModel(int index) { }
	
	// TODO
	private void CreateRecruitmentRecodeCancelModel(int index) { }
	
	// TODO
	private void CreateJoinRecodeCancelModel(int index) { }
	
	// TODO
	private void CreateRecruitmentGreetingsCancelModel(int index) { }
	
	// TODO
	private void CreateJoinGreetingsCancelModel(int index) { }
	
	// TODO
	private void CreateRecruitmentBallDecoCancelModel(int index) { }
	
	// TODO
	private void CreateJoinBallDecoCancelModel(int index) { }
	
	// TODO
	public void SwitchTransitionMessage(int type, int sexId, int fromStationIndex, bool isRecruitment = false) { }
	
	// TODO
	public bool SwitchTalkStateMine(OpcState.OnlineState state, OpcController controller) { return default; }
	
	// TODO
	private void StartAutoCloseMsgWindow() { }
	
	// TODO
	private void CompleteAutoCloseMsgWindow() { }
	
	// TODO
	private void UpdateAutoCloseMsgWindow(float deltaTime) { }
	
	// TODO
	public void SwitchSpokenStateMine(int index, TalkState talkState) { }
	
	// TODO
	public void SwitchCancelEnd() { }
	
	// TODO
	public void SettingCurrentState(int targetStationIndex, OpcState.OnlineState onlineState, bool isRecruiment) { }
	
	// TODO
	public void StartCommunication(int targetStationIndex, OpcState.OnlineState onlineState, bool isRecruiment) { }
	
	// TODO
	public void SwitchTransitionAfterTalk(OpcState.OnlineState state, OpcController controller) { }
	
	// TODO
	public void ShowDebugMenu() { }
	
	// TODO
	public void HideDebugMenu() { }
	
	// TODO
	private OpcState.OnlineState GetSelectMenuOpcState(int id) { return default; }
	
	// TODO
	public void SetBattleStateWindowText(List<UnionMatchWaitData> matchWaitDataList, BattleModeID battleModeId) { }
	
	// TODO
	public void ShowBattleJoinYesNoMenu(int staIndex) { }
	
	// TODO
	public void Decide(int stationIndex) { }
	
	// TODO
	public void Cancel() { }
	
	// TODO
	private void ShowBattleStateWindow(List<UnionMatchWaitData> matchWaitDataList, BattleModeID battleModeId) { }
	
	// TODO
	public void SwitchBatttleStateTalk(int stationIndex, BattleModeID battleModeID) { }
	
	// TODO
	private void ShowJoinRecodeCheck(int targetStationIndex)
	{
		// TODO
		void OpenYesNoWindow() { }
    }
	
	// TODO
	public void ReciveIsMatchWait(NetDataIsMatchWaitData data) { }
	
	// TODO
	public void ReciveMatchWaitListData(NetDataStandbyWaitListData data) { }
	
	// TODO
	public void ReciveMatchWaitData(NetDataStandbyWaitData data) { }
	
	// TODO
	private void AddMacthPlayerData(int targetStationIndex) { }
	
	// TODO
	private void AddMacthPlayerDataInMine(int hostIndex, int joinPlayerIndex, int sendTargetIndex) { }
	
	// TODO
	public void AddMatchWait(UnionMatchWaitData waitData) { }
	
	// TODO
	public void RemoveMatchWait(int removeIndex) { }
	
	// TODO
	public void RemoveMatchWaitStationIndex(int stationIndex) { }
	
	// TODO
	public void ClearMatchWait() { }
	
	public List<UnionMatchWaitData> GetMatchWaitList() {
	    return unionMatchWaitDataList;
	}
	
	// TODO
	private void SendRequestIsMatchWait(int stationIndex) { }
	
	// TODO
	private void SendRequestMatchPlayerListData(int stationIndex) { }
	
	// TODO
	private void SendRequestBattleRule(int stationIndex) { }
	
	// TODO
	private void SendIsMatchWait() { }
	
	// TODO
	private void SendAddStanbyPlayer() { }
	
	// TODO
	private void SendRecodeData(RECORD recodeData, int targetStationIndex) { }
	
	// TODO
	private void SendStandbyPlayerData(int stationIndex) { }
	
	// TODO
	private void ClearMatchPlayerDataList() { }
}