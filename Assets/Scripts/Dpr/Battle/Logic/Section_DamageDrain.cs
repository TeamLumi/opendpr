namespace Dpr.Battle.Logic
{
	public sealed class Section_DamageDrain : Section
	{
		public Section_DamageDrain(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			if (description.attacker.IsDead())
			{
				return;
			}

			uint recoverHP = calcRecoverVolume(description.wazaParam, description.damage);

			if (recoverHP > 0)
			{
				drain(description.attacker, description.defender, recoverHP);
			}
		}

		private uint calcRecoverVolume(WazaParam wazaParam, uint damage)
		{
			uint ratio = WAZADATA.GetDamageRecoverRatio(wazaParam.wazaID);
			if (ratio == 0)
			{
				return 0;
			}

			uint volume = damage * ratio / 100;
			if (volume == 0)
			{
				volume = 1;
			}

			return volume;
		}

		private bool drain(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, uint damage)
		{
			var desc = new Section_DamageDrain_Core.Description();
			desc.attacker = attacker;
			desc.target = defender;
			desc.drainHP = (ushort)damage;
			desc.skipSpFailCheck = false;

			var result = new Section_DamageDrain_Core.Result();
			var section = new Section_DamageDrain_Core(GetCommonParam());
			section.Execute(result, in desc);

			return result.isHpRecovered;
		}

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM defender;
			public uint damage;

			public Description()
			{
				wazaParam = null;
				attacker = null;
				defender = null;
				damage = 0;
			}
		}

		public class Result { }
	}
}
