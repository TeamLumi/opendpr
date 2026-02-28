using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_ExtraAction : Section
	{
		public Section_RaidBoss_ExtraAction(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool canExtraAttack() { return default; }
		
		private void effectOnExtraAttack()
		{
			var uVar2 = 4.GetPokeParam();
			var uVar1 = uVar2.GetID();
			this.m_pServerCmdPutter.Message_Std(0x17e,uVar1);
			this.m_pServerCmdPutter.EffectByPos(uVar2,0x82);
		}
		
		// TODO
		private void rankUp() { }
		
		// TODO
		private void rankUp(WazaRankEffect effect) { }
		
		// TODO
		private void extraAttack() { }
		
		// TODO
		private void decideWazaParam(WazaParam pWazaParam) { }
		
		// TODO
		private BTL_POKEPARAM decideTarget(in WazaParam wazaParam) { return default; }
		
		// TODO
		private void wazaExec(BTL_POKEPARAM target, WazaParam wazaParam) { }
		
		private void initGWall()
		{
			var uVar2 = 4.GetPokeParam();
			var uVar1 = uVar2.GetID();
			this.m_pServerCmdPutter.InitGWallGauge(uVar1);
		}
		
		// TODO
		private void repairGWall() { }
		
		// TODO
		private BTL_POKEPARAM getBoss() { return default; }

		public class Description { }

		public class Result { }
	}
}