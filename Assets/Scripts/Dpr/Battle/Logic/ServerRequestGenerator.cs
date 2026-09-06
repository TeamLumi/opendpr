namespace Dpr.Battle.Logic
{
    public sealed unsafe class ServerRequestGenerator
    {
        private ServerCommandGenerator m_pServerCmdGenerator;
        private ServerCommandQueue m_pServerCmdQueue;
        private PokeChangeRequest m_pPokeChangeRequest;
        private SendDataContainer m_pSendDataContainer;
        private rec.SendTool m_pRecTool;
        private SVCL_ACTION m_pClientInstructions;
        private BTL_RESULT_CONTEXT* m_battleResultContext;
        private TimeLimit m_pTimeLimit;
        private ServerSendData.CONFIRM_COUNTER_POKECHANGE* m_sendData_ConfirmCounterPokeChange;
        private ServerSendData.CLIENT_LIMIT_TIME* m_sendData_ClientLimitTime;
        private ServerSendData.RAIDBOSS_CAPTURE_RESULT* m_sendData_CoopCapResult;
        private ServerSendData.POKECHANGE_REQUEST* m_sendData_PokeChangeRequest;
        private bool m_isBattleInEventOccured;
        private bool m_isEscapeSucceeded;
        private InterruptCode m_interruptCode;

        // TODO
        public ServerRequestGenerator(in SetupParam setupParam) { }

        // TODO
        public InterruptCode GetInterruptCode() { return InterruptCode.NONE; }

        public bool IsEscapeSucceededOnChangeOrEscape() {
            return m_isEscapeSucceeded;
        }

        // TODO
        public void SetSendData_ConfirmCounterPokeChange(byte enemyPutPokeID) { }

        // TODO
        public void SetSendData_RaidBossCaptureResult(in ServerSendData.RAIDBOSS_CAPTURE_RESULT data) { }

        // TODO
        public void GenerateSendData(void** data, ref uint dataSize, ServerRequest serverReq, uint serialNo) { }

        // TODO
        private void calcSendData(void** data, out uint dataSize, ServerRequest serverReq)
        {
            dataSize = 0;
        }

        // TODO
        private void calcSendData_SELECT_COVER_POKE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_CONFIRM_COUNTER_POKECHANGE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SERVER_CMD_AFTER_COVER_POKE_SELECT(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SELECT_CHANGE_POKE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SERVER_CMD_FIRST_BATTLE_IN(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SERVER_CMD_AFTER_ACTION_SELECT(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SERVER_CMD_ESCAPE_BY_CHANGE_OR_ESCAPE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SERVER_CMD_AFTER_INTERRUPT_POKECHANGE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SERVER_CMD_POKECHANGE_AFTERFIRSTPOKEIN(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_RECORD_BATTLE_START_TIMING(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_RECORD_BATTLE_START_CHAPTER(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_RECORD_ACTION(void** data, ref uint dataSize, rec.Timing timingCode, bool fChapter) { }

        // TODO
        private void calcSendData_RECORD_TIMEUP_CHAPTER(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_EXIT_WILD_WIN(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_EXIT_WILD_LOSE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_EXIT_WILD_FORCE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_EXIT_CAPTURE(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_EXIT_COMM(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_EXIT_NPC(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_EXIT_BATTLE_SPOT_TRAINER(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_SYNC_CLIENT_LIMIT_TIME(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_RAID_CAPTURE_RESULT(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_RAID_SCMD_RESULT(void** data, ref uint dataSize) { }

        // TODO
        private void calcSendData_RAID_EXIT_LOSE(void** data, ref uint dataSize) { }

        public class SetupParam
        {
            public ServerCommandGenerator pServerCmdGenerator;
            public ServerCommandQueue pServerCmdQueue;
            public PokeChangeRequest pPokeChangeRequest;
            public SendDataContainer pSendDataContainer;
            public rec.SendTool pRecTool;
            public SVCL_ACTION pClientInstruction;
            public BTL_RESULT_CONTEXT* pBattleResultContext;
            public TimeLimit pTimeLimit;
        }
    }
}