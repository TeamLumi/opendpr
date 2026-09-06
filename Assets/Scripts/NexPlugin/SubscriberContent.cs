using System.Collections.Generic;

namespace NexPlugin
{
	public class SubscriberContent
	{
		internal ulong contentId;
		internal ulong pid;
		internal NpDateTime postTime;
		internal List<uint> topics;
		internal List<byte> binary;
		internal string message;
		
		public SubscriberContent()
		{
			topics = new List<uint>();
			binary = new List<byte>();
			message = "";
		}
		
		public ulong GetContentId() {
		    return contentId;
		}
		
		public string GetMessage() {
		    return message;
		}
		
		public List<byte> GetBinary() {
		    return binary;
		}
		
		public ulong GetPosterPrincipalId() {
		    return pid;
		}
		
		public List<uint> GetTopic() {
		    return topics;
		}
		
		// TODO
		public uint GetTopicSingle() { return default; }
		
		// TODO
		public NpDateTime GetPostDateTime() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}