using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class AiScriptCommandHandler
    {
        private readonly MainModule m_mainModule;
        private readonly BattleEnv m_pBattleEnv;
        private BattleSimulator m_pBattleSimulator;
        private CommandParam m_commandParam;
        private WazaNo[][] m_usedWaza;
        internal bool m_isEscapeSelected;
        private Random m_randGenerator;

        // TODO
        public AiScriptCommandHandler(MainModule mainModule, BattleSimulator pBattleSimulator, BattleEnv pBattleEnv, ulong randSeed) { }

        public void Dispose()
        {
        	this.m_pBattleSimulator = null;
        	if (this.m_commandParam != null) {
        	  this.m_commandParam.clientID = 5;
        	  this.m_commandParam.attackPoke = 0;
        	  this.m_commandParam.defensePoke = 0;
        	  this.m_commandParam.currentBenchPoke = 0;
        	  this.m_commandParam.currentWazaIndex = 0;
        	  this.m_commandParam.currentWazaNo = 0;
        	  this.m_commandParam.currentItemNo = 0;
        	  this.m_commandParam.isGWazaUseTurn = 0;
        	}
        	this.m_commandParam = null;
        	this.m_usedWaza = null;
        	this.m_randGenerator = null;
        }

        // TODO
        public void SetCommandParam(in CommandParam commandParam) { }

        public CommandParam GetCommandParam()
        {
        	return this.m_commandParam;
        }

        public Random GetRandGenerator()
        {
        	return this.m_randGenerator;
        }

        public MainModule GetMainModule()
        {
        	return this.m_mainModule;
        }

        public BattleSimulator GetBattleSimulator()
        {
        	return this.m_pBattleSimulator;
        }

        public POKECON GetPokeCon()
        {
        	return this.m_pBattleEnv.m_pokecon;
        }

        public BattleEnv GetBattleEnv()
        {
        	return this.m_pBattleEnv;
        }

        public BTL_POKEPARAM GetAttackPokeParam()
        {
        	return this.m_commandParam.attackPoke;
        }

        public BTL_POKEPARAM GetDefensePokeParam()
        {
        	return this.m_commandParam.defensePoke;
        }

        public BtlPokePos GetAttackPokePos()
        {
        	if (this.m_commandParam.attackPoke != 0) {
        	  var uVar1 = this.m_commandParam.attackPoke.GetID();
        	  this.m_mainModule = this.m_mainModule.PokeIDtoPokePos(this.m_pBattleEnv.m_pokecon,uVar1);
        	  return this.m_mainModule;
        	}
        	return (BtlPokePos)5;
        }

        public BtlPokePos GetDefensePokePos()
        {
        	if (this.m_commandParam.defensePoke != 0) {
        	  var uVar1 = this.m_commandParam.defensePoke.GetID();
        	  this.m_mainModule = this.m_mainModule.PokeIDtoPokePos(this.m_pBattleEnv.m_pokecon,uVar1);
        	  return this.m_mainModule;
        	}
        	return (BtlPokePos)5;
        }

        private BtlPokePos GetPokePos(BTL_POKEPARAM pokeParam)
        {
        	if (pokeParam != null) {
        	  var uVar1 = pokeParam.GetID();
        	  this.m_mainModule = this.m_mainModule.PokeIDtoPokePos(this.m_pBattleEnv.m_pokecon,uVar1);
        	  return this.m_mainModule;
        	}
        	return (BtlPokePos)5;
        }

        public BTL_POKEPARAM GetBenchPokeParam()
        {
        	return this.m_commandParam.currentBenchPoke;
        }

        public byte GetCurrentWazaIndex()
        {
        	return (byte)(this.m_commandParam.currentWazaIndex);
        }

        public WazaNo GetCurrentWazaNo()
        {
        	return this.m_commandParam.currentWazaNo;
        }

        public ushort GetCurrentItemNo()
        {
        	return (ushort)(this.m_commandParam.currentItemNo);
        }

        // TODO
        public BTL_POKEPARAM GetBpp(BtlPokePos pos) { return null; }

        // TODO
        public BTL_POKEPARAM GetBppByAISide(uint ai_side) { return null; }

        public byte AISideToClientID(uint ai_side)
        {
        	if (ai_side == 4) {
        	  ai_side = 1;
        	}
        	var uVar1 = AISideToPokePos(ai_side);
        	this.m_mainModule.BtlPosToClientID(uVar1);
        	return 0;
        }

        // TODO
        public BtlPokePos AISideToPokePos(uint ai_side) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public TokuseiNo CheckTokuseiByAISide(int ai_side) { return TokuseiNo.NULL; }

        // TODO
        public uint CalcMaxDamage(BTL_POKEPARAM atkPoke, BTL_POKEPARAM defPoke, bool loss_flag) { return 0; }

        // TODO
        public void StoreUsedWaza(BTL_POKEPARAM bpp) { }

        // TODO
        public bool CheckWazaStored(BTL_POKEPARAM bpp, WazaNo waza_no) { return false; }

        public void ResetEscape()
        {
        	this.m_isEscapeSelected = false;
        }

        public void NotifyEscapeByAI()
        {
        	this.m_isEscapeSelected = true;
        }

        public bool IsEscapeSelected()
        {
        	return this.m_isEscapeSelected;
        }

        public class CommandParam
        {
            public byte clientID;
            public BTL_POKEPARAM attackPoke;
            public BTL_POKEPARAM defensePoke;
            public byte currentWazaIndex;
            public WazaNo currentWazaNo;
            public ushort currentItemNo;
            public BTL_POKEPARAM currentBenchPoke;
            public bool isGWazaUseTurn;

            public CommandParam()
            {
                Clear();
            }

            public void CopyFrom(CommandParam src)
            {
                clientID = src.clientID;
                attackPoke = src.attackPoke;
                defensePoke = src.defensePoke;
                currentWazaIndex = src.currentWazaIndex;
                currentWazaNo = src.currentWazaNo;
                currentItemNo = src.currentItemNo;
                currentBenchPoke = src.currentBenchPoke;
                isGWazaUseTurn = src.isGWazaUseTurn;
            }

            public void Clear()
            {
                clientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
                attackPoke = null;
                defensePoke = null;
                currentBenchPoke = null;
                currentWazaIndex = 0;
                currentWazaNo = WazaNo.NULL;
                currentItemNo = (ushort)ItemNo.DUMMY_DATA;
                isGWazaUseTurn = false;
            }
        }
    }
}