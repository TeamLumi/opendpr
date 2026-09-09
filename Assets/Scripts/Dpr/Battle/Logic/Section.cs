using Pml;

namespace Dpr.Battle.Logic
{
	public class Section
	{
		private MainModule m_pMainModule;
		private BattleEnv m_pBattleEnv;
		private ServerCommandQueue m_pServerCmdQueue;
		private ServerCommandPutter m_pServerCmdPutter;
		private WazaCommandPutter m_pWazaCmdPutter;
		private EventSystem m_pEventSystem;
		private EventLauncher m_pEventLauncher;
		private SectionSharedData m_pSharedData;
		private PokeActionContainer m_pPokemonActionContainer;
		private PokeChangeRequest m_pPokeChangeRequest;
		private CaptureInfo m_pCaptureInfo;
		private SectionContainer m_pSectionContainer;
		
		public Section(in CommonParam param)
		{
			m_pMainModule = param.pMainModule;
			m_pBattleEnv = param.pBattleEnv;
			m_pServerCmdQueue = param.pServerCmdQueue;
			m_pServerCmdPutter = param.pServerCmdPutter;
			m_pWazaCmdPutter = param.pWazaCmdPutter;
			m_pEventSystem = param.pEventSystem;
			m_pEventLauncher = param.pEventLauncher;
			m_pSharedData = param.pSharedData;
			m_pPokemonActionContainer = param.pPokemonActionContainer;
			m_pPokeChangeRequest = param.pPokeChangeRequest;
			m_pCaptureInfo = param.pCaptureInfo;
			m_pSectionContainer = param.pSectionContainer;
		}
		
		protected MainModule GetMainModule() {
		    return m_pMainModule;
		}
		
		protected BattleEnv GetBattleEnv() {
		    return m_pBattleEnv;
		}
		
		protected ServerCommandQueue GetServerCommandQueue() {
		    return m_pServerCmdQueue;
		}
		
		protected ServerCommandPutter GetServerCommandPutter() {
		    return m_pServerCmdPutter;
		}
		
		protected WazaCommandPutter GetWazaCommandPutter() {
		    return m_pWazaCmdPutter;
		}
		
		protected EventSystem GetEventSystem() {
		    return m_pEventSystem;
		}
		
		protected EventLauncher GetEventLauncher() {
		    return m_pEventLauncher;
		}
		
		protected SectionSharedData GetSharedData() {
		    return m_pSharedData;
		}
		
		// TODO
		protected ActionSharedData GetActionSharedData() { return default; }
		
		protected PokeActionContainer GetPokemonActionContainer() {
		    return m_pPokemonActionContainer;
		}
		
		protected PokeChangeRequest GetPokeChangeRequest() {
		    return m_pPokeChangeRequest;
		}
		
		protected CaptureInfo GetCaptureInfo() {
		    return m_pCaptureInfo;
		}
		
		protected SectionContainer GetSectionContainer() {
		    return m_pSectionContainer;
		}
		
		// TODO
		protected byte GetPokeID(BtlPokePos pos) { return default; }
		
		// TODO
		protected BTL_POKEPARAM GetPokeParam(byte pokeID) { return default; }
		
		// TODO
		protected BTL_POKEPARAM GetPokeParam(BtlPokePos pos) { return default; }
		
		// TODO
		protected BTL_POKEPARAM GetPokeParam(byte clientID, byte posIdx) { return default; }
		
		// TODO
		protected BtlPokePos GetPokePos(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		protected BtlPokePos GetPokePos(byte pokeID) { return default; }
		
		// TODO
		protected BtlSide GetPokeSide(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		protected BtlSide GetPokeSide(byte pokeID) { return default; }
		
		// TODO
		protected BTL_PARTY GetPokeParty(byte clientID) { return default; }
		
		// TODO
		protected BtlRule GetRule() { return default; }
		
		// TODO
		protected BtlMultiMode GetMultiMode() { return default; }
		
		// TODO
		protected BtlCompetitor GetCompetitor() { return default; }
		
		// TODO
		protected bool CheckCommMode() { return default; }
		
		// TODO
		protected bool CheckStatusFlag(BTL_STATUS_FLAG flag) { return default; }
		
		// TODO
		protected bool CheckFriendPoke(BTL_POKEPARAM poke1, BTL_POKEPARAM poke2) { return default; }
		
		// TODO
		protected bool CheckFriendPoke(byte pokeID1, byte pokeID2) { return default; }
		
		// TODO
		protected bool CheckShowdown() { return default; }
		
		// TODO
		protected bool CheckAllDeadSide(BtlSide checkSide) { return default; }
		
		// TODO
		protected bool CheckSkipBattleAfterShowdown() { return default; }
		
		// TODO
		protected bool CheckTurnEnd(InterruptCode interruptCode) { return default; }
		
		// TODO
		protected bool CheckPlayersClient(BTL_CLIENT_ID clientID) { return default; }
		
		// TODO
		protected byte GetFriendship(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		protected bool CheckPlayersPoke(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		protected bool CheckPlayersPoke(byte pokeID) { return default; }
		
		// TODO
		protected bool CheckPlayersFriendPoke(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		protected bool CheckPlayersFriendPoke(byte pokeID) { return default; }
		
		// TODO
		protected bool CheckMustHit(BTL_POKEPARAM attacker, BTL_POKEPARAM target) { return default; }
		
		// TODO
		protected bool CheckInvalidWaza(WazaNo waza) { return default; }
		
		// TODO
		protected bool CheckWazaEffectEnable() { return default; }
		
		// TODO
		protected bool CheckSkyBattleFailWaza(WazaNo waza) { return default; }
		
		// TODO
		protected WazaNo CheckEncoreWazaChange(PokeAction action) { return default; }
		
		// TODO
		protected ulong GetCounter(BattleCounter.UniqueCounter counterID) { return default; }
		
		// TODO
		protected ulong GetCounter(BattleCounter.ClientCounter counterID, BTL_CLIENT_ID clientID) { return default; }

		public class CommonParam
		{
			public MainModule pMainModule;
			public BattleEnv pBattleEnv;
			public ServerCommandQueue pServerCmdQueue;
			public ServerCommandPutter pServerCmdPutter;
			public WazaCommandPutter pWazaCmdPutter;
			public EventSystem pEventSystem;
			public EventLauncher pEventLauncher;
			public SectionSharedData pSharedData;
			public PokeActionContainer pPokemonActionContainer;
			public PokeChangeRequest pPokeChangeRequest;
			public CaptureInfo pCaptureInfo;
			public SectionContainer pSectionContainer;
		}
	}
}