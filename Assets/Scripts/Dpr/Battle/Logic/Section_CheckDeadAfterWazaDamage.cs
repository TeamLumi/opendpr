namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckDeadAfterWazaDamage : Section
	{
		public Section_CheckDeadAfterWazaDamage(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			DamageProcParams damageParams = description.damageParams;
			WazaParam wazaParam = description.wazaParam;
			HITCHECK_PARAM hitCheckParam = description.hitCheckParam;
			BTL_POKEPARAM attacker = description.attacker;
			byte hitPokeCount = description.hitPokeCount;

			checkAttackerDead_Before(attacker, wazaParam);

			for (byte i = 0; i < hitPokeCount; i++)
			{
				BTL_POKEPARAM target = damageParams.bpp[i];
				if (target != null)
				{
					checkTargetDead(hitCheckParam, attacker, wazaParam, target);
				}
			}

			checkAttackerDead_After(attacker);
		}

		private void checkTargetDead(HITCHECK_PARAM hitCheckParam, BTL_POKEPARAM attacker, WazaParam wazaParam, BTL_POKEPARAM target)
		{
			if (!target.IsDead())
			{
				return;
			}

			var desc = new Section_CheckPokeDead.Description();
			desc.poke = target;
			desc.isDeadMessageDisplay = hitCheckParam.isDeadMessageDisplay;
			var result = new Section_CheckPokeDead.Result();
			new Section_CheckPokeDead(GetCommonParam()).Execute(result, desc);
		}

		private void checkAttackerDead_Before(BTL_POKEPARAM poke, WazaParam wazaParam)
		{
			if (poke == null || !poke.IsDead())
			{
				return;
			}

			if (WAZADATA.GetDamageRecoverRatio(wazaParam.wazaID) > 0)
			{
				var desc = new Section_CheckPokeDead.Description();
				desc.poke = poke;
				desc.isDeadMessageDisplay = true;
				var result = new Section_CheckPokeDead.Result();
				new Section_CheckPokeDead(GetCommonParam()).Execute(result, desc);
			}
		}

		private void checkAttackerDead_After(BTL_POKEPARAM poke)
		{
			if (poke == null || !poke.IsDead())
			{
				return;
			}

			var desc = new Section_CheckPokeDead.Description();
			desc.poke = poke;
			desc.isDeadMessageDisplay = true;
			var result = new Section_CheckPokeDead.Result();
			new Section_CheckPokeDead(GetCommonParam()).Execute(result, desc);
		}

		public class Description
		{
			public DamageProcParams damageParams;
			public WazaParam wazaParam;
			public HITCHECK_PARAM hitCheckParam;
			public BTL_POKEPARAM attacker;
			public byte hitPokeCount;
			
			public Description()
			{
				damageParams = null;
				wazaParam = null;
				hitCheckParam = null;
				attacker = null;
				hitPokeCount = 0;
			}
		}

		public class Result { }
	}
}