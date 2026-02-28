namespace Dpr.SecretBase
{
	public class StatePlacement : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private int placement_dir;
		private int tmp_placement_dir;
		private int dir_backup;
		private PlacementData placement;
		private bool bIsPrevField;
		
		public StatePlacement() : base(StatuePlacementEditController.State.Placement)
		{
			// Empty
		}
		
		public void Enter_Placement(PlacementData statue, bool isField)
		{
			this.placement_dir = statue.Length;
			var uVar1 = statue.Length;
			this.placement = statue;
			this.dir_backup = uVar1;
			this.bIsPrevField = (isField ? 1 : 0) & 1;
		}
		
		// TODO
		public override void Enter(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Execute(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Exit(StatuePlacementEditController owner) { }
	}
}