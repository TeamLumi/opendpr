using Dpr.Battle.View.Objects;

namespace Dpr.Contest
{
	public class WazaSequencePlayer
	{
		private SceneObjectManager objManager;
		private BOCamera mainCamera;
		private BOCamera wazaCamera;
		private ContestViewSystem wazaViewSystemPtr;
		private WazaSeqState seqState;
		private int userIndex;
		private bool hasRequestPlaySequence;
		
		// TODO
		public void SetupWazaSequence() { }
		
		public void ResetParam()
		{
			this.seqState = (WazaSeqState)0;
		}
		
		public bool IsRunning { get => seqState == WazaSeqState.Active || seqState == WazaSeqState.Playing; }
		
		// TODO
		private void ActivateWazaCamera() { }
		
		private void DeactivateWazaCamera()
		{
			var uVar1 = Dpr_SequenceEditor_SequenceCameraObject__get_PostProcess
			                  (this.wazaCamera,0);
			uVar1.Reset();
			uVar1.enabled = 0;
			uVar1 = Dpr_SequenceEditor_SequenceCameraObject__get_PostProcess
			                  (this.wazaCamera,0);
			uVar1.enabled = 0;
			this.wazaCamera.IsEnabled = 0;
			uVar1 = Dpr_SequenceEditor_SequenceCameraObject__get_PostProcess
			                  (this.mainCamera,0);
			uVar1.enabled = 1;
		}
		
		public void PlayWazaSequence(int userIndex)
		{
			this.seqState = (WazaSeqState)2;
			this.userIndex = userIndex;
			this.hasRequestPlaySequence = true;
		}
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void UpdateStateActive() { }
		
		// TODO
		private void UpdateStatePlaying() { }
		
		// TODO
		public void OnLateUpdate() { }

		private enum WazaSeqState : int
		{
			Wait = 0,
			Start = 1,
			Active = 2,
			Playing = 3,
			End = 4,
		}
	}
}