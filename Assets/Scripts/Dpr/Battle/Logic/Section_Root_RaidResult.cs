namespace Dpr.Battle.Logic
{
	public sealed class Section_Root_RaidResult : Section
	{
		public Section_Root_RaidResult(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			this.m_pServerCmdPutter.Act_RaidResult();
		}

		public class Description { }

		public class Result { }
	}
}