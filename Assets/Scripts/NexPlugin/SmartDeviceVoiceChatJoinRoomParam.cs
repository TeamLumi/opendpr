namespace NexPlugin
{
	public class SmartDeviceVoiceChatJoinRoomParam
	{
		internal ulong sessionId;
		internal uint gameMode;
		internal uint channelId;
		
		public SmartDeviceVoiceChatJoinRoomParam()
		{
			sessionId = 0;
			gameMode = 0;
			channelId = 0;
		}
		
		public void SetSessionId(ulong sessionId_) {
		    this.sessionId = sessionId_;
		}
		
		public ulong GetSessionId() {
		    return sessionId;
		}
		
		public void SetGameMode(uint gameMode_) {
		    this.gameMode = gameMode_;
		}
		
		public uint GetGameMode() {
		    return gameMode;
		}
		
		public void SetChannelId(uint channelId_) {
		    this.channelId = channelId_;
		}
		
		public uint GetChannelId() {
		    return channelId;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}