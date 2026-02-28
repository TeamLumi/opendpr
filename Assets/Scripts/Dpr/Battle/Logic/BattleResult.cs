using Pml.PokePara;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class BattleResult
    {
        // TODO
        public static void ApplyBattlePartyStateOnly(BATTLE_SETUP_PARAM setupParam, BattleEnv pBattleEnvForServer, BattleEnv pBattleEnvForClient, MainModule mainModule, byte myClientId) { }

        // TODO
        public static void ApplyBattlePartyData(BATTLE_SETUP_PARAM setupParam, BattleEnv pBattleEnvForServer, BattleEnv pBattleEnvForClient, MainModule mainModule, byte myClientId) { }

        // TODO
        private static bool isBossBattle(MainModule pMainModule, BATTLE_SETUP_PARAM pSetupParam) { return false; }

        // TODO
        private static void addFriendshipByBossBattle(PokeParty pParty) { }

        // TODO
        private static bool needRevertItem(MainModule mainModule, BATTLE_SETUP_PARAM pSetupParam) { return false; }

        // TODO
        private static void revertItem(PokeParty pSrcParty, PokeParty pOrgParty) { }

        // TODO
        private static void adjustMaxHP(PokeParty pSrcParty, PokeParty pOrgParty) { }

        // TODO
        private static void resetForm(PokeParty party, PokeParty orgParty) { }

        // TODO
        private static void resetForm(PokemonParam pokeParam, in PokemonParam orgParam) { }

        // TODO
        private static void clearUnknownUBNickName(MainModule mainModule, PokeParty party) { }

        // TODO
        public static void ApplyRecordHeader(BATTLE_SETUP_PARAM setupParam, MainModule mainModule, byte myClientId, BtlResult result) { }

        private unsafe static uint GetRecTurnCount(byte* recordData, uint recordDataSize)
        {
        	if (recordData != 0) {
        	var uVar1 = new rec_Reader();
        	  uVar1.Init(recordData,recordDataSize);
        	  uVar1 = uVar1.GetTurnCount();
        	  return uVar1;
        	}
        	return 0;
        }

        // TODO
        private static BtlRecordResult1 GetRecResult1(BtlResult result) { return BtlRecordResult1.BTL_RECORD_RESULT_1_WIN; }

        private static BtlRecordResult2 GetRecResult2(MainModule mainModule, BtlResult result)
        {
        	var uVar1 = mainModule.CheckGameLimitTimeOver();
        	if (uVar1) {
        	  return (BtlRecordResult2)1;
        	}
        	uVar1 = mainModule.CheckClientLimitTimeOver();
        	if (uVar1) {
        	  return (BtlRecordResult2)1;
        	}
        	if ((int)result == 3) {
        	  return (BtlRecordResult2)2;
        	}
        	return (ulong)((int)result == 4) << 1;
        }
    }
}