namespace Pml.PokePara
{
	public struct CoreDataBlockB
	{
		public unsafe fixed char nickname[PmlConstants.MONS_NAME_BUFFER_SIZE];
		public unsafe fixed ushort waza[PmlConstants.MAX_WAZA_NUM];
		public unsafe fixed byte pp[PmlConstants.MAX_WAZA_NUM];
		public unsafe fixed byte pointupUsedCount[PmlConstants.MAX_WAZA_NUM];
		public unsafe fixed ushort tamagoWaza[PmlConstants.MAX_WAZA_NUM];
		public ushort hp;
		public uint _bitsA;
		public byte effortG;
		public uint sick;
		public uint palma;
        public unsafe fixed byte padding[12];

		private const int bitsA0_sz = 5;
		private const int bitsA0_loc = 0;
		private const int bitsA1_sz = 5;
		private const int bitsA1_loc = 5;
		private const int bitsA2_sz = 5;
		private const int bitsA2_loc = 10;
		private const int bitsA3_sz = 5;
		private const int bitsA3_loc = 15;
		private const int bitsA4_sz = 5;
		private const int bitsA4_loc = 20;
		private const int bitsA5_sz = 5;
		private const int bitsA5_loc = 25;
		private const int bitsA6_sz = 1;
		private const int bitsA6_loc = 30;
		private const int bitsA7_sz = 1;
		private const int bitsA7_loc = 31;
		private const int bitsA0_mask = 31;
		private const int bitsA1_mask = 992;
		private const int bitsA2_mask = 31744;
		private const int bitsA3_mask = 1015808;
		private const int bitsA4_mask = 32505856;
		private const int bitsA5_mask = 1040187392;
		private const int bitsA6_mask = 1073741824;
		private const int bitsA7_mask = -2147483648;
		
		public uint talentHp
		{
			get => (_bitsA & bitsA0_mask) >> bitsA0_loc;
			set => _bitsA = (_bitsA & ~(uint)bitsA0_mask) | ((value << bitsA0_loc) & bitsA0_mask);
		}

		public uint talentAtk
		{
			get => (_bitsA & bitsA1_mask) >> bitsA1_loc;
			set => _bitsA = (_bitsA & ~(uint)bitsA1_mask) | ((value << bitsA1_loc) & bitsA1_mask);
		}

		public uint talentDef
		{
			get => (_bitsA & bitsA2_mask) >> bitsA2_loc;
			set => _bitsA = (_bitsA & ~(uint)bitsA2_mask) | ((value << bitsA2_loc) & bitsA2_mask);
		}

		public uint talentAgi
		{
			get => (_bitsA & bitsA3_mask) >> bitsA3_loc;
			set => _bitsA = (_bitsA & ~(uint)bitsA3_mask) | ((value << bitsA3_loc) & bitsA3_mask);
		}

		public uint talentSpatk
		{
			get => (_bitsA & bitsA4_mask) >> bitsA4_loc;
			set => _bitsA = (_bitsA & ~(uint)bitsA4_mask) | ((value << bitsA4_loc) & bitsA4_mask);
		}

		public uint talentSpdef
		{
			get => (_bitsA & bitsA5_mask) >> bitsA5_loc;
			set => _bitsA = (_bitsA & ~(uint)bitsA5_mask) | ((value << bitsA5_loc) & bitsA5_mask);
		}

		public bool tamagoFlag
		{
			get => ((_bitsA & bitsA6_mask) >> bitsA6_loc) != 0;
			set => _bitsA = (_bitsA & ~(uint)bitsA6_mask) | (uint)(value ? bitsA6_mask : 0);
		}

		public bool nicknameFlag
		{
			get => ((_bitsA & unchecked((uint)bitsA7_mask)) >> bitsA7_loc) != 0;
			set => _bitsA = (_bitsA & ~unchecked((uint)bitsA7_mask)) | unchecked((uint)(value ? bitsA7_mask : 0));
		}
	}
}