namespace NexPlugin
{
	public class SmartDeviceVoiceChatShowAppPageResult
	{
		internal SmartDeviceVoiceChat.ShowAppResultStatus status;
		
		public SmartDeviceVoiceChatShowAppPageResult()
		{
			status = 0;
		}
		
		public void SetStatus(SmartDeviceVoiceChat.ShowAppResultStatus status_) {
		    this.status = status_;
		}
		
		public SmartDeviceVoiceChat.ShowAppResultStatus GetStatus() {
		    return status;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}