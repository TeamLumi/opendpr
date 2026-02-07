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
			if (m_isAvailable && m_numCause < NUM_CAUSE_PER_WAZA)
			{
				m_causes[m_numCause] = cause;
				m_numCause++;
			}
		}

		public Result GetResult()
		{
			if (!m_isAvailable || m_numCause == 0)
				return Result.RESULT_STD;

			if (countFailCode(Cause.CAUSE_OTHER_EFFECTS) > 0)
				return Result.RESULT_OTHER_EFFECTS;

			if (countFailCode(Cause.CAUSE_SELF) == m_numCause)
				return Result.RESULT_NO_EFFECT;

			return Result.RESULT_STD;
		}

		private void init()
		{
			for (int i=0; i<m_causes.Length; i++)
				m_causes[i] = Cause.CAUSE_NULL;

			m_numCause = 0;
		}

		private uint countFailCode(Cause failCode)
		{
			uint count = 0;
			for (uint i = 0; i < m_numCause; i++)
			{
				if (m_causes[i] == failCode)
					count++;
			}
			return count;
		}

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