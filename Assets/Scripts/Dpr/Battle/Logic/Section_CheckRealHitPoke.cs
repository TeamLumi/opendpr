namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckRealHitPoke : Section
	{
		public Section_CheckRealHitPoke(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.realHitPokeCount = 0;

			uint count = storeDamageRecords(description.damageProcParams, description.damageRecord);
			pResult.realHitPokeCount = (byte)count;
		}

		private uint storeDamageRecords(DamageProcParams damageProcParams, DamageCalcResult rec)
		{
			uint targetCount = rec.GetTargetCount();
			uint realHitCount = 0;

			for (uint i = 0; i < targetCount; i++)
			{
				storeDamageRecord(damageProcParams, realHitCount, rec, i);

				if (!rec.record[i].isMigawari)
				{
					realHitCount++;
				}
			}

			return realHitCount;
		}

		private void storeDamageRecord(DamageProcParams param, uint paramIdx, DamageCalcResult rec, uint recIdx)
		{
			DamageCalcResult.RECORD record = rec.record[recIdx];

			if (!record.isMigawari)
			{
				param.bpp[paramIdx] = GetPokeParam(record.pokeID);
				param.dmg[paramIdx] = record.damage;
				param.affAry[paramIdx] = record.affinity;
				param.criticalTypes[paramIdx] = record.isCritical
					? (record.isCriticalByFriendship ? CriticalType.CRITICAL_FRIENDSHIP : CriticalType.CRITICAL_NORMAL)
					: CriticalType.CRITICAL_NONE;
				param.koraeru_cause[paramIdx] = record.koraeruCause;
			}
		}

		public class Description
		{
			public DamageCalcResult damageRecord;
			public DamageProcParams damageProcParams;

			public Description()
			{
				damageRecord = null;
				damageProcParams = null;
			}
		}

		public class Result
		{
			public byte realHitPokeCount;
		}
	}
}
