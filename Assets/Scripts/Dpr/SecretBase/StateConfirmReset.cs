namespace Dpr.SecretBase
{
	public class StateConfirmReset : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private int selectIndex = -1;
		private string[] labelNames = new string[]
		{
            "DLP_underground_505", "DLP_underground_418",
        };
		
		public StateConfirmReset() : base(StatuePlacementEditController.State.ConfirmReset)
		{
			// Empty
		}
		
		// TODO
		public override void Enter(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Execute(StatuePlacementEditController owner) { }
		
		public override void Exit(StatuePlacementEditController owner)
		{
			MsgWindowManager.CloseMsg(0);
		}
	}
}