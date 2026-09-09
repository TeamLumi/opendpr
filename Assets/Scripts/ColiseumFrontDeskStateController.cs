using SmartPoint.AssetAssistant;
using System;

public class ColiseumFrontDeskStateController : SingletonMonoBehaviour<ColiseumFrontDeskStateController>
{
	private static readonly string UNION_ROOM_MANAGER = "UnionRoomManager";
	private const int MESSAGE_INDEX_TRADE_DESCRIPTION = 1;
	private const int MESSAGE_INDEX_TRADE_TIMEOUT = 3;
	private static bool IsStart;
	public bool isTalkEnd = true;
	public bool isNotFirst = true;
    public bool isFirstInternetCheck = true;
    public bool isInternet;
	public bool isMultiBattleRoom;
	private UnionFrontDeskMsgWindow msgWindow;
	private UnionFrontDeskContextMenu contextMenu;
	private UnionFrontDeskMsgWindow ruleMsgWindow;
	
	// TODO
	private void OnDestroy() { }
	
	// TODO
	public void Init() { }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void Cancel() { }
	
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
	private void OpenContextSelectChangeBattleRuleYesNoMenu() { }
	
	// TODO
	private void OpenContextYesNoMenu(Action<int> selectFunc) { }
	
	// TODO
	private void FindTradePlayer() { }
	
	// TODO
	private void SelectContextMenuRequirements(int selectIndex) { }
	
	// TODO
	private void SelectContextMenuBattleRuleLocal(int selectIndex) { }
	
	// TODO
	private void SelectContextMenuBattleRuleInternet(int selectIndex) { }
	
	// TODO
	private void SelectChangeBattleRuleCheck(int select) { }
	
	// TODO
	private void InternetCheck() { }

	public enum FrontDeskNpcState : int
	{
		NONE = 0,
		START = 1,
		CHANGE_CONNECT = 2,
		DESCRIPTION = 3,
		TALK = 4,
	}
}