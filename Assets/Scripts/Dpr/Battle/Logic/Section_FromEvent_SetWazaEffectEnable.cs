namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetWazaEffectEnable : Section
	{
		public Section_FromEvent_SetWazaEffectEnable(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			GetActionSharedData().wazaEffectParams.SetEnable();
		}

		public class Description { }

		public class Result { }
	}
}