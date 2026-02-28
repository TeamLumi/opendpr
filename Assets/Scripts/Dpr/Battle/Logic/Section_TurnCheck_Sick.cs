using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnCheck_Sick : Section
	{
		private static DamageCause getDamageCause(WazaSick sick)
		{
			if (sick - 4U < 7) {
			  return 0x2b2a0000002829 >> (((ulong)(sick - 4U) & 7) << 3);
			}
			return (DamageCause)0;
		}
		
		public Section_TurnCheck_Sick(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void storeFrontPokeByAgilityOrder(PokeSet pPokeSet) { }
		
		// TODO
		private void turncheckSick(BTL_POKEPARAM pPoke, WazaSick sick) { }
		
		// TODO
		private void continueSick(BTL_POKEPARAM poke, WazaSick sick) { }
		
		// TODO
		private void sickDamage(BTL_POKEPARAM poke, WazaSick sick) { }
		
		// TODO
		private bool isDamageEnable(BTL_POKEPARAM poke, uint damage, WazaSick sick) { return default; }
		
		// TODO
		private void addDamage(BTL_POKEPARAM poke, uint damage, WazaSick sickID) { }
		
		// TODO
		private void getSickDamageMessage(StrParam strParam, BTL_POKEPARAM poke, WazaSick sick) { }
		
		// TODO
		private int getSickDamageStrID(WazaSick sick) { return default; }
		
		// TODO
		private void putEffect(BTL_POKEPARAM poke, WazaSick sick) { }
		
		// TODO
		private void cont_HorobiNoUta(BTL_POKEPARAM poke) { }
		
		// TODO
		private void putHorobiCounter(BTL_POKEPARAM poke, byte count) { }
		
		// TODO
		private void cont_Yadorigi(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cont_NeWoHaru(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cont_Bind(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cont_AquaRing(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cont_Encore(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cont_Takogatame(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cureSick(BTL_POKEPARAM poke, WazaSick sick, in BTL_SICKCONT oldCont) { }
		
		// TODO
		private void cure_Akubi(BTL_POKEPARAM poke, in BTL_SICKCONT sickCont) { }
		
		// TODO
		private void cure_HorobiNoUta(BTL_POKEPARAM poke, in BTL_SICKCONT sickCont) { }
		
		// TODO
		private void cure_Sasiosae(BTL_POKEPARAM poke) { }
		
		// TODO
		private void cure_KaifukuFuji(BTL_POKEPARAM bpp) { }
		
		// TODO
		private bool checkExpGet() { return default; }

		public class Description { }

		public class Result
		{
			public bool isExpGet;
		}
	}
}