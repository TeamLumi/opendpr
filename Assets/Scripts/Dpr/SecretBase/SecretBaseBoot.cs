using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class SecretBaseBoot : MonoBehaviour
	{
		[SerializeField]
		private SecretBaseController scene;
		private AssetRequestOperation playerRequestOperation;
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		public IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private IEnumerator Load() { return default; }
		
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