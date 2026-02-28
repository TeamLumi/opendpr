using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class AiWazaJudge : AiJudge
    {
        public MainModule m_mainModule;
        public BattleEnv m_pBattleEnv;
        public BTL_POKEPARAM m_atkPoke;
        public BTL_POKEPARAM m_defPoke;
        public Random m_randGenerator = new Random();
        public AiScript m_script;
        public AiScriptHandler m_scriptHandler;
        public AiScriptCommandHandler m_scriptCommandHandler;
        public byte m_pokeID;
        public byte m_atkClientID;
        public BtlPokePos m_atkPos;
        public BtlPokePos m_defPos;
        public byte m_currentWazaPos;
        public WazaNo m_currentWazaNo;
        public ushort m_itemId;
        public bool m_isGoingToStartG;
        public uint m_AIStep;
        public int[][] m_wazaScore = RectangularArrays.RectangularDefaultArray<int>(DefineConstants.BTL_POSIDX_MAX, BattleDefConst.PTL_WAZA_MAX);
        public ScoreStatus[][] m_wazaScoreStatus = RectangularArrays.RectangularScoreStatusArray(DefineConstants.BTL_POSIDX_MAX, BattleDefConst.PTL_WAZA_MAX);
        public bool[] m_usableWazaFlags = new bool[BattleDefConst.PTL_WAZA_MAX];
        public bool[] m_bTokuseiAppeared = new bool[PokeID.NUM];
        public int m_selectWazaScore;
        public byte m_selectWazaPos;
        public BtlPokePos m_selectTargetPos;
        public byte m_currentTargetIdx;
        public bool m_bTargetSideFriend;
        public bool m_bEscape;
        public bool m_bDecided;
        public bool m_bFinished;

        public AiWazaJudge(AiScript aiScript, MainModule mainModule, BattleEnv pBattleEnv, BattleSimulator pBattleSimulator, ulong randSeed, uint ai_bit, byte myClientID) :
            base(myClientID, BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_MIN, BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_MAX, ai_bit)
        {
            m_mainModule = mainModule;
            m_pBattleEnv = pBattleEnv;
            m_atkPoke = null;
            m_defPoke = null;
            m_script = aiScript;
            m_scriptHandler = null;
            m_scriptCommandHandler = null;

            m_pokeID = PokeID.INVALID;
            m_atkClientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;
            m_atkPos = BtlPokePos.POS_NULL;
            m_defPos = BtlPokePos.POS_NULL;
            m_currentWazaNo = WazaNo.NULL;
            m_itemId = (ushort)ItemNo.DUMMY_DATA;
            m_AIStep = 0;
            m_selectWazaScore = 0;
            m_selectWazaPos = 0;
            m_selectTargetPos = BtlPokePos.POS_NULL;
            m_currentTargetIdx = 0;
            m_bTargetSideFriend = false;
            m_bEscape = false;
            m_bDecided = false;
            m_bFinished = false;

            m_randGenerator.Initialize(randSeed);
            m_scriptHandler = new AiScriptHandler();
            m_scriptCommandHandler = new AiScriptCommandHandler(mainModule, pBattleSimulator, pBattleEnv, randSeed);
        }

        // TODO
        public override void Dispose() { }

        // TODO
        public void SetJudgeParam(bool[] usableWazaFlags, BtlPokePos pos, byte pokeID, ushort itemId, bool isGoingToStartG) { }

        public void StartJudge()
        {
        	this.m_AIStep = 0;
        	this.m_bDecided = false;
        	this.m_scriptCommandHandler.m_isEscapeSelected = 0;
        }

        public override bool IsJudgeFinished()
        {
        	return this.m_bFinished;
        }

        // TODO
        public override void UpdateJudge() { }

        // TODO
        private void subProc_Core() { }

        // TODO
        private bool incrementTargetIndex() { return false; }

        // TODO
        private BtlPokePos updateTargetPos(bool bFriendSide, byte targetIdx) { return BtlPokePos.POS_1ST_0; }

        private bool isTargettingCoveragePos(WazaNo waza_no, BtlPokePos targetPos)
        {
        	return this.m_atkPos != targetPos;
        }

        // TODO
        private BtlPokePos correctTargetPos(BtlPokePos targetPos, byte wazaIdx) { return BtlPokePos.POS_1ST_0; }

        // TODO
        private BtlPokePos searchBestScorePos(byte wazaIdx, BtlPokePos atkPos, BtlSide side) { return BtlPokePos.POS_1ST_0; }

        // TODO
        private BTL_POKEPARAM decideTargetPoke(BtlPokePos target_pos) { return null; }

        // TODO
        private void wazaScore_Reset() { }

        // TODO
        private int wazaScore_Add(byte wazaIdx, BtlPokePos targetPos, int score) { return 0; }

        private void wazaScore_SetScoreless(byte wazaIdx, BtlPokePos targetPos)
        {
        	uint uVar1 = default;
        	if ((3 < wazaIdx) || (uVar1 = (int)targetPos & 0xff, 4 < uVar1)) {
        	}
        	if (uVar1 < this.m_wazaScoreStatus.Length) {
        	  if ((uint)wazaIdx < this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0].Length) {
        	    this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0] + (ulong)wazaIdx * 4[0] = 2;
        	    if ((uVar1 < this.m_wazaScore.Length) &&
        	       (this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0] = this.m_wazaScore + ((ulong)(int)targetPos & 0xff) * 8[0],
        	       (uint)wazaIdx < this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0].Length)) {
        	      this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0] + (ulong)wazaIdx * 4[0] = 0;
        	    }
        	  }
        	}
        }

        private bool wazaScore_IsScoreless(byte wazaIdx, BtlPokePos targetPos)
        {
        	uint uVar1 = default;
        	if ((3 < wazaIdx) || (uVar1 = (int)targetPos & 0xff, 4 < uVar1)) {
        	  return false;
        	}
        	if (uVar1 < this.m_wazaScoreStatus.Length) {
        	  if ((uint)wazaIdx < this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0].Length) {
        	    if (this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0] + (ulong)wazaIdx * 4[0] != 2) {
        	      return false;
        	    }
        	    if ((uVar1 < this.m_wazaScore.Length) &&
        	       (this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0] = this.m_wazaScore + ((ulong)(int)targetPos & 0xff) * 8[0],
        	       (uint)wazaIdx < this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0].Length)) {
        	      if (this.m_wazaScoreStatus + ((ulong)(int)targetPos & 0xff) * 8[0] + (ulong)wazaIdx * 4[0] != 0) {
        	        return false;
        	      }
        	      return true;
        	    }
        	  }
        	}
        }

        // TODO
        private void wazaScore_DecideBest() { }

        // TODO
        private void wazaScore_DecideRaidBoss() { }

        private WazaNo getAttackerWazaNo(byte wazaIdx)
        {
        	if (((this.m_atkPoke.IsGMode() & 1) == 0) && (!this.m_isGoingToStartG)) {
        	  return this.m_atkPoke.WAZA_GetID(wazaIdx) & 0xffffffff;
        	}
        	this.m_atkPoke.WAZA_GetID(wazaIdx) = GWaza.GetGWaza(BTL_POKEPARAM.WAZA_GetID(this.m_atkPoke,wazaIdx) & 0xffffffff,0);
        	return this.m_atkPoke.WAZA_GetID(wazaIdx);
        }

        public bool IsEnemyEscape()
        {
        	return this.m_scriptCommandHandler.m_isEscapeSelected;
        }

        public bool IsWazaSelected()
        {
        	return this.m_bDecided;
        }

        public int GetSelectedWazaScore()
        {
        	return this.m_selectWazaScore;
        }

        public void GetSelectedWaza(ref byte wazaIdx, ref BtlPokePos targetPos)
        {
        	if (this.m_bDecided) {
        	  wazaIdx = (byte)(this.m_selectWazaPos);
        	  targetPos = (BtlPokePos)(this.m_selectTargetPos);
        	}
        }

        public enum ScoreStatus : int
        {
            STATUS_NORMAL = 0,
            STATUS_DISABLE = 1,
            STATUS_DISCOURAGE = 2,
        }

        private enum SeqSubProc_Core : int
        {
            AISTEP_START = 0,
            AISTEP_INIT = 1,
            AISTEP_SWITCH_SCRIPT = 2,
            AISTEP_CHECK_RUNNABLE_SCRIPT = 3,
            AISTEP_SCRIPT_START = 4,
            AISTEP_SETUP_WAZA = 5,
            AISTEP_SCRIPT_WAIT = 6,
            AISTEP_SWITCH_WAZA = 7,
            AISTEP_SWITCH_TARGET = 8,
            AISTEP_DONE = 9,
        }

        private class ScoreData
        {
            public int score;
            public byte wazaIdx;
            public BtlPokePos targetPos;
        }
    }
}