using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatuePoseController : MonoBehaviour
	{
		private int MotionPrefixLength = "pm0000_00_00_".Length;
		private StatueEffectData statueData;
		private SkinnedMeshRenderer[] renderers;
		private Step step;
		
		public void Initialize(StatueEffectData statueData, SkinnedMeshRenderer[] renderers)
		{
			this.statueData = statueData;
			this.renderers = renderers;
			this.step = (Step)0;
			if (0 < (int)renderers.Length) {
			  var uVar3 = 0;
			  var uVar2 = renderers.Length & 0xffffffff;
			  do {
			    if (uVar2 <= uVar3) {
			    }
			    ExtensionMethods.SetActive(*(renderers + 0x20 + uVar3 * 8),0,0);
			    uVar2 = (ulong)renderers.Length;
			    uVar3 = uVar3 + 1;
			  } while ((long)uVar3 < (int)renderers.Length);
			}
		}
		
		// TODO
		private void LateUpdate() { }
		
		// TODO
		private void PlayAnimation() { }
		
		// TODO
		private void StopAnimation() { }
		
		// TODO
		private void DisableAnimator() { }
		
		// TODO
		private void OnEnable() { }

		private enum Step : int
		{
			FirstFrame = 0,
			PlayAnimation = 1,
			StopAnimation = 2,
			ShowModel = 3,
			DisableAnimator = 4,
			Idle = 5,
		}
	}
}