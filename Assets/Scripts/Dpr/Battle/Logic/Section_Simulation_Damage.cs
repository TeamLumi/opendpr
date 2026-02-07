using Pml;
using Pml.Battle;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_Simulation_Damage : Section
	{
		public Section_Simulation_Damage(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result result, in Description description)
		{
			result.damage = 0;

			BTL_POKEPARAM attacker = GetPokeParam(description.atkPokeID);
			BTL_POKEPARAM defender = GetPokeParam(description.defPokeID);
			WazaNo waza = description.waza;

			// Get move power
			uint wazaPower = WAZADATA.GetPower(waza);
			if (wazaPower == 0)
			{
				return;
			}

			// Get attack and defense stats based on damage type
			WazaDamageType damageType = WAZADATA.GetDamageType(waza);
			uint atkPower;
			uint defPower;
			if (damageType == WazaDamageType.SPECIAL)
			{
				atkPower = (uint)attacker.GetValue(BTL_POKEPARAM.ValueID.BPP_SP_ATTACK);
				defPower = (uint)defender.GetValue(BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE);
			}
			else
			{
				atkPower = (uint)attacker.GetValue(BTL_POKEPARAM.ValueID.BPP_ATTACK);
				defPower = (uint)defender.GetValue(BTL_POKEPARAM.ValueID.BPP_DEFENCE);
			}

			uint atkLevel = (uint)attacker.GetValue(BTL_POKEPARAM.ValueID.BPP_LEVEL);

			// Base damage calculation
			uint damage = calc.DamageBase(wazaPower, atkPower, atkLevel, defPower);

			// Apply random factor if enabled
			if (description.isRandomEnable)
			{
				uint rand = calc.GetRand(16); // 0-15
				damage = damage * (100 - rand) / 100;
			}

			// Apply type affinity if enabled
			if (description.isAffinityEnable)
			{
				TypeAffinity.AffinityID aff = checkTypeAffinity(description.atkPokeID, description.defPokeID, waza);
				damage = calc.AffDamage(damage, aff);
			}

			// Apply STAB (Same Type Attack Bonus)
			byte wazaType = (byte)WAZADATA.GetType(waza);
			if (attacker.IsMatchType(wazaType))
			{
				damage = damage * 3 / 2;
			}

			// Apply weather modifier
			BtlWeather weather = getLoaclWeather(description.atkPokeID);
			if (wazaType == (byte)PokeType.HONOO)
			{
				if (calc.IsShineWeather(weather))
				{
					damage = damage * 3 / 2;
				}
				else if (calc.IsRainWeather(weather))
				{
					damage = damage / 2;
				}
			}
			else if (wazaType == (byte)PokeType.MIZU)
			{
				if (calc.IsRainWeather(weather))
				{
					damage = damage * 3 / 2;
				}
				else if (calc.IsShineWeather(weather))
				{
					damage = damage / 2;
				}
			}

			if (damage == 0)
			{
				damage = 1;
			}

			result.damage = (ushort)damage;
		}

		private TypeAffinity.AffinityID checkTypeAffinity(byte attackerID, byte defenderID, WazaNo waza)
		{
			var desc = new Section_Simulation_TypeAffinity.Description();
			desc.atkPokeID = attackerID;
			desc.defPokeID = defenderID;
			desc.waza = waza;

			var result = new Section_Simulation_TypeAffinity.Result();
			var section = new Section_Simulation_TypeAffinity(GetCommonParam());
			section.Execute(result, in desc);

			return result.affinity;
		}

		private BtlWeather getLoaclWeather(byte pokeID)
		{
			var desc = new Section_FromEvent_GetWeather.Description();
			desc.pokeID = pokeID;

			var result = new Section_FromEvent_GetWeather.Result();
			var section = new Section_FromEvent_GetWeather(GetCommonParam());
			section.Execute(result, in desc);

			return result.weather;
		}

		public class Description
		{
			public byte atkPokeID;
			public byte defPokeID;
			public WazaNo waza;
			public bool isAffinityEnable;
			public bool isRandomEnable;

			public Description()
			{
				atkPokeID = PokeID.INVALID;
				defPokeID = PokeID.INVALID;
				waza = WazaNo.NULL;
				isAffinityEnable = false;
				isRandomEnable = false;
			}
		}

		public class Result
		{
			public ushort damage;
		}
	}
}
