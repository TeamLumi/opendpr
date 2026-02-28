namespace Dpr.Battle.Logic
{
    public sealed class ServerCommandGenerator
    {
        private MainModule m_pMainModule;
        private BattleEnv m_pBattleEnv;
        private ServerCommandQueue m_pQueue;
        private SectionContainer m_pSectionContainer;

        public ServerCommandGenerator(in SetupParam setupParam)
        {
            m_pMainModule = setupParam.pMainModule;
            m_pBattleEnv = setupParam.pBattleEnv;
            m_pQueue = setupParam.pServerCmdQueue;
            m_pSectionContainer = setupParam.pSectionContainer;
        }

        // TODO
        public void GenerateOperations_FirstPokeIn(Result pResult) { }

        // TODO
        private InterruptCode firstPokeIn() { return InterruptCode.NONE; }

        // TODO
        public void GenerateOperations_PokeChange_AfterFirstPokeIn(Result pResult, SVCL_ACTION pClientInstructions) { }

        // TODO
        private InterruptCode pokeChangeAfterFirstPokeIn(SVCL_ACTION clientInstructions) { return InterruptCode.NONE; }

        // TODO
        public void GenerateOperations(Result pResult, SVCL_ACTION pClientInstructions) { }

        // TODO
        private InterruptCode processActions(SVCL_ACTION clientInstructions) { return InterruptCode.NONE; }

        // TODO
        public void GenerateOperations_ForInterruptPokeChange(Result pResult, SVCL_ACTION pClientInstructions) { }

        // TODO
        private InterruptCode interruptPokeChange(SVCL_ACTION clientInstructions) { return InterruptCode.NONE; }

        // TODO
        public void GenerateOperations_ForCover(Result pResult, SVCL_ACTION pClientInstructions) { }

        // TODO
        private InterruptCode putCover(SVCL_ACTION clientInstructions) { return InterruptCode.NONE; }

        public bool GenerateOperations_ForEscape()
        {
        	this.m_pQueue.Initialize();
        	escape(this);
        	return false;
        }

        // TODO
        private bool escape() { return false; }

        // TODO
        public void GenerateOperations_RaidResult() { }

        // TODO
        private void raidResult() { }

        public class SetupParam
        {
            public MainModule pMainModule;
            public BattleEnv pBattleEnv;
            public ServerCommandQueue pServerCmdQueue;
            public SectionContainer pSectionContainer;
        }

        public class Result
        {
            public InterruptCode interruptCode;
        }
    }
}