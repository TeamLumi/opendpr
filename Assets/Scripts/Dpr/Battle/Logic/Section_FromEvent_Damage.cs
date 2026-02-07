namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Damage : Section
	{
		public Section_FromEvent_Damage(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;

			BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID);

			if (!isDamageEnable(targetPoke, description.damage, description.damageCause))
			{
				return;
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(description.pokeID);
			}

			if (description.exEffectPlayMode == EffectPlayMode.FORCE ||
				(description.exEffectPlayMode == EffectPlayMode.ENABLE))
			{
				viewEffect(description.exEffectNo, description.exEffectPos_from, description.exEffectPos_to);
			}

			bool doDeadProcess = !description.disableDeadProcess;
			addDamage(targetPoke, description.damage, description.damageCause, description.damageCausePokeID, in description.successMessage, doDeadProcess);

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_Out(description.pokeID);
			}

			result.isSuccessed = true;
		}

		private bool isDamageEnable(BTL_POKEPARAM poke, uint damage, DamageCause damageCause)
		{
			if (poke.IsDead())
			{
				return false;
			}
			if (damage == 0)
			{
				return false;
			}
			return true;
		}

		private void viewEffect(ushort effectNo, BtlPokePos effectPos_from, BtlPokePos effectPos_to)
		{
			if (effectPos_from == BtlPokePos.POS_NULL && effectPos_to == BtlPokePos.POS_NULL)
			{
				GetServerCommandPutter().Act_EffectSimple(effectNo);
			}
			else if (effectPos_to == BtlPokePos.POS_NULL)
			{
				GetServerCommandPutter().EffectByPos(effectPos_from, effectNo);
			}
			else
			{
				GetServerCommandPutter().EffectBySide(effectPos_from, effectPos_to, effectNo);
			}
		}

		private void addDamage(BTL_POKEPARAM poke, uint damage, DamageCause damageCause, byte damageCausePokeID, in StrParam message, bool doDeadProcess)
		{
			GetServerCommandPutter().SimpleHp(poke, -(int)damage, damageCause, damageCausePokeID, true);

			if (message.IsEnable())
			{
				GetServerCommandPutter().Message(in message);
			}

			if (doDeadProcess)
			{
				var deadDesc = new Section_CheckPokeDead.Description();
				deadDesc.poke = poke;
				deadDesc.isDeadMessageDisplay = true;
				var deadResult = new Section_CheckPokeDead.Result();
				var deadSection = new Section_CheckPokeDead(GetCommonParam());
				deadSection.Execute(deadResult, in deadDesc);
			}
		}

		public enum EffectPlayMode : byte
		{
			DISABLE = 0,
			ENABLE = 1,
			FORCE = 2,
		}

		public class Description
		{
			public byte pokeID;
			public byte targetPokeID;
			public ushort damage;
			public DamageCause damageCause;
			public byte damageCausePokeID;
			public bool canHidePokeAvoid;
			public bool disableDeadProcess;
			public bool isDisplayTokuseiWindow;
			public EffectPlayMode exEffectPlayMode;
			public ushort exEffectNo;
			public BtlPokePos exEffectPos_from;
			public BtlPokePos exEffectPos_to;
			public StrParam successMessage = new StrParam();

			public Description()
			{
				pokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				damage = 0;
				damageCause = DamageCause.OTHER;
				damageCausePokeID = PokeID.INVALID;
				canHidePokeAvoid = false;
				disableDeadProcess = false;
				isDisplayTokuseiWindow = false;
				exEffectPlayMode = EffectPlayMode.DISABLE;
				exEffectNo = 0;
				exEffectPos_from = BtlPokePos.POS_NULL;
				exEffectPos_to = BtlPokePos.POS_NULL;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}
