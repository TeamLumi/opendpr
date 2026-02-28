namespace Dpr.Battle.Logic
{
	public class BATTLE_TVNAVI_DATA
	{
		public ushort[] frontPoke = new ushort[(int)BtlSide.BTL_SIDE_NUM];
		public ushort lastWaza;
		
		public void Clear()
		{
			if (0 < (int)this.frontPoke.Length) {
			  var uVar4 = 0;
			  var uVar5 = this.frontPoke.Length & 0xffffffff;
			  do {
			    if (uVar5 <= uVar4) {
			    }
			    var lVar1 = uVar4 * 2;
			    uVar4 = uVar4 + 1;
			    this.frontPoke + lVar1[0] = 0;
			    uVar5 = (ulong)this.frontPoke.Length;
			  } while ((long)uVar4 < (int)this.frontPoke.Length);
			}
			this.lastWaza = (ushort)0;
		}
	}
}