namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RecoverPP : Section
	{
		public Section_FromEvent_RecoverPP(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
            if (!description.isDeadPokeEnable && poke.IsDead())
            {
                result.isSuccessed = false;
                return;
            }
            result.isSuccessed = true;
            GetServerCommandPutter().RecoverPP(poke, description.wazaIdx, description.volume, !description.isSurfacePP);
            GetServerCommandPutter().Message(in description.successMessage);
        }

		public class Description
		{
			public byte pokeID;
			public byte wazaIdx;
			public byte volume;
			public bool isSurfacePP;
			public bool isDeadPokeEnable;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				wazaIdx = 0;
				volume = 0;
				isSurfacePP = false;
				isDeadPokeEnable = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}