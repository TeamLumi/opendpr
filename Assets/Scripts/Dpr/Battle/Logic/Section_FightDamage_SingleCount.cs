namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamage_SingleCount : Section
	{
		// TODO
		public Section_FightDamage_SingleCount(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private int getDamageRatioByTargetCount(in PokeSet targets) { return default; }
		
		// TODO
		private void calcDamage(DamageCalcResult dmgRec, BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, DmgAffRec affRec, AffCounter affCounter, int damageRatio) { }
		
		private uint damageWithFriend(DamageCalcResult pDamageRec, ActionDesc pActionDesc, WazaParam pWazaParam, BTL_POKEPARAM pAttacker, HITCHECK_PARAM pHitCheckParam, PokeSet pDamagedPokeSet, bool isPluralHitWaza)
		{
			damageSide();
			return 0;
		}
		
		// TODO
		private uint damageSide(DamageCalcResult pDamageRec, ActionDesc pActionDesc, WazaParam pWazaParam, BTL_POKEPARAM pAttacker, HITCHECK_PARAM pHitCheckParam, PokeSet pDamagedPokeSet, bool isPluralHitWaza) { return default; }
		
		// TODO
		private SectionUtil.GWallUpdateResult updateGWallGauge(BTL_POKEPARAM pAttacker, PokeSet pDamagedPokeSet, WazaParam wazaParam) { return default; }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public ActionDesc pActionDesc;
			public WazaParam pWazaParam;
			public DmgAffRec pDmgAffRec;
			public bool isDelayAttack;
			public PokeSet pTargets;
			public PokeSet pDamagedPokeSet;
			public HITCHECK_PARAM pHitCheckParam;
			public WazaEffectReservedPos pWazaEffectReservedPos;
			public AffCounter pAffCounter;
		}

		public class Result
		{
			public uint dmgSum;
			public SectionUtil.GWallUpdateResult gWallUpdateResult = new SectionUtil.GWallUpdateResult();
			
			public Result()
			{
				dmgSum = 0;
			}
		}
	}
}