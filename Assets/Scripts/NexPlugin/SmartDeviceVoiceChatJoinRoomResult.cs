namespace NexPlugin
{
	public class SmartDeviceVoiceChatJoinRoomResult
	{
		internal ulong roomId;
		
		public SmartDeviceVoiceChatJoinRoomResult()
		{
			roomId = 0;
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