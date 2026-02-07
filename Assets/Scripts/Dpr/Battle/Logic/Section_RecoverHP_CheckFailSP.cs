using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RecoverHP_CheckFailSP : Section
	{
		public Section_RecoverHP_CheckFailSP(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isFailed = false;
			if (description.poke.CheckSick(WazaSick.WAZASICK_KAIHUKUHUUJI))
			{
				if (description.isFailMsgEnable)
				{
					GetServerCommandPutter().Message_Set(description.poke, (ushort)BTL_STRID_SET.KaifukuFujiWarn);
				}
				pResult.isFailed = true;
			}
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public bool isFailMsgEnable;

			public Description()
			{
				poke = null;
				isFailMsgEnable = false;
			}
		}

		public class Result
		{
			public bool isFailed;
		}
	}
}
