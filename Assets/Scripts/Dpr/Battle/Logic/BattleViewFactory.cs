namespace Dpr.Battle.Logic
{
	public static class BattleViewFactory
	{
		public static BattleViewBase CreateViewSystem(BTLV_INIT_PARAM initParam)
		{
			var uVar1 = new Systems_BattleViewSystem(initParam);
			return uVar1;
		}
	}
}