namespace Dpr.Battle.Logic
{
    public static class ServerSendData
    {
        // TODO
        public static void CLIENT_LIMIT_TIME_Copy(ref CLIENT_LIMIT_TIME dest, in CLIENT_LIMIT_TIME src) { }

        public static void RAIDBOSS_CAPTURE_RESULT_Copy(ref RAIDBOSS_CAPTURE_RESULT dest, in RAIDBOSS_CAPTURE_RESULT src)
        {
        	var uVar1 = src;
        	var uVar2 = src[1];
        	var uVar3 = src[3];
        	dest[2] = src[2];
        	dest[3] = uVar3;
        	dest = uVar1;
        	dest[1] = uVar2;
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