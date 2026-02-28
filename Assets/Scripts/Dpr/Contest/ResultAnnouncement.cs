using DG.Tweening;
using Dpr.SubContents;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class ResultAnnouncement : MonoBehaviour
	{
		[SerializeField]
		private Sprite[] rankNumSprArray;
		private DOTweenAnimation titleFadeTween;
		private Image resultTitleImage;
		private DOTweenAnimation rankGaugeFadeTween;
		private Image rankGaugeImage;
		private Image rankNumImage;
		private EffectEmitter fxEmitter = new EffectEmitter();
		private RankGaugeData gaugeData;
		private ShowMessageWindow resultMsg = new ShowMessageWindow();
		private ResultSettings settingsData;
		private Sprite rankLogoSpr;
		internal AnimStateID currentState;
		private ResultID resultId;
		private float waitTimer;
		private float gaugeTimer;
		private int nextRankPoint;
		private int addValue;
		internal bool bRunning;
		private bool isRankup;
		private bool isMultiMode;
		
		public void Initialize(ResultSettings setting)
		{
			this.settingsData = setting;
			this.waitTimer = 0;
			this.currentState = (AnimStateID)0;
			InitResultTitle();
			InitRankGauge();
			ExtensionMethods.SetActive(0);
		}
		
		// TODO
		private void InitResultTitle() { }
		
		// TODO
		private void InitRankGauge() { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool IsReady { get => fxEmitter.IsReady; }
		
		// TODO
		public void LoadResultFx(ResultID resultID) { }
		
		// TODO
		public void Setup(RankGaugeData gaugeData, Sprite spr, bool isMultiMode, ResultID resultId) { }
		
		// TODO
		public void StartAnimation() { }
		
		public bool OnUpdate(float deltaTime)
		{
			if ((int)this.currentState == 3) {
			  UpdateWait();
			  return this.bRunning;
			}
			if ((int)this.currentState != 2) {
			  if ((int)this.currentState == 1) {
			    UpdateGauge();
			  }
			  return this.bRunning;
			}
			UpdateRankupAnim();
			return this.bRunning;
		}
		
		// TODO
		private void UpdateGauge(float deltaTime) { }
		
		private bool CheckRankUp()
		{
			return this.nextRankPoint <=
			       this.addValue + this.gaugeData.startPoint;
			return false;
		}
		
		private void SetGaugeRatio(float gaugeRatio)
		{
			this.rankGaugeImage.set_fillAmount();
		}
		
		// TODO
		private void SetGaugeAnimParam() { }
		
		// TODO
		private int GetNextRankPoint() { return default; }
		
		private bool IsMaxRank()
		{
			var uVar1 = this.gaugeData.rankDataArray.Length;
			if ((int)uVar1 <= (int)this.gaugeData.userRank) {
			  return true;
			}
			if (this.gaugeData.userRank < uVar1) {
			  return this.gaugeData.rankDataArray + (int)this.gaugeData.userRank * 8[0].Length >> 0x1f;
			}
		}
		
		// TODO
		private void StopGaugeSE() { }
		
		// TODO
		private void UpdateRankupAnim() { }
		
		// TODO
		private void ChangeUserRank() { }
		
		// TODO
		private void UpdateWait(float deltaTime) { }
		
		// TODO
		private void StartFadeout() { }
		
		// TODO
		public void OnCompleteTitleFade() { }
		
		// TODO
		private float CalcInitGaugeRatio() { return default; }
		
		public void OnCompleteTitleFadeBackWards()
		{
			this.bRunning = false;
		}
		
		// TODO
		public void OnCompleteRankInfoFade() { }

		internal enum AnimStateID : int
		{
			TweenAnim = 0,
			GaugeAnim = 1,
			RankupAnim = 2,
			Wait = 3,
			End = 4,
		}
	}
}