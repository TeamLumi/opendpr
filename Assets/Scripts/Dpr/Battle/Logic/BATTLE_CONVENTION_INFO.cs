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
			CommBattle = 0;
			Egg = 0;
			BattleHouse = 0;
			TrialHouse = 0;
			CaptureNum = 0;
			Evolution = 0;
			Bp = 0;
			Judge = 0;
			Sparing = 0;
			Pointup = 0;
			Dendou = 0;
		}
	}
}