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
		
		private void putDeadMessage(BTL_POKEPARAM deadPoke)
		{
			var uVar1 = deadPoke.IsRaidBoss();
			if (uVar1) {
			}
			this.m_pServerCmdPutter.Message_Set(deadPoke,0);
		}
		
		private bool isKillCountIncrementEnable(byte deadPokeID, byte deadCausePokeID, DamageCause deadCause)
		{
			var uVar1 = Section.CheckFriendPoke();
			if ((uVar1 & 1) != 0) {
			  return false;
			}
			return deadCause != deadCausePokeID && deadCause != '\x1f';
		}
		
		private bool isKillCountEffectEnable(bool isKillCountInc)
		{
			return false;
		}
		
		private bool needDeadMessage(BTL_POKEPARAM pDeadPoke)
		{
			return true;
		}
		
		// TODO
		private bool needDeadAct(BTL_POKEPARAM pDeadPoke) { return default; }
		
		// TODO
		private void removePokeDependEffect(BTL_POKEPARAM poke) { }
		
		private void endGMode(BTL_POKEPARAM poke)
		{
			var uVar2 = poke.IsGMode();
			if (uVar2) {
			  var uVar1 = poke.GetID();
			  this.m_pServerCmdPutter.EndGMode(uVar1);
			}
		}
		
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
		
		private void setPokeMemories(byte deadPokeID, byte deadCausePokeID)
		{
			if ((deadCausePokeID & 0xff) != 0x1f) {
			  var uVar1 = deadCausePokeID.CheckPlayersPoke();
			  if ((uVar1 & 1) != 0) {
			    var uVar2 = deadPokeID.GetPokeParam();
			    var uVar3 = deadCausePokeID.GetPokeParam();
			    Memories.SetMemories_OnKill(this.m_pMainModule,uVar3,uVar2);
			  }
			}
		}
		
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