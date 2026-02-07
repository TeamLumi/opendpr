using DPData;
using Dpr.BallDeco;
using Dpr.Battle.Logic.Net;
using Dpr.Trainer;
using Pml;
using Pml.PokePara;
using poketool;
using System.Collections;
using System.Collections.Generic;
using XLSXContent;

namespace Dpr.Battle.Logic
{
    public class MainModule
    {
        // TODO .cctor

        private BATTLE_SETUP_PARAM m_setupParam;
        private BattleViewBase m_viewCore;
        private Random m_randSys;
        private ulong m_randomSeed;
        private pSubProc m_subProc;
        private int m_subSeq;
        private int m_setupStep;
        private pMainProc m_mainLoop;
        private PokeParty[] m_srcParty;
        private PokeParty[] m_srcPartyForServer;
        private PokeParty m_tmpParty;
        private MyStatus m_playerStatus;
        private bool[] m_fClientQuit;
        private BtlRule m_rule;
        private uint m_regularMoney;
        private uint m_bonusMoney;
        private uint m_loseMoney;
        private MSGSPEED m_msgSpeed;
        private ushort m_LimitTimeGame;
        private ushort m_LimitTimeClient;
        private ushort m_LimitTimeCommand;
        private BtlResult m_serverResult;
        private ResultCause m_serverResultCause;
        private byte m_myClientID;
        private BtlPokePos m_myOrgPos;
        private BATTLERULE m_changeMode;
        private byte m_MultiAIDataSeq;
        private byte m_MultiAIClientNum;
        private byte[] m_MultiAIClientID;
        private bool m_fCommError;
        private bool m_fCommErrorMainQuit;
        private bool m_fWazaEffectEnable;
        private bool m_fGetMoneyFixed;
        private bool m_fLoseMoneyFixed;
        private bool m_padding;
        private bool m_isFinalizeStarted;
        private BTL_SERVER m_server;
        private BTL_SERVER m_cmdCheckServer;
        private BTL_CLIENT[] m_client;
        private BTL_CLIENT[] m_dummyClient;
        private TRAINER_DATA[] m_trainerParam;
        private ClientPublicInformation[] m_clientPublicInformation;
        private AdapterFactory m_adapterFactory;
        private rec.Reader m_recReader;
        private bool[] m_moneyDblUpCause;
        private Dictionary<uint, uint> m_zukanDataOnBattleStart;
        private PokeIDRec m_deadPokeIDRec;
        private BattleEnv m_battleEnvForClient;
        private BattleEnv m_battleEnvForServer;
        public Client m_iPtrNetClient;
        public bool isInitialized;
        public bool isFinalized;
        private static readonly BtlvPos[][] rule_double_vpos;
        private static readonly BtlvPos[][] rule_double_vpos_PA_A;
        private static readonly BtlvPos[][] rule_raid_vpos1;
        private static readonly BtlvPos[][] rule_raid_vpos2;
        private static readonly BtlvPos[][] rule_raid_vpos3;
        private static readonly BtlvPos[][] rule_raid_vpos4;
        private CapsuleData DummyCapsuleData;

        // TODO
        public BATTLE_SETUP_PARAM GetBattleSetupParam() { return null; }

        // TODO
        public bool GetEnableTimeStop() { return false; }

        // TODO
        public bool GetEnableVoiceChat() { return false; }

        // TODO
        public bool IsSkyBattle() { return false; }

        // TODO
        public bool IsMustCaptureMode() { return false; }

        // TODO
        public void SetFairyGymResult(byte result) { }

        // TODO
        public byte GetFairyGymResult() { return 0; }

        public BattleViewBase GetBattleViewSystem()
        {
            return m_viewCore;
        }

        public BattleEnv GetBattleEnvForServer()
        {
            return m_battleEnvForServer;
        }

        public BattleEnv GetBattleEnvForClient()
        {
            return m_battleEnvForClient;
        }

        // TODO
        public MainModule(BATTLE_SETUP_PARAM setupParam) { }

        // TODO
        public void Dispose() { }

        // TODO
        public IEnumerator InitializeCoroutine() { return null; }

        // TODO
        private void createBattleEnv() { }

        // TODO
        private void initializeBattleAiSystem() { }

        // TODO
        private Dictionary<uint, uint> createZukanDataClone() { return null; }

