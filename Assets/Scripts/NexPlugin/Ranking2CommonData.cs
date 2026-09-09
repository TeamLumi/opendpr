using System.Collections.Generic;

namespace NexPlugin
{
	public class Ranking2CommonData
	{
		internal List<byte> binaryData;
		internal string userName;
		
		public Ranking2CommonData()
		{
			userName = "";
			binaryData = new List<byte>();
		}
		
		public string GetUserName() {
		    return userName;
		}
		
		// TODO
		public void SetUserName(string userName_) { }
		
		public List<byte> GetBinaryData() {
		    return binaryData;
		}
		
		// TODO
		public void SetBinaryData(List<byte> binaryData_) { }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}