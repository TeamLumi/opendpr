using System;

public class UnionSystemController
{
	private const int TRADE_OK_MEMBER_POKE_COUNT = 2;

	public UnionMsgSystemWindow unionMsgSystemWindow = new UnionMsgSystemWindow();
	public UnionContextMenu contextMenu;
	public OnlinePlayerCharacter onlinePlayer;
	private OpcState.OnlineState onlinePlayerSelectState;
	private OpcState.OnlineState fadeAfterSelectState;
	public Action<OpcState.OnlineState, NetStateModel.StateModelType> createModel;
	public Action<OpcState.OnlineState> SendState;
	public Action OnTalkEnd;
	public Action<int> sendEndSpokeData;
	public Action<int, byte> _requestNetData;
	private Action<int> _setDefaltCancelFunc;
	private Action<int> _startGreetingsFunc;
	private int targetStationIndex = -1;
	public int targetSexId;
	public bool isRecuruiment;
	public CommunicationTargetData targetData;

    public UnionStateTransitionController transitionController { get; set; }

    private byte PenaltyState;
	
	public void SetOnlinePlayerSelectState(OpcState.OnlineState state) {
	    this.onlinePlayerSelectState = state;
	}
	
	public OpcState.OnlineState GetOnlinePlayerSelectState() {
	    return onlinePlayerSelectState;
	}
	
	public void SetFadeAfterSelectState(OpcState.OnlineState state) {
	    this.fadeAfterSelectState = state;
	}
	
	public OpcState.OnlineState GetFadeAfterSelectState() {
	    return fadeAfterSelectState;
	}
	
	// TODO
	public void SetTargetStationIndex(int index, int cassetVersion = -1, bool isTalkEnd = true) { }
	
	public int GetTargetStationIndex() {
	    return targetStationIndex;
	}
	
	public UnionSystemController()
	{
		unionMsgSystemWindow = new UnionMsgSystemWindow();
	}
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void CreateTargetData(int index, OpcState.OnlineState state, int id, bool isRecruiment) { }
	
	// TODO
	public void SetOnlinePlayerCharacter(OnlinePlayerCharacter onlinePlayerCharacter) { }
	
	// TODO
	public void MessageFinishChangeOpcState(OpcState.OnlineState state) { }
	
	// TODO
	public void MessageFinishChangeOpcState(OpcState.OnlineState state, OpcState.OnlineState fadeAfterState) { }
	
	// TODO
	public void ChangeOpcState(OpcState.OnlineState state) { }
	
	// TODO
	public void StartMsgBattle() { }
	
	// TODO
	public void StartMsgGreeting(Action<int> startGreetings) { }
	
	// TODO
	public void SetSystemMessageBattle() { }
	
	// TODO
	public void SetSystemMessageTrade() { }
	
	// TODO
	public void SetSystemMessageGreeting() { }
	
	// TODO
	public void SetSystemMessageBallDeco() { }
	
	// TODO
	public void SetSystemMessageCommunicate() { }
	
	// TODO
	public void SetSystemMessageNowBattle() { }
	
	// TODO
	public void SetSystemMessageNowTrade() { }
	
	// TODO
	public void SetSystemMessageNowRecord() { }
	
	// TODO
	public void SetSystemMessageNowGreetings() { }
	
	// TODO
	public void SetSystemMessageNowBallDecoration() { }
	
	// TODO
	private void GetRandomLabelFile(ref string[] labelFile, int num) { }
	
	// TODO
	public void OpenMessageTalkBattle(int sexId) { }
	
	// TODO
	public void OpenMessageTalkTrade(int sexId) { }
	
	// TODO
	public void OpenMessageTalkRecode(int sexId) { }
	
	// TODO
	public void OpenMessageTalkGreeting(int sexId) { }
	
	// TODO
	public void OpenMessageTalkBallDeco(int sexId) { }
	
	// TODO
	public void SetTradeErrorMesage() { }
	
	// TODO
	public void StartOpenGreetingMsgWindow(int stationIndex, int sexId, int cassetVersion) { }
	
	// TODO
	public void OpenSystemMsgWindow(int index, UnionTextData.SpeakerID speakerID = UnionTextData.SpeakerID.SYSTEM) { }
	
	// TODO
	public void CloseSystemMsgWindow() { }
	
	// TODO
	public void OpenYesNoWindowRecruiment() { }
	
	// TODO
	public void SetNetworkErrorMessage() { }
	
	// TODO
	public void RusultGreetJoinYesNoWindow() { }
	
	// TODO
	public void RusultGreetRecruimentYesNoWindow(int selectIndex) { }
	
	// TODO
	public void RusultGreetJoinYesNoWindow(int selectIndex) { }
	
	// TODO
	public bool CheckErrorMessageTrade() { return default; }
	
	// TODO
	public bool CheckBallDeco() { return default; }
	
	// TODO
	public void SetEndSpokeEndData(Action<int> endSpokeData) { }
	
	// TODO
	public void SetRequestData(Action<int, byte> requestData) { }
	
	// TODO
	public void SetIsRecruiment(bool recruiment) { }
	
	// TODO
	private void PlayerInputEnabled() { }
	
	// TODO
	private void PlayerInputDisabled() { }
	
	// TODO
	public void SetDefaltCancelFunc(Action<int> func) { }
	
	// TODO
	public void SetCallbackCommunication(Action<int, OpcState.OnlineState, bool> startCommunicationFunc) { }
	
	// TODO
	private void PenaltyErrorMsgUpdate(float time) { }

	public struct CommunicationTargetData
	{
		public int stationIndex;
		public OpcState.OnlineState state;
		public int sexId;
		public bool isRecruiment;
		
		public CommunicationTargetData(int index, OpcState.OnlineState opcState, int sexID, bool isRec)
		{
			stationIndex = index;
			state = opcState;
			sexId = sexID;
			isRecruiment = isRec;
		}
	}
}