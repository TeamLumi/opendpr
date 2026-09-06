namespace NexPlugin
{
	public class SubscriberGetContentParam
	{
		internal uint size;
		internal uint offset;
		internal ulong minimumContentId;
		internal uint topic;
		
		public SubscriberGetContentParam()
		{
			topic = Subscriber.INVALID_RESERVED_TOPIC_NUM;
			size = Subscriber.MAX_FOLLOWING_SIZE;
			offset = 0;
			minimumContentId = 0;
		}
		
		public void SetTopic(uint topic_) {
		    this.topic = topic_;
		}
		
		public uint GetTopic() {
		    return topic;
		}
		
		public void SetSize(uint size_) {
		    this.size = size_;
		}
		
		public uint GetSize() {
		    return size;
		}
		
		public void SetOffset(uint offset_) {
		    this.offset = offset_;
		}
		
		public uint GetOffset() {
		    return offset;
		}
		
		public void SetMinimumContentId(ulong minimumContentId_) {
		    this.minimumContentId = minimumContentId_;
		}
		
		public ulong GetMinimumContentId() {
		    return minimumContentId;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}