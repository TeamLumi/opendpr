using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigFossilSceneLauncher : MonoBehaviour
	{
		private DigFossilController scene;
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		public IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void OnDestroy() { }
		
		private void OnUpdate(float deltaTime)
		{
			this.scene.OnUpdate();
		}
	}
}