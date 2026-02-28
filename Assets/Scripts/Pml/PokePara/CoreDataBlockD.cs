namespace Pml.PokePara
{
	public struct CoreDataBlockD
	{
		public const int WAZA_RECORD_FLAG_LEN = 14;
		public const int BANK_UNIQUE_ID_LEN = 8;

        public unsafe fixed char parentsName[PmlConstants.PERSON_NAME_BUFFER_SIZE];
		public byte friendship;
		public byte memories_level;
		public byte memories_code;
		public ushort memories_data;
		public byte memories_feel;
		public byte eggGetYear;
		public byte eggGetMonth;
		public byte eggGetDay;
		public byte firstContactYear;
		public byte firstContactMonth;
		public byte firstContactDay;
		public ushort getPlace;
		public ushort birthPlace;
		public byte getBall;
		public byte _bitsA;
		public byte trainingFlag;
        public unsafe fixed byte wazaRecordFlag[WAZA_RECORD_FLAG_LEN];
        public unsafe fixed byte bankUniqueID[BANK_UNIQUE_ID_LEN];
        public unsafe fixed byte padding[11];

		private const int bitsA0_sz = 7;
		private const int bitsA0_loc = 0;
		private const int bitsA1_sz = 1;
		private const int bitsA1_loc = 7;
		private const int bitsA0_mask = 127;
		private const int bitsA1_mask = 128;
		
		public byte getLevel
		{
			get => (byte)((_bitsA & bitsA0_mask) >> bitsA0_loc);
			set => _bitsA = (byte)((_bitsA & ~bitsA0_mask) | ((value << bitsA0_loc) & bitsA0_mask));
		}

		public byte parentsSex
		{
			get => (byte)((_bitsA & bitsA1_mask) >> bitsA1_loc);
			set => _bitsA = (byte)((_bitsA & ~bitsA1_mask) | ((value << bitsA1_loc) & bitsA1_mask));
		}
	}
}