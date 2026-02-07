namespace Dpr.Battle.Logic
{
	public sealed class Section_Escape : Section
	{
		public Section_Escape(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isSucceeded = false;

			BTL_POKEPARAM poke = description.poke;

			bool isSuccess = escape(poke);
			pResult.isSucceeded = isSuccess;

			if (!isSuccess)
			{
				onEscapeFailed(poke);
			}
		}

		private bool escape(BTL_POKEPARAM poke)
		{
			// Check force succeed first (Run Away ability, Smoke Ball, etc.)
			var forceDesc = new Section_Escape_CheckForceSucceed.Description();
			forceDesc.poke = poke;
			var forceResult = new Section_Escape_CheckForceSucceed.Result();
			var forceSection = new Section_Escape_CheckForceSucceed(GetCommonParam());
			forceSection.Execute(forceResult, in forceDesc);

			if (forceResult.canEscape)
			{
				return true;
			}

			// Run the core escape logic (forbid check, speed calc, etc.)
			var coreDesc = new Section_Escape_Core.Description();
			coreDesc.escapePoke = poke;
			coreDesc.isForceSuccess = false;
			coreDesc.isSpMessageCheckEnable = true;

			var coreResult = new Section_Escape_Core.Result();
			var coreSection = new Section_Escape_Core(GetCommonParam());
			coreSection.Execute(coreResult, in coreDesc);

			return coreResult.isSucceeded;
		}

		private void onEscapeFailed(BTL_POKEPARAM poke)
		{
			// Show escape failed message
			StrParam str = new StrParam();
			str.Setup(BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.EscapeFail);
			GetServerCommandPutter().Message(in str);
		}

		public class Description
		{
			public BTL_POKEPARAM poke;

			public Description()
			{
				poke = null;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}
