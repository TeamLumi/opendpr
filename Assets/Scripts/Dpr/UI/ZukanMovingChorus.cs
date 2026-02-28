namespace Dpr.UI
{
	public class ZukanMovingChorus : ZukanMovingEffecter
	{
		public void OnUpdate(float deltaTime)
		{
			GetSensorValue();
			deltaTime.UpdateEffecter(0xdd4f5eb3,0);
		}
		
		// TODO
		public float GetSensorValue() { return default; }
	}
}