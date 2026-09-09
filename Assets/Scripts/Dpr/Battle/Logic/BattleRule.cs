namespace Dpr.Battle.Logic
{
    public static class BattleRule
    {
        // TODO
        public static byte GetClientNum(BtlRule rule, BtlMultiMode multiMode) { return 0; }

        // TODO
        public static byte GetFriendClientNum(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID myClientId) { return 0; }

        // TODO
        public static byte GetEnemyClientNum(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID myClientId) { return 0; }

        // TODO
        public static bool IsClientExist(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID clientId) { return false; }

        // TODO
        public static bool IsClientAi(BtlRule rule, BtlCommMode commMode, BtlMultiMode multiMode, BTL_CLIENT_ID clientId) { return false; }

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

        // TODO
        public static bool IsResultStrictJudge(BtlRule rule, BtlCompetitor competitor) { return false; }

        // TODO
        public static bool IsDummyClientSwitchEnable(BtlRule rule) { return false; }

        public static bool IsSkipBattleAfterShowdown(BtlRule rule) {
            return true;
        }

        // TODO
        public static bool NeedPGLRecord(BtlRule rule) { return false; }
    }
}