using Dpr.NetworkUtils;
using Pml.PokePara;
using System;
using System.Runtime.InteropServices;

public class TradeStateModel
{
	private const int INVALID_INDEX = -1;
	private const int WAIT_RND_TIME_MAX = 30;

	protected int targetStationIndex;
	public PokemonParam myPokeData;
	public PokemonParam targetPokeData;
	protected PokemonParam myPokeParam;
	protected PokemonParam targetPokeParam;
	protected PokemonParam myPokeCopyData;
	private UnionTradeManager.BoxPokeData evolvedTargetPokeParam;
	public TradeSecurityStateMessageWindow msgWindow;
	protected Action errorFunc;
	protected Action disconnectFunc;
	protected Action initFunc;
	protected Action<int, bool> openTradeBoxWindow;
	protected Action<UnionTradeManager.TradeFlowState> setTradeFlowState;
	public TradeState currentState;
	public TradeState targetState;
	public bool targetIsTradeReadyOk;
	public TradeSecurityController.TradeParent tradeParent;
	private uint myPokeUniqeId;
	private uint targetPokeUniqeId;
	private UnionTradeManager.BoxPokeData boxPokeData;
	private UnionTradeManager.TargetTranerParam targetTranerParam;
	private bool IsGetMonsNo;
	private bool IsGetEvolvedMonsNo;
	public int waitRndTime;
	
	// TODO
	public virtual void Init() { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void FirstSave() { }
	
	// TODO
	public void SecondSave() { }
	
	// TODO
	public void DisconnectVictim_ResetSave() { }
	
	// TODO
	public void PlayerSave() { }
	
	// TODO
	public void SetInitCallBack(Action func, Action<int, bool> startOpenTradeBoxWindow, Action<UnionTradeManager.TradeFlowState> setState) { }
	
	public void SetTargetTransitionIndex(int index) {
	    this.targetStationIndex = index;
	}
	
	public int GetTargetTransitionIndex() {
	    return targetStationIndex;
	}
	
	// TODO
	public void SetTargetTranerParam(UnionTradeManager.TargetTranerParam param) { }
	
	// TODO
	public void SetTragetPokeData(PokemonParam pokemonParam) { }
	
	// TODO
	public void SetBoxPokeData(UnionTradeManager.BoxPokeData boxPoke) { }
	
	public void SetTradeParent(TradeSecurityController.TradeParent parentState) {
	    tradeParent = parentState;
	}
	
	public TradeSecurityController.TradeParent GetTradeParent() {
	    return tradeParent;
	}
	
	// TODO
	protected virtual void SendPokeData() { }
	
	// TODO
	protected virtual void RecivePokeData(byte[] pokeData) { }
	
	// TODO
	public virtual void SendTradeState() { }
	
	// TODO
	protected virtual void WriteSaveData() { }
	
	// TODO
	public bool CheckReplacePokeData() { return default; }
	
	// TODO
	public void InitState() { }
	
	// TODO
	public virtual void OnUpdate(float deltaTime) { }
	
	// TODO
	public void PlayTradeDemo() { }
	
	// TODO
	private void ReturnTradePokeSelectWindow() { }
	
	public void SetNetModelState(TradeState tradeState) {
	    this.currentState = tradeState;
	}
	
	public TradeState GetCurrentTradeState() {
	    return currentState;
	}
	
	// TODO
	public bool IsTargetPokeData() { return default; }
	
	// TODO
	public bool IsShowFatalError() { return default; }
	
	// TODO
	public bool CheckNetworkConnect() { return default; }
	
	// TODO
	public void OpenErrorMessage([Optional] ErrorAppletResult errorAppletResult) { }
	
	// TODO
	public bool IsNetworkCheck() { return default; }
	
	// TODO
	private void TradeCancelReturn() { }
	
	// TODO
	public void ReplacePoke() { }
	
	// TODO
	private void SetPlayReport() { }
	
	// TODO
	public TradeStateModel() { }

	public enum TradeState : int
	{
		NONE = 0,
		INIT = 1,
		WAIT = 2,
		SEND_POKE = 3,
		WAIT_POKE = 4,
		SEND_READYOK = 5,
		WAIT_READYOK = 6,
		START_WRITE_SAVE = 7,
		WRITEING_SAVE = 8,
		END_SAVE = 9,
		END = 10,
		ERROR = 11,
	}
}