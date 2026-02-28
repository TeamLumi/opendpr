using Dpr.UI;

namespace Dpr.UnderGround.UgFather
{
	public class UgFatherHealing : UgFatherBase
	{
		private float waitTime;
		private const float HealingWaitTime = 1;
		private ContextMenuItem selectedItem;
		private State state;
		private ContextMenuID[] contextMenuIds = new ContextMenuID[] { ContextMenuID.UNDERGROUND_REST, ContextMenuID.UNDERGROUND_CANCEL };
		
		// TODO
		public override void OnTalkEvent() { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		private void ShowPcContextMenu() { }
		
		// TODO
		private void ChangeState(State state) { }
		
		private void EventEnd()
		{
			this.state = (State)0;
			if (this.onEventEndCallback != 0) {
			  OnEventEnd.Invoke();
			}
		}

		private enum State : int
		{
			None = 0,
			ChoicesMessage = 1,
			BeginMessage = 2,
			BeginMessageWait = 3,
			HealingFadOut = 4,
			HealingWait = 5,
			HealingFadIn = 6,
			EndMessage = 7,
			EndMessageWait = 8,
		}
	}
}