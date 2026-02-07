namespace Dpr.Battle.Logic
{
	public sealed class EffectSummarizer
	{
		private ServerCommandQueue m_pQueue;
		private ushort m_reservedPos_Effect;
		private ushort m_reservedPos_Message;
		
		public EffectSummarizer(ServerCommandQueue pQueue)
		{
			m_pQueue = pQueue;
			m_reservedPos_Effect = 0;
			m_reservedPos_Message = 0;
		}
		
		public void Reserve()
		{
			m_reservedPos_Effect = m_pQueue.ReservePutPos(ServerCommand.ACT_EFFECT_SIMPLE);
			m_reservedPos_Message = m_pQueue.ReservePutPos(ServerCommand.MSG_SET);
		}

		public void Put(in GShockEffectParam param)
		{
			put_Effect(in param);
			put_Message(in param);
		}

		private void put_Effect(in GShockEffectParam param)
		{
			if (!param.IsEffectedAny())
				return;

			ushort effectNo = param.GetEffectNo((BtlPokePos)0);
			m_pQueue.Put_ToReservedPos(m_reservedPos_Effect, ServerCommand.ACT_EFFECT_SIMPLE, new int[] { (int)effectNo });
		}

		private void put_Message(in GShockEffectParam param)
		{
			if (!param.IsEffectedAny())
				return;

			m_pQueue.Put_ToReservedPos(m_reservedPos_Message, ServerCommand.MSG_SET, new int[] { 0 });
		}
	}
}