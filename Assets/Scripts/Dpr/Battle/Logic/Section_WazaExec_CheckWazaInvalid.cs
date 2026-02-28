using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CheckWazaInvalid : Section
	{
		private static bool isHitMigawari(WazaNo waza)
		{
			var uVar1 = WAZADATA.GetCategory(waza);
			if (uVar1 < 10) {
			  return 0x3d1U >> (int)(uVar1 & 0x1f) & 1;
			}
			return false;
		}
		
		public Section_WazaExec_CheckWazaInvalid(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void removeMovedSelfTarget(PokeSet targets, BTL_POKEPARAM attacker, WazaParam wazaParam) { }
		
		// TODO
		private bool isValidWazaToMovedSelf(WazaParam wazaParam) { return default; }
		
		// TODO
		private void checkAvoidByHide(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam) { }
		
		// TODO
		private void checkTypeAffinity(DmgAffRec affinityRecorder, BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam) { }
		
		// TODO
		private void checkNoEffect_Guard(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, DmgAffRec affinityRecorder, ActionRecorder actionRecorder) { }
		
		// TODO
		private void checkNoEffect_Tokusei(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, DmgAffRec affinityRecorder, ActionRecorder actionRecorder) { }
		
		// TODO
		private void checkNoEffect_TypeAffinity(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, DmgAffRec affinityRecorder, ActionRecorder actionRecorder, bool isTypeAffCheckForce) { }
		
		// TODO
		private void checkNoEffect_Affinity(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, DmgAffRec affinityRecorder) { }
		
		// TODO
		private void checkNoEffect_SimpleSick(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam) { }
		
		// TODO
		private void checkNoEffect_SimpleEffect(ActionDesc actionDesc, BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam) { }
		
		// TODO
		private void checkNoEffect_Avoid(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, ActionRecorder actionRecorder, bool isDelayAttack) { }
		
		// TODO
		private void checkNoEffect_Avoid_Others(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, ActionRecorder actionRecorder, bool isDelayAttack) { }
		
		// TODO
		private void checkNoEffect_Avoid_Ichigeki(WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets) { }
		
		// TODO
		private bool isAllTargetRemoved(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam) { return default; }
		
		// TODO
		private void removeMigawariTarget(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }
		
		// TODO
		private void onNotEffective(BTL_POKEPARAM attacker, WazaParam wazaParam, ActionDesc actionDesc) { }

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public bool isMigawariCheckDisable;
			public bool isTypeAffCheckForce;
			public bool isDelayAttack;
			public ActionRecorder actionRecorder;
			public DmgAffRec affinityRecorder;
			
			public Description()
			{
				actionDesc = null;
				wazaParam = null;
				attacker = null;
				targets = null;
				isMigawariCheckDisable = false;
				isTypeAffCheckForce = false;
				isDelayAttack = false;
				actionRecorder = null;
				affinityRecorder = null;
			}
		}

		public class Result
		{
			public bool isWazaInvalid;
		}
	}
}