using Dpr.Message;
using TMPro;
using UnityEngine;

namespace Dpr.UI
{
	public class MenuHeader : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _timeText;
		[SerializeField]
		private GameObject _timerObj;
		[SerializeField]
		private string useMsbtName = "";
		[SerializeField]
		private string timeLabelName = "";

		private MessageMsgFile _useMsgFile;
		
		public void Setup()
		{
			this._useMsgFile = null;
			if ((this._timerObj.activeSelf & 1) != 0) {
			  this._timerObj.SetActive(0);
			}
		}
		
		public void HideTimer()
		{
			this._useMsgFile = null;
			if ((this._timerObj.activeSelf & 1) != 0) {
			  this._timerObj.SetActive(0);
			}
		}
		
		private void SetTimerActive(bool active)
		{
			if (((this._timerObj.activeSelf ^ active) & 1) != 0) {
			  this._timerObj.SetActive((active ? 1 : 0) & 1);
			}
		}
		
		// TODO
		public void SetTime(int minut, int second) { }
		
		// TODO
		public void SetTime(string minutStr, string secondStr) { }
		
		// TODO
		private bool CheckHaveMsgFile() { return default; }
	}
}