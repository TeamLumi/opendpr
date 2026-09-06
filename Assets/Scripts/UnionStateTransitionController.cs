using Dpr.BattleMatching;
using Dpr.NetworkUtils;
using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;

public class UnionStateTransitionController
{
	private const float INIT_FADE_TIME = 1;
	public OpcState.OnlineState transitionState;
	private int targetIndex;
	private float _FadeInTime = 1.0f;
	private bool isFadeOut;
	private bool isFadeOutEnd;

    public UnionSystemController systemController { get; set; }

    private Action closeWindowCallback;
	private Action initPlayerStateCallback;
	private Action initMatchingCallback;
	private Action<bool> setisTransitionAfter;
	private Action sendTransitionAfter;
	private bool isRecruiment;
	private List<UnionMatchWaitData> stanbyWaitDataList;
	public UnionTradeManager tradeManager;
	public BattleMatchingManager battleMatchingManager;
	public RecodeMatching recodeMatchingManager = new RecodeMatching();
	public BallDecoMatching balldecoMatchingManager = new BallDecoMatching();
	public Action OnEndFadeOut;
	public Func<bool> CreateUI;
	private bool _isClearCall;
	public bool isFade;
	
	public UnionStateTransitionController()
	{
		Sequencer.update -= MyUpdate;
		Sequencer.update += MyUpdate;

		stanbyWaitDataList = new List<UnionMatchWaitData>();
		_isClearCall = false;
	}
	
	// TODO
	private void MyUpdate(float deltaTime) { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void SetCallback(Action closeWindow, Action initPlayerState, Action sendTransitionAfterFunc, Action startRecodeTradeFunc) { }
	
	// TODO
	public void SetIsTransitionAfter(Action<bool> func) { }
	
	// TODO
	private void RemoveCallback() { }
	
	// TODO
	public void SetTradeManager(UnionTradeManager manager) { }
	
	// TODO
	public void SetBattleMatchingManager(BattleMatchingManager manager) { }
	
	public void SetTransitionState(OpcState.OnlineState onlineState) {
	    this.transitionState = onlineState;
	}
	
	public void SetIsRecruiment(bool flag) {
	    this.isRecruiment = flag;
	}
	
	// TODO
	public void SetStanbyWaitDataList(List<UnionMatchWaitData> unionMatchWaitDatas) { }
	
	// TODO
	public void AddStanbyData(UnionMatchWaitData data) { }
	
	// TODO
	public int GetStationIndex() { return default; }
	
	// TODO
	public void StartFadeOut() { }
	
	// TODO
	public void StartFadeIn() { }
	
	// TODO
	public void ResetBattleMachingReceiveData() { }
	
	// TODO
	public void TransitionBattle() { }
	
	// TODO
	public void TransitionTradePoke() { }
	
	// TODO
	public void TransitionMixRecode() { }
	
	// TODO
	public void TransitionShowTrainerCard() { }
	
	// TODO
	public void TransitionTradeBallDeco() { }
	
	// TODO
	private void SwitchTransition() { }
	
	// TODO
	private void SendTranerData(int index) { }
	
	// TODO
	private void SendOpcStateData() { }
	
	// TODO
	private void CheckSendIsMatchWait(OpcState.OnlineState state) { }
	
	// TODO
	private void CreateUIRecodeMatching() { }
	
	// TODO
	public void ReceiveRecodeData(INetData netData) { }
	
	// TODO
	public void RecodeLeaveMine() { }
	
	// TODO
	public void RecodeLeaveOther() { }
	
	// TODO
	public void InitRecodeData() { }
	
	// TODO
	public void RecodeForceClose() { }
	
	// TODO
	private void CreateUIBallDecoMatching() { }
	
	// TODO
	public void ReceiveBallDecoData(INetData netData) { }
	
	// TODO
	public void BallDecoLeaveMine() { }
	
	// TODO
	public void BallDecoLeaveOther() { }
	
	// TODO
	public void InitBallDecoData() { }
	
	// TODO
	public void BallDecoForceClose() { }
	
	public bool GetIsFade() {
	    return isFade;
	}
}