using System;
using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigFallBoardDirection : MonoBehaviour
	{
		[SerializeField]
		private RectTransform curtain;
		[SerializeField]
		private float fallSpeed = 20.0f;
		private Action onFinishDirection;
		private Vector3 defaultRootPos;
		private Vector3 velocity = Vector3.zero;
		private bool isCompleted = true;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		public void StartDirection(Action onFinishDirection) { }
		
		public void SetActive(bool bisActive)
		{
			ExtensionMethods.SetActive(this.curtain,(bisActive ? 1 : 0) & 1);
		}
		
		// TODO
		public float GetDirectionTime() { return default; }
		
		// TODO
		private void Start() { }
	}
}