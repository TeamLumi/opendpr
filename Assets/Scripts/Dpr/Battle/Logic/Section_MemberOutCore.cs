namespace Dpr.Battle.Logic
{
	public sealed class Section_MemberOutCore : Section
	{
		public Section_MemberOutCore(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM outPoke = description.outPoke;
			ushort effectNo = description.effectNo;

			if (outPoke == null || !outPoke.IsFightEnable())
			{
				pResult.isOutSuccessed = false;
				return;
			}

			endGMode(outPoke);
			clearPokeDependEffect(outPoke);
			putMemberOut(outPoke, effectNo);

			pResult.isOutSuccessed = true;
		}

		private void putMemberOut(BTL_POKEPARAM outPoke, ushort effectNo)
		{
			byte pokeID = outPoke.GetID();
			BtlPokePos pos = GetPokePos(outPoke);

			GetServerCommandPutter().ClearForOut(pokeID);
			GetServerCommandPutter().Act_MemberOut(pos, effectNo);

			outPoke.Clear_ForOut();
		}

		private void clearPokeDependEffect(BTL_POKEPARAM poke)
		{
			var desc = new Section_ClearPokeDependEffect.Description();
			desc.poke = poke;
			var result = new Section_ClearPokeDependEffect.Result();
			new Section_ClearPokeDependEffect(GetCommonParam()).Execute(result, desc);
		}

		private void endGMode(BTL_POKEPARAM poke)
		{
			if (poke.IsGMode())
			{
				poke.EndGMode();
			}
		}

		public class Description
		{
			public BTL_POKEPARAM outPoke;
			public ushort effectNo;
			
			public Description()
			{
				outPoke = null;
				effectNo = 0;
			}
		}

		public class Result
		{
			public bool isOutSuccessed;
		}
	}
}