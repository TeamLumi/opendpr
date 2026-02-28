namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamage_Root : Section
	{
		public Section_FightDamage_Root(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		private void event_DamageProcStart(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets)
		{
			this.m_pEventLauncher.Event_DamageProcStart();
		}
		
		// TODO
		private void event_GetHitCheckParam(HITCHECK_PARAM pHitCheckParam, BTL_POKEPARAM attacker, WazaParam wazaParam, bool isDelayAttack) { }
		
		// TODO
		private void damageToRecover(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private uint damage(in Description description, HITCHECK_PARAM pHitCheckParam, PokeSet pDamagedPokeSet, WazaEffectReservedPos pWazaEffectReservedPos, SectionUtil.GWallUpdateResult pGWallUpdateResult) { return default; }
		
		// TODO
		private void damage_Single(ref uint pDamageSum, WazaEffectReservedPos pWazaEffectReservePos, BTL_POKEPARAM pAttacker, ActionDesc pActionDesc, WazaParam pWazaParam, DmgAffRec pDmgAffRec, bool isDelayAttack, PokeSet pTargets, PokeSet pDamagedPokeSet, HITCHECK_PARAM pHitCheckParam, SectionUtil.GWallUpdateResult pGWallUpdateResult) { }
		
		// TODO
		private void damage_Prural(ref uint pDamageSum, WazaEffectReservedPos pWazaEffectReservePos, HITCHECK_PARAM hitCheckParam, PokeSet pDamagedPokeSet, BTL_POKEPARAM pAttacker, ActionDesc actionDesc, WazaParam pWazaParam, DmgAffRec pDmgAffRec, PokeSet pTargets, SectionUtil.GWallUpdateResult pGWallUpdateResult) { }
		
		// TODO
		private void damage_Ichigeki(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets, PokeSet damagedPokeSet, SectionUtil.GWallUpdateResult pGWallUpdateResult) { }
		
		// TODO
		private void kickbackDamage(BTL_POKEPARAM attacker, WazaParam wazaParam, uint wazaDamage) { }
		
		// TODO
		private void damageProcEnd(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets, bool fDelayAttack) { }
		
		// TODO
		private void putWazaEffectOperation(in WazaParam wazaParam, in WazaEffectReservedPos reservedPos) { }
		
		// TODO
		private void breakGWall() { }
		
		// TODO
		private void addRaidBossExtraAction() { }
		
		// TODO
		private void checkBattleTalk(PokeSet damagedPokeSet) { }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public WazaParam pWazaParam;
			public ActionDesc pActionDesc;
			public DmgAffRec pDmgAffRec;
			public PokeSet pTargets;
			public bool isDelayAttack;
			
			public Description()
			{
				pAttacker = null;
				pWazaParam = null;
				pActionDesc = null;
				pDmgAffRec = null;
				pTargets = null;
				isDelayAttack = false;
			}
		}

		public class Result { }
	}
}