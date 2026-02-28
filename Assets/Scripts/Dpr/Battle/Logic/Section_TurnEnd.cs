namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnEnd : Section
	{
		public Section_TurnEnd(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		private void removeRaidBossReinforceHandler()
		{
			var iVar1 = Section.GetRule();
			if (iVar1 == 2) {
			  var uVar3 = 4.GetPokeParam();
			  var uVar2 = uVar3.GetID();
			  this.m_pServerCmdPutter.RemoveRaidBossHandler(uVar2,0);
			}
		}
		
		// TODO
		private void updateRaidBossReinforceTurn() { }
		
		// TODO
		private void updateRaidBossGWazaUseSchedule() { }
		
		// TODO
		private void updateRaidBossGWall() { }
		
		// TODO
		private void updateGGauge() { }
		
		// TODO
		private void updateGMode() { }
		
		// TODO
		private void updateGMode(BTL_POKEPARAM poke) { }
		
		private bool needEndG(BTL_POKEPARAM pPoke)
		{
			var uVar3 = Section.CheckShowdown();
			if ((uVar3 & 1) != 0) {
			  return this.m_pMainModule.NeedEndGOnBattleEnd();
			}
			var uVar2 = GMode.GetMaxTurn(0);
			var bVar1 = pPoke.GetGModePassedTurnCount();
			return (ulong)(uVar2 <= bVar1);
		}
		
		// TODO
		private void reliveAllDeadPartyOnRaidBattle() { }
		
		// TODO
		private void reliveAllDeadPartyOnRaidBattle(BTL_CLIENT_ID clientID) { }
		
		// TODO
		private void updateGRights() { }
		
		// TODO
		private void updateGRights(BtlSide side) { }
		
		// TODO
		private bool checkTransferGRights(BtlSide side) { return default; }
		
		// TODO
		private void transferGRights(BtlSide side) { }
		
		private void clearPokeTurnFlag()
		{
			var uVar2 = new PokeSet();
			storeFrontPokeByAgilityOrder(uVar2);
			uVar2.SeekStart();
			var lVar3 = uVar2.SeekNext();
			while (lVar3 != null) {
			  var uVar1 = lVar3.GetID();
			  this.m_pServerCmdPutter.TurnEnd(uVar1);
			  lVar3 = uVar2.SeekNext();
			}
		}
		
		// TODO
		private void storeFrontPokeByAgilityOrder(PokeSet pPokeSet) { }
		
		// TODO
		private void incPokeTurnCount() { }
		
		private bool checkForceQuitByTurnOver()
		{
			var iVar2 = 0.GetCounter();
			return this.m_pMainModule.GetForceQuitTurnCount() != 0 && (uint)MainModule.GetForceQuitTurnCount(this.m_pMainModule) <= iVar2 + 1U;
		}
		
		// TODO
		private void checkBattleTalk() { }
		
		// TODO
		private bool checkRaidBattleForceQuit() { return default; }

		public class Description { }

		public class Result { }
	}
}