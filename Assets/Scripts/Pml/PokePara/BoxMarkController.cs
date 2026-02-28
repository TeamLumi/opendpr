namespace Pml.PokePara
{
	public static class BoxMarkController
	{
		private const ushort BOXMARK_UNIT_MASK = 3;
		private const ushort BOXMARK_UNIT_BIT_COUNT = 2;
		
		public static BoxMarkColor GetBoxMarkColor(ushort value, BoxMark mark)
		{
			int shift = (int)mark * BOXMARK_UNIT_BIT_COUNT;
			return (BoxMarkColor)((value >> shift) & BOXMARK_UNIT_MASK);
		}

		public static ushort SetBoxMarkColor(ushort value, BoxMark mark, BoxMarkColor color)
		{
			int shift = (int)mark * BOXMARK_UNIT_BIT_COUNT;
			ushort mask = (ushort)(BOXMARK_UNIT_MASK << shift);
			return (ushort)((value & ~mask) | (((ushort)color & BOXMARK_UNIT_MASK) << shift));
		}
	}
}