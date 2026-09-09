namespace NexPlugin
{
	public class ResultRange
	{
		internal uint offset;
		internal uint size;
		
		public ResultRange(uint uiOffset = 0, uint uiSize = 20)
		{
			offset = uiOffset;
			size = uiSize;
		}
		
		public void SetOffset(uint uiOffset = 0) {
		    this.offset = uiOffset;
		}
		
		public uint GetOffset() {
		    return offset;
		}
		
		public void SetSize(uint uiSize = 20) {
		    this.size = uiSize;
		}
		
		public uint GetSize() {
		    return size;
		}
		
		// TODO
		public static ResultRange operator ++(ResultRange r) { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}