using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaRankEffect_CheckEffective : Section
	{
		public Section_WazaRankEffect_CheckEffective(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isEffective = false;
			pResult.failResult = SimpleEffectFailManager.Result.RESULT_STD;

			BTL_POKEPARAM attacker = description.pAttacker;
			BTL_POKEPARAM target = description.pTarget;
			WazaParam wazaParam = description.pWazaParam;
			uint actionSerialNo = description.actionSerialNo;
			bool fAlmost = description.fAlmost;

			byte attackerID = attacker.GetID();
			bool isMigawariThrew = false;

			WazaNo waza = wazaParam.wazaID;
			byte rankEffCount = WAZADATA.GetRankEffectCount(waza);

			SimpleEffectFailManager failManager = new SimpleEffectFailManager();
			failManager.Start();

			for (uint i = 0; i < rankEffCount; i++)
			{
				int volume;
				WazaRankEffect effect = WAZADATA.GetRankEffect(waza, i, out volume);
				if (effect == WazaRankEffect.NONE)
				{
					continue;
				}

				if (checkEffective(attackerID, effect, volume, isMigawariThrew, fAlmost, actionSerialNo, target, failManager))
				{
					pResult.isEffective = true;
				}
			}

			pResult.failResult = failManager.GetResult();
			failManager.End();
		}

		private bool checkEffective(byte attackerID, WazaRankEffect effect, int volume, bool isMigawariThrew, bool fAlmost, uint actionSerialNo, BTL_POKEPARAM target, SimpleEffectFailManager pFailManager)
		{
			return checkEffectiveCore(attackerID, effect, volume, isMigawariThrew, fAlmost, actionSerialNo, target, pFailManager);
		}

		private bool checkEffectiveCore(byte attackerID, WazaRankEffect effect, int volume, bool isMigawariThrew, bool fAlmost, uint actionSerialNo, BTL_POKEPARAM target, SimpleEffectFailManager pFailManager)
		{
			var desc = new Section_RankEffect_CheckEffective.Description();
			desc.attackerID = attackerID;
			desc.targetID = target.GetID();
			desc.effect = effect;
			desc.volume = volume;
			desc.cause = RankEffectCause.OTHER;
			desc.rankEffSerial = actionSerialNo;
			desc.canPutFailMessage = fAlmost;
			desc.canMigawariThrew = isMigawariThrew;
			desc.pSimpleEffectFailManager = pFailManager;

			var result = new Section_RankEffect_CheckEffective.Result();
			var section = new Section_RankEffect_CheckEffective(GetCommonParam());
			section.Execute(result, in desc);

			return result.isValid;
		}

		public class Description
		{
			public WazaParam pWazaParam;
			public BTL_POKEPARAM pAttacker;
			public BTL_POKEPARAM pTarget;
			public uint actionSerialNo;
			public bool fAlmost;
		}

		public class Result
		{
			public bool isEffective;
			public SimpleEffectFailManager.Result failResult;
		}
	}
}
