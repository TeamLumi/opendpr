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
			arenaIndex = 0;
			sizennotikaraWazaNo = WazaNo.NULL;
			enableDarkBall = false;
			minomuttiFormNo = 0;
			footEffectID = 0;
			attachJoint = 0;
			isIndoor = false;
			reflectionResolution = 0;
			shadowResolution = 0;
			arenaEffTable = null;
		}

		public void CopyFrom(BgComponentData src)
		{
			arenaIndex = src.arenaIndex;
			sizennotikaraWazaNo = src.sizennotikaraWazaNo;
			enableDarkBall = src.enableDarkBall;
			minomuttiFormNo = src.minomuttiFormNo;
			footEffectID = src.footEffectID;
			attachJoint = src.attachJoint;
			isIndoor = src.isIndoor;
			reflectionResolution = src.reflectionResolution;
			shadowResolution = src.shadowResolution;
			arenaEffTable = src.arenaEffTable;
		}

		public void SetUpBgComponentData(ArenaID id)
		{
			arenaIndex = (int)id;
			arenaEffTable = BattleDataTableManager.GetArenaEff(id);

			var arenaInfo = GameManager.arenaInfo;
			if (arenaInfo != null)
			{
				var arenaData = arenaInfo.GetArenaData(id);
				SetParam(arenaData);
			}
		}

		private void SetParam(ArenaInfo.SheetArenaData field)
		{
			sizennotikaraWazaNo = field.SizennotikaraWazaNo;
			enableDarkBall = field.EnableDarkBall;
			minomuttiFormNo = field.MinomuttiFormNo;
			footEffectID = field.FootEffectID;
			attachJoint = field.AttachJoint;
			isIndoor = field.IsIndoor;
			reflectionResolution = field.ReflectionResolution;
			shadowResolution = field.ShadowResolution;
		}
	}
}