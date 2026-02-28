namespace Dpr.Battle.Logic
{
    public sealed class AiScript
    {
        private static BtlAIBaseScript[] s_PawnBaeCache = new BtlAIBaseScript[(int)BtlAiScriptNo.BTL_AISCRIPT_NO_NUM];
        private uint m_loadedScriptNo;
        private BtlAIBaseScript m_script;

        public AiScript()
        {
            m_script = null;
            m_loadedScriptNo = (int)BtlAiScriptNo.BTL_AISCRIPT_NO_NULL;
        }

        // TODO
        public bool StartLoadScript(BtlAiScriptNo scriptNo) { return false; }

        // TODO
        private static BtlAIBaseScript CreateScriptBase(uint scriptNo) { return null; }

        // TODO
        public static void ReleaseAiScriptCache() { }

        public bool WaitLoadScript()
        {
        	return this.m_script != null;
        }

        // TODO
        public void SetExecParameter(AiScriptCommandHandler commandHandler) { }

        public bool Execute()
        {
        	if (this.m_script != null) {
        	  this.m_script.Execute();
        	}
        	return true;
        }

        public void GetResult(Result dest)
        {
        	this.m_script.GetResult(dest);
        }

        public void UnLoadScript()
        {
        	this.m_script = null;
        }

        public class Result
        {
            public int score;
            public bool isPokeChangeEnable;
        }
    }
}