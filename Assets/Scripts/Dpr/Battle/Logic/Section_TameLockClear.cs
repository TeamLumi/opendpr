using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_TameLockClear : Section
	{
		public Section_TameLockClear(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM poke = description.poke;

			if (poke == null || poke.IsDead())
				return;

			clearTameLock(poke);
			clearHide(poke);
		}

		private void clearTameLock(BTL_POKEPARAM poke)
		{
			if (poke.CONTFLAG_Get(ContFlag.CONTFLG_TAME))
			{
				GetServerCommandPutter().ResetContFlag(poke, ContFlag.CONTFLG_TAME);
			}
		}

		private void cureSick(BTL_POKEPARAM poke, WazaSick sick)
		{
			if (poke.CheckSick(sick))
			{
				BTL_SICKCONT oldCont;
				GetServerCommandPutter().CureSick(poke, sick, out oldCont);
			}
		}

		private void clearHide(BTL_POKEPARAM poke)
		{
			ContFlag hideFlag = poke.CONTFLAG_CheckWazaHide();
			if (hideFlag == ContFlag.CONTFLG_MAX)
				return;

			GetServerCommandPutter().ResetContFlag(poke, hideFlag);
			GetServerCommandPutter().Act_TameWazaHide(poke.GetID(), false);

			if (hideFlag == ContFlag.CONTFLG_SORAWOTOBU)
			{
				cureSick(poke, WazaSick.WAZASICK_FLYING);
			}
		}

		public class Description
		{
			public BTL_POKEPARAM poke;

			public Description()
			{
				poke = null;
			}
		}

		public class Result { }
	}
}
