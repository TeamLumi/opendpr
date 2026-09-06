using Dpr.BallDeco;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using INL1;
using System;

namespace Dpr.Contest
{
	public class ContestMatchingNetwork
	{
		private const int MAX_RETRY_COUNT = 3;
		private const float SEND_READY_SPAN = 3.0f;

		private NetPlayerInfo charaModelData;
		private CountDownNetData countDownData;
		private NoticeNetData noticeData;
		private SkillPointNetData skillPointData;
		private ChoiceNetData choiceData;
		private CategoryAndRankNetData categoryAndRankData;
		private ContestEntryNPCNetData entryNPCData;
		private ContestEntryPlayerNetData entryPlayerData;
		private ContestInfoNetData contestInfoData;
		private ScoreNetData scoreData;
		private LaunchSkillNetData launchSkillData;
		private ResultScoreNetData resultScoreData;
		private StationWaitFrameData waitFrameData;
		private NetworkManager networkManager;
		private WaitTimer repeatSendSpanTimer = new WaitTimer();
		private uint[] attributeValueArray;
		private uint[] attributeMinValueArray;
		private uint[] attributeMaxValueArray;
		private Action<byte, PacketReader> onRecievePacket;
		private Action<SessionEventData> onSessionEvent;
		private Action onFinishedSession;
		private ConnectType connectType;
		private MatchingType matchingType;
		private PlayerSkill playerSkill;
		private MultiContestStepID currentStepID;
		private string password;
		private int nowJoinMemberNum;
		private int myStationIndex;
		private int retryCount;
		private bool[] mainFlagArray;
		private bool[] subFlagArray;
		private bool bIsInitialize;
		
		// TODO
		public void Initialize(Action<byte, PacketReader> onRecievePacket, Action<SessionEventData> onSessionEvent, Action onFinishedSession) { }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void ReleaseReceivePacket() { }
		
		// TODO
		public void ReleaseSessionEvent() { }
		
		// TODO
		private void ReleaseNetworkCallback() { }
		
		public ConnectType ConnectType { get => connectType; }
		public MatchingType MatchingType { get => matchingType; }
		public PlayerSkill PlayerSkill { get => playerSkill; }
		
		// TODO
		public bool IsHost() { return default; }
		
		// TODO
		public bool IsConnect() { return default; }
		
		// TODO
		public bool CanPlayNetworkContest() { return default; }
		
		public int MyStationIndex { get => myStationIndex; }
		public int JoinMemberNum { get => nowJoinMemberNum; }
		
		// TODO
		public bool IsJoinedOtherPlayer() { return default; }
		
		// TODO
		public bool IsGamerActive(int stationIndex) { return default; }
		
		// TODO
		private void OnJoinMine() { }
		
		// TODO
		private void UpdateJoinMemberNum() { }
		
		// TODO
		public void SetEntryPlayerInfo(int playerIndex, PlayerType playerType) { }
		
		public MultiContestStepID CurrentStepID { get => currentStepID; }
		
		public void SetStepID(MultiContestStepID stepID) {
		    this.currentStepID = stepID;
		}
		
		// TODO
		public bool GetMyMainFlag() { return default; }
		
		// TODO
		public void SetMainFlag(int stationIndex, bool flag) { }
		
		// TODO
		public void SetAllMainFlag(bool flag) { }
		
		// TODO
		public bool IsAllMainFlagTrue(int memberNum) { return default; }
		
		// TODO
		public bool GetSubFlagByStationIndex(int stationIndex) { return default; }
		
		// TODO
		public bool GetMySubFlag() { return default; }
		
		// TODO
		public void SetSubFlag(int stationIndex, bool flag) { }
		
		// TODO
		private void SetAllSubFlag(bool flag) { }
		
		// TODO
		public bool IsAllSubFlagTrue(int memberNum) { return default; }
		
		// TODO
		private bool CheckPlayerIndex(int index) { return default; }
		
		// TODO
		public void RepeatSendNotice(NoticeID noticeID, float deltaTime) { }
		
		// TODO
		public bool IsFinishWait(float deltaTime) { return default; }
		
