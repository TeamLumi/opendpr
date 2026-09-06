using Pml;

namespace Dpr.Battle.Logic
{
	public static class GMode
	{
		private const byte MAX_GMODE_TURN = 3;
		
		public static uint GetMaxTurn() {
		    return 3;
		}
		
		// TODO
		public static bool IsGPokeExist(MainModule mainModule, BattleEnv battleEnv, BTL_CLIENT_ID targetClientID) { return default; }
		
		// TODO
		public static bool CanStartG(MainModule mainModule, BattleEnv battleEnv, BTL_CLIENT_ID clientID) { return default; }
		
		// TODO
		public static bool NeedGButtonDisplay(MainModule mainModule, BattleEnv battleEnv, BTL_CLIENT_ID clientID) { return default; }
		
		// TODO
		public static bool IsSpecialGExist(MonsNo monsno, ushort formno) { return default; }
	}
}