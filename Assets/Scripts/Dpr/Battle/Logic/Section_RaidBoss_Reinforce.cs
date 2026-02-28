namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_Reinforce : Section
	{
		public Section_RaidBoss_Reinforce(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool canReinforce(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private void cureSick(BTL_POKEPARAM boss) { }
		
		// TODO
		private void recoverRank(BTL_POKEPARAM boss) { }
		
		// TODO
		private void setNextTurn(BTL_POKEPARAM boss) { }
		
		private void registerHandler(BTL_POKEPARAM boss)
		{
			var uVar1 = boss.GetID();
			this.m_pServerCmdPutter.AddRaidBossHandler(uVar1,0);
		}
		
		// TODO
		private void decGWallRepairCount(BTL_POKEPARAM boss) { }
		
		// TODO
		private void resetPlayersRank() { }

		public class Description
		{
			public byte pokeID;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result { }
	}
}