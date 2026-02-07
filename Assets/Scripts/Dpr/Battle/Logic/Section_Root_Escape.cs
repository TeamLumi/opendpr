namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_Escape : Section
	{
		public Section_Root_Escape(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isSuccessed = false;

			// Attempt escape
			bool isSuccess = escape();
			pResult.isSuccessed = isSuccess;

			// Run turn end processing
			onTurnEnd();
		}

		private bool escape()
		{
			// Get the current action pokemon (the one trying to escape)
			PokeActionContainer actionContainer = GetPokemonActionContainer();
			byte count = actionContainer.GetCount();
			for (byte i = 0; i < count; i++)
			{
				PokeAction action = actionContainer.Get(i);
				if (action.actionCategory == PokeActionCategory.Escape && !action.fDone)
				{
					action.fDone = true;

					BTL_POKEPARAM poke = action.bpp;
					if (poke == null || poke.IsDead())
					{
						continue;
					}

					// Run the escape sub-section
					var desc = new Section_Escape_Sub.Description();
					desc.escapePoke = poke;

					var result = new Section_Escape_Sub.Result();
					var section = new Section_Escape_Sub(GetCommonParam());
					section.Execute(result, in desc);

					if (result.isSucceeded)
					{
						return true;
					}

					// Show escape fail message
					StrParam str = new StrParam();
					str.Setup(BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.EscapeFail);
					GetServerCommandPutter().Message(in str);
					return false;
				}
			}
			return false;
		}

		private void onTurnEnd()
		{
			GetEventLauncher().Event_TurnEnd();
		}

		public class Description { }

		public class Result
		{
			public bool isSuccessed;
		}
	}
}
