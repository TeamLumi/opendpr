namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_UpdateGWall : Section
	{
		public Section_RaidBoss_UpdateGWall(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			PokeSet damagedPokeSet = description.damagedPokeSet;
			WazaParam wazaParam = description.wazaParam;

			pResult.gWallUpdateResult.isBroken = false;
			pResult.gWallUpdateResult.isBecameMax = false;

			uint count = damagedPokeSet.GetCount();
			for (uint i = 0; i < count; i++)
			{
				BTL_POKEPARAM poke = damagedPokeSet.Get(i);
				if (poke.IsRaidBoss())
				{
					RaidBossParam raidParam = poke.GetRaidBossParam();
					GWall gWall = raidParam.GetGWall();
					if (gWall != null && gWall.IsActive())
					{
						bool isBroken = decGWallGauge(attacker, poke, wazaParam);
						if (isBroken)
						{
							pResult.gWallUpdateResult.isBroken = true;
						}
					}
				}
			}
		}

		private bool decGWallGauge(BTL_POKEPARAM attacker, BTL_POKEPARAM boss, WazaParam wazaParam)
		{
			RaidBossParam raidParam = boss.GetRaidBossParam();
			GWall gWall = raidParam.GetGWall();

			byte subValue = getGWallSubValue(attacker, wazaParam);
			gWall.SubGauge(subValue);

			return gWall.IsGaugeZero();
		}

		private byte getGWallSubValue(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			if (isIchigekiWaza(wazaParam))
			{
				return 2;
			}

			return 1;
		}

		private bool isIchigekiWaza(WazaParam wazaParam)
		{
			return WAZADATA.GetCategory(wazaParam.wazaID) == Pml.WazaData.WazaCategory.ICHIGEKI;
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public PokeSet damagedPokeSet;
			public WazaParam wazaParam;
		}

		public class Result
		{
			public SectionUtil.GWallUpdateResult gWallUpdateResult = new SectionUtil.GWallUpdateResult();
		}
	}
}