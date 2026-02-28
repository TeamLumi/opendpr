namespace Pml.WazaData
{
    public struct SickContParam
    {
        private const int sz0 = 4;
        private const int loc0 = 0;
        private const int mask0 = 15;
        private const int sz1 = 6;
        private const int loc1 = 4;
        private const int mask1 = 1008;
        private const int sz2 = 6;
        private const int loc2 = 10;
        private const int mask2 = 64512;
        public ushort raw;

        public byte type
        {
            get => (byte)((raw & mask0) >> loc0);
            set => raw = (ushort)((raw & ~mask0) | ((value << loc0) & mask0));
        }

        public ushort turnMin
        {
            get => (ushort)((raw & mask1) >> loc1);
            set => raw = (ushort)((raw & ~mask1) | ((value << loc1) & mask1));
        }

        public ushort turnMax
        {
            get => (ushort)((raw & mask2) >> loc2);
            set => raw = (ushort)((raw & ~mask2) | ((value << loc2) & mask2));
        }
    }
}
