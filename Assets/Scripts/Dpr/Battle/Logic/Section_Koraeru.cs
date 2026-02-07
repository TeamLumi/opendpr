namespace Dpr.Battle.Logic
{
	public sealed class Section_Koraeru : Section
	{
		public Section_Koraeru(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = description.poke;
			KoraeruCause cause = description.cause;

			switch (cause)
			{
				case KoraeruCause.WAZA_DEFENDER:
				case KoraeruCause.WAZA_ATTACKER:
					onKoraeru_ByDefender(poke);
					break;
				case KoraeruCause.FRIENDSHIP:
					onKoraeru_ByFriendship(poke);
					break;
				default:
					onKoraeru_ByOthers(poke, cause);
					break;
			}
		}

		private void onKoraeru_ByDefender(BTL_POKEPARAM poke)
		{
			GetEventLauncher().Event_KoraeruExe(poke, KoraeruCause.WAZA_DEFENDER);
		}

		private void onKoraeru_ByFriendship(BTL_POKEPARAM poke)
		{
			GetEventLauncher().Event_KoraeruExe(poke, KoraeruCause.FRIENDSHIP);
		}

		private void onKoraeru_ByOthers(BTL_POKEPARAM poke, KoraeruCause cause)
		{
			GetEventLauncher().Event_KoraeruExe(poke, cause);
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public KoraeruCause cause;
			
			public Description()
			{
				poke = null;
				cause = KoraeruCause.NONE;
			}
		}

		public class Result { }
	}
}