using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckWazaAvoid : Section
	{
		public Section_CheckWazaAvoid(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
		{
			uint count = description.targets.GetCount();
			bool anyAvoided = false;

			for (int i = 0; i < (int)count; i++)
			{
				BTL_POKEPARAM target = description.targets.Get((byte)i);

				checkHit(out bool isHit, out bool isFriendshipActive, description.attacker, target, description.wazaParam);

				if (!isHit)
				{
					putAvoidMessage(target, description.wazaParam.wazaID, isFriendshipActive);
					description.targets.Remove(target);
					i--;
					count--;
					anyAvoided = true;

					if (description.actionRecorder != null)
					{
						description.actionRecorder.SetAction(description.attacker.GetID(), ActionRecorder.ActionID.FAILED_HIT_PERCENTAGE);
					}
				}
			}

			if (anyAvoided && description.targets.GetCount() == 0)
			{
				wazaAvoid(description.attacker, description.isDelayAttack);
			}
		}

		private void checkHit(out bool pIsHit, out bool pIsFriendshipActive, BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam)
		{
			pIsFriendshipActive = false;

			if (GetEventLauncher().Event_SkipAvoidCheck(attacker, target, wazaParam))
			{
				pIsHit = true;
				return;
			}

			pIsHit = GetEventLauncher().Event_CheckHit(attacker, target, wazaParam, out pIsFriendshipActive);
		}

		private void putAvoidMessage(BTL_POKEPARAM avoidPoke, WazaNo waza, bool byFriendship)
		{
			if (byFriendship)
			{
				StrParam strParam = new StrParam();
				strParam.Setup(BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.FR_Avoid);
				strParam.AddArg(avoidPoke.GetID());
				GetServerCommandPutter().Message(strParam);
			}
			else
			{
				StrParam strParam = new StrParam();
				strParam.Setup(BtlStrType.BTL_STRTYPE_SET, (ushort)BTL_STRID_SET.WazaAvoid);
				strParam.AddArg(avoidPoke.GetID());
				GetServerCommandPutter().Message(strParam);
			}
		}

		private void wazaAvoid(BTL_POKEPARAM attacker, bool fDelayAttack)
		{
			GetEventLauncher().Event_WazaAvoid(attacker, fDelayAttack);
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public PokeSet targets;
			public ActionRecorder actionRecorder;
			public bool isDelayAttack;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				targets = null;
				actionRecorder = null;
				isDelayAttack = false;
			}
		}

		public class Result { }
	}
}