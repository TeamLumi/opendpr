namespace Dpr.Battle.Logic
{
	public class BATTLE_TVNAVI_DATA
	{
		public ushort[] frontPoke = new ushort[(int)BtlSide.BTL_SIDE_NUM];
		public ushort lastWaza;
		
		public void Clear()
		{
			for (int i = 0; i < frontPoke.Length; i++)
			{
				frontPoke[i] = 0;
			}
			lastWaza = 0;
		}
	}
}