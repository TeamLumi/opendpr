namespace Dpr.Battle.Logic
{
	public class BATTLE_KENTEI_RESULT
	{
		public uint TurnNum;
		public ushort HPSum;
		public ushort PokeChgNum;
		public ushort VoidAtcNum;
		public ushort WeakAtcNum;
		public ushort ResistAtcNum;
		public ushort VoidNum;
		public ushort ResistNum;
		public ushort WinTrainerNum;
		public ushort WinPokeNum;
		public ushort LosePokeNum;
		public ushort UseWazaNum;
		
		public void Clear()
		{
			this.UseWazaNum = (ushort)0;
			this.TurnNum = 0;
			this.VoidAtcNum = (ushort)0;
			this.ResistNum = (ushort)0;
		}
	}
}