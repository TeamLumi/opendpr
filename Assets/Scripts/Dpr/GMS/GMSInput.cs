using UnityEngine;

namespace Dpr.GMS
{
	public class GMSInput
	{
		public static GMSInput input;
		private GameController.LogicalInput localInput = new GameController.LogicalInput();
		
		// TODO
		public static void CreateInstance() { }
		
		// TODO
		public static void DestroyInstance() { }
		
		// TODO
		public void Subscribe() { }
		
		// TODO
		public void Remove() { }
		
		private void AssignKeyLeft()
		{
			this.localInput.Assign(0,0x11000,0);
		}
		
		private void AssignKeyRight()
		{
			this.localInput.Assign(1,0x44000,0);
		}
		
		private void AssignKeyUp()
		{
			this.localInput.Assign(2,0x22000,0);
		}
		
		private void AssignKeyDown()
		{
			this.localInput.Assign(3,0x88000,0);
		}
		
		private void AssignKeyDecide()
		{
			this.localInput.Assign(4,0x301,0);
		}
		
		private void AssignKeyCancel()
		{
			this.localInput.Assign(5,2,0);
		}
		
		private void AssignKeyFarCamera()
		{
			this.localInput.Assign(6,8,0);
		}
		
		private void AssignKeyNearCamera()
		{
			this.localInput.Assign(7,4,0);
		}
		
		private void AssignKeySpeed()
		{
			this.localInput.Assign(8,0x40,0);
		}
		
		private void AssignKeyPlayCry()
		{
			this.localInput.Assign(9,0x80,0);
		}
		
		// TODO
		public static bool RepeatLeft() { return default; }
		
		// TODO
		public static bool ReleaseLeft() { return default; }
		
		// TODO
		public static bool RepeatRight() { return default; }
		
		// TODO
		public static bool ReleaseRight() { return default; }
		
		// TODO
		public static bool RepeatUp() { return default; }
		
		// TODO
		public static bool ReleaseUp() { return default; }
		
		// TODO
		public static bool RepeatDown() { return default; }
		
		// TODO
		public static bool ReleaseDown() { return default; }
		
		// TODO
		public static bool PushDecide() { return default; }
		
		// TODO
		public static bool PushCancel() { return default; }
		
		// TODO
		public static bool PushFarCamera() { return default; }
		
		// TODO
		public static bool PushNearCamera() { return default; }
		
		// TODO
		public static bool OnSpeedUp() { return default; }
		
		// TODO
		public static bool IsPushPlayCry() { return default; }
		
		// TODO
		public static Vector2 Analog { get; }
		
		// TODO
		private bool IsPush(int assignValue) { return default; }
		
		// TODO
		private bool IsRepeat(int assignValue) { return default; }
		
		// TODO
		private bool IsRelease(int assignValue) { return default; }
		
		// TODO
		private bool IsOn(int assignValue) { return default; }

		private enum KeyAssignId : int
		{
			Left = 0,
			Right = 1,
			Up = 2,
			Down = 3,
			Decide = 4,
			Cancel = 5,
			FarCamera = 6,
			NearCamera = 7,
			SpeedUp = 8,
			PlayCry = 9,
		}

		private class KeyAssignIdValue
		{
			public const int Left = 1;
			public const int Right = 2;
			public const int Up = 4;
			public const int Down = 8;
			public const int Decide = 16;
			public const int Cancel = 32;
			public const int FarCamera = 64;
			public const int NearCamera = 128;
			public const int SpeedUp = 256;
			public const int PlayCry = 512;
		}
	}
}