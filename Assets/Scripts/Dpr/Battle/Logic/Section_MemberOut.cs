namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberOut : Section
	{
		public Section_MemberOut(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM outPoke = description.outPoke;

			if (outPoke == null || !outPoke.IsFightEnable())
			{
				pResult.isOutSuccessed = false;
				return;
			}

			// Fire the member-out-fixed event (notifies handlers before switching)
			if (!description.isInterruptDisable)
			{
				GetEventLauncher().Event_MemberOutFixed(outPoke);
			}

			memberOut(outPoke);

			pResult.isOutSuccessed = true;
		}

		private void memberOut(BTL_POKEPARAM outPoke)
		{
			byte pokeID = outPoke.GetID();
			BtlPokePos pos = GetPokePos(outPoke);

			// Show the member-out message
			GetServerCommandPutter().Message_MemberOut(outPoke);

			// Clear data for going out
			GetServerCommandPutter().ClearForOut(pokeID);

			// Play the member-out visual
			GetServerCommandPutter().Act_MemberOut(pos, (ushort)BtlEff.BTLEFF_MAX);

			outPoke.Clear_ForOut();
		}

		public class Description
		{
			public BTL_POKEPARAM outPoke;
			public bool isInterruptDisable;

			public Description()
			{
				outPoke = null;
				isInterruptDisable = false;
			}
		}

		public class Result
		{
			public bool isOutSuccessed;
		}
	}
}
