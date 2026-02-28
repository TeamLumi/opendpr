using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UnderGround.LightStone
{
	public class UgLightStoneGauge : MonoBehaviour
	{
		[SerializeField]
		private UgLightStoneCount lightStoneCount;
		[SerializeField]
		private Image gauge;
		[SerializeField]
		private Animator rainbowEffectAnim;
		
		private void Start()
		{
			this.lightStoneCount.Initialize();
			this.lightStoneCount.SetDenominato(0x28);
			this.lightStoneCount.SetNumerator(0);
			0.fillAmount = this.gauge;
		}
		
		public void Initialize()
		{
			this.lightStoneCount.Initialize();
			this.lightStoneCount.SetDenominato(0x28);
			this.lightStoneCount.SetNumerator(0);
			0.fillAmount = this.gauge;
		}
		
		// TODO
		public void UpdateStoneNum() { }
		
		// TODO
		public void UpdateBonusState() { }
	}
}