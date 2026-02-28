using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Failed : Section
	{
		public Section_WazaExec_Failed(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void section_ConfDamage(BTL_POKEPARAM pPoke) { }
		
		// TODO
		private bool section_CheckPokeDead(BTL_POKEPARAM pPoke) { return default; }
		
		// TODO
		private void put_WazaFail(BTL_POKEPARAM pAttacker, WazaNo waza, WazaFailCause failCause) { }
		
		private void event_CheckWazaExeFail(BTL_POKEPARAM pAttacker, WazaNo waza, WazaFailCause failCause)
		{
			this.m_pEventLauncher.Event_CheckWazaExeFail();
		}

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public WazaNo waza;
			public WazaFailCause failCause;
			
			public Description()
			{
				pAttacker = null;
				waza = WazaNo.NULL;
				failCause = WazaFailCause.NONE;
			}
		}

		public class Result { }
	}
}