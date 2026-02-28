namespace Dpr.SecretBase
{
	public class StateSelectFromStatueWindow : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private PlacementData placement;
		private int selectIndex = -1;
		
		public StateSelectFromStatueWindow() : base(StatuePlacementEditController.State.SelectFromStatueWindow)
		{
			// Empty
		}
		
		public void Enter_SelectFromStatueWindow(PlacementData data)
		{
			this.placement = data;
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