using Dpr.Battle.View;
using Pml;
using XLSXContent;

namespace Dpr.Battle.Logic
{
	public class BgComponentData
	{
		public int arenaIndex;
		public WazaNo sizennotikaraWazaNo;
		public bool enableDarkBall;
		public byte minomuttiFormNo;
		public EffectBattleID footEffectID;
		public JointName attachJoint;
		public bool isIndoor;
		public int reflectionResolution;
		public int shadowResolution;
		private BattleSetupEffectLots.SheetArenaEffTable arenaEffTable;
		
		public bool enableReflection { get => reflectionResolution > 0; }
		
		public EffectBattleID[] effectBattleID { get => arenaEffTable.EffectID; }
		
		public void Clear()
		{
			this.arenaEffTable = null;
			this.arenaIndex = 0xa1ffffffff;
			this.enableDarkBall = 0x200;
			this.footEffectID = (EffectBattleID)0xffffffff;
			this.isIndoor = false;
			this.reflectionResolution = 0xffffffffffffffff;
		}
		
		// TODO
		public void CopyFrom(BgComponentData src) { }
		
		// TODO
		public void SetUpBgComponentData(ArenaID id) { }
		
		// TODO
		private void SetParam(ArenaInfo.SheetArenaData field) { }
	}
}