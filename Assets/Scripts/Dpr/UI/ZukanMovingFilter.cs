using Audio;
using System.Runtime.InteropServices;

namespace Dpr.UI
{
	public class ZukanMovingFilter : ZukanMovingEffecter
	{
		public void OnUpdate(float deltaTime, [Optional] AudioInstance voiceInstance)
		{
			GetSensorValue();
			deltaTime.UpdateEffecter(0x4ffc13af,1,voiceInstance);
		}
		
		// TODO
		public float GetSensorValue() { return default; }
	}
}