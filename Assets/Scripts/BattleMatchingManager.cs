using Dpr.NetworkUtils;
using Dpr.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class BattleMatchingManager
{
	private UIBattleMatching _battleMatchingUI;
	private BattleMatchingRecruitmentMember _recruitmentMember;
	private BattleMatchingSelectTeamMember _selectTeamMember;
	private BattleMatchingSelectRule _selectRule;
	private BattleMatchingSelectBattleTeam _selectBattleTeam;
	private BattleMatchingSelectPokemon _selectPokemon;
	private BattleMatchingResult _result;
	private BattleMatchingResume _resume;
	private NetDataBattleMatchingCountDown _countDownData;
	private Queue<INetData> _loadingRecieveData;
	private Action _onFinish;
	private bool _isError;
	
	public bool IsError { get => _isError; }

	public int ColiseumLeavePoint { get; set; } = -1;

    private bool _dispColiseumLeaveOtherMsg;
    private bool _dispedLeaveOtherMsg;
    private MatchingState _currentState;

    public bool IsStateNone { get => _currentState == MatchingState.None; }
	
	public bool IsStateBattle { get => _currentState == MatchingState.GoBattle; }
	
	public bool IsStateClosing { get => _currentState == MatchingState.Closing; }
	
	// TODO
	public static IEnumerator LoadBattleMatchingUI(Action<UIBattleMatching> onCompletedLoad) { return default; }
	
	// TODO
	public static void UnloadBattleMatchingUI() { }
	
	// TODO
	public static IEnumerator LoadBattleTowerUI(Action onCompletedLoad) { return default; }
	
	// TODO
	public static void UnloadBattleTowerUI() { }
	
	// TODO
	public void Initialize(Action onFinish) { }
	
	// TODO
	public void ResetData() { }
	
	// TODO
	public void StartProcess() { }
	
	// TODO
	private bool IsNetworkError() { return default; }
	
	// TODO
	private bool CheckLeavedMember() { return default; }
	
	// TODO
	private void FinishProcess() { }
	
	// TODO
	private void PreClose() { }
	
	// TODO
	private void Close() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	private void OnUpdateClose() { }
	
	// TODO
	private void FinishMatching() { }
	
	// TODO
	private MatchingState NextState() { return default; }
	
	// TODO
	private void ChangeNextState() { }
	
	// TODO
	private void ChangeState(MatchingState state) { }
	
	// TODO
	private void ShowVS() { }
	
	// TODO
	private void GoBattle() { }
	
	// TODO
	public void ReturnBattle() { }
	
	// TODO
	public void ReturnBattleError() { }
	
	// TODO
	private uint GetColiseumBgm() { return default; }
	
	// TODO
	private void LeaveMine() { }
	
	// TODO
	public void LeaveOther(int index) { }
	
	// TODO
	private void LeaveOtherMessage() { }
	
	// TODO
	public void OnError() { }
	
	// TODO
	public void SendJoinMineData(int targetStationIndex) { }
	
	// TODO
	private void SendJoinMemberData(int index, NetDataBattleMatchingJoin data) { }
	
	// TODO
	public void SendLeaveData() { }
	
	// TODO
	public void SendReadyData() { }
	
	// TODO
	public void SendStateData() { }
	
	// TODO
	public void SendSelectTeamData(int index, int stationIndex) { }
	
	// TODO
	public void SendDecideTeamData() { }
	
	// TODO
	public void SendSelectRuleMemberData() { }
	
	// TODO
	public void SendDecideRuleMemberData() { }
	
	// TODO
	public void SendRuleData() { }
	
	// TODO
	public void SendSelectPokemonData() { }
	
	// TODO
	public void SendCancelPokemonData() { }
	
	// TODO
	public void SendResumeData(bool resume) { }
	
	// TODO
	public void SendCountDownData(ushort timeCount) { }
	
	// TODO
	public void ReceiveData(INetData netData) { }
	
	// TODO
	private void ReceiveJoinData(NetDataBattleMatchingJoin data) { }
	
	// TODO
	private void ReceiveLeaveData(NetDataBattleMatchingLeave data) { }
	
	// TODO
	private void ReceiveTalkCancelData(NetDataTalkCancelEndData data) { }
	
	// TODO
	private void ReceiveTalkCancelData(NetDataBattleRuleCancelData data) { }
	
	// TODO
	private void ReceiveReadyData(NetDataBattleMatchingReady data) { }
	
	// TODO
	private void ReceiveStateData(NetDataBattleMatchingState data) { }
	
	// TODO
	private void ReceiveSelectTeamData(NetDataBattleMatchingSelectTeam data) { }
	
	// TODO
	private void ReceiveDecideTeamData(NetDataBattleMatchingDecideTeam data) { }
	
	// TODO
	private void ReceiveSelectRuleMemberData(NetDataBattleMatchingSelectRuleMember data) { }
	
	// TODO
	private void ReceiveDecideRuleMemberData(NetDataBattleMatchingDecideRuleMember data) { }
	
	// TODO
	private void ReceiveRuleData(NetDataBattleMatchingRule data) { }
	
	// TODO
	private void ReceiveSelectPokemonData(NetDataBattleMatchingSelectPokemon data) { }
	
	// TODO
	private void ReceiveCancelPokemonData(NetDataBattleMatchingCancelPokemon data) { }
	
	// TODO
	private void ReceiveResumeData(NetDataBattleMatchingResume data) { }
	
	// TODO
	private void ReceiveCountDownData(NetDataBattleMatchingCountDown data) { }
	
	// TODO
	private void SetPlayReport() { }
	
	// TODO
	private void CheckReceivedPacket() { }
	
	// TODO
	public BattleMatchingManager() { }

	public enum FinishPattern : int
	{
		Success = 0,
		Cancel = 1,
		Dissolution = 2,
		LeavedMember = 3,
		ProgramError = 4,
		NetworkError = 5,
	}

	private enum MatchingState : int
	{
		None = 0,
		Initialize = 1,
		Load = 2,
		RecruitmentMember = 3,
		SelectTeamMember = 4,
		SelectRule = 5,
		SelectBattleTeam = 6,
		SelectPokemon = 7,
		GoBattle = 8,
		Result = 9,
		Resume = 10,
		Closing = 11,
		LeavedOtherMembers = 12,
	}
}