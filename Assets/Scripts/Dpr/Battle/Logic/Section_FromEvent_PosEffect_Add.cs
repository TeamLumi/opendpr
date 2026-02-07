namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_PosEffect_Add : Section
	{
		public Section_FromEvent_PosEffect_Add(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isAdded = false;

			int[] factorParam = new int[6];
			byte factorParamNum = 0;
			getEventFactorParam(factorParam, ref factorParamNum, description.userPokeID, description.pos, description.effect, in description.effectParam, description.isSkipHpRecoverSpFailCheck);

			result.isAdded = GetServerCommandPutter().PosEffect_Add(description.pos, description.effect, in description.effectParam);
		}

		private void getEventFactorParam(int[] factorParam, ref byte factorParamNum, byte userPokeID, BtlPokePos pos, BtlPosEffect effect, in PosEffect.EffectParam effectParam, bool isSkipHpRecoverSpFailCheck)
		{
			factorParamNum = 0;
			factorParam[factorParamNum++] = userPokeID;
			factorParam[factorParamNum++] = (int)pos;
			factorParam[factorParamNum++] = (int)effect;
		}

		public class Description
		{
			public byte userPokeID;
			public BtlPokePos pos;
			public BtlPosEffect effect;
			public PosEffect.EffectParam effectParam;
			public bool isSkipHpRecoverSpFailCheck;
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				pos = BtlPokePos.POS_NULL;
				effect = BtlPosEffect.BTL_POSEFF_NULL;
				effectParam = default;
				isSkipHpRecoverSpFailCheck = false;
			}
		}

		public class Result
		{
			public bool isAdded;
		}
	}
}