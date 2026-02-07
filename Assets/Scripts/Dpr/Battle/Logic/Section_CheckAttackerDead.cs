namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckAttackerDead : Section
	{
		public Section_CheckAttackerDead(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;

			if (attacker != null && attacker.IsFightEnable())
			{
				checkPokeDead(attacker);
			}
		}

		private void checkPokeDead(BTL_POKEPARAM poke)
		{
			if (poke.IsDead())
			{
				var desc = new Section_CheckPokeDead.Description();
				desc.poke = poke;
				desc.isDeadMessageDisplay = true;
				desc.pPglParam = null;
				var deadResult = new Section_CheckPokeDead.Result();
				new Section_CheckPokeDead(GetCommonParam()).Execute(deadResult, desc);
			}
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
			}
		}

		public class Result { }
	}
}