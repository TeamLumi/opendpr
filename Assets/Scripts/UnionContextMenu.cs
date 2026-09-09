using Dpr.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnionContextMenu
{
	protected static readonly Vector2 CONTEXT_RECRUITMENT_MENU_POSITION = new Vector2(720.0f, 260.0f);
	protected static readonly Vector2 CONTEXT_BATTLE_MENU_POSITION = new Vector2(680.0f, 280.0f);
    protected static readonly Vector2 CONTEXT_START_MENU_POSITION = new Vector2(680.0f, 280.0f);
    private static int UNION_MSG_INDEX = 1;

	public Action<int> _UnionMenuSelect;
	public Action<int, int> _BattleRuleSelect;
	public Action _Fade;
	public Action _LeaveUnion;
	public Action<OpcState.OnlineState, NetStateModel.StateModelType> _CreateStateModel;
	protected string messageFileName;
	protected List<string> _menuMessageList = new List<string>();
	protected ContextMenuWindow contextMenuWindow;
	protected int transitionType;
	private bool isContextOpen;
	private ZoneID zoneID;
	private Vector3 returnPosition;

	public UnionSystemController systemController { set; get; }
	
	public UnionContextMenu()
	{
		// Empty, explicitly declared
	}
	
	// TODO
	public void Clear() { }
	
	public void SetZoneID(ZoneID zoneId) {
	    zoneID = zoneId;
	}
	
	// TODO
	public void SetCallBack(Action leaveUnion, Action<OpcState.OnlineState, NetStateModel.StateModelType> createStateModel) { }
	
	// TODO
	public string GetUnionMenuText(int index) { return default; }
	
	// TODO
	public void CreateContextMenu(OnlinePlayerCharacter onlinePlayerCharacter) { }
	
	// TODO
	public void CreateEmoticonSelctContextMenu(OnlinePlayerCharacter onlinePlayerCharacter, string mFileName, string[] MenuMessagesList) { }
	
	// TODO
	public void CreateContextBattleTypeMenu(OnlinePlayerCharacter onlinePlayerCharacter) { }
	
	// TODO
	private void SendStateData(OnlinePlayerCharacter onlinePlayerCharacter, OpcState.OnlineState state) { }
	
	// TODO
	protected void SendTransitionData(int targetIndex, int isRecruitment = 0) { }
	
	// TODO
	protected void SendCancelData(int targetIndex, OpcState.OnlineState state) { }
	
	// TODO
	public void ShowYesNoWindow(Action<int> SelectFunc) { }
	
	// TODO
	public void CloseContextWindow() { }
	
	public ContextMenuWindow GetOpenMenu() {
	    return contextMenuWindow;
	}
	
	private void SetIsOpen(bool isOpen) {
	    isContextOpen = isOpen;
	}
	
	// TODO
	public bool IsOpen() { return default; }
	
	// TODO
	public void SetUnderModeInputActive() { }

	public struct ContextMenuData
	{
		public string messageFileName;
		public string[] messageList;
		public Vector2 menuPosition;
		public float minItemWidth;
		public bool isChangeSelectFrame;
		public ContextMenuWindow.CursorType cursorType;
		public bool useLoopAndRepeat;
	}

	public enum RecruitmentMenu : int
	{
		BATTLE = 0,
		TRADE = 1,
		RECODE = 2,
		GREETINGS = 3,
		BALL_DECO = 4,
		NONE = 5,
	}

	public enum BattleType : int
	{
		SINGLE = 0,
		DOUBLE = 1,
		MIX = 2,
		MULTI = 3,
		NONE = 4,
	}
}