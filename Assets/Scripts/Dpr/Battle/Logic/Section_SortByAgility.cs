namespace Dpr.Battle.Logic
{
	public sealed class Section_SortByAgility : Section
	{
		public Section_SortByAgility(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			PokeSet targets = description.targets;
			uint count = targets.GetCount();
			if (count <= 1)
			{
				return;
			}
			bool fTrickRoomEnable = GetBattleEnv().GetFieldStatus().CheckEffect(EffectType.EFF_TRICKROOM);
			for (uint i = 0; i < count - 1; i++)
			{
				for (uint j = i + 1; j < count; j++)
				{
					BTL_POKEPARAM pokeI = targets.Get(i);
					BTL_POKEPARAM pokeJ = targets.Get(j);
					ushort agiI = GetEventLauncher().Event_CalcAgility(pokeI, fTrickRoomEnable);
					ushort agiJ = GetEventLauncher().Event_CalcAgility(pokeJ, fTrickRoomEnable);
					if (agiJ > agiI)
					{
						targets.Swap((byte)i, (byte)j);
					}
					else if (agiJ == agiI)
					{
						if (calc.GetRand(2) == 0)
						{
							targets.Swap((byte)i, (byte)j);
						}
					}
				}
			}
		}

		public class Description
		{
			public PokeSet targets;
		}

		public class Result { }
	}
}