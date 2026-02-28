namespace Dpr.SecretBase
{
	public class StateWaitStatueWindow : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private LocalState state;
		private float timer;
		private PlacementData placement;
		
		public StateWaitStatueWindow() : base(StatuePlacementEditController.State.WaitStatueWindow)
		{
			// Empty
		}
		
		public void Enter_WaitStatueWindow(PlacementData statue)
		{
			this.placement = statue;
		}
		
		// TODO
		public override void Enter(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Execute(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Exit(StatuePlacementEditController owner) { }

		private enum LocalState : int
		{
			Press = 0,
			Spread = 1,
		}
	}
}