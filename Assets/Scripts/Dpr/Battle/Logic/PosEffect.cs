namespace Dpr.Battle.Logic
{
    public sealed class PosEffect
    {
        public const int POSEFF_PARAM_MAX = 4;
        private static readonly EffectParamType[] ParamTypeTable;

        static PosEffect()
        {
            ParamTypeTable = new EffectParamType[(int)BtlPosEffect.BTL_POSEFF_MAX]
            {
                EffectParamType.PARAM_TYPE_NONE,           // NEGAIGOTO
                EffectParamType.PARAM_TYPE_NONE,           // MIKADUKINOMAI
                EffectParamType.PARAM_TYPE_DELAY_RECOVER,  // IYASINONEGAI
                EffectParamType.PARAM_TYPE_DELAY_ATTACK,   // DELAY_ATTACK
                EffectParamType.PARAM_TYPE_NONE,           // BATONTOUCH
            };
        }

        public static EffectParamType GetEffectParamType(BtlPosEffect posEffect)
        {
            if (posEffect < BtlPosEffect.BTL_POSEFF_MAX)
                return ParamTypeTable[(int)posEffect];

            return EffectParamType.PARAM_TYPE_NONE;
        }

        public PosEffect()
        {
        }

        public enum EffectParamType : int
        {
            PARAM_TYPE_NONE = 0,
            PARAM_TYPE_DELAY_ATTACK = 1,
            PARAM_TYPE_DELAY_RECOVER = 2,
        }

        public struct EffectParam
        {
            private const int sz0 = 16;
            private const int loc0 = 0;
            private const int mask0 = 65535;
            private const int sz1 = 4;
            private const int loc1 = 16;
            private const int mask1 = 983040;
            private const int sz2 = 4;
            private const int loc2 = 20;
            private const int mask2 = 15728640;
            private const int sz3 = 8;
            private const int loc3 = 24;
            private const int mask3 = -16777216;
            private int raw;

            public uint Raw_param1
            {
                get { return (uint)raw; }
                set { raw = (int)value; }
            }

            public ushort DelayAttack_wazaNo
            {
                get { return (ushort)((raw & mask0) >> loc0); }
                set { raw = (raw & ~mask0) | ((value << loc0) & mask0); }
            }

            public byte DelayAttack_execTurnMax
            {
                get { return (byte)((raw & mask1) >> loc1); }
                set { raw = (raw & ~mask1) | ((value << loc1) & mask1); }
            }

            public byte DelayAttack_execTurnCount
            {
                get { return (byte)((raw & mask2) >> loc2); }
                set { raw = (raw & ~mask2) | ((value << loc2) & mask2); }
            }
        }
    }
}
