using UnityEngine;

namespace Dpr.Contest
{
	public sealed class AudienceGenerator : MonoBehaviour
	{
		private readonly Vector3 COPY_TARGET_POSITION = new Vector3(0.0f, -500.0f, 0.0f);

		[SerializeField]
		private GameObject[] copyTargetArray;
		[SerializeField]
		private Transform[] generateParentArray;

		private AudienceObj[] audienceArray;
		private GameObject copyParent;
		private bool bPlaying = true;
		
		// TODO
		private void Start() { }
		
		public void Play()
		{
			this.bPlaying = true;
		}
		
		public void Stop()
		{
			this.bPlaying = false;
		}
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void GenerateAudience() { }
		
		// TODO
		public void MovePositionX(float moveX, Camera camera) { }
		
		// TODO
		private void PostLateUpdate(float deltaTime) { }

		private struct AudienceObj
		{
			private Camera cameraPtr;
			private Transform targetTransform;
			private Mesh targetMesh;
			private Matrix4x4[] meshMatrixArray;
			private Matrix4x4[] calcMeshMatrixArray;
			private Material mat;
			
			// TODO
			public void Create(MeshRenderer originalMeshRenderer, Vector3[] posArray, Quaternion[] rotArray) { }
			
			// TODO
			public void MovePosX(float moveX, Camera camera) { }
			
			// TODO
			public void OnUpdate() { }
			
			// TODO
			private Matrix4x4 Multiply(ref Matrix4x4 lhs, ref Matrix4x4 rhs) { return default; }
			
			// TODO
			public void OnFinalize() { }
		}
	}
}