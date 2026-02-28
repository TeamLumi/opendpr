using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_G_Start : Section
	{
		private static readonly resetFormTableElem[] resetFormTable = new resetFormTableElem[] { };
		
		public Section_G_Start(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResulkt, in Description description) { }
		
		// TODO
		private void deleteMigawari(BTL_POKEPARAM poke) { }
		
		// TODO
		private void breakIllusion(byte pokeID) { }
		
		// TODO
		private void resetForm(BTL_POKEPARAM poke) { }
		
		// TODO
		private void checkBattleTalk(byte pokeID) { }
		
		private void registerZukanFlag(BTL_POKEPARAM poke)
		{
			this.m_pMainModule.RegisterZukanSeeFlag(poke);
			var uVar1 = poke.IsSpecialG();
			if ((uVar1) &&
			   (uVar1 = poke.CheckPlayersPoke(), uVar1)) {
			  this.m_pMainModule.RegisterZukanSpGGetFlag(poke);
			}
		}
		
		// TODO
		private void setPokeMemories(BTL_POKEPARAM pGPoke) { }
		
		// TODO
		private void setPokeMemoriesOnPlayersStartG(BTL_POKEPARAM pGPoke) { }
		
		// TODO
		private void setPokeMemoriesOnFaceToG(BTL_POKEPARAM pGPoke) { }

		public class Description
		{
			public byte pokeID;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result { }

		private struct resetFormTableElem
		{
			public MonsNo monsno;
			public ushort formno_before;
			public ushort formno_after;
			
			public resetFormTableElem(MonsNo monsno, ushort formno_before, ushort formno_after)
			{
				this.monsno = monsno;
				this.formno_before = formno_before;
				this.formno_after = formno_after;
			}
		}
	}
}