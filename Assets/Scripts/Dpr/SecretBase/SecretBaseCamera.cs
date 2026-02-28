using UnityEngine;

namespace Dpr.SecretBase
{
	public class SecretBaseCamera : MonoBehaviour
	{
		[SerializeField]
		private Transform lookAt;
		[SerializeField]
		private Camera mainCamera;
		[SerializeField]
		private Camera pedestalCamera;
		[SerializeField]
		private SecretBaseMasterDataManager masterData;
		private int viewIndex;
		
		// TODO
		public void SetViewIndex(int index) { }
		
		// TODO
		public void IncrementViewIndex() { }
		
		// TODO
		public void ResetLookAt() { }
		
		// TODO
		public void TargetLookAt(PlacementData target) { }
		
		public void SetRenderTexture(RenderTexture texture)
		{
			ExtensionMethods.SetActive(this.pedestalCamera,1);
			ExtensionMethods.SetActive(this.mainCamera,0);
			this.pedestalCamera.targetTexture = texture;
		}
	}
}