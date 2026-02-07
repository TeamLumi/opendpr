namespace Dpr.Battle.Logic
{
	public class BtlAiAllowance : BtlAIBaseScript
	{
		protected override void main()
		{
			_ = string.Format("■PAWN allowanceAI start ...wazaNo = {0}[{1}], score={2}\n", CurrentWazaNo(), (int)CurrentWazaNo(), p_Score);
			main_proc();
            _ = string.Format("■PAWN allowanceAI score = {0}\n", p_Score);
        }
		
		private void main_proc()
		{
			// Allowance AI does not modify scores - intentionally empty
		}
	}
}