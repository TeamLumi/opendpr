using UnityEngine;

namespace Dpr.SubContents
{
	public class ColiseumPlayerMove
	{
		private const float WAIT_TIME = 0.5f;
		private const float MOVE_SCALE = 0.2f;

		private FieldPlayerEntity player;
		private MoveState currentState;
		private Vector3 goalPosition;
		private float waitTimer;
		private float timeScale;
		private int goalPointNumber;
		
		public void Initialize(FieldPlayerEntity player)
		{
			this.player = player;
			this.currentState = (MoveState)0;
		}
		
		public void OnFinalize()
		{
			this.player = null;
		}
		
		public bool IsStateNone { get => currentState == MoveState.None; }
		public bool IsStateFinishArrive { get => currentState == MoveState.FinishArrive; }
		public bool IsStateFinishLeave { get => currentState == MoveState.FinishLeave; }
		
		// TODO
		public void StartControlPlayer() { }
		
		// TODO
		public void StopControlPlayer(bool isChangeMotionIdle = true) { }
		
		public void StopPlayerMove()
		{
			this.currentState = (MoveState)0;
			this.player.PlayIdle();
		}
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void StartMoveToPoint(Vector3 goalPosition, int goalPointNumber) { }
		
		// TODO
		private void UpdateArrive(float deltaTime) { }
		
		// TODO
		private void UpdateArrived(float deltaTime) { }
		
		// TODO
		public void StartLeaveFromPoint(Vector3 goalPosition) { }
		
		// TODO
		private void UpdateLeave(float deltaTime) { }
		
		// TODO
		private bool Waiting(float deltaTime, float waitTime) { return default; }

		private enum MoveState : int
		{
			None = 0,
			Arrive = 1,
			Arrived = 2,
			FinishArrive = 3,
			Leave = 4,
			FinishLeave = 5,
		}
	}
}