using Pml;
using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckWazaDamageAffinity : Section
	{
		public Section_CheckWazaDamageAffinity(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			BTL_POKEPARAM defender = description.defender;
			WazaParam wazaParam = description.wazaParam;
			byte wazaType = wazaParam.wazaType;

			TypeAffinity.AffinityID affinity = GetEventLauncher().Event_CheckDamageAffinity(attacker, defender, wazaType, description.checkOnlyAttacker);

			bool isNoEffectByFloatingStatus = false;
			affinity = rewiteWazaAffinityByFloatingStatus(ref isNoEffectByFloatingStatus, attacker, defender, wazaType, affinity);
			affinity = rewiteWazaAffinityByTarSick(defender, wazaType, affinity);

			pResult.typeAffinity = affinity;
			pResult.isNoEffectByFloatingStatus = isNoEffectByFloatingStatus;
		}

		public TypeAffinity.AffinityID rewiteWazaAffinityByFloatingStatus(ref bool isNoEffectByFloatingStatus, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, byte wazaType, TypeAffinity.AffinityID affinity)
		{
			if (wazaType != (byte)PokeType.JIMEN)
			{
				return affinity;
			}

			if (checkFloating(defender, true))
			{
				isNoEffectByFloatingStatus = true;
				return TypeAffinity.AffinityID.TYPEAFF_0;
			}

			return affinity;
		}

		private bool checkFloating(BTL_POKEPARAM pPoke, bool isIncludeHikouType)
		{
			return GetEventLauncher().Event_CheckFloating(pPoke, isIncludeHikouType);
		}

		public TypeAffinity.AffinityID rewiteWazaAffinityByTarSick(BTL_POKEPARAM defender, byte wazaType, TypeAffinity.AffinityID affinity)
		{
			return affinity;
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BTL_POKEPARAM defender;
			public WazaParam wazaParam;
			public bool checkOnlyAttacker;
			
			public Description()
			{
				attacker = null;
				defender = null;
				wazaParam = null;
				checkOnlyAttacker = false;
			}
		}

		public class Result
		{
			public TypeAffinity.AffinityID typeAffinity;
			public bool isNoEffectByFloatingStatus;
		}
	}
}