namespace Dpr.Battle.Logic
{
    public static class BattleRule
    {
        public static byte GetClientNum(BtlRule rule, BtlMultiMode multiMode)
        {
        	var uVar6 = (int)multiMode & 0xffffffff;
        	var uVar7 = (int)rule & 0xffffffff;
        	var uVar1 = IsClientExist(rule,multiMode);
        	var uVar2 = IsClientExist(uVar7,uVar6,1);
        	var uVar3 = IsClientExist(uVar7,uVar6,2);
        	var uVar4 = IsClientExist(uVar7,uVar6,3);
        	var uVar5 = IsClientExist(uVar7,uVar6,4);
        	return (byte)((uVar1 & 1) + (uVar2 & 1) + (uVar3 & 1) + (uVar4 & 1) + (uVar5 & 1));
        }

        // TODO
        public static byte GetFriendClientNum(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID myClientId) { return 0; }

        // TODO
        public static byte GetEnemyClientNum(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID myClientId) { return 0; }

        // TODO
        public static bool IsClientExist(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID clientId) { return false; }

        public static bool IsClientAi(BtlRule rule, BtlCommMode commMode, BtlMultiMode multiMode, BTL_CLIENT_ID clientId)
        {
        	switch(rule) {
        	case 0:
        	case 3:
        	  var uVar1 = IsClientAi_Single(commMode,clientId);
        	  return uVar1;
        	case 1:
        	  uVar1 = IsClientAi_Double(commMode,multiMode,clientId);
        	  return uVar1;
        	case 2:
        	  uVar1 = IsClientAi_Raid(commMode,multiMode,clientId);
        	  return uVar1;
        	default:
        	  return false;
        	}
        }

        // TODO
        public static bool IsClientAi_Single(BtlCommMode commMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi_Double(BtlCommMode commMode, BtlMultiMode multiMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi_Double_MultiMode_NONE(BtlCommMode commMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi_Double_MultiMode_PP_AA(BtlCommMode commMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi_Double_MultiMode_PA_AA(BtlCommMode commMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi_Double_MultiMode_P_AA(BtlCommMode commMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi_Double_MultiMode_PA_A(BtlCommMode commMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi_Raid(BtlCommMode commMode, BtlMultiMode multiMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsFriendClient(BtlRule rule, BTL_CLIENT_ID clientId_0, BTL_CLIENT_ID clientId_1) { return false; }

        // TODO
        public static bool IsOpponentClient(BtlRule rule, BTL_CLIENT_ID clientId_0, BTL_CLIENT_ID clientId_1) { return false; }

        // TODO
        public static BTL_CLIENT_ID GetFriendClientId(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID myClientID, byte opponentIndex) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        public static BTL_CLIENT_ID GetOpponentClientId(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID myClientID, byte opponentIndex) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        public static bool IsResultStrictJudge(BtlRule rule, BtlCompetitor competitor)
        {
        	return ((int)competitor | 1) == 3;
        }

        public static bool IsDummyClientSwitchEnable(BtlRule rule)
        {
        	return (int)rule == 2;
        }

        public static bool IsSkipBattleAfterShowdown(BtlRule rule)
        {
        	return true;
        }

        public static bool NeedPGLRecord(BtlRule rule)
        {
        	return (int)rule < 2;
        }
    }
}