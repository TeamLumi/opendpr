namespace Pml.PokePara
{
	public struct CoreDataBlockA
	{
		public ushort monsno;
		public ushort itemno;
		public uint id;
		public uint exp;
		public ushort tokuseino;
		public ushort _bitsA;
		public ushort boxMark;
		public uint colorRnd;
		public byte seikaku;
		public byte seikakuHosei;
		public byte _bitsB;
		public ushort formNo;
		public byte effortHp;
		public byte effortAtk;
		public byte effortDef;
		public byte effortAgi;
		public byte effortSpatk;
		public byte effortSpdef;
		public byte style;
		public byte beautiful;
		public byte cute;
		public byte clever;
		public byte strong;
		public byte fur;
		public byte pokerus;
		public uint ribbonA;
		public uint ribbonB;
		public byte lumpingRibbonA;
		public byte lumpingRibbonB;
		public uint ribbonC;
		public uint ribbonD;
		public uint _bitsC;
		public uint camp_reserved;
		public byte talentHeight;
		public byte talentWeight;
		public byte _bitsD;
		public unsafe fixed byte padding[5];

		private const int bitsA0_sz = 1;
		private const int bitsA0_loc = 0;
		private const int bitsA1_sz = 1;
		private const int bitsA1_loc = 1;
		private const int bitsA2_sz = 1;
		private const int bitsA2_loc = 2;
		private const int bitsA3_sz = 1;
		private const int bitsA3_loc = 3;
		private const int bitsA4_sz = 1;
		private const int bitsA4_loc = 4;
		private const int bitsA5_sz = 1;
		private const int bitsA5_loc = 5;
		private const int bitsA0_mask = 1;
		private const int bitsA1_mask = 2;
		private const int bitsA2_mask = 4;
		private const int bitsA3_mask = 8;
		private const int bitsA4_mask = 16;
		private const int bitsA5_mask = 32;
		private const int bitsB0_sz = 1;
		private const int bitsB0_loc = 0;
		private const int bitsB1_sz = 1;
		private const int bitsB1_loc = 1;
		private const int bitsB2_sz = 2;
		private const int bitsB2_loc = 2;
		private const int bitsB0_mask = 1;
		private const int bitsB1_mask = 2;
		private const int bitsB2_mask = 12;
		private const int bitsC0_sz = 8;
		private const int bitsC0_loc = 0;
		private const int bitsC0_mask = 255;
		private const int bitsD0_sz = 1;
		private const int bitsD0_loc = 0;
		private const int bitsD0_mask = 1;
		
		public bool tokusei1Flag
		{
			get => ((_bitsA & bitsA0_mask) >> bitsA0_loc) != 0;
			set => _bitsA = (ushort)((_bitsA & ~bitsA0_mask) | (value ? bitsA0_mask : 0));
		}

		public bool tokusei2Flag
		{
			get => ((_bitsA & bitsA1_mask) >> bitsA1_loc) != 0;
			set => _bitsA = (ushort)((_bitsA & ~bitsA1_mask) | (value ? bitsA1_mask : 0));
		}

		public bool tokusei3Flag
		{
			get => ((_bitsA & bitsA2_mask) >> bitsA2_loc) != 0;
			set => _bitsA = (ushort)((_bitsA & ~bitsA2_mask) | (value ? bitsA2_mask : 0));
		}

		public bool favoriteFlag
		{
			get => ((_bitsA & bitsA3_mask) >> bitsA3_loc) != 0;
			set => _bitsA = (ushort)((_bitsA & ~bitsA3_mask) | (value ? bitsA3_mask : 0));
		}

		public bool special_g_flag
		{
			get => ((_bitsA & bitsA4_mask) >> bitsA4_loc) != 0;
			set => _bitsA = (ushort)((_bitsA & ~bitsA4_mask) | (value ? bitsA4_mask : 0));
		}

		public bool debug_edit_flag
		{
			get => ((_bitsA & bitsA5_mask) >> bitsA5_loc) != 0;
			set => _bitsA = (ushort)((_bitsA & ~bitsA5_mask) | (value ? bitsA5_mask : 0));
		}

		public bool eventGetFlag
		{
			get => ((_bitsB & bitsB0_mask) >> bitsB0_loc) != 0;
			set => _bitsB = (byte)((_bitsB & ~bitsB0_mask) | (value ? bitsB0_mask : 0));
		}

		public bool officialBattleEnableFlag
		{
			get => ((_bitsB & bitsB1_mask) >> bitsB1_loc) != 0;
			set => _bitsB = (byte)((_bitsB & ~bitsB1_mask) | (value ? bitsB1_mask : 0));
		}

		public byte sex
		{
			get => (byte)((_bitsB & bitsB2_mask) >> bitsB2_loc);
			set => _bitsB = (byte)((_bitsB & ~bitsB2_mask) | ((value << bitsB2_loc) & bitsB2_mask));
		}

		public uint camp_friendship
		{
			get => (_bitsC & bitsC0_mask) >> bitsC0_loc;
			set => _bitsC = (_bitsC & ~(uint)bitsC0_mask) | ((value << bitsC0_loc) & bitsC0_mask);
		}

		public bool dpr_illegal_flag
		{
			get => ((_bitsD & bitsD0_mask) >> bitsD0_loc) != 0;
			set => _bitsD = (byte)((_bitsD & ~bitsD0_mask) | (value ? bitsD0_mask : 0));
		}
	}
}