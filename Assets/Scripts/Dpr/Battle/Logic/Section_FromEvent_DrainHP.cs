namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DrainHP : Section
	{
		public Section_FromEvent_DrainHP(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;

			BTL_POKEPARAM recoverPoke = GetPokeParam(description.recoverPokeID);
			BTL_POKEPARAM damagedPoke = GetPokeParam(description.damagedPokeID);

			if (recoverPoke.IsDead())
			{
				return;
			}

			result.isSuccessed = drain(recoverPoke, damagedPoke, description.recoverHP, description.isSkipFailCheckSP);

			if (result.isSuccessed && description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(description.successMessage);
			}
		}

		private bool drain(BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort drainHP, bool skipSpFailCheck)
		{
			if (!skipSpFailCheck)
			{
				Section_RecoverHP_CheckFailSP section = new Section_RecoverHP_CheckFailSP(GetCommonParam());
				Section_RecoverHP_CheckFailSP.Description desc = new Section_RecoverHP_CheckFailSP.Description();
				Section_RecoverHP_CheckFailSP.Result res = new Section_RecoverHP_CheckFailSP.Result();

				desc.poke = attacker;

				section.Execute(res, desc);

				if (res.isFailed)
				{
					return false;
				}
			}

			ushort recoverHP = GetEventLauncher().Event_RecalcDrainVolume(attacker, target, drainHP);

			if (recoverHP > 0)
			{
				GetServerCommandPutter().SimpleHp(attacker, -(int)recoverHP, DamageCause.OTHER, PokeID.INVALID, true);
				return true;
			}

			return false;
		}

		public class Description
		{
			public ushort recoverHP;
			public byte recoverPokeID;
			public byte damagedPokeID;
			public bool isSkipFailCheckSP;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				recoverHP = 0;
				recoverPokeID = PokeID.INVALID;
				damagedPokeID = PokeID.INVALID;
				isSkipFailCheckSP = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}