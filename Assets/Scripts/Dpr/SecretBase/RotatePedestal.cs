using UnityEngine;

namespace Dpr.SecretBase
{
	public class RotatePedestal : MonoBehaviour
	{
		[SerializeField]
		private float speed = 0.5f;
		private float time;
		private Transform rotateNode;
		
		// TODO
		private void Update() { }
		
		// TODO
		public void SetRotateNode(Transform node) { }
		
		public void SetSpeed(float speed) {
		    this.speed = speed;
		}
	}
}