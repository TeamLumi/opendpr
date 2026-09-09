namespace Dpr.SecretBase
{
	public static class StatuePlacementEditInput
	{
		private static int inputUp { get => GameController.ButtonMask.Up | GameController.ButtonMask.StickLUp | GameController.ButtonMask.StickRUp; }
		
		private static int inputDown { get => GameController.ButtonMask.Down | GameController.ButtonMask.StickLDown | GameController.ButtonMask.StickRDown; }
		
		private static int inputLeft { get => GameController.ButtonMask.Left | GameController.ButtonMask.StickLLeft | GameController.ButtonMask.StickRLeft; }
		
		private static int inputRight { get => GameController.ButtonMask.Right | GameController.ButtonMask.StickLRight | GameController.ButtonMask.StickRRight; }
		
		// TODO
		public static bool Left { get; }
		
		// TODO
		public static bool Right { get; }
		
		// TODO
		public static bool Up { get; }
		
		// TODO
		public static bool Down { get; }
		
		// TODO
		public static bool ReleasePad { get; }
		
		// TODO
		public static bool Decide { get; }
		
		// TODO
		public static bool Cancel { get; }
		
		// TODO
		public static bool OpenFilter { get; }
		
		// TODO
		public static bool ApplyFilter { get; }
		
		// TODO
		public static bool ResetFilter { get; }
		
		// TODO
		public static bool RotateStatue { get; }
		
		// TODO
		public static bool RemoveAllStatue { get; }
		
		// TODO
		public static bool PutAwayPedestal { get; }
		
		// TODO
		public static bool ShowStatueList { get; }
	}
}