        // TODO
        public bool MainLoop(ref int seq) { return false; }

        // TODO
        private void storeBattleResult() { }

        // TODO
        private bool isBgmFadeOutDisable() { return false; }

        // TODO
        private bool checkRecReadComplete() { return false; }

        // TODO
        public IEnumerator FinalizeCoroutine() { return null; }

        // TODO
        public bool FinalizeApp(ref int seq) { return false; }

        // TODO
        public IEnumerator LeavenOnErrorCoroutine() { return null; }

        // TODO
        public void StartForceRemoveView() { }

        // TODO
        public bool WaitForceRemoveView() { return false; }

        // TODO
        private void setMainLoop(pMainProc proc) { }

        // TODO
        private bool callMainLoop() { return false; }

        // TODO
        private void setSubProc(pSubProc subProc) { }

        // TODO
        private bool callSubProc() { return false; }

        // TODO
        private void setSubProcForSetup(BATTLE_SETUP_PARAM setup_param) { }

        // TODO
        private void setSubProcForCleanUp(BATTLE_SETUP_PARAM setup_param) { }

        // TODO
        private void setupCommon_TrainerParam(BATTLE_SETUP_PARAM sp) { }

        // TODO
        private void setupCommon_SetRecplayerClientMode(BATTLE_SETUP_PARAM sp) { }

        // TODO
        private void setupCommon_CreateViewModule(BATTLE_SETUP_PARAM sp, BtlBagMode bagMode) { }

        // TODO
        private bool setupCommon_InitViewModule() { return false; }

        // TODO
        private void setupCommon_ClientPublicInformation(in BATTLE_SETUP_PARAM setupParam) { }

        // TODO
        private void setupCommon_ClientPublicInformation(ClientPublicInformation publicInfo, byte clientId, in MiseaiData miseaiData) { }

