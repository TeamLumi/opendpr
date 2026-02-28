namespace Dpr.Battle.Logic
{
	public sealed class Section_FirstPokeIn_End : Section
	{
		public Section_FirstPokeIn_End(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			angryRaidBoss();
			if ((this.m_pMainModule.IsSideExist(0) & 1) != 0) {
			  putGRightsAnnounce();
			}
			if ((this.m_pMainModule.IsSideExist(1) & 1) != 0) {
			  putGRightsAnnounce(1);
			}
			this.m_pServerCmdPutter.SetBattleFlag(0);
			setPokeMemoriesOnFaceToRaidBossG();
		}
		
		// TODO
		private void angryRaidBoss() { }
		
		// TODO
		private void putGRightsAnnounce() { }
		
		// TODO
		private void putGRightsAnnounce(BtlSide side) { }
		
		// TODO
		private void setPokeMemoriesOnFaceToRaidBossG() { }

		public class Description { }

		public class Result { }
	}
}