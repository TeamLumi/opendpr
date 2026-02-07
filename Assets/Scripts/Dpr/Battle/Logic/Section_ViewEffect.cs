namespace Dpr.Battle.Logic
{
	public sealed class Section_ViewEffect : Section
	{
		private const int EFF_SIMPLE = 0;
		private const int EFF_POS = 1;
		private const int EFF_VECTOR = 2;
		
		public Section_ViewEffect(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			int type = EFF_SIMPLE;
			if (description.pos_from != description.pos_to)
			{
				type = EFF_VECTOR;
			}
			else if (description.pos_from != BtlPokePos.POS_NULL)
			{
				type = EFF_POS;
			}

			ServerCommandPutter scp = GetServerCommandPutter();
			switch (type)
			{
				case EFF_SIMPLE:
					scp.Act_EffectSimple(description.effectNo);
					break;
				case EFF_POS:
					scp.EffectByPos(description.pos_from, description.effectNo);
					break;
				case EFF_VECTOR:
					scp.EffectBySide(description.pos_from, description.pos_to, description.effectNo);
					break;
			}
		}

		public class Description
		{
			public ushort effectNo;
			public BtlPokePos pos_from;
			public BtlPokePos pos_to;
			public bool fQueResereved;
			public uint reservedPos;
		}

		public class Result { }
	}
}