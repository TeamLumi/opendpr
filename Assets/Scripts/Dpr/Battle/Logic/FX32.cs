namespace Dpr.Battle.Logic
{
	public static class FX32
	{
		private const int INT_SIZE = 19;
		private const int DEC_SIZE = 12;

		public const int SHIFT = 12;
		public const int DEC_MASK = 4095;
		public const int CONST_0_0 = 0;
		public const int CONST_0_013 = 53;
		public const int CONST_0_017 = 70;
		public const int CONST_0_01 = 41;
		public const int CONST_0_027 = 111;
		public const int CONST_0_032 = 131;
		public const int CONST_0_035 = 143;
		public const int CONST_0_043 = 176;
		public const int CONST_0_053 = 217;
		public const int CONST_0_071 = 291;
		public const int CONST_0_1 = 410;
		public const int CONST_0_128 = 524;
		public const int CONST_0_25 = 1024;
		public const int CONST_0_3 = 1229;
		public const int CONST_0_5 = 2048;
		public const int CONST_0_667 = 2732;
		public const int CONST_0_75 = 3072;
		public const int CONST_0_7 = 2867;
		public const int CONST_0_8 = 3277;
		public const int CONST_0_9 = 3686;
		public const int CONST_1_0 = 4096;
		public const int CONST_1_063 = 4354;
		public const int CONST_1_1 = 4506;
		public const int CONST_1_2 = 4915;
		public const int CONST_1_25 = 5120;
		public const int CONST_1_3 = 5325;
		public const int CONST_1_33 = 5448;
		public const int CONST_1_5 = 6144;
		public const int CONST_1_67 = 6840;
		public const int CONST_1_7 = 6963;
		public const int CONST_2_0 = 8192;
		public const int CONST_2_5 = 10240;
		public const int CONST_255_0 = 1044480;
		public const int CONST_3_0 = 12288;
		public const int CONST_3_5 = 14336;
		public const int CONST_4_0 = 16384;
		public const int CONST_5_0 = 20480;
		public const int CONST_8_0 = 32768;
		public const int CONST_10_0 = 40960;
		public const int CONST_32_0 = 131072;
		public const int CONST_32_5 = 133120;
		public const int CONST_50_0 = 204800;
		public const int CONST_55_0 = 225280;
		public const int CONST_66_67 = 273080;
		public const int CONST_75_0 = 307200;
		public const int CONST_77_5 = 317440;
		public const int CONST_100_0 = 409600;
		public const int CONST_512_0 = 2097152;
		public const int CONST_65536_0 = 268435456;
		
		// TODO
		public static int CONST(double x) { return default; }
		
		// TODO
		public static int CONST(float x) { return default; }
		
		// TODO
		public static double ToFloat(int val) { return default; }
		
		public static int Mul(int v1, int v2)
		{
			return (long)v2 * (long)v1 + 0x800U >> 0xc;
		}
		
		public static int Whole(int v)
		{
			return v >> 0xc;
		}
		
		public static int Div(int numer, int denom)
		{
			var dVar1 = 0.0;
			if ((denom & 0xfff) != 0) {
			  dVar1 = (double)(denom & 0xfff) * 0.000244140625;
			}
			dVar1 = dVar1 + (double)((int)denom >> 0xc);
			if (dVar1 != 0.0) {
			  var dVar2 = 0.0;
			  if ((numer & 0xfff) != 0) {
			    dVar2 = (double)(numer & 0xfff) * 0.000244140625;
			  }
			  dVar1 = (dVar2 + (double)((int)numer >> 0xc)) / dVar1;
			  dVar2 = 0.5;
			  if (dVar1 <= 0.0) {
			    dVar2 = -0.5;
			  }
			  return (int)(dVar1 * 4096.0 + dVar2);
			}
			return 0;
		}
		
		// TODO
		public static int Sqrt(int val) { return default; }
		
		// TODO
		public static int POW(int val1, int val2) { return default; }
	}
}