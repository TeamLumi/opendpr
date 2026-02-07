using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class AiItemJudge : AiJudge
    {
        private readonly MainModule m_mainModule;
        private readonly BattleEnv m_pBattleEnv;
        private BTL_POKEPARAM m_poke;
        private Random m_randGenerator = new Random();
        private AiScript m_script;
        private AiScriptHandler m_scriptHandler;
        private AiScriptCommandHandler m_scriptCommandHandler;
        private ushort m_itemNo;
        private int m_score;
        private uint m_seq;
        private bool m_isFinished;

        public AiItemJudge(AiScript aiScript, MainModule mainModule, BattleEnv pBattleEnv, BattleSimulator pBattleSimulator, ulong randSeed, uint scriptBit, byte myClientID) :
            base(myClientID, BtlAiScriptNo.BTL_AISCRIPT_NO_ITEM_MIN, BtlAiScriptNo.BTL_AISCRIPT_NO_ITEM_MAX, scriptBit)
        {
            m_mainModule = mainModule;
            m_pBattleEnv = pBattleEnv;
            m_poke = null;
            m_script = aiScript;
            m_scriptHandler = null;
            m_scriptCommandHandler = null;
            m_itemNo = (ushort)ItemNo.DUMMY_DATA;
            m_score = 0;
            m_isFinished = true;

            m_randGenerator.Initialize(randSeed);
            m_scriptHandler = new AiScriptHandler();
            m_scriptCommandHandler = new AiScriptCommandHandler(mainModule, pBattleSimulator, pBattleEnv, randSeed);
        }

        public override void Dispose()
        {
            m_scriptCommandHandler = null;
            m_scriptHandler = null;
        }

        public void StartJudge(BTL_POKEPARAM poke, ushort itemNo)
        {
            m_poke = poke;
            m_itemNo = itemNo;
            m_score = 0;
            m_isFinished = false;
            m_seq = (uint)UpdateJudgeSeq.SEQ_SCRIPT_START;

            ResetScriptNo();
        }

        public override void UpdateJudge()
        {
            switch ((UpdateJudgeSeq)m_seq)
            {
                case UpdateJudgeSeq.SEQ_SCRIPT_START:
                    if (IsAllScriptFinished())
                    {
                        m_seq = (uint)UpdateJudgeSeq.SEQ_END;
                    }
                    else
                    {
                        StartScript();
                        m_seq = (uint)UpdateJudgeSeq.SEQ_SCRIPT_WAIT;
                    }
                    break;

                case UpdateJudgeSeq.SEQ_SCRIPT_WAIT:
                    if (m_scriptHandler.WaitScript())
                    {
                        RegisterScriptResult();
                        m_seq = (uint)UpdateJudgeSeq.SEQ_TO_NEXT_SCRIPT;
                    }
                    break;

                case UpdateJudgeSeq.SEQ_TO_NEXT_SCRIPT:
                    UpdateScriptNo();
                    m_seq = (uint)UpdateJudgeSeq.SEQ_SCRIPT_START;
                    break;

                case UpdateJudgeSeq.SEQ_END:
                    m_isFinished = true;
                    break;
            }
        }

        private void StartScript()
        {
            var startParam = new AiScriptHandler.ScriptStartParam();
            startParam.script = m_script;
            startParam.scriptNo = GetCurrentScriptNo();
            startParam.commandHandler = m_scriptCommandHandler;
            startParam.commandParam.clientID = GetMyClientID();
            startParam.commandParam.attackPoke = m_poke;
            startParam.commandParam.defensePoke = null;
            startParam.commandParam.currentWazaIndex = 0;
            startParam.commandParam.currentWazaNo = WazaNo.NULL;
            startParam.commandParam.currentItemNo = m_itemNo;
            startParam.commandParam.currentBenchPoke = null;
            startParam.commandParam.isGWazaUseTurn = false;

            m_scriptHandler.StartScript(startParam);
        }

        private void RegisterScriptResult()
        {
            m_score += m_scriptHandler.GetScriptResult().score;
        }

        public override bool IsJudgeFinished()
        {
            return m_isFinished;
        }

        public int GetScore()
        {
            return m_score;
        }

        private enum UpdateJudgeSeq : int
        {
            SEQ_SCRIPT_START = 0,
            SEQ_SCRIPT_WAIT = 1,
            SEQ_TO_NEXT_SCRIPT = 2,
            SEQ_END = 3,
        }
    }
}