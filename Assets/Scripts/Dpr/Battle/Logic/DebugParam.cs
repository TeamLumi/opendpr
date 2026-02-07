namespace Dpr.Battle.Logic
{
	public sealed class DebugParam
	{
		public bool captureMustFail_isEnable;
		public byte captureMustFail_yureCount;
		public int[] yubiWoHuruWaza = new int[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		public int gTurnMax;
		public ClientParam[] clientParam = Arrays.InitializeWithDefaultInstances<ClientParam>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
		private static DebugParam s_uPtrDebugParam;
		
		public static void CreateInstance()
		{
			if (s_uPtrDebugParam == null)
				s_uPtrDebugParam = new DebugParam();
		}

		public static void DeleteInstance()
		{
			s_uPtrDebugParam = null;
		}

		public static DebugParam GetInstance()
		{
			return s_uPtrDebugParam;
		}
		
		public DebugParam()
		{
			captureMustFail_isEnable = false;
			captureMustFail_yureCount = 0;

			for (int i=0; i<yubiWoHuruWaza.Length; i++)
				yubiWoHuruWaza[i] = 0;
		}
		
		public void IncYubiWoHuruWaza(BtlPokePos pos)
		{
			yubiWoHuruWaza[(int)pos]++;
		}

		public struct ClientParam
		{
			public bool forceGOnBattleStart;
			public byte forceGPokePosIdx;
		}
	}
}