		// TODO
		public void ResetTimer() { }
		
		// TODO
		private void OnRecievePacket(PacketReader pr) { }
		
		// TODO
		private void OnSessionEvent(SessionEventData result) { }
		
		// TODO
		private void OnFinishedSession() { }
		
		// TODO
		public void SetSessionParam(ConnectType connectType, MatchingType matchingType, PlayerSkill playerSkill, string password) { }
		
		// TODO
		public void StartSession(Action<bool> onFinish) { }
		
		// TODO
		private void SetupSessionParam() { }
		
		// TODO
		public void RestartRequestAsync() { }
		
		// TODO
		private IlcaNetSessionNetworkType GetNetworkType() { return default; }
		
		// TODO
		private void SettingSessionAttribute() { }
		
		// TODO
		public bool CloseSession() { return default; }
		
		// TODO
		public void LeaveSession() { }
		
		// TODO
		public bool FinishSession() { return default; }
		
		// TODO
		public void OnResumeGame() { }
		
		// TODO
		public void SendPlayerModelData(int stationIndex) { }
		
		// TODO
		public NetPlayerInfo ReceiveCharaModelData(PacketReader pr) { return default; }
		
		// TODO
		public void SendCountDownData(ushort timeCount) { }
		
		// TODO
		public CountDownNetData ReceiveCountDownData(PacketReader pr) { return default; }
		
		// TODO
		public void SendNoticeData(NoticeID noticeID) { }
		
		// TODO
		public void SendNoticeData(int stationIndex, NoticeID noticeID) { }
		
		// TODO
		public void SendNoticeDataToAll(NoticeID noticeID) { }
		
		// TODO
		public NoticeNetData ReceiveNoticeData(PacketReader pr) { return default; }
		
		// TODO
		public void SendChoiceData(int targetStationIndex) { }
		
		// TODO
		public ChoiceNetData ReceiveChoiceNetData(PacketReader pr) { return default; }
		
		// TODO
		public void SendSkillPointDataToHost() { }
		
		// TODO
		public SkillPointNetData ReceiveSkillPointData(PacketReader pr) { return default; }
		
		// TODO
		public void SendCategoryAndRankDataToAll(CategoryID categoryID, RankID rankID, int cassetVersion) { }
		
		// TODO
		public CategoryAndRankNetData ReceiveCategoryAndRankData(PacketReader pr) { return default; }
		
		// TODO
		public void SendEntryNPCDataToAll() { }
		
		// TODO
		public ContestEntryNPCNetData ReceiveEntryNPCData(PacketReader pr) { return default; }
		
		// TODO
		public void SendEntryPlayerDataToAll(int userEntryNumber, float wazaSeqMaxTime, AffixSealData[] sealDataArray) { }
		
		// TODO
		public ContestEntryPlayerNetData ReceiveEntryPlayerData(PacketReader pr) { return default; }
		
		// TODO
		public void SendContestDataToAll(byte stageRank) { }
		
		// TODO
		public ContestInfoNetData ReceiveContestData(PacketReader pr) { return default; }
		
		// TODO
		public void SendScoreDataToAll(int playerIndex, int danceScore, int tension) { }
		
		// TODO
		public ScoreNetData ReceiveScoreData(PacketReader pr) { return default; }
		
		// TODO
		public void SendLaunchSkillDataToAll(int playerIndex, float elapsedTime, float duration) { }
		
		// TODO
		public LaunchSkillNetData ReceiveLaunchSkillData(PacketReader pr) { return default; }
		
		// TODO
		public void SendResultScoreToAll(int playerIndex, int visualScore, int danceScore, int wazaScore) { }
		
		// TODO
		public ResultScoreNetData ReceiveResultScoreData(PacketReader pr) { return default; }
		
		// TODO
		public float SendWaitFrameData() { return default; }
		
		// TODO
		public float ReceiveWaitFrameData(PacketReader pr) { return default; }
		
		// TODO
		private void SendDataToStation<T>(ANetData<T> data, int index) { }
		
		// TODO
		private void SendDataToAll<T>(ANetData<T> data) { }
	}
}