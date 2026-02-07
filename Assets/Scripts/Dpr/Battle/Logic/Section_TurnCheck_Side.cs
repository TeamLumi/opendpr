namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnCheck_Side : Section
	{
		public Section_TurnCheck_Side(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			ServerCommandPutter scp = GetServerCommandPutter();
			SideEffectManager sideMgr = GetBattleEnv().GetSideEffectManager();
			for (int side = (int)BtlSide.BTL_SIDE_MIN; side <= (int)BtlSide.BTL_SIDE_MAX; side++)
			{
				for (int eff = (int)BtlSideEffect.BTL_SIDEEFF_START; eff < (int)BtlSideEffect.BTL_SIDEEFF_MAX; eff++)
				{
					SideEffectStatus status = sideMgr.GetSideEffectStatusConst((BtlSide)side, (BtlSideEffect)eff);
					if (status != null && status.IsEffective())
					{
						scp.SideEffect_IncTurnCount((BtlSide)side, (BtlSideEffect)eff);
					}
				}
			}
		}

		public class Description { }

		public class Result { }
	}
}