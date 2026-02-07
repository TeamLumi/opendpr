using Pml;
using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class Section_Simulation_TypeAffinity : Section
	{
		public Section_Simulation_TypeAffinity(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			BTL_POKEPARAM attacker = GetPokeParam(description.atkPokeID);
			BTL_POKEPARAM defender = GetPokeParam(description.defPokeID);

			WazaParam wazaParam = new WazaParam();
			WazaParam.Init(wazaParam);
			wazaParam.wazaID = description.waza;
			wazaParam.wazaType = (byte)WAZADATA.GetType(description.waza);

			result.affinity = checkTypeAffinity(attacker, defender, wazaParam, description.onlyAttacker);
		}

		private TypeAffinity.AffinityID checkTypeAffinity(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, bool checkOnlyAttacker)
		{
			TypeAffinity.AffinityID aff = GetEventLauncher().Event_CheckDamageAffinity(attacker, defender, wazaParam.wazaType, checkOnlyAttacker);
			aff = GetEventLauncher().Event_RewriteWazaAffinity(attacker, defender, wazaParam.wazaType, aff);
			return aff;
		}

		public class Description
		{
			public byte atkPokeID;
			public byte defPokeID;
			public WazaNo waza;
			public bool onlyAttacker;
			
			public Description()
			{
				atkPokeID = PokeID.INVALID;
				defPokeID = PokeID.INVALID;
				waza = WazaNo.NULL;
				onlyAttacker = false;
			}
		}

		public class Result
		{
			public TypeAffinity.AffinityID affinity;
		}
	}
}