        // TODO
        private bool setup_alone_single(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_00(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_01(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_02(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_03(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_04(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_05(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_06(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_07(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_08(ref int seq) { return false; }

        // TODO
        private bool setup_alone_double_multi_09(ref int seq) { return false; }

        // TODO
        private bool setup_alone_raid(ref int seq) { return false; }

        // TODO
        private bool setup_comm_raid(ref int seq) { return false; }

        // TODO
        private bool setupseq_comm_raid(ref int seq) { return false; }

        // TODO
        private void setup_raid_srcParty() { }

        // TODO
        private void setup_raid_trainerParam() { }

        // TODO
        private void setup_raid_battleEnv(BattleEnv env, bool forServer) { }

        // TODO
        private void setup_raid_boss(BattleEnv env) { }

        // TODO
        private void setupCommon_SetupBattleEnv() { }

        // TODO
        private void setupCommon_SetupBattleEnv(BattleEnv env) { }

        // TODO
        private void setupCommon_SetupBattleEnv_TimeLimit(BattleEnv env) { }

        // TODO
        private void setupCommon_SetupBattleEnv_GRights(BattleEnv env) { }

        // TODO
        private void setupCommon_SetupBattleEnv_BattleTalk(BattleEnv env) { }

        // TODO
        public void setupCommon_CreateServerClient(in BATTLE_SETUP_PARAM setupParam) { }

        // TODO
        private BtlBagMode checkBagMode(BATTLE_SETUP_PARAM sp) { return default; }

        // TODO
        private void setup_alone_common_ClientID(BATTLE_SETUP_PARAM sp) { }

        // TODO
        private void setupCommon_srcParty(BATTLE_SETUP_PARAM sp) { }

        // TODO
        private void setSrcPartyToBattleEnv(BattleEnv battleEnv, byte clientID, bool forServer) { }

        // TODO
        public byte ClientIDtoRelation(byte myClientID, byte targetClientID) { return 0; }

        // TODO
        private bool cleanup_common(ref int seq) { return false; }

        // TODO
        private bool setup_comm_single(ref int seq) { return false; }

        // TODO
        private bool setup_comm_double(ref int seq) { return false; }

        // TODO
        private bool setupseq_comm_determine_server(ref int seq) { return false; }

        // TODO
        private bool setupseq_comm_store_party_data(ref int seq) { return false; }

        // TODO
        private bool setupseq_comm_store_player_data(ref int seq) { return false; }

        // TODO
        private bool setupseq_comm_create_server_client(ref int seq) { return false; }

        // TODO
        private bool setupseq_comm_start_server(ref int seq) { return false; }

        // TODO
        private bool MainLoop_StandAlone() { return false; }

        // TODO
        private bool MainLoop_Comm_Server() { return false; }

        // TODO
        private void watchRemoteClientCommunication() { }

        // TODO
        private void watchMyClientCommunication() { }

        // TODO
        private bool canLaunchDammyClient() { return false; }

        // TODO
        private void launchDammyClient(BTL_CLIENT_ID clientId) { }

        // TODO
        private bool MainLoop_Comm_NotServer() { return false; }

        // TODO
        private void watchRemoteServerLoss() { }

        // TODO
        private void changeServerSelf() { }

        // TODO
        private bool MainLoop_Comm_Error() { return false; }

        // TODO
        public void OnCommError() { }

        // TODO
        public void NotifyCommErrorToLocalClient() { }

        // TODO
        public bool CheckAllClientQuit() { return false; }

        public BtlRule GetRule()
        {
            return m_rule;
        }

        // TODO
        public bool IsWazaEffectEnable() { return false; }

        // TODO
        public byte GetMaxFollowPokeLevel() { return 0; }

        // TODO
        public bool NeedReduleHighLevelCaptureRate() { return false; }

        // TODO
        public byte GetCaptureLevelCap() { return 0; }

        // TODO
        public byte GetExpLevelCap() { return 0; }

        // TODO
        public bool IsIrekaeMode() { return false; }

        // TODO
        public bool IsCompetitorScenarioMode() { return false; }

        // TODO
        public bool IsScenarioMultiBattle() { return false; }

        // TODO
        public bool IsScenarioRaidBattle() { return false; }

        // TODO
        public bool IsPokeItemConsumeBattle() { return false; }

        // TODO
        public bool CanAddBonusMoney() { return false; }

        // TODO
        public bool IsEscapeEnableBattle() { return false; }

        // TODO
        public bool IsExpSeqEnable() { return false; }

        // TODO
        public bool IsMoneySeqEnable() { return false; }

        // TODO
        public BtlPokePos GetValidPosMax() { return BtlPokePos.POS_1ST_0; }

        // TODO
        public uint GetFrontPosNum(byte clientID) { return 0; }

        // TODO
        public uint GetSidePosNum(BtlSide side) { return 0; }

        // TODO
        public uint GetOpponentFrontPosNum(byte clientID) { return 0; }

        // TODO
        public bool IsPokePosExist(BtlPokePos pos) { return false; }

        // TODO
        public bool IsFrontPos(BtlPokePos pos) { return false; }

        // TODO
        public BtlCompetitor GetCompetitor(bool isDemoCaptureConvert = true) { return BtlCompetitor.BTL_COMPETITOR_WILD; }

        // TODO
        public BtlCommMode GetCommMode() { return default; }

        // TODO
        public string GetWinBGMStr() { return null; }

        // TODO
        public BtlEscapeMode GetEscapeMode() { return default; }

        // TODO
        public bool CanUseEscapeItem() { return false; }

        // TODO
        public BTL_FIELD_SITUATION GetFieldSituation() { return null; }

        // TODO
        public BtlWeather GetDefaultWeather() { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public byte GetDefaultGround() { return 0; }

        // TODO
        public BattleEffectComponentData GetBattleEffectData() { return default; }

        // TODO
        public byte GetForceQuitTurnCount() { return 0; }

        // TODO
        public MyStatus GetPlayerStatus() { return null; }

        // TODO
        public bool IsZukanRegistered(MonsNo monsno) { return false; }

        // TODO
        public bool IsZukanRegistered(BTL_POKEPARAM bpp) { return false; }

        // TODO
        public uint GetZukanCapturedCount() { return 0; }

        // TODO
        public bool IsZukanPokeSeeOnBattleStart(MonsNo monsno) { return false; }

        // TODO
        public void RegisterZukanSeeFlag(BTL_POKEPARAM bpp) { }

        // TODO
        private bool canRegisterZukanSeeFlag(BTL_POKEPARAM pTarget) { return false; }

        // TODO
        public void RegisterZukanSpGGetFlag(BTL_POKEPARAM bpp) { }

        // TODO
        public void IncrementZukanBattleCount(BTL_POKEPARAM bpp, bool isCaptured) { }

        // TODO
        public uint GetClientCoverPosNum(byte clientID) { return 0; }

        // TODO
        public BTL_CLIENT_ID GetPosCoverClientId(BtlPokePos pos) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        public bool IsExistClient(byte clientID) { return false; }

        // TODO
        public BtlMultiMode GetMultiMode() { return BtlMultiMode.BTL_MULTIMODE_NONE; }

        // TODO
        public bool IsMultiMode() { return false; }

        // TODO
        public bool IsPlayerRatingDisplay() { return false; }

        // TODO
        public bool IsWatchMember() { return false; }

        // TODO
        public BtlSide GetClientSide(byte clientID) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public bool IsPlayerSide(BtlSide side) { return false; }

        // TODO
        public bool IsSideExist(BtlSide side) { return false; }

        // TODO
        public void ExpandSide(BtlSide[] expandSide, ref byte expandSideNum, BtlSide side) { }

        // TODO
        public BtlPokePos GetSidePos(BtlSide side, byte index) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public byte GetSideNum() { return 0; }

        // TODO
        public byte GetClientNum() { return 0; }

        // TODO
        public byte GetClientNum(BtlSide side) { return 0; }

        // TODO
        public byte GetEnemyClientNum(byte clientID) { return 0; }

        // TODO
        public BtlPokePos GetOpponentPokePos(BtlPokePos basePos, byte idx) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public BtlPokePos GetFriendPokePos(BtlPokePos basePos, byte idx) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public bool IsFriendPokePos(BtlPokePos pos1, BtlPokePos pos2) { return false; }

        // TODO
        public bool IsOpponentClientID(byte clientID1, byte clientID2) { return false; }

        // TODO
        private byte btlPos_to_clientID(BtlPokePos btlPos) { return 0; }

        // TODO
        private void btlPos_to_cliendID_and_posIdx(BtlPokePos btlPos, out byte clientID, out byte posIdx)
        {
            clientID = 0;
            posIdx = 0;
        }

        // TODO
        public BtlPokePos PokeIDtoPokePos(POKECON pokeCon, byte pokeID) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public BtlvPos PokeIDtoViewPos(POKECON pokeCon, byte pokeID) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public byte BtlPosToClientID(BtlPokePos pos) { return 0; }

        // TODO
        public byte BtlPosToPosIdx(BtlPokePos pos) { return 0; }

        // TODO
        public void BtlPosToClientID_and_PosIdx(BtlPokePos pos, out byte clientID, out byte posIdx)
        {
            clientID = 0;
            posIdx = 0;
        }

        // TODO
        public BtlvPos ClientIDtoTrainerViewPos(byte clientID) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public BtlvPos BtlPosToViewPos(BtlPokePos pos) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public BtlPokePos ViewPosToBtlPos(byte vpos) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public byte GetPlayerClientID() { return 0; }

        // TODO
        public byte GetPlayerFriendCleintID() { return 0; }

        // TODO
        public byte GetFriendCleintID(byte clientID) { return 0; }

        // TODO
        public byte GetEnemyClientID(byte idx) { return 0; }

        // TODO
        public uint GetOpponentClientID(byte clientID, byte idx) { return 0; }

        // TODO
        public bool DecrementPlayerItem(byte clientID, ushort itemID) { return false; }

        // TODO
        public bool AddItem(byte clientID, ushort itemID) { return false; }

        // TODO
        public bool IsRecordEnable() { return false; }

        // TODO
        public void NotifyCapturedInfo(in CaptureInfo info) { }

        // TODO
        public void NotifyTurnedLevelUpPokePos(byte pokeID) { }

        // TODO
        public bool CheckTurnedLevelUp(byte pokeID) { return false; }

        // TODO
        public void NotifyRaidCaptureStart() { }

        // TODO
        public void NotifyRaidExitLose() { }

        // TODO
        public void NotifyBattleResult(BtlResult result, ResultCause resultCause, bool isForceSetEnable = false) { }

        // TODO
        public BtlResult GetBattleResult() { return BtlResult.BTL_RESULT_LOSE; }

        // TODO
        public ResultCause GetBattleResultCause() { return default; }

        // TODO
        public void NotifyCmdCheckError() { }

        // TODO
        public uint FixRegularMoney() { return 0; }

        // TODO
        public void AddBonusMoney(uint volume) { }

        // TODO
        public uint GetBonusMoney() { return 0; }

        // TODO
        public void SetMoneyDblUp(MoneyDblUpCause cause) { }

        // TODO
        private uint calcMoneyDblUpRatio() { return 0; }

        // TODO
        public uint FixLoseMoney() { return 0; }

        // TODO
        public void ReflectNatsukiDead(BTL_POKEPARAM bpp, bool fLargeDiffLevel) { }

        // TODO
        private void natsukiPut(BTL_POKEPARAM bpp, DaisukiType calcID) { }

        // TODO
        public void ReflectPokeWazaOboe(byte pokeID) { }

        // TODO
        public byte GetClientFrontPosCount(byte clientID) { return 0; }

        // TODO
        public byte GetClientBenchPosIndex(byte clientID) { return 0; }

        // TODO
        public bool IsPlayersPokeID(byte pokeID) { return false; }

        // TODO
        public bool IsFriendPokeID(byte pokeID1, byte pokeID2) { return false; }

        // TODO
        public BtlSide PokeIDtoSide(byte pokeID) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public BtlSide PokeIDtoOpponentSide(byte pokeID) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public BtlSide GetOpponentSide(BtlSide side) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public void SetIllusionForParty(BTL_PARTY party, byte clientID) { }

        // TODO
        public bool GetSetupStatusFlag(BTL_STATUS_FLAG flag) { return false; }

        // TODO
        public void RECORDDATA_Inc(RECORD_ID recID) { }

        // TODO
        public void RECORDDATA_Add(RECORD_ID recID, uint value) { }

        // TODO
        public bool IsShooterEnable() { return false; }

        // TODO
        public bool IsItemEnable() { return false; }

        // TODO
        public bool IsFriendshipActive(BTL_POKEPARAM bpp) { return false; }

        // TODO
        public byte GetPokeFriendship(BTL_POKEPARAM bpp) { return 0; }

        // TODO
        public bool CanEvolveAfterBattle(in BTL_POKEPARAM poke) { return false; }

        // TODO
        public void GetEvolveSituation(EvolveSituation dest, byte pokeId) { }

        // TODO
        public void NotifyPokemonLevelup(BTL_POKEPARAM bpp) { }

        // TODO
        public void CalcNatsukiItemUse(BTL_POKEPARAM bpp, ushort itemNo) { }

        // TODO
        public void NotifyPokemonGetToGameSystem(BTL_POKEPARAM bpp) { }

        // TODO
        public bool IsResultStrictMode() { return false; }

        // TODO
        private BtlResult checkWinner(byte myClientId) { return BtlResult.BTL_RESULT_LOSE; }

        public uint GetCommandLimitTime()
        {
            return m_LimitTimeCommand;
        }

        public uint GetClientLimitTime()
        {
            return m_LimitTimeClient;
        }

        // TODO
        public bool IsClientLimitTimeExist() { return false; }

        public uint GetGameLimitTime()
        {
            return m_LimitTimeGame;
        }

        // TODO
        public bool IsGameLimitTimeExist() { return false; }

        // TODO
        public bool CheckGameLimitTimeOver() { return false; }

        // TODO
        public bool CheckClientLimitTimeOver() { return false; }

        // TODO
        public bool IsLongEncount() { return false; }

        // TODO
        public bool CheckRecPlayError() { return false; }

        // TODO
        private void Bspstore_RecordData() { }

        // TODO
        public void StartFadeoutForRecPlay() { }

        // TODO
        public void ResetForRecPlay(uint nextTurnNum) { }

        // TODO
        public void NotifyChapterSkipEnd() { }

        // TODO
        public BTL_CLIENT GetClient(byte clientID) { return default; }

        // TODO
        public BTL_CLIENT GetClientByPokeID(byte pokeID) { return default; }

        // TODO
        private void Kentei_ClearField(BATTLE_SETUP_PARAM sp) { }

        // TODO
        private void Bspstore_KenteiData() { }

        // TODO
        private void trainerParam_Init() { }

        // TODO
        private void trainerParam_Clear() { }

        // TODO
        private void trainerParam_ClearCore(TRAINER_DATA data) { }

        // TODO
        public void trainerParam_StorePlayer(TRAINER_DATA dst, MyStatus playerData) { }

        // TODO
        public void trainerParam_StoreCore(TRAINER_DATA dst) { }

        // TODO
        private void trainerParam_StoreNPCTrainer(TRAINER_DATA dst, BSP_TRAINER_DATA trData) { }

        // TODO
        private void trainerParam_SetupForRecPlay(byte clientID) { }

        // TODO
        private bool trainerParam_IsExist(TRAINER_DATA trData) { return false; }

        // TODO
        public bool IsClientTrainerExist(byte clientID) { return false; }

        // TODO
        public bool IsClientNPC(byte clientID) { return false; }

        // TODO
        public ushort GetClientUseItem(byte clientID, byte itemIdx) { return 0; }

        // TODO
        public uint GetClientAIBit(byte clientID) { return 0; }

        // TODO
        public TRAINER_DATA GetClientTrainerData(byte clientID) { return default; }

        // TODO
        public TrainerID GetClientTrainerID(byte clientID) { return TrainerID.INVALID; }

        // TODO
        public void GetClientTrainerMsg(byte clientID, TrainerMessageID messageID, out string outMessageLabel, out string outSequenceName)
        {
            outMessageLabel = null;
            outSequenceName = null;
        }

        // TODO
        public string GetCliehtTrainerSequence(byte clientID, TrainerSequenceID sequenceID) { return null; }

        // TODO
        public string GetClientTrainerMsg(byte clientID, TrainerMessageID messageID) { return null; }

        // TODO
        public string GetClientTrainerName(byte clientID) { return null; }

        // TODO
        public string GetClientTrainerNameLabel(byte clientID) { return null; }

        // TODO
        public string GetClientTrainerTypeLabel(byte clientID) { return null; }

        // TODO
        public Sex GetClientTrainerSex(byte clientID) { return Sex.MALE; }

        // TODO
        public TrainerType GetClientTrainerType(byte clientID) { return TrainerType.INVALID; }

        // TODO
        public TrainerTypeGroup GetClientTrainerGroup(byte clientID) { return default; }

        // TODO
        public byte GetClientTrainerGold(byte clientID) { return 0; }

        // TODO
        public string GetClientTrainerModelID(byte clientID) { return null; }

        // TODO
        public int GetClientTrainerColorID(byte clientID) { return 0; }

        // TODO
        public string GetClientTrainerWinEffect(byte clientID) { return null; }

        // TODO
        public HandDominance GetClientTrainerHandDominance(byte clientID) { return HandDominance.NONE; }

        // TODO
        public HandDominance GetClientTrainerHoldBallHandDominance(byte clientID) { return HandDominance.NONE; }

        // TODO
        public float GetClientTrainerThrowTime(byte clientID) { return 0.0f; }

        // TODO
        public float GetClientTrainerCaptureThrowTime(byte clientID) { return 0.0f; }

        // TODO
        public float GetClientTrainerLoseLoopTime(byte clientID) { return 0.0f; }

        // TODO
        public string GetClientTrainerEffect(byte clientID) { return null; }

        // TODO
        private TrainerTable.SheetTrainerData GetClientTrainerDataXLSX(byte clientID) { return null; }

        // TODO
        private TrainerTable.SheetTrainerType GetClientTrainerTypeDataXLSX(byte clientID) { return null; }

        // TODO
        public MyStatus GetClientPlayerData(byte clientID) { return null; }

        // TODO
        public ushort GetClientRating(byte clientID) { return 0; }

        // TODO
        public ClientPublicInformation GetClientPublicInformation(byte clientID) { return default; }

        // TODO
        public bool IsRecordPlayMode() { return false; }

        // TODO
        public bool CheckImServerMachine() { return false; }

        // TODO
        public bool HasPlayerGakusyuSouti() { return false; }

        // TODO
        public BtlPokePos GetClientPokePos(byte clientID, byte posIdx) { return BtlPokePos.POS_1ST_0; }

        // TODO
        private void srcParty_Create() { }

        // TODO
        private void srcParty_Delete() { }

        // TODO
        private void srcParty_Set(byte clientID, in PokeParty party) { }

        // TODO
        private static void srcParty_FormChangeForX(PokeParty party) { }

        // TODO
        private static void srcParty_FromChange_OnBattleStart(PokemonParam pokeParam) { }

        // TODO
        private void setupUnknownPokeNickName(PokeParty party) { }

        // TODO
        public PokeParty GetSrcParty(byte clientID, bool fForServer) { return null; }

        // TODO
        public PartyDesc GetPartySetupParam(byte clientID) { return null; }

        // TODO
        public RaidBattleParam GetRaidBattleParam() { return default; }

        // TODO
        public static byte GetClientBasePokeID(byte clientID) { return 0; }

        // TODO
        public static byte PokeIDtoClientID(byte pokeID) { return 0; }

        // TODO
        public static byte PokeIDtoShortID(byte pokeID) { return 0; }

        // TODO
        public static byte ShortIDtoPokeID(byte clientID, byte shortID) { return 0; }

        // TODO
        public BtlPokePos GetFacedPokePos(BtlPokePos pos) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public bool IsFriendClientID(byte clientID_1, byte clientID_2) { return false; }

        // TODO
        public BtlSide PosToSide(BtlPokePos pos) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public BATTLE_CONVENTION_INFO GetBattleConventionInfo(byte id) { return default; }

        // TODO
        public void NotifyPGLRecord(BTL_POKEPARAM bpp, PGLRecord.RecParam recParam) { }

        // TODO
        public void SetTvNaviData_FrontPoke(BTL_POKEPARAM bpp1, BTL_POKEPARAM bpp2) { }

        // TODO
        public void SetTvNaviData_UseWaza(BTL_POKEPARAM bpp, ushort wazaNo) { }

        // TODO
        public void NotifyPokemonDead(byte pokeID) { }

        // TODO
        public bool RankUpByClient(byte pokeID, BTL_POKEPARAM.ValueID rank, byte volume) { return false; }

        // TODO
        public bool RankDownByClient(byte pokeID, BTL_POKEPARAM.ValueID rank, byte volume) { return false; }

        // TODO
        public void SetUpRandSystem() { }

        // TODO
        public bool IsRaidBossRare() { return false; }

        // TODO
        public bool IsGEnableByNPC(byte pokeID) { return false; }

        // TODO
        public void WatchCmdAddReader() { }

        // TODO
        public bool NeedEndGOnBattleEnd() { return false; }

        // TODO
        public void WatchDataRecvAfterFunc() { }

        // TODO
        public void UpdateNetClient() { }

        // TODO
        public void NotifyPokeMemory_AllDead(byte causedPokeID) { }

        // TODO
        public bool IsLiveCup() { return false; }

        // TODO
        public void SyncClientLimitTimeForLiveCupWatcher(in ServerSendData.CLIENT_LIMIT_TIME time) { }

        // TODO
        public void SendClientTimerForLiveCupWatcher(uint[] timeBuf, in uint num) { }

        // TODO
        public void PauseTimerForLiveCup() { }

        // TODO
        public void RestartTimerForLiveCup(uint gameTimeS) { }

        // TODO
        public uint GetRemainingGameTimeForLiveCup() { return 0; }

        // TODO
        public BtlDetailRule GetDetailRule() { return BtlDetailRule.WildSingle; }

        // TODO
        public byte GetBallDecoSeals(byte pokeID, ref AffixSealData[] sealData) { return 0; }

        // TODO
        private ref CapsuleData GetBallDeco(byte clientID, PokemonParam pp, int index) { return ref PlayerWork.GetBallDecoData().CapsuleDatas[index]; }

        // TODO
        public bool IsTurearukiPokemon(PokemonParam pp) { return false; }

        private delegate bool pSubProc(ref int UnnamedParameter);

        private delegate bool pMainProc();

        private enum LocalSeq : int
        {
            kNone = 0,
            kDetermingServer = 1,
            kNotifyServerParam = 2,
            kStartWaitServerParam = 3,
            kWaitingServerParamNotified = 4,
            kEnd = 5,
        }

        public enum BtlDetailRule : int
        {
            WildSingle = 0,
            TrainerSingle = 1,
            TrainerDouble1 = 2,
            TrainerDouble2 = 3,
            WildMulti = 4,
            TrainerMulti = 5,
            L1 = 6,
            L2 = 7,
            L3 = 8,
            L4 = 9,
            L5 = 10,
            L6 = 11,
            L7 = 12,
            L8 = 13,
            F1 = 14,
            F2 = 15,
            F3 = 16,
            F4 = 17,
            C = 18,
            G1 = 19,
            G2 = 20,
            G3 = 21,
            G4 = 22,
            BTW = 23,
            Joker1 = 24,
            Joker2 = 25,
            Safari = 26,
        }
    }
}