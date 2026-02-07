namespace Dpr.Battle.Logic
{
	public sealed class Section_SetSpActPriority : Section
	{
		public Section_SetSpActPriority(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            PokeActionContainer actionContainer = description.actionContainer;
            byte count = actionContainer.GetCount();
            for (byte i = 0; i < count; i++)
            {
                PokeAction action = actionContainer.Get(i);
                BTL_POKEPARAM poke = action.bpp;
                byte priority = GetEventLauncher().Event_CheckSpecialActPriority(poke);
                if (priority > 0)
                {
                    GetServerCommandPutter().SetSpActPriority(poke, priority);
                }
            }
        }

		public class Description
		{
			public PokeActionContainer actionContainer;
			
			public Description()
			{
				actionContainer = null;
			}
		}

		public class Result { }
	}
}