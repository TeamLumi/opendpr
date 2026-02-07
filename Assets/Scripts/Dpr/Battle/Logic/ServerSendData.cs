namespace Dpr.Battle.Logic
{
    public static class ServerSendData
    {
        public static unsafe void CLIENT_LIMIT_TIME_Copy(ref CLIENT_LIMIT_TIME dest, in CLIENT_LIMIT_TIME src)
        {
            for (int i = 0; i < (int)BTL_CLIENT_ID.BTL_CLIENT_NUM; i++)
            {
                dest.limitTime[i] = src.limitTime[i];
            }
        }

        public static unsafe void RAIDBOSS_CAPTURE_RESULT_Copy(ref RAIDBOSS_CAPTURE_RESULT dest, in RAIDBOSS_CAPTURE_RESULT src)
        {
            for (int i = 0; i < (int)BTL_CLIENT_ID.BTL_CLIENT_NUM; i++)
            {
                dest.isThrow[i] = src.isThrow[i];
                dest.itemno[i] = src.itemno[i];
                dest.isCaptured[i] = src.isCaptured[i];
                dest.yureCount[i] = src.yureCount[i];
            }
        }

        public struct CLIENT_LIMIT_TIME
        {
            public unsafe fixed ushort limitTime[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        }

        public struct CONFIRM_COUNTER_POKECHANGE
        {
            public byte enemyPutPokeID;
        }

        public struct POKECHANGE_REQUEST
        {
            public byte requestPosNum;
            public unsafe fixed byte requestPos[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        }

        public struct RAIDBOSS_CAPTURE_RESULT
        {
            public unsafe fixed bool isThrow[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
            public unsafe fixed ushort itemno[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
            public unsafe fixed bool isCaptured[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
            public unsafe fixed ushort yureCount[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        }
    }
}