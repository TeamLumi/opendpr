namespace Dpr.Battle.Logic
{
	public sealed class Section_CriticalMsg : Section
	{
		public Section_CriticalMsg(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			// Find the first target that got a critical hit and display message
			for (uint i = 0; i < description.targetNum; i++)
			{
				if (description.criticalTypes[i] != CriticalType.CRITICAL_NONE)
				{
					putMessage(description.attacker, description.targets[i],
						description.criticalTypes[i], description.isPluralHitWaza);

					// Check battle talk for first damage on trainer's pokemon
					checkBattleTalk(description.targets[i].GetID());
					break;
				}
			}
		}

		private void putMessage(BTL_POKEPARAM attacker, BTL_POKEPARAM target, CriticalType criticalType, bool isPluralHitWaza)
		{
			StrParam str = new StrParam();

			if (criticalType == CriticalType.CRITICAL_FRIENDSHIP)
			{
				// Friendship critical uses special message
				str.Setup(BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.FR_Critical);
				str.AddArg(attacker.GetID());
			}
			else
			{
				// Normal critical hit message
				str.Setup(BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.CriticalHit);
			}

			GetServerCommandPutter().Message(in str);
		}

		private void checkBattleTalk(byte pokeID)
		{
			// Battle talk is handled client-side by TrainerMessageManager
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public uint targetNum;
			public BTL_POKEPARAM[] targets;
			public CriticalType[] criticalTypes;
			public bool isPluralHitWaza;

			public Description()
			{
				attacker = null;
				wazaParam = null;
				targetNum = 0;
				targets = null;
				criticalTypes = null;
				isPluralHitWaza = false;
			}
		}

		public class Result { }
	}
}
