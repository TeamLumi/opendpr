using Pml;

namespace Dpr.Battle.Logic
{
	public static class SectionUtil
	{
		// TODO
		public static bool CheckShowdown(MainModule mainModule, BattleEnv battleEnv) { return default; }
		
		// TODO
		private static bool checkShowdown_Raid(MainModule mainModule, BattleEnv battleEnv) { return default; }
		
		// TODO
		private static bool checkAllDeadSideExist(MainModule mainModule, BattleEnv battleEnv) { return default; }
		
		// TODO
		public static bool CheckAllDeadSide(MainModule mainModule, BattleEnv battleEnv, BtlSide checkSide) { return default; }
		
		// TODO
		private static bool checkAllDeadClient(BattleEnv pBattleEnv, BTL_CLIENT_ID clientID) { return default; }
		
		// TODO
		public static bool CheckSkipBattleAfterShowdown(MainModule mainModule) { return default; }
		
		public static bool CheckTurnEnd(InterruptCode interruptCode)
		{
			if ((((int)interruptCode & 0xff) < 6) && ((1 << (int)((int)interruptCode & 0x1f) & 0x31U) != 0)) {
			  return true;
			}
			return ((int)interruptCode & 0xff) == 6;
		}
		
		// TODO
		public static bool CheckPlayersClient(MainModule mainModule, BTL_CLIENT_ID clientID) { return default; }
		
		public static byte GetFriendship(MainModule mainModule, BTL_POKEPARAM poke)
		{
			mainModule.GetPokeFriendship(poke);
			return 0;
		}
		
		public static bool CheckPlayersPoke(MainModule mainModule, BTL_POKEPARAM poke)
		{
			var uVar1 = poke.GetID();
			mainModule.IsPlayersPokeID(uVar1);
			return false;
		}
		
		// TODO
		public static bool CheckPlayersFriendPoke(MainModule mainModule, BTL_POKEPARAM poke) { return default; }
		
		// TODO
		public static bool CheckMustHit(MainModule mainModule, BTL_POKEPARAM attacker, BTL_POKEPARAM target, in PosPoke posPoke) { return default; }
		
		public static bool CheckSkyBattleFailWaza(MainModule mainModule, WazaNo waza)
		{
			var uVar1 = mainModule.IsSkyBattle();
			if (((uVar1 & 1) != 0) &&
			   (uVar1 = WAZADATA.GetFlag(waza,0xe), (uVar1 & 1) != 0)) {
			  return true;
			}
			return false;
		}
		
		// TODO
		public static WazaNo CheckEncoreWazaChange(PokeAction action) { return default; }

		public class GWallUpdateResult
		{
			public bool isBroken;
			public bool isBecameMax;
			
			public void CopyFrom(GWallUpdateResult src)
			{
				isBroken = src.isBroken;
				isBecameMax = src.isBecameMax;
			}
		}
	}
}