namespace Dpr.Battle.Logic
{
	public sealed class Section_Koraeru : Section
	{
		public Section_Koraeru(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description description) { }
		
		private void onKoraeru_ByDefender(BTL_POKEPARAM poke)
		{
			var uVar1 = poke.GetID();
			this.m_pServerCmdPutter.Message_Set(0x2b6,uVar1);
		}
		
		// TODO
		private void onKoraeru_ByFriendship(BTL_POKEPARAM poke) { }
		
		// TODO
		private void onKoraeru_ByOthers(BTL_POKEPARAM poke, KoraeruCause cause) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public KoraeruCause cause;
			
			public Description()
			{
				poke = null;
				cause = KoraeruCause.NONE;
			}
		}

		public class Result { }
	}
}