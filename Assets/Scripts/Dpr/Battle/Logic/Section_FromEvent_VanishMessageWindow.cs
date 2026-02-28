namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_VanishMessageWindow : Section
	{
		public Section_FromEvent_VanishMessageWindow(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			this.m_pServerCmdPutter.Act_HideMessageWindow();
		}

		public class Description { }

		public class Result
		{
			public bool isSucceeded;
		}
	}
}