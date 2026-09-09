using System;

public class NetStateModel
{
	public int nowStateID { get; protected set; }
	public bool isOtherWaiting { get; protected set; }

    private Action<CancelModel> OnCancel;
    public Action OnCancelCallBack;
    public CancelModel currentCancelModel;

    public UnionMsgBattleWindow unionMsgBattleWindow { set; get; }
	public UnionBaseMsgWindow msgWindow { get; set; }

    public bool isTalkStateEnd;

    // TODO
    protected virtual void Start() { }
	
	// TODO
	protected virtual void MyUpdate(float deltaTime) { }
	
	// TODO
	public void SetState(int stateID, Action<CancelModel> OnCancel, bool isOtherWaiting) { }
	
	// TODO
	public void Cancel(CancelModel model) { }
	
	// TODO
	public void SetCancelModel(CancelModel cancelModel) { }
	
	// TODO
	public bool IsOtherPlayerCheck() { return default; }
	
	// TODO
	public virtual void EnablePlayerInputActive() { }
	
	// TODO
	public virtual void CloseWindow() { }
	
	// TODO
	public virtual void OpenSwitchCancelMsg(bool isCancel) { }
	
	public virtual bool IsCancelable() {
	    return true;
	}

	public enum StateModelType : int
	{
		RECRUITMENT = 0,
		JOIN = 1,
	}

	public enum TradeJoinState : int
	{
		NONE = 0,
		WAIT = 1,
		CANCEL_MINE = 2,
		CANCEL_OPPONENT = 3,
		TRADE = 4,
	}

	public enum TradeRecruitmentState : int
	{
		NONE = 0,
		TRADE_RECRUITMENT = 1,
		SELECT = 2,
		CANCEL_MINE = 3,
		CANCEL_OPPONENT = 4,
		TRADE = 5,
	}
}