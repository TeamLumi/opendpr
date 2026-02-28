namespace Dpr.Battle.View.Systems
{
	public struct TrainerTalkParam
	{
		public byte clientId;
		public uint param;
		public bool isKeyWait;
		
		public static TrainerTalkParam Factory()
		{
			return ZEXT816(0);
		}
	}
}