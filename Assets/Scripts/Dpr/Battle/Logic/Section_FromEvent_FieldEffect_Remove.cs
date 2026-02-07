namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_FieldEffect_Remove : Section
	{
		public Section_FromEvent_FieldEffect_Remove(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = removeFieldEffect(description.effect, description.pDependPoke);
		}

		private bool removeFieldEffect(EffectType effect, BTL_POKEPARAM pDependPoke)
		{
			ServerCommandPutter scp = GetServerCommandPutter();

			if (pDependPoke != null)
			{
				return scp.RemoveFieldEffect_DependPoke(pDependPoke, effect);
			}
			else
			{
				return scp.RemoveFieldEffect(effect);
			}
		}

		public class Description
		{
			public EffectType effect;
			public BTL_POKEPARAM pDependPoke;
			
			public Description()
			{
				pDependPoke = null;
				effect = EffectType.EFF_NULL;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}