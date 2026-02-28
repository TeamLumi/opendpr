namespace Dpr.Battle.Logic
{
	public sealed class Section_ClearPokeDependEffect : Section
	{
		public Section_ClearPokeDependEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void releaseFreeFall(BTL_POKEPARAM poke) { }
		
		private void removeHandlers(BTL_POKEPARAM poke)
		{
			var uVar1 = poke.GetID();
			this.m_pServerCmdPutter.RemoveTokuseiHandler(uVar1);
			uVar1 = poke.GetID();
			this.m_pServerCmdPutter.RemoveItemHandler(uVar1);
			uVar1 = poke.GetID();
			this.m_pServerCmdPutter.RemoveDefaultPowerUpHandler(uVar1);
			uVar1 = poke.GetID();
			this.m_pServerCmdPutter.RemoveForceAllWazaHandler(uVar1);
		}
		
		// TODO
		private void cureDependPokeSick(BTL_POKEPARAM causePoke) { }
		
		// TODO
		private void removeDependPokeField(BTL_POKEPARAM causePoke) { }
		
		// TODO
		private void onKintyoukanMoved(BTL_POKEPARAM poke) { }

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