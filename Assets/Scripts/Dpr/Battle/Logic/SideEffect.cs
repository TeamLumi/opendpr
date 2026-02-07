namespace Dpr.Battle.Logic
{
	public static class SideEffect
	{
		private static readonly ELEM[] SIDE_EFFECT_DESC = new ELEM[]
		{
			new ELEM(BtlSideEffect.BTL_SIDEEFF_REFLECTOR, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_HIKARINOKABE, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_AURORAVEIL, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_SINPINOMAMORI, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_SIROIKIRI, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_OIKAZE, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_OMAJINAI, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_MAKIBISI, 3),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_DOKUBISI, 2),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_STEALTHROCK, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_WIDEGUARD, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_FASTGUARD, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_RAINBOW, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_BURNING, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_MOOR, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_NEBANEBANET, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_TATAMIGAESHI, 3),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_TRICKGUARD, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_SPOTLIGHT, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_STEALTHROCK_HAGANE, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_GSHOCK_HONOO, 1),
			new ELEM(BtlSideEffect.BTL_SIDEEFF_GSHOCK_IWA, 1),
		};
		
		public static uint GetMaxAddCount(BtlSideEffect sideEffect)
		{
			for (int i = 0; i < SIDE_EFFECT_DESC.Length; i++)
			{
				if (SIDE_EFFECT_DESC[i].sideEffect == sideEffect)
				{
					return SIDE_EFFECT_DESC[i].maxAddCount;
				}
			}
			return 0;
		}

		private struct ELEM
		{
			public BtlSideEffect sideEffect;
			public uint maxAddCount;
			
			public ELEM(BtlSideEffect sideEffect, uint maxAddCount)
			{
				this.sideEffect = sideEffect;
				this.maxAddCount = maxAddCount;
			}
		}
	}
}