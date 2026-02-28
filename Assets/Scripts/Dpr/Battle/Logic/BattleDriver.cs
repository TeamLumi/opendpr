namespace Dpr.Battle.Logic
{
    public sealed class BattleDriver
    {
        private MainModule m_pMainModule;
        private BattleEnv m_pBattleEnv;
        private ServerCommandQueue m_serverCmdQueue;
        private ServerCommandGenerator m_serverCmdGenerator;
        private ServerCommandPutter m_serverCmdPutter;
        private WazaCommandPutter m_wazaCmdPutter;
        internal ServerCommandExecutor m_serverCmdExecutor;
        private EventSystem m_eventSystem;
        private EventLauncher m_eventLauncher;
        private PokeActionContainer m_pokeActionContainer;
        private SectionSharedData m_sectionSharedData;
        private SectionContainer m_sectionContainer;
        private PokeChangeRequest m_pokeChangeRequest;
        private CaptureInfo m_captureInfo;

        public BattleDriver(in SetupParam setupParam)
        {
            m_pMainModule = setupParam.pMainModule;
            m_pBattleEnv = setupParam.pBattleEnv;

            m_serverCmdQueue = null;
            m_serverCmdGenerator = null;
            m_serverCmdPutter = null;
            m_wazaCmdPutter = null;
            m_serverCmdExecutor = null;
            m_eventSystem = null;
            m_eventLauncher = null;
            m_pokeActionContainer = null;
            m_sectionSharedData = null;
            m_sectionContainer = null;
            m_pokeChangeRequest = null;
            m_captureInfo = null;

            m_captureInfo = new CaptureInfo();
            m_pokeChangeRequest = new PokeChangeRequest(setupParam.pMainModule);
            m_serverCmdQueue = new ServerCommandQueue();
            m_pokeActionContainer = new PokeActionContainer();
            m_sectionContainer = new SectionContainer();
            m_sectionSharedData = new SectionSharedData(new SectionSharedData.SetupParam());

            createEventSystem();
            createEventLauncher();
            createServerCommandExecutor();
            createServerCommandPutter();
            createWazaMessagePutter();
            createSections();
            createServerCommandGenerator();
        }

        public void Dispose()
        {
            m_pMainModule = null;
            m_pBattleEnv = null;
            m_serverCmdQueue = null;
            m_serverCmdGenerator = null;
            m_serverCmdPutter = null;
            m_wazaCmdPutter = null;
            m_serverCmdExecutor = null;
            m_eventSystem = null;
            m_eventLauncher = null;
            m_pokeActionContainer = null;
            m_sectionSharedData = null;
            m_sectionContainer = null;
            m_pokeChangeRequest = null;
            m_captureInfo = null;
        }

        // TODO
        private void createSectionSharedData() { }

        // TODO
        private void createEventSystem() { }

        // TODO
        private void createEventLauncher() { }

        // TODO
        private void createServerCommandExecutor() { }

        // TODO
        private void createServerCommandPutter() { }

        // TODO
        private void createWazaMessagePutter() { }

        // TODO
        private void createSections() { }

        // TODO
        private void createServerCommandGenerator() { }

        public void Initialize()
        {
        	this.m_serverCmdQueue.Initialize();
        	this.m_eventSystem.Initialize();
        	this.m_sectionSharedData.Initialize();
        	this.m_pokeActionContainer.Clear();
        	this.m_pokeChangeRequest.Clear();
        	this.m_captureInfo.Clear();
        }

        public ServerCommandQueue GetServerCommandQueue()
        {
            return m_serverCmdQueue;
        }

        public ServerCommandGenerator GetServerCommandGenerator()
        {
            return m_serverCmdGenerator;
        }

        public ServerCommandPutter GetServerCommandPutter()
        {
            return m_serverCmdPutter;
        }

        public WazaCommandPutter GetWazaCommandPutter()
        {
            return m_wazaCmdPutter;
        }

        public ServerCommandExecutor GetServerCommandExecutor()
        {
            return m_serverCmdExecutor;
        }

        public EventSystem GetEventSystem()
        {
            return m_eventSystem;
        }

        public EventLauncher GetEventLauncher()
        {
            return m_eventLauncher;
        }

        public PokeActionContainer GetPokeActionContainer()
        {
            return m_pokeActionContainer;
        }

        public SectionSharedData GetSectionSharedData()
        {
            return m_sectionSharedData;
        }

        public SectionContainer GetSectionContainer()
        {
            return m_sectionContainer;
        }

        public PokeChangeRequest GetPokeChangeRequest()
        {
            return m_pokeChangeRequest;
        }

        public CaptureInfo GetCaptureInfo()
        {
            return m_captureInfo;
        }

        public class SetupParam
        {
            public MainModule pMainModule;
            public BattleEnv pBattleEnv;
        }
    }
}