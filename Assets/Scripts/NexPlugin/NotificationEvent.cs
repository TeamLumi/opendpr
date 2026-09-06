namespace NexPlugin
{
	public class NotificationEvent
	{
		internal ulong param1;
		internal ulong param2;
		internal Common.NotificationEvents type;
		internal uint subType;
		internal string stringParam;
		internal ulong pid;
		
		public ulong GetSource() {
		    return pid;
		}
		
		public Common.NotificationEvents GetType() {
		    return type;
		}
		
		public uint GetSubType() {
		    return subType;
		}
		
		public ulong GetParam1() {
		    return param1;
		}
		
		public ulong GetParam2() {
		    return param2;
		}
		
		public string GetStringParam() {
		    return stringParam;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		internal string ToString() { return default; }
	}
}