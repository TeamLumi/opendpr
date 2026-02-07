using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FightDamage_ToRecover : Section
	{
		public Section_FightDamage_ToRecover(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			WazaParam wazaParam = description.wazaParam;
			PokeSet targets = description.targets;
			WazaNo wazaID = wazaParam.wazaID;

			uint ratio = WAZADATA.GetDamageRecoverRatio(wazaID);
			if (ratio == 0)
			{
				return;
			}

			uint totalDamage = 0;
			uint count = targets.GetCount();
			for (uint i = 0; i < count; i++)
			{
				BTL_POKEPARAM target = targets.Get(i);
				uint damage;
				if (targets.GetDamage(target, out damage))
				{
					totalDamage += damage;
				}
			}

			if (totalDamage == 0)
			{
				return;
			}

			ushort recoverHP = (ushort)(totalDamage * ratio / 100);
			if (recoverHP == 0)
			{
				recoverHP = 1;
			}

			for (uint i = 0; i < count; i++)
			{
				BTL_POKEPARAM target = targets.Get(i);
				recoverHP = GetEventLauncher().Event_RecalcDrainVolume(attacker, target, recoverHP);
			}

			if (attacker.IsDead())
			{
				return;
			}

			GetServerCommandPutter().SimpleHp(attacker, (int)recoverHP, DamageCause.OTHER, PokeID.INVALID, true);
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targets;

			public Description()
			{
				attacker = null;
				wazaParam = null;
				targets = null;
			}
		}

		public class Result { }
	}
}
