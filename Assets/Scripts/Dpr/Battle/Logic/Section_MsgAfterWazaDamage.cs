namespace Dpr.Battle.Logic
{
	public sealed class Section_MsgAfterWazaDamage : Section
	{
		public Section_MsgAfterWazaDamage(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
		{
			DamageProcParams damageProcParam = description.damageProcParam;
			WazaParam wazaParam = description.wazaParam;
			BTL_POKEPARAM attacker = description.attacker;
			byte targetCount = description.targetCount;

			// Put critical hit message
			putCriticalMessage(
				attacker, wazaParam,
				targetCount,
				damageProcParam.bpp,
				damageProcParam.criticalTypes,
				description.isPluralHitWaza);

			// Check battle talk for first damage done
			checkBattleTalk(attacker.GetID());
		}

		private void putCriticalMessage(BTL_POKEPARAM attacker, WazaParam wazaParam, uint targetNum, BTL_POKEPARAM[] targets, CriticalType[] criticalTypes, bool isPluralHitWaza)
		{
			for (uint i = 0; i < targetNum; i++)
			{
				if (targets[i] == null)
					continue;

				CriticalType critType = criticalTypes[i];
				if (critType == CriticalType.CRITICAL_NONE)
					continue;

				if (critType == CriticalType.CRITICAL_FRIENDSHIP)
				{
					// Friendship critical: show friendship effect + friendship critical message
					GetServerCommandPutter().Message_Std((ushort)BTL_STRID_STD.FR_Critical, attacker.GetID());
				}
				else
				{
					// Normal critical hit message
					GetServerCommandPutter().Message_Std((ushort)BTL_STRID_STD.CriticalHit);
				}

				// Only show one critical message total (even if hitting multiple targets)
				break;
			}
		}

		private void checkBattleTalk(byte pokeID)
		{
			// Trainer first-damage battle talk is handled by the client-side TrainerMessageManager
		}

		public class Description
		{
			public DamageProcParams damageProcParam;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public HITCHECK_PARAM hitCheckParam;
			public byte targetCount;
			public bool isPluralHitWaza;
			
			public Description()
			{
				damageProcParam = null;
				wazaParam = null;
				attacker = null;
				hitCheckParam = null;
				targetCount = 0;
				isPluralHitWaza = false;
			}
		}

		public class Result { }
	}
}