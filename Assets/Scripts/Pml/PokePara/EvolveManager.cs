using Pml.Personal;
using XLSXContent;

namespace Pml.PokePara
{
	public sealed class EvolveManager
	{
		public const ushort EVOLVE_FRIENDSHIP = 160;

		public EvolveManager()
		{
			// Empty, declared explicitly
		}

		public MonsNo GetEvolvedMonsNo_byLevelUp(CoreParam poke, PokeParty party, EvolveSituation situation, ref uint root_num)
		{
			if (!canEvolve(poke))
				return MonsNo.NULL;

			if (poke.IsEgg(EggCheckType.BOTH_EGG))
				return MonsNo.NULL;
			if (CheckItem_KAWARAZUNOISHI(poke.GetItem()))
				return MonsNo.NULL;

			var evolveData = PersonalSystem.GetEvolutionTable(poke.GetMonsNo(), poke.GetFormNo());
			var routeNum = evolveData.GetEvolutionRouteNum();

			for (int i = 0; i < routeNum; i++)
			{
				if (IsSatisfyEvolveConditionLevelUp(poke, party, situation, evolveData, i))
				{
					root_num = (uint)i;
					return evolveData.GetEvolvedMonsNo(i);
				}
			}

			return MonsNo.NULL;
		}

		public MonsNo GetEvolvedMonsNo_byEvent(CoreParam poke, PokeParty party, EvolveSituation situation, ref uint root_num)
		{
			if (!canEvolve(poke))
				return MonsNo.NULL;

			if (poke.IsEgg(EggCheckType.BOTH_EGG))
				return MonsNo.NULL;
			if (CheckItem_KAWARAZUNOISHI(poke.GetItem()))
				return MonsNo.NULL;

			var evolveData = PersonalSystem.GetEvolutionTable(poke.GetMonsNo(), poke.GetFormNo());
			var routeNum = evolveData.GetEvolutionRouteNum();

			for (int i = 0; i < routeNum; i++)
			{
				IsSatisfyEvolveConditionEvent(poke, party, situation, evolveData, i);
			}

			return MonsNo.NULL;
		}

		public MonsNo GetEvolvedMonsNo_byItem(CoreParam poke, EvolveSituation situation, uint use_item, ref uint root_num)
		{
			if (!canEvolve(poke))
				return MonsNo.NULL;

			if (poke.IsEgg(EggCheckType.BOTH_EGG))
				return MonsNo.NULL;
			if (CheckItem_KAWARAZUNOISHI(poke.GetItem()))
				return MonsNo.NULL;

			var evolveData = PersonalSystem.GetEvolutionTable(poke.GetMonsNo(), poke.GetFormNo());
			var routeNum = evolveData.GetEvolutionRouteNum();

			for (int i = 0; i < routeNum; i++)
			{
				if (IsSatisfyEvolveConditionItem(poke, situation, use_item, evolveData, i))
				{
					root_num = (uint)i;
					return evolveData.GetEvolvedMonsNo(i);
				}
			}

			return MonsNo.NULL;
		}

		public MonsNo GetEvolvedMonsNo_byTrade(CoreParam poke, CoreParam pair_poke, ref uint root_num)
		{
			if (!canEvolve(poke))
				return MonsNo.NULL;

			if (poke.IsEgg(EggCheckType.BOTH_EGG))
				return MonsNo.NULL;
			if (poke.GetMonsNo() != MonsNo.YUNGERAA && CheckItem_KAWARAZUNOISHI(poke.GetItem()))
				return MonsNo.NULL;

			var evolveData = PersonalSystem.GetEvolutionTable(poke.GetMonsNo(), poke.GetFormNo());
			var routeNum = evolveData.GetEvolutionRouteNum();

			for (int i = 0; i < routeNum; i++)
			{
				if (IsSatisfyEvolveConditionTrade(poke, pair_poke, evolveData, i))
				{
					root_num = (uint)i;
					return evolveData.GetEvolvedMonsNo(i);
				}
			}

			return MonsNo.NULL;
		}

		public bool HaveEvolutionRoot(CoreParam poke)
		{
			if (poke.IsSpecialGEnable())
			{
				var monsno = poke.GetMonsNo();
				if (monsno == MonsNo.PIKATYUU || monsno == MonsNo.NYAASU || monsno == MonsNo.IIBUI)
					return false;
			}
			var evolveData = PersonalSystem.GetEvolutionTable(poke.GetMonsNo(), poke.GetFormNo());
			return evolveData.GetEvolutionRouteNum() > 0;
		}

		protected bool CheckItem_KAWARAZUNOISHI(uint item)
		{
			return item == (uint)ItemNo.KAWARAZUNOISI;
		}

		private bool canEvolve(CoreParam poke)
		{
			if (poke.IsSpecialGEnable())
			{
				var monsno = poke.GetMonsNo();
				if (monsno == MonsNo.PIKATYUU || monsno == MonsNo.NYAASU || monsno == MonsNo.IIBUI)
					return false;
			}
			return true;
		}

		private bool IsSatisfyEvolveConditionLevelUp(CoreParam poke, PokeParty party, EvolveSituation situation, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex)
		{
			// TODO: Complex method with OT friendship logic, HaveCalcData checks, and jump table
			return false;
		}

		private bool IsSatisfyEvolveConditionEvent(CoreParam poke, PokeParty party, EvolveSituation situation, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex)
		{
			// TODO: Binary shows this always returns false (event evolution not used in BDSP)
			return false;
		}

		private bool IsSatisfyEvolveConditionItem(CoreParam poke, EvolveSituation situation, uint use_item, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex)
		{
			var cond = evolveData.GetEvolutionCondition(evolveRouteIndex);
			var param = evolveData.GetEvolutionParam(evolveRouteIndex);
			evolveData.GetEvolvedMonsNo(evolveRouteIndex);
			evolveData.GetEvolveEnableLevel(evolveRouteIndex);

			switch (cond)
			{
				case EvolveCond.ITEM:
					return param == use_item;

				case EvolveCond.ITEM_MALE:
					return param == use_item && poke.GetSex() == Sex.MALE;

				case EvolveCond.ITEM_FEMALE:
					return param == use_item && poke.GetSex() == Sex.FEMALE;

				case EvolveCond.PLACE_ULTRA_SPACE_ITEM:
					return param == use_item && situation.isUltraSpace;

				default:
					return false;
			}
		}

		private bool IsSatisfyEvolveConditionTrade(CoreParam poke, CoreParam pair_poke, EvolveTable.SheetEvolve evolveData, int evolveRouteIndex)
		{
			int cond = (int)evolveData.GetEvolutionCondition(evolveRouteIndex);
			var param = evolveData.GetEvolutionParam(evolveRouteIndex);
			evolveData.GetEvolvedMonsNo(evolveRouteIndex);
			evolveData.GetEvolveEnableLevel(evolveRouteIndex);

			if (cond == 7) // EvolveCond.TUUSHIN_YUUGOU
			{
				if (pair_poke != null && pair_poke.GetItem() != (uint)ItemNo.KAWARAZUNOISI)
				{
					// Dead code in binary: calls IsTamago and IsFuseiTamago but discards results
					pair_poke.IsEgg(EggCheckType.BOTH_EGG);
				}
			}
			else
			{
				if (cond == 6) // EvolveCond.TUUSHIN_ITEM
				{
					return poke.GetItem() == param;
				}
				if (cond == 5) // EvolveCond.TUUSHIN
				{
					return true;
				}
			}
			return false;
		}
	}
}
