using System.Collections.Generic;

namespace NexPlugin
{
	public class SubscriberPostContentParam
	{
		internal List<uint> topics;
		internal List<byte> binary;
		internal string message;
		
		public SubscriberPostContentParam()
		{
			Reset();
		}
		
		// TODO
		public void SetTopic(List<uint> topics_) { }
		
		// TODO
		public void SetTopic(uint topic_) { }
		
		public List<uint> GetTopic() {
		    return topics;
		}
		
		// TODO
		public uint GetTopicSingle() { return default; }
		
		// TODO
		public void SetMessage(string message_) { }
		
		public string GetMessage() {
		    return message;
		}
		
		// TODO
		public void SetBinary(List<byte> binary_) { }
		
		public List<byte> GetBinary() {
		    return binary;
		}
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}