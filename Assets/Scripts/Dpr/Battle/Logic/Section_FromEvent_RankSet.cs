namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RankSet : Section
	{
		public Section_FromEvent_RankSet(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			if (description.attack != 0) poke.RankSet(BTL_POKEPARAM.ValueID.BPP_ATTACK_RANK, description.attack);
			if (description.defence != 0) poke.RankSet(BTL_POKEPARAM.ValueID.BPP_DEFENCE_RANK, description.defence);
			if (description.sp_attack != 0) poke.RankSet(BTL_POKEPARAM.ValueID.BPP_SP_ATTACK_RANK, description.sp_attack);
			if (description.sp_defence != 0) poke.RankSet(BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE_RANK, description.sp_defence);
			if (description.agility != 0) poke.RankSet(BTL_POKEPARAM.ValueID.BPP_AGILITY_RANK, description.agility);
			if (description.hit_ratio != 0) poke.RankSet(BTL_POKEPARAM.ValueID.BPP_HIT_RATIO, description.hit_ratio);
			if (description.avoid_ratio != 0) poke.RankSet(BTL_POKEPARAM.ValueID.BPP_AVOID_RATIO, description.avoid_ratio);
			poke.SetCriticalRank(description.critical_rank);
			GetServerCommandPutter().RankSet8(description.pokeID, description.attack, description.defence, description.sp_attack, description.sp_defence, description.agility, description.hit_ratio, description.avoid_ratio, description.critical_rank);
			result.isSuccessed = true;
		}

		public class Description
		{
			public byte pokeID;
			public byte attack;
			public byte defence;
			public byte sp_attack;
			public byte sp_defence;
			public byte agility;
			public byte hit_ratio;
			public byte avoid_ratio;
			public byte critical_rank;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				attack = 0;
				defence = 0;
				sp_attack = 0;
				sp_defence = 0;
				agility = 0;
				hit_ratio = 0;
				avoid_ratio = 0;
				critical_rank = 0;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}