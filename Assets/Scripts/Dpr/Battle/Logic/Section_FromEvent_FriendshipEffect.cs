namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FriendshipEffect : Section
	{
		public Section_FromEvent_FriendshipEffect(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            GetServerCommandPutter().Act_FriendshipEffect(description.pokeID, description.effectType);
            GetServerCommandPutter().Message(description.message);
        }

		public class Description
		{
			public byte pokeID;
			public FriendshipEffect effectType;
			public StrParam message = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				effectType = FriendshipEffect.FREFF_HEART;
			}
		}

		public class Result { }
	}
}