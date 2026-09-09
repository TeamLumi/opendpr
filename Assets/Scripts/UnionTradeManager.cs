using Dpr.Message;
using Dpr.NetworkUtils;
using Pml.PokePara;
using System;
using System.Runtime.InteropServices;

public class UnionTradeManager
{
	private OnlinePlayerCharacter myPlayer;
	public TradeSecurityController securityController;

    public int tradeTargetIndex { get; private set; }

    public TradeSelectPokeModel tradeSelectModel;
	private BoxPokeData boxMyPokeData;
	private PokemonParam targetPokemonParam;
	private TargetTranerParam targetTranerParam;
	private PokemonParam selectMyPokemonParam;
	public bool isRecruiment;
	private TradeFlowMsgWindow msgWindow;
	public bool isError;

    public bool isLoadingBox { get; private set; }

    private Action _LeaveUnion;
	public TradeFlowState currentState;
	
	// TODO
	public void Init() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	public void SetTargetTranerParam(uint id, string name, int cassetVersion, MessageEnumData.MsgLangId langId) { }
	
	public void SetIsError(bool error) {
	    isError = error;
	}
	
	public bool GetIsError() {
	    return isError;
	}
	
	// TODO
	private void SetWaitMessage() { }
	
	// TODO
	public void CreateTradeSelectModel(Action reStartFunc, Action networkErrorFunc, Action leaveFunc) { }
	
	// TODO
	private void WaitBoxWindowComplete() { }
	
	// TODO
	public void SetBoxData(BoxPokeData boxData) { }
	
	// TODO
	public BoxPokeData GetBoxPokeData() { return default; }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void Cancel() { }
	
	// TODO
	public void Error() { }
	
	public TradeSelectPokeModel GetTradeSlectPokeModel() {
	    return tradeSelectModel;
	}
	
	public TradeFlowState GetCurrentState() {
	    return currentState;
	}
	
	// TODO
	public void NextState() { }
	
	public void SetCurrentState(TradeFlowState state) {
	    currentState = state;
	}
	
	public void SetTargetIndex(int index) {
	    tradeTargetIndex = index;
	}
	
	// TODO
	private void SetTargetConfirmPokeParam(PokemonParam param) { }
	
	public PokemonParam GetTargetConfirmPokeParam() {
	    return targetPokemonParam;
	}
	
	public void SetIsRecruiment(bool isRec) {
	    isRecruiment = isRec;
	}
	
	public PokemonParam GetSelectMyPokemonParam() {
	    return selectMyPokemonParam;
	}
	
	// TODO
	private void SendPokeParam(PokemonParam param) { }
	
	// TODO
	public void RecivePokeData(PokemonParam param) { }
	
	// TODO
	public void ReciveCancelData(NetDataCurrentFlowCancelData data) { }
	
	// TODO
	public void ReciveTradeReadyOkData(NetDataTradeReadyOkData data) { }
	
	// TODO
	public void ReciveReturnSelectPoke(NetDataReturnSelectData data) { }
	
	// TODO
	public void ReciveTradePokeCheckOk(NetDataTradePokeCheckOkData data) { }
	
	// TODO
	private void SetTargetTradePoke(PokemonParam param) { }
	
	// TODO
	public void SetSecurityTradeParam() { }
	
	// TODO
	private void SetTargetTradeDemoPoke(PokemonParam param) { }
	
	// TODO
	private void SettingSecurityControllerParam(int stationIndex, BoxPokeData boxPokeData) { }
	
	// TODO
	public void StartOpenTradeBoxWindow(int index, bool isFirst = true) { }
	
	// TODO
	public void InitPlayerState() { }
	
	// TODO
	public void OnFinishedTradeInternal() { }
	
	// TODO
	public void TradeError([Optional] ErrorAppletResult errorAppletResult) { }
	
	// TODO
	public void TradeSecurityError() { }
	
	// TODO
	public void TradeSelectError() { }
	
	// TODO
	public void CheckTragetNetworkError(int targetIndex) { }
	
	// TODO
	public void OnFatalError() { }
	
	// TODO
	public void SecurtyTradeClear() { }
	
	// TODO
	public void ResetSecurityTradeState() { }
	
	// TODO
	public void OpenTradeCancelMsg() { }
	
	// TODO
	public void CloseBoxMenuWindow() { }
	
	// TODO
	public void CloseStatusWindow() { }

	public struct BoxPokeData
	{
		public PokemonParam pokeParam;
		public bool isTeam;
		public int teamIndex;
		public int teamPos;
	}

	public class TargetTranerParam
	{
		public uint tranerId;
		public int cassetVersion;
		public MessageEnumData.MsgLangId langId;
		public string tranerName;
	}

	public enum TradeFlowState : int
	{
		NONE = 0,
		SELECT_WINDOW = 1,
		SECURIY_TRADE = 2,
		PLAY_DEMO = 3,
		END = 4,
	}
}