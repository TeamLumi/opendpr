namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberOutCore : Section
	{
		public Section_MemberOutCore(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void putMemberOut(BTL_POKEPARAM outPoke, ushort effectNo) { }
		
		// TODO
		private void clearPokeDependEffect(BTL_POKEPARAM poke) { }
		
		private void endGMode(BTL_POKEPARAM poke)
		{
			var uVar2 = poke.IsGMode();
			if (uVar2) {
			  var uVar1 = poke.GetID();
			  this.m_pServerCmdPutter.EndGMode(uVar1);
			}
		}

		public class Description
		{
			public BTL_POKEPARAM outPoke;
			public ushort effectNo;
			
			public Description()
			{
				outPoke = null;
				effectNo = 0;
			}
		}

		public class Result
		{
			public bool isOutSuccessed;
		}
	}
}