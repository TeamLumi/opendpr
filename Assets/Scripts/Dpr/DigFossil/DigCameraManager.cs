using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigCameraManager : MonoBehaviour
	{
		[SerializeField]
		private Camera mainCamera;
		[SerializeField]
		private DigStatueCameraSelector resultCamera;
		
		public void SetCamera(CameraSet set)
		{
			if ((int)set == 2) {
			  GameObject.SetActive(this.resultCamera.gameObject,1,0);
			}
			else {
			  if (((int)set != 1) && ((int)set != 0)) {
			  }
			  GameObject.SetActive(this.mainCamera.gameObject,1,0);
			}
			this.resultCamera = this.resultCamera.gameObject;
			this.resultCamera.SetActive(0);
		}

		public enum CameraSet : int
		{
			Game = 0,
			ItemResult = 1,
			BoxResult = 2,
		}
	}
}