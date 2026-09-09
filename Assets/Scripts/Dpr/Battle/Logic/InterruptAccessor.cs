namespace Dpr.Battle.Logic
{
	public sealed class InterruptAccessor
	{
		private InterruptCode m_interrupt;
		
		public InterruptAccessor()
		{
			m_interrupt = InterruptCode.NONE;
		}
		
		// TODO
		public void Clear() { }
		
		public void Request(InterruptCode interrupt) {
		    this.m_interrupt = interrupt;
		}
		
		// TODO
		public bool IsRequested(InterruptCode interrupt) { return default; }
		
		// TODO
		public bool IsRequested() { return default; }
		
		public InterruptCode GetRequest() {
		    return m_interrupt;
		}
	}
}