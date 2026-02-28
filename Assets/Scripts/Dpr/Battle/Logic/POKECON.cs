using Pml;
using Pml.PokePara;

namespace Dpr.Battle.Logic
{
    public sealed class POKECON
    {
        private readonly MainModule m_mainModule;
        private BTL_PARTY[] m_party = Arrays.InitializeWithDefaultInstances<BTL_PARTY>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        private BTL_POKEPARAM[] m_activePokeParam = new BTL_POKEPARAM[PokeID.NUM];
        private BTL_POKEPARAM[] m_storedPokeParam = new BTL_POKEPARAM[PokeID.NUM];
        private static PokeParty s_tmpPokeParty;

        // TODO
        public static void InitSystem() { }

        // TODO
        public static void QuitSystem() { }

        public POKECON(MainModule mainModule, FieldStatus fieldStatus)
        {
            m_mainModule = mainModule;
            
            for (int i=0; i<m_storedPokeParam.Length; i++)
                m_storedPokeParam[i] = new BTL_POKEPARAM(fieldStatus);
        }

        // TODO
        public void Dispose() { }

        // TODO
        public void Clear() { }

        private void storeAllPokeParam()
        {
        	if (0 < this.m_activePokeParam.Length) {
        	  var uVar1 = 0;
        	  do {
        	    storePokeParam(uVar1);
        	    uVar1 = (ulong)((int)uVar1 + 1);
        	  } while ((long)uVar1 < (long)this.m_activePokeParam.Length);
        	}
        }

        // TODO
        private void storePokeParam(byte pokeID) { }

        // TODO
        private void activatePokeParam(byte pokeID) { }

        // TODO
        public void CopyFrom(in POKECON src) { }

        // TODO
        public void SetParty(byte clientID, PokeParty srcParty, in PartyDesc partyDesc, MyStatus playerData) { }

        // TODO
        private void addPokeParam(byte clientID, byte pokeID, PokemonParam srcParam, in DefaultPowerUpDesc defaultPowerUpDesc, MyStatus playerData) { }

        // TODO
        private void setupPokeParam(BTL_POKEPARAM pokeParam, byte pokeID, PokemonParam srcParam, in DefaultPowerUpDesc defaultPowerUpDesc, MyStatus playerData) { }

        private bool checkForceGEnable(PokemonParam pPoke)
        {
        	return false;
        }

        // TODO
        private void updateIllusionTarget(byte clientID) { }

        // TODO
        public BTL_PARTY GetPartyData(uint clientID) { return null; }

        // TODO
        public BTL_PARTY GetPartyDataConst(uint clientID) { return null; }

        // TODO
        public BTL_POKEPARAM GetClientPokeDataConst(byte clientID, byte memberIdx) { return null; }

        // TODO
        public BTL_POKEPARAM GetPokeParam(byte pokeID) { return null; }

        // TODO
        public BTL_POKEPARAM GetPokeParamConst(byte pokeID) { return null; }

        // TODO
        public bool IsExistPokemon(byte pokeID) { return false; }

        // TODO
        public BTL_POKEPARAM GetViewSrcPokeParam(byte pokeID) { return null; }

        // TODO
        public void ConvertToPokeParty(PokeParty pDstParty, byte clientID, bool fDefaultForm) { }

        // TODO
        public void ConvertToPokePartyByStartingOrder(PokeParty pDstParty, byte clientID, bool[] fightPokeIdx) { }

        // TODO
        private void convertToPokeParamAndAddPokeParty(PokeParty pDstParty, BTL_PARTY pBtlParty, byte memberIdx) { }

        // TODO
        public int FindPokemon(byte clientID, byte pokeID) { return 0; }

        // TODO
        public BTL_POKEPARAM GetFrontPokeData(BtlPokePos pos) { return null; }

        // TODO
        public BTL_POKEPARAM GetFrontPokeDataConst(BtlPokePos pos) { return null; }

        // TODO
        public byte GetFrontPokeID(BtlPokePos pos) { return 0; }

        // TODO
        public BTL_POKEPARAM GetClientPokeData(byte clientID, byte posIdx) { return null; }
    }
}
