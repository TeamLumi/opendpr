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

        // TODO
        public void StartScript(ScriptStartParam startParam) { }

        // TODO
        public bool WaitScript() { return false; }

        public AiScript.Result GetScriptResult()
        {
        	return this.m_result;
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