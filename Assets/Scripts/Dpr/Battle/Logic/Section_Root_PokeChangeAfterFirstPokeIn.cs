namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_PokeChangeAfterFirstPokeIn : Section
	{
		public Section_Root_PokeChangeAfterFirstPokeIn(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.interrupt = InterruptCode.NONE;

			PokeActionContainer pokeActionContainer = GetPokemonActionContainer();
			storePokeActions(pokeActionContainer, description.pClientInstructions);
			processInterruptPokeChangeAction(pokeActionContainer);
			firstPokeInEnd();
		}

		private void storePokeActions(PokeActionContainer pokeActionContainer, SVCL_ACTION pClientInstructions)
		{
			var desc = new Section_StoreActions.Description();
			desc.pokeActionContainer = pokeActionContainer;
			desc.clientInstructions = pClientInstructions;

			var result = new Section_StoreActions.Result();
			var section = new Section_StoreActions(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void processInterruptPokeChangeAction(PokeActionContainer pokeActionContainer)
		{
			var desc = new Section_ProcessInterruptPokeChangeAction.Description();
			desc.pokeActionContainer = pokeActionContainer;

			var result = new Section_ProcessInterruptPokeChangeAction.Result();
			var section = new Section_ProcessInterruptPokeChangeAction(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void firstPokeInEnd()
		{
			var desc = new Section_FirstPokeIn_End.Description();
			var result = new Section_FirstPokeIn_End.Result();
			var section = new Section_FirstPokeIn_End(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public SVCL_ACTION pClientInstructions;
		}

		public class Result
		{
			public InterruptCode interrupt;
		}
	}
}
