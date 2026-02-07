namespace Dpr.Battle.Logic
{
	public class BtlAiStrong : BtlAIBaseScript
	{
		protected override void main()
		{
			_ = string.Format("■PAWN strongAI start ...wazaNo = {0}[{1}], score={2}\n", CurrentWazaNo(), (int)CurrentWazaNo(), p_Score);
			main_proc();
			_ = string.Format("■PAWN strongAI score = {0}\n", p_Score);
		}

		private void main_proc()
		{
			int result = Strong_exception();
			if (result != 0)
				return;

			result = Strong_KinomiCheck();
			if (result != 0)
				return;
		}

		private int Strong_exception()
		{
			return 0;
		}

		private int Strong_KinomiCheck()
		{
			return 0;
		}
	}
}