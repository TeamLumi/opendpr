using Dpr.SequenceEditor;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.SealPreview
{
	public sealed class SealPreviewController : MonoBehaviour
	{
		private const ArenaID ARENA_ID = ArenaID.G023;

		public static CapsuleInfo PreviewCapsuleInfo;
		public static CapsuleInfo PreviewSubCapsuleInfo;

        public static bool IsLoadFailed { get; private set; }

        private static bool isDispose;
		[SerializeField]
		private SequenceCameraObject sequenceCameraObject;
		[SerializeField]
		private EnvironmentController environmentController;
		[SerializeField]
		private SceneConnector connector;
		private bool isPause;
		private int _subSeq;
		private SealPreviewSetupParam _setupParam;
		private SealPreviewViewSystem _sealPreviewViewSystem;
		private Transform _cluster;

		private SealPreviewState CurrentPreviewState { get; set; }
		
		// TODO
		public static void RequestDispose() { }
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		private IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void Dispose() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void SwitchBattleRule() { }
		
		// TODO
		public void SwitchPlayAndPause() { }
		
		// TODO
		public SealPreviewSetupParam GetSealPreviewSetupParam() { return default; }
		
		public SequenceCameraObject GetSequenceCameraObject() {
		    return sequenceCameraObject;
		}

		private enum CameraMode : int
		{
			Single = 0,
			Double = 1,
			Length = 2,
		}

		private enum SealPreviewState : int
		{
			None = 0,
			Initialized = 1,
			ThrowBall = 2,
			SequenceEnd = 3,
			FadeOut = 4,
		}
	}
}