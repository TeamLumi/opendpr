namespace Dpr.Battle.Logic
{
    public static class ActPri
    {
        internal const uint MASK_DOMINANT = 234881024;
        internal const uint MASK_OPERATION = 29360128;
        internal const uint MASK_WAZA = 4128768;
        internal const uint MASK_SP = 57344;
        internal const uint MASK_AGILITY = 8191;

        // TODO
        private static uint GetShiftWidthByMask(uint mask) { return 0; }

        private static uint MakeBitFlag(uint value, uint mask)
        {
        	var uVar1 = GetShiftWidthByMask(mask);
        	return value << (int)(uVar1 & 0x1f) & mask;
        }

        private static uint GetMaskedValue(uint value, uint mask)
        {
        	var uVar1 = GetShiftWidthByMask(mask);
        	return (mask & value) >> (int)(uVar1 & 0x1f);
        }

        private static uint SetMaskedValue(uint oldValue, uint mask, uint setValue)
        {
        	var uVar1 = GetShiftWidthByMask(mask);
        	return setValue << (int)(uVar1 & 0x1f) & mask | oldValue & (mask ^ 0xffffffff);
        }

        public static uint Make(DominantPriority dominantPri, OperationPriority operationPri, byte wazaPri, byte spPri, ushort agility)
        {
        	return ((int)dominantPri & 7) << 0x19 | ((int)operationPri & 7) << 0x16 | (wazaPri & 0x3f) << 0x10 |
        	       (spPri & 7) << 0xd | agility & 0x1fff;
        	return 0;
        }

        public static uint ChangeAgility(uint priority, ushort agility)
        {
        	return priority & 0xffffe000 | agility & 0x1fff;
        }

        public static uint ChangeWazaPriority(uint priority, byte wazaPri)
        {
        	return priority & 0xffc00000 | priority & 0xffff | (wazaPri & 0x3f) << 0x10;
        }

        public static byte GetWazaPri(uint priority)
        {
        	return (byte)(priority >> 0x10 & 0x3f);
        }

        public static byte GetSpPri(uint priority)
        {
        	return (byte)(priority >> 0xd & 7);
        }

        public static OperationPriority GetOperationPri(uint priority)
        {
        	return priority >> 0x16 & 7;
        }

        public static DominantPriority GetDominantPri(uint priority)
        {
        	return priority >> 0x19 & 7;
        }

        public static uint SetDominantPri(uint priority, DominantPriority dominantPri)
        {
        	return priority & 0xf0000000 | priority & 0x1ffffff | ((int)dominantPri & 7) << 0x19;
        }

        public static uint SetSpPri(uint priority, byte spPri)
        {
        	return priority & 0xffff0000 | priority & 0x1fff | (spPri & 7) << 0xd;
        }

        public static uint ToHandlerPri(uint priority)
        {
        	return priority & 0x3fffff;
        }

        public static int ToWazaOrgPri(uint priority)
        {
        	return (priority >> 0x10 & 0x3f) - 7;
        }
    }
}