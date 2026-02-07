using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_TameHideCancel : Section
	{
		public Section_TameHideCancel(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM poke = description.poke;
			ContFlag hideContFlag = description.hideContFlag;

			if (poke.IsDead())
			{
				pResult.isCanceled = false;
				return;
			}

			if (!poke.CONTFLAG_Get(hideContFlag))
			{
				pResult.isCanceled = false;
				return;
			}

			// Reset the hide cont flag
			GetServerCommandPutter().ResetContFlag(poke, hideContFlag);

			// Show the pokemon (unhide) if not omitting the cancel action
			if (!description.isOmitCancelAction)
			{
				GetServerCommandPutter().Act_TameWazaHide(poke.GetID(), false);
			}

			// Cure the associated WazaSick (e.g. WAZASICK_FLYING for Fly)
			if (hideContFlag == ContFlag.CONTFLG_SORAWOTOBU)
			{
				cureSick(poke, WazaSick.WAZASICK_FLYING);
			}

			pResult.isCanceled = true;
		}

		private void cureSick(BTL_POKEPARAM poke, WazaSick sick)
		{
			if (poke.CheckSick(sick))
			{
				BTL_SICKCONT oldCont;
				GetServerCommandPutter().CureSick(poke, sick, out oldCont);
			}
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ContFlag hideContFlag;
			public bool isOmitCancelAction;
			
			public Description()
			{
				poke = null;
				hideContFlag = ContFlag.CONTFLG_NULL;
				isOmitCancelAction = false;
			}
		}

		public class Result
		{
			public bool isCanceled;
		}
	}
}