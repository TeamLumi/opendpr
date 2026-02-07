namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_CheckSpecialWazaAdditionalEffectOccur : Section
	{
		public Section_FromEvent_CheckSpecialWazaAdditionalEffectOccur(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            uint per = GetEventLauncher().Event_CheckSpecialWazaAdditionalPer(description.atkPokeID, description.defPokeID, description.defaultPer);
            result.isOccur = calc.IsOccurPer(per);
        }

		public class Description
		{
			public byte atkPokeID;
			public byte defPokeID;
			public byte defaultPer;
			
			public Description()
			{
				atkPokeID = PokeID.INVALID;
				defPokeID = PokeID.INVALID;
				defaultPer = 0;
			}
		}

		public class Result
		{
			public bool isOccur;
		}
	}
}