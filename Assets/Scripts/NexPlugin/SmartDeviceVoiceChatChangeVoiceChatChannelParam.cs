namespace NexPlugin
{
	public class SmartDeviceVoiceChatChangeVoiceChatChannelParam
	{
		internal ulong roomId;
		internal uint channelId;
		
		public SmartDeviceVoiceChatChangeVoiceChatChannelParam()
		{
			roomId = 0;
			channelId = 0;
		}
		
		public void SetChannelId(uint channelId_) {
		    this.channelId = channelId_;
		}
		
		public uint GetChannelId() {
		    return channelId;
		}
		
		public void SetRoomId(ulong roomId_) {
		    this.roomId = roomId_;
		}
		
		public ulong GetRoomId() {
		    return roomId;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}