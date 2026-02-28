namespace Dpr.Battle.Logic
{
    public sealed class BattleAi
    {
        private readonly MainModule m_mainModule;
        private readonly BattleEnv m_pBattleEnv;
        private BTL_CLIENT m_client;
        private BTL_POKEPARAM m_procPoke;
        private Random m_randGenerator;
        private AiScript m_script;
        private AiItemJudge m_itemJudge;
        private AiPokeChangeJudge m_pokeChangeJudge;
        private AiWazaJudge m_wazaJudge;
        private bool[] m_isWazaSelectable;
        private bool m_isGoingToStartG;
        private ushort m_judgeTargetItem;
        private byte m_pokeChangeTarget;
        private byte m_selectedWazaIndex;
        private BtlPokePos m_selectedTargetPos;
        private Result m_result;
        private uint m_turnCount;
        private uint m_seq;
        private bool m_isFinished;
        private ActionData[] m_actionData;

        private static readonly AiAction[] selectForcedActionByPriority_priorityTable = new AiAction[]
        {
            AiAction.AIACT_WAZA, AiAction.AIACT_ESCAPE, AiAction.AIACT_ITEM, AiAction.AIACT_POKECHANGE, AiAction.AIACT_WARUAGAKI,
        };

        // TODO
        public BattleAi(in SetupParam setupParam) { }

        public void ChangeScript(uint scriptNoBit)
        {
        	this.m_wazaJudge.m_targetScriptBit = scriptNoBit;
        	this.m_itemJudge.m_targetScriptBit = scriptNoBit;
        	this.m_pokeChangeJudge.m_targetScriptBit = scriptNoBit;
        }

        public uint GetScript()
        {
        	return this.m_itemJudge.m_targetScriptBit | this.m_wazaJudge.m_targetScriptBit |
        	       this.m_pokeChangeJudge.m_targetScriptBit;
        	return 0;
        }

        public bool IsActionSelectFinished()
        {
        	return this.m_isFinished;
        }

        public Result GetResult()
        {
        	return this.m_result;
        }

        // TODO
        public void StartActionSelect(in StartParam startParam) { }

        // TODO
        public void UpdateActionSelect() { }

        // TODO
        private void setActionDataByWazaJudge(in AiWazaJudge wazaJudge) { }

        // TODO
        private bool CheckSpecialAction(Result result) { return false; }

        private bool IsItemUseEnable()
        {
        	return this.m_judgeTargetItem != 0;
        }

        // TODO
        private bool IsPokeChangeEnable() { return false; }

        // TODO
        private bool IsEnemyExist() { return false; }

        // TODO
        private bool IsWazaUseEnable() { return false; }

        // TODO
        private ushort GetItemNoForWazaJudge() { return 0; }

        // TODO
        private void UpdateJudge(AiJudge judge) { }

        // TODO
        private uint GetSelectableWazaCount() { return 0; }

        // TODO
        private void DecideAction() { }

        // TODO
        private AiAction GetBestAction() { return AiAction.AIACT_WAZA; }

        // TODO
        private AiAction GetForcedAction() { return AiAction.AIACT_WAZA; }

        // TODO
        private static AiAction selectForcedActionByPriority(AiAction[] candidates, uint numCandidates) { return AiAction.AIACT_WAZA; }

        // TODO
        private AiAction GetBestScoredAction() { return AiAction.AIACT_WAZA; }

        // TODO
        private uint storeBestScoredActions(AiAction[] dest, uint numDestArray) { return 0; }

        // TODO
        private AiAction SelectActionAtRandom(AiAction[] actionArray, uint actionNum) { return AiAction.AIACT_WAZA; }

        // TODO
        private void SetupActionParam(Result destParam, AiAction action) { }

        public enum AiAction : int
        {
            AIACT_WAZA = 0,
            AIACT_ITEM = 1,
            AIACT_POKECHANGE = 2,
            AIACT_ESCAPE = 3,
            AIACT_WARUAGAKI = 4,
            AIACT_NUM = 5,
            AIACT_NULL = 6,
        }

        public class SetupParam
        {
            public MainModule mainModule;
            public BattleEnv pBattleEnv;
            public BattleSimulator pBattleSimulator;
            public ulong randSeed;
            public uint scriptNoBit;
            public byte myClientID;
        }

        public class StartParam
        {
            public byte pokeId;
            public bool[] selectableWazaFlags = new bool[BattleDefConst.PTL_WAZA_MAX];
            public ushort itemId;
            public bool isGoingToStartG;
        }

        public class Result
        {
            public AiAction action;
            public byte wazaIndex;
            public BtlPokePos wazaTargetPos;
            public ushort itemId;
            public byte changePokeIndex;
        }

        private enum ActionValuation : int
        {
            ACTION_VALUATION_SCORE = 0,
            ACTION_VALUATION_PROHIBIT = 1,
            ACTION_VALUATION_FORCE = 2,
        }

        private class ActionData
        {
            public ActionValuation valuation;
            public int score;
        }

        private enum SeqUpdateActionSelect : int
        {
            SEQ_START = 0,
            SEQ_ITEM_START = 1,
            SEQ_ITEM_WAIT = 2,
            SEQ_POKECHANGE_START = 3,
            SEQ_POKECHANGE_WAIT = 4,
            SEQ_WAZA_START = 5,
            SEQ_WAZA_WAIT = 6,
            SEQ_DECIDE_ACT = 7,
            SEQ_DONE = 8,
        }
    }
}