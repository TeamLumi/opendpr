using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaRob : Section
	{
		public Section_WazaRob(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			WazaRobParam robParam = description.robParam;
			BTL_POKEPARAM originalAttacker = description.attacker;
			WazaNo actWaza = description.actWaza;

			for (byte i = 0; i < robParam.robberCount; i++)
			{
				byte robberPokeID = robParam.robberPokeID[i];
				BtlPokePos targetPos = robParam.targetPos[i];

				BTL_POKEPARAM robPoke = GetPokeParam(robberPokeID);
				if (robPoke.IsDead())
				{
					continue;
				}

				event_WazaRob(robPoke, originalAttacker, actWaza);

				WazaParam wazaParam = new WazaParam();
				getWazaParam(wazaParam, robPoke, actWaza);

				if (isFailedByKaihukuHuuji(robPoke, wazaParam))
				{
					putFailedMessageByKaihukuHuuji(robPoke, wazaParam);
					continue;
				}

				if (isFailedByZigokuDuki(robPoke, wazaParam))
				{
					putFailedMessageByZigokuDuki(robPoke, wazaParam);
					continue;
				}

				PokeSet targets = new PokeSet();
				registerTarget(targets, robPoke, wazaParam, targetPos);

				if (targets.GetCount() > 0)
				{
					wazaExec(robPoke, wazaParam, targets);
				}
			}
		}

		private void event_WazaRob(BTL_POKEPARAM robPoke, BTL_POKEPARAM originalPoke, WazaNo waza)
		{
			GetEventLauncher().Event_WazaRob(robPoke, originalPoke, waza);
		}

		private void getWazaParam(WazaParam pWazaParam, BTL_POKEPARAM attacker, WazaNo waza)
		{
			int wazaPri = WAZADATA.GetPriority(waza);
			GetEventLauncher().Event_GetWazaParam(waza, waza, WazaNo.NULL, wazaPri, attacker, pWazaParam);
		}

		private void registerTarget(PokeSet pPokeSet, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, BtlPokePos targetPos)
		{
			if (targetPos == BtlPokePos.POS_NULL)
			{
				return;
			}

			byte targetPokeID = GetBattleEnv().GetPokeCon().GetFrontPokeID(targetPos);
			if (targetPokeID == PokeID.INVALID)
			{
				return;
			}

			BTL_POKEPARAM target = GetPokeParam(targetPokeID);
			if (target != null && target.IsFightEnable())
			{
				pPokeSet.Add(target);
			}
		}

		private bool isFailedByKaihukuHuuji(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			if (!attacker.CheckSick(WazaSick.WAZASICK_KAIHUKUHUUJI))
			{
				return false;
			}

			return WAZADATA.GetFlag(wazaParam.wazaID, WazaFlag.KAIFUKU_HUUJI);
		}

		private void putFailedMessageByKaihukuHuuji(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			StrParam str = new StrParam();
			str.Setup(BtlStrType.BTL_STRTYPE_SET, (ushort)BTL_STRID_SET.KaifukuFujiWarn);
			str.AddArg(attacker.GetID());
			GetServerCommandPutter().Message(in str);
		}

		private bool isFailedByZigokuDuki(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			if (!attacker.CheckSick(WazaSick.WAZASICK_ZIGOKUDUKI))
			{
				return false;
			}

			WazaDamageType dmgType = WAZADATA.GetDamageType(wazaParam.wazaID);
			return dmgType == WazaDamageType.NONE;
		}

		private void putFailedMessageByZigokuDuki(BTL_POKEPARAM attacker, WazaParam wazaParam)
		{
			GetEventLauncher().Event_CheckWazaExeFail(attacker, wazaParam.wazaID, WazaFailCause.ZIGOKUDUKI);
		}

		private void wazaExec(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets)
		{
			WazaCategory category = WAZADATA.GetCategory(wazaParam.wazaID);

			var desc = new Section_WazaExec_Category.Description();
			desc.attacker = attacker;
			desc.actionDesc = new ActionDesc();
			desc.wazaParam = wazaParam;
			desc.isDamageWaza = false;
			desc.wazaCategory = category;
			desc.affinityRecorder = null;
			desc.targets = targets;

			var result = new Section_WazaExec_Category.Result();
			var section = new Section_WazaExec_Category(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public WazaRobParam robParam;
			public BTL_POKEPARAM attacker;
			public WazaNo actWaza;
		}

		public class Result { }
	}
}
