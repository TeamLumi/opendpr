namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetWazaEffectEnable : Section
	{
		public Section_FromEvent_SetWazaEffectEnable(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			var lVar1 = result.GetActionSharedData();
			lVar1.Length.SetEnable();
		}

		public class Description { }

		public class Result { }
	}
}