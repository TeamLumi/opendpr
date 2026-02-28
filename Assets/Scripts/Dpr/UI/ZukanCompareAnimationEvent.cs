using AK;
using Audio;
using UnityEngine;

namespace Dpr.UI
{
	public class ZukanCompareAnimationEvent : MonoBehaviour
	{
		private static readonly uint[] CompareWeightSeIds = new uint[]
        {
            EVENTS.UI_ZUKAN_POKE_LAND,    EVENTS.UI_ZUKAN_PL_FLY,    EVENTS.UI_ZUKAN_PL_LAND,   EVENTS.UI_ZUKAN_PL_FLY_HIGH,
            EVENTS.UI_ZUKAN_PL_FLY_HIGH2, EVENTS.UI_ZUKAN_PL_FLY_17, EVENTS.UI_ZUKAN_PL_FLY_18, EVENTS.UI_ZUKAN_PL_LAND_2,
        };
        private static readonly uint[] CompareHeightSeIds = new uint[]
		{
			EVENTS.UI_MONITOR_NOISE, EVENTS.UI_MONITOR_NOISE_2,
		};

		private AudioInstance currentAudioInstance;
		
		// TODO
		public void PlayCompareWeightSe(int id) { }
		
		// TODO
		public void PlayCompareHeightSe(int id) { }
		
		public void StopSe()
		{
			if (this.currentAudioInstance != null) {
			  this.currentAudioInstance.Stop();
			}
		}
	}
}