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
			TurnNum = 0;
			HPSum = 0;
			PokeChgNum = 0;
			VoidAtcNum = 0;
			WeakAtcNum = 0;
			ResistAtcNum = 0;
			VoidNum = 0;
			ResistNum = 0;
			WinTrainerNum = 0;
			WinPokeNum = 0;
			LosePokeNum = 0;
			UseWazaNum = 0;
		}
	}
}