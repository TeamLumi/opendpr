namespace Dpr.SecretBase
{
	public class StateSelectFromField : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private int selectIndex = -1;
		private string[] labelNames = new string[]
		{
            "DLP_underground_502", "DLP_underground_503", "DLP_underground_505", "DLP_underground_418",
        };
		
		public StateSelectFromField() : base(StatuePlacementEditController.State.SelectFromField)
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