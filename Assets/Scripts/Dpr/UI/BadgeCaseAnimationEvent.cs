using UnityEngine;

namespace Dpr.UI
{
	public class BadgeCaseAnimationEvent : MonoBehaviour
	{
		private BadgeCaseObject badgeCaseObject;
		
		// TODO
		public void PlayOpenCloseSe(int state) { }
		
		public void Register(BadgeCaseObject badgeCaseObject)
		{
			this.badgeCaseObject = badgeCaseObject;
		}
		
		// TODO
		public void PlayBadgeConditionEffects() { }
		
		// TODO
		public void StopBadgeConditionEffects() { }
	}
}