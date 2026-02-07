namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckItemReaction : Section
	{
		public Section_CheckItemReaction(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description desc)
        {
            BTL_POKEPARAM poke = GetPokeParam(desc.pokeID);
            GetEventLauncher().Event_CheckItemReaction(poke, desc.reactionType);
        }

		public class Description
		{
			public byte pokeID = PokeID.INVALID;
			public byte reactionType;
		}

		public class Result { }
	}
}