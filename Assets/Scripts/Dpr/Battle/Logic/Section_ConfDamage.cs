namespace Dpr.Battle.Logic
{
	public sealed class Section_ConfDamage : Section
	{
		public Section_ConfDamage(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM poke = description.attacker;
			pResult.damage = 0;

			// Display confusion self-hit message
			StrParam str = new StrParam();
			str.Setup(BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.KonranExe);
			str.AddArg(poke.GetID());
			GetServerCommandPutter().Message(in str);

			// Calculate confusion damage
			ushort damage = calcDamage(poke);

			// Fix damage (clamp to current HP)
			damage = fixDamage(poke, damage);

			// Check if poke endures the hit
			KoraeruCause koraeCause;
			ushort fixedDamage;
			checkKoraeru(out koraeCause, out fixedDamage, poke, damage);
			if (koraeCause != KoraeruCause.NONE)
			{
				damage = fixedDamage;
			}

			// Apply damage
			GetServerCommandPutter().SimpleHp(poke, -(int)damage, DamageCause.KONRAN, poke.GetID(), true);

			// Handle endure
			if (koraeCause != KoraeruCause.NONE)
			{
				section_Koraeru(poke, koraeCause);
			}

			// Trigger confusion damage reaction event
			GetEventLauncher().Event_ConfDamageReaction(poke, poke);

			pResult.damage = damage;
		}

		private ushort calcDamage(BTL_POKEPARAM poke)
		{
			// Confusion damage formula: ((2*level/5+2) * 40 * Atk/Def) / 50 + 2
			uint level = (uint)poke.GetValue(BTL_POKEPARAM.ValueID.BPP_LEVEL);
			uint attack = (uint)poke.GetValue(BTL_POKEPARAM.ValueID.BPP_ATTACK);
			uint defense = (uint)poke.GetValue(BTL_POKEPARAM.ValueID.BPP_DEFENCE);

			uint damage = ((2 * level / 5 + 2) * 40 * attack / defense) / 50 + 2;

			// Random factor 85-100%
			uint rand = calc.GetRand(16); // 0-15
			damage = damage * (100 - rand) / 100;

			if (damage == 0)
			{
				damage = 1;
			}

			return (ushort)damage;
		}

		private ushort fixDamage(BTL_POKEPARAM poke, ushort damage)
		{
			uint hp = (uint)poke.GetValue(BTL_POKEPARAM.ValueID.BPP_HP);
			if (damage > hp)
			{
				damage = (ushort)hp;
			}
			return damage;
		}

		private void checkKoraeru(out KoraeruCause koraeCause, out ushort fixedDamage, BTL_POKEPARAM poke, ushort damage)
		{
			koraeCause = KoraeruCause.NONE;
			fixedDamage = damage;

			koraeCause = GetEventLauncher().Event_CheckKoraeru(poke, poke, false, ref fixedDamage);
		}

		private void section_Koraeru(BTL_POKEPARAM poke, KoraeruCause cause)
		{
			var desc = new Section_Koraeru.Description();
			desc.poke = poke;
			desc.cause = cause;
			var result = new Section_Koraeru.Result();
			var section = new Section_Koraeru(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;

			public Description()
			{
				attacker = null;
			}
		}

		public class Result
		{
			public ushort damage;
		}
	}
}
