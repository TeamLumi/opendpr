namespace Dpr.Battle.Logic
{
	public sealed class RaidBattle
	{
		public const byte MAX_ALLDEAD_COUNT = 4;
		public const byte TURNCOUNT_RELIVE = 2;
		
		public static byte GetReliveTurnCount(MainModule pMainModule)
		{
			return TURNCOUNT_RELIVE;
		}

		public static bool IsLoseByPlayerDead(MainModule pMainModule)
		{
			RaidBattleStatus raidBattleStatus = pMainModule.GetBattleEnvForServer().GetRaidBattleStatus();
			return raidBattleStatus.GetAllDeadCount() >= MAX_ALLDEAD_COUNT;
		}
	}
}