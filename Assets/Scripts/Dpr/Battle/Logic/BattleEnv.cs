namespace Dpr.Battle.Logic
{
    public sealed class BattleEnv
    {
        private POKECON m_pokecon;
        private FieldStatus m_fieldStatus;
        private SideEffectManager m_sideEffectManager;
        private PosEffectManager m_posEffectManager;
        private EventFactorContainer m_eventFactorContainer;
        private PosPoke m_posPoke;
        private DeadRec m_deadRec;
        private WazaRec m_wazaRec;
        private AffCounter m_affCounter;
        private ActionRecorder m_actionRecorder;
        private ActionSerialNoManager m_actionSerialNoManager;
        private TimeLimit m_timeLimit;
        private GRightsManager m_gRightsManager;
        private GGauge[] m_gGauge = new GGauge[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        private RaidBattleStatus m_raidBattleStatus;
        private BattleFlags m_flags;
        private BattleCounter m_counter;
        private EscapeInfo m_escapeInfo;
        private WazaParam m_lastExecutedWaza = new WazaParam();
        private TamaHiroiData m_tamaHiroiData = new TamaHiroiData();

        public BattleEnv(in SetupParam param)
        {
            m_pokecon = null;
            m_fieldStatus = null;
            m_sideEffectManager = null;
            m_posEffectManager = null;
            m_eventFactorContainer = null;
            m_posPoke = null;
            m_deadRec = null;
            m_wazaRec = null;
            m_affCounter = null;
            m_actionRecorder = null;
            m_actionSerialNoManager = null;
            m_timeLimit = null;
            m_gRightsManager = null;
            m_raidBattleStatus = null;
            m_flags = null;
            m_counter = null;
            m_escapeInfo = null;

            m_fieldStatus = new FieldStatus();
            m_pokecon = new POKECON(param.pMainModule, m_fieldStatus);
            m_sideEffectManager = new SideEffectManager();
            m_posEffectManager = new PosEffectManager();
            m_eventFactorContainer = new EventFactorContainer();
            m_posPoke = new PosPoke();
            m_deadRec = new DeadRec();
            m_wazaRec = new WazaRec();
            m_affCounter = new AffCounter();
            m_actionRecorder = new ActionRecorder();
            m_actionSerialNoManager = new ActionSerialNoManager();
            m_timeLimit = new TimeLimit();
            m_gRightsManager = new GRightsManager(param.pMainModule, this);
            m_raidBattleStatus = new RaidBattleStatus();

            for (int i=0; i<m_gGauge.Length; i++)
                m_gGauge[i] = new GGauge();

            m_flags = new BattleFlags();
            m_counter = new BattleCounter();
            m_escapeInfo = new EscapeInfo();

            Initialize(param.pMainModule);
        }

        // TODO
        public void Dispose() { }

        // TODO
        public void Initialize(MainModule mainModule) { }

        // TODO
        public void CopyFrom(in BattleEnv src) { }

        public POKECON GetPokeCon()
        {
            return m_pokecon;
        }

        public FieldStatus GetFieldStatus()
        {
            return m_fieldStatus;
        }

        public SideEffectManager GetSideEffectManager() {
            return m_sideEffectManager;
        }

        // TODO
        public SideEffectStatus GetSideEffectStatus(BtlSide side, BtlSideEffect effect) { return null; }

        // TODO
        public PosEffectStatus GetPosEffectStatus(BtlPokePos pos, BtlPosEffect effect) { return null; }

        public EventFactorContainer GetEventFactorContainer()
        {
            return m_eventFactorContainer;
        }

        public PosPoke GetPosPoke() {
            return m_posPoke;
        }

        public DeadRec GetDeadRec() {
            return m_deadRec;
        }

        public WazaRec GetWazaRec() {
            return m_wazaRec;
        }

        public AffCounter GetAffinityCounter() {
            return m_affCounter;
        }

        public ActionRecorder GetActionRecorder() {
            return m_actionRecorder;
        }

        public ActionSerialNoManager GetActionSerialNoManager() {
            return m_actionSerialNoManager;
        }

        public TimeLimit GetTimeLimit() {
            return m_timeLimit;
        }

        public GRightsManager GetGRightsManager() {
            return m_gRightsManager;
        }

        // TODO
        public GGauge GetGGauge(BTL_CLIENT_ID clientID) { return null; }

        public RaidBattleStatus GetRaidBattleStatus() {
            return m_raidBattleStatus;
        }

        public BattleFlags GetBattleFlags() {
            return m_flags;
        }

        public BattleCounter GetBattleCounter() {
            return m_counter;
        }

        public EscapeInfo GetEscapeInfo() {
            return m_escapeInfo;
        }

        public WazaParam GetLastExecutedWaza()
        {
            return m_lastExecutedWaza;
        }

        public void SetLastExecutedWaza(in WazaParam wazaParam)
        {
            m_lastExecutedWaza.CopyFrom(wazaParam);
        }

        // TODO
        public void SetTamaHiroiData(ushort itemNo) { }

        // TODO
        public ushort GetTamaHiroiData() { return 0; }

        public class SetupParam
        {
            public MainModule pMainModule;
        }
    }
}