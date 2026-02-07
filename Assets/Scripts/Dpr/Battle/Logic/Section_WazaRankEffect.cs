using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaRankEffect : Section
	{
		public Section_WazaRankEffect(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isEffective = false;

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

				if (rankEffect(attackerID, effect, volume, isMigawariThrew, fAlmost, actionSerialNo, target, failManager))
				{
					pResult.isEffective = true;
				}
			}

			failManager.End();
		}

		private bool rankEffect(byte attackerID, WazaRankEffect effect, int volume, bool isMigawariThrew, bool fAlmost, uint actionSerialNo, BTL_POKEPARAM target, SimpleEffectFailManager pFailManager)
		{
			return rankEffectCore(attackerID, effect, volume, isMigawariThrew, fAlmost, actionSerialNo, target, pFailManager);
		}

		private bool rankEffectCore(byte attackerID, WazaRankEffect effect, int volume, bool isMigawariThrew, bool fAlmost, uint actionSerialNo, BTL_POKEPARAM target, SimpleEffectFailManager pFailManager)
		{
			var desc = new Section_RankEffect.Description();
			desc.atkPokeID = attackerID;
			desc.pTarget = target;
			desc.effect = effect;
			desc.volume = volume;
			desc.cause = RankEffectCause.OTHER;
			desc.rankEffSerial = actionSerialNo;
			desc.canPutFailMessage = fAlmost;
			desc.bMigawariThrew = isMigawariThrew;
			desc.pSimpleEffectFailManager = pFailManager;
			desc.fStdMsg = true;
			desc.effectViewType = RankEffectViewType.ENABLE;

			var result = new Section_RankEffect.Result();
			var section = new Section_RankEffect(GetCommonParam());
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
		}
	}
}
