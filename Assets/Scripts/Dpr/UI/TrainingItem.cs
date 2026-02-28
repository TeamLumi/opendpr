using UnityEngine;

namespace Dpr.UI
{
	public class TrainingItem : TrainingItemBase
	{
		protected static readonly int animState2CheckOff = Animator.StringToHash("CheckMark_Off");
		protected static readonly int animState2CheckOn = Animator.StringToHash("CheckMark_On");

        private bool _isChecked;
		
		// TODO
		public override void Setup() { }
		
		// TODO
		public void Check(bool enabled) { }
		
		public bool IsCheck()
		{
			return this._isChecked;
		}
	}
}