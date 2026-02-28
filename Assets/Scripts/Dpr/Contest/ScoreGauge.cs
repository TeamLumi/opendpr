using Dpr.SubContents;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class ScoreGauge : MonoBehaviour
	{
		[SerializeField]
		private RectTransform clearArrowRect;
		[SerializeField]
		private RectTransform markRect;
		[SerializeField]
		private Color baseColor;
		[SerializeField]
		private Color flashColor;
		[SerializeField]
		private float flickDuration = 360.0f;
		[SerializeField]
		private Material gaugeMat;
		private EffectEmitter fxEmitter = new EffectEmitter();
		private LockPlayFx lockNormalFxTimer = new LockPlayFx();
		private LockPlayFx lockLargeFxTimer = new LockPlayFx();
		private RectTransform leftFrameRect;
		private Image leftGaugeImage;
		private Image leftGaugeBgImage;
		private RectTransform rightFrameRect;
		private Image rightGaugeImage;
		private Image rightGaugeBgImage;
		private Color gaugeColor;
		private float successScoreRatio;
		private float totalWidth;
		private float goalRatio;
		private float currentRatio;
		private float addGaugeValue;
		private float addFadeValue;
		private float colorAngleValue;
		private bool playingGaugeFlash;
		
		public Vector3 MarkCenterPos { get => markRect.position; }
		
		// TODO
		public void Initialize(float addValue, float lockTime) { }
		
		private void SetComponents()
		{
			var uVar1 = ComponentExtensions.FindDeep(StringLiteral_8963,1);
			var uVar2 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.leftFrameRect = uVar2;
			uVar2 = GameObjectExtensions.FindDeep(uVar1,StringLiteral_8964,1);
			uVar2 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar2);
			this.leftGaugeImage = uVar2;
			uVar1 = GameObjectExtensions.FindDeep(uVar1,StringLiteral_8965,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.leftGaugeBgImage = uVar1;
			uVar1 = ComponentExtensions.FindDeep(StringLiteral_8966,1);
			uVar2 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.rightFrameRect = uVar2;
			uVar2 = GameObjectExtensions.FindDeep(uVar1,StringLiteral_8967,1);
			uVar2 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar2);
			this.rightGaugeImage = uVar2;
			uVar1 = GameObjectExtensions.FindDeep(uVar1,StringLiteral_8968,1);
			uVar1 = UnityEngine_GameObject__GetComponent<object>
			                  (uVar1);
			this.rightGaugeBgImage = uVar1;
		}
		
		public void OnFinalize()
		{
			this.fxEmitter.OnFinalize();
		}
		
		// TODO
		public void SetUp(float successScoreRatio, float initGaugeRatio) { }
		
		// TODO
		private EmitEffectParam[] GetHitFxParams() { return default; }
		
		// TODO
		public void SetScoreRatio(float ratio, EmitHeartPattern emitPattern) { }
		
		private void CheckSuccessRatio()
		{
			if ((!this.playingGaugeFlash) &&
			   (this.successScoreRatio <= this.goalRatio)) {
			  this.playingGaugeFlash = true;
			}
		}
		
		// TODO
		public void ResetParam(float ratio) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateGaugeAmount(float deltaTime) { }
		
		// TODO
		private void SetGaugeRatio(float scoreRatio) { }
		
		// TODO
		private float CalcLeftGaugeAmount(float scoreRatio) { return default; }
		
		// TODO
		private float CalcRightGaugeAmount(float scoreRatio) { return default; }
		
		// TODO
		private void UpdateColorFade(float deltaTime) { }
		
		// TODO
		private void SetColorRatio(float ratio) { }
		
		private float LerpColorFactor(float a, float b, float ratio)
		{
			return (b - a) * ratio + a;
		}
	}
}