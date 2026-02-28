using Pml.PokePara;
using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class BTL_CLIENT
    {
        public const int AITRAINER_MSG_MAX = 4;

        private MainModule m_mainModule;
        private BattleEnv m_pBattleEnv;
        private BTL_POKEPARAM m_procPoke;
        private byte m_actCountSum;
        private int m_procActionIndex;
        private BTL_ACTION_PARAM_OBJ m_procActionUIRet = new BTL_ACTION_PARAM_OBJ();
        private int m_currentActionIndex;
        private rec.Data m_recData;
        private rec.Reader m_btlRecReader;
        private RECPLAYER_CONTROL m_recPlayer = new RECPLAYER_CONTROL();
        private ClientMainProc m_mainProc;
        private FieldStatus m_fldSim;
        private ulong m_randContext;
        private Adapter m_adapter;
        private SendDataContainer m_sendDataContainer;
        private SendDataContainer m_receiveDataContainer;
        private Random m_random = new Random();
        private Random m_AIRand = new Random();
        private TrainerMessageManager m_trainerMessageManager;
        private ClientSeq_TrainerMessage m_seq_TrainerMessage;
        private ClientSeq_WinWild m_seq_WinWild;
        private ClientSeq_Capture m_seq_Capture;
        private BattleSimulator m_battleSimulator;
        private BattleDriver m_battleDriver;
        private ServerCommandQueue m_serverCmdQueue;
        internal GameTimer m_gameTimer;
        private ServerSendData.CLIENT_LIMIT_TIME m_syncClientTime;
        private ServerSendData.RAIDBOSS_CAPTURE_RESULT m_raidBossCaptureResult;
        private uint m_turnCount;
        private ushort m_EnemyPokeHPBase;
        private SEL_ITEM_WORK[] m_selItemWork = Arrays.InitializeWithDefaultInstances<SEL_ITEM_WORK>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        internal byte m_myID;
        private byte m_myType;
        private byte m_myState;
        private bool m_commWaitInfoOn;
        private byte m_bagMode;
        private unsafe byte* m_change_escape_code;
        private bool m_fForceQuitSelAct;
        private byte m_cmdCheckTimingCode;
        private byte[] m_actionCountWork = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private byte m_wazaInfoPokeIdx;
        private byte m_wazaInfoWazaIdx;
        private bool m_fAITrainerBGMChanged;
        private bool m_fCommError;
        private bool m_fSelActForceFinish;
        private bool m_fCmdCheckEnable;
        private bool m_fRecPlayEndTimeOver;
        private bool m_fRecPlayEndBufOver;
        private bool m_bRecPlayFadeStarted;
        private bool m_isWaitingAdapterCommand;
        private bool m_isGSelectedThisTurn;
        private bool m_isFirstActionSelectDone;
        private byte m_myChangePokeCnt;
        private byte m_myPuttablePokeCnt;
        private BtlPokePos[] m_myChangePokePos = new BtlPokePos[DefineConstants.BTL_POSIDX_MAX];
        private ushort m_returnDataSerialNumber;
        private ServerSequence m_returnDataServerSeq;
        private ServerRequest m_returnDataServerRequest;
        private unsafe void* m_returnDataPtr;
        private uint m_returnDataSize;
        private unsafe uint* m_dummyReturnData;
        private unsafe ClientSendData.ACTION_SELECT* m_returnData_ActionSelect;
        private unsafe ClientSendData.CLIENT_LIMIT_TIME* m_returnData_ClientLimitTime;
        private unsafe ClientSendData.RAID_BALL_SELECT* m_returnData_RaidBallSelect;
        private ushort m_cmdLimitTime;
        private ushort m_gameLimitTime;
        private ushort m_clientLimitTime;
        private readonly BTL_PARTY m_myParty;
        private byte m_procPokeIdx;
        private byte m_procPokeActIdx;
        private sbyte m_prevPokeIdx;
        private byte m_firstPokeIdx;
        private bool m_fStdMsgChanged;
        private bool m_b1stReadyMsgDisped;
        private BTL_SERVER m_cmdCheckServer;
        private BattleViewBase _m_viewCore;
        private BattleViewBase.ExpGetDesc m_viewExpGetDesc = new BattleViewBase.ExpGetDesc();
        private BattleViewBase.ExpGetResult m_viewExpGetResult = new BattleViewBase.ExpGetResult();
        private BTL_ACTION_PARAM[] m_actionParam = new BTL_ACTION_PARAM[ClientSendData.ACTION_SELECT.ACTIONPARAM_NUM];
        private int[] m_cmdArgs = new int[BattleServerConst.BTL_SERVERCMD_ARG_MAX];
        private VariableArgs m_stdVariableArgs = new VariableArgs();
        private VariableArgs m_tmpVariableArgs;
        private BattleAi m_ai;
        private ushort[] m_AIItem = new ushort[BSP_TRAINER_DATA.USE_ITEM_MAX];
        private sbyte[] m_AIChangeIndex = new sbyte[6]; // TODO: Party size maybe?
        private bool[] m_AITrainerMsgCheckedFlag = new bool[AITRAINER_MSG_MAX];
        private ClientSubProc m_subProc;
        private int m_subSeq;
        private ClientSubProc m_selActProc;
        private int m_selActSeq;
        private BTLV_STRPARAM m_strParam = new BTLV_STRPARAM();
        private BTLV_STRPARAM m_strParamSub = new BTLV_STRPARAM();
        private PokeSelParam m_pokeSelParam = new PokeSelParam();
        private PokeSelResult m_pokeSelResult = new PokeSelResult();
        private ServerCmdProc m_scProc;
        private ServerCommand m_serverCmd;
        private int m_scSeq;
        private BtlPokePos[] m_deadPokePos = new BtlPokePos[DefineConstants.BTL_POSIDX_MAX];
        private bool m_isLiveRecSeedSetup;
        private uint m_liveRecWaitCameraSeq;
        private uint m_liveRecSizeSave;
        private WAZAEFF_SYNCDAMAGE_CMD_WORK m_wazaEffDmgSyncWork = new WAZAEFF_SYNCDAMAGE_CMD_WORK();
        private bool m_bWazaEffectDone;
        private bool m_bSyncEffectDone;
        private FriendshipEffectProc m_frEffectProc = new FriendshipEffectProc();
        private uint m_JK3Joker_PrevTurnAttackToLegends;
        private uint m_JK3Legend_PrevTurnUseKyozyuuzan;

        private const int CHAPTER_CTRL_FRAMES = 45;

        private static readonly check_status_up_item_check_tbl_elem[] check_status_up_item_check_tbl = new check_status_up_item_check_tbl_elem[]
        {
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.ATTACK_UP,     BTL_POKEPARAM.ValueID.BPP_ATTACK_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.DEFENCE_UP,    BTL_POKEPARAM.ValueID.BPP_DEFENCE_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.SP_ATTACK_UP,  BTL_POKEPARAM.ValueID.BPP_SP_ATTACK_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.SP_DEFENCE_UP, BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.AGILITY_UP,    BTL_POKEPARAM.ValueID.BPP_AGILITY_RANK),
            new check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID.HIT_UP,        BTL_POKEPARAM.ValueID.BPP_HIT_RATIO),
        };
        private static readonly check_cure_sick_item_tbl_elem[] check_cure_sick_item_check_tbl = new check_cure_sick_item_tbl_elem[]
        {
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.SLEEP_RCV,    WazaSick.WAZASICK_NEMURI),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.POISON_RCV,   WazaSick.WAZASICK_DOKU),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.BURN_RCV,     WazaSick.WAZASICK_YAKEDO),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.ICE_RCV,      WazaSick.WAZASICK_KOORI),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.PARALYZE_RCV, WazaSick.WAZASICK_MAHI),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.PANIC_RCV,    WazaSick.WAZASICK_KONRAN),
            new check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID.MEROMERO_RCV, WazaSick.WAZASICK_MEROMERO),
        };
        private static sbyte SubProc_UI_SelectAction_trainerMessage_clientID;
        private static TrainerMessageID SubProc_UI_SelectAction_trainerMessage_messageID;

        private int scProc_MSG_StdSE_subSeq;
        private int scProc_MSG_SetSE_subSeq;

        private static readonly getWeatherStartMessageTableElem[] getWeatherStartMessageParamTable = new getWeatherStartMessageTableElem[]
        {
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_NONE,       BTL_STRID_STD.ShineStart,      -1),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_SHINE,      BTL_STRID_STD.ShineStart,      BTL_STRID_STD.ShineStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_RAIN,       BTL_STRID_STD.RainStart,       BTL_STRID_STD.RainStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_SNOW,       BTL_STRID_STD.SnowStart,       BTL_STRID_STD.SnowStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_SAND,       BTL_STRID_STD.StormStart,      BTL_STRID_STD.StormStart_OnBattleStart),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_STORM,      BTL_STRID_STD.RainStormStart,  -1),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_DAY,        BTL_STRID_STD.DayStart,        -1),
            new getWeatherStartMessageTableElem(BtlWeather.BTL_WEATHER_TURBULENCE, BTL_STRID_STD.TurbulenceStart, -1),
        };

        private uint scProc_ACT_KinomiPrevWaza_procIdx;
        private int scProc_ACT_FriendshipEffectMsg_effSeq;
        private int scProc_ACT_FriendshipEffectMsg_msgSeq;
        private uint scProc_ACTOP_SwapTokusei_timer;

        private BTL_ACTION_PARAM m_procAction { get => m_actionParam[m_procActionIndex]; }
        private byte m_currentActionCount { get => m_actionCountWork[m_currentActionIndex]; set => m_actionCountWork[m_currentActionIndex] = value; }
        private BattleViewBase m_viewCore { get => _m_viewCore; set => _m_viewCore = value; }

        // TODO
        private void m_viewCore_CMD_EFFECT_DrawEnableTimer(GameTimer.TimerType type, bool enable) { }

        public BTL_CLIENT(MainModule mainModule, BattleEnv pBattleEnv, Adapter adapter, SendDataContainer sendDataContainer, SendDataContainer receiveDataContainer, byte commMode, ushort clientID, byte clientType, BtlBagMode bagMode, bool fRecPlayMode, ulong randSeed)
        {
            unsafe
            {
                m_dummyReturnData =            (uint*)                             BattleUnmanagedMem.Malloc(sizeof(uint));
                m_returnData_ActionSelect =    (ClientSendData.ACTION_SELECT*)     BattleUnmanagedMem.Malloc(sizeof(ClientSendData.ACTION_SELECT));
                m_returnData_ClientLimitTime = (ClientSendData.CLIENT_LIMIT_TIME*) BattleUnmanagedMem.Malloc(sizeof(ClientSendData.CLIENT_LIMIT_TIME));
                m_returnData_RaidBallSelect =  (ClientSendData.RAID_BALL_SELECT*)  BattleUnmanagedMem.Malloc(sizeof(ClientSendData.RAID_BALL_SELECT));
                m_change_escape_code =         (byte*)                             BattleUnmanagedMem.Malloc(sizeof(byte));
            }

            m_pBattleEnv = pBattleEnv;
            m_myID = (byte)clientID;
            m_myType = clientType;
            m_mainModule = mainModule;
            m_procPokeIdx = 0;
            m_viewCore = null;
            m_turnCount = 0;
            m_b1stReadyMsgDisped = false;
            m_isFirstActionSelectDone = false;
            m_tmpVariableArgs = null;

            m_adapter = adapter;
            m_sendDataContainer = sendDataContainer;
            m_receiveDataContainer = receiveDataContainer;
            m_myParty = getPokeCon().GetPartyDataConst(clientID);
            m_serverCmdQueue = new ServerCommandQueue();

            createSimulator();
            createBattleDriver();

            m_gameTimer = new GameTimer();
            m_gameTimer.Initialize();

            m_cmdLimitTime = (ushort)m_mainModule.GetCommandLimitTime();
            m_gameLimitTime = (ushort)m_mainModule.GetGameLimitTime();
            m_clientLimitTime = (ushort)m_mainModule.GetClientLimitTime();

            // Is this right? Compiler did some weird stuff here i think
            m_syncClientTime = default;
            m_raidBossCaptureResult = default;

            m_mainProc = main_Normal;

            m_myState = 0;
            m_cmdCheckServer = null;
            m_commWaitInfoOn = false;
            m_fForceQuitSelAct = false;
            m_cmdCheckTimingCode = 0;
            m_fAITrainerBGMChanged = false;
            m_fCommError = false;
            m_fStdMsgChanged = false;
            m_fCmdCheckEnable = false;
            m_fRecPlayEndTimeOver = false;
            m_fRecPlayEndBufOver = false;
            m_bRecPlayFadeStarted = false;
            m_isWaitingAdapterCommand = false;

            m_random.Initialize();
            m_AIRand.Initialize(randSeed);

            m_fldSim = pBattleEnv.GetFieldStatus();
            m_bagMode = (byte)bagMode;

            RecPlayer_Init(m_recPlayer);

            for (byte i=0; i<m_AIItem.Length; i++)
                m_AIItem[i] = m_mainModule.GetClientUseItem(m_myID, i);

            if (m_myType == (byte)BtlClientType.BTL_CLIENT_TYPE_AI && !fRecPlayMode)
            {
                m_ai = new BattleAi(new BattleAi.SetupParam()
                {
                    mainModule = m_mainModule,
                    pBattleEnv = pBattleEnv,
                    pBattleSimulator = m_battleSimulator,
                    scriptNoBit = m_mainModule.GetClientAIBit(m_myID),
                    randSeed = randSeed,
                    myClientID = (byte)clientID,
                });
            }
            else
            {
                m_ai = null;
            }

            for (int i=0; i<m_AITrainerMsgCheckedFlag.Length; i++)
                m_AITrainerMsgCheckedFlag[i] = false;

            if (m_myType == (byte)BtlClientType.BTL_CLIENT_TYPE_UI && m_mainModule.IsRecordEnable())
                m_recData = new rec.Data();
            else
                m_recData = null;

            if (m_mainModule.IsPlayerSide(m_mainModule.GetClientSide(m_myID)))
                m_mainModule.SetTvNaviData_FrontPoke(m_myParty.GetMemberDataConst(0), m_myParty.GetMemberDataConst(1));

            m_trainerMessageManager = new TrainerMessageManager(m_mainModule);
            m_seq_TrainerMessage = new ClientSeq_TrainerMessage();
            m_seq_WinWild = new ClientSeq_WinWild();
            m_seq_Capture = new ClientSeq_Capture();
            m_viewExpGetDesc.iPtrParty = new PokeParty();

            m_isLiveRecSeedSetup = false;
            m_liveRecWaitCameraSeq = 0;
            m_liveRecSizeSave = 0;
            m_JK3Joker_PrevTurnAttackToLegends = 0;
            m_JK3Legend_PrevTurnUseKyozyuuzan = 0;
        }

        // TODO
        private void createSimulator() { }

        // TODO
        private void createBattleDriver() { }

        // TODO
        public void Dispose() { }

        private POKECON getPokeCon()
        {
            return m_pBattleEnv.GetPokeCon();
        }

        private ServerCommandExecutor getServerCmdExecutor()
        {
        	return this.m_battleDriver.m_serverCmdExecutor;
        }

        private void changeMainProc(ClientMainProc proc)
        {
        	this.m_mainProc = proc;
        	this.m_myState = (byte)0;
        }

        // TODO
        private byte getMyCoverPosNum() { return 0; }

        public bool IsWaitingAdapterCommand()
        {
        	return this.m_isWaitingAdapterCommand;
        }

        // TODO
        private bool main_Normal() { return false; }

        // TODO
        private bool main_ChapterSkip() { return false; }

        // TODO
        public unsafe void registerReceivedData(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, in void* data, uint dataSize) { }

        // TODO
        private bool returnToServer() { return false; }

        private void RecPlayer_Init(RECPLAYER_CONTROL ctrl)
        {
            ctrl.skipTurnCount = 0;
            ctrl.seq = 0;
            ctrl.ctrlCode = 0;
            ctrl.fChapterSkip = false;
            ctrl.fFadeOutStart = false;
            ctrl.fFadeOutDone = false;
            ctrl.fTurnIncrement = false;
            ctrl.fLock = false;
            ctrl.fQuit = false;
            ctrl.handlingTimer = 0;
            ctrl.turnCount = 0;
            ctrl.nextTurnCount = 0;
            ctrl.maxTurnCount = 0;
        }

        // TODO
        private void RecPlayer_Setup(RECPLAYER_CONTROL ctrl, uint turnCnt) { }

        // TODO
        private bool RecPlayer_CheckBlackOut(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private void RecPlayer_TurnIncReq(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private RecCtrlCode RecPlayer_GetCtrlCode(RECPLAYER_CONTROL ctrl) { return RecCtrlCode.RECCTRL_NONE; }

        // TODO
        private void RecPlayer_ChapterSkipOn(RECPLAYER_CONTROL ctrl, uint nextTurnNum) { }

        // TODO
        private void RecPlayer_ChapterSkipOff(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private bool RecPlayer_CheckChapterSkipEnd(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private uint RecPlayer_GetNextTurn(RECPLAYER_CONTROL ctrl) { return 0; }

        // TODO
        private bool RecPlayerCtrl_Lock(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private void RecPlayerCtrl_Unlock(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private void RecPlayer_Quit(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private bool RecPlayer_IsActive(RECPLAYER_CONTROL ctrl) { return false; }

        // TODO
        private void RecPlayerCtrl_Main(RECPLAYER_CONTROL ctrl) { }

        // TODO
        private void AIItem_Setup() { }

        // TODO
        private ushort AIItem_CheckUse(BTL_POKEPARAM bpp, BTL_PARTY party) { return 0; }

        // TODO
        private bool check_status_up_item(ushort itemID, BTL_POKEPARAM bpp) { return false; }

        // TODO
        private bool check_cure_sick_item(ushort itemID, BTL_POKEPARAM bpp) { return false; }

        // TODO
        public void SetRecordPlayerMode(rec.Reader recReader) { }

        public void NotifyCommError()
        {
        	this.m_fCommError = true;
        }

        public unsafe void* GetRecordData(ref uint size)
        {
        	if (this.m_recData != null) {
        	  this.m_recData.GetDataPtr(size);
        	}
        	return default;
        }

        public void AttachViewCore(BattleViewBase viewCore)
        {
        	this._m_viewCore = viewCore;
        }

        public void AttachCmdCheckServer(BTL_SERVER server)
        {
        	this.m_cmdCheckServer = server;
        	this.m_fCmdCheckEnable = true;
        }

        public void DetachCmdCheckServer()
        {
        	this.m_cmdCheckServer = null;
        	this.m_fCmdCheckEnable = false;
        }

        public Adapter GetAdapter()
        {
        	return this.m_adapter;
        }

        public GameTimer GetGameTimer()
        {
        	return this.m_gameTimer;
        }

        // TODO
        public uint GetSyncClientTime(BTL_CLIENT_ID clientID) { return 0; }

        public void SetSyncClientTime(in ServerSendData.CLIENT_LIMIT_TIME time)
        {
        	ServerSendData.CLIENT_LIMIT_TIME_Copy(ref this.m_syncClientTime,time);
        }

        public bool Main()
        {
        	this.m_mainProc.Invoke();
        	return false;
        }

        public void NotifyFadeoutStartForRecPlay()
        {
        	this.m_bRecPlayFadeStarted = true;
        }

        // TODO
        public void SetChapterSkip(uint nextTurnNum) { }

        // TODO
        public void StopChapterSkip() { }

        public bool IsRecPlayerMode()
        {
        	return this.m_myType == '\x02';
        }

        public uint GetRecPlayerMaxChapter()
        {
        	return this.m_recPlayer.maxTurnCount;
        }

        // TODO
        public bool IsChapterSkipMode() { return false; }

        // TODO
        private void setDummyReturnData() { }

        // TODO
        private bool setSubProc(ServerRequest serverReq, out bool fRecCtrlLock)
        {
            fRecCtrlLock = false;
            return false;
        }

        // TODO
        private bool callSubProc() { return false; }

        public bool IsGameTimeOver()
        {
        	if (this.m_myType == '\x02') {
        	  return (ulong)(this.m_fRecPlayEndTimeOver);
        	}
        	if (this.m_gameLimitTime != 0) {
        	  return this.m_gameTimer.IsFinish(0);
        	}
        	return false;
        }

        public bool IsRecPlayBufOver()
        {
        	return this.m_fRecPlayEndBufOver;
        }

        // TODO
        private bool SubProc_UI_Setup(ref int seq) { return false; }

        private bool SubProc_AI_Setup(ref int seq)
        {
        	this.m_cmdLimitTime = (ushort)(this.m_mainModule.m_LimitTimeCommand);
        	this.m_gameLimitTime = (ushort)(this.m_mainModule.m_LimitTimeGame);
        	this.m_clientLimitTime = (ushort)(this.m_mainModule.m_LimitTimeClient);
        	return true;
        }

        // TODO
        private bool SubProc_REC_Setup(ref int seq) { return false; }

        // TODO
        private void enemyPokeHPBase_Update() { }

        // TODO
        private uint enemyPokeHPBase_CheckRatio() { return 0; }

        // TODO
        private BTL_POKEPARAM enemyPokeHPBase_GetTargetPoke() { return null; }

        private void startGameTimeCountDown()
        {
        	this.m_gameTimer.StartCountDown(0,0);
        }

        // TODO
        private void cmdLimit_Start() { }

        private bool cmdLimit_CheckOver()
        {
            if (m_cmdLimitTime == 0)
                return false;

            if (m_fForceQuitSelAct)
                return true;

            if (m_gameTimer.IsFinish(GameTimer.TimerType.COMMAND))
            {
                m_fForceQuitSelAct = true;
                return true;
            }

            if (m_fForceQuitSelAct)
                return true;

            return false;
        }

        private bool checkSelactForceQuit(ClientSubProc nextProc)
        {
            if (cmdLimit_CheckOver())
            {
                if (nextProc != null)
                    selActSubProc_Set(nextProc);

                return true;
            }

            if (!m_fCommError)
                return false;

            if (nextProc != null)
                selActSubProc_Set(nextProc);

            return true;
        }

        // TODO
        private void cmdLimit_End() { }

        private bool cmdComm_checkError()
        {
        	return this.m_fCommError;
        }

        // TODO
        private bool setupSelectStartStr(BTL_POKEPARAM procPoke, BTLV_STRPARAM strParam) { return false; }

        private bool checkFriendshipSpecialMessage(BTL_POKEPARAM procPoke, BTLV_STRPARAM strParam)
        {
        	return false;
        }

        private void selActSubProc_Set(ClientSubProc proc)
        {
            m_selActProc = proc;
            m_selActSeq = 0;
        }

        // TODO
        private bool selActSubProc_Call() { return false; }

        // TODO
        private bool SubProc_UI_SelectAction(ref int seq) { return false; }

        // TODO
        private void onFirstActionSelectStart() { }

        // TODO
        private bool needDisplayTipsForG() { return false; }

        private bool isRandomWaitCameraEnable()
        {
        	return true;
        }

        // TODO
        private bool DecideTrainerMessage_OnSelectAction(ref sbyte clientID, ref TrainerMessageID messageID) { return false; }

        // TODO
        private sbyte DecideTrainerMessage_OnSelectAction_FirstDamage() { return 0; }

        // TODO
        private bool IsTrainerMessageEnable_OnSelectAction_FirstDamage(byte clientID) { return false; }

        // TODO
        private sbyte DecideTrainerMessage_OnSelectAction_LastPokeHpHalf() { return 0; }

        // TODO
        private bool IsTrainerMessageEnable_OnSelectAction_LastPokeHpHalf(byte clientID) { return false; }

        // TODO
        private bool SubProc_REC_SelectAction(ref int seq) { return false; }

        // TODO
        private void setNullActionRecplay() { }

        // TODO
        private bool selact_Start(ref int seq) { return false; }

        // TODO
        private void selact_startMsg(BTLV_STRPARAM strParam) { }

        // TODO
        private void selact_ClearWorks() { }

        // TODO
        private bool selact_ForceQuit(ref int seq) { return false; }

        // TODO
        private void setActionForce(ref BTL_ACTION_PARAM pActionParam, BTL_POKEPARAM poke) { }

        private bool selact_Root(ref int seq)
        {
            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_START)
            {
                selact_root_start(ref seq);
                if (seq != (int)SelActRootSeq.SELACT_ROOTSEQ_WAIT_MSG_CHECK)
                    return false;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_FRIENDSHIP_MSG_WAIT)
            {
                selact_root_friendship_msg_wait(ref seq);
                return false;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_WAIT_MSG_CHECK)
            {
                selact_root_wait_msg_check(ref seq);
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_WAIT_MSG_WAIT)
            {
                if (!_m_viewCore.CMD_WaitMsg())
                    return false;

                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_SEL_START;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_SEL_START)
            {
                var selectAction = new BattleViewBase.SelectActionParam();

                setupSelectActionUIParam(selectAction, m_procPoke, m_procPokeIdx);
                m_procActionUIRet.value = m_procAction;
                _m_viewCore.CMD_UI_SelectAction_Start(selectAction, m_procActionUIRet);

                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_SEL_MAIN;

                return false;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_SEL_MAIN)
            {
                selact_root_sel_main(ref seq);
                m_actionParam[m_procActionIndex] = m_procActionUIRet.value;
                return false;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_WAIT_UI_RESTART)
            {
                if (_m_viewCore.CMD_UI_WaitRestart())
                    seq = (int)SelActRootSeq.SELACT_ROOTSEQ_SEL_START;

                return false;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_FREEFALL_WARN)
            {
                _m_viewCore.CMD_UI_RestartIfNotStandBy();

                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_FREEFALL_WARN_MSG;

                return false;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_FREEFALL_WARN_MSG)
            {
                if (!_m_viewCore.CMD_UI_WaitRestart())
                    return false;

                BTLV_STRPARAM.Setup(m_strParam, BtlStrType.BTL_STRTYPE_STD, BTL_STRID_STD.FreeFallBind);
                BTLV_STRPARAM.AddArg(m_strParam, m_procPoke.GetID());

                _m_viewCore.CMD_StartMsg(m_strParam);
                m_fStdMsgChanged = true;

                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_FREEFALL_WARN_WAIT;

                return false;
            }

            if (seq == (int)SelActRootSeq.SELACT_ROOTSEQ_FREEFALL_WARN_WAIT)
            {
                selact_root_friendship_msg_wait(ref seq);
                return false;
            }

            return false;
        }

        // TODO
        private void setupSelectActionUIParam(BattleViewBase.SelectActionParam pViewParam, BTL_POKEPARAM pActPoke, byte actPokeIdx) { }

        // TODO
        private byte calcAddActionCountSum(byte pokeIdx) { return 0; }

        // TODO
        private void setupCurrentPokeActionPtr() { }

        private bool selact_root_start(ref int seq)
        {
            setupCurrentPokeActionPtr();

            if (checkActionForceSet(m_procPoke, ref m_actionParam[m_procActionIndex]))
            {
                selActSubProc_Set(selact_CheckFinish);
            }
            else
            {
                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_WAIT_MSG_CHECK;
            }

            return false;
        }

        private void incrementAddActionCount()
        {
        	if (this.m_currentActionIndex < this.m_actionCountWork.Length) {
        	  this.m_actionCountWork + (int)this.m_currentActionIndex[0] = this.m_actionCountWork + (int)this.m_currentActionIndex[0] + '\x01';
        	}
        }

        // TODO
        private void decrementAddActionCount() { }

        private bool selact_root_friendship_msg_wait(ref int seq)
        {
            if (_m_viewCore.CMD_WaitMsg())
                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_WAIT_MSG_CHECK;

            return false;
        }

        private bool selact_root_wait_msg_check(ref int seq)
        {
            if (m_prevPokeIdx == m_procPokeIdx && !m_fStdMsgChanged)
            {
                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_SEL_START;
            }
            else
            {
                if (setupSelectStartStr(m_procPoke, m_strParam))
                {
                    _m_viewCore.CMD_StartMsg(m_strParam);
                    m_fStdMsgChanged = false;
                    m_b1stReadyMsgDisped = true;
                }
                m_prevPokeIdx = (sbyte)m_procPokeIdx;
                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_WAIT_MSG_WAIT;
            }

            return false;
        }

        // TODO
        private bool selact_root_sel_main(ref int seq)
        {
            if (checkSelactForceQuit(selact_ForceQuit))
            {
                _m_viewCore.CMD_UI_SelectAction_ForceQuit();
                return false;
            }

            var action = _m_viewCore.CMD_UI_SelectAction_Wait();
            if (m_mainModule.GetRule() == BtlRule.BTL_RULE_SAFARI)
            {
                switch (action)
                {
                    case BtlAction.BTL_ACTION_FIGHT:
                    case BtlAction.BTL_ACTION_SAFARI_BALL:
                        if (!canUseItem(m_strParam, (ushort)ItemNo.SAFARIBOORU, m_procPokeIdx))
                        {
                            selActSubProc_Set(selact_Item);
                            seq = (int)SelActRootSeq.SELACT_ROOTSEQ_SEL_START;
                            return false;
                        }
                        else
                        {
                            m_procActionUIRet.value.gen_cmd = (byte)BtlAction.BTL_ACTION_SAFARI_BALL;
                            m_procActionUIRet.value.gen_pokeID = m_procPoke.GetID();
                            selActSubProc_Set(selact_CheckFinish);
                            return false;
                        }

                    case BtlAction.BTL_ACTION_ITEM:
                    case BtlAction.BTL_ACTION_SAFARI_DORO:
                        m_procActionUIRet.value.gen_cmd = (byte)BtlAction.BTL_ACTION_SAFARI_DORO;
                        m_procActionUIRet.value.gen_pokeID = m_procPoke.GetID();
                        selActSubProc_Set(selact_CheckFinish);
                        return false;

                    case BtlAction.BTL_ACTION_CHANGE:
                    case BtlAction.BTL_ACTION_SAFARI_ESA:
                        m_procActionUIRet.value.gen_cmd = (byte)BtlAction.BTL_ACTION_SAFARI_ESA;
                        m_procActionUIRet.value.gen_pokeID = m_procPoke.GetID();
                        selActSubProc_Set(selact_CheckFinish);
                        return false;

                    case BtlAction.BTL_ACTION_ESCAPE:
                        if (m_procPokeIdx == m_firstPokeIdx)
                        {
                            if (m_procPoke.CheckSick(WazaSick.WAZASICK_FREEFALL) && m_mainModule.GetEscapeMode() != BtlEscapeMode.BTL_ESCAPE_MODE_CONFIRM)
                            {
                                _m_viewCore.CMD_UI_Restart();
                                seq = (int)SelActRootSeq.SELACT_ROOTSEQ_FREEFALL_WARN;
                                return false;
                            }
                            else
                            {
                                selActSubProc_Set(selact_Escape);
                                return false;
                            }
                        }
                        else
                        {
                            do
                            {
                                if (m_procPokeIdx == 0)
                                    return false;

                                m_procPokeIdx--;
                            }
                            while (checkActionForceSet(m_pBattleEnv.GetPokeCon().GetClientPokeData(m_myID, m_procPokeIdx), ref m_procActionUIRet.value)); // Not sure if this is the right action

                            // TODO more here...
                            return false;
                        }
                }
            }
            else
            {
                switch (action)
                {

                }
            }

            // TODO remove when done
            return false;
        }

        // TODO
        private bool canStartG(BTL_POKEPARAM pPoke) { return false; }

        private bool selact_Fight(ref int seq)
        {
            if (seq == (int)Seqselact_Fight.SEQ_START)
            {
                if (!checkWazaForceSet(m_procPoke, ref m_actionParam[m_procActionIndex]))
                {
                    seq = (int)Seqselact_Fight.SEQ_SELECT_WAZA_START;
                    return false;
                }

                selActSubProc_Set(selact_CheckFinish);
                return false;
            }

            if (seq == (int)Seqselact_Fight.SEQ_SELECT_WAZA_START)
            {
                m_procActionUIRet.value = m_procAction;
                m_viewCore.CMD_UI_SelectWaza_Start(m_procPoke, m_procPokeIdx, m_procActionUIRet);

                seq = (int)Seqselact_Fight.SEQ_SELECT_WAZA_WAIT;
                return false;
            }

            if (seq == (int)Seqselact_Fight.SEQ_SELECT_WAZA_WAIT)
            {
                if (checkSelactForceQuit(selact_ForceQuit))
                {
                    m_viewCore.CMD_UI_SelectWaza_ForceQuit();
                    return false;
                }

                var done = m_viewCore.CMD_UI_SelectWaza_Wait();
                m_actionParam[m_procActionIndex] = m_procActionUIRet.value;

                if (!done)
                    return false;

                if (m_procAction.fight_cmd != 0)
                {
                    WazaNo waza = (m_procAction.fight_cmd == 1) ? (WazaNo)m_procAction.fight_waza : WazaNo.NULL;

                    if (m_procPoke.IsGMode() || m_procAction.fight_cmd == 1 || m_procAction.fight_gFlag)
                        waza = GWaza.GetGWaza(waza);

                    if (is_unselectable_waza(m_procPoke, waza, m_strParam))
                    {
                        m_strParam.wait = 0;
                        m_viewCore.CMD_StartMsg(m_strParam);
                        m_fStdMsgChanged = true;

                        seq = (int)Seqselact_Fight.SEQ_WAIT_UNSEL_WAZA_MSG;
                        return false;
                    }
                    else
                    {
                        seq = (int)Seqselact_Fight.SEQ_SELECT_WAZA_END;
                        return false;
                    }
                }

                selActSubProc_Set(selact_Root);
                return false;
            }

            if (seq == (int)Seqselact_Fight.SEQ_SELECT_WAZA_END)
            {
                if (m_viewCore.CMD_UI_SelectWaza_End())
                    seq = (int)Seqselact_Fight.SEQ_CHECK_WAZA_TARGET;

                return false;
            }

            if (seq == (int)Seqselact_Fight.SEQ_CHECK_WAZA_TARGET)
            {
                var rule = m_mainModule.GetRule();
                if (calc.RULE_IsNeedSelectTarget(rule))
                {
                    if (rule != BtlRule.BTL_RULE_RAID || m_mainModule.GetMultiMode() != BtlMultiMode.BTL_MULTIMODE_RAID_P_A)
                    {
                        seq = (int)Seqselact_Fight.SEQ_SELECT_TARGET_START;
                        return false;
                    }

                    if (WAZADATA.GetWazaTarget((WazaNo)m_procAction.fight_waza) != WazaTarget.TARGET_FRIEND_SELECT)
                    {
                        seq = (int)Seqselact_Fight.SEQ_SELECT_TARGET_START;
                        return false;
                    }

                    m_actionParam[m_procActionIndex].fight_targetPos = (int)BtlPokePos.POS_1ST_0;

                    seq = (int)Seqselact_Fight.SEQ_DONE;
                    return false;
                }
                else
                {
                    var pos = m_mainModule.PokeIDtoPokePos(m_pBattleEnv.GetPokeCon(), m_procPoke.GetID());
                    m_actionParam[m_procActionIndex].fight_targetPos = (byte)m_mainModule.GetOpponentPokePos(pos, 0);

                    seq = (int)Seqselact_Fight.SEQ_DONE;
                    return false;
                }
            }

            if (seq == (int)Seqselact_Fight.SEQ_SELECT_TARGET_START)
            {
                m_procActionUIRet.value = m_procAction;
                m_viewCore.CMD_UI_SelectTarget_Start(m_procPokeIdx, m_procPoke, m_procActionUIRet);

                seq = (int)Seqselact_Fight.SEQ_SELECT_TARGET_WAIT;
                return false;
            }

            if (seq == (int)Seqselact_Fight.SEQ_SELECT_TARGET_WAIT)
            {
                if (checkSelactForceQuit(selact_ForceQuit))
                {
                    m_viewCore.CMD_UI_SelectTarget_ForceQuit();
                    return false;
                }

                var result = m_viewCore.CMD_UI_SelectTarget_Wait();
                m_actionParam[m_procActionIndex] = m_procActionUIRet.value;

                switch (result)
                {
                    case BattleViewBase.BtlvResult.NONE:
                    default:
                        return false;

                    case BattleViewBase.BtlvResult.DONE:
                        var waza = (m_procAction.fight_cmd == 1) ? (WazaNo)m_procAction.fight_waza : WazaNo.NULL;
                        var targetPos = (m_procAction.fight_cmd == 1) ? (BtlPokePos)m_procAction.fight_targetPos : BtlPokePos.POS_NULL;
                        if (is_unselectable_target(m_procPoke, waza, targetPos, m_strParam))
                        {
                            m_strParam.wait = 0;
                            m_viewCore.CMD_StartMsg(m_strParam);
                            m_fStdMsgChanged = true;

                            seq = (int)Seqselact_Fight.SEQ_WAIT_UNSEL_TARGET_MSG;
                            return false;
                        }
                        seq = (int)Seqselact_Fight.SEQ_DONE;
                        return false;

                    case BattleViewBase.BtlvResult.CANCEL:
                        seq = (int)Seqselact_Fight.SEQ_SELECT_WAZA_START;
                        return false;
                }
            }

            if (seq == (int)Seqselact_Fight.SEQ_WAIT_UNSEL_WAZA_MSG)
            {
                if (!m_viewCore.CMD_WaitMsg())
                    return false;

                m_viewCore.CMD_UI_SelectWaza_Restart(m_procPokeIdx);
                seq = (int)Seqselact_Fight.SEQ_SELECT_WAZA_WAIT;
                return false;
            }

            if (seq == (int)Seqselact_Fight.SEQ_WAIT_UNSEL_TARGET_MSG)
            {
                if (!m_viewCore.CMD_WaitMsg())
                    return false;

                m_procActionUIRet.value = m_procAction;
                m_viewCore.CMD_UI_SelectTarget_Start(m_procPokeIdx, m_procPoke, m_procActionUIRet);

                seq = (int)Seqselact_Fight.SEQ_SELECT_TARGET_WAIT;
                return false;
            }

            if (seq == (int)Seqselact_Fight.SEQ_DONE)
            {
                if (m_procAction.fight_cmd == 1 && m_procAction.fight_gFlag)
                    m_isGSelectedThisTurn = true;

                selActSubProc_Set(selact_CheckFinish);
                return false;
            }

            return false;
        }

        // TODO
        private bool needGButtonDisplay(BTL_POKEPARAM pActPoke) { return false; }

        // TODO
        private bool selact_SelectChangePokemon(ref int seq) { return false; }

        // TODO
        private bool selact_Item(ref int seq) { return false; }

        // TODO
        private bool canSelectItem(BTLV_STRPARAM pCantMessage) { return false; }

        private bool canUseItem(BTLV_STRPARAM pCantMessage, ushort itemno, byte procPokeIdx)
        {
            return !calc.ITEM_IsBall(itemno) || canUseBall(pCantMessage, itemno, procPokeIdx);
        }

        // TODO
        private bool canUseBall(BTLV_STRPARAM pCantMessage, ushort itemno, byte procPokeIdx) { return false; }

        // TODO
        private void registerLastSelectedBall(uint itemno) { }

        // TODO
        private BTL_POKEPARAM getBallTarget() { return null; }

        // TODO
        private bool checkBallTargetHide() { return false; }

        // TODO
        private bool selact_Escape(ref int seq) { return false; }

        // TODO
        private bool canSelectEscape(BTLV_STRPARAM pCantMessage) { return false; }

        // TODO
        private bool needEscapeConfirm(BTLV_STRPARAM pConfirmMessage) { return false; }

        // TODO
        private bool selact_CheckFinish(ref int seq) { return false; }

        // TODO
        private void setupSelActReturnData() { }

        // TODO
        private void storeActionSelectSendData(BTL_ACTION_PARAM[] actionParamArray, uint actionNum) { }

        // TODO
        private unsafe void storeActionSelectSendData(BTL_ACTION_PARAM* actionParamArray, uint actionNum) { }

        // TODO
        private void sendSelectedRaidActionIconID() { }

        private void clearSelectedRaidActionIconID()
        {
        	if (this.m_mainModule.m_rule == 2) {
        	  this.m_adapter.ClearRaidAction();
        	}
        }

        // TODO
        private bool selact_Finish(ref int seq) { return false; }

        // TODO
        private void selItemWork_Init() { }

        // TODO
        private void selItemWork_Reserve(byte pokeIdx, ushort itemID, bool bFromPokeSelect) { }

        // TODO
        private bool selItemWork_IsFromPokeSelect(byte pokeIdx) { return false; }

        // TODO
        private void selItemWork_Restore(byte pokeIdx) { }

        private void selItemWork_Quit()
        {
        	if ((this.m_bagMode == 0) && (0 < this.m_selItemWork.Length)) {
        	  var uVar1 = 0;
        	  do {
        	    selItemWork_Restore(uVar1);
        	    uVar1 = (ulong)((int)uVar1 + 1);
        	  } while ((long)uVar1 < (long)this.m_selItemWork.Length);
        	}
        }

        // TODO
        private bool checkActionForceSet(BTL_POKEPARAM bpp, ref BTL_ACTION_PARAM action) { return false; }

        // TODO
        public bool IsCheerMode() { return false; }

        // TODO
        private bool checkWazaForceSet(BTL_POKEPARAM bpp, ref BTL_ACTION_PARAM action) { return false; }

        // TODO
        private void setWaruagakiAction(ref BTL_ACTION_PARAM dst, BTL_POKEPARAM bpp) { }

        // TODO
        private bool is_unselectable_waza(BTL_POKEPARAM bpp, WazaNo waza, BTLV_STRPARAM strParam) { return false; }

        // TODO
        private bool is_unselectable_target(BTL_POKEPARAM bpp, WazaNo waza, BtlPokePos targetPos, BTLV_STRPARAM strParam) { return false; }

        // TODO
        private byte storeSelectableWazaFlag(BTL_POKEPARAM bpp, bool checkGWaza, bool[] dst) { return 0; }

        // TODO
        public CantEscapeCode isForbidPokeChange(BTL_POKEPARAM procPoke, out byte pokeID, out ushort tokuseiID)
        {
            pokeID = 0;
            tokuseiID = 0;
            return CantEscapeCode.CANTESC_START;
        }

        // TODO
        public CantEscapeCode isForbidEscape(ref byte pokeID, ref ushort tokuseiID) { return CantEscapeCode.CANTESC_START; }

        // TODO
        private CantEscapeCode checkForbidChangeEscapeCommon(BTL_POKEPARAM procPoke, ref byte pokeID, ref ushort tokuseiID) { return CantEscapeCode.CANTESC_START; }

        // TODO
        private bool checkForbitEscapeEffective_Kagefumi(BTL_POKEPARAM procPoke) { return false; }

        private bool checkForbitEscapeEffective_Arijigoku(BTL_POKEPARAM procPoke)
        {
        	if (((this.m_fldSim.CheckEffect(2) & 1) != 0) ||
        	   (this.m_fldSim.CheckEffect(2) = BTL_POKEPARAM.CheckSick(procPoke,0x20), (FieldStatus.CheckEffect(this.m_fldSim,2) & 1) != 0)) {
        	  return true;
        	}
        	this.m_fldSim.CheckEffect(2) = BTL_POKEPARAM.CheckSick(procPoke,0x15);
        	var bVar1 = true;
        	if ((procPoke.GetItemEffective(ref this.m_fldSim) != 0x116) && ((FieldStatus.CheckEffect(this.m_fldSim,2) & 1) == 0)) {
        	  var iVar3 = procPoke.GetValue(0x13);
        	  if (iVar3 != 0x1a) {
        	    this.m_fldSim.CheckEffect(2) = BTL_POKEPARAM.IsMatchType(procPoke,2);
        	    if ((((this.m_fldSim.CheckEffect(2) & 1) == 0) &&
        	        (this.m_fldSim.CheckEffect(2) = BTL_POKEPARAM.CheckSick(procPoke,0x1f), (FieldStatus.CheckEffect(this.m_fldSim,2) & 1) == 0)) &&
        	       (this.m_fldSim.CheckEffect(2) = BTL_POKEPARAM.CheckSick(procPoke,0x21), (FieldStatus.CheckEffect(this.m_fldSim,2) & 1) == 0)) {
        	      return procPoke.GetItemEffective(ref this.m_fldSim) != 0x21d;
        	    }
        	    return false;
        	  }
        	  bVar1 = false;
        	}
        	return bVar1;
        }

        // TODO
        private bool checkForbitEscapeEffective_Jiryoku(BTL_POKEPARAM procPoke) { return false; }

        // TODO
        private void changeAI_InitWork() { }

        // TODO
        public bool changeAI_CheckReserve(byte pokeIndexWithinParty) { return false; }

        private void changeAI_SetReserve(byte outPokeIdx, byte inPokeIdx)
        {
        	var uVar1 = (uint)outPokeIdx & 0xff;
        	if ((int)uVar1 < (int)this.m_AIChangeIndex.Length) {
        	  if (this.m_AIChangeIndex.Length <= uVar1) {
        	  }
        	  this.m_AIChangeIndex + (outPokeIdx & 0xff)[0] = inPokeIdx;
        	}
        }

        // TODO
        public bool IsPuttablePokemonExist() { return false; }

        // TODO
        private BTL_POKEPARAM changeAI_SupposeEnemy(BtlPokePos basePos) { return null; }

        // TODO
        private bool SubProc_AI_SelectAction(ref int seq) { return false; }

        // TODO
        private byte getAIPokeActNum(BTL_POKEPARAM pPoke) { return 0; }

        // TODO
        private BTL_ACTION_PARAM buildActionParamFromAiResult(ref BTL_ACTION_PARAM actionParam, byte actPokeIndex, BTL_POKEPARAM actPoke, BTL_PARTY actPokeParty, in BattleAi.Result aiResult) { return default; }

        // TODO
        private void buildActionParamFromAiResult_Fight(ref BTL_ACTION_PARAM actionParam, BTL_POKEPARAM actPoke, in BattleAi.Result aiResult) { }

        // TODO
        private void buildActionParam_Safari(ref BTL_ACTION_PARAM actionParam, byte actPokeIndex, BTL_POKEPARAM actPoke) { }

        // TODO
        private bool canStartGForNPC(BTL_POKEPARAM pActPoke) { return false; }

        // TODO
        private void decideRaidBossGWazaAction(ref BTL_ACTION_PARAM destAction) { }

        // TODO
        private BtlPokePos decideRaidBossGWazaTarget() { return BtlPokePos.POS_1ST_0; }

        // TODO
        private void correctRaidBossGWazaTarget_JK3(RaidBoss.SelectTargetParam pSelectParam) { }

        // TODO
        private WazaNo decideRaidBossWaza(BTL_POKEPARAM boss, BTL_POKEPARAM target) { return WazaNo.AAMUHANMAA; }

        // TODO
        private bool isRaidBossGWazaUseTurn(BTL_POKEPARAM boss) { return false; }

        private bool canRaidBossUseGWazaIfNotG(BTL_POKEPARAM boss)
        {
        	return false;
        }

        // TODO
        public byte countPuttablePokemons(byte[] list) { return 0; }

        // TODO
        private byte countPuttablePokemons_sub(byte[] list, byte numFrontPos) { return 0; }

        // TODO
        private unsafe void sortPuttablePokemonList(byte* list, byte numPoke, BTL_POKEPARAM target, BtlPokePos posForCheckEffect) { }

        private bool changeAI_IsSpecialMons(BTL_POKEPARAM bpp)
        {
        	if ((this.m_mainModule.IsCompetitorScenarioMode() & 1) != 0) {
        	  var uVar1 = bpp.GetID();
        	  this.m_mainModule = this.m_mainModule.IsGEnableByNPC(uVar1);
        	  return this.m_mainModule;
        	}
        	return false;
        }

        // TODO
        private bool isExistHPRecoverEffect(BtlPokePos pos) { return false; }

        // TODO
        private void setupPokeSelParam(byte numSelect, PokeSelParam param, PokeSelResult result) { }

        // TODO
        private void storePokeSelResult(PokeSelResult res) { }

        // TODO
        private void storePokeSelResult_ForceQuit() { }

        // TODO
        private byte storeMyChangePokePos(BtlPokePos[] myCoverPos) { return 0; }

        // TODO
        private bool SubProc_UI_SelectChangeOrEscape(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_SelectPokemonForCover(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_SelectPokemonForChange(ref int seq) { return false; }

        // TODO
        private bool SubProc_AI_SelectPokemon(ref int seq) { return false; }

        // TODO
        private void sortChangePos(BtlPokePos[] posAry, uint posCnt) { }

        // TODO
        private bool SubProc_REC_SelectPokemon(ref int seq) { return false; }

        // TODO
        private bool selectPokemonUI_Core(ref int seq, bool bForceChangeMode) { return false; }

        // TODO
        private bool SubProc_UI_ConfirmIrekae(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_RecordData(ref int seq) { return false; }

        private bool SubProc_REC_ExitCommTrainer(ref int seq)
        {
        	if (this._m_viewCore != null) {
        	  var uVar1 = SubProc_ExitCommTrainer(seq,1);
        	  return uVar1;
        	}
        	return true;
        }

        // TODO
        private bool SubProc_UI_ExitCommTrainer(ref int seq) { return false; }

        // TODO
        private bool SubProc_ExitCommTrainer(ref int seq, bool isRecPlayMode) { return false; }

        // TODO
        private BtlResult expandServerResult(out ResultCause resultCause)
        {
            resultCause = ResultCause.RESULT_CAUSE_TIMEOVER;
            return BtlResult.BTL_RESULT_LOSE;
        }

        // TODO
        private bool getVsCommTrainerExitMessage(BTLV_STRPARAM strParam, BtlResult battleResult, bool isMultiMode) { return false; }

        private bool isEnemyClientDouble()
        {
        	return this.m_mainModule.GetEnemyClientID(0) != MainModule.GetEnemyClientID(this.m_mainModule,1);
        }

        // TODO
        private void trainerGraphicIn(int client_idx) { }

        // TODO
        private void msgWinningTrainerStart() { }

        private bool SubProc_REC_ExitForNPC(ref int seq)
        {
        	if (this._m_viewCore != null) {
        	  var uVar1 = SubProc_UI_ExitForNPC();
        	  return uVar1;
        	}
        	return true;
        }

        // TODO
        private bool SubProc_UI_ExitForNPC(ref int seq) { return false; }

        private bool SubProc_REC_ExitForSubwayTrainer(ref int seq)
        {
        	if (this._m_viewCore != null) {
        	  var uVar1 = SubProc_ExitForSubwayTrainer(seq,1);
        	  return uVar1;
        	}
        	return true;
        }

        // TODO
        private bool SubProc_UI_ExitForSubwayTrainer(ref int seq) { return false; }

        // TODO
        private bool SubProc_ExitForSubwayTrainer(ref int seq, bool isRecPlayMode) { return false; }

        // TODO
        private void setupSubwayTrainerMsg(BtlResult result, byte client_idx) { }

        // TODO
        public void GetBonusMoneyGettingStr(BTLV_STRPARAM strParam, uint bonus) { }

        // TODO
        private void setBonusMoneyGettingStr(BTLV_STRPARAM strParam, uint bonus) { }

        // TODO
        private bool SubProc_UI_WinWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_LoseWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_ForceQuitWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_CaptureWild(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_NotifyTimeUp(ref int seq) { return false; }

        // TODO
        private void getTimeUpMessage(out uint strID, out BtlStrType strType)
        {
            strID = 0;
            strType = BtlStrType.BTL_STRTYPE_NULL;
        }

        // TODO
        private void getTimeUpMessage_ClientLimitTime(out uint strID, out BtlStrType strType)
        {
            strID = 0;
            strType = BtlStrType.BTL_STRTYPE_NULL;
        }

        // TODO
        private bool SubProc_UI_FadeOut(ref int seq) { return false; }

        // TODO
        private bool SubProc_REC_FadeOut(ref int seq) { return false; }

        // TODO
        public bool isEvolveEnablePokeExsist() { return false; }

        private bool SubProc_UI_SendLastDataAgain(ref int seq)
        {
        	uint uVar3;
        	if (this.m_sendDataContainer.GetLatestData() == 0) {
        	  this.m_returnDataSerialNumber = (ushort)0x310000;
        	  this.m_returnDataPtr = 0;
        	  uVar3 = 0;
        	}
        	else {
        	  var uVar2 = SendData.GetSerialNumber(this.m_sendDataContainer.GetLatestData(),0);
        	  this.m_returnDataSerialNumber = (ushort)(uVar2);
        	  var uVar1 = SendData.GetServerSequence(this.m_sendDataContainer.GetLatestData(),0);
        	  this.m_returnDataServerSeq = (ServerSequence)(uVar1);
        	  uVar1 = SendData.GetServerRequest(this.m_sendDataContainer.GetLatestData(),0);
        	  this.m_returnDataServerRequest = (ServerRequest)(uVar1);
        	  var uVar5 = SendData.GetData(this.m_sendDataContainer.GetLatestData(),0);
        	  this.m_returnDataPtr = uVar5;
        	  uVar3 = SendData.GetDataSize(this.m_sendDataContainer.GetLatestData(),0);
        	}
        	this.m_returnDataSize = uVar3;
        	return true;
        }

        // TODO
        private bool SubProc_UI_SendClientLimitTime(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_SyncClientLimitTime(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_RaidBossCapture_Start(ref int seq) { return false; }

        // TODO
        private uint getRaidBossCaptureStartSeqNo() { return 0; }

        // TODO
        private bool SubProc_UI_RaidBossCapture_SelectBall(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_RaidBossCapture_Result(ref int seq) { return false; }

        // TODO
        private bool SubProc_UI_LoseRaid(ref int seq) { return false; }

        private bool SubProc_REC_ServerCmd(ref int seq)
        {
        	if (this._m_viewCore != null) {
        	  var uVar1 = SubProc_UI_ServerCmd();
        	  return uVar1;
        	}
        	return true;
        }

        // TODO
        private ServerCmdProc dispatchServerCmdProc(ServerCommand cmd) { return null; }

        // TODO
        private bool SubProc_UI_ServerCmd(ref int seq) { return false; }

        private bool SubProc_AI_ServerCmd(ref int seq)
        {
        	return true;
        }

        // TODO
        private void storeWazaEffectSyncDamageParams(WAZAEFF_SYNCDAMAGE_CMD_WORK work, ServerCommand[] pTargetCmdList) { }

        // TODO
        private bool putWazaEffSyncDamage(WAZAEFF_SYNCDAMAGE_CMD_WORK work) { return false; }

        // TODO
        private bool scProc_ACT_MemberOutMsg(ref int seq, int[] args) { return false; }

        // TODO
        private ushort checkMemberOutStrID(byte clientID, byte pokeID, out bool fClientArg)
        {
            fClientArg = false;
            return 0;
        }

        // TODO
        private bool scProc_ACT_MemberOut(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MemberIn(ref int seq, int[] args) { return false; }

        // TODO
        private bool IsTrainerMessageEnable_OnLastPokeIn(byte clientID) { return false; }

        // TODO
        private void StartTrainerMessage(byte clientID, TrainerMessageID messageID) { }

        private bool UpdateTrainerMessage()
        {
        	this.m_seq_TrainerMessage.Update();
        	return this.m_seq_TrainerMessage.m_isFinished;
        }

        // TODO
        private ushort checkMemberPutStrID(BTL_POKEPARAM putPoke) { return 0; }

        // TODO
        private ushort getMemberPutStrID(BTL_POKEPARAM putPoke, BTL_POKEPARAM opponentPoke) { return 0; }

        // TODO
        private bool scProc_MSG_Std(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_MSG_StdSE(ref int seq, int[] args) { return false; }

        // TODO
        private unsafe bool scproc_msgStdCore(ref int seq, ushort strID, int* args, int argsLen) { return false; }

        // TODO
        private bool scProc_MSG_Set(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_MSG_SetSE(ref int seq, int[] args) { return false; }

        // TODO
        private unsafe bool scproc_msgSetCore(ref int seq, ushort strID, int* args, int argsLen) { return false; }

        // TODO
        private bool scProc_MSG_Waza(ref int seq, int[] args) { return false; }

        // TODO
        private bool needWazaMessageDisplay(WazaNo wazano, WazaTarget wazaRange, BtlPokePos attackerPos, BtlPokePos targetPos) { return false; }

        // TODO
        private bool scProc_ACT_WazaEffect(ref int seq, int[] args) { return false; }

        // TODO
        private WazaEffectCmdProcResult scproc_wazaEffProc_Start(int[] args) { return WazaEffectCmdProcResult.WAZAEFF_CMD_RESULT_NO_PROC; }

        // TODO
        private bool wazaEff_IsOmitFriendAttackEffect(WazaNo waza, WazaTarget wazaRange, BtlPokePos atkPokePos, BtlPokePos defPokePos) { return false; }

        // TODO
        private WazaTarget checkWazaRange(WazaNo waza, BtlPokePos atPokePos) { return WazaTarget.TARGET_OTHER_SELECT; }

        // TODO
        private bool scProc_ACT_TameWazaHide(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_WazaDmg(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_WazaDmg_Plural(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_WazaIchigeki(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_SickIcon(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_ConfDamage(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Dead(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Relive(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_RankDown(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_RankUp(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncWeatherPassedTurn(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetSpActPriority(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetActionRecord(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddEscapeInfo(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallBreak(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallGaugeAdd(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallGaugeSub(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallGaugeInit(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallDecRepairTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GWallRepair(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_G_Start(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_G_End(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_G_IncTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GGauge_Inc(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GGauge_Empty(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_DecReinforceTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_SetReinforceTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_SetAngry(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_GWazaUseSchedule_DecTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_GWazaUseSchedule_SetUsed(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBoss_GWazaUseSchedule_Reset(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GRights_Transfer(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GRights_Invalidate(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_GRights_IncTurn(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_GRights_Get(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_GRights_Get_MySelf(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_GRights_Get_Others(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBattleStatus_IncAllDeadCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBattleStatus_IncTurnCountAfterAllDead(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RaidBattleStatus_ResetTurnCountAfterAllDead(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_RaidResult(ref int seq, int[] args) { return false; }

        // TODO
        private void setupRaidRewardParam(BattleViewBase.RaidRewardParam pRewardParam) { }

        // TODO
        private bool scProc_ACT_SummarizedGShockEffect(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_BattleTalk(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_TurnStart(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_G_Start(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_G_End(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_WeatherStart(ref int seq, int[] args) { return false; }

        // TODO
        private bool needWeatherStartEffect(ChangeWeatherCause cause) { return false; }

        // TODO
        private int getWeatherStartMessage(BtlWeather weather, ChangeWeatherCause cause) { return 0; }

        // TODO
        private bool scProc_ACT_WeatherEnd(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_WeatherEnd(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_SimpleHP(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_UseItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_KinomiPrevWaza(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Kill(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_Move(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Move(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MigawariCreate(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MigawariDelete(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Hensin(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_Hensin(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MigawariDamage(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_PlayWinBGM(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_MsgWinHide(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_FriendshipEffect(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_FriendshipEffectMsg(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Exp_InitParam(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Exp_AddParam(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Exp(ref int seq, int[] args) { return false; }

        // TODO
        private void updatePokeParamByLevelUp(in BattleViewBase.ExpGetResult result) { }

        // TODO
        private bool copyWaza(PokemonParam pDest, PokemonParam pSrc) { return false; }

        // TODO
        private bool scProc_OP_AddExp(ref int seq, int[] args) { return false; }

        private bool scProc_ExArg(ref int seq, int[] args)
        {
        	this.m_stdVariableArgs.Setup(args);
        	return true;
        }

        // TODO
        private bool scProc_ExAssignClient_Start(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveForceWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveForceAllWazaHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddTokuseiHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveTokuseiHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_SwapTokuseiHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddItemHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveItemHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddPosHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemovePosHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_SleepSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_WakeSideHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddFieldHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveFieldHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddDefaultPowerUpHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveDefaultPowerUpHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_AddRaidBossHandler(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_RemoveRaidBossHandler(ref int seq, int[] args) { return false; }

        public bool PrintCallback(PrintCallbackArg arg)
        {
        	return true;
        }

        // TODO
        private bool scProc_ACT_BallThrow(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_BallThrowCaptured(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_BallThrowForbidden(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_ChangeTokusei(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACTOP_SwapTokusei(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_FakeDisable(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectSimple(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectByPos(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_PluralEx2ndHit(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectByVector(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectBySide(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_EffectField(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangeForm(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_ChangeForm(ref int seq, int[] args) { return false; }

        // TODO
        private void updateClientPublicInformation_FormNo(in BTL_POKEPARAM poke) { }

        // TODO
        private bool scProc_TOKWIN_In(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_TOKWIN_Out(ref int seq, int[] args) { return false; }

        // TODO
        private void notifyTokuseiToAI(byte pokeID) { }

        // TODO
        private bool scProc_OP_HpMinus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_HpPlus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPMinus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPMinus_Org(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_WazaUsed(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncWazaUsedCount(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncWazaKillCount(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_HpZero(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPPlus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PPPlus_Org(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankUp(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankDown(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankSet8(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankRecover(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankReset(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RankUpReset(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddCritical(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SickSet(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_CurePokeSick(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_CureWazaSick(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_MemberIn(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangePokeType(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ExPokeType(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_WSTurnCheck(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ConsumeItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_UpdateUseWaza(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetContFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ResetContFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetTurnFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ResetTurnFlag(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetPermFlag(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetBattleFlag(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RemoveBattleFlag(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncBattleCount_Unique(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncBattleCount_Client(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncBattleCount_Side(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncPokeTurnCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangeTokusei(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_UpdateWazaNumber(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_OutClear(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_DeadClear(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddFldEff(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddFldEffDepend(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ChangeGround(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_DelFldEffDepend(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RemoveFldEff(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetPokeCounter(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetPokePermCounter(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddPokePermCounter(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncKillCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_BatonTouch(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_MigawariCreate(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_MigawariDelete(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetFakeSrc(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_FakeDisable(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_ClearConsumedItem(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_CureSickDependPoke(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddWazaDamage(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_TurnCheck(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_IncFieldTurn(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetDoryoku(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_AddEffort_G(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_StartPosEff(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_RemovePosEff(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_UpdatePosEffectParam(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PGLRecord(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_Add(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_Remove(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_IncTurnCount(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SideEffect_Swap(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PublishClientInformation_AppaearPokemon(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_PublishClientInformation_HavePokemonItem(ref int UnnamedParameter, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetStatus(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_OP_SetWeight(ref int seq, int[] args) { return false; }

        private VariableArgs PushTmpVariableArgsWork(VariableArgs newArgs)
        {
        	this.m_tmpVariableArgs = newArgs;
        	return this.m_tmpVariableArgs;
        }

        private void PopTmpVariableArgsWork(VariableArgs oldArgs)
        {
        	this.m_tmpVariableArgs = oldArgs;
        }

        private byte GetVariableArgsCount()
        {
        	if (this.m_tmpVariableArgs != null) {
        	  return (byte)(this.m_tmpVariableArgs.m_cnt);
        	}
        	return (byte)(this.m_stdVariableArgs.m_cnt);
        }

        private int GetVariableArgs(byte idx)
        {
        	if (this.m_tmpVariableArgs != null) {
        	  this.m_tmpVariableArgs.GetArg(idx);
        	}
        	this.m_stdVariableArgs.GetArg(idx);
        	return 0;
        }

        public byte GetClientID()
        {
        	return (byte)(this.m_myID);
        }

        // TODO
        public BTL_PARTY GetParty() { return null; }

        public BtlWeather GetWeather()
        {
        	this.m_fldSim.GetWeather();
        	return (BtlWeather)0;
        }

        public uint GetTurnCount()
        {
        	this.m_pBattleEnv.m_counter.Get(0);
        	return 0;
        }

        // TODO
        public BtlPokePos GetProcPokePos() { return BtlPokePos.POS_1ST_0; }

        public bool IsUnselectableWaza(BTL_POKEPARAM bpp, WazaNo waza)
        {
        	is_unselectable_waza();
        	return false;
        }

        // TODO
        private bool scProc_OP_DecBattleCount_Unique(ref int seq, int[] args) { return false; }

        // TODO
        private bool scProc_ACT_Safari(ref int seq, int[] args) { return false; }

        // TODO
        public bool CanChangePoke(BTL_POKEPARAM bpp) { return false; }

        public enum PrintCallbackArg : int
        {
            PRINTCB_RUN = 0,
            PRINTCB_JUST_DONE = 1,
            PRINTCB_AFTER_DONE = 2,
        }

        public enum CantEscapeCode : int
        {
            CANTESC_START = 0,
            CANTESC_KAGEFUMI = 0,
            CANTESC_ARIJIGOKU = 1,
            CANTESC_JIRYOKU = 2,
            CANTESC_TOOSENBOU = 3,
            CANTESC_FAIRY_LOCK = 4,
            CANTESC_MAX = 5,
            CANTESC_NULL = 5,
        }

        private delegate bool ClientMainProc();

        private delegate bool ClientSubProc(ref int seq);

        private delegate bool ServerCmdProc(ref int seq, int[] args);

        private enum RecCtrlCode : int
        {
            RECCTRL_NONE = 0,
            RECCTRL_QUIT = 1,
            RECCTRL_CHAPTER = 2,
        }

        private sealed class RECPLAYER_CONTROL
        {
            public byte seq;
            public byte ctrlCode;
            public bool fChapterSkip;
            public bool fFadeOutStart;
            public bool fFadeOutDone;
            public bool fTurnIncrement;
            public bool fLock;
            public bool fQuit;
            public ushort handlingTimer;
            public ushort turnCount;
            public ushort nextTurnCount;
            public ushort maxTurnCount;
            public ushort skipTurnCount;
        }

        private sealed class SEL_ITEM_WORK
        {
            public ushort itemNo;
            public bool bFromPokeSelect;
        }

        private enum WazaEffectCmdProcResult : int
        {
            WAZAEFF_CMD_RESULT_NO_PROC = 0,
            WAZAEFF_CMD_RESULT_PROC_NO_SYNC = 1,
            WAZAEFF_CMD_RESULT_PROC_SYNC = 2,
        }

        private sealed class VariableArgs
        {
            private int[] m_args = new int[BattleServerConst.BTL_SERVERCMD_ARG_MAX];
            private byte m_cnt;

            public void Dispose()
            {
                // Empty
            }

            public VariableArgs()
            {
                Clear();
            }

            public void Clear()
            {
                m_cnt = 0;
                for (int i=0; i<m_args.Length; i++)
                    m_args[i] = 0;
            }

            // TODO
            public void Setup(int[] cmd_args) { }

            public byte GetCount()
            {
            	return (byte)(this.m_cnt);
            }

            public int GetArg(byte idx)
            {
            	var uVar1 = (uint)idx & 0xff;
            	if ((int)this.m_args.Length <= (int)uVar1) {
            	  return 0;
            	}
            	if (uVar1 < this.m_args.Length) {
            	  return this.m_args + (idx & 0xff) * 4[0];
            	}
            }
        }

        private sealed class WAZAEFF_SYNCDAMAGE_CMD_WORK
        {
            public uint cmdCount;
            public StoreElem[] store = Arrays.InitializeWithDefaultInstances<StoreElem>(BattleServerConst.BTL_SERVERCMD_ARG_MAX);

            public sealed class StoreElem
            {
                public ServerCmdProc cmdProc;
                public ServerCommand cmd;
                public int[] cmdArgs = new int[BattleServerConst.BTL_SERVERCMD_ARG_MAX];
                public int seq;
                public bool bDone;
                public VariableArgs variableArgs = new VariableArgs();
            }
        }

        private enum SelActRootSeq : int
        {
            SELACT_ROOTSEQ_START = 0,
            SELACT_ROOTSEQ_FRIENDSHIP_MSG_WAIT = 1,
            SELACT_ROOTSEQ_WAIT_MSG_CHECK = 2,
            SELACT_ROOTSEQ_WAIT_MSG_WAIT = 3,
            SELACT_ROOTSEQ_SEL_START = 4,
            SELACT_ROOTSEQ_SEL_MAIN = 5,
            SELACT_ROOTSEQ_WAIT_UI_RESTART = 6,
            SELACT_ROOTSEQ_FREEFALL_WARN = 7,
            SELACT_ROOTSEQ_FREEFALL_WARN_MSG = 8,
            SELACT_ROOTSEQ_FREEFALL_WARN_WAIT = 9,
        }

        private sealed class FriendshipEffectProc
        {
            private MainModule m_mainModule;
            private POKECON m_pokeCon;
            private BattleViewBase m_viewCore;
            internal byte m_myID;
            private byte m_numCoverPos;
            private byte m_searchIdx;
            private int m_step;

            public FriendshipEffectProc()
            {
                m_mainModule = null;
                m_pokeCon = null;
                m_viewCore = null;
                m_myID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
                m_numCoverPos = 0;
                m_searchIdx = 0;
                m_step = -1;
            }

            public void Dispose()
            {
                // Empty
            }

            public void Start(MainModule mainModule, POKECON pokeCon, BattleViewBase viewCore, byte myID, byte numCoverPos)
            {
            	this.m_mainModule = mainModule;
            	this.m_pokeCon = pokeCon;
            	this.m_viewCore = viewCore;
            	this.m_numCoverPos = (byte)(numCoverPos);
            	this.m_myID = (byte)(myID);
            	this.m_step = 0;
            	this.m_searchIdx = (byte)0;
            }

            // TODO
            public bool Wait() { return false; }

            // TODO
            private int checkEffectNo(BTL_POKEPARAM bpp) { return 0; }

            // TODO
            public static bool S_IsEnable(BTL_POKEPARAM bpp) { return false; }
        }

        private enum main_NormalSeq : int
        {
            SEQ_READ_ACMD = 0,
            SEQ_EXEC_CMD = 1,
            SEQ_RETURN_TO_SV = 2,
            SEQ_RETURN_TO_SV_QUIT = 3,
            SEQ_RECPLAY_CTRL = 4,
            SEQ_RECPLAY_STOP = 5,
            SEQ_BGM_FADEOUT = 6,
            SEQ_WAIT_RECPLAY_FADEOUT = 7,
            SEQ_COMM_ERROR = 8,
            SEQ_WAIT_CLEANUP_FOR_COMM_ERROR = 9,
            SEQ_QUIT = 10,
        }

        private enum main_ChapterSkipSeq : int
        {
            SEQ_RECPLAY_START = 0,
            SEQ_RECPLAY_READ_ACMD = 1,
            SEQ_RECPLAY_EXEC_CMD = 2,
            SEQ_RECPLAY_RETURN_TO_SV = 3,
            SEQ_RECPLAY_FADEIN = 4,
            SEQ_RECPLAY_QUIT = 5,
        }

        private enum SeqRecPlayerCtrl_Main : int
        {
            SEQ_DEFAULT = 0,
            SEQ_FADEOUT = 1,
            SEQ_STAY = 2,
        }

        private struct check_status_up_item_check_tbl_elem
        {
            public Pml.Item.ItemData.PrmID itemParamID;
            public BTL_POKEPARAM.ValueID rankID;

            public check_status_up_item_check_tbl_elem(Pml.Item.ItemData.PrmID itemParamID, BTL_POKEPARAM.ValueID rankID)
            {
                this.itemParamID = itemParamID;
                this.rankID = rankID;
            }
        }

        private struct check_cure_sick_item_tbl_elem
        {
            public Pml.Item.ItemData.PrmID itemParamID;
            public WazaSick sickID;

            public check_cure_sick_item_tbl_elem(Pml.Item.ItemData.PrmID itemParamID, WazaSick sickID)
            {
                this.itemParamID = itemParamID;
                this.sickID = sickID;
            }
        }

        private enum SeqSubProc_UI_SelectAction : int
        {
            SEQ_START_0 = 0,
            SEQ_DEMOCAPTURE_WAIT = 1,
            SEQ_START_1 = 2,
            SEQ_TRAINER_MESSAGE_SWITCH = 3,
            SEQ_TRAINER_MESSAGE_START = 4,
            SEQ_TRAINER_MESSAGE_WAIT = 5,
            SEQ_CAMERA_INIT = 6,
            SEQ_CAMERA_WAIT = 7,
            SEQ_SELACT_START = 8,
            SEQ_SELACT_WAIT = 9,
        }

        private enum SeqSubProc_REC_SelectAction : int
        {
            SEQ_FIRST = 0,
            SEQ_NONE = 1,
            SEQ_START_WAIT = 2,
            SEQ_CAMERA_RUNNING = 3,
            SEQ_END_WAIT = 4,
        }

        private enum Seqselact_Fight : int
        {
            SEQ_START = 0,
            SEQ_SELECT_WAZA_START = 1,
            SEQ_SELECT_WAZA_WAIT = 2,
            SEQ_SELECT_WAZA_END = 3,
            SEQ_CHECK_WAZA_TARGET = 4,
            SEQ_SELECT_TARGET_START = 5,
            SEQ_SELECT_TARGET_WAIT = 6,
            SEQ_WAIT_UNSEL_WAZA_MSG = 7,
            SEQ_WAIT_UNSEL_TARGET_MSG = 8,
            SEQ_DONE = 9,
        }

        private enum Seqselact_Item : int
        {
            SEQ_START = 0,
            SEQ_SELECT_START = 1,
            SEQ_SELECT_WAIT = 2,
            SEQ_FORCE_QUIT = 3,
            SEQ_CANT_USE_START = 4,
            SEQ_CANT_USE_WAIT = 5,
        }

        private enum Seqselact_Escape : int
        {
            SEQ_INIT = 0,
            SEQ_CANT_MSG_START = 1,
            SEQ_CANT_MSG_WAIT = 2,
            SEQ_CONFIRM_MSG_START = 3,
            SEQ_CONFIRM_MSG_WAIT = 4,
            SEQ_CONFIRM_YESNO = 5,
            SEQ_RETURN_ESCAPE = 6,
        }

        private enum SEQ_SubProc_AI_SelectAction : int
        {
            SEQ_INIT = 0,
            SEQ_POKE_START = 1,
            SEQ_AI_START = 2,
            SEQ_AI_WAIT = 3,
            SEQ_NEXT_POKE = 4,
            SEQ_SAFARI = 5,
            SEQ_END = 6,
        }

        private enum SeqselectPokemonUI_Core : int
        {
            SEQ_INIT = 0,
            SEQ_SELECT_ROOT = 1,
            SEQ_TIMELIMIT_OVER = 2,
            SEQ_SELECT_END = 3,
            SEQ_PROC_QUIT_ROOT = 4,
            SEQ_COMM_WAIT = 5,
            SEQ_PROC_QUIT_END = 6,
        }

        private enum SeqSubProc_UI_ConfirmIrekae : int
        {
            SEQ_INIT = 0,
            SEQ_START_CONFIRM = 1,
            SEQ_WAIT_CONFIRM = 2,
            SEQ_WAIT_POKESELECT = 3,
            SEQ_DONT_CHANGE = 4,
            SEQ_RETURN = 5,
        }

        private enum SeqSubProc_ExitCommTrainer : int
        {
            SEQ_START = 0,
            SEQ_SHOWDOWN_MESSAGE_START = 1,
            SEQ_SHOWDOWN_MESSAGE_WAIT_WIN = 2,
            SEQ_SHOWDOWN_MESSAGE_WAIT_LOSE = 3,
            SEQ_LOSE_BGM_FADEOUT_WAIT = 4,
        }

        private enum SeqSubProc_UI_ExitForNPC : int
        {
            SEQ_INIT = 0,
            SEQ_WIN_START = 1,
            SEQ_WIN_WAIT_TR1_IN = 2,
            SEQ_WIN_WAIT_TR1_MSG = 3,
            SEQ_WIN_WAIT_TR1_OUT = 4,
            SEQ_WIN_WAIT_TR2_IN = 5,
            SEQ_WIN_WAIT_TR2_MSG = 6,
            SEQ_WIN_GET_MONEY_MSG = 7,
            SEQ_WIN_GET_MONEY = 8,
            SEQ_WIN_BONUS_MONEY = 9,
            SEQ_LOSE_START = 10,
            SEQ_LOSE_WAIT_MSG1 = 11,
            SEQ_END = 12,
        }

        private enum SeqSubProc_ExitForSubwayTrainer : int
        {
            SEQ_START = 0,
            SEQ_INIT = 1,
            SEQ_WAIT_TRAINER_IN = 2,
            SEQ_WAIT_MSG = 3,
            SEQ_WAIT_TRAINER_OUT = 4,
            SEQ_WAIT_TRAINER2_IN = 5,
            SEQ_WAIT_MSG2 = 6,
        }

        private enum SeqSubProc_UI_FadeOut : int
        {
            SEQ_START = 0,
            SEQ_FADEOUT_START = 1,
            SEQ_FAIDEOUT_WAIT = 2,
            SEQ_END = 3,
        }

        private enum SeqSubProc_UI_RaidBossCapture_SelectBall : int
        {
            SEQ_START = 0,
            SEQ_SELECTBALL_START = 1,
            SEQ_SELECTBALL_WAIT = 2,
            SEQ_END = 3,
        }

        private enum SeqSubProc_UI_RaidBossCapture_Result : int
        {
            SEQ_START = 0,
            SEQ_BALLTHROW_START = 1,
            SEQ_BALLTHROW_WAIT = 2,
            SEQ_CAPTURED = 3,
            SEQ_ESCAPE = 4,
            SEQ_ESCAPE_ACT_START = 5,
            SEQ_ESCAPE_ACT_WAIT = 6,
            SEQ_JOKER_BALLTHROW_START = 7,
            SEQ_JOKER_BALLTHROW_WAIT = 8,
            SEQ_END = 9,
        }

        private enum SeqSubProc_UI_LoseRaid : int
        {
            SEQ_START = 0,
            SEQ_EFFECT_START = 1,
            SEQ_EFFECT_WAIT = 2,
            SEQ_END = 3,
        }

        private enum SeqscProc_ACT_MemberIn : int
        {
            SEQ_TRAINER_MSG_SWITCH = 0,
            SEQ_TRAINER_MSG_START = 1,
            SEQ_TRAINER_MSG_WAIT = 2,
            SEQ_MEMBERIN_MSG_START = 3,
            SEQ_MEMBERIN_MSG_WAIT = 4,
            SEQ_MEMBERIN_ACT = 5,
        }

        private struct getWeatherStartMessageTableElem
        {
            public BtlWeather weather;
            public int strID_others;
            public int strID_onBattleStart;

            public getWeatherStartMessageTableElem(BtlWeather weather, int strID_others, int strID_onBattleStart)
            {
                this.weather = weather;
                this.strID_others = strID_others;
                this.strID_onBattleStart = strID_onBattleStart;
            }
        }

        private enum SeqscProc_ACT_BallThrow : int
        {
            SEQ_START_BALL_THROW = 0,
            SEQ_WAIT_BALL_THROW = 1,
            SEQ_DONE = 2,
        }

        private enum SeqscProc_ACT_BallThrowForbidden : int
        {
            SEQ_START = 0,
            SEQ_BALLTHROW_START = 1,
            SEQ_BALLTHROW_WAIT = 2,
            SEQ_MSG_START = 3,
            SEQ_MSG_WAIT = 4,
            SEQ_END = 5,
        }

        private enum Seq_ACT_Safari : int
        {
            Start = 0,
            Throw0 = 1,
            Throw1 = 2,
            Throw2 = 3,
            Throw3 = 4,
            Yousumi0 = 5,
            Yousumi1 = 6,
            Yousumi2 = 7,
            End = 8,
        }
    }
}