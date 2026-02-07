namespace Dpr.Battle.Logic
{
	public sealed class Section_SimpleDamage : Section
	{
		public Section_SimpleDamage(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isDamaged = false;

			BTL_POKEPARAM poke = description.poke;
			if (poke.IsDead())
			{
				return;
			}

			// Check if simple damage is enabled (event check)
			var checkDesc = new Section_SimpleDamage_CheckEnable.Description();
			checkDesc.poke = poke;
			checkDesc.damage = description.damage;
			checkDesc.damageCause = description.damageCause;
			var checkResult = new Section_SimpleDamage_CheckEnable.Result();
			var checkSection = new Section_SimpleDamage_CheckEnable(GetCommonParam());
			checkSection.Execute(checkResult, in checkDesc);

			if (!checkResult.isEnable)
			{
				return;
			}

			// Display message if provided
			if (description.message != null && description.message.IsEnable())
			{
				GetServerCommandPutter().Message(in description.message);
			}

			// Apply damage
			putSimpleHp(poke, description.damage, description.damageCause, description.damageCausePokeID);
			pResult.isDamaged = true;

			// Check item reaction
			checkItemReaction(poke);

			// Check if pokemon died from the damage
			if (description.doDeadProcess)
			{
				checkPokeDead(poke);
			}
		}

		private void putSimpleHp(BTL_POKEPARAM bpp, uint damage, DamageCause damageCause, byte damageCausePokeID)
		{
			// Clamp damage to current HP
			uint hp = (uint)bpp.GetValue(BTL_POKEPARAM.ValueID.BPP_HP);
			if (damage > hp)
			{
				damage = hp;
			}

			GetServerCommandPutter().SimpleHp(bpp, -(int)damage, damageCause, damageCausePokeID, true);
		}

		private void checkItemReaction(BTL_POKEPARAM poke)
		{
			if (!poke.IsFightEnable())
			{
				return;
			}

			var desc = new Section_CheckItemReaction.Description();
			desc.pokeID = poke.GetID();
			var result = new Section_CheckItemReaction.Result();
			var section = new Section_CheckItemReaction(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void checkPokeDead(BTL_POKEPARAM poke)
		{
			if (!poke.IsDead())
			{
				return;
			}

			var desc = new Section_CheckPokeDead.Description();
			desc.poke = poke;
			desc.isDeadMessageDisplay = true;
			var result = new Section_CheckPokeDead.Result();
			var section = new Section_CheckPokeDead(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public uint damage;
			public DamageCause damageCause;
			public byte damageCausePokeID;
			public StrParam message;
			public bool doDeadProcess;

			public Description()
			{
				poke = null;
				message = null;
				damage = 0;
				damageCause = DamageCause.OTHER;
				damageCausePokeID = PokeID.INVALID;
				doDeadProcess = false;
			}
		}

		public class Result
		{
			public bool isDamaged;
		}
	}
}
