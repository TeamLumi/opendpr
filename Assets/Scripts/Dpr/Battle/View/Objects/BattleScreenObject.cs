using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public sealed class BattleScreenObject : BtlvBehaviour
	{
		[SerializeField]
		private Camera[] _cameras = new Camera[2];
		private RefCounted[] _refCounteds;
		
		// TODO
		public void Initialize(Transform cluster) { }
		
		public void UnInitialize()
		{
			this._cameras = null;
			this._refCounteds = null;
		}
		
		// TODO
		public Camera GetCamera(CameraType type) { return default; }
		
		// TODO
		public void Release(CameraType type) { }
		
		// TODO
		public void AllReleaseForce() { }

		public enum CameraType : int
		{
			ScreenEffect = 0,
			ForeFrontEffect = 1,
		}
	}
}