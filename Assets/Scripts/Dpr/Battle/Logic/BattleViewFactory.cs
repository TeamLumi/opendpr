namespace Dpr.Battle.Logic
{
	public static class BattleViewFactory
	{
		public static BattleViewBase CreateViewSystem(BTLV_INIT_PARAM initParam)
		{
			return new BattleViewBase(initParam);
		}
	}
}