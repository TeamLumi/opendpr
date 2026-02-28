namespace Dpr.Battle.Logic
{
	public sealed class SimpleEffectFailManager
	{
		private const int NUM_CAUSE_PER_WAZA = 5;

		private Cause[] m_causes = new Cause[NUM_CAUSE_PER_WAZA];
		private uint m_numCause;
		private bool m_isAvailable;
		
		public SimpleEffectFailManager()
		{
			init();
			End();
		}
		
		public void Start()
		{
			init();
			m_isAvailable = true;
		}
		
		public void End()
		{
            m_isAvailable = false;
        }
		
		public void AddCause(Cause cause)
		{
			if (this.m_isAvailable) {
			  if ((long)(ulong)this.m_numCause < (long)this.m_causes.Length) {
			    this.m_numCause = this.m_numCause + 1;
			    if (this.m_causes.Length <= this.m_numCause) {
			    }
			    this.m_causes + (ulong)this.m_numCause * 4[0] = cause;
			  }
			}
		}
		
		// TODO
		public Result GetResult() { return default; }
		
		private void init()
		{
			for (int i=0; i<m_causes.Length; i++)
				m_causes[i] = Cause.CAUSE_NULL;

			m_numCause = 0;
		}
		
		// TODO
		private uint countFailCode(Cause failCode) { return default; }

		public enum Cause : int
		{
			CAUSE_NULL = 0,
			CAUSE_SELF = 1,
			CAUSE_LIMIT = 2,
			CAUSE_MIGAWARI = 3,
			CAUSE_OTHER_EFFECTS = 4,
		}

		public enum Result : int
		{
			RESULT_STD = 0,
			RESULT_NO_EFFECT = 1,
			RESULT_OTHER_EFFECTS = 2,
		}
	}
}