using INL1;
using System.Collections.Generic;

namespace Dpr.NetworkUtils
{
	public class NetDataParser
	{
		private SessionConnector sessionConnector;
		private INetData netData;
		private List<INetData> netDataList = new List<INetData>();
		public bool _isTest;
		
		public NetDataParser()
		{
			sessionConnector = new SessionConnector();
			_isTest = true;

			netDataList.Add(new NetJoinData());
			netDataList.Add(new NetPosData());
			netDataList.Add(new NetEmotionData());
			netDataList.Add(new NetCharacterStateData());
			netDataList.Add(new NetDataTranerCardData());
			netDataList.Add(new NetDataTalkData());
			netDataList.Add(new NetDataTransitionData());
			netDataList.Add(new NetDataSelectData());
			netDataList.Add(new NetDataBattleTypeData());
			netDataList.Add(new NetDataTalkCancelEndData());
			netDataList.Add(new NetDataBattleRuleCancelData());
			netDataList.Add(new NetRequestData());
			netDataList.Add(new NetTradePokeData());
			netDataList.Add(new NetDataRecodeData());
			netDataList.Add(new NetDataAttachSealNetData());
			netDataList.Add(new NetUgJoinData());
			netDataList.Add(new NetZoneData());
			netDataList.Add(new NetSecretBaseData());
			netDataList.Add(new NetDigData());
			netDataList.Add(new NetDataTransitionAfterData());
			netDataList.Add(new NetDataTradeReadyOkData());
			netDataList.Add(new NetDataStandbyWaitListData());
			netDataList.Add(new NetDataIsMatchWaitData());
			netDataList.Add(new NetDataTradeTranerData());
			netDataList.Add(new NetDataCurrentFlowCancelData());
			netDataList.Add(new NetDigJoinData());
			netDataList.Add(new NetDigAttackData());
			netDataList.Add(new NetDigEndData());
			netDataList.Add(new NetDigGroupIdData());
			netDataList.Add(new NetDataBattleMatchingJoin());
			netDataList.Add(new NetDataBattleMatchingLeave());
			netDataList.Add(new NetDataBattleMatchingReady());
			netDataList.Add(new NetDataBattleMatchingState());
			netDataList.Add(new NetDataBattleMatchingSelectTeam());
			netDataList.Add(new NetDataBattleMatchingSelectRuleMember());
			netDataList.Add(new NetDataBattleMatchingDecideRuleMember());
			netDataList.Add(new NetDataBattleMatchingRule());
			netDataList.Add(new NetDataBattleMatchingSelectPokemon());
			netDataList.Add(new NetDataBattleMatchingCancelPokemon());
			netDataList.Add(new NetDataBattleMatchingResume());
			netDataList.Add(new NetSecretBaseInfo());
			netDataList.Add(new NetPlayerNameData());
			netDataList.Add(new NetPosZoneData());
			netDataList.Add(new NetJoinDigPermission());
			netDataList.Add(new NetDataReturnSelectData());
			netDataList.Add(new NetDataTradePokeCheckOkData());
			netDataList.Add(new NetKousekiAdd());
			netDataList.Add(new NetBonusStart());
			netDataList.Add(new NetRemainBonusTime());
			netDataList.Add(new NetKousekiCount());
			netDataList.Add(new NetDigJoinMemberCount());
			netDataList.Add(new NetDataBattleMatchingCountDown());
			netDataList.Add(new NetSecretBaseUpdate());
			netDataList.Add(new NetNaminoriData());
			netDataList.Add(new NetDataColiseumJoinDataData());
			netDataList.Add(new NetDataColiseumLeaveData());
			netDataList.Add(new NetDataColiseumReadyPointJoinData());
			netDataList.Add(new NetDataColiseumConfirmEntryData());
			netDataList.Add(new NetDataColiseumReplyEntryData());
			netDataList.Add(new NetDataStandbyWaitData());
			netDataList.Add(new NetDataRecodeTradeData());
			netDataList.Add(new NetDigTableData());
			netDataList.Add(new NetDataBattleMatchingDecideTeam());
			netDataList.Add(new NetDataTalkReserveData());
			netDataList.Add(new NetDataTalkReserveResultData());
		}
		
		public INetData GetNetData() {
		    return netData;
		}
		
		// TODO
		public void Parse(PacketReader pr) { }
		
		// TODO
		private INetData GetInstance(int DataID) { return default; }
		
		// TODO
		public void Destroy() { }
	}
}