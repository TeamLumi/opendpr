using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RaidBoss_BreakGWall : Section
	{
		public Section_RaidBoss_BreakGWall(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description desc)
		{
			BTL_POKEPARAM boss = findRaidBoss();
			if (boss == null)
			{
				return;
			}

			GetServerCommandPutter().BreakGWall(boss.GetID());
			addDamage(boss);
			rankDown(boss);
		}

		private BTL_POKEPARAM findRaidBoss()
		{
			for (int i = 0; i < (int)PokemonPosition.BTL_POS_NUM; i++)
			{
				byte pokeID = GetBattleEnv().GetPokeCon().GetFrontPokeID((BtlPokePos)i);
				if (pokeID == PokeID.INVALID)
				{
					continue;
				}
				BTL_POKEPARAM poke = GetPokeParam(pokeID);
				if (poke != null && poke.IsRaidBoss())
				{
					return poke;
				}
			}
			return null;
		}

		private void addDamage(BTL_POKEPARAM boss)
		{
			uint maxHp = (uint)boss.GetValue(BTL_POKEPARAM.ValueID.BPP_MAX_HP);
			uint damage = maxHp / 8;
			if (damage == 0)
			{
				damage = 1;
			}

			GetServerCommandPutter().SimpleHp(boss, -(int)damage, DamageCause.OTHER, PokeID.INVALID, true);
		}

		private void rankDown(BTL_POKEPARAM boss)
		{
			rankDown(boss, WazaRankEffect.ATTACK);
			rankDown(boss, WazaRankEffect.DEFENCE);
			rankDown(boss, WazaRankEffect.SP_ATTACK);
			rankDown(boss, WazaRankEffect.SP_DEFENCE);
		}

		private void rankDown(BTL_POKEPARAM boss, WazaRankEffect effect)
		{
			var desc = new Section_RankEffect.Description();
			desc.atkPokeID = PokeID.INVALID;
			desc.pTarget = boss;
			desc.effect = effect;
			desc.volume = -2;
			desc.cause = RankEffectCause.OTHER;
			desc.canPutFailMessage = false;
			desc.fStdMsg = true;
			desc.effectViewType = RankEffectViewType.ENABLE;
			var result = new Section_RankEffect.Result();
			new Section_RankEffect(GetCommonParam()).Execute(result, desc);
		}

		public class Description { }

		public class Result { }
	}
}