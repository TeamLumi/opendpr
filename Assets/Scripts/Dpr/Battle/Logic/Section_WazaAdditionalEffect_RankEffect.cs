using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaAdditionalEffect_RankEffect : Section
	{
		public Section_WazaAdditionalEffect_RankEffect(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			WazaParam wazaParam = description.wazaParam;
			BTL_POKEPARAM attacker = description.attacker;
			BTL_POKEPARAM target = description.target;

			// Check if rank effect occurs (probability check)
			if (!isRankEffectOccur(wazaParam, attacker, target))
			{
				return;
			}

			// Apply the rank effect
			addRankEffect(description.actionDesc, wazaParam, attacker, target);
		}

		private bool isRankEffectOccur(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target)
		{
			if (target.IsDead())
			{
				return false;
			}

			WazaNo waza = wazaParam.wazaID;

			// Get the number of rank effects this move has
			byte rankEffCount = WAZADATA.GetRankEffectCount(waza);
			if (rankEffCount == 0)
			{
				return false;
			}

			// Check probability for each rank effect
			for (uint i = 0; i < rankEffCount; i++)
			{
				int per = WAZADATA.GetRankEffectPer(waza, i);
				if (per > 0)
				{
					// Check special occurrence rate via event system
					uint finalPer = GetEventLauncher().Event_CheckSpecialWazaAdditionalPer(
						attacker.GetID(), target.GetID(), (uint)per);
					if (calc.IsOccurPer(finalPer))
					{
						return true;
					}
				}
			}

			return false;
		}

		private void addRankEffect(ActionDesc actionDesc, WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target)
		{
			WazaNo waza = wazaParam.wazaID;
			byte rankEffCount = WAZADATA.GetRankEffectCount(waza);

			for (uint i = 0; i < rankEffCount; i++)
			{
				int volume;
				WazaRankEffect effect = WAZADATA.GetRankEffect(waza, i, out volume);
				if (effect == WazaRankEffect.NONE)
				{
					continue;
				}

				var desc = new Section_WazaRankEffect.Description();
				desc.pWazaParam = wazaParam;
				desc.pAttacker = attacker;
				desc.pTarget = target;
				desc.actionSerialNo = actionDesc.serialNo;

				var result = new Section_WazaRankEffect.Result();
				var section = new Section_WazaRankEffect(GetCommonParam());
				section.Execute(result, in desc);
			}
		}

		public class Description
		{
			public ActionDesc actionDesc;
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM target;

			public Description()
			{
				actionDesc = null;
				wazaParam = null;
				attacker = null;
				target = null;
			}
		}

		public class Result { }
	}
}
