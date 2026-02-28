namespace Dpr.Battle.Logic
{
    public static class PokemonPosition
    {
        public const byte BTL_POS_NUM = 5;
        public const byte BTL_EXIST_POS_MAX = 6;
        public const byte BTL_POS_DOUBLE_NUM = 4;
        public const byte BTL_POS_RAID_NUM = 5;
        public const byte BTL_POS_RAID_NUM_PLAYERS = 4;
        public const byte BTL_POS_RAID_NUM_BOSS = 1;

        private static readonly BTL_CLIENT_ID[] GetPosCoverClientId_Single_POS_COVER_CLIENT_SINGLE = new BTL_CLIENT_ID[BTL_POS_NUM]
        {
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_NULL,   BTL_CLIENT_ID.BTL_CLIENT_NULL,   BTL_CLIENT_ID.BTL_CLIENT_NULL,
        };
        private static readonly BTL_CLIENT_ID[] GetPosCoverClientId_Double_POS_COVER_CLIENT_DOUBLE = new BTL_CLIENT_ID[BTL_POS_NUM]
        {
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_NULL,
        };
        private static readonly BTL_CLIENT_ID[] GetPosCoverClientId_Double_POS_COVER_CLIENT_DOUBLE_MULTI = new BTL_CLIENT_ID[BTL_POS_NUM]
        {
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER,  BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_PARTNER, BTL_CLIENT_ID.BTL_CLIENT_ENEMY2,
            BTL_CLIENT_ID.BTL_CLIENT_NULL,
        };
        private static readonly BTL_CLIENT_ID[] GetPosCoverClientId_Double_POS_COVER_CLIENT_DOUBLE_AI_TAG = new BTL_CLIENT_ID[BTL_POS_NUM]
        {
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER, BTL_CLIENT_ID.BTL_CLIENT_ENEMY2,
            BTL_CLIENT_ID.BTL_CLIENT_NULL,
        };
        private static readonly BTL_CLIENT_ID[] GetPosCoverClientId_Double_POS_COVER_CLIENT_DOUBLE_PA_A = new BTL_CLIENT_ID[BTL_POS_NUM]
        {
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER,  BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_PARTNER,
            BTL_CLIENT_ID.BTL_CLIENT_NULL,    BTL_CLIENT_ID.BTL_CLIENT_NULL,
        };
        private static readonly BTL_CLIENT_ID[] GetPosCoverClientId_Double_POS_COVER_CLIENT_DOUBLE_PA_A2 = new BTL_CLIENT_ID[BTL_POS_NUM]
        {
            BTL_CLIENT_ID.BTL_CLIENT_PLAYER,  BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_PARTNER, BTL_CLIENT_ID.BTL_CLIENT_ENEMY1,
            BTL_CLIENT_ID.BTL_CLIENT_NULL,
        };
        private static readonly BtlSide[] GetClientSide_Single_SIDE_TABLE = new BtlSide[BTL_POS_NUM]
        {
            BtlSide.BTL_SIDE_1ST,  BtlSide.BTL_SIDE_2ND,
            BtlSide.BTL_SIDE_NULL, BtlSide.BTL_SIDE_NULL, BtlSide.BTL_SIDE_NULL,
        };
        private static readonly BtlSide[] GetClientSide_Double_SIDE_TABLE = new BtlSide[BTL_POS_NUM]
        {
            BtlSide.BTL_SIDE_1ST,  BtlSide.BTL_SIDE_2ND,
            BtlSide.BTL_SIDE_1ST,  BtlSide.BTL_SIDE_2ND,
            BtlSide.BTL_SIDE_NULL,
        };

        // TODO
        public static uint GetClientCoverPosNum(BtlRule rule, BtlMultiMode multiMode, BTL_CLIENT_ID clientId) { return 0; }

        // TODO
        public static BTL_CLIENT_ID GetPosCoverClientId(BtlRule rule, BtlMultiMode multiMode, BtlPokePos pos) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        private static BTL_CLIENT_ID GetPosCoverClientId_Single(BtlPokePos pos) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        private static BTL_CLIENT_ID GetPosCoverClientId_Double(BtlMultiMode multiMode, BtlPokePos pos) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        private static BTL_CLIENT_ID GetPosCoverClientId_Raid(BtlMultiMode multiMode, BtlPokePos pos) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        // TODO
        public static bool IsPokePosExist(BtlRule rule, BtlMultiMode multiMode, BtlPokePos pos) { return false; }

        public static BtlPokePos GetValidPosMax(BtlRule rule)
        {
        	if ((int)rule < 4) {
        	  return 0x1040301 >> (int)(((int)rule & 3) << 3);
        	}
        	return (BtlPokePos)3;
        }

        // TODO
        public static BtlPokePos GetOpponentPokePos(BtlRule rule, BtlMultiMode multiMode, BtlPokePos myBasePos, byte opponentPosIndex) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static byte GetClientNum(BtlRule rule, BtlMultiMode multiMode, BtlSide side) { return 0; }

        // TODO
        public static uint GetFrontPosNum(BtlRule rule, BtlMultiMode multiMode, BtlSide side) { return 0; }

        // TODO
        public static BtlPokePos GetSidePos(BtlRule rule, BtlSide side, byte posIndex) { return BtlPokePos.POS_1ST_0; }

        public static BtlPokePos GetSidePos_Raid(BtlSide side, byte posIndex)
        {
        	var uVar1 = 4;
        	if ((int)side != 1) {
        	  uVar1 = posIndex;
        	}
        	return uVar1;
        }

        // TODO
        public static BtlSide PosToSide(BtlRule rule, BtlMultiMode multiMode, BtlPokePos pos) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public static bool IsPlayerSide(BtlSide playerSide, BtlSide checkSide) { return false; }

        // TODO
        public static BtlSide GetOpponentSide(BtlRule rule, BtlSide side) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public static bool IsSideExist(BtlRule rule, BtlSide side) { return false; }

        // TODO
        public static byte GetSideNum(BtlRule rule) { return 0; }

        // TODO
        public static void ExpandSide(BtlSide[] expandSide, ref byte expandSideNum, BtlRule rule, BtlSide targetSide) { }

        // TODO
        public static void AddSideIfExist(BtlSide[] destArray, ref byte count, BtlRule rule, BtlSide side) { }

        public static bool IsUnitSide(BtlSide side)
        {
        	return (int)side < 2;
        }

        public static bool IsMultiSide(BtlSide side)
        {
        	return side - 3U < 3;
        }

        // TODO
        public static BtlSide GetClientSide(BtlRule rule, BTL_CLIENT_ID clientId) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide GetClientSide_Single(BTL_CLIENT_ID clientId) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide GetClientSide_Double(BTL_CLIENT_ID clientId) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        private static BtlSide GetClientSide_Raid(BTL_CLIENT_ID clientId) { return BtlSide.BTL_SIDE_1ST; }

        // TODO
        public static byte PosToSidePosIndex(BtlRule rule, BtlPokePos pos) { return 0; }

        private static byte PosToSidePosIndex_Raid(BtlPokePos pos)
        {
        	var uVar1 = 0;
        	if (((int)pos & 0xff) != 4) {
        	  uVar1 = pos;
        	}
        	return (byte)(uVar1);
        }

        // TODO
        public static BtlPokePos GetFriendPokePos(BtlRule rule, BtlMultiMode multiMode, BtlPokePos myBasePos, byte sidePosIndex) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public static bool IsFriendPokePos(BtlRule rule, BtlMultiMode multiMode, BtlPokePos pos1, BtlPokePos pos2) { return false; }

        // TODO
        public static BtlPokePos GetFacedPokePos(BtlRule rule, BtlMultiMode multiMode, BtlPokePos pos) { return BtlPokePos.POS_1ST_0; }

        // TODO
        private static BtlPokePos GetFacedPokePos_Double(BtlMultiMode multiMode, BtlPokePos pos) { return BtlPokePos.POS_1ST_0; }
    }
}