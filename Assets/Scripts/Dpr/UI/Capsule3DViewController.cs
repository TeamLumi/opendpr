using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class Capsule3DViewController : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
	{
		private const string CapsuleObjectAssetName = "objects/ob1015_00";
		private const string SealObjectAssetName = "objects/ob1015_01";
		private const float RotateSpeed = 3.0f;

		[SerializeField]
		private Camera bgCamera;
		[SerializeField]
		private Transform modelCameraRoot;
		[SerializeField]
		private Camera modelCamera;
		[SerializeField]
		private Transform modelRoot;
		[SerializeField]
		private RectTransform bgRoot;
		[SerializeField]
		private EnvironmentController environmentController;
		[SerializeField]
		private EnvironmentSettings environmentSettings;
		[SerializeField]
		private DefaultPositionAndRotation listModeDefault;
		[SerializeField]
		private DefaultPositionAndRotation editModeDefault;
		[Header("-----3Dシールオブジェクトの調整-----")]
		[SerializeField]
		private Vector3 sealScale = new Vector3(0.5f, 0.5f, 0.5f);
		[SerializeField]
		private float offsetPositionZ = 0.002f;

		private RenderTexture renderTexture;
		private Transform capsuleTransform;
		private Transform modelCameraTransform;
		private Vector3 hitCapsulePosition;
		private Vector3 hitCapsuleNormal;
		private List<Seal3DObject> sealObjects;
		private GameObject capsuleObject;
		private GameObject seal3DObjectPrefab;
		private RaycastHit[] raycastHits;
		private RaycastHit dummyRaycastHit;
		private DefaultPositionAndRotation currentDefault;
		private bool isLoadedCapsuleObject;
		private bool isLoadedSealObject;
		
		public float CapsuleRadius { get; private set; }
		public bool IsIntialized { get => isLoadedCapsuleObject && isLoadedSealObject; }
		public bool IsHitCapsule { get; private set; }
		
		// TODO
		public void OnViewportChange(int screenWidth, int screenHeight) { }
		
		// TODO
		public void Initialize(RawImage rawImage) { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void SetEnviromentControllerActive(bool isActive) { }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		public void SetCapsuleActive(bool isActive)
		{
			this.capsuleObject.SetActive((isActive ? 1 : 0) & 1);
		}
		
		// TODO
		public IEnumerator Redraw() { return default; }
		
		// TODO
		public void Setup(CapsuleInfo capsuleInfo, bool isResetView) { }
		
		public void SetBG(RectTransform rectTransform)
		{
			rectTransform.SetParent(this.bgRoot,0);
			GameObject.SetActive(this.bgCamera.gameObject,0,0);
			GameObject.SetActive(this.bgCamera.gameObject,1,0);
		}
		
		// TODO
		public void ShowListMode() { }
		
		// TODO
		public void ShowEditMode() { }
		
		// TODO
		public void Rotation(float x, float y) { }
		
		// TODO
		public void ResetRotation() { }
		
		// TODO
		public Vector3 GetAffixSealPosition() { return default; }
		
		// TODO
		public Vector3 GetAffixSealPosition(Seal3DObject seal3DObject) { return default; }
		
		// TODO
		public Vector3 GetScreenPosition(Seal3DObject seal3DObject) { return default; }
		
		// TODO
		public RaycastHit Raycast(Vector3 screenPosition, out Seal3DObject seal3DObject)
		{
			seal3DObject = default;
			return default;
		}
		
		// TODO
		public void AffixSeal(int affixSealId, int sealId) { }
		
		// TODO
		public void AffixSealObject(Seal3DObject seal3DObject) { }
		
		// TODO
		private void AffixSeal(int affixSealId, int sealId, Vector3 affixDataPosition) { }
		
		// TODO
		private void CreateCapsuleObject() { }
		
		// TODO
		private void LoadSealObjectPrefab() { }
		
		// TODO
		private Seal3DObject GetSealObject() { return default; }
		
		// TODO
		private Vector3 ConvertAffixSealPointToWorldPoint(Vector3 affixSealPoint) { return default; }
		
		// TODO
		private Vector3 ConvertWorldPointToAffixSealPoint(Vector3 worldPoint) { return default; }
		
		[Serializable]
		private class DefaultPositionAndRotation
		{
			[SerializeField]
			private Vector3 capsuleObjectPosition = Vector3.zero;
			[SerializeField]
			private Vector3 capsuleObjectRotation = Vector3.zero;
            [SerializeField]
			private Vector3 modelCameraRootPosition = Vector3.zero;
            [SerializeField]
			private Vector3 modelCameraRootRotation = Vector3.zero;
            [SerializeField]
			private Vector3 modelCameraPosition = Vector3.zero;
            [SerializeField]
			private Vector3 modelCameraRotation = Vector3.zero;
			
			public Vector3 CapsuleObjectPosition { get => capsuleObjectPosition; }
			public Quaternion CapsuleObjectRotation { get; private set; }
			public Vector3 ModelCameraRootPosition { get => modelCameraRootPosition; }
			public Quaternion ModelCameraRootRotation { get; private set; }
			public Vector3 ModelCameraPosition { get => modelCameraPosition; }
			public Quaternion ModelCameraRotation { get; private set; }
			
			// TODO
			public void Initialize() { }
		}
	}
}