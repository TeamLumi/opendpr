namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_TameHideCancel : Section
	{
		public Section_FromEvent_TameHideCancel(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.targetPokeID);
			result.isSucceeded = cancelHide(poke, description.flag, in description.successMessage);
		}

		private bool cancelHide(BTL_POKEPARAM poke, ContFlag flag, in StrParam successMessage)
		{
			if (poke.IsDead())
				return false;

			if (!poke.CONTFLAG_Get(flag))
				return false;

			GetServerCommandPutter().ResetContFlag(poke, flag);

			if (successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in successMessage);
			}

			return true;
		}

		public class Description
		{
			public byte targetPokeID;
			public ContFlag flag;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				targetPokeID = PokeID.INVALID;
				flag = ContFlag.CONTFLG_NULL;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}