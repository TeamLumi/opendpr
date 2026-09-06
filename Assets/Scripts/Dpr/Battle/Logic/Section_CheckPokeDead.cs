namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckPokeDead : Section
	{
		public Section_CheckPokeDead(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void incWazaKillCount(PGLRecord.RecParam pPglParam) { }
		
		// TODO
		private void recordPokeDead(DeadRec pDeadRec, byte deadPokeID) { }
		
		// TODO
		private void putDeadMessage(BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private bool isKillCountIncrementEnable(byte deadPokeID, byte deadCausePokeID, DamageCause deadCause) { return default; }
		
		private bool isKillCountEffectEnable(bool isKillCountInc) {
		    return false;
		}
		
		private bool needDeadMessage(BTL_POKEPARAM pDeadPoke) {
		    return true;
		}
		
		// TODO
		private bool needDeadAct(BTL_POKEPARAM pDeadPoke) { return default; }
		
		// TODO
		private void removePokeDependEffect(BTL_POKEPARAM poke) { }
		
		// TODO
		private void endGMode(BTL_POKEPARAM poke) { }
		
		// TODO
		private void incGGaugeByFriendDead(BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private void updateNatsuki(BTL_POKEPARAM deadPoke) { }
		
		// TODO
		private uint checkExistEnemyMaxLevel() { return default; }
		
		// TODO
		private void updateRecord(byte deadPokeID) { }
		
		// TODO
		private void updateZukanData(BTL_POKEPARAM pDeadPoke) { }
		
		// TODO
		private void notifyPokeMemory(byte deadPokeID, byte deadCausePokeID) { }
		
		// TODO
		private void setPokeMemories(byte deadPokeID, byte deadCausePokeID) { }
		
		// TODO
		private void allDeadOnRaidBattle(BTL_POKEPARAM deadPoke) { }

		public class Description
		{
			public BTL_POKEPARAM poke;
			public bool isDeadMessageDisplay;
			public PGLRecord.RecParam pPglParam;
			
			public Description()
			{
				poke = null;
				pPglParam = null;
				isDeadMessageDisplay = false;
			}
		}

		public class Result
		{
			public bool isDead;
		}
	}
}