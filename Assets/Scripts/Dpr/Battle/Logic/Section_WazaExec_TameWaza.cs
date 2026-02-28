namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_TameWaza : Section
	{
		public Section_WazaExec_TameWaza(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool tameStart(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targetRec) { return default; }
		
		// TODO
		private void putTameStartCommand(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targetRec) { }
		
		// TODO
		private void putHideCommand(BTL_POKEPARAM attacker, byte hideTargetPokeID) { }
		
		// TODO
		private bool event_TameStart(ref byte pHideTargetPokeID, ref bool pIsFailMsgDisplayed, BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targetRec) { return default; }
		
		private void event_TameStartFixed(BTL_POKEPARAM attacker)
		{
			this.m_pEventLauncher.Event_TameStartFixed(attacker);
		}
		
		// TODO
		private void event_TameSkipFixed(BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private bool event_TameRelease(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targetRec) { return default; }
		
		// TODO
		private void clearTameLock(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targetRec;
		}

		public class Result
		{
			public TameWazaResult resultCode;
		}
	}
}