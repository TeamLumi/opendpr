namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_GetWeight : Section
	{
		public Section_FromEvent_GetWeight(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			ushort weight = poke.GetWeight();
			int ratio = GetEventLauncher().svEvent_GetWeightRatio(poke);
			if (ratio != 0)
			{
				weight = (ushort)calc.MulRatio(weight, ratio);
			}
			if (weight == 0)
			{
				weight = 1;
			}
			result.weight = weight;
		}

		public class Description
		{
			public byte pokeID;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
			}
		}

		public class Result
		{
			public uint weight;
		}
	}
}