using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleRuleSelectWindow : UIWindow
{
	private const float WINDOW_CLOSE_TIME = 1.0f;

	[SerializeField]
	private UIText titleText;
	[SerializeField]
	private UIText detielText;
	private Action<BattleModeID> _onDecide;
	private Action _onCancel;
	private List<BattleModeID> battleModeIDList;
	private bool _decideSE;
	private int _currentIndex = -1;
	private WaitTimer waitTimer = new WaitTimer();
	private static readonly string[] BATTLE_RULE = new string[]
	{
        "DP_options_006", "DP_options_007", "DP_options_009"
    };
	private static readonly string[] BATTLE_RULE_NAIYOU = new string[]
    {
        "SS_net_live_comm_133", "SS_net_live_comm_134", "SS_net_live_comm_135"
    };

    // TODO
    public void Open(List<BattleModeID> battleMode, Action<BattleModeID> onDecide, Action onCancel, bool decideSE = false, UIWindowID prevWindowId = WINDOWID_FIELD) { }
	
	// TODO
	public void Close() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	public override void OnCreate() { }
	
	public int GetCurrentSelectIndex() {
	    return _currentIndex;
	}
	
	// TODO
	private void SetKeyguide() { }
	
	// TODO
	private void MoveSelectRule(bool right) { }
	
	// TODO
	private void SelectRule(int index) { }
	
	// TODO
	private int GetPrevIndex() { return default; }
	
	// TODO
	private int GetNextIndex() { return default; }
	
	// TODO
	private void DecideRule() { }
	
	// TODO
	private void Decide() { }
	
	// TODO
	private void Back() { }
	
	// TODO
	private string[] GetMsbtFileLabel(string label) { return default; }
}