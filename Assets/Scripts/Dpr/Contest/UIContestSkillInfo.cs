using DG.Tweening;
using Dpr.SubContents;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.Contest
{
	public class UIContestSkillInfo : MonoBehaviour
	{
		[SerializeField]
		private GameObject template;
		private UILaunchSkillLog[] skillLogArray;
		private Sprite[] chainCountSprArray;
		private RectTransform commandIconTransform;
		private RectTransform chainCountContentRect;
		private GameObject acceptChainGaugeObj;
		private Image acceptChainGaugeImage;
		private DOTweenAnimation[] chainCountTweenArray;
		private DOTweenAnimation[] commandAppealTween;
		private EffectEmitter fxEmitter = new EffectEmitter();
		private GameObject chainCountObj;
		private Image chainCountImage;
		private CanvasGroup appealCanvasGroup;
		private float showSkillLogDuration;
		private float showChainCountDuration;
		private float showChainCountTimer;
		private int showLogCount;
		private bool bIsShowCommand;
		private bool bIsShowChainCount;
		private bool bPlayingCommandAppealTween;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		private void InitChainCount() { }
		
		// TODO
		private void SetChainCountSprArray() { }
		
		// TODO
		public bool IsReady() { return default; }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void ResetParam() { }
		
		// TODO
		public void Setup(ContestConfigDatas configDatas, ContestPlayerEntity[] entities, bool isTutorial) { }
		
		// TODO
		private void SetSkillUser(int logIndex, ContestPlayerEntity entity, Transform parent) { }
		
		public void UseContestSkill(int playerIndex, int chainCount, bool isShowChainCount, bool canChain, bool isShowChainCountFx, bool isSameUserWazaType)
		{
			if (!canChain) {
			  if ((this.acceptChainGaugeObj.activeSelf & 1) != 0) {
			    this.acceptChainGaugeObj.SetActive(0);
			  }
			}
			else {
			  if ((this.acceptChainGaugeObj.activeSelf & 1) == 0) {
			    this.acceptChainGaugeObj.SetActive(1);
			  }
			  0x3f800000.fillAmount = this.acceptChainGaugeImage;
			}
			if (isShowChainCount) {
			  ShowChainCount(chainCount,(isShowChainCountFx ? 1 : 0) & 1);
			  HideUserContestSkill();
			}
			ShowLaunchSkillLog(playerIndex,(isSameUserWazaType ? 1 : 0) & 1);
		}
		
		// TODO
		private void ShowChainCount(int chainCount, bool isShowFx) { }
		
		private void PlayChainCountFx()
		{
			this.chainCountContentRect.position;
			this.fxEmitter.PlayFx(0x19,0);
		}
		
		private void StopChainCountFx()
		{
			0.StopFx(this.fxEmitter,0x19);
		}
		
		// TODO
		public void HideUserContestSkill() { }
		
		// TODO
		public void PlayCommandAppealTween() { }
		
		// TODO
		private void StopCommandAppealTween() { }
		
		private void SetCommandActive(bool active)
		{
			if (((!this.bIsShowCommand ^ active) & 1) != 0) {
			}
			this.bIsShowCommand = (active ? 1 : 0) & 1;
			ExtensionMethods.SetActive(this.commandIconTransform,(active ? 1 : 0) & 1);
		}
		
		private void ShowAcceptChainGauge()
		{
			if ((this.acceptChainGaugeObj.activeSelf & 1) == 0) {
			  this.acceptChainGaugeObj.SetActive(1);
			}
			0x3f800000.fillAmount = this.acceptChainGaugeImage;
		}
		
		public bool IsShowLog { get => showLogCount > 0; }
		
		// TODO
		private void ShowLaunchSkillLog(int playerIndex, bool isSameUserWazaType) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateUIChainCount(float deltaTime) { }
		
		// TODO
		public void OnCompleteBackWards() { }
		
		private bool IsUpdateChainGauge { get => acceptChainGaugeObj.activeSelf; }
		
		// TODO
		public void UpdateChainGauge(float gaugeRatio) { }
		
		// TODO
		public void UpdateChainGaugeHideTime(float deltaTime) { }
		
		public void HideChainGauge()
		{
			if ((this.acceptChainGaugeObj.activeSelf & 1) != 0) {
			  this.acceptChainGaugeObj.SetActive(0);
			}
		}
		
		private void SetAcceptChainGaugeActive(bool active)
		{
			if (((this.acceptChainGaugeObj.activeSelf ^ active) & 1) != 0) {
			  this.acceptChainGaugeObj.SetActive((active ? 1 : 0) & 1);
			}
		}
	}
}