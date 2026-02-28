using Dpr.SecretBase;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using XLSXContent;

namespace Dpr.DigFossil
{
	public class DigStoneBoxResult : IDigStoneBoxResult
	{
		private Context context;
		private Action onFinishDirection;
		private Step step;
		private StoneBoxDirection stoneBoxDirection;
		private GameObject statueModel;
		private StatueEffectData statueData;
		private GameObject bgModel;
		private int statueLoadWaitCount;
		private bool isMaxStatue;
		private StatueEffectRawData.Sheettable statue;

		private const string animatonClipAssetName = "objects/ob2000_00";
		private const string bgModelAssetName = "bg/arenas/ground/eventarea012";
		private const string bgModelPrefabName = "EVENTAREA012";
		
		// TODO
		public IEnumerator Initialize(Context context) { return default; }
		
		// TODO
		public void Start(Action onFinishDirection) { }
		
		// TODO
		private void LotteryAndLoadStatue() { }
		
		// TODO
		private StatueEffectRawData.Sheettable LotteryStatue() { return default; }
		
		// TODO
		private void LoadStatue(StatueEffectRawData.Sheettable statue) { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void ChangeStep(Step step) { }

		public class Context
		{
			public DigMasterDataManager.StoneBoxData boxData;
			public Transform boxPos;
			public DigMasterDataManager masterDataManager;
			public IDigMessage message;
			public IDigFade fade;
			public IDigAudioManager audioManager;
			public IDigStatueCameraSelector cameraSelector;
			public IDigBoard digBoard;
			public DigFossilController.DigParam digParam;
			public StatueModelLoader statueModelLoader;
			public DigEffectManager effectManager;
			public DirectionParam directionParam;
			public DebugParam debugParam;
			
			public Context(DigMasterDataManager.StoneBoxData boxData, Transform boxPos, DigMasterDataManager masterDataManager, IDigMessage message, IDigFade fade, IDigAudioManager audioManager, IDigStatueCameraSelector cameraSelector, IDigBoard digBoard, DigFossilController.DigParam digParam, StatueModelLoader statueModelLoader, DigEffectManager effectManager)
			{
				this.boxData = boxData;
				this.boxPos = boxPos;
				this.masterDataManager = masterDataManager;
				this.message = message;
				this.fade = fade;
				this.audioManager = audioManager;
				this.cameraSelector = cameraSelector;
				this.digBoard = digBoard;
				this.digParam = digParam;
				this.statueModelLoader = statueModelLoader;
				this.effectManager = effectManager;
			}
		}

		public class DirectionParam
		{
			public float boxOpenAnimationSpeed;
			public float effectFireDelay;
			public Vector2 blackIn;
			public Vector2 whiteOut;
			public Vector2 whiteIn;
			
			public DirectionParam(float boxOpenAnimationSpeed, float effectFireDelay, Vector2 blackIn, Vector2 whiteOut, Vector2 whiteIn)
			{
				this.boxOpenAnimationSpeed = boxOpenAnimationSpeed;
				this.effectFireDelay = effectFireDelay;
				this.blackIn = blackIn;
				this.whiteOut = whiteOut;
				this.whiteIn = whiteIn;
			}
		}

		public class DebugParam
		{
			public int statueId;
			
			public DebugParam(int statueId)
			{
				this.statueId = statueId;
			}
		}

		public class LotteryInfo
		{
			public LotteryInfo(StatueEffectRawData.Sheettable info, DigMasterDataManager.RatioId ratioId)
			{
				Info = info;

				switch (ratioId)
				{
					case DigMasterDataManager.RatioId.Diamond:         Ratio = info.ratio1; break;
					case DigMasterDataManager.RatioId.Diamond_Dialga:  Ratio = info.ratio2; break;
					case DigMasterDataManager.RatioId.Diamond_Zenkoku: Ratio = info.ratio3; break;
					case DigMasterDataManager.RatioId.Pearl:           Ratio = info.ratio4; break;
					case DigMasterDataManager.RatioId.Pearl_Palkia:    Ratio = info.ratio5; break;
					case DigMasterDataManager.RatioId.Pearl_Zenkoku:   Ratio = info.ratio6; break;
				}
			}
			
			public StatueEffectRawData.Sheettable Info { get; private set; }
			public float Ratio { get; set; }
		}

		private enum Step : int
		{
			Init = 0,
			IdleStatueLoding = 1,
			FadeIn = 2,
			ShowBoxGetMessage = 3,
			IdleBoxGetMessage = 4,
			ShowBoxOpenMessage = 5,
			IdleBoxOpenMessage = 6,
			BoxOpenDirection = 7,
			ShowStatueWhbiteIn = 8,
			ShowStatueGetMessage = 9,
			IdleStatueGetMessage = 10,
			ShowStatueMaxMessage = 11,
			IdleStatueMaxMessage = 12,
			End = 13,
		}

		public class StoneBoxDirection : MonoBehaviour
		{
			private PlayableGraph graph;
			private AnimationClipPlayable clipPlayable;
			private Context context;
			
			// TODO
			public void Init(AnimationClip clip, Context context) { }
			
			// TODO
			public void BoxOpen(Vector3 effectPos, Action onCompletedCallback) { }
			
			private void PlayBoxOpenAnimation()
			{
				PlayableGraph.Play(ref this.graph);
			}
			
			// TODO
			private IEnumerator BoxOpenDirection(Vector3 effectPos, Action onCompletedCallback) { return default; }
		}
	}
}