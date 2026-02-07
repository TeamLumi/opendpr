namespace Dpr.Battle.Logic
{
	public sealed class Section_DamageDetermine : Section
	{
		public Section_DamageDetermine(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.pAttacker;
			DamageCalcResult damageRec = description.pDamageRecord;
			WazaParam wazaParam = description.pWazaParam;

			damageDetermineEvent(damageRec, attacker, wazaParam);
			udpateCriticalCount(attacker, damageRec);
			updateTotalDamageRecieved(damageRec);
		}

		private void damageDetermineEvent(DamageCalcResult damageRec, BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			// Damage determine event — triggers handlers after damage values are finalized
			// Individual record events handled by later pipeline stages
		}

		private void udpateCriticalCount(BTL_POKEPARAM pAttacker, DamageCalcResult pDamageRec)
		{
			uint targetCount = pDamageRec.GetTargetCount();
			for (uint i = 0; i < targetCount; i++)
			{
				DamageCalcResult.RECORD rec = pDamageRec.record[i];
				if (rec.isCritical && !rec.isMigawari)
				{
					pAttacker.PERMCOUNTER_Inc(BTL_POKEPARAM.PermCounter.CRITICAL);
				}
			}
		}

		private void updateTotalDamageRecieved(DamageCalcResult pDamageRec)
		{
			uint targetCount = pDamageRec.GetTargetCount();
			for (uint i = 0; i < targetCount; i++)
			{
				DamageCalcResult.RECORD rec = pDamageRec.record[i];
				if (rec.damage > 0 && !rec.isMigawari)
				{
					BTL_POKEPARAM target = GetPokeParam(rec.pokeID);
					target.PERMCOUNTER_Add(BTL_POKEPARAM.PermCounter.TOTAL_DAMAGE_RECIEVED, rec.damage);
				}
			}
		}

		public class Description
		{
			public BTL_POKEPARAM pAttacker;
			public HITCHECK_PARAM pHitCheckParam;
			public DamageCalcResult pDamageRecord;
			public WazaParam pWazaParam;
			
			public Description()
			{
				pAttacker = null;
				pHitCheckParam = null;
				pDamageRecord = null;
				pWazaParam = null;
			}
		}

		public class Result { }
	}
}