namespace Dpr.Contest.Dbg
{
	public class MenuInput
	{
		private GameController.LogicalInput localInput = new GameController.LogicalInput();
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		private void AssignInputGoNextScene()
		{
			this.localInput.Assign(0,0x800,0);
		}
		
		private void AssignInputOpenMenu()
		{
			this.localInput.Assign(1,0x400,0);
		}
		
		// TODO
		public bool IsInputGoNextScene() { return default; }
		
		// TODO
		public bool IsInputOpenMenu() { return default; }
		
		// TODO
		private bool IsButtonPush(int assignValue) { return default; }

		private enum KeyAssignId : int
		{
			GoNextScene = 0,
			OpenMenu = 1,
		}

		private class KeyAssignValue
		{
			public const int GoNextScene = 1;
			public const int OpenMenu = 2;
		}
	}
}