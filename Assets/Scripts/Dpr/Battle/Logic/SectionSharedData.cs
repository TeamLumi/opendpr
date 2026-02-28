namespace Dpr.Battle.Logic
{
    public sealed class SectionSharedData
    {
        private ActionSharedDataStack m_actionSharedDataStack;
        private InterruptAccessor m_interruptAccessor;
        private PartyAllDeadRecorder m_partyAllDeadRecorder;
        private PokemonBattleInRegister m_pokemonBattleInRegister;
        private ushort[] m_itemChangeCounter;
        private byte m_turnCheckStep;
        private ulong m_turnFlag;

        // TODO
        public SectionSharedData(in SetupParam param) { }

        public void Initialize()
        {
        	this.m_actionSharedDataStack.Initialize();
        	this.m_interruptAccessor.Clear();
        	this.m_partyAllDeadRecorder.Clear();
        	this.m_pokemonBattleInRegister.Clear();
        	if (0 < (int)this.m_itemChangeCounter.Length) {
        	  var uVar4 = 0;
        	  var uVar5 = this.m_itemChangeCounter.Length & 0xffffffff;
        	  do {
        	    if (uVar5 <= uVar4) {
        	    }
        	    var lVar1 = uVar4 * 2;
        	    uVar4 = uVar4 + 1;
        	    this.m_itemChangeCounter + lVar1[0] = 0;
        	    uVar5 = (ulong)this.m_itemChangeCounter.Length;
        	  } while ((long)uVar4 < (int)this.m_itemChangeCounter.Length);
        	}
        	this.m_turnCheckStep = (byte)0;
        	this.m_turnFlag = 0;
        }

        public ActionSharedDataStack GetActionSharedDataStack()
        {
        	return this.m_actionSharedDataStack;
        }

        public InterruptAccessor GetInterruptAccessor()
        {
        	return this.m_interruptAccessor;
        }

        public PartyAllDeadRecorder GetPartyAllDeadRecorder()
        {
        	return this.m_partyAllDeadRecorder;
        }

        public PokemonBattleInRegister GetPokemonBattleInRegister()
        {
        	return this.m_pokemonBattleInRegister;
        }

        public byte GetTurnCheckStep()
        {
        	return (byte)(this.m_turnCheckStep);
        }

        public void IncTurnCheckStep()
        {
        	this.m_turnCheckStep = (byte)(this.m_turnCheckStep + '\x01');
        }

        public void ResetTurnCheckStep()
        {
        	this.m_turnCheckStep = (byte)0;
        }

        public ushort GetItemChangeCount(byte pokeID)
        {
        	var uVar1 = (uint)pokeID & 0xff;
        	if ((int)this.m_itemChangeCounter.Length <= (int)uVar1) {
        	  return 0;
        	}
        	if (uVar1 < this.m_itemChangeCounter.Length) {
        	  return (ushort)(this.m_itemChangeCounter + (pokeID & 0xff) * 2[0]);
        	}
        }

        public void IncItemChangeCount(byte pokeID)
        {
        	var uVar2 = (uint)pokeID & 0xff;
        	if ((int)uVar2 < (int)this.m_itemChangeCounter.Length) {
        	  if (this.m_itemChangeCounter.Length <= uVar2) {
        	  }
        	  this.m_itemChangeCounter + (pokeID & 0xff) * 2[0] = this.m_itemChangeCounter + (pokeID & 0xff) * 2[0] + 1;
        	}
        }

        public void ClearItemChangeCount()
        {
        	if (0 < (int)this.m_itemChangeCounter.Length) {
        	  var uVar4 = 0;
        	  var uVar5 = this.m_itemChangeCounter.Length & 0xffffffff;
        	  do {
        	    if (uVar5 <= uVar4) {
        	    }
        	    var lVar1 = uVar4 * 2;
        	    uVar4 = uVar4 + 1;
        	    this.m_itemChangeCounter + lVar1[0] = 0;
        	    uVar5 = (ulong)this.m_itemChangeCounter.Length;
        	  } while ((long)uVar4 < (int)this.m_itemChangeCounter.Length);
        	}
        }

        public bool GetTurnFlag(TurnFlag flag)
        {
        	return (this.m_turnFlag & 1L << ((int)flag & 0x3f)) != 0;
        }

        public void SetTurnFlag(TurnFlag flag)
        {
        	this.m_turnFlag = this.m_turnFlag | 1L << ((int)flag & 0x3f);
        }

        public void ResetTurnFlag(TurnFlag flag)
        {
        	this.m_turnFlag =
        	     this.m_turnFlag & (1L << ((int)flag & 0x3f) ^ 0xffffffffffffffffU);
        }

        public void ClearTurnFlag()
        {
        	this.m_turnFlag = 0;
        }

        public class SetupParam { }

        public enum TurnFlag : ulong
        {
            ESCAPE_MESSAGE_DISPLAYED = 0,
            TURN_START_PROCESS_DONE = 1,
            BEFORE_FIRST_FIGHT_PROCESS_DONE = 2,
            RAID_BOSS_EXTRA_ACTION_ADD = 3,
            GWALL_BREAK_EFFECT_DISPLAYED = 4,
            NUM = 5,
        }
    }
}