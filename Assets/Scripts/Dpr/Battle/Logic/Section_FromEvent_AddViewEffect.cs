namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_AddViewEffect : Section
	{
		public Section_FromEvent_AddViewEffect(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
		{
			addVewEffect(description.effectNo, description.pos_from, description.pos_to, description.isQueueReserved, description.reservedQueuePos);

			if (description.isMessageWindowVanish)
			{
				GetServerCommandPutter().Act_HideMessageWindow();
			}

			if (description.afterMessage.IsEnable())
			{
				GetServerCommandPutter().Message(description.afterMessage);
			}
		}

		private void addVewEffect(ushort effectNo, BtlPokePos effectPos_from, BtlPokePos effectPos_to, bool isQueueReserved, uint reservedQueuePos)
		{
			ServerCommandPutter scp = GetServerCommandPutter();

			if (effectPos_from == BtlPokePos.POS_NULL && effectPos_to == BtlPokePos.POS_NULL)
			{
				scp.Act_EffectSimple(effectNo);
			}
			else if (effectPos_to == BtlPokePos.POS_NULL)
			{
				scp.EffectByPos(effectPos_from, effectNo);
			}
			else
			{
				scp.Act_EffectByVector(effectPos_from, effectPos_to, effectNo);
			}
		}

		public class Description
		{
			public ushort effectNo;
			public BtlPokePos pos_from;
			public BtlPokePos pos_to;
			public ushort reservedQueuePos;
			public bool isQueueReserved;
			public bool isMessageWindowVanish;
			public StrParam afterMessage = new StrParam();
			
			public Description()
			{
				effectNo = 0;
				pos_from = BtlPokePos.POS_NULL;
				pos_to = BtlPokePos.POS_NULL;
				reservedQueuePos = 0;
				isQueueReserved = false;
				isMessageWindowVanish = false;
			}
		}

		public class Result { }
	}
}