using UnityEngine;

namespace Dpr.Contest
{
	public class VisualSection : MonoBehaviour
	{
		private ContestViewSystem contestViewSystem;
		private uint mainBgmID;
		private bool bPlayeSeq;
		private bool bStop;
		private bool bRunning;
		
		public void RestParam()
		{
			this.bRunning = false;
			this.bPlayeSeq = false;
			var uVar1 = this.gameObject;
			uVar1.SetActive(1);
		}
		
		// TODO
		public void Setup(uint mainBgmID, ContestViewSystem viewSystem) { }
		
		public void Stop()
		{
			this.bStop = true;
		}
		
		// TODO
		public void StartSection() { }
		
		// TODO
		public bool UpdateSection() { return default; }
	}
}