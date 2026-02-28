namespace Dpr.Battle.Logic
{
	public sealed class Section_GetExp : Section
	{
		public Section_GetExp(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void addEffortPower(BTL_PARTY party, in ExpCalculator.CalcExpContainer expContainer) { }
		
		// TODO
		private void addEffortPower(BTL_POKEPARAM bpp, in ExpCalculator.CalcExpWork expWork) { }
		
		// TODO
		private void addExp_ByFaced(ref bool isExpGet, ref bool isExist_OnlyGakusyuSoutiExp, BTL_PARTY pParty, in ExpCalculator.CalcExpContainer expContainer) { }
		
		// TODO
		private void addExp_ByGakusyuSouti(ref bool isExpGet, BTL_PARTY pParty, in ExpCalculator.CalcExpContainer expContainer) { }
		
		private void addExp(BTL_POKEPARAM poke, uint exp)
		{
			var uVar1 = poke.GetID();
			this.m_pServerCmdPutter.Op_AddExp(uVar1,exp);
		}
		
		// TODO
		private bool checkRightsOfGettinExp(out uint exp, out bool isGakusyuSoutiOnly, in BTL_POKEPARAM poke, in ExpCalculator.CalcExpWork expWork)
		{
			exp = default;
			isGakusyuSoutiOnly = default;
			return default;
		}
		
		private void putActCommand_InitParam()
		{
			this.m_pServerCmdPutter.Act_AddExp_InitParam();
		}
		
		// TODO
		private void putActCommand_SetParam(BTL_PARTY pParty, ExpCalculator.CalcExpContainer pExpContainer) { }
		
		private void putActCommand_Execute()
		{
			this.m_pServerCmdPutter.Act_AddExp();
		}

		public class Description
		{
			public BTL_PARTY pParty;
			public ExpCalculator.CalcExpContainer pExpContainer;
			
			public Description()
			{
				pParty = null;
				pExpContainer = null;
			}
		}

		public class Result
		{
			public bool isExpGet;
			
			public Result()
			{
				isExpGet = false;
			}
		}
	}
}