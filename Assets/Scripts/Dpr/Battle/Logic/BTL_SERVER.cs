namespace Dpr.Battle.Logic
{
    public sealed class BTL_SERVER
    {
        private ServerSequence m_currentSeq;
        private int m_seqStep;
        private MainModule m_pMainModule;
        private BattleEnv m_pBattleEnv;
        private SendDataContainer m_pSendDataContainer;
        private ushort m_sendDataSerialNo;
        private ClientData[] m_clientData = Arrays.InitializeWithDefaultInstances<ClientData>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        private rec.SendTool m_recTool = new rec.SendTool();
        private unsafe BTL_RESULT_CONTEXT* m_btlResultContext;
        private SVCL_ACTION m_clientInstruction = new SVCL_ACTION();
        private ServerRequestGenerator m_serverRequestGenerator;
        private BattleDriver m_battleDriver;

        public BTL_SERVER(MainModule pMainModule, ulong randSeed, BattleEnv pBattleEnv, SendDataContainer pSendDataContainer)
        {
            unsafe
            {
                m_btlResultContext = (BTL_RESULT_CONTEXT*)BattleUnmanagedMem.Malloc(sizeof(BTL_RESULT_CONTEXT)); // This should be 8 bytes
            }

            m_currentSeq = ServerSequence.END;
            m_seqStep = 0;

            m_pMainModule = pMainModule;
            m_pBattleEnv = pBattleEnv;
            m_pSendDataContainer = pSendDataContainer;
            m_serverRequestGenerator = null;

            m_sendDataSerialNo = 1;

            calc.ResetSys(randSeed);
            clearClientData();
            createBattleDriver();
            createServerRequestGenerator();

            m_currentSeq = ServerSequence.BATTLE_START_SETUP;
            m_seqStep = 0;
        }

        // TODO
        public void createBattleDriver() { }

        // TODO
        public void createServerRequestGenerator() { }

        // TODO
        public void AttachAdapter(BTL_CLIENT_ID clientID, Adapter adapter) { }

        public void Startup()
        {
        	this.m_currentSeq = (ServerSequence)0;
        	this.m_seqStep = 0;
        	initAllAdapter();
        	this.m_battleDriver.Initialize();
        }

        public void StartupAsNewServer()
        {
        	this.m_currentSeq = (ServerSequence)0x2f;
        	this.m_seqStep = 0;
        	resetAdapterCmd();
        }

        // TODO
        public bool IsWaitingClientReply() { return false; }

        // TODO
        public unsafe void CMDCHECK_RestoreActionData(void* recData, uint recDataSize) { }

        // TODO
        public void CMDCHECK_RestoreClientLimitTime(in ServerSendData.CLIENT_LIMIT_TIME syncData) { }

        // TODO
        public unsafe bool CMDCHECK_Make(rec.Timing timingCode, void* recvedCmd, uint recvedCmdSize) { return false; }

        // TODO
        public bool MainLoop() { return false; }

        // TODO
        private bool updateSeq() { return false; }

        private void changeSequence(ServerSequence nextSeq)
        {
        	this.m_currentSeq = (ServerSequence)(nextSeq);
        	this.m_seqStep = 0;
        }

        // TODO
        private void seq_BATTLE_START_SETUP(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        private void seq_BATTLE_START_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq)
        {
        	this.m_pMainModule.GetCompetitor(0);
        	pNextSeq = (ServerSequence)2;
        }

        // TODO
        private void seq_BATTLE_START_TIMING(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_BATTLE_START_COMMAND(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_BATTLE_START_RECORD(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        private void seq_BATTLE_START_SWITCH_AFTER_FIRST_POKEIN(ref int pSeqStep, ref ServerSequence pNextSeq)
        {
        	var uVar1 = 6;
        	if (this.m_serverRequestGenerator.m_interruptCode != '\x01') {
        	  uVar1 = 10;
        	}
        	var uVar2 = 10;
        	if (this.m_serverRequestGenerator.m_interruptCode != 0) {
        	  uVar2 = uVar1;
        	}
        	pNextSeq = (ServerSequence)(uVar2);
        }

        // TODO
        private void seq_POKECHANGE_AFTERFIRSTPOKEIN_POKESELECT(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_POKECHANGE_AFTERFIRSTPOKEIN_RECORD(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_POKECHANGE_AFTERFIRSTPOKEIN_COMMAND(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        private void seq_POKECHANGE_AFTERFIRSTPOKEIN_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq)
        {
        	var uVar1 = 6;
        	if (this.m_serverRequestGenerator.m_interruptCode != '\x01') {
        	  uVar1 = 10;
        	}
        	var uVar2 = 10;
        	if (this.m_serverRequestGenerator.m_interruptCode != 0) {
        	  uVar2 = uVar1;
        	}
        	pNextSeq = (ServerSequence)(uVar2);
        }

        // TODO
        private void seq_ACTION_SELECT_START(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        private void seq_ACTION_SELECT_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq)
        {
        	if ((this.m_pMainModule.CheckGameLimitTimeOver() & 1) != 0) {
        	  pNextSeq = (ServerSequence)0x1d;
        	}
        	var uVar2 = 0x24;
        	if ((this.m_pMainModule.CheckRecPlayError() & 1) == 0) {
        	  uVar2 = 0xc;
        	}
        	pNextSeq = (ServerSequence)(uVar2);
        }

        // TODO
        private void seq_ACTION_SELECT_RECORD(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_ACTION_SELECT_COMMAND(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_ACTION_SELECT_COMMAND_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private bool isPokeCoverEscapeMode() { return false; }

        // TODO
        private void seq_CHANGE_OR_ESCAPE_START(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_CHANGE_OR_ESCAPE_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_CHANGE_OR_ESCAPE_ESCAPE_SELECTED(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_COVER_SELECT_START(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_COVER_COMFIRM_PLAYER_POKECHANGE(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        private void seq_COVER_SELECT_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq)
        {
        	if ((this.m_pMainModule.CheckRecPlayError() & 1) != 0) {
        	  pNextSeq = (ServerSequence)0x24;
        	}
        	pNextSeq = (ServerSequence)0x15;
        }

        // TODO
        private void seq_COVER_SELECT_RECORD(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_COVER_COMMAND(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_COVER_COMMAND_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private bool irekae_IsNeedConfirm() { return false; }

        // TODO
        private byte irekae_GetEnemyPutPokeID() { return 0; }

        // TODO
        private void seq_INTERRUPT_POKECHANGE_POKESELECT(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        private void seq_INTERRUPT_POKECHANGE_POKESELECT_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq)
        {
        	if ((this.m_pMainModule.CheckRecPlayError() & 1) != 0) {
        	  pNextSeq = (ServerSequence)0x24;
        	}
        	pNextSeq = (ServerSequence)0x1a;
        }

        // TODO
        private void seq_INTERRUPT_POKECHANGE_RECORD(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_INTERRUPT_POKECHANGE_COMMAND(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_INTERRUPT_POKECHANGE_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_TIMEUP_RECORD(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_TIMEUP_COMMAND(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_RAID_CAPTURE_START(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_RAID_CAPTURE_SELECT_BALL(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void storeClientSendData_RaidBallSelect() { }

        // TODO
        private void seq_RAID_CAPTURE_RESULT(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void checkRaidBossCaptureResult() { }

        // TODO
        private void checkRaidBossCaptureResult(ref ServerSendData.RAIDBOSS_CAPTURE_RESULT pResult) { }

        // TODO
        private void checkRaidBossCaptureResult(ref ServerSendData.RAIDBOSS_CAPTURE_RESULT pResult, BTL_CLIENT_ID clientID) { }

        // TODO
        private void seq_RAID_EXIT_WIN(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_RAID_EXIT_LOSE(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_COMMON(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_WILD_WIN(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_WILD_LOSE(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_WILD_FORCE(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_WILD_CAPTURE(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_COMM(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_NPC(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_BATTLE_SPOT_TRAINER(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_FADEOUT(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_EXIT_QUIT(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_NEW_STARTUP_SEND_LATEST_REPLY(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void seq_NEW_STARTUP_SWITCH(ref int pSeqStep, ref ServerSequence pNextSeq) { }

        // TODO
        private void notifyBattleResult() { }

        // TODO
        private void checkBattleResult(out BtlResult pResult, out ResultCause pJudgeCause)
        {
            pResult = BtlResult.BTL_RESULT_LOSE;
            pJudgeCause = ResultCause.RESULT_CAUSE_OTHER;
        }

        // TODO
        private bool checkRaidBattleWin() { return false; }

        private BtlRule getRule()
        {
        	return this.m_pMainModule.m_rule;
        }

        // TODO
        private void storeClientInstruction() { }

        // TODO
        private void clearClientInstruction() { }

        // TODO
        private void storeClientLimitTime() { }

        // TODO
        private bool isClientLimitTimeOver() { return false; }

        // TODO
        private void sendClientLimitTimeToLiveCupWatchMember() { }

        // TODO
        private void sendRequest(ServerRequest request) { }

        // TODO
        private void sendRequestAlone(ServerRequest request, byte clientID) { }

        // TODO
        private void sendRequestCore(ServerRequest request, byte clientID) { }

        // TODO
        public unsafe void setSendDataInAllAdapter(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* sendData, uint dataSize) { }

        // TODO
        public unsafe void setSendDataInSingleAdapter(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* sendData, uint dataSize, byte clientID) { }

        // TODO
        public unsafe void registerSendData(ushort serialNumber, ServerSequence serverSeq, ServerRequest serverReq, void* data, uint dataSize) { }

        // TODO
        private bool waitAllAdapterReply() { return false; }

        // TODO
        private void resetAdapterCmd() { }

        // TODO
        private void initAllAdapter() { }

        // TODO
        private void clearClientData() { }

        // TODO
        private void setupClientData(BTL_CLIENT_ID clientID, Adapter adapter, BTL_PARTY party) { }

        // TODO
        private Adapter getClientAdapter(BTL_CLIENT_ID clientID) { return null; }

        // TODO
        private bool isClientExist(BTL_CLIENT_ID clientID) { return false; }

        private delegate void SequenceFunc(ref int seqStep, ref ServerSequence pNextSeq);

        private class ClientData
        {
            public Adapter adapter;
            public BTL_PARTY party;
            public ClientSendData.RAID_BALL_SELECT sendData_RaidBallSelect;
        }

        private enum seq_POKECHANGE_AFTERFIRSTPOKEIN_RECORDSeq : int
        {
            SEQ_Record = 0,
            SEQ_Record_Wait = 1,
            SEQ_ClientLimitTimeReq = 2,
            SEQ_ClientLimitTimeReq_Wait = 3,
            SEQ_ClientLimitTimeSync = 4,
            SEQ_ClientLimitTimeSync_Wait = 5,
            SEQ_End = 6,
        }

        private enum seq_ACTION_SELECT_RECORDSeq : int
        {
            SEQ_Record = 0,
            SEQ_Record_Wait = 1,
            SEQ_ClientLimitTimeReq = 2,
            SEQ_ClientLimitTimeReq_Wait = 3,
            SEQ_ClientLimitTimeSync = 4,
            SEQ_ClientLimitTimeSync_Wait = 5,
            SEQ_End = 6,
        }

        private enum seq_COVER_SELECT_RECORDSeq : int
        {
            SEQ_Record = 0,
            SEQ_Record_Wait = 1,
            SEQ_ClientLimitTimeReq = 2,
            SEQ_ClientLimitTimeReq_Wait = 3,
            SEQ_ClientLimitTimeSync = 4,
            SEQ_ClientLimitTimeSync_Wait = 5,
            SEQ_End = 6,
        }

        private enum seq_INTERRUPT_POKECHANGE_RECORDSeq : int
        {
            SEQ_Record = 0,
            SEQ_Record_Wait = 1,
            SEQ_ClientLimitTimeReq = 2,
            SEQ_ClientLimitTimeReq_Wait = 3,
            SEQ_ClientLimitTimeSync = 4,
            SEQ_ClientLimitTimeSync_Wait = 5,
            SEQ_End = 6,
        }
    }
}