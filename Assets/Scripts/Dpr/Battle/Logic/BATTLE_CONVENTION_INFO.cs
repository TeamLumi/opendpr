namespace Dpr.Battle.Logic
{
	public class BATTLE_CONVENTION_INFO
	{
		public uint CommBattle;
		public uint Egg;
		public uint BattleHouse;
		public uint TrialHouse;
		public uint CaptureNum;
		public uint Evolution;
		public uint Bp;
		public uint Judge;
		public uint Sparing;
		public uint Pointup;
		public uint Dendou;
		
		public void Clear()
		{
			this.Dendou = 0;
			this.CommBattle = 0;
			this.Bp = 0;
			this.Sparing = 0;
			this.BattleHouse = 0;
			this.CaptureNum = 0;
		}
	}
}