using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RankEffect : Section
	{
		public Section_FromEvent_RankEffect(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;

			if (description.targetPokeCount == 0)
			{
				return;
			}

			if (!checkEffectiveAny(description.targetPokeCount, description.targetPokeID, description.rankType, description.rankVolume))
			{
				return;
			}

			result.isSuccessed = addRankEffect(in description);
		}

		private bool checkTokuseiWindowDisplay(in Description description)
		{
			return description.isDisplayTokuseiWindow;
		}

		private bool checkEffectiveAny(byte targetPokeCount, byte[] targetPokeID, WazaRankEffect rankType, sbyte rankVolume)
		{
			for (byte i = 0; i < targetPokeCount; i++)
			{
				BTL_POKEPARAM target = GetPokeParam(targetPokeID[i]);
				if (target.IsDead())
				{
					continue;
				}

				int currentRank = target.GetValue((BTL_POKEPARAM.ValueID)getRankValueID(rankType));
				if (rankVolume > 0 && currentRank < 12)
				{
					return true;
				}
				if (rankVolume < 0 && currentRank > 0)
				{
					return true;
				}
			}
			return false;
		}

		private bool addRankEffect(in Description description)
		{
			bool anySucceeded = false;
			bool isTokuseiWindowDisplay = checkTokuseiWindowDisplay(in description);
			bool isStandardMessageEnable = !description.isStandardMessageDisable;

			StrParam preMessage = getPreMessage(in description);

			if (isTokuseiWindowDisplay)
			{
				GetServerCommandPutter().TokWin_In(description.pokeID);
			}

			for (byte i = 0; i < description.targetPokeCount; i++)
			{
				byte targetPokeID = description.targetPokeID[i];
				BTL_POKEPARAM target = GetPokeParam(targetPokeID);

				if (target.IsDead())
				{
					continue;
				}

				if (addRankEffect(description.pokeID, target, description.rankType, description.rankVolume,
					description.cause, description.itemID, description.effectSerial,
					description.isSpFailMessageDisplay, description.isMigawariThrew,
					isStandardMessageEnable, preMessage, description.effectViewType))
				{
					anySucceeded = true;
				}
			}

			if (isTokuseiWindowDisplay)
			{
				GetServerCommandPutter().TokWin_Out(description.pokeID);
			}

			return anySucceeded;
		}

		private StrParam getPreMessage(in Description description)
		{
			if (description.isPreEffectMessageEnable && description.message.IsEnable())
			{
				return description.message;
			}
			return null;
		}

		private bool addRankEffect(byte attackerID, BTL_POKEPARAM target, WazaRankEffect effect, int volume, RankEffectCause cause, ushort itemID, uint rankEffSerial, bool isSpFailMessageDisplay, bool isMigawariThrew, bool isStandardMessageEnable, StrParam preMessage, RankEffectViewType effectViewType)
		{
			var desc = new Section_RankEffect.Description();
			desc.atkPokeID = attackerID;
			desc.pTarget = target;
			desc.effect = effect;
			desc.volume = volume;
			desc.cause = cause;
			desc.itemID = itemID;
			desc.rankEffSerial = rankEffSerial;
			desc.canPutFailMessage = isSpFailMessageDisplay;
			desc.bMigawariThrew = isMigawariThrew;
			desc.fStdMsg = isStandardMessageEnable;
			desc.preMessage = preMessage;
			desc.effectViewType = effectViewType;

			var rankResult = new Section_RankEffect.Result();
			var rankSection = new Section_RankEffect(GetCommonParam());
			rankSection.Execute(rankResult, in desc);

			return rankResult.isValid;
		}

		private BTL_POKEPARAM getPoke(byte pokeID)
		{
			return GetPokeParam(pokeID);
		}

		private static BTL_POKEPARAM.ValueID getRankValueID(WazaRankEffect rankType)
		{
			switch (rankType)
			{
				case WazaRankEffect.ATTACK:    return BTL_POKEPARAM.ValueID.BPP_ATTACK_RANK;
				case WazaRankEffect.DEFENCE:   return BTL_POKEPARAM.ValueID.BPP_DEFENCE_RANK;
				case WazaRankEffect.SP_ATTACK:  return BTL_POKEPARAM.ValueID.BPP_SP_ATTACK_RANK;
				case WazaRankEffect.SP_DEFENCE: return BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE_RANK;
				case WazaRankEffect.AGILITY:   return BTL_POKEPARAM.ValueID.BPP_AGILITY_RANK;
				case WazaRankEffect.HIT:       return BTL_POKEPARAM.ValueID.BPP_HIT_RATIO;
				case WazaRankEffect.AVOID:     return BTL_POKEPARAM.ValueID.BPP_AVOID_RATIO;
				default:                       return BTL_POKEPARAM.ValueID.BPP_ATTACK_RANK;
			}
		}

		public class Description
		{
			public byte pokeID;
			public byte targetPokeCount;
			public byte[] targetPokeID = new byte[DefineConstants.BTL_POSIDX_MAX];
			public WazaRankEffect rankType;
			public sbyte rankVolume;
			public RankEffectCause cause;
			public ushort itemID;
			public uint effectSerial;
			public bool isDisplayTokuseiWindow;
			public bool isStandardMessageDisable;
			public bool isSpFailMessageDisplay;
			public bool byWazaEffect;
			public bool isPreEffectMessageEnable;
			public RankEffectViewType effectViewType;
			public bool isMigawariThrew;
			public StrParam message = new StrParam();

			public Description()
			{
				pokeID = PokeID.INVALID;
				targetPokeCount = 0;
				rankType = WazaRankEffect.NONE;
				rankVolume = 0;
				cause = RankEffectCause.OTHER;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				effectSerial = 0;
				isDisplayTokuseiWindow = false;
				isStandardMessageDisable = false;
				isSpFailMessageDisplay = false;
				byWazaEffect = false;
				isPreEffectMessageEnable = false;
				effectViewType = RankEffectViewType.ENABLE;
				isMigawariThrew = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}
