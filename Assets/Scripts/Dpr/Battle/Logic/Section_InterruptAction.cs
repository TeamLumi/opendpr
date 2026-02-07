namespace Dpr.Battle.Logic
{
	public sealed class Section_InterruptAction : Section
	{
		public Section_InterruptAction(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isInterrupted = false;

			// Get the interrupt action for this pokemon
			PokeAction pokeAction = getInterruptPokeAction(description.interruptPokeID);
			if (pokeAction == null)
			{
				return;
			}

			// Process the interrupt action
			processAction(pokeAction);
			result.isInterrupted = true;
		}

		private PokeAction getInterruptPokeAction(byte interruptPokeID)
		{
			PokeActionContainer actionContainer = GetPokemonActionContainer();
			byte count = actionContainer.GetCount();
			for (byte i = 0; i < count; i++)
			{
				PokeAction action = actionContainer.Get(i);
				if (action.bpp != null && action.bpp.GetID() == interruptPokeID && !action.fDone)
				{
					return action;
				}
			}
			return null;
		}

		private void processAction(PokeAction pokeAction)
		{
			var desc = new Section_ProcessActionCore.Description();
			desc.pokeAction = pokeAction;

			var result = new Section_ProcessActionCore.Result();
			var section = new Section_ProcessActionCore(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public byte interruptPokeID;
			public byte targetPokeID;

			public Description()
			{
				interruptPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
            }
		}

		public class Result
		{
			public bool isInterrupted;
		}
	}
}
