using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_NotEffective : Section
	{
		public Section_WazaExec_NotEffective(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM poke = GetPokeParam(description.pokeID);
			GetServerCommandPutter().Message_NoEffect(poke);
		}

		public class Description
		{
			public byte pokeID;
			public WazaNo wazaID;
			public ActionDesc pActionDesc;
			
			public Description()
			{
				pActionDesc = null;
				pokeID = PokeID.INVALID;
				wazaID = WazaNo.NULL;
			}
		}

		public class Result { }
	}
}