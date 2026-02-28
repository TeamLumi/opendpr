namespace Dpr.Battle.Logic
{
	public sealed class Section_Migawari_Create : Section
	{
		public Section_Migawari_Create(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		private void putAlreadyExistMessage(BTL_POKEPARAM poke)
		{
			this.m_pServerCmdPutter.Message_Set(poke,0x426)
			;
		}
		
		// TODO
		private bool isHpEnough(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private uint calcMigawariHP(BTL_POKEPARAM poke) { return default; }
		
		private void putFailedMessage()
		{
			this.m_pServerCmdPutter.Message_StdEx(0x8c,0,0);
		}
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			
			public Description()
			{
				poke = null;
			}
		}

		public class Result
		{
			public bool isCreated;
		}
	}
}