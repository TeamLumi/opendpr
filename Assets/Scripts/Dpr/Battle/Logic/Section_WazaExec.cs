using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec : Section
	{
		public Section_WazaExec(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		private void updateWazaExecRecord(BTL_POKEPARAM attacker, WazaNo waza)
		{
			attacker.CheckPlayersPoke(waza);
		}
		
		// TODO
		private TameWazaResult execTameWaza(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet taragets) { return default; }
		
		// TODO
		private void section_CheckWazaInvalid(ref bool pIsWazaValid, DmgAffRec pAffinityRecorder, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, ActionDesc actionDesc, PokeSet pTaragets) { }
		
		// TODO
		private void section_WazaExecCategory(BTL_POKEPARAM pAttacker, ActionDesc actionDesc, WazaParam pWazaParam, DmgAffRec pAffinityRecorder, PokeSet pTaragets, bool isDamageWaza, WazaCategory wazaCategory) { }
		
		// TODO
		private void section_WazaExecedEffect(BTL_POKEPARAM pAttacker, WazaParam pWazaParam, ActionDesc pActionDesc, WazaEffectReservedPos pQueReservePos, bool isWazaValid) { }
		
		// TODO
		private void event_WazaExeDone(byte pokeID, WazaNo waza, ActionDesc actionDesc) { }
		
		// TODO
		private void incWazaUsedCount(BTL_POKEPARAM pAttacker, WazaNo wazano) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM poke) { }

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public ActionDesc pActionDesc;
			public WazaParam pWazaParam;
			public PokeSet pTargets;
		}

		public class Result
		{
			public bool isSuccess;
		}
	}
}