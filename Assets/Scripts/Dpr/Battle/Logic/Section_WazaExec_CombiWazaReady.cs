using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_CombiWazaReady : Section
	{
		private const uint MAX_COMBI_POKE_NUM = 4;

		private static readonly WazaNo[] COMBI_WAZA_TABLE = new WazaNo[]
		{
            WazaNo.HONOONOTIKAI, WazaNo.MIZUNOTIKAI, WazaNo.KUSANOTIKAI,
        };

		public Section_WazaExec_CombiWazaReady(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isReadied = false;

			if (!isCombiWaza(description.waza))
				return;

			PokeAction[] actionBuffer = new PokeAction[MAX_COMBI_POKE_NUM];
			uint actionNum = 0;

			getCombiPossibleActions(actionBuffer, ref actionNum, description.attacker.GetID(), description.waza, description.targetPos);

			if (actionNum == 0)
				return;

			PokeAction partnerAction = getCombiPartnerAction(actionBuffer, actionNum);
			if (partnerAction == null)
				return;

			byte partnerPokeID = partnerAction.bpp.GetID();
			description.attacker.CombiWaza_SetParam(partnerPokeID, description.waza);
			partnerAction.bpp.CombiWaza_SetParam(description.attacker.GetID(), description.waza);

			pResult.isReadied = true;
		}

		private bool isCombiWaza(WazaNo waza)
		{
			for (int i = 0; i < COMBI_WAZA_TABLE.Length; i++)
			{
				if (COMBI_WAZA_TABLE[i] == waza)
					return true;
			}
			return false;
		}

		private void getCombiPossibleActions(PokeAction[] ppActionBuffer, ref uint pActionNum, byte attackerID, WazaNo waza, BtlPokePos targetPos)
		{
			pActionNum = 0;

			PokeActionContainer container = GetPokemonActionContainer();
			byte count = container.GetCount();

			for (byte i = 0; i < count; i++)
			{
				PokeAction action = container.Get(i);

				if (action.fDone)
					continue;

				if (action.actionCategory != PokeActionCategory.Fight)
					continue;

				if (action.bpp.GetID() == attackerID)
					continue;

				if (action.actionParam_Fight.waza != waza)
					continue;

				if (pActionNum < MAX_COMBI_POKE_NUM)
				{
					ppActionBuffer[pActionNum] = action;
					pActionNum++;
				}
			}
		}

		private PokeAction getCombiPartnerAction(PokeAction[] pActions, uint actionNum)
		{
			if (actionNum == 0)
				return null;

			return pActions[0];
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaNo waza;
			public BtlPokePos targetPos;
		}

		public class Result
		{
			public bool isReadied;
		}
	}
}
