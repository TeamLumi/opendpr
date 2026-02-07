namespace Dpr.Battle.Logic
{
	public sealed class Section_RecoverHP_Core : Section
	{
		public Section_RecoverHP_Core(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			if (description.recoverHP > 0)
			{
				GetServerCommandPutter().SimpleHp(description.poke, (int)description.recoverHP, DamageCause.OTHER, PokeID.INVALID, description.isEffectEnable);
			}
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public ushort recoverHP;
			public bool isEffectEnable;
			
			public Description()
			{
				poke = null;
				recoverHP = 0;
				isEffectEnable = false;
			}
		}

		public class Result { }
	}
}