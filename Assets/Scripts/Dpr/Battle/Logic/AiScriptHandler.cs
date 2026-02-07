namespace Dpr.Battle.Logic
{
    public sealed class AiScriptHandler
    {
        private AiScript m_script;
        private BtlAiScriptNo m_scriptNo;
        private AiScriptCommandHandler m_commandHandler;
        private AiScriptCommandHandler.CommandParam m_commandParam = new AiScriptCommandHandler.CommandParam();
        private uint m_seq;
        private AiScript.Result m_result = new AiScript.Result();

        public AiScriptHandler()
        {
            m_script = null;
            m_commandHandler = null;
            m_scriptNo = BtlAiScriptNo.BTL_AISCRIPT_NO_NULL;
            m_seq = 0;
        }

        public void StartScript(ScriptStartParam startParam)
        {
            m_script = startParam.script;
            m_scriptNo = startParam.scriptNo;
            m_commandHandler = startParam.commandHandler;
            m_commandParam.CopyFrom(startParam.commandParam);
            m_seq = (uint)SeqWaitScript.SEQ_LOAD_START;
        }

        public bool WaitScript()
        {
            switch ((SeqWaitScript)m_seq)
            {
                case SeqWaitScript.SEQ_LOAD_START:
                    m_script.StartLoadScript(m_scriptNo);
                    m_seq = (uint)SeqWaitScript.SEQ_LOAD_WAIT;
                    break;
                case SeqWaitScript.SEQ_LOAD_WAIT:
                    if (m_script.WaitLoadScript())
                    {
                        m_seq = (uint)SeqWaitScript.SEQ_EXEC_START;
                    }
                    break;
                case SeqWaitScript.SEQ_EXEC_START:
                    m_script.SetExecParameter(m_commandHandler);
                    m_seq = (uint)SeqWaitScript.SEQ_EXEC_WAIT;
                    break;
                case SeqWaitScript.SEQ_EXEC_WAIT:
                    if (m_script.Execute())
                    {
                        m_script.GetResult(m_result);
                        m_script.UnLoadScript();
                        m_seq = (uint)SeqWaitScript.SEQ_END;
                    }
                    break;
                case SeqWaitScript.SEQ_END:
                    return true;
            }
            return false;
        }

        public AiScript.Result GetScriptResult()
        {
            return m_result;
        }

        public class ScriptStartParam
        {
            public AiScript script;
            public BtlAiScriptNo scriptNo;
            public AiScriptCommandHandler commandHandler;
            public AiScriptCommandHandler.CommandParam commandParam = new AiScriptCommandHandler.CommandParam();
        }

        public enum SeqWaitScript : int
        {
            SEQ_LOAD_START = 0,
            SEQ_LOAD_WAIT = 1,
            SEQ_EXEC_START = 2,
            SEQ_EXEC_WAIT = 3,
            SEQ_END = 4,
        }
    }
}