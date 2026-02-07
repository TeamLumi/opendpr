using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DecideWazaTargetAuto : Section
	{
		public Section_FromEvent_DecideWazaTargetAuto(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
            result.targetPos = calc.DecideWazaTargetAuto(GetMainModule(), GetBattleEnv().GetPokeCon(), poke, description.waza);
        }

		public class Description
		{
			public byte pokeID;
			public WazaNo waza;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public BtlPokePos targetPos;
		}
	}
}