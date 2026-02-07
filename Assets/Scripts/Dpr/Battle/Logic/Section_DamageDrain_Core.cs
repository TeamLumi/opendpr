namespace Dpr.Battle.Logic
{
	public sealed class Section_DamageDrain_Core : Section
	{
		public Section_DamageDrain_Core(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isHpRecovered = false;

			ushort drainHP = recalcDrainVolume(description.attacker, description.target, description.drainHP);

			if (drainHP > 0)
			{
				pResult.isHpRecovered = recoverHP(description.attacker, drainHP, description.skipSpFailCheck);
			}
		}

		private ushort recalcDrainVolume(BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort drainHP)
		{
			return GetEventLauncher().Event_RecalcDrainVolume(attacker, target, drainHP);
		}

		private bool recoverHP(BTL_POKEPARAM poke, ushort drainHP, bool skipSpFailCheck)
		{
			var desc = new Section_RecoverHP.Description();
			desc.userPokeID = poke.GetID();
			desc.targetPokeID = poke.GetID();
			desc.recoverHP = drainHP;
			desc.isDisplayRecoverEffect = true;
			desc.isDisplayFailMessage_HPFull = false;
			desc.isDisplayFailMessage_SP = !skipSpFailCheck;
			desc.isSkipFailCheckSP = skipSpFailCheck;

			var result = new Section_RecoverHP.Result();
			var section = new Section_RecoverHP(GetCommonParam());
			section.Execute(result, in desc);

			return result.isRecovered;
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;
			public ushort drainHP;
			public bool skipSpFailCheck;

			public Description()
			{
				attacker = null;
				target = null;
				drainHP = 0;
				skipSpFailCheck = false;
			}
		}

		public class Result
		{
			public bool isHpRecovered;
		}
	}
}
