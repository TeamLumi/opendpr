namespace Dpr.Battle.Logic
{
    public sealed class BattleEnv
    {
        internal POKECON m_pokecon;
        internal FieldStatus m_fieldStatus;
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
        internal BattleFlags m_flags;
        internal BattleCounter m_counter;
        internal EscapeInfo m_escapeInfo;
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

        public void Dispose()
        {
        	this.m_pokecon = null;
        	this.m_fieldStatus = null;
        	this.m_sideEffectManager = null;
        	this.m_posEffectManager = null;
        	this.m_eventFactorContainer = null;
        	this.m_posPoke = null;
        	this.m_deadRec = null;
        	this.m_wazaRec = null;
        	this.m_affCounter = null;
        	this.m_actionRecorder = null;
        	this.m_actionSerialNoManager = null;
        	this.m_timeLimit = null;
        	this.m_gRightsManager = null;
        	this.m_gGauge = null;
        	this.m_raidBattleStatus = null;
        	this.m_flags = null;
        	this.m_counter = null;
        	this.m_escapeInfo = null;
        	this.m_lastExecutedWaza = null;
        	this.m_tamaHiroiData = null;
        }

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

        public SideEffectManager GetSideEffectManager()
        {
        	return this.m_sideEffectManager;
        }

        // TODO
        public SideEffectStatus GetSideEffectStatus(BtlSide side, BtlSideEffect effect) { return null; }

        // TODO
        public PosEffectStatus GetPosEffectStatus(BtlPokePos pos, BtlPosEffect effect) { return null; }

        public EventFactorContainer GetEventFactorContainer()
        {
            return m_eventFactorContainer;
        }

        public PosPoke GetPosPoke()
        {
        	return this.m_posPoke;
        }

        public DeadRec GetDeadRec()
        {
        	return this.m_deadRec;
        }

        public WazaRec GetWazaRec()
        {
        	return this.m_wazaRec;
        }

        public AffCounter GetAffinityCounter()
        {
        	return this.m_affCounter;
        }

        public ActionRecorder GetActionRecorder()
        {
        	return this.m_actionRecorder;
        }

        public ActionSerialNoManager GetActionSerialNoManager()
        {
        	return this.m_actionSerialNoManager;
        }

        public TimeLimit GetTimeLimit()
        {
        	return this.m_timeLimit;
        }

        public GRightsManager GetGRightsManager()
        {
        	return this.m_gRightsManager;
        }

        // TODO
        public GGauge GetGGauge(BTL_CLIENT_ID clientID) { return null; }

        public RaidBattleStatus GetRaidBattleStatus()
        {
        	return this.m_raidBattleStatus;
        }

        public BattleFlags GetBattleFlags()
        {
        	return this.m_flags;
        }

        public BattleCounter GetBattleCounter()
        {
        	return this.m_counter;
        }

        public EscapeInfo GetEscapeInfo()
        {
        	return this.m_escapeInfo;
        }

        public WazaParam GetLastExecutedWaza()
        {
            return m_lastExecutedWaza;
        }

        public void SetLastExecutedWaza(in WazaParam wazaParam)
        {
            m_lastExecutedWaza.CopyFrom(wazaParam);
        }

        public void SetTamaHiroiData(ushort itemNo)
        {
        	if (this.m_tamaHiroiData.ballItem != 0) {
        	}
        	this.m_tamaHiroiData.ballItem = itemNo;
        	this.m_tamaHiroiData.ballValid = 1;
        }

        public ushort GetTamaHiroiData()
        {
        	if (this.m_tamaHiroiData.ballValid != 0) {
        	  this.m_tamaHiroiData.ballValid = 0;
        	  return (ushort)(this.m_tamaHiroiData.ballItem);
        	}
        	return 0;
        }

        public class SetupParam
        {
            public MainModule pMainModule;
        }
    }
}