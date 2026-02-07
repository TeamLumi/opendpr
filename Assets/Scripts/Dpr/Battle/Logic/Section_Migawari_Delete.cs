namespace Dpr.Battle.Logic
{
	public sealed class Section_Migawari_Delete : Section
	{
		public Section_Migawari_Delete(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM poke = description.poke;
			byte pokeID = poke.GetID();

			poke.MIGAWARI_Delete();
			GetServerCommandPutter().DeleteMigawari(pokeID);

			BtlPokePos pos = GetPokePos(poke);
			GetServerCommandPutter().Act_MigawariDelete(pos);
		}

		public class Description
		{
			public BTL_POKEPARAM poke;
			public bool canPutDefaultMessage = true;
		}

		public class Result { }
	}
}