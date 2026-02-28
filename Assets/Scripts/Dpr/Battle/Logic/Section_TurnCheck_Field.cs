namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnCheck_Field : Section
	{
		public Section_TurnCheck_Field(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		private bool incTurnCount(EffectType effect)
		{
			this.m_pServerCmdPutter.IncFieldTurnCount(effect)
			;
			return false;
		}
		
		// TODO
		private void removeEffect(EffectType effect) { }

		public class Description { }

		public class Result { }
	}
}