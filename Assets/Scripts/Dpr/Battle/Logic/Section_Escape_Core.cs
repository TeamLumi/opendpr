namespace Dpr.Battle.Logic
{
	public sealed class Section_Escape_Core : Section
	{
		public Section_Escape_Core(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isSucceeded = false;

			BTL_POKEPARAM escapePoke = description.escapePoke;

			// If force success, skip all checks
			if (description.isForceSuccess)
			{
				pResult.isSucceeded = true;

				if (description.isSpMessageCheckEnable)
				{
					if (!putSpEscapeMessage(escapePoke))
					{
						putDefaultEscapeMessage(escapePoke);
					}
				}
				else
				{
					putDefaultEscapeMessage(escapePoke);
				}

				BTL_CLIENT_ID clientID = PokeID.PokeIdToClientId(escapePoke.GetID());
				GetServerCommandPutter().AddEscapeInfo(clientID);
				return;
			}

			// Check if escape is forbidden (trapping moves, abilities, etc.)
			if (checkEscapeForbid(escapePoke))
			{
				pResult.isSucceeded = false;
				return;
			}

			// Escape succeeds
			pResult.isSucceeded = true;

			if (description.isSpMessageCheckEnable)
			{
				if (!putSpEscapeMessage(escapePoke))
				{
					putDefaultEscapeMessage(escapePoke);
				}
			}
			else
			{
				putDefaultEscapeMessage(escapePoke);
			}

			BTL_CLIENT_ID escClientID = PokeID.PokeIdToClientId(escapePoke.GetID());
			GetServerCommandPutter().AddEscapeInfo(escClientID);
		}

		private bool checkEscapeForbid(BTL_POKEPARAM escapePoke)
		{
			return GetEventLauncher().Event_CheckNigeruForbid(escapePoke);
		}

		private bool putSpEscapeMessage(BTL_POKEPARAM escapePoke)
		{
			// Check for special escape messages from events (e.g., ability-based escape)
			// Returns true if a special message was displayed
			return false;
		}

		private void putDefaultEscapeMessage(BTL_POKEPARAM escapePoke)
		{
			StrParam str = new StrParam();
			str.Setup(BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.EscapeSuccess);
			GetServerCommandPutter().Message(in str);
		}

		public class Description
		{
			public BTL_POKEPARAM escapePoke;
			public bool isForceSuccess;
			public bool isSpMessageCheckEnable;

			public Description()
			{
				escapePoke = null;
				isForceSuccess = false;
				isSpMessageCheckEnable = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;

			public Result()
			{
				isSucceeded = false;
			}
		}
	}
}
