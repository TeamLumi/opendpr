namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_ShiftHP : Section
	{
		public Section_FromEvent_ShiftHP(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;

			BTL_POKEPARAM userPoke = GetPokeParam(description.pokeID);
			if (userPoke.IsDead())
				return;

			for (byte i = 0; i < description.targetPokeCount; i++)
			{
				BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID[i]);
				if (targetPoke.IsDead())
					continue;

				int volume = description.volume[i];
				if (volume == 0)
					continue;

				GetServerCommandPutter().SimpleHp(targetPoke, volume, description.damageCause, description.pokeID, !description.isEffectDisable);
				result.isSuccessed = true;

				if (!description.isItemReactionDisable)
				{
					checkItemReaction(targetPoke);
				}
			}
		}

		private void checkItemReaction(BTL_POKEPARAM poke)
		{
			GetEventLauncher().Event_CheckItemReaction(poke, 0);
		}

		public class Description
		{
			public byte pokeID;
			public bool isEffectDisable;
			public bool isItemReactionDisable;
			public byte targetPokeCount;
			public byte[] targetPokeID = new byte[DefineConstants.BTL_POSIDX_MAX];
			public int[] volume = new int[DefineConstants.BTL_POSIDX_MAX];
			public DamageCause damageCause;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				isEffectDisable = false;
				isItemReactionDisable = false;
				targetPokeCount = 0;
				damageCause = DamageCause.OTHER;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}