using System;
using UnityEngine;

namespace Dpr.SubContents
{
	public class TimeLineComponent : MonoBehaviour
	{
		protected Action OnStopTimeLine;
		protected Action OnResumeTimeLine;
		
		public void SetCallBack(Action OnStop, Action OnResume)
		{
			OnStopTimeLine = OnStop;
			OnResumeTimeLine = OnResume;
		}
		
		public void StopTimeLine()
		{
			if (this.OnStopTimeLine != null) {
			  this.OnStopTimeLine.Invoke();
			}
		}
		
		public void ResumeTimeLine()
		{
			if (this.OnResumeTimeLine != null) {
			  this.OnResumeTimeLine.Invoke();
			}
		}
	}
}