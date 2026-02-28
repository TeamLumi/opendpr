using Effect;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.SubContents
{
	public class EffectEmitter
	{
		private Dictionary<int, EmitEffectData> fxTable = new Dictionary<int, EmitEffectData>();
		private EffectManager fxManager;
		private int loadCount;
		private int loadedCount;
		private bool bReady;
		
		public bool IsReady { get => bReady; }
		
		// TODO
		public void Initialize(Transform fxParent, EmitEffectParam[] loadEffectIDArray) { }
		
		// TODO
		public void OnFinalize() { }

		// TODO
		public void LoadFx(EmitEffectParam param, Transform fxParent, [Optional] Action onCompletedLoad) { }
		
		private void OnCompleteLoad()
		{
			if (this.loadedCount <= this.loadCount) {
			  this.bReady = true;
			}
		}
		
		// TODO
		public EffectInstance PlayFx(EffectContestID fxID, Vector3 emitPos, [Optional] Action onComplete) { return default; }
		
		// TODO
		public void StopFx(EffectContestID fxID, float fadeTime = 0.0f) { }

		private class EmitEffectData
		{
			private EffectManager effectManagerPtr;
			private Transform effectManagerTransform;
			private EffectData fxData;
			private EffectInstance[] fxInstArray;
			private Transform parent;
			private int useCount;
			private int emptyIndex;
			
			public bool HasEmptyIndex { get => useCount < fxInstArray.Length; }
			
			// TODO
			public void Setup(Transform parent, EffectManager effectManager, EffectData fxData, int count) { }
			
			// TODO
			public EffectInstance PlayFx(Vector3 emitPos, Action onComplete) { return default; }
			
			// TODO
			public void StopFx(float fadeTime = 0.0f) { }
			
			// TODO
			public void ReleaseAll() { }
			
			// TODO
			private int FindEmptyIndex() { return default; }
		}
	}
}