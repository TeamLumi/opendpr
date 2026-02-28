using Effect;
using System;
using UnityEngine;

namespace Dpr.Contest
{
	public class StageEffect
	{
		private EffectInstance[] stageLightFxArray;
		private EffectData stageLightFxData;
		private EffectManager fxManager;
		private EffectParam[] monitorFxArray;
		private EffectParam confettiFxParam;
		private EffectParam resultLightFxParam;
		private Transform monitorFxParent;
		private int nowMonitorIndex;
		private int loadCount;
		private int loadedCount;
		
		public bool IsLoading { get => loadedCount < loadCount; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		public void ResetLoadCount()
		{
			this.loadCount = 0;
		}
		
		// TODO
		public void LoadStageLight(uint userRank, LightSetting[] lightDataArray, Vector3 offsetPos) { }
		
		// TODO
		public void PauseAllStageLight() { }
		
		public int NowMonitorIndex { get => nowMonitorIndex; }
		
		// TODO
		public float GetMonitorFxTime() { return default; }
		
		// TODO
		public void LoadMonitorEffects(Transform parent, Vector3 offsetPosition, int startMonitorIndex, EffectContestID[] monitorFxIDs) { }
		
		// TODO
		private void LoadMonitorFx(int index, EffectContestID effectID, bool playAwake, Vector3 offsetPosition) { }
		
		// TODO
		public void LoadConfettiFx() { }
		
		// TODO
		public void LoadResultSpotLightFx() { }
		
		// TODO
		private void LoadContestFx(EffectContestID effectID, Action<EffectData> onCompleteLoad) { }
		
		// TODO
		public ParticleSystem GetMonitorFx(int index) { return default; }
		
		// TODO
		public void SwitchMonitor() { }
		
		// TODO
		public void MoveMonitorPositionX(float moveX) { }
		
		// TODO
		public void PlayConfettiFx(Vector3 confettiPos) { }
		
		// TODO
		public void PlayResultLight(Vector3 lightPos) { }
		
		// TODO
		public void StopStageLightFx() { }
		
		// TODO
		public void PlayStageLightFx() { }
		
		// TODO
		public void StopMonitorFx() { }
		
		// TODO
		public void PlayMonitorFx() { }
		
		// TODO
		public void StopConfettiFx() { }

		private class EffectParam
		{
			public EffectData fxData;
			public EffectInstance instance;
		}
	}
}