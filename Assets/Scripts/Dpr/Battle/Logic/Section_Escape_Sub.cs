namespace Dpr.Battle.Logic
{
	public sealed class Section_Escape_Sub : Section
	{
		public Section_Escape_Sub(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			pResult.isSucceeded = false;

			BTL_POKEPARAM escapePoke = description.escapePoke;
			bool isForceSuccess = description.isForceSuccess;
			bool isSkipAgiCheck = description.isSkipAgiCheck;

			// Check force succeed conditions (Run Away ability, Smoke Ball, etc.)
			if (!isForceSuccess)
			{
				checkForceSucceed(ref isForceSuccess, ref isSkipAgiCheck, in description);
			}

			// If not force success and not skipping agi check, do speed comparison
			if (!isForceSuccess && !isSkipAgiCheck)
			{
				// Get escape try count from the battle counter
				byte tryCount = (byte)GetBattleEnv().GetBattleCounter().Get(BattleCounter.UniqueCounter.ESCAPE_TRIED_COUNT);
				if (!checkEscapeEnableByAgi(escapePoke, tryCount))
				{
					// Escape failed — increment try counter
					GetBattleEnv().GetBattleCounter().Inc(BattleCounter.UniqueCounter.ESCAPE_TRIED_COUNT);
					pResult.isSucceeded = false;
					return;
				}
			}

			// Run the actual escape
			pResult.isSucceeded = section_Escape_Core(escapePoke, isForceSuccess);
		}

		private void checkForceSucceed(ref bool pIsForceSuccess, ref bool pIsSkipAgiCheck, in Description description)
		{
			// Check if the pokemon has an ability/item that forces escape success
			bool canForceEscape = section_Escape_CheckForceSucceed(description.escapePoke);
			if (canForceEscape)
			{
				pIsForceSuccess = true;
			}
		}

		private bool section_Escape_CheckForceSucceed(BTL_POKEPARAM pPoke)
		{
			// Delegate to child section
			var desc = new Section_Escape_CheckForceSucceed.Description();
			desc.poke = pPoke;
			var result = new Section_Escape_CheckForceSucceed.Result();
			var section = new Section_Escape_CheckForceSucceed(GetCommonParam());
			section.Execute(result, in desc);
			return result.canEscape;
		}

		private bool checkEscapeEnableByAgi(BTL_POKEPARAM escapePoke, byte tryCount)
		{
			// Wild battle escape formula: compare speed with opponent
			// Player speed * 128 / opponent speed + 30 * tryCount
			// If >= 256, escape succeeds. Otherwise random check.

			// Get opponent pokemon (first alive enemy)
			byte myPokeID = escapePoke.GetID();
			byte myClientID = (byte)PokeID.PokeIdToClientId(myPokeID);

			// Calculate escape poke speed
			ushort mySpeed = GetEventLauncher().Event_CalcAgility(escapePoke, false);

			// Find the fastest opponent
			ushort opponentSpeed = 0;
			for (byte pos = 0; pos < (byte)PokemonPosition.BTL_POS_NUM; pos++)
			{
				byte pokeID = GetBattleEnv().GetPokeCon().GetFrontPokeID((BtlPokePos)pos);
				if (pokeID == PokeID.INVALID)
				{
					continue;
				}
				BTL_POKEPARAM oppPoke = GetPokeParam(pokeID);
				if (oppPoke.IsDead())
				{
					continue;
				}
				byte oppClientID = (byte)PokeID.PokeIdToClientId(pokeID);
				if (!GetMainModule().IsOpponentClientID(myClientID, oppClientID))
				{
					continue;
				}
				ushort speed = GetEventLauncher().Event_CalcAgility(oppPoke, false);
				if (speed > opponentSpeed)
				{
					opponentSpeed = speed;
				}
			}

			if (opponentSpeed == 0)
			{
				return true;
			}

			// Escape formula
			uint escapeValue = (uint)mySpeed * 128 / opponentSpeed + 30 * (uint)tryCount;
			if (escapeValue >= 256)
			{
				return true;
			}

			// Random check
			uint rand = calc.GetRand(256);
			return rand < escapeValue;
		}

		private bool section_Escape_Core(BTL_POKEPARAM pPoke, bool isForceSuccess)
		{
			var desc = new Section_Escape_Core.Description();
			desc.escapePoke = pPoke;
			desc.isForceSuccess = isForceSuccess;
			desc.isSpMessageCheckEnable = true;

			var result = new Section_Escape_Core.Result();
			var section = new Section_Escape_Core(GetCommonParam());
			section.Execute(result, in desc);
			return result.isSucceeded;
		}

		public class Description
		{
			public BTL_POKEPARAM escapePoke;
			public bool isSkipAgiCheck;
			public bool isForceSuccess;

			public Description()
			{
				escapePoke = null;
				isSkipAgiCheck = false;
				isForceSuccess = false;
			}
		}

		public class Result
		{
			public bool isSucceeded;

			public Result()
			{
				isSucceeded = false;
			}
		}
	}
}
