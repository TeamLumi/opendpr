namespace Dpr.UI
{
	public class TrainingItemStart : TrainingItemBase
	{
		// TODO
		public override void Setup() { }
		
		public override void Enable(bool enabled)
		{
			this._isEnabled = (enabled ? 1 : 0) & 1;
			SetAnimState();
		}
		
		public override void Select(bool enabled)
		{
			this._isSelected = (enabled ? 1 : 0) & 1;
			SetAnimState();
		}
		
		// TODO
		private void SetAnimState() { }
	}
}