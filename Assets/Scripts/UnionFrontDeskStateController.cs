using SmartPoint.AssetAssistant;
using System;

public class UnionFrontDeskStateController : SingletonMonoBehaviour<UnionFrontDeskStateController>
{
	private static readonly ZoneID ZONE_COMMUNITY = ZoneID.UNION01;
	private static readonly ZoneID ZONE_GLOBAL = ZoneID.UNION02;
    private static readonly string UNION_ROOM_MANAGER = "UnionRoomManager";

	private const int MESSAGE_INDEX_TRADE_DESCRIPTION = 1;
	private const int MESSAGE_INDEX_TRADE_TIMEOUT = 3;

	private static bool IsStart;
	public bool isTalkEnd = true;
	public bool isNotFirst = true;
    public bool isFirstInternetCheck = true;
    private UnionFrontDeskMsgWindow msgWindow;
	private UnionFrontDeskContextMenu contextMenu;
	private ZoneID currentZoneID;
	public UnionRoomManager roomManager;
	public UnionStateTransitionController transitionController;
	public Action _FadeOut;
	public Action _OpenTradeSelectWindow;
	
	public bool isGlobal { get => PlayerWork.zoneID == ZONE_GLOBAL; }
	
	// TODO
	public void Init() { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void SetFade(UnionStateTransitionController controller) { }
	
	// TODO
	public void SetOpenTradeWindow(Action<int, bool> openSelectWindow) { }
	
	// TODO
	public void SetSendRequet(Action func) { }
	
	// TODO
	public void TimeOut() { }
	
	// TODO
	public void Cancel() { }
	
	// TODO
	private void Close() { }
	
	// TODO
	private void StartMessage() { }
	
	// TODO
	public void StartTalk() { }
	
	// TODO
	public void CreateUI() { }
	
	// TODO
	public void SetIsStart(bool start) { }
	
	// TODO
	public bool GetIsStart() { return default; }
	
	// TODO
	public void TalkEnd() { }
	
	public void SetIsTalkEnd(bool isEnd) {
	    this.isTalkEnd = isEnd;
	}
	
	public bool GetIsTalkEnd() {
	    return isTalkEnd;
	}
	
	// TODO
	private void TalkMessageRequirements() { }
	
	// TODO
	private void OpenContextSelectInternetYesNoMenu() { }
	
	// TODO
	private void OpenContextSelectTradeYesNoMenu() { }
	
	// TODO
	private void OpenContextYesNoMenu(Action<int> selectFunc) { }
	
	// TODO
	private void FindTradePlayer() { }
	
	// TODO
	public void Transition() { }
	
	// TODO
	private void SelectContextMenuRequirements(int selectIndex) { }
	
	// TODO
	private void SelectContextMenuDescription(int selectIndex) { }
	
	// TODO
	private void SelectContextMenuInternetMode(int selectIndex) { }
	
	// TODO
	private void SelectInternetCheck(int select) { }
	
	// TODO
	private void SelectTradeStart(int select) { }
	
	// TODO
	public void ChangeInternetMode() { }
	
	// TODO
	public bool CheckPenarty() { return default; }
	
	// TODO
	private void SwitchMessageTrade() { }
	
	// TODO
	private void InternetCheck() { }
	
	// TODO
	private void StartTransition() { }

	public enum FrontDeskNpcState : int
	{
		NONE = 0,
		START = 1,
		CHANGE_CONNECT = 2,
		DESCRIPTION = 3,
		TALK = 4,
	}
}