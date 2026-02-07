namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_UpdatePosEffectParam : Section
	{
		public Section_FromEvent_UpdatePosEffectParam(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			PosEffectStatus posEffectStatus = GetBattleEnv().GetPosEffectStatus(description.pos, description.effect);
			posEffectStatus.SetEffectParam(description.effectParam);
			ServerCommandPutter.SCQUE_OP_UpdatePosEffectParam(GetServerCommandQueue(), description.effect, description.pos, description.effectParam.Raw_param1);
		}

		public class Description
		{
			public BtlPokePos pos;
			public BtlPosEffect effect;
			public PosEffect.EffectParam effectParam;
			
			public Description()
			{
				pos = BtlPokePos.POS_NULL;
				effect = BtlPosEffect.BTL_POSEFF_NULL;
				effectParam = default;
			}
		}

		public class Result { }
	}
}