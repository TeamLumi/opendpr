namespace Dpr.Battle.Logic
{
	public sealed class Section_CalcActionPriority : Section
	{
		public Section_CalcActionPriority(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			PokeAction pAction = description.pokeAction;
			DominantPriority dominantPri = description.dominantPriority;
			BtlSpecialPri specialPri = description.specialPriority;

			OperationPriority operationPri = calcOperationPriority(pAction);
			byte wazaPri = calcWazaPriority(in pAction);
			ushort agility = calcAgility(pAction.bpp);

			pResult.priority = ActPri.Make(dominantPri, operationPri, wazaPri, (byte)specialPri, agility);
		}

		private OperationPriority calcOperationPriority(PokeAction pAction)
		{
			switch (pAction.actionCategory)
			{
				case PokeActionCategory.Escape:
					return OperationPriority.ESCAPE;
				case PokeActionCategory.PokeChange:
					return OperationPriority.POKECHANGE;
				case PokeActionCategory.Item:
					return OperationPriority.ITEM;
				case PokeActionCategory.Cheer:
					return OperationPriority.CHEER;
				case PokeActionCategory.GStart:
					return OperationPriority.G_START;
				case PokeActionCategory.Fight:
					return OperationPriority.FIGHT;
				case PokeActionCategory.Skip:
					return OperationPriority.SKIP;
				default:
					return OperationPriority.NONE;
			}
		}

		private ushort calcAgility(BTL_POKEPARAM poke)
		{
			bool fTrickRoomEnable = GetBattleEnv().GetFieldStatus().CheckEffect(EffectType.EFF_TRICKROOM);
			return GetEventLauncher().Event_CalcAgility(poke, fTrickRoomEnable);
		}

		private byte calcWazaPriority(in PokeAction pokeAction)
		{
			if (pokeAction.actionCategory != PokeActionCategory.Fight)
			{
				return 0;
			}

			int pri = WAZADATA.GetPriority(pokeAction.actionParam_Fight.waza);
			return (byte)(pri + 7);
		}

		public class Description
		{
			public PokeAction pokeAction;
			public DominantPriority dominantPriority;
			public BtlSpecialPri specialPriority;
			
			public Description()
			{
				pokeAction = null;
				dominantPriority = DominantPriority.DEFAULT;
				specialPriority = BtlSpecialPri.BTL_SPPRI_DEFAULT;
			}
		}

		public class Result
		{
			public uint priority;
		}
	}
}