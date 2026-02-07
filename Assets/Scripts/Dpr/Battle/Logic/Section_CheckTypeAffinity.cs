using Pml;
using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckTypeAffinity : Section
	{
		public Section_CheckTypeAffinity(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			uint count = description.targets.GetCount();
			for (int i = 0; i < (int)count; i++)
			{
				BTL_POKEPARAM target = description.targets.Get((byte)i);
				checkTypeAffinity(out TypeAffinity.AffinityID typeAff, out bool isNoEffectByFloating,
					description.attacker, target, description.wazaParam);

				if (description.affinityRecorder != null)
				{
					description.affinityRecorder.Add(target.GetID(), typeAff, isNoEffectByFloating);
				}

				if (typeAff == TypeAffinity.AffinityID.TYPEAFF_0)
				{
					description.targets.Remove(target);
					i--;
					count--;
				}
			}
		}

		public void checkTypeAffinity(out TypeAffinity.AffinityID pTypeAffinity, out bool pIsNoEffectByFloatingStatus, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam)
		{
			pIsNoEffectByFloatingStatus = false;

			pTypeAffinity = GetEventLauncher().Event_CheckDamageAffinity(attacker, defender, wazaParam.wazaType, false);

			if (pTypeAffinity == TypeAffinity.AffinityID.TYPEAFF_0)
			{
				if ((PokeType)wazaParam.wazaType == PokeType.JIMEN)
				{
					if (GetEventLauncher().Event_CheckFloating(defender, true))
					{
						pIsNoEffectByFloatingStatus = true;
					}
				}
			}

			pTypeAffinity = GetEventLauncher().Event_RewriteWazaAffinity(attacker, defender, wazaParam.wazaType, pTypeAffinity);
		}

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public DmgAffRec affinityRecorder;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				targets = null;
				affinityRecorder = null;
			}
		}

		public class Result { }
	}
}