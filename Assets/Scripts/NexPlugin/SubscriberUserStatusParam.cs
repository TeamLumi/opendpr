using System.Collections.Generic;

namespace NexPlugin
{
	public class SubscriberUserStatusParam
	{
		internal byte key;
		internal List<byte> value;
		
		public SubscriberUserStatusParam()
		{
			Reset();
		}
		
		public void SetKey(byte key_) {
		    this.key = key_;
		}
		
		public byte GetKey() {
		    return key;
		}
		
		// TODO
		public void SetValue(List<byte> _value) { }
		
		// TODO
		public List<byte> GetValue() { return default; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}