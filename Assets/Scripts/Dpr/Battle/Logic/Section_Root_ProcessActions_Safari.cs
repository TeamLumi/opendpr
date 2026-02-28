namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_ProcessActions_Safari : Section
	{
		public Section_Root_ProcessActions_Safari(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void processPlayer(SVCL_ACTION clientInstructions) { }
		
		// TODO
		private void processEnemy(SVCL_ACTION clientInstructions) { }
		
		// TODO
		private void throwSafariBall(byte pokeID) { }
		
		// TODO
		private void throwEsa(byte pokeID) { }
		
		// TODO
		private void throwDoro(byte pokeID) { }
		
		private void yousumi(byte pokeID)
		{
			this.m_pServerCmdPutter.SafariAct(pokeID,2,0);
		}
		
		// TODO
		private bool escape(byte pokeID) { return default; }
		
		// TODO
		private void ballEmpty() { }

		public class Description
		{
			public SVCL_ACTION pClientInstructions;
			
			public Description()
			{
				pClientInstructions = null;
			}
		}

		public class Result
		{
			public InterruptCode interrupt;
		}
	}
}