namespace Dpr.Battle.Logic
{
	public sealed class InterruptAccessor
	{
		private InterruptCode m_interrupt;
		
		public InterruptAccessor()
		{
			m_interrupt = InterruptCode.NONE;
		}
		
		public void Clear()
		{
			this.m_interrupt = (InterruptCode)0;
		}
		
		public void Request(InterruptCode interrupt)
		{
			this.m_interrupt = (InterruptCode)(interrupt);
		}
		
		// TODO
		public bool IsRequested(InterruptCode interrupt) { return default; }
		
		// TODO
		public bool IsRequested() { return default; }
		
		public InterruptCode GetRequest()
		{
			return this.m_interrupt;
		}
	}
}