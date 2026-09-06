using Dpr.NetworkUtils;
using Dpr.UI;
using Pml.PokePara;
using System;
using System.Runtime.InteropServices;

public class TradeSelectPokeModel
{
	private Action<PokemonParam> _SendPokeParam;
	private Action<PokemonParam> _SetTargetSelectPokeData;
	private Action<UnionTradeManager.BoxPokeData> _SetBoxData;
	private Action _Cancel;
	private Action _Error;
	private Action _OpenErrorDialog;
	private Action _LeaveUnion;
	private int tradeTargetIndex;
	private BoxWindow boxWindow;
	private BoxWindow.SelectedPokemon selectPokemon;
	private BoxWindow.NetTradePhase nextTradePhase;
	private PokemonParam targetPokemonParam;
	private PokemonParam targetDemoPokemonParam;
	private bool isRecivePokeParam;
	private bool isSendPokeParam;
	private bool isTrading;
	private bool isWaitingOK;
	private bool isWaitingSelect;
	private TradeStateModel.TradeState myTradeState;
	private TradeStateModel.TradeState targetTradeState;
	private TradeSelectState currentState;
	public UnionTradeManager.TargetTranerParam targetTranerParam;
	
	// TODO
	public void Init() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	private void CheckCloseUIWindowOnErrorDialog() { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void InitParam() { }
	
	// TODO
	public void SetCallback(Action<PokemonParam> send, Action<PokemonParam> setTargetSelectPokeData, Action<UnionTradeManager.BoxPokeData> setBoxData, Action cancal, Action error, Action openErrorDiaolog, [Optional] Action leaveUnion) { }
	
	// TODO
	public void ClearCallback() { }
	
	public void SetStationIndex(int index) {
	    this.tradeTargetIndex = index;
	}
	
	public int GetStationIndex() {
	    return tradeTargetIndex;
	}
	
	// TODO
	public void SetTargetPokeParam(PokemonParam param) { }
	
	// TODO
	public void SetTargetDemoPokeParam(PokemonParam param) { }
	
	public void SetIsRecivePokeParam(bool isRecive) {
	    this.isRecivePokeParam = isRecive;
	}
	
	public void SetIsSendPokeParam(bool isSend) {
	    this.isSendPokeParam = isSend;
	}
	
	public bool GetIsSendPokeParam() {
	    return isSendPokeParam;
	}
	
	// TODO
	private bool IsOpenModelView() { return default; }
	
	public TradeStateModel.TradeState GetMyTradeState() {
	    return myTradeState;
	}
	
	public TradeStateModel.TradeState GetTargetTradeState() {
	    return targetTradeState;
	}
	
	public void SetTradeSelectState(TradeSelectState state) {
	    this.currentState = state;
	}
	
	public void SetNextTradePhase(BoxWindow.NetTradePhase phase) {
	    this.nextTradePhase = phase;
	}
	
	public TradeSelectState GetTradeSelectState() {
	    return currentState;
	}
	
	// TODO
	public BoxWindow GetBoxWindow() { return default; }
	
	// TODO
	public void SetTargetTranerParam(UnionTradeManager.TargetTranerParam param) { }
	
	// TODO
	public void SetBoxOppPlayerName() { }
	
	// TODO
	private void PokeSelectWait() { }
	
	// TODO
	private void TradePokeCheckOkWait() { }
	
	// TODO
	private UnionTradeManager.BoxPokeData SettingBoxPokeData(BoxWindow.SelectedPokemon selectData) { return default; }
	
	// TODO
	private void CheckComplete(BoxWindow window) { }
	
	// TODO
	private void BoxCloseComplete() { }
	
	// TODO
	private void BoxCloseCancel() { }
	
	// TODO
	private void BoxCloseError() { }
	
	// TODO
	public void BoxOpenError() { }
	
	// TODO
	public void OpenTradeBoxWindow(bool isFirst, UnionTradeManager.TargetTranerParam param) { }
	
	// TODO
	private void OnSelectBoxPoke(BoxWindow window, bool isReceived) { }
	
	// TODO
	public void OnFinishTrade() { }
	
	// TODO
	public void SetBoxMessage(BoxWindow window, string messageId) { }
	
	// TODO
	private void TradeCheckPokeResult(ValidateCheckResult checkResult) { }
	
	// TODO
	private void SendRequestPokeData() { }
	
	// TODO
	private void SendRequestCancelData() { }
	
	// TODO
	private void SendCancel() { }
	
	// TODO
	public void SendReadyOk(TradeStateModel.TradeState state) { }
	
	// TODO
	private void MyReadyOk() { }
	
	// TODO
	public void SendReturnSelectPoke(bool received = false) { }
	
	// TODO
	public void SendTradePokeCheckOk() { }
	
	// TODO
	private void ResetTradeState() { }
	
	// TODO
	public void ReciveReadyOk(NetDataTradeReadyOkData data) { }
	
	// TODO
	public void ReciveCancel(NetDataCurrentFlowCancelData data) { }
	
	// TODO
	public void ReciveReturnSelectPoke(NetDataReturnSelectData data) { }
	
	// TODO
	public void ReciveTradePokeCheckOk(NetDataTradePokeCheckOkData data) { }
	
	// TODO
	private void CloseUIWindow() { }
	
	// TODO
	private string GetCheckTargetName() { return default; }

	public enum TradeSelectState : int
	{
		NONE = 0,
		WAIT = 1,
		COMPLETE = 2,
		CANCAL_MINE = 3,
		CANCAL_OTHER = 4,
		ERROR_MINE = 5,
		ERROR_OTHER = 6,
	}
}