using Dpr.Message;
using UnityEngine;

namespace Dpr.UI
{
	public class UIBattleMatchingTimer : MonoBehaviour
	{
		[SerializeField]
		private UIText _textTimer;
		[SerializeField]
		private UIText _textRemaining;
		[SerializeField]
		private UIText _textCount;
		[SerializeField]
		private GameObject _objCount;

		private MessageMsgFile _msgFile;
		private int _maxCount;
		
		// TODO
		public void SetTimerMessage(string label) { }
		
		// TODO
		public void SetTimerMessage(string msbt, string label) { }
		
		// TODO
		public void SetActive(bool active) { }
		
		// TODO
		public void SetActiveChild(bool active) { }
		
		// TODO
		public void SetTimer(string minutes, string seconds) { }
		
		// TODO
		public void SetActiveRemainingText(bool active) { }
		
		// TODO
		public void RemainingWarningText(bool warning = true) { }
		
		public void SetupCount(int max)
		{
			this._maxCount = max;
			if (0 < max) {
			  this._objCount.SetActive(1);
			  SetCount();
			}
			this._objCount.SetActive(0);
		}
		
		// TODO
		public void SetCount(int count) { }
	}
}