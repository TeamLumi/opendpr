namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_Angry : Section
	{
		public Section_RaidBoss_Angry(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool checkAngry(BTL_POKEPARAM boss) { return default; }
		
		// TODO
		private bool checkWazaActionEnable(BTL_POKEPARAM boss) { return default; }
		
		// TODO
		private void addWazaAction() { }
		
		private void appearGWall(BTL_POKEPARAM boss)
		{
			var uVar1 = boss.GetID();
			this.m_pServerCmdPutter.RepairGWall(uVar1);
			uVar1 = boss.GetID();
			this.m_pServerCmdPutter.Act_RaidBoss_GWallAppear(uVar1);
		}

		public class Description
		{
			public bool canPutMessage;
			public bool canInsertWazaAction;
			
			public Description()
			{
				canPutMessage = true;
				canInsertWazaAction = true;
			}
		}

		public class Result { }
	}
}