using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_PlayWazaEffect : Section
	{
		public Section_FromEvent_PlayWazaEffect(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			GetServerCommandPutter().Act_WazaEffect(description.atkPos, description.defPos, description.waza, description.wazaType, (byte)description.turnType, description.pluralHitIndex, description.isSyncEffect, false);
		}

		public class Description
		{
			public BtlPokePos atkPos;
			public BtlPokePos defPos;
			public WazaNo waza;
			public byte wazaType;
			public BtlvWazaEffect_TurnType turnType;
			public byte pluralHitIndex;
			public bool isSyncEffect;
			
			public Description()
			{
				waza = WazaNo.NULL;
				wazaType = (byte)PokeType.NORMAL;
				atkPos = BtlPokePos.POS_NULL;
				defPos = BtlPokePos.POS_NULL;
				turnType = BtlvWazaEffect_TurnType.BTLV_WAZAEFF_INDEX_DEFAULT;
				pluralHitIndex = 0;
				isSyncEffect = false;
			}
		}

		public class Result { }
	